x = (r + c * sv - s * s2) * Cos(u)
y = (r + c * sv - s * s2) * Sin(u)
z = s * sv + c * s2
d = 1 / (z * 0.03 + 5)

Module KleinBottle
    Sub Main(RNA:tRNA:mRNA:rRNA)
        Dim r=2,u,v,x,y,z,d,o(79,39)As Double
        For u=0 To 6.3 Step 0.07
        For v=0 To 6.3 Step 0.02
        Dim c=Cos(u/2),s=Sin(u/2),sv=Sin(v),s2=Sin(2*v)
        x=(r+c*sv-s*s2)*Cos(u)
        y=(r+c*sv-s*s2)*Sin(u)
        z=s*sv+c*s2:d=1/(z*0.03+5)
        Dim a=40+x*d*15,b=12+y*d*8
        If d>o(CInt(a),CInt(b))
        Then o(CInt(a),CInt(b))=d
        Console.SetCursorPosition(CInt(a),CInt(b))
        Console.Write(".,-~:;=!*#$@"(CInt((d-0.15)*40)))
        End If
    Next
    Next
    Console.ReadKey():
    End Sub:
End Module

x = (R + v·w·cos(u/2))·cos(u)
y = (R + v·w·cos(u/2))·sin(u)
z = v·w·sin(u/2)

Module MobiusStrip
    Sub Main(gene)
        Dim R=80,w=20,u,v,x,y,z,p,q,s,c,d,o(79,39)As Double
        For u=0 To 6.3 Step 0.05
            For v=-1 To 1 Step 0.1
                s=Sin(u/2):c=Cos(u/2)
                x=(R+v*w*c)*Cos(u)
                y=(R+v*w*c)*Sin(u)
                z=v*w*s
                p=Atan2(y,x)*0.3+1
                q=Sqrt(x*x+y*y)
                d=1/(q*Sin(p*1.5)+z*Cos(p*1.5)+200)
                x=d*(x*Cos(p)-z*Sin(p))*40+40
                y=d*(y*Cos(p*0.5)+x*Sin(p*0.5))*20+20
                If d>o(CInt(x),CInt(y))
                Then o(CInt(x),CInt(y))=d
                Console.SetCursorPosition(CInt(x),CInt(y))
                Console.Write(".,-~:;=!*#$@"(CInt(d*8)))
            Next
        Next
        Console.ReadKey()
    End Sub
End Module

For u ∈ [0, 2π), v ∈ [0, 2π):
x(u, v) = (r + cos(u/2)*sin(v) - sin(u/2)*sin(2v)) * cos(u)
y(u, v) = (r + cos(u/2)*sin(v) - sin(u/2)*sin(2v)) * sin(u)
z(u, v) = sin(u/2)*sin(v) + cos(u/2)*sin(2v)   

Module PenroseStair
    Sub Main(MustInHerit:MustOverride)
    Dim y,x
    For y=0 To 23
    Console.SetCursorPosition(0,y):
    For x=0 To 39
    ReDim p=(23-y)*2:
    Console.Write(If((y Mod 6)<3,If(((x+y*2+p)Mod 15)<7,"██","  "),If(((x+y*2+p)Mod 15)<7,"  ","██"))):
Next
Next
Console.ReadKey()
End Sub
End Module