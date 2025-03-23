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
    //[Authorize(Roles = "Admin")]
    public partial class Unos_KartonPredmeta : System.Web.UI.Page
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
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM KartonPredmeta", sqlCon);
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
                        string query = "INSERT INTO KartonPredmeta (tipStudija_id,name,tip,casoviPredavanja,casoviVezbe,casoviDon,casoviPraksa,status) VALUES (@tipStudija_id,@name,@tip,@casoviPredavanja,@casoviVezbe,@casoviDon,@casoviPraksa,@status)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                        // Retrieve the values from the new row's text boxes
                        TextBox txtTipStudija_id = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtTipStudija_idFooter");
                        TextBox txtName = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtNameFooter");
                        TextBox txtTip = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtTipFooter");
                        TextBox txtCasoviPredavanja = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtCasoviPredavanjaFooter");
                        TextBox txtCasoviVezbe = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtCasoviVezbeFooter");
                        TextBox txtCasoviDon = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtCasoviDonFooter");
                        TextBox txtCasoviPraksa = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtCasoviPraksaFooter");

                        CheckBox chkStatus = (CheckBox)EDnevnikVranje.FooterRow.FindControl("txtStatusFooter");



                        sqlCmd.Parameters.AddWithValue("@tipStudija_id", txtTipStudija_id.Text);
                        sqlCmd.Parameters.AddWithValue("@name", txtName.Text);
                        sqlCmd.Parameters.AddWithValue("@tip", txtTip.Text);
                        sqlCmd.Parameters.AddWithValue("@casoviPredavanja", txtCasoviPredavanja.Text);
                        sqlCmd.Parameters.AddWithValue("@casoviVezbe", txtCasoviVezbe.Text);
                        sqlCmd.Parameters.AddWithValue("@casoviDon", txtCasoviDon.Text);
                        sqlCmd.Parameters.AddWithValue("@casoviPraksa", txtCasoviPraksa.Text);
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
                //TextBox txtName = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtName");
                //CheckBox chkStatus = (CheckBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtStatus");
                TextBox txtTipStudija_id = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtTipStudija_id");
                TextBox txtName = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtName");
                TextBox txtTip = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtTip");
                TextBox txtCasoviPredavanja = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtCasoviPredavanja");
                TextBox txtCasoviVezbe = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtCasoviVezbe");
                TextBox txtCasoviDon = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtCasoviDon");
                TextBox txtCasoviPraksa = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtCasoviPraksa");

                CheckBox chkStatus = (CheckBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtStatus");

                // Dohvatite trenutne podatke iz GridView-a
                string currentTipStudija_id = EDnevnikVranje.DataKeys[e.NewEditIndex]["tipStudija_id"].ToString();
                string currentName = EDnevnikVranje.DataKeys[e.NewEditIndex]["name"].ToString();
                string currentTip = EDnevnikVranje.DataKeys[e.NewEditIndex]["tip"].ToString();
                string currentCasoviPredavanja = EDnevnikVranje.DataKeys[e.NewEditIndex]["casoviPredavanja"].ToString();
                string currentCasoviVezbe = EDnevnikVranje.DataKeys[e.NewEditIndex]["casoviVezbe"].ToString();
                string currentCasoviDon = EDnevnikVranje.DataKeys[e.NewEditIndex]["casoviDon"].ToString();
                string currentCasoviPraksa = EDnevnikVranje.DataKeys[e.NewEditIndex]["casoviPraksa"].ToString();
                bool currentStatus = (bool)EDnevnikVranje.DataKeys[e.NewEditIndex]["status"];

                // Postavite trenutne podatke kao placeholder tekst ili vrijednost u TextBox i CheckBox kontrole
                txtTipStudija_id.Text = currentTipStudija_id;
                txtName.Text = currentName;
                txtTip.Text = currentTip;
                txtCasoviPredavanja.Text = currentCasoviPredavanja;
                txtCasoviVezbe.Text = currentCasoviVezbe;
                txtCasoviDon.Text = currentCasoviDon;
                txtCasoviPraksa.Text = currentCasoviPraksa;
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
                    SqlCommand sqlCmd = new SqlCommand("UPDATE KartonPredmeta set tipStudija_id=@tipStudija_id,name=@name,tip=@tip,casoviPredavanja=@casoviPredavanja,casoviVezbe=@casoviVezbe,casoviDon=@casoviDon,casoviPraksa=@casoviPraksa,status=@status where id=@id", sqlCon);

                    //TextBox txtName = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtName");
                    
                    TextBox txtTipStudija_id = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtTipStudija_id");
                    TextBox txtName = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtName");
                    TextBox txtTip = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtTip");
                    TextBox txtCasoviPredavanja = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtCasoviPredavanja");
                    TextBox txtCasoviVezbe = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtCasoviVezbe");
                    TextBox txtCasoviDon = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtCasoviDon");
                    TextBox txtCasoviPraksa = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtCasoviPraksa");

                    CheckBox chkStatus = (CheckBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtStatus");

                 
                    sqlCmd.Parameters.AddWithValue("@tipStudija_id", txtTipStudija_id.Text);
                    sqlCmd.Parameters.AddWithValue("@name", txtName.Text);
                    sqlCmd.Parameters.AddWithValue("@tip", txtTip.Text);
                    sqlCmd.Parameters.AddWithValue("@casoviPredavanja", txtCasoviPredavanja.Text);
                    sqlCmd.Parameters.AddWithValue("@casoviVezbe", txtCasoviVezbe.Text);
                    sqlCmd.Parameters.AddWithValue("@casoviDon", txtCasoviDon.Text);
                    sqlCmd.Parameters.AddWithValue("@casoviPraksa", txtCasoviPraksa.Text);
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
                    string query = "DELETE FROM KartonPredmeta WHERE id = @id";
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