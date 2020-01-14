Public Class Form1
    Dim ways(4) As Integer
    Dim Ntime, Stime, Etime, Wtime, multiplier As Integer
    Dim Nweight As Integer
    Dim Sweight As Integer
    Dim Eweight As Integer
    Dim Wweight As Integer
    Dim cyclelength As Integer
    Dim counter, ic As Integer
    Dim cnt As Integer = 1 '1N 2S 3W 4E test this is a change 
    Dim yy As Integer = 3 'length of yellow signal
    Dim a, b, c, d, e As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dance() 'todo make the lights dance on startup
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles startBtn.Click 'start
        a = 0
        b = 0
        c = 0
        d = 0
        e = 0
        seconds.Interval = 1000 / Integer.Parse(TextBox2.Text)
        Nweight = Integer.Parse(weightNorth.Text)
        Sweight = Integer.Parse(weightSouth.Text)
        Eweight = Integer.Parse(weightEast.Text)
        Wweight = Integer.Parse(weightWest.Text)

        cyclelength = Integer.Parse(TextBox1.Text) * 60
        Dim weightTotal As Integer = Nweight + Sweight + Eweight + Wweight
        Ntime = (Nweight / weightTotal) * cyclelength
        Stime = (Sweight / weightTotal) * cyclelength
        Etime = (Eweight / weightTotal) * cyclelength
        Wtime = (Wweight / weightTotal) * cyclelength

        ways(0) = Ntime
        ways(1) = Stime
        ways(2) = Wtime
        ways(3) = Etime

        NLbl.Text = Ntime - yy 'starts with go timer
        SLbl.Text = Ntime
        WLbl.Text = Stime + Ntime
        ELbl.Text = Stime + Ntime + Wtime

        counter = Ntime
        cnt = 1
        seconds.Enabled = True
    End Sub

    Private Sub Lights_Controller(greenlight As Object)
        If greenlight = NGreen Then
            NYellow.Visible = False
            NRed.Visible = False

            EGreen.Visible = False
            EYellow.Visible = False
            ERed.Visible = True

            WGreen.Visible = False
            WYellow.Visible = False
            WRed.Visible = True

            SGreen.Visible = False
            SYellow.Visible = False
            SRed.Visible = True
        End If
    End Sub

    Private Sub northGreen()
        'GO FOR NORTH
        Redder()
        NGreen.Visible = True
        NYellow.Visible = False
        NRed.Visible = False
    End Sub

    Private Sub southGreen()
        'GO FOR SOUTH
        Redder()
        SGreen.Visible = True
        SYellow.Visible = False
        SRed.Visible = False
    End Sub

    Private Sub seconds_Tick(sender As Object, e As EventArgs) Handles seconds.Tick

        If counter = 1 Then
            If cnt + 1 = 5 Then
                cnt = 1
            Else
                cnt += 1
            End If
            counter = ways(cnt - 1) + 1
        End If

        If counter <= 4 Then
            Yellower(cnt) '4,3,2
        Else
            Greener(cnt) '15,14,13,12,11,10,9,8,7,6,5
        End If
        decrementer()
        counter -= 1

        If cnt = 1 Then
            a += 1
        End If

        If cnt = 2 Then
            b += 1
        End If

        If cnt = 3 Then
            c += 1
        End If

        If cnt = 4 Then
            d += 1
        End If
    End Sub

    Private Sub eastGreen()
        'GO FOR EAST
        Redder()
        EGreen.Visible = True
        EYellow.Visible = False
        ERed.Visible = False
    End Sub

    Private Sub westGreen()
        'GO FOR WEST
        Redder()
        WGreen.Visible = True
        WYellow.Visible = False
        WRed.Visible = False
    End Sub


    Private Sub Redder()
        NRed.Visible = True
        ERed.Visible = True
        WRed.Visible = True
        SRed.Visible = True

        NGreen.Visible = False
        EGreen.Visible = False
        WGreen.Visible = False
        SGreen.Visible = False

        NYellow.Visible = False
        EYellow.Visible = False
        WYellow.Visible = False
        SYellow.Visible = False
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        seconds.Enabled = False
        MessageBox.Show("Total number of vehicles that crossed the intersection:" & vbCrLf &
                        NORTH.Text & " " & a & vbCrLf &
                        SOUTH.Text & " " & b & vbCrLf &
                        WEST.Text & " " & c & vbCrLf &
                        EAST.Text & " " & d & vbCrLf)

    End Sub

    Private Sub decrementer()
        'method to decrement the count for the lights
        Dim N, S, W, E As Integer

        'north
        If Integer.Parse(NLbl.Text) - 1 <> 0 Then
            NLbl.Text = Integer.Parse(NLbl.Text) - 1
        ElseIf Integer.Parse(NLbl.Text) - 1 = 0 And NYellow.Visible Then
            NLbl.Text = "3"
        ElseIf Integer.Parse(NLbl.Text) - 1 = 0 And NGreen.Visible Then
            NLbl.Text = Ntime - yy
        Else
            NLbl.Text = cyclelength - Ntime
        End If

        If NGreen.Visible Then
            NLbl.BackColor = Color.Green
        End If
        If NYellow.Visible Then
            NLbl.BackColor = Color.Yellow
        End If
        If NRed.Visible Then
            NLbl.BackColor = Color.Red
        End If

        'south
        If Integer.Parse(SLbl.Text) - 1 <> 0 Then
            SLbl.Text = Integer.Parse(SLbl.Text) - 1
        ElseIf Integer.Parse(SLbl.Text) - 1 = 0 And SYellow.Visible Then
            SLbl.BackColor = Color.Yellow
            SLbl.Text = "3"
        ElseIf Integer.Parse(SLbl.Text) - 1 = 0 And SGreen.Visible Then
            SLbl.Text = Stime - yy
        Else
            SLbl.Text = cyclelength - Stime

        End If
        If SGreen.Visible Then
            SLbl.BackColor = Color.Green
        End If
        If SYellow.Visible Then
            SLbl.BackColor = Color.Yellow
        End If
        If SRed.Visible Then
            SLbl.BackColor = Color.Red
        End If

        'west
        If Integer.Parse(WLbl.Text) - 1 <> 0 Then
            WLbl.Text = Integer.Parse(WLbl.Text) - 1
        ElseIf Integer.Parse(WLbl.Text) - 1 = 0 And WYellow.Visible Then
            WLbl.BackColor = Color.Yellow
            WLbl.Text = "3"
        ElseIf Integer.Parse(WLbl.Text) - 1 = 0 And WGreen.Visible Then
            WLbl.Text = Wtime - yy
        Else
            WLbl.Text = cyclelength - Wtime
        End If
        If WGreen.Visible Then
            WLbl.BackColor = Color.Green
        End If
        If WYellow.Visible Then
            WLbl.BackColor = Color.Yellow
        End If
        If WRed.Visible Then
            WLbl.BackColor = Color.Red
        End If

        'east
        If Integer.Parse(ELbl.Text) - 1 <> 0 Then
            ELbl.Text = Integer.Parse(ELbl.Text) - 1
        ElseIf Integer.Parse(ELbl.Text) - 1 = 0 And EYellow.Visible Then
            ELbl.BackColor = Color.Yellow
            ELbl.Text = "3"
        ElseIf Integer.Parse(ELbl.Text) - 1 = 0 And EGreen.Visible Then
            ELbl.Text = Etime - yy
        Else
            ELbl.Text = cyclelength - Etime
        End If
        If EGreen.Visible Then
            ELbl.BackColor = Color.Green
        End If
        If EYellow.Visible Then
            ELbl.BackColor = Color.Yellow
        End If
        If ERed.Visible Then
            ELbl.BackColor = Color.Red
        End If

    End Sub

    Private Sub Greener(n As Integer)
        Select Case n
            Case 1
                'north
                northGreen()
            Case 2
                'south
                southGreen()
            Case 3
                'west
                westGreen()
            Case 4
                'east
                eastGreen()
        End Select
    End Sub

    Private Sub Yellower(n As Integer)
        Select Case n
            Case 1
                'north
                yN()
            Case 2
                'south
                yS()
            Case 3
                'west
                yW()
            Case 4
                'east
                yE()
        End Select
    End Sub

    Private Sub yN() 'turns on yellow light on North way
        NGreen.Visible = False
        NYellow.Visible = True
        NRed.Visible = False
    End Sub

    Private Sub yS()
        SGreen.Visible = False
        SYellow.Visible = True
        SRed.Visible = False
    End Sub
    Private Sub yW()
        WGreen.Visible = False
        WYellow.Visible = True
        WRed.Visible = False
    End Sub
    Private Sub yE()
        EGreen.Visible = False
        EYellow.Visible = True
        ERed.Visible = False
    End Sub
    Private Sub dance()
        'make the lights dance
    End Sub
End Class