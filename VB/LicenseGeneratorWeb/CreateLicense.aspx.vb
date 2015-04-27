Imports Habanero.Licensing.Generator
Imports Habanero.Licensing.Shared
Imports System.Net
Imports System.Net.Mail

Public Class CreateLicense
    Inherits System.Web.UI.Page

    Dim applicationSecret As Byte() = Convert.FromBase64String("YOURSECRET")

    Dim privateKey As String = "YOURPRIVATEKEY"

    Dim thisLicense As String = <span>
YOUR_OWN_LICENSE_STRING_FOR
_THE_LICENSE_MANAGER
</span>.Value

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim email As String = Request.Form("email")
        Dim fullname As String = Request.Form("fullname")
        Dim company As String = Request.Form("company")
        Dim userSerial As Guid = Guid.NewGuid()

        Dim licensee As LicensedUser = Nothing

        'depending on what info you expect to receive you may need to call a different create method
        fullname = fullname.Trim()
        email = email.Trim()
        company = company.Trim()
        licensee = LicensedUser.Create(fullname, email, company)


        Dim product As New LicensedProductInformation()
        product.ProductName = "YOURPRODUCTNAME"
        'set the maxversion to the version you will be issuing licenses for
        'the following line issues licenses for *.*
        product.MaxVersion = New LicensedVersionNumber()
        'Set the edition the license is valid for
        product.LicenseName = "YOUREDITION"
        'set the expiration date or null
        Dim expiration As DateTime? = DateTime.Now.AddYears(1)

        'now create the actual license
        Dim license = LicenseGenerator.CreateLicense(thisLicense, New ByteHolder(privateKey), applicationSecret,
                                                        product, userSerial,
                                                        licensee,
                                                        expiration)

        'pad the license using ===== to make it clear in emails
        Dim emailBody As String =
           "You have purchased a license - your license is included in this email:" + vbCrLf + vbCrLf +
           "==========" + vbCrLf + license.ToString() + vbCrLf + "=========="


        Dim mailer As New System.Net.Mail.SmtpClient("smtp.yourserver.com")
        mailer.UseDefaultCredentials = False
        mailer.Credentials =
            New NetworkCredential("user", "password")
        mailer.DeliveryMethod = SmtpDeliveryMethod.Network
        mailer.Timeout = 50000


        Dim message As New MailMessage("from@email.com", email, "Your License to PRODUCTNAME",
                                             emailBody
                   )
        'send a copy to yourself just in case
        message.Bcc.Add("secretcopy@email.com")
        mailer.Send(message)
    End Sub

End Class