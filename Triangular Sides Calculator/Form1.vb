Public Class Form1
    Private angleA As Double
    Private angleB As Double
    Private sideA As Double
    Private sideB As Double
    Private sideC As Double
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        angleA = Val(TextBox4.Text)
        angleB = Val(TextBox1.Text)

        sideB = Val(TextBox2.Text)
        sideA = Val(TextBox1.Text)
        sideC = Val(TextBox3.Text)

        If IsValidInputs() = True Then
            If CalculateAngles() = True Then
                CalculateSides()
            End If
        End If

        'Dim AB, AC, BC As Single
        'AB = Val(TextBox1.Text)
        'AC = Val(TextBox2.Text)
        'BC = Val(TextBox3.Text)
        '
        'If AB <> 0 And AC <> 0 Then
        'BC = Math.Sqrt(AB ^ 2 + AC ^ 2)
        'TextBox3.Text = Math.Round(BC, 2)
        'ElseIf AB <> 0 And BC <> 0 Then
        'AC = Math.Sqrt(BC ^ 2 - AB ^ 2)
        'TextBox2.Text = Math.Round(AC, 2)
        'ElseIf AC <> 0 And BC <> 0 Then
        'AB = Math.Sqrt(BC ^ 2 - AC ^ 2)
        'TextBox1.Text = Math.Round(AB, 2)
        'End If
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Form2.show()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim a, b, c As Single
        a = Val(TextBox4.Text)
        b = Val(TextBox1.Text)
        c = Val(90)

        If a + b > 90 Then
            MessageBox.Show("The two angles cannot be greater than 90 Degrees!")
            Me.Close()
        Else
            'something here'
        End If
    End Sub
    Private Function IsValidInputs() As Boolean

        ' check angles
        If (angleA > 0 AndAlso angleB > 0) Then
            If (angleA + angleB) <> 90 Then
                MessageBox.Show("You input invalid two angles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End If

        ' check sides
        If (sideA > 0 AndAlso sideB > 0 AndAlso sideC > 0) Then
            If (sideC <> Math.Sqrt(Math.Pow(sideB, 2) + Math.Pow(sideA, 2))) Then
                MessageBox.Show("The three sides inputed do not make a right triangle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End If

        Return True

    End Function

    Private Function CalculateAngles() As Boolean

        If (angleA > 0) Then
            angleB = 90 - angleA

        ElseIf (angleB > 0) Then
            angleA = 90 - angleB


        ElseIf (sideA > 0 AndAlso sideB > 0) Then
            angleA = RadToDeg(Math.Atan(sideA / sideB))
            angleB = RadToDeg(Math.Atan(sideB / sideA))

        ElseIf (sideB > 0 AndAlso sideC > 0) Then
            angleA = RadToDeg(Math.Acos(sideB / sideC))
            angleB = RadToDeg(Math.Asin(sideB / sideC))

        ElseIf (sideA > 0 AndAlso sideC > 0) Then
            angleA = RadToDeg(Math.Asin(sideA / sideC))
            angleB = RadToDeg(Math.Acos(sideA / sideC))

        End If

        If (angleA > 0 AndAlso angleB > 0) Then
            TextBox4.Text = Math.Round(angleA)
            TextBox5.Text = Math.Round(angleB)
            Return True
        Else

            MessageBox.Show("You must input at least one side and an angle or two sides", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Return False

        End If

    End Function

    Private Sub CalculateSides()

        If (sideA > 0) Then
            sideB = sideA / Math.Tan(DegToRad(angleA))
            sideC = sideA / Math.Sin(DegToRad(angleA))

        ElseIf (sideB > 0) Then
            sideA = sideB / Math.Tan(DegToRad(angleB))
            sideC = sideB / Math.Sin(DegToRad(angleB))


        ElseIf (sideC > 0) Then
            sideA = sideC * Math.Cos(DegToRad(angleB))
            sideB = sideC * Math.Sin(DegToRad(angleB))

        End If

        If (sideA > 0 AndAlso sideB > 0 AndAlso sideC > 0) Then

            TextBox1.Text = Math.Round(sideA)
            TextBox2.Text = Math.Round(sideB)
            TextBox3.Text = Math.Round(sideC)

        Else

            MessageBox.Show("You must input at least one side and an angle or two sides", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

    End Sub

    Private Function RadToDeg(ByVal dblRad As Double) As Double
        Return (360 / (2 * Math.PI) * dblRad)
    End Function

    Private Function DegToRad(ByVal dblDeg As Double) As Double
        Return ((2 * Math.PI) / 360 * dblDeg)
    End Function

    'Private Function RoundResult(ByVal dblN As Double) As Double
    'Dim r As Double
    '   If ComboBox1.SelectedIndex = 0 Then
    '      Return dblN
    ' Else
    '    Return Math.Round(dblN, CInt(ComboBox1.Text))
    'End If
    'End Function
End Class
