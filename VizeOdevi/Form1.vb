Public Class Form1
    Dim sayac As Integer
    Dim enemy As PictureBox
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Drawing.Size(516, 599)
        Me.KeyPreview = True
        spaceship.Location = New Point(215, spaceship.Location.Y)
        sayac = 0
        puan.Text = sayac.ToString
    End Sub
    Public Sub enemyOlustur()
        Dim RastgeleSayi As New Random
        Dim OlusturulanSayi As Integer = RastgeleSayi.Next(-20, 450)

        Timer1.Enabled = True
        enemy = New PictureBox
        enemy.Image = Image.FromFile("C:\Users\serhat\source\repos\VizeOdevi\VizeOdevi\enemy.png")
        enemy.Visible = True
        enemy.SizeMode = PictureBoxSizeMode.Zoom
        enemy.Top = 0
        enemy.Left = OlusturulanSayi
        Panel2.Controls.Add(enemy)
    End Sub
    Private Sub baslatButton_Click(sender As Object, e As EventArgs) Handles baslatButton.Click
        Panel2.Controls.Remove(enemy)
        Timer1.Interval = 101
        spaceship.Location = New Point(215, spaceship.Location.Y)
        sayac = 0
        puan.Text = sayac.ToString
        enemyOlustur()
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Right Or e.KeyCode = Keys.A Then
            If spaceship.Location.X <= 0 Then
            Else
                spaceship.Left -= 15
            End If
        End If
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.D Then
            If spaceship.Location.X >= 430 Then
            Else
                spaceship.Left += 15
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        enemy.Top += 10
        If enemy.Location.Y >= 323 And enemy.Location.Y <= 450 Then
            If enemy.Location.X >= spaceship.Location.X - 50 And enemy.Location.X <= spaceship.Location.X + 50 Then
                Timer1.Enabled = False
                MessageBox.Show("Puanın: " + sayac.ToString, "Oyun Bitti !")
            End If
        End If
        If enemy.Location.Y >= 500 Then
            sayac += 1
            puan.Text = sayac.ToString
            Panel2.Controls.Remove(enemy)
            If Timer1.Interval = 1 Then
                Timer1.Interval = 1
            Else
                Timer1.Interval -= 10
            End If
            Timer1.Enabled = False
            enemyOlustur()
        End If
    End Sub
End Class
