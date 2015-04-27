using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Habanero.Licensing;
using Habanero.Licensing.Validation;

namespace SampleApp
{
    public partial class Form1 : Form
    {

      

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LicensePopup popup = new LicensePopup();
            popup.ShowDialog();

            //now we can check the new license
            UpdateUI();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            //load existing license
            
            UpdateUI();
        }

        private void UpdateUI()
        {
            LicenseValidator localValidator = Common.FileValidator;
            LicenseValidationResult valResult = localValidator.CheckLicense();
            string licenseStateString;
            switch (valResult.State)
            {
                case LicenseState.Valid:
                    licenseStateString = "Valid";
                    break;
                case LicenseState.Trial:
                    licenseStateString = "Trial";
                    break;
                default:
                    licenseStateString = "Invalid";
                    break;
            }
            label1.Text = "Your license is: " + licenseStateString;

            #region check what edition we are running
            //default to false
            btnPro.Enabled = false;
            btnStandard.Enabled = false;
            btnEnterprise.Enabled = false;
            if (localValidator.IsEdition(Common.EnterpriseOrHigher))
            {
                btnEnterprise.Enabled = true;
            }

            if (localValidator.IsEdition(Common.ProOrHigher))
            {
                btnPro.Enabled = true;
            }

            if (localValidator.IsEdition(Common.StandardOrHigher))
            {
                btnStandard.Enabled = true;
            }

            if(valResult.State == LicenseState.Trial)
            {
                btnStandard.Enabled = true;
                btnPro.Enabled = true;
            }
            #endregion
        }

        private void btnStandard_Click(object sender, EventArgs e)
        {
            LicenseValidationResult valResult = Common.FileValidator.CheckLicense();
            if (valResult.State == LicenseState.Trial)
            {
                MessageBox.Show("Trial of standard feature!");
            }
            else
            {
                if (!Common.FileValidator.IsEdition(Common.StandardOrHigher))
                {
                    MessageBox.Show("You do not have a standard edition.");
                    return;
                }
                MessageBox.Show("Standard feature!");
            }
        }

        private void btnPro_Click(object sender, EventArgs e)
        {
             LicenseValidationResult valResult = Common.FileValidator.CheckLicense();
             if (valResult.State == LicenseState.Trial)
             {
                 MessageBox.Show("Trial of pro feature!");
             }
             else
             {
                 if (!Common.FileValidator.IsEdition(Common.ProOrHigher))
                 {
                     MessageBox.Show("You do not have a pro edition.");
                     return;
                 }
                 MessageBox.Show("Pro feature!");
             }
        }

        private void btnEnterprise_Click(object sender, EventArgs e)
        {
            if (!Common.FileValidator.IsEdition(Common.EnterpriseOrHigher))
            {
                MessageBox.Show("You do not have an enterprise edition.");
                return;
            }
            MessageBox.Show("Enterprise feature");
        }
    }
}
