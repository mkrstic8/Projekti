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
    public partial class Unos_OdrzaniCasovi_NastavniPlan : System.Web.UI.Page
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
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM OdrzaniCasovi_NastavniPlan", sqlCon);
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
                        string query = "INSERT INTO OdrzaniCasovi_NastavniPlan (nastavniPlan_id,datum,nastavnaJedinica,metodeRada,casoviPredavanja,casoviVezbe,casoviDON,casoviPraksa,napomena) VALUES (@nastavniPlan_id,@datum,@nastavnaJedinica,@metodeRada,@casoviPredavanja,@casoviVezbe,@casoviDON,@casoviPraksa,@napomena)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                        // Retrieve the values from the new row's text boxes
                        TextBox txtNastavniPlan_id = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtNastavniPlan_idFooter");
                        TextBox txtDatum = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtDatumFooter");
                        TextBox txtNastavnaJedinica = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtNastavnaJedinicaFooter");
                        TextBox txtMetodeRada = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtMetodeRadaFooter");
                        TextBox txtCasoviPredavanja = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtCasoviPredavanjaFooter");
                        TextBox txtCasoviVezbe = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtCasoviVezbeFooter");
                        TextBox txtCasoviDON = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtCasoviDONFooter");
                        TextBox txtCasoviPraksa = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtCasoviPraksaFooter");
                        TextBox txtNapomena = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtNapomenaFooter");
                        string a = Convert.ToDateTime(txtDatum.Text).ToString("yyy/MM/dd");


                        sqlCmd.Parameters.AddWithValue("@nastavniPlan_id", txtNastavniPlan_id.Text);
                        sqlCmd.Parameters.AddWithValue("@datum", a);
                        sqlCmd.Parameters.AddWithValue("@nastavnaJedinica", txtNastavnaJedinica.Text);
                        sqlCmd.Parameters.AddWithValue("@metodeRada", txtMetodeRada.Text);
                        sqlCmd.Parameters.AddWithValue("@casoviPredavanja", txtCasoviPredavanja.Text);
                        sqlCmd.Parameters.AddWithValue("@casoviVezbe", txtCasoviVezbe.Text);
                        sqlCmd.Parameters.AddWithValue("@casoviDON", txtCasoviDON.Text);
                        sqlCmd.Parameters.AddWithValue("@casoviPraksa", txtCasoviPraksa.Text);
                        sqlCmd.Parameters.AddWithValue("@napomena", txtNapomena.Text);

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
                // TextBox txtName = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtName");

               
                //TextBox id = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("id");
                //id.Visible = false;

                TextBox txtNastavniPlan_id = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtNastavniPlan_id");
                TextBox txtDatum = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtDatum");
                TextBox txtNastavnaJedinica = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtNastavnaJedinica");
                TextBox txtMetodeRada = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtMetodeRada");
                TextBox txtCasoviPredavanja = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtCasoviPredavanja");
                TextBox txtCasoviVezbe = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtCasoviVezbe");
                TextBox txtCasoviDON = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtCasoviDON");
                TextBox txtCasoviPraksa = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtCasoviPraksa");
                TextBox txtNapomena = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtNapomena");


                // Dohvatite trenutne podatke iz GridView-a
                string currentNastavniPlan_id = EDnevnikVranje.DataKeys[e.NewEditIndex]["nastavniPlan_id"].ToString();
                string currentDatum = EDnevnikVranje.DataKeys[e.NewEditIndex]["datum"].ToString();
                string currentNastavnaJedinica = EDnevnikVranje.DataKeys[e.NewEditIndex]["nastavnaJedinica"].ToString();
                string currentMetodeRada = EDnevnikVranje.DataKeys[e.NewEditIndex]["metodeRada"].ToString();
                string currentCasoviPredavanja = EDnevnikVranje.DataKeys[e.NewEditIndex]["casoviPredavanja"].ToString();
                string currentCasoviVezbe = EDnevnikVranje.DataKeys[e.NewEditIndex]["casoviVezbe"].ToString();
                string currentCasoviDON = EDnevnikVranje.DataKeys[e.NewEditIndex]["casoviDON"].ToString();
                string currentCasoviPraksa = EDnevnikVranje.DataKeys[e.NewEditIndex]["casoviPraksa"].ToString();
                string currentNapomena = EDnevnikVranje.DataKeys[e.NewEditIndex]["napomena"].ToString();
                string a = Convert.ToDateTime(currentDatum).ToString("dd. MM. yyyy");

                // Postavite trenutne podatke kao placeholder tekst ili vrijednost u TextBox i CheckBox kontrole
                txtNastavniPlan_id.Text = currentNastavniPlan_id;
                txtDatum.Text = a;
                txtNastavnaJedinica.Text = currentNastavnaJedinica;
                txtMetodeRada.Text = currentMetodeRada;
                txtCasoviPredavanja.Text = currentCasoviPredavanja;
                txtCasoviVezbe.Text = currentCasoviVezbe;
                txtCasoviDON.Text = currentCasoviDON;
                txtCasoviPraksa.Text = currentCasoviPraksa;
                txtNapomena.Text = currentNapomena;

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
                    SqlCommand sqlCmd = new SqlCommand("UPDATE OdrzaniCasovi_NastavniPlan set nastavniPlan_id=@nastavniPlan_id,datum=@datum,nastavnaJedinica=@nastavnaJedinica,metodeRada=@metodeRada,casoviPredavanja=@casoviPredavanja,casoviVezbe=@casoviVezbe,casoviDON=@casoviDON,casoviPraksa=@casoviPraksa,napomena=@napomena where id=@id", sqlCon);


                    
                    //TextBox txtName = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtName");
                    TextBox txtNastavniPlan_id = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtNastavniPlan_id");
                    TextBox txtDatum = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtDatum");
                    TextBox txtNastavnaJedinica = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtNastavnaJedinica");
                    TextBox txtMetodeRada = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtMetodeRada");
                    TextBox txtCasoviPredavanja = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtCasoviPredavanja");
                    TextBox txtCasoviVezbe = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtCasoviVezbe");
                    TextBox txtCasoviDON = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtCasoviDON");
                    TextBox txtCasoviPraksa = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtCasoviPraksa");
                    TextBox txtNapomena = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtNapomena");
                    string a = Convert.ToDateTime(txtDatum.Text).ToString("yyy/MM/dd");

                    sqlCmd.Parameters.AddWithValue("@nastavniPlan_id", txtNastavniPlan_id.Text);
                    sqlCmd.Parameters.AddWithValue("@datum", a);
                    sqlCmd.Parameters.AddWithValue("@nastavnaJedinica", txtNastavnaJedinica.Text);
                    sqlCmd.Parameters.AddWithValue("@metodeRada", txtMetodeRada.Text);
                    sqlCmd.Parameters.AddWithValue("@casoviPredavanja", txtCasoviPredavanja.Text);
                    sqlCmd.Parameters.AddWithValue("@casoviVezbe", txtCasoviVezbe.Text);
                    sqlCmd.Parameters.AddWithValue("@casoviDON", txtCasoviDON.Text);
                    sqlCmd.Parameters.AddWithValue("@casoviPraksa", txtCasoviPraksa.Text);
                    sqlCmd.Parameters.AddWithValue("@napomena", txtNapomena.Text);

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
                    string query = "DELETE FROM OdrzaniCasovi_NastavniPlan WHERE id = @id";
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