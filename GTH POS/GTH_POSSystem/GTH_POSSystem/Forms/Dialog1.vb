Imports System.Windows.Forms

Public Class Dialog1

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If lblMessage.ForeColor = Color.Black Then
            lblMessage.ForeColor = Color.Maroon
        Else
            lblMessage.ForeColor = Color.Black
        End If
        If lblMessage.Visible = True Then
            lblMessage.Visible = False
        Else
            lblMessage.Visible = True
        End If
        Timer1.Interval = 150
    End Sub
End Class
