using System;
using System.Windows.Forms;
using Habanero.Licensing.Validation;

namespace WindowsApplication
{
    public partial class LicensePopup : Form
    {
        public LicensePopup()
        {
            InitializeComponent();

            //load current license information
            LicenseValidationResult valResult = Common.FileValidator.CheckLicense();

            UpdateUI(valResult);
        }



        private void btnActivateTrial_Click(object sender, EventArgs e)
        {
            LicenseValidationResult valResult = Common.FileValidator.ActivateTrial(10);
            Close();
        }

        private void UpdateUI(LicenseValidationResult valResult)
        {
            //we can change the ui based on the existing license here
            if (valResult.State == LicenseState.Invalid)
            {
                btnActivateTrial.Enabled = true;
            }
            else
            {
                btnActivateTrial.Enabled = false;
            }

            //load the rawlicense into a textbox
            txtLicense.Text = valResult.RawLicenseData;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //check the new license
            LicenseValidationResult valResult = Common.FileValidator.CheckLicense(txtLicense.Text);
            if (valResult.State == LicenseState.Invalid)
            {
                MessageBox.Show("The license you entered is not valid and will not be saved!", "Invalid License", MessageBoxButtons.OK);
            }
            else
            {
                Common.FileValidator.SaveLicense(txtLicense.Text);
                Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Common.FileValidator.SaveLicense("");
            Close();
        }
       
    }
}
