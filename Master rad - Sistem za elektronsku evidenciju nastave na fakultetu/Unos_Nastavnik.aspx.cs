using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace MilanKrstic
{
    public partial class Unos_Nastavnik : System.Web.UI.Page
    {
        //string connectionString = "Data Source=DESKTOP-5DQ906E\\SQLEXPRESS;Initial Catalog=EDnevnikVranje;User ID=sa; Password=Pskssp555;";
        string connectionString = ConfigurationManager.ConnectionStrings["EDnevnikVranje"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridview();
            }

        }

        void PopulateGridview()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Nastavnik", sqlCon);
                sqlDa.Fill(dtbl);
            }

            if (dtbl.Rows.Count > 0)
            {
                //EDnevnikVranje.DataSourceID = null;
                EDnevnikVranje.DataSource = dtbl;
                EDnevnikVranje.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                //EDnevnikVranje.DataSourceID = null;
                EDnevnikVranje.DataSource = dtbl;
                EDnevnikVranje.DataBind();
                
                EDnevnikVranje.Rows[0].Cells.Clear();
                EDnevnikVranje.Rows[0].Cells.Add(new TableCell());
                EDnevnikVranje.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                EDnevnikVranje.Rows[0].Cells[0].Text = "No Data Found ..!";
                EDnevnikVranje.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }




        }

        protected void EDnevnikVranje_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO Nastavnik (ime,srednjeSlovo,prezime,katedra,zvanje,tipAngazovanja,status) VALUES (@ime,@srednjeSlovo,@prezime,@katedra,@zvanje,@tipAngazovanja,@status)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                        // Retrieve the values from the new row's text boxes
                        TextBox txtIme = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtImeFooter");
                        TextBox txtSrednjeSlovo = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtSrednjeSlovoFooter");
                        TextBox txtPrezime = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtPrezimeFooter");

                        TextBox txtKatedra = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtKatedraFooter");
                        TextBox txtZvanje = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtZvanjeFooter");
                        TextBox txtTipAngazovanja = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtTipAngazovanjaFooter");
                        CheckBox chkStatus = (CheckBox)EDnevnikVranje.FooterRow.FindControl("txtStatusFooter");
                        //TextBox txtId = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtId");
                        //txtId.Enabled = false;


                        sqlCmd.Parameters.AddWithValue("@ime", txtIme.Text);
                        sqlCmd.Parameters.AddWithValue("@srednjeSlovo", txtSrednjeSlovo.Text);
                        sqlCmd.Parameters.AddWithValue("@prezime", txtPrezime.Text);
                        sqlCmd.Parameters.AddWithValue("@katedra", txtKatedra.Text);
                        sqlCmd.Parameters.AddWithValue("@zvanje", txtZvanje.Text);
                        sqlCmd.Parameters.AddWithValue("@tipAngazovanja", txtTipAngazovanja.Text);
                        sqlCmd.Parameters.AddWithValue("@status", chkStatus.Checked);
                        EDnevnikVranje.EditIndex = -1;
                        sqlCmd.ExecuteNonQuery();
                        PopulateGridview();
                        lblSuccessMessage.Text = "New Record Added";
                        lblErrorMessage.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
        protected void EDnevnikVranje_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                EDnevnikVranje.EditIndex = e.NewEditIndex;
            PopulateGridview();
            //TextBox txtAkademskaGodina = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtAkademskaGodina");
            //TextBox txtGodina = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtGodina");
            //TextBox txtSemestar = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtSemestar");
           

            TextBox txtIme = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtIme");
            TextBox txtSrednjeSlovo = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtSrednjeSlovo");
            TextBox txtPrezime = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtPrezime");
            TextBox txtKatedra = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtKatedra");
            TextBox txtZvanje = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtZvanje");
            TextBox txtTipAngazovanja = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtTipAngazovanja");
            CheckBox chkStatus = (CheckBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtStatus");


            // Dohvatite trenutne podatke iz GridView-a
            string currentIme = EDnevnikVranje.DataKeys[e.NewEditIndex]["ime"].ToString();
            string currentSrednjeSlovo = EDnevnikVranje.DataKeys[e.NewEditIndex]["srednjeSlovo"].ToString();
            string currentPrezime= EDnevnikVranje.DataKeys[e.NewEditIndex]["prezime"].ToString();
            string currentKatedra = EDnevnikVranje.DataKeys[e.NewEditIndex]["katedra"].ToString();
            string currentZvanje = EDnevnikVranje.DataKeys[e.NewEditIndex]["zvanje"].ToString();
            string currenTipAngazovanja = EDnevnikVranje.DataKeys[e.NewEditIndex]["tipAngazovanja"].ToString();
            bool currentStatus = (bool)EDnevnikVranje.DataKeys[e.NewEditIndex]["status"];

            // Postavite trenutne podatke kao placeholder tekst ili vrijednost u TextBox i CheckBox kontrole
            txtIme.Text = currentIme;
            txtSrednjeSlovo.Text = currentSrednjeSlovo;
            txtPrezime.Text = currentPrezime;

            txtKatedra.Text = currentKatedra;
            txtZvanje.Text = currentZvanje;
            txtTipAngazovanja.Text = currenTipAngazovanja;




            chkStatus.Checked = currentStatus;
            }

            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void EDnevnikVranje_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            EDnevnikVranje.EditIndex = -1;
            PopulateGridview();
        }


        protected void EDnevnikVranje_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("UPDATE Nastavnik set ime=@ime,srednjeSlovo=@srednjeSlovo,prezime=@prezime,katedra=@katedra,zvanje=@zvanje,tipAngazovanja=@tipAngazovanja,status=@status where id=@id", sqlCon);

                    //TextBox txtAkademskaGodina = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtAkademskaGodina");
                    //TextBox txtGodina = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtGodina");
                    //TextBox txtSemestar = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtSemestar");
                    //CheckBox chkStatus = (CheckBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtStatus");

                    TextBox txtIme = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtIme");
                    TextBox txtSrednjeSlovo = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtSrednjeSlovo");
                    TextBox txtPrezime = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtPrezime");
                    TextBox txtKatedra = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtKatedra");
                    TextBox txtZvanje = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtZvanje");
                    TextBox txtTipAngazovanja = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtTipAngazovanja");
                    CheckBox chkStatus = (CheckBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtStatus");



                    sqlCmd.Parameters.AddWithValue("@ime", txtIme.Text);
                    sqlCmd.Parameters.AddWithValue("@srednjeSlovo", txtSrednjeSlovo.Text);
                    sqlCmd.Parameters.AddWithValue("@prezime", txtPrezime.Text);
                    sqlCmd.Parameters.AddWithValue("@katedra", txtKatedra.Text);
                    sqlCmd.Parameters.AddWithValue("@zvanje", txtZvanje.Text);
                    sqlCmd.Parameters.AddWithValue("@tipAngazovanja", txtTipAngazovanja.Text);
                    sqlCmd.Parameters.AddWithValue("@status", chkStatus.Checked);







                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(EDnevnikVranje.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    EDnevnikVranje.EditIndex = -1;
                    PopulateGridview();
                    lblSuccessMessage.Text = "Selected Record Updated";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void EDnevnikVranje_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM Nastavnik WHERE id = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(EDnevnikVranje.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridview();
                    lblSuccessMessage.Text = "Selected Record Deleted";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
        protected void EDnevnikVranje_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EDnevnikVranje.PageIndex = e.NewPageIndex;
            PopulateGridview();
        }
    }
}