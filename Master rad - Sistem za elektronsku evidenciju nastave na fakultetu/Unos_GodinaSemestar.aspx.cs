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

   // [Authorize(Roles = "Admin")]
    public partial class Unos_GodinaSemestar : System.Web.UI.Page
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
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM GodinaSemestar", sqlCon);
                sqlDa.Fill(dtbl);
            }

            if (dtbl.Rows.Count > 0)
            {
               // EDnevnikVranje.DataSourceID = null;
                EDnevnikVranje.DataSource = dtbl;
                EDnevnikVranje.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
               // EDnevnikVranje.DataSourceID = null;
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
                        string query = "INSERT INTO GodinaSemestar (akademskaGodina, godina, semestar, status) VALUES (@akademskaGodina, @godina, @semestar, @status)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                        // Retrieve the values from the new row's text boxes
                        TextBox txtAkademskaGodina = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtAkademskaGodinaFooter");
                        TextBox txtGodina = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtGodinaFooter");
                        TextBox txtSemestar = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtSemestarFooter");
                        CheckBox chkStatus = (CheckBox)EDnevnikVranje.FooterRow.FindControl("txtStatusFooter");
                        //TextBox txtId = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtId");
                        //txtId.Enabled = false;


                        sqlCmd.Parameters.AddWithValue("@akademskaGodina", txtAkademskaGodina.Text);
                        sqlCmd.Parameters.AddWithValue("@godina", txtGodina.Text);
                        sqlCmd.Parameters.AddWithValue("@semestar", txtSemestar.Text);
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
                TextBox txtAkademskaGodina = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtAkademskaGodina");
                TextBox txtGodina = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtGodina");
                TextBox txtSemestar = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtSemestar");
                CheckBox chkStatus = (CheckBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtStatus");

                // Dohvatite trenutne podatke iz GridView-a
                string currentAkademskaGodina = EDnevnikVranje.DataKeys[e.NewEditIndex]["akademskaGodina"].ToString();
                string currentGodina = EDnevnikVranje.DataKeys[e.NewEditIndex]["godina"].ToString();
                string currentSemestar = EDnevnikVranje.DataKeys[e.NewEditIndex]["semestar"].ToString();
                bool currentStatus = (bool)EDnevnikVranje.DataKeys[e.NewEditIndex]["status"];

                // Postavite trenutne podatke kao placeholder tekst ili vrijednost u TextBox i CheckBox kontrole
                txtAkademskaGodina.Text = currentAkademskaGodina;
                txtGodina.Text = currentGodina;
                txtSemestar.Text = currentSemestar;
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
                    SqlCommand sqlCmd = new SqlCommand("UPDATE GodinaSemestar SET akademskaGodina=@akademskaGodina, godina=@godina, semestar=@semestar, status=@status WHERE id=@id", sqlCon);

                    TextBox txtAkademskaGodina = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtAkademskaGodina");
                    TextBox txtGodina = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtGodina");
                    TextBox txtSemestar = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtSemestar");
                    CheckBox chkStatus = (CheckBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtStatus");

                    sqlCmd.Parameters.AddWithValue("@akademskaGodina", txtAkademskaGodina.Text);
                    sqlCmd.Parameters.AddWithValue("@godina", txtGodina.Text);
                    sqlCmd.Parameters.AddWithValue("@semestar", txtSemestar.Text);
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
                    string query = "DELETE FROM GodinaSemestar WHERE id = @id";
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