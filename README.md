# Google reCAPTCHA Control for PSWebEnrolment

This control allows you to easily add reCAPTCHA verification to your PSWebEnrolment pages.

# Licence/Disclaimer
The code is licenced under 'The Unlicence'. Feel free to do whatever you want with it. The code is provided 'as is' with no warranty.

Note: This code is custom and is not related in any way to Advanced Computer Software. Please do not contact them for support relating to this control.

# I'd like to report a bug, how can I do this?
Please log your bug using the 'Issues' tab in GitHub.

# How do I use this?

1. Create your Google reCAPTCHA Site & Secret API Keys by visiting: https://www.google.com/recaptcha/admin. This control will not function correctly without valid reCAPTCHA API keys.

2. Download the latest release from the 'Releases' tab on GitHub and extract the two GooglereCAPTCHA.ascx & GooglereCAPTCHA.ascx.vb files from the 'ControlFiles' folder in the ZIP to your 'webcontrols' folder where PSWebEnrolment is deployed on your webserver.

3. **In your web.config file**, you will need to add the following two keys under the `<appsettings>` tag. Copy in the relevant API key:

```xml
<appsettings>
...
<!-- HCFE Google reCAPTCHA Control Settings -->
<add key="reCAPTCHA.SiteKey" value="Copy your site key here" />
<add key="reCAPTCHA.SecretKey" value="Copy your secret key here" />
<!-- End HCFE Google reCAPTCHA Control Settings -->
</appsetttings>
```  

4. Register the control to the pages that require it. Do this by adding the following code to the top of your .ascx page where you want the captcha to appear:
```html
<%@ Register Src="~/webcontrols/GooglereCAPTCHA.ascx" TagPrefix="uc2" TagName="GooglereCAPTCHA" %>
```

5. Add the captcha control to the page in your required location (for example, before your 'Continue' button(s) etc.)
```html
<uc2:GooglereCAPTCHA runat="server" ID="Captcha" />
```

6. **How do I add validation to ensure my users have actually completed the captcha?** <br />
Most pages in PSWebEnrolment have a Overrides Subroutine named **ValidateControl()** in the .ascx.vb file of the page you have added the control to. The control has a 'CaptureValidate' function that you can call to ensure the captcha response is valid.<br />Here's an example you can add to the ValidateControl() subroutine:
```vb.net
' Validate captcha
If Not Captcha.CaptchaValidate() Then
	Dim v As New CustomValidator() With {
		.ErrorMessage = "You must successfully complete the CAPTCHA verification.",
		.IsValid = False
	}
	Me.Page.Validators.Add(v)
End If
```
