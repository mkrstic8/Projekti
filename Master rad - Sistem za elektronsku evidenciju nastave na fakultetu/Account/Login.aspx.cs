//using System;
//using System.Web;
//using System.Web.UI;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
//using Owin;
//using MilanKrstic.Models;
//using System.Linq;
//using System.Security.Principal;
//using System.Web.UI.WebControls;

//namespace MilanKrstic.Account
//{
//    public partial class Login : Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            RegisterHyperLink.NavigateUrl = "Register";
//            // Enable this once you have account confirmation enabled for password reset functionality
//            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
//            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
//            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
//            if (!String.IsNullOrEmpty(returnUrl))
//            {
//                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
//            }
//        }

//        protected void LogIn(object sender, EventArgs e)
//        {
//            if (IsValid)
//            {
//                // Validate the user password
//                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
//                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

//                // This doen't count login failures towards account lockout
//                // To enable password failures to trigger lockout, change to shouldLockout: true
//                var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

//                switch (result)
//                {
//                    case SignInStatus.Success:
//                        IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
//                        break;
//                    case SignInStatus.LockedOut:
//                        Response.Redirect("/Account/Lockout");
//                        break;
//                    case SignInStatus.RequiresVerification:
//                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
//                                                        Request.QueryString["ReturnUrl"],
//                                                        RememberMe.Checked),
//                                          true);
//                        break;
//                    case SignInStatus.Failure:
//                    default:
//                        FailureText.Text = "Invalid login attempt";
//                        ErrorMessage.Visible = true;
//                        break;
//                }
//            }
//        }

//    }
//}

using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using MilanKrstic.Models;
using System.Linq;
using System.Security.Principal;
using System.Web.UI.WebControls;

namespace MilanKrstic.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            //OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Provera korisničkih podataka
                var email = Email.Text;
                var password = Password.Text;

                // Povezivanje na bazu podataka
                using (var connection = new SqlConnection("Data Source=DESKTOP-5DQ906E\\SQLEXPRESS;Initial Catalog=EDnevnikVranje;Persist Security Info=True;User ID=sa;Password=Pskssp555"))
                {
                    connection.Open();

                    // SQL upit za proveru korisnika
                    var query = "SELECT IsAdmin FROM dbo.Korisnik WHERE Username = @Username AND Password = @Password";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", email);
                        command.Parameters.AddWithValue("@Password", password);

                        // Izvršavanje upita
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                bool isAdmin = reader.GetBoolean(reader.GetOrdinal("IsAdmin"));

                                if (isAdmin)
                                {
                                    // Ako je korisnik administrator, uloguj ga


                                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                                   // Response.Redirect("~/About.aspx");
                                }
                                else
                                {
                                    // Ako korisnik nije administrator, prikaži poruku o neuspeloj prijavi
                                    FailureText.Text = "Nemate privilegije za pristup.";
                                    ErrorMessage.Visible = true;
                                }
                            }
                            else
                            {
                                // Ako korisnik ne postoji, prikaži poruku o neuspeloj prijavi
                                FailureText.Text = "Pogrešno korisničko ime ili lozinka.";
                                ErrorMessage.Visible = true;
                            }
                        }
                    }
                }
            }
        }
    }
}