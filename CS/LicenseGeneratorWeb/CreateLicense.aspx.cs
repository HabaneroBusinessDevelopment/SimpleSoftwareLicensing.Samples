using System;
using System.Net;
using System.Net.Mail;
using Habanero.Licensing.Generator;
using Habanero.Licensing.Shared;

namespace LicenseGeneratorWeb
{
    public partial class CreateLicense : System.Web.UI.Page
    {


        byte[] applicationSecret = Convert.FromBase64String("YOURSECRET");

        private string privateKey = "YOURPRIVATEKEY";

        private string thisLicense = @"YOUR_OWN_LICENSE_STRING_FOR_THE_LICENSE_MANAGER";

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.Form("ctransaction") == "SALE" && ipnValid(Request))
            //{
            //    //clickbank version
            //    string email = Request.Form["ccustemail"];
            //    string fullname = Request.Form["ccustfullname"];
            //    Guid userSerial = Guid.NewGuid();

            //    LicensedUser licensee = null;

            //    //depending on what info you expect to receive you may need to call a differnt create method
            //    licensee = LicensedUser.Create(fullname.Trim(), email.Trim(), null);

            //    //setup your product
            //    //you may need to check Request.Form["cproditem"] for different editions and products

            //    //create license

            //    //send license by email

            //}
            //get user data
            string email = Request.Form["email"];
            string fullname = Request.Form["fullname"];
            string company = Request.Form["company"];
            Guid userSerial = Guid.NewGuid();

            LicensedUser licensee = null;

            //depending on what info you expect to receive you may need to call a differnt create method
            fullname = fullname.Trim();
            email = email.Trim();
            company = company.Trim();
            licensee = LicensedUser.Create(fullname, email, company);


            var product = new LicensedProductInformation();
            product.ProductName = "YOURPRODUCTNAME";
            //set the maxversion to the version you will be issuing licenses for
            //the following line issues licenses for *.*
            product.MaxVersion = new LicensedVersionNumber();
            //Set the edition the license is valid for
            product.LicenseName = "YOUREDITION";
            //set the expiration date or null
            DateTime? expiration = DateTime.Now.AddYears(1);

            //now create the actual license
            var license = LicenseGenerator.CreateLicense(thisLicense, new ByteHolder(privateKey), applicationSecret,
                                                            product, userSerial,
                                                            licensee,
                                                            expiration);

            //pad the license using ===== to make it clear in emails
            string emailBody =
               "You have purchased a license - your license is included in this email:\n" +
               "\n==========\n" + license.ToString() + "\n==========";


            var mailer = new System.Net.Mail.SmtpClient("smtp.yourserver.com")
            {
                UseDefaultCredentials = false,
                Credentials =
                    new NetworkCredential("user", "password"),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Timeout = 50000
            };

            var message = new MailMessage("from@email.com", email, "Your License to PRODUCTNAME",
                                                 emailBody
                       );
            //send a copy to yourself just in case
            message.Bcc.Add("secretcopy@email.com");
            mailer.Send(message);

        }
    }
}