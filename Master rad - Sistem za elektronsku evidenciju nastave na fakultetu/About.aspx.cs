//using Microsoft.AspNetCore.Authorization;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Data.SqlClient;
//using System.Web.Security;

//namespace MilanKrstic
//{

//    public partial class About : Page
//    {

//        protected void Page_Load(object sender, EventArgs e)
//        {

//            if (!User.Identity.IsAuthenticated)
//            {
//                // Ako korisnik nije prijavljen, preusmerite ga na stranicu za prijavljivanje
//                Response.Redirect("~/Account/Login.aspx");
//            }
//            //else 
//            //{
//            //    // Ako je korisnik prijavljen, proverite da li je administrator
//            //    // Ovo možete uraditi na osnovu vaše logike, na primer, proverom korisničke uloge
//            //    if (!IsAdmin(User.Identity.Name))
//            //    {
//            //        // Ako korisnik nije administrator, prikažite poruku o nedozvoljenom pristupu
//            //        // i preusmerite ga na neku drugu stranicu
//            //        Response.Redirect("~/Unauthorized.aspx");
//            //    }
//            //}
//            else if (!IsAdmin(User.Identity.Name))
//            {
//                // Ako je korisnik prijavljen, proverite da li je administrator
//                // Ovo možete uraditi na osnovu vaše logike, na primer, proverom korisničke uloge

//                {
//                    // Ako korisnik nije administrator, prikažite poruku o nedozvoljenom pristupu
//                    // i preusmerite ga na neku drugu stranicu
//                    Response.Redirect("~/Unauthorized.aspx");
//                }
//            }

//        }

//        private bool IsAdmin(string username)
//        {
//            // Ovde implementirajte logiku provere da li je korisnik administrator
//            // Na primer, možete proveriti u bazi podataka ili u nekom drugom izvoru podataka
//            // Vratite true ako je korisnik administrator, false inače
//            // Ovde je primer provere iz baze podataka:
//            using (var connection = new SqlConnection("Data Source=DESKTOP-5DQ906E\\SQLEXPRESS;Initial Catalog=EDnevnikVranje;Persist Security Info=True;User ID=sa;Password=Pskssp555"))
//            {
//                connection.Open();
//                var query = "SELECT IsAdmin FROM dbo.Korisnik WHERE Username = @Username";
//                using (var command = new SqlCommand(query, connection))
//                {
//                    command.Parameters.AddWithValue("@Username", username);
//                    return (bool)command.ExecuteScalar();
//                }
//            }
//        }


//    }
//}
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;

namespace MilanKrstic
{
    
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //item1.Visible = HttpContext.Current.User.Identity.IsAuthenticated;
            //item2.Visible = HttpContext.Current.User.Identity.IsAuthenticated;
            //item3.Visible = HttpContext.Current.User.Identity.IsAuthenticated;
            //item4.Visible = HttpContext.Current.User.Identity.IsAuthenticated;
            //item5.Visible = HttpContext.Current.User.Identity.IsAuthenticated;
            //item6.Visible = HttpContext.Current.User.Identity.IsAuthenticated;
        }
        
      
    }
}