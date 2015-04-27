Imports Habanero.Licensing.Validation

Public Class LicensePopup

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        Common.FileValidator.SaveLicense("")
        Close()
    End Sub

    Private Sub btnActivateTrial_Click(sender As System.Object, e As System.EventArgs) Handles btnActivateTrial.Click
        Dim valResult As LicenseValidationResult = Common.FileValidator.ActivateTrial(10)
        Close()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        'check the new license
        Dim valResult As LicenseValidationResult = Common.FileValidator.CheckLicense(txtLicense.Text)
        If valResult.State = LicenseState.Invalid Then
            MessageBox.Show("The license you entered is not valid and will not be saved!", "Invalid License", MessageBoxButtons.OK)
        Else
            Common.FileValidator.SaveLicense(txtLicense.Text)
            Close()
        End If
    End Sub

    Private Sub LicensePopup_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'load current license information
        Dim valResult As LicenseValidationResult = Common.FileValidator.CheckLicense()

        UpdateUI(valResult)
    End Sub

    Private Sub UpdateUI(valResult As LicenseValidationResult)
        'we can change the ui based on the existing license here
        If valResult.State = LicenseState.Invalid Then
            btnActivateTrial.Enabled = True
        Else
            btnActivateTrial.Enabled = False
        End If

        'load the rawlicense into a textbox
        txtLicense.Text = valResult.RawLicenseData
    End Sub
End Class