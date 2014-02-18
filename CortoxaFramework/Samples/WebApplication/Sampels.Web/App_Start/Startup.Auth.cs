using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace Sampels.Web
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers
//            app.UseMicrosoftAccountAuthentication(
//                clientId: "0000000040115884",
//                clientSecret: "qyfMuVREovaRjjdNtLqY9On83LnF4kW2");

//            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings.Get("MicrosoftClientId")))
//            {
//                var msaccountOptions = new Microsoft.Owin.Security.MicrosoftAccount.MicrosoftAccountAuthenticationOptions()
//                {
//                    ClientId = "0000000040115884",//ConfigurationManager.AppSettings.Get("MicrosoftClientId"),
//                    ClientSecret = "qyfMuVREovaRjjdNtLqY9On83LnF4kW2",//ConfigurationManager.AppSettings.Get("MicrosoftClientSecret"),
//                    Provider = new Microsoft.Owin.Security.MicrosoftAccount.MicrosoftAccountAuthenticationProvider()
//                    {
//                        OnAuthenticated = (context) =>
//                        {
//                            context.Identity.AddClaim(new System.Security.Claims.Claim("urn:microsoftaccount:access_token", context.AccessToken, , "Microsoft"));
//
//                            return Task.FromResult(0);
//                        }
//                    }
//                };
//
//                app.UseMicrosoftAccountAuthentication(msaccountOptions);
//            }


            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            app.UseGoogleAuthentication();
        }
    }
}