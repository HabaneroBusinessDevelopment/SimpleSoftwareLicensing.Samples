Imports Habanero.Licensing.Validation

Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim popup As New LicensePopup()
        popup.ShowDialog()

        'now we can check the new license
        UpdateUI()
    End Sub

    Private Sub btnStandard_Click(sender As System.Object, e As System.EventArgs) Handles btnStandard.Click
        Dim valResult As LicenseValidationResult = Common.FileValidator.CheckLicense()
        If valResult.State = LicenseState.Trial Then
            MessageBox.Show("Trial of standard feature!")
        Else
            If Not Common.FileValidator.IsEdition(Common.StandardOrHigher) Then
                MessageBox.Show("You do not have a standard edition")
                Return
            End If
            MessageBox.Show("Standard feature!")
        End If

    End Sub

    Private Sub btnPro_Click(sender As System.Object, e As System.EventArgs) Handles btnPro.Click
        Dim valResult As LicenseValidationResult = Common.FileValidator.CheckLicense()
        If valResult.State = LicenseState.Trial Then
            MessageBox.Show("Trial of pro feature!")
        Else
            If Not Common.FileValidator.IsEdition(Common.ProOrHigher) Then
                MessageBox.Show("You do not have a pro edition")
                Return
            End If
            MessageBox.Show("Pro feature!")
        End If
    End Sub

    Private Sub btnEnterprise_Click(sender As System.Object, e As System.EventArgs) Handles btnEnterprise.Click
        If Not Common.FileValidator.IsEdition(Common.EnterpriseOrHigher) Then
            MessageBox.Show("You do not have an enterprise edition")
            Return
        End If
        MessageBox.Show("Enterprise feature!")
    End Sub

    Private Sub UpdateUI()
        Dim localValidator As LicenseValidator = Common.FileValidator
        Dim valResult As LicenseValidationResult = localValidator.CheckLicense()
        Dim licenseStateString As String

        Select Case valResult.State
            Case LicenseState.Valid
                licenseStateString = "Valid"
            Case LicenseState.Trial
                licenseStateString = "Trial"
            Case Else
                licenseStateString = "Invalid"
        End Select

        Label1.Text = "Your license is: " + licenseStateString

        'region check what edition we are running
        'default to false
        btnPro.Enabled = False
        btnStandard.Enabled = False
        btnEnterprise.Enabled = False
        If (localValidator.IsEdition(Common.EnterpriseOrHigher)) Then
            btnEnterprise.Enabled = True
        End If

        If (localValidator.IsEdition(Common.ProOrHigher)) Then
            btnPro.Enabled = True
        End If

        If (localValidator.IsEdition(Common.StandardOrHigher)) Then
            btnStandard.Enabled = True
        End If

        'lastly if this is a trial activate those features
        If (valResult.State = LicenseState.Trial) Then
            btnStandard.Enabled = True
            btnPro.Enabled = True
        End If

    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        UpdateUI()
    End Sub
End Class