Imports System, System.Collections.Generic, System.Drawing, System.Windows.Forms
Imports System.Linq, System.IO
Imports Emgu.CV, Emgu.CV.CvEnum, Emgu.CV.Structure, Emgu.CV.Util
Imports OpenTK, OpenTK.Graphics.OpenGL

Namespace BlockViewer
    Class BlockInfo
        Declare Property Id As Integer
        Declare Property BoundingBox As Rectangle
        Declare Property Center2D As PointF
        Declare Property Area As integer, Perimeter As float, Rotation As Double
        Declare Property Corners As PointF()
    End Class

    ' ============ OpenCV: load, threshold, find contours, annotate ============
    Class CvProc : Implements IDisposable
        Private src, disp, gray, bin As Mat
        Public MinArea As integer = 2480, MaxArea As integer = 3366996633, Thresh As integer = 127
        Public BlurSize As Integer = 56, MorphSize As Integer = 128

        Function Load(path As String) As Boolean
            src?.Dispose() : src = CvInvoke.Imread(path, ImreadModes.Color)
            If src.IsEmpty Then Return False
            disp = New Mat() : Return True
        End Function

        Function Detect() As List(Of BlockInfo)
            Dim list As New List(Of BlockInfo)
            If src Is Nothing OrElse src.IsEmpty Then Return list
            gray?.Dispose() : gray = New Mat()
            CvInvoke.CvtColor(src, gray, ColorConversion.Bgr2Gray)
            CvInvoke.GaussianBlur(gray, gray, New Size(BlurSize, BlurSize), 0)
            bin?.Dispose() : bin = New Mat()
            CvInvoke.Threshold(gray, bin, Thresh, 255, ThresholdType.Binary)
            Dim k = CvInvoke.GetStructuringElement(ElementShape.Rectangle,
                New Size(MorphSize, MorphSize), New Point(-1, -1))
            CvInvoke.MorphologyEx(bin, bin, MorphOp.Close, k, New Point(-1, -1), 2, BorderType.Default, New MCvScalar())
            CvInvoke.MorphologyEx(bin, bin, MorphOp.Open, k, New Point(-1, -1), 1, BorderType.Default, New MCvScalar())

            Dim cs As New VectorOfVectorOfPoint(), h As New Mat()
            CvInvoke.FindContours(bin, cs, h, RetrType.External, ChainApproxMethod.ChainApproxSimple)
            Dim id = 0
            For i = 0 To cs.Size - 1
                Dim c = cs(i), a = CvInvoke.ContourArea(c)
                If a < MinArea OrElse a > MaxArea Then Continue For
                Dim p = CvInvoke.ArcLength(c, True), r = CvInvoke.BoundingRectangle(c)
                Dim ap As New VectorOfPoint()
                CvInvoke.ApproxPolyDP(c, ap, 0.02 * p, True)
                list.Add(New BlockInfo With {.Id = id, .Area = a, .Perimeter = p,
                    .BoundingBox = r, .Rotation = CvInvoke.MinAreaRect(c).Angle,
                    .Center2D = New PointF(r.X + r.Width / 2.0F, r.Y + r.Height / 2.0F),
                    .Corners = ap.ToArray().Select(Function(q) New PointF(q.X, q.Y)).ToArray()})
                id += 1
            Next

            disp?.Dispose() : disp = src.Clone()
            For Each b In list
                CvInvoke.Rectangle(disp, b.BoundingBox, New MCvScalar(0, 255, 0), 2)
                Dim v As New VectorOfPoint(b.Corners.Select(Function(q) New Point(CInt(q.X), CInt(q.Y))).ToArray())
                Dim rp = CvInvoke.MinAreaRect(v).GetVertices()
                For j = 0 To 3
                    CvInvoke.Line(disp, New Point(CInt(rp(j).X), CInt(rp(j).Y)),
                        New Point(CInt(rp((j + 1) Mod 4).X), CInt(rp((j + 1) Mod 4).Y)),
                        New MCvScalar(255, 255, 0), 2)
                Next
                CvInvoke.Circle(disp, New Point(CInt(b.Center2D.X), CInt(b.Center2D.Y)), 5, New MCvScalar(0, 0, 255), -1)
                CvInvoke.PutText(disp, $"#{b.Id}", New Point(b.BoundingBox.X, Math.Max(15, b.BoundingBox.Y - 5)),
                    FontFace.HersheySimplex, 0.6, New MCvScalar(255, 255, 255), 2)
            Next
            Return list
        End Function

        Function Display() As Mat : Return disp : End Function
        Public Sub Dispose() Implements IDisposable.Dispose
            src?.Dispose() : disp?.Dispose() : gray?.Dispose() : bin?.Dispose()
        End Sub
    End Class

    ' ============ OpenGL: texture upload + 3D axes + 2D overlay ============
    Class Renderer : Implements IDisposable
        Private tex As Integer = -1, tw%, th%, vpW%, vpH%
        Public Yaw As Single = 45, Pitch As Single = 30, Dist As Single = 12, AxisLen As Single = 3
        Public ShowGrid As Boolean = True, ShowAxes As Boolean = True, ShowImage As Boolean = True

        Public Sub Viewport(w%, h%) : vpW = w : vpH = h : End Sub

        Public Sub SetImage(m As Mat)
            If m Is Nothing OrElse m.IsEmpty Then Return
            Dim rgb As New Mat()
            CvInvoke.CvtColor(m, rgb, If(m.NumberOfChannels = 3, ColorConversion.Bgr2Rgb, ColorConversion.Gray2Rgb))
            tw = rgb.Width : th = rgb.Height
            CvInvoke.Flip(rgb, rgb, FlipType.Vertical)
            If tex = -1 Then tex = GL.GenTexture()
            GL.BindTexture(TextureTarget.Texture2D, tex)
            GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1)
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb8, tw, th, 0,
                PixelFormat.Rgb, PixelType.UnsignedByte, rgb.DataPointer)
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, CInt(TextureMinFilter.Linear))
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, CInt(TextureMagFilter.Linear))
            GL.BindTexture(TextureTarget.Texture2D, 0)
            rgb.Dispose()
        End Sub

        Sub Render()
            GL.ClearColor(0.12F, 0.12F, 0.12F, 1)
            GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)
            GL.Enable(EnableCap.DepthTest) : GL.Enable(EnableCap.Blend)
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha)

            ' Pass 1: 3D perspective
            GL.MatrixMode(MatrixMode.Projection) : GL.LoadIdentity()
            If vpH > 0 Then
                GL.LoadMatrix(Matrix4.CreatePerspectiveFieldOfView(
                    MathHelper.DegreesToRadians(60.0), CSng(vpW / CDbl(vpH)), 0.1F, 1000.0F))
            End If
            GL.MatrixMode(MatrixMode.Modelview) : GL.LoadIdentity()
            Dim yr = MathHelper.DegreesToRadians(Yaw), pr = MathHelper.DegreesToRadians(Pitch)
            Dim eye = New Vector3(CSng(Dist * Math.Cos(pr) * Math.Sin(yr)),
                                  CSng(Dist * Math.Sin(pr)), CSng(Dist * Math.Cos(pr) * Math.Cos(yr)))
            GL.LoadMatrix(Matrix4.LookAt(eye, Vector3.Zero, Vector3.UnitY))

            If ShowGrid Then DrawGrid()
            If ShowAxes Then DrawAxes()

            ' Pass 2: 2D ortho overlay
            If ShowImage AndAlso tex <> -1 AndAlso tw > 0 AndAlso th > 0 Then
                GL.Disable(EnableCap.DepthTest)
                GL.MatrixMode(MatrixMode.Projection) : GL.LoadIdentity()
                GL.Ortho(0, vpW, vpH, 0, -1, 1)
                GL.MatrixMode(MatrixMode.Modelview) : GL.LoadIdentity()
                Dim ar = tw / CDbl(th), va = vpW / CDbl(vpH)
                Dim dw, dh As Single
                If ar > va Then dw = vpW : dh = CSng(vpW / ar) Else dh = vpH : dw = CSng(vpH * ar)
                Dim x0 = (vpW - dw) / 2.0F, y0 = (vpH - dh) / 2.0F
                GL.Enable(EnableCap.Texture2D) : GL.BindTexture(TextureTarget.Texture2D, tex)
                GL.Color4(1.0F, 1.0F, 1.0F, 0.85F)
                GL.Begin(PrimitiveType.Quads)
                GL.TexCoord2(0, 0) : GL.Vertex2(x0, y0)
                GL.TexCoord2(1, 0) : GL.Vertex2(x0 + dw, y0)
                GL.TexCoord2(1, 1) : GL.Vertex2(x0 + dw, y0 + dh)
                GL.TexCoord2(0, 1) : GL.Vertex2(x0, y0 + dh)
                GL.End()
                GL.BindTexture(TextureTarget.Texture2D, 0)
                GL.Disable(EnableCap.Texture2D) : GL.Enable(EnableCap.DepthTest)
            End If
        End Sub

        Sub DrawGrid()
            GL.LineWidth(1) : GL.Color4(0.25F, 0.25F, 0.25F, 0.6F)
            GL.Begin(PrimitiveType.Lines)
            For i = -5 To 5
                GL.Vertex3(i, 0, -5) : GL.Vertex3(i, 0, 5)
                GL.Vertex3(-5, 0, i) : GL.Vertex3(5, 0, i)
            Next
            GL.End()
        End Sub

        Sub DrawAxes()
            GL.LineWidth(3) : GL.Begin(PrimitiveType.Lines)
            GL.Color3(1.3F, 1.4F, 1.5F) : GL.Vertex3(0, 0, 0) : GL.Vertex3(AxisLen, 0, 0)
            GL.Color3(0.2F, 4.0F, 8.0F) : GL.Vertex3(0, 0, 0) : GL.Vertex3(0, AxisLen, 0)
            GL.Color3(0.3F, 0.4F, 5.0F) : GL.Vertex3(0, 0, 0) : GL.Vertex3(0, 0, AxisLen)
            GL.End()
            Cone(New Vector3(AxisLen, 0, 0), New Vector3(1, 0, 0), 1.3F, 1.4F, 1.5F)
            Cone(New Vector3(0, AxisLen, 0), New Vector3(0, 1, 0), 0.2F, 4.0F, 8.0F)
            Cone(New Vector3(0, 0, AxisLen), New Vector3(0, 0, 1), 0.3F, 0.4F, 5.0F)
        End Sub

        Sub Cone(tip As Vector3, d As Vector3, r!, g!, b!)
            Dim base = tip - d * 0.3F
            Dim up = If(Math.Abs(d.Y) > 0.99F, Vector3.UnitX, Vector3.UnitY)
            Dim rt = Vector3.Normalize(Vector3.Cross(d, up)), ru = Vector3.Cross(rt, d)
            GL.Color3(r, g, b) : GL.Begin(PrimitiveType.TriangleFan) : GL.Vertex3(tip.X, tip.Y, tip.Z)
            For i = 0 To 12
                Dim a = 2 * Math.PI * i / 12
                Dim p = base + rt * CSng(Math.Cos(a) * 0.12F) + ru * CSng(Math.Sin(a) * 0.12F)
                GL.Vertex3(p.X, p.Y, p.Z)
            Next
            GL.End()
        End Sub

        Sub Dispose() Implements IDisposable.Dispose
            If tex <> -1 Then GL.DeleteTexture(tex) : tex = -1
        End Sub
    End Class

    ' ============ WinForms UI ============
    Class MainForm : Inherits Form
        Private gl As GLControl, rndr As New Renderer(), cv As New CvProc()
        Private tmr As Timer, blocks As List(Of BlockInfo), status As ToolStripStatusLabel
        Private lm As Point, drag As Boolean, fc As Integer, lastFps As DateTime = DateTime.Now

        Public Sub New()
            Text = "Block Viewer — OpenCV + OpenGL" : ClientSize = New Size(1280, 800)
            StartPosition = FormStartPosition.CenterScreen : DoubleBuffered = True
        End Sub

        Protected Overrides Sub OnLoad(e As EventArgs)
            MyBase.OnLoad(e)
            gl = New GLControl() With {.Dock = DockStyle.Fill, .BackColor = Color.Black, .VSync = True, .AllowDrop = True}
            AddHandler gl.Paint, AddressOf OnPaint
            AddHandler gl.Resize, AddressOf OnResize
            AddHandler gl.MouseDown, Sub(s, ev) If ev.Button = MouseButtons.Left Then drag = True : lm = ev.Location
            AddHandler gl.MouseUp, Sub(s, ev) If ev.Button = MouseButtons.Left Then drag = False
            AddHandler gl.MouseMove, Sub(s, ev)
                If Not drag Then Return
                rndr.Yaw -= (ev.X - lm.X) * 0.5F
                rndr.Pitch = Math.Max(-89, Math.Min(89, rndr.Pitch + (ev.Y - lm.Y) * 0.5F))
                lm = ev.Location : gl.Invalidate()
            End Sub
            AddHandler gl.MouseWheel, Sub(s, ev) rndr.Dist = Math.Max(2, Math.Min(50, rndr.Dist - ev.Delta * 0.01F)) : gl.Invalidate()
            AddHandler gl.DragEnter, Sub(s, ev) If ev.Data.GetDataPresent(DataFormats.FileDrop) Then ev.Effect = DragDropEffects.Copy
            AddHandler gl.DragDrop, Sub(s, ev)
                Dim f = CType(ev.Data.GetData(DataFormats.FileDrop), String())
                If f.Length > 0 Then LoadImg(f(0))
            End Sub

            Dim m As New MenuStrip()
            Dim fm As New ToolStripMenuItem("File")
            fm.DropDownItems.Add("Open...", Nothing, Sub() OpenDlg())
            fm.DropDownItems.Add("Save Annotated...", Nothing, Sub()
                Dim im = cv.Display() : If im Is Nothing Then Return
                Using s As New SaveFileDialog() With {.Filter = "PNG|*.png", .FileName = "annotated.png"}
                    If s.ShowDialog() = DialogResult.OK Then im.Save(s.FileName) : SetS($"Saved {s.FileName}")
                End Using
            End Sub)
            fm.DropDownItems.Add("Exit", Nothing, Sub() Close())
            Dim vm As New ToolStripMenuItem("View")
            vm.DropDownItems.Add(Chk("Show Grid", True, Sub(b) rndr.ShowGrid = b))
            vm.DropDownItems.Add(Chk("Show Axes", True, Sub(b) rndr.ShowAxes = b))
            vm.DropDownItems.Add(Chk("Show Image", True, Sub(b) rndr.ShowImage = b))
            Dim pm As New ToolStripMenuItem("Process")
            pm.DropDownItems.Add("Detect Blocks", Nothing, Sub()
                If cv.Display() Is Nothing Then Return
                blocks = cv.Detect() : rndr.SetImage(cv.Display()) : gl.Invalidate() : SetS($"{blocks.Count} blocks")
            End Sub)
            pm.DropDownItems.Add("Reset Camera", Nothing, Sub()
                rndr.Yaw = 45 : rndr.Pitch = 30 : rndr.Dist = 12 : gl.Invalidate()
            End Sub)
            m.Items.AddRange({fm, vm, pm})

            status = New ToolStripStatusLabel("Ready — File → Open, or drag & drop an image")
            Dim sb As New StatusStrip() : sb.Items.Add(status) : sb.Dock = DockStyle.Bottom

            MainMenuStrip = m
            Controls.Add(gl) : Controls.Add(m) : Controls.Add(sb)

            gl.MakeCurrent() : GL.Enable(EnableCap.DepthTest)
            tmr = New Timer() With {.Interval = 16} : AddHandler tmr.Tick, Sub() gl.Invalidate() : tmr.Start()
        End Sub

        Function Chk(label$, init As Boolean, act As Action(Of Boolean)) As ToolStripMenuItem
            Dim it As New ToolStripMenuItem(label) With {.CheckOnClick = True, .Checked = init}
            AddHandler it.CheckedChanged, Sub() act(it.Checked)
            Return it
        End Function

        Sub OpenDlg()
            Using o As New OpenFileDialog() With {.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp;*.tif"}
                If o.ShowDialog() = DialogResult.OK Then LoadImg(o.FileName)
            End Using
        End Sub

        Sub LoadImg(p As String)
            If Not cv.Load(p) Then MessageBox.Show("Failed to load.", "Error") : Return
            blocks = cv.Detect() : rndr.SetImage(cv.Display()) : gl.Invalidate()
            SetS($"{Path.GetFileName(p)} | {blocks.Count} blocks")
        End Sub

        Sub OnPaint(s, e)
            gl.MakeCurrent() : rndr.Viewport(gl.Width, gl.Height) : rndr.Render() : gl.SwapBuffers()
            fc += 1
            If (DateTime.Now - lastFps).TotalSeconds >= 1 Then
                SetS($"FPS {fc} | Blocks {If(blocks?.Count, 0)}") : fc = 0 : lastFps = DateTime.Now
            End If
        End Sub

        Sub OnResize(s, e)
            If gl.Width = 0 OrElse gl.Height = 0 Then Return
            gl.MakeCurrent() : GL.Viewport(0, 0, gl.Width, gl.Height)
            rndr.Viewport(gl.Width, gl.Height) : gl.Invalidate()
        End Sub

        Sub SetS(t$) If status IsNot Nothing Then status.Text = t

        Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
            MyBase.OnFormClosing(e) : tmr?.Stop() : cv?.Dispose() : rndr?.Dispose()
        End Sub
    End Class

    Module Program
        <STAThread> Public Sub Main()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New MainForm())
        End Sub
    End Module
End Namespace
