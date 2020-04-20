<%@ Control Language="VB" AutoEventWireup="false" CodeFile="GooglereCAPTCHA.ascx.vb" Inherits="webcontrols_hcfe_googlerecaptcha" %>


<div class="g-recaptcha" data-sitekey="<%=System.Configuration.ConfigurationManager.AppSettings("reCAPTCHA.SiteKey")%>"></div>
	
<script src="https://www.google.com/recaptcha/api.js" async defer></script>
