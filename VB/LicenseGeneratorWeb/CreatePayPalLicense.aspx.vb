Imports Habanero.Licensing.Generator
Imports Habanero.Licensing.Shared
Imports System.Net.Mail
Imports System.Net
Imports System.IO

Public Class CreatePayPalLicense
    Inherits System.Web.UI.Page

    'Set this to true when you deploy to production
    Dim payPalLive As Boolean = False

    Dim applicationSecret As Byte() = Convert.FromBase64String("YOUR_APPLICATIONS_APPLICATIONSECRET")

    Dim privateKey As String = "YOUR_APPLICATIONS_PRIVATEKEY"

    Dim thisLicense As String = <span>
THE_LICENSE_FOR_THE_LICENSEMANAGER
THAT_WAS_SENT_TO_YOU
</span>.Value
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim mailer As New System.Net.Mail.SmtpClient("your.smtp.server")
        mailer.UseDefaultCredentials = False
        mailer.Credentials =
            New NetworkCredential("smtpUsername", "smtpPassword")
        mailer.DeliveryMethod = SmtpDeliveryMethod.Network
        mailer.Timeout = 50000

        Try

            Dim strSandbox As String = "https://www.sandbox.paypal.com/cgi-bin/webscr"
            Dim strLive As String = "https://www.paypal.com/cgi-bin/webscr"

            Dim req As HttpWebRequest = CType(WebRequest.Create(IIf(payPalLive, strLive, strSandbox)), HttpWebRequest)

            'Set values for the request back
            req.Method = "POST"
            req.ContentType = "application/x-www-form-urlencoded"
            Dim Param() As Byte = Request.BinaryRead(HttpContext.Current.Request.ContentLength)
            Dim strRequest As String = Encoding.ASCII.GetString(Param)
            strRequest = strRequest + "&cmd=_notify-validate"
            req.ContentLength = strRequest.Length


            Dim email As String = Request.Form("payer_email")
            Dim fullname As String = Request.Form("first_name") + Request.Form("last_name")
            Dim company As String = Request.Form("payer_business_name")
            Dim userSerial As Guid = Guid.NewGuid()

            Dim licensee As LicensedUser = Nothing

            'depending on what info you expect to receive you may need to call a different create method
            fullname = fullname.Trim()
            email = email.Trim()
            company = ""
            licensee = LicensedUser.Create(fullname, email, company)


            Dim product As New LicensedProductInformation()
            product.ProductName = "YOUR_PRODUCT_NAME"
            'set the maxversion to the version you will be issuing licenses for
            'the following line issues licenses for *.*
            product.MaxVersion = New LicensedVersionNumber()
            'Set the edition the license is valid for
            product.LicenseName = "YOUREDITION"
            'set the expiration date or null
            Dim expiration As DateTime? = DateTime.Now.AddYears(1)

            'If paypal says the purchase is ok then create license and contact the user

            Dim streamOut As StreamWriter = New StreamWriter(req.GetRequestStream(), Encoding.ASCII)
            streamOut.Write(strRequest)
            streamOut.Close()
            Dim streamIn As StreamReader = New StreamReader(req.GetResponse().GetResponseStream())
            Dim strResponse As String = streamIn.ReadToEnd()
            streamIn.Close()


            If strResponse = "VERIFIED" Then

                'now create the actual license
                Dim license = LicenseGenerator.CreateLicense(thisLicense, New ByteHolder(privateKey), applicationSecret,
                                                                product, userSerial,
                                                                licensee,
                                                                expiration)

                'pad the license using ===== to make it clear in emails
                Dim emailBody As String =
                   "You have purchased a license - your license is included in this email:" + vbCrLf + vbCrLf +
                   "==========" + vbCrLf + license.ToString() + vbCrLf + "=========="




                Dim message As New MailMessage("EMAIL_FROM_ADRESS", email, "Your License to PRODUCTNAME",
                                                     emailBody
                           )
                'send a copy to yourself just in case
                message.Bcc.Add("YOUR_OWN_EMAIL")
                mailer.Send(message)
            ElseIf strResponse = "INVALID" Then
                'log for manual investigation
                mailer.Send("EMAIL_FROM_ADRESS", "YOUR_OWN_EMAIL", "Paypal IPN failure", "PayPal responded with INVALID for payment confirmation response. This indicates possible fraud or technical errors." + vbCrLf + vbCrLf + "The full request from PayPal was:" + vbCrLf + strRequest)
            Else
                'Response wasn't VERIFIED or INVALID, log for manual investigation
                mailer.Send("EMAIL_FROM_ADRESS", "YOUR_OWN_EMAIL", "Paypal IPN failure", "PayPal responded with an unhandled payment confirmation response. This indicates potential technical errors." + vbCrLf + vbCrLf + "The full request from PayPal was:" + vbCrLf + strRequest + vbCrLf + vbCrLf + "The full reponse from PayPal was:" + vbCrLf + strResponse)

            End If
        Catch ex As Exception
            mailer.Send("EMAIL_FROM_ADRESS", "YOUR_OWN_EMAIL", "IPN failure", ex.Message + ex.StackTrace)

        End Try

    End Sub

End Class