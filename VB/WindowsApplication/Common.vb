Imports System.IO
Imports Habanero.Licensing.Validation
Imports System.Reflection

Friend NotInheritable Class Common
    Shared LicenseFolder As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SampleApplication")
    Shared LicenseFile As String = "SampleLicenseFile.lic"
    Shared LicenseFileLocation As String = Path.Combine(LicenseFolder, LicenseFile)

    Public Shared ReadOnly Property LicenseFileLocationProperty As String
        Get
            Return LicenseFileLocation
        End Get
    End Property


    'create code for applicationsecret - taken from the License Manager application
    Shared applicationSecret() As Byte = Convert.FromBase64String("JdZlrqJqbEemYDIaUXTKVQ==")
    'create code for public key - taken from the License Manager application
    Shared publicKey() As Byte = Convert.FromBase64String("BgIAAACkAABSU0ExAAIAAAEAAQCJVIQQWZoDItPbDQMMsz+Q3Sz2Z+iBFZuKNPQG1cTSToOoSQpZ35VAx9bPSvRURvOrktPbMZeGW0TwpuoLFT6q")

    Shared productName As String = "Demo product 2012"

    Friend Shared ReadOnly Property FileValidator As LicenseValidator
        Get
            'make sure that the license folder exists
            Dim licensePath As String = Path.GetDirectoryName(LicenseFileLocation)
            If Not Directory.Exists(licensePath) Then
                Directory.CreateDirectory(licensePath)
            End If
            'now return the FileValidator
            Return New LicenseValidator(LicenseLocation.File, LicenseFileLocation, productName, publicKey, applicationSecret, ThisVersion)

        End Get
    End Property

    Friend Shared ReadOnly Property IsolatedStorageValidator As LicenseValidator
        Get
            'now return the Validator
            Return New LicenseValidator(LicenseLocation.UserIsolatedStorage, LicenseFile, productName, publicKey, applicationSecret, ThisVersion)

        End Get
    End Property

    Friend Shared ReadOnly Property ThisVersion As Version
        Get
            'Get the executing files filesversion
            Dim fileversion As FileVersionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location)
            Dim myVersion As Version = New Version(fileversion.FileMajorPart, fileversion.FileMinorPart, fileversion.FileBuildPart, fileversion.FilePrivatePart)

            Return myVersion
        End Get
    End Property
    Friend Shared StandardOrHigher() As String = New String() {"Standard", "Pro", "Enterprise"}
    Friend Shared ProOrHigher() As String = New String() {"Pro", "Enterprise"}
    Friend Shared EnterpriseOrHigher() As String = New String() {"Enterprise"}
End Class
