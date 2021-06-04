Imports System.Threading

Public NotInheritable Class frmDenomination
    Dim OneThousand As Integer
    Dim FiveHundred As Integer
    Dim TwoHundred As Integer
    Dim OneHundred As Integer
    Dim Fifty As Integer
    Dim Tweenty As Integer
    Dim Ten As Integer
    Dim Five As Integer
    Dim One As Integer
    Dim TweentyFive As Integer
    Dim TenCents As Integer
    Dim FiveCents As Integer
    Dim Amt2Devide As Double, NoOfDenom As Integer

    Private Sub frmDenomination_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Amt2Devide = Convert.ToDouble(IIf(lblChange.Text = "", 0, lblChange.Text))
        OneThousand = 0
        FiveHundred = 0
        TwoHundred = 0
        OneHundred = 0
        Fifty = 0
        Tweenty = 0
        Ten = 0
        Five = 0
        One = 0
        TweentyFive = 0
        TenCents = 0
        FiveCents = 0

        If Amt2Devide >= 1000 Then
            While Amt2Devide >= 1000
                OneThousand = OneThousand + 1
                Amt2Devide = Amt2Devide - 1000
            End While
            If OneThousand <> 0 Then LOneThousand.ForeColor = Color.Red
        End If
        If Amt2Devide >= 500 Then
            While Amt2Devide >= 500
                FiveHundred = FiveHundred + 1
                Amt2Devide = Amt2Devide - 500
            End While
            If FiveHundred <> 0 Then LFiveHundred.ForeColor = Color.Red
        End If
        If Amt2Devide >= 200 Then
            While Amt2Devide >= 200
                TwoHundred = TwoHundred + 1
                Amt2Devide = Amt2Devide - 200
            End While
            If TwoHundred <> 0 Then LTwoHundred.ForeColor = Color.Red
        End If
        If Amt2Devide >= 100 Then
            While Amt2Devide >= 100
                OneHundred = OneHundred + 1
                Amt2Devide = Amt2Devide - 100
            End While
            If OneHundred <> 0 Then LOneHundred.ForeColor = Color.Red
        End If
        If Amt2Devide >= 50 Then
            While Amt2Devide >= 50
                Fifty = Fifty + 1
                Amt2Devide = Amt2Devide - 50
            End While
            If Fifty <> 0 Then LFifty.ForeColor = Color.Red
        End If
        If Amt2Devide >= 20 Then
            While Amt2Devide >= 20
                Tweenty = Tweenty + 1
                Amt2Devide = Amt2Devide - 20
            End While
            If Tweenty <> 0 Then LTweenty.ForeColor = Color.Red
        End If
        If Amt2Devide >= 10 Then
            While Amt2Devide >= 10
                Ten = Ten + 1
                Amt2Devide = Amt2Devide - 10
            End While
            If Ten <> 0 Then LTen.ForeColor = Color.Red
        End If
        If Amt2Devide >= 5 Then
            While Amt2Devide >= 5
                Five = Five + 1
                Amt2Devide = Amt2Devide - 5
            End While
            If Five <> 0 Then LFive.ForeColor = Color.Red
        End If
        If Amt2Devide >= 1 Then
            While Amt2Devide >= 1
                One = One + 1
                Amt2Devide = Amt2Devide - 1
            End While
            If One <> 0 Then LOne.ForeColor = Color.Red
        End If
        If Amt2Devide >= 0.25 Then
            While Amt2Devide >= 0.25
                TweentyFive = TweentyFive + 1
                Amt2Devide = Amt2Devide - 0.25
            End While
            If TweentyFive <> 0 Then LTweentyFive.ForeColor = Color.Red
        End If
        If Amt2Devide >= 0.1 Then
            While Amt2Devide >= 0.1
                TenCents = TenCents + 1
                Amt2Devide = Amt2Devide - 0.1
            End While
            If TenCents <> 0 Then LTenCents.ForeColor = Color.Red
        End If
        If Amt2Devide >= 0.05 Then
            While Amt2Devide >= 0.05
                FiveCents = FiveCents + 1
                Amt2Devide = Amt2Devide - 0.05
            End While
            If FiveCents <> 0 Then LFiveCents.ForeColor = Color.Red
        End If
        LOneThousand.Text = OneThousand
        LFiveHundred.Text = FiveHundred
        LTwoHundred.Text = TwoHundred
        LOneHundred.Text = OneHundred
        LFifty.Text = Fifty
        LTweenty.Text = Tweenty
        LTen.Text = Ten
        LFive.Text = Five
        LOne.Text = One
        LTweentyFive.Text = TweentyFive
        LTenCents.Text = TenCents
        LFiveCents.Text = FiveCents
        'lblChange.Text = Format(lblChange.Text, "c")
    End Sub

    Private Sub frmDenomination_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            'Me.Close()
            'Me.Dispose()
            Beep()
        ElseIf e.KeyCode = Keys.F1 Then
            frmSalesOrderTaking.ClearControls()
            frmSalesOrderTaking.change_bkGround(Color.DarkGray)
            frmSalesOrderTaking.Lock_Controls(False)
            Me.Close()
            Me.Dispose()
            NOT_SAVE_FLAG = False
            TRANSACTION_NUMBER = 0
            OFFICIAL_RECEIPT_NO = ""
        End If
    End Sub

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub frmDenomination_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        KeyPreview = True
        Timer1.Enabled = True
        Timer1.Interval = 150
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title & Chr(13) & Chr(13) & My.Application.Info.CompanyName & Chr(13) & My.Application.Info.Trademark & Chr(13) & Chr(13) & My.Application.Info.Description
        Else
            'If the application title is missing, use the application name, without the extension
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        'Copyright info
        Copyright.Text = My.Application.Info.Copyright
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Label30.ForeColor = Color.Blue Then
            'Label1.ForeColor = Color.Yellow
            Label30.ForeColor = Color.Yellow
            lblChange.ForeColor = Color.Yellow
        Else
            ' Label1.ForeColor = Color.Blue
            Label30.ForeColor = Color.Blue
            lblChange.ForeColor = Color.Blue
        End If

    End Sub

    Private Sub LTwoHundred_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LTwoHundred.Click

    End Sub

    Private Sub LFive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LFive.Click

    End Sub



    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Dim strtStr As String = "Press F1 twice to start a new transaction!"
    Dim strtPos As Integer = Len("Press F1 twice to start a new transaction!")

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer2.Interval = 20
        'Label8.Text = "Press F1 to start a new transaction. . ."

        strtPos = strtPos - 1
        If strtPos = 0 Then
            strtPos = Len("Press F1 twice to start a new transaction!")
            Thread.Sleep(1000)
        End If

        Label8.Text = Mid(StrReverse("Press F1 twice to start a new transaction!"), strtPos)
        Label8.Text = StrReverse(Label8.Text)

    End Sub
End Class
