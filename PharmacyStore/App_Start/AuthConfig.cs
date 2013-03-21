using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using PharmacyStore.Models;

namespace PharmacyStore
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "KlFuFVPwjiBwH6Jp8qRBg",
                consumerSecret: "SDTmIZJvg4QKaw2GgHCu1aAULoMFDUEiyPKLSCXN1Q");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "531363453574247",
                appSecret: "4901d97673c234e01e30a9ca23852fc9");

            OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
