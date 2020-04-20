Imports System.Net
Imports System.Web.Script.Serialization
Imports System.IO
Imports CompassCC.CCCSystem.CCCCommon

' Google reCAPTCHA web control for PSWebEnrolment
' Jack Galloway - Hartlepool College of Further Education - https://www.hartlepoolfe.ac.uk
' Read Me, Licence & future updates available on github! 
' https://github.com/jackgalloway/Google-reCAPTCHA-Control-for-PSWebEnrolment

Partial Class webcontrols_hcfe_googlerecaptcha
    Inherits System.Web.UI.UserControl

    Public Function CaptchaValidate() As Boolean
        Dim strResponse As String = Request("g-recaptcha-response")
        Dim strWebRequestURL As String = "https://www.google.com/recaptcha/api/siteverify?secret=" & ConfigurationManager.AppSettings("reCAPTCHA.SecretKey") & "&response="
        Dim WebReq As HttpWebRequest = DirectCast(WebRequest.Create(Convert.ToString(strWebRequestURL) & strResponse), HttpWebRequest)

        Try
            Using wResponse As WebResponse = WebReq.GetResponse()
                Using readStream As New StreamReader(wResponse.GetResponseStream())
                    Dim jsonResponse As String = readStream.ReadToEnd()
                    Dim js As New JavaScriptSerializer()
                    Dim data As CaptchaRespone = js.Deserialize(Of CaptchaRespone)(jsonResponse)

                    Dim bValid As Boolean = Convert.ToBoolean(data.success)
                    Return bValid
                End Using
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class

Public Class CaptchaRespone
    Private m_success As String
    Public Property success() As String
        Get
            Return m_success
        End Get
        Set(value As String)
            m_success = value
        End Set
    End Property

End Class
