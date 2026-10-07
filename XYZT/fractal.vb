Module FractalEnum
    Sub Main()
        ' Choose fractal: 1=Mandelbrot, 2=Julia, 3=Sierpinski, 4=BarnsleyFern, 5=KochSnowflake
        Dim choice = 1
        Select Case choice
            Case 1 : Mandelbrot(80, 40, 50)
            Case 2 : Julia(80, 40, 50, -0.8, 0.156)
            Case 3 : Sierpinski(63)
            Case 4 : BarnsleyFern(10000)
            Case 5 : KochSnowflake(4)
        End Select
    End Sub

    ' 1. Mandelbrot set (escape-time)
    Sub Mandelbrot(w, h, maxIter)
        For y = 0 To h - 1
            For x = 0 To w - 1
                Dim cx = (x - w * 0.75) / (w * 0.35)
                Dim cy = (y - h / 2) / (h * 0.4)
                Dim zx = 0.0, zy = 0.0, iter = 0
                While zx * zx + zy * zy < 4 AndAlso iter < maxIter
                    Dim tmp = zx * zx - zy * zy + cx
                    zy = 2 * zx * zy + cy
                    zx = tmp
                    iter += 1
                End While
                Console.Write(" .:-=+*#%@"(iter * 9 \ maxIter))
            Next
            Console.WriteLine()
        Next
    End Sub

    ' 2. Julia set (c = constant)
    Sub Julia(w, h, maxIter, cReal, cImag)
        For y = 0 To h - 1
            For x = 0 To w - 1
                Dim zx = (x - w / 2) / (w * 0.35)
                Dim zy = (y - h / 2) / (h * 0.4)
                Dim iter = 0
                While zx * zx + zy * zy < 4 AndAlso iter < maxIter
                    Dim tmp = zx * zx - zy * zy + cReal
                    zy = 2 * zx * zy + cImag
                    zx = tmp
                    iter += 1
                End While
                Console.Write(" .:-=+*#%@"(iter * 9 \ maxIter))
            Next
            Console.WriteLine()
        Next
    End Sub

    ' 3. Sierpinski triangle (binary/chaos game)
    Sub Sierpinski(size)
        Dim grid(size, size * 2) As Char
        For i = 0 To size
            For j = 0 To size * 2
                grid(i, j) = " "
            Next
        Next
        ' Recursive or deterministic: use Pascal's triangle mod 2
        For y = 0 To size
            For x = 0 To y
                If (y And x) = x Then grid(y, size + x - y) = "#"
            Next
        Next
        For y = 0 To size
            For x = 0 To size * 2
                Console.Write(grid(y, x))
            Next
            Console.WriteLine()
        Next
    End Sub

    ' 4. Barnsley fern (IFS)
    Sub BarnsleyFern(n)
        Dim x = 0.0, y = 0.0
        For i = 1 To n
            Dim r = Rnd()
            If r < 0.01 Then
                x = 0 : y = 0.16 * y
            ElseIf r < 0.86 Then
                x = 0.85 * x + 0.04 * y : y = -0.04 * x + 0.85 * y + 1.6
            ElseIf r < 0.93 Then
                x = 0.2 * x - 0.26 * y : y = 0.23 * x + 0.22 * y + 1.6
            Else
                x = -0.15 * x + 0.28 * y : y = 0.26 * x + 0.24 * y + 0.44
            End If
            ' Plot scaled to console (~60x40 grid)
            Dim px = 30 + CInt(x * 50)
            Dim py = 40 - CInt(y * 20)
            If px >= 0 And px < 80 And py >= 0 And py < 40 Then
                Console.SetCursorPosition(px, py)
                Console.Write("*")
            End If
        Next
    End Sub

    ' 5. Koch snowflake (L-system: F→F+F--F+F)
    Sub KochSnowflake(iter)
        Dim axiom = "F--F--F"
        Dim rule = "F+F--F+F"
        Dim current = axiom
        For i = 1 To iter
            Dim nextStr = ""
            For Each c In current
                If c = "F" Then nextStr &= rule Else nextStr &= c
            Next
            current = nextStr
        Next
        ' Interpret L-system as turtle graphics (simplified ASCII)
        Dim angle = 0, x = 40, y = 20
        For Each c In current
            If c = "F" Then
                Dim nx = x + Cos(angle) * 2
                Dim ny = y + Sin(angle) * 1.5
                Try : Console.SetCursorPosition(CInt(nx), CInt(ny)) : 
                      Console.Write("*") 
                    Catch 
                End Try
                x = nx : y = ny
            ElseIf c = "+" Then
                angle += PI / 3
            ElseIf c = "-" Then
                angle -= PI / 3
            End If
        Next
    End Sub
End Module