' Пользовательский элемент управления 
' Отображает в графическом виде данные, полученные от ПИР6 (или ЦВР 10)

Public Class KSP

    Private colValLineColor As Color = Color.Black
    Private colNullLineColor As Color = Color.Red
    Private colBackColor As Color = Color.White

    Private dblMaxVal, dblMinVal, dblInputVal, dblScaleXUnit As Double
    Private intMaxX, intMaxY, intNullX, intCurIndex As Integer

    Private intValArray() As Integer



    Private g As Graphics = Me.CreateGraphics


    '################################################################################
    '#############  Свойства контрола
    '################################################################################
    Public Overrides Property BackColor() As System.Drawing.Color
        Get
            Return colBackColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            colBackColor = value
            MyBase.BackColor = colBackColor
        End Set
    End Property
    Public Property ValLineColor() As Color
        Get
            Return colValLineColor
        End Get
        Set(ByVal value As Color)
            colValLineColor = value
        End Set
    End Property
    Public Property NullLineColor() As Color
        Get
            Return colNullLineColor
        End Get
        Set(ByVal value As Color)
            colNullLineColor = value
        End Set
    End Property
    Public Property MaxVal() As Double
        Get
            Return dblMaxVal
        End Get
        Set(ByVal value As Double)
            dblMaxVal = value
            dblScaleXUnit = IIf(dblMaxVal = dblMinVal, 0, intMaxX / (dblMaxVal - dblMinVal))
            intNullX = -dblMinVal * dblScaleXUnit
            g.Clear(colBackColor)
        End Set
    End Property
    Public Property MinVal() As Double
        Get
            Return dblMinVal
        End Get
        Set(ByVal value As Double)
            dblMinVal = value
            dblScaleXUnit = IIf(dblMaxVal = dblMinVal, 0, intMaxX / (dblMaxVal - dblMinVal))
            intNullX = -dblMinVal * dblScaleXUnit
            g.Clear(colBackColor)
        End Set
    End Property
    Public Property InputVal() As Double
        Get
            Return dblInputVal
        End Get
        Set(ByVal value As Double)
            dblInputVal = value
            If intValArray Is Nothing Then Exit Property

            Dim dblCurrentInput As Double

            If dblInputVal < dblMinVal Then
                dblCurrentInput = dblMinVal
            ElseIf dblInputVal > dblMaxVal Then
                dblCurrentInput = dblMaxVal
            Else
                dblCurrentInput = dblInputVal
            End If
            intValArray(intCurIndex) = (dblCurrentInput - dblMinVal) * dblScaleXUnit
            Call ReDraw()
            intCurIndex = intCurIndex + 1
            If intCurIndex > intMaxY Then intCurIndex = 0

        End Set
    End Property
    '################################################################################

    Private Sub KSP_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        g = Me.CreateGraphics
        Call InitControl()
    End Sub
    Private Sub InitControl()
        intMaxX = MyBase.Width - 1
        intMaxY = MyBase.Height - 1
        dblScaleXUnit = IIf(dblMaxVal = dblMinVal, 0, intMaxX / (dblMaxVal - dblMinVal))
        intNullX = -dblMinVal * dblScaleXUnit
        ReDim intValArray(0 To intMaxY)
        intCurIndex = 0

        Me.PictureBox1.Width = Me.Width
        Me.PictureBox1.Height = Me.Height
        Me.PictureBox1.Location = New Point(0, 0)

    End Sub
    Private Sub ReDraw()
        Dim bmp As New Bitmap(Me.PictureBox1.Width, Me.PictureBox1.Height)
        Dim gr As Graphics = Graphics.FromImage(bmp)

        Dim intPrevY As Integer
        For intI As Integer = intCurIndex To 0 Step -1
            intPrevY = IIf(intI = 0, intMaxY, intI - 1)
            If intValArray(intI) <> intValArray(intPrevY) Then
                gr.DrawEllipse(New Pen(colBackColor), intValArray(intPrevY), intCurIndex - intI, 1, 1)
            End If
            gr.DrawEllipse(New Pen(colValLineColor), intValArray(intI), intCurIndex - intI, 1, 1)
            If Not intValArray(intI) = intNullX Then gr.DrawEllipse(New Pen(colNullLineColor), intNullX, intCurIndex - intI, 1, 1)
        Next intI

        For intI As Integer = intMaxY To intCurIndex + 1 Step -1
            intPrevY = IIf(intI = 0, intMaxY, intI - 1)
            If intValArray(intI) <> intValArray(intPrevY) Then
                gr.DrawEllipse(New Pen(colBackColor), intValArray(intPrevY), intMaxY + intCurIndex - intI + 1, 1, 1)
            End If
            gr.DrawEllipse(New Pen(colValLineColor), intValArray(intI), intMaxY + intCurIndex - intI + 1, 1, 1)
            If Not intValArray(intI) = intNullX Then gr.DrawEllipse(New Pen(colNullLineColor), intNullX, intMaxY + intCurIndex - intI + 1, 1, 1)
        Next intI
        Me.PictureBox1.Image = bmp




        'g.SmoothingMode = Drawing2D.SmoothingMode.None

        'Dim intPrevY As Integer

        'For intI As Integer = intCurIndex To 0 Step -1
        '    intPrevY = IIf(intI = 0, intMaxY, intI - 1)
        '    If intValArray(intI) <> intValArray(intPrevY) Then
        '        g.DrawEllipse(New Pen(colBackColor), intValArray(intPrevY), intCurIndex - intI, 1, 1)
        '    End If
        '    g.DrawEllipse(New Pen(colValLineColor), intValArray(intI), intCurIndex - intI, 1, 1)
        '    If Not intValArray(intI) = intNullX Then g.DrawEllipse(New Pen(colNullLineColor), intNullX, intCurIndex - intI, 1, 1)
        'Next intI

        'For intI As Integer = intMaxY To intCurIndex + 1 Step -1
        '    intPrevY = IIf(intI = 0, intMaxY, intI - 1)
        '    If intValArray(intI) <> intValArray(intPrevY) Then
        '        g.DrawEllipse(New Pen(colBackColor), intValArray(intPrevY), intMaxY + intCurIndex - intI + 1, 1, 1)
        '    End If
        '    g.DrawEllipse(New Pen(colValLineColor), intValArray(intI), intMaxY + intCurIndex - intI + 1, 1, 1)
        '    If Not intValArray(intI) = intNullX Then g.DrawEllipse(New Pen(colNullLineColor), intNullX, intMaxY + intCurIndex - intI + 1, 1, 1)
        'Next intI
    End Sub
End Class
