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
    public partial class Unos_NastavniPlan_GodinaSemestar_TipStudija : System.Web.UI.Page
    {
        //string connectionString = "Data Source=DESKTOP-5DQ906E\\SQLEXPRESS;Initial Catalog=EDnevnikVranje;User ID=sa; Password=Pskssp555;";
        //public object ddlKartonPredmeta_id;
        string connectionString = ConfigurationManager.ConnectionStrings["EDnevnikVranje"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindDropDownLists();
                PopulateGridview();
            }

        }

        //private void BindDropDownLists()
        //{
        //    List<KeyValuePair<string, string>> data = GetDataFromDatabase();

        //    ddlKartonPredmeta_id.DataSource = data;
        //    ddlKartonPredmeta_id.DataTextField = "Value";
        //    ddlKartonPredmeta_id.DataValueField = "Key";
        //    ddlKartonPredmeta_id.DataBind();
        //}

        //private void BindDropDownList(DropDownList ddl, List<KeyValuePair<string, string>> data)
        //{
        //    ddl.DataSource = data;
        //    ddl.DataTextField = "Value";
        //    ddl.DataValueField = "Key";
        //    ddl.DataBind();
        //}

        //public List<KeyValuePair<string, string>> GetDataFromDatabase()
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["EDnevnikVranjeConnectionString"].ConnectionString;
        //    List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        string query = "SELECT id, name FROM KartonPredmeta"; // Promenite ime tabele i kolona prema vašoj bazi

        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            connection.Open();
        //            SqlDataReader reader = command.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                string key = reader["id"].ToString();
        //                string value = reader["name"].ToString(); // Pretpostavljamo da je ovo naziv koji želite da prikažete u DropDownList

        //                data.Add(new KeyValuePair<string, string>(key, value));
        //            }

        //            reader.Close();
        //        }
        //    }

        //    return data;
        //}

        void PopulateGridview()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM NastavniPlan_GodinaSemestar_TipStudija", sqlCon);
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
                        string query = "INSERT INTO NastavniPlan_GodinaSemestar_TipStudija (tipStudija_id,godinaSemestra_id,kartonPredmeta_id,nastavnik_id,casoviPredavanja,casoviVezbe,casoviDON,casoviPraksa,status) VALUES (@tipStudija_id,@godinaSemestra_id,@kartonPredmeta_id,@nastavnik_id,@casoviPredavanja,@casoviVezbe,@casoviDON,@casoviPraksa,@status)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                        // Retrieve the values from the new row's text boxes
                        TextBox txtTipStudija_id = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtTipStudija_idFooter");
                        TextBox txtGodinaSemestra_id = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtGodinaSemestra_idFooter");
                        DropDownList ddlKartonPredmeta_id = (DropDownList)EDnevnikVranje.FooterRow.FindControl("ddlKartonPredmeta_id");
                        DropDownList ddlNastavnik_id = (DropDownList)EDnevnikVranje.FooterRow.FindControl("ddlNastavnik_id");
                        TextBox txtCasoviPredavanja = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtCasoviPredavanjaFooter");
                        TextBox txtCasoviVezbe = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtCasoviVezbeFooter");
                        TextBox txtCasoviDON = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtCasoviDONFooter");
                        TextBox txtCasoviPraksa = (TextBox)EDnevnikVranje.FooterRow.FindControl("txtCasoviPraksaFooter");
                        CheckBox chkStatus = (CheckBox)EDnevnikVranje.FooterRow.FindControl("txtStatusFooter");



                        sqlCmd.Parameters.AddWithValue("@tipStudija_id", txtTipStudija_id.Text);
                        sqlCmd.Parameters.AddWithValue("@godinaSemestra_id", txtGodinaSemestra_id.Text);
                        sqlCmd.Parameters.AddWithValue("@kartonPredmeta_id", ddlKartonPredmeta_id.SelectedValue);
                        sqlCmd.Parameters.AddWithValue("@nastavnik_id", ddlNastavnik_id.Text);
                        sqlCmd.Parameters.AddWithValue("@casoviPredavanja", txtCasoviPredavanja.Text);
                        sqlCmd.Parameters.AddWithValue("@casoviVezbe", txtCasoviVezbe.Text);
                        sqlCmd.Parameters.AddWithValue("@casoviDON", txtCasoviDON.Text);
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
                TextBox txtGodinaSemestra_id = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtGodinaSemestra_id");
                DropDownList ddlKartonPredmeta_id = (DropDownList)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("ddlKartonPredmeta_id");
                DropDownList ddlNastavnik_id = (DropDownList)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("ddlNastavnik_id");
                TextBox txtCasoviPredavanja = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtCasoviPredavanja");
                TextBox txtCasoviVezbe = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtCasoviVezbe");
                TextBox txtCasoviDON = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtCasoviDON");
                TextBox txtCasoviPraksa = (TextBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtCasoviPraksa");
                

                CheckBox chkStatus = (CheckBox)EDnevnikVranje.Rows[e.NewEditIndex].FindControl("txtStatus");

                // Dohvatite trenutne podatke iz GridView-a
                string currentTipStudija_id = EDnevnikVranje.DataKeys[e.NewEditIndex]["tipStudija_id"].ToString();
                string currentGodinaSemestra_id = EDnevnikVranje.DataKeys[e.NewEditIndex]["godinaSemestra_id"].ToString();
                string currentKartonPredmeta_id = EDnevnikVranje.DataKeys[e.NewEditIndex]["kartonPredmeta_id"].ToString();
                string currentNastavnik_id = EDnevnikVranje.DataKeys[e.NewEditIndex]["nastavnik_id"].ToString();
                string currentCasoviPredavanja = EDnevnikVranje.DataKeys[e.NewEditIndex]["casoviPredavanja"].ToString();
                string currentCasoviVezbe = EDnevnikVranje.DataKeys[e.NewEditIndex]["casoviVezbe"].ToString();
                string currentCasoviDON = EDnevnikVranje.DataKeys[e.NewEditIndex]["casoviDON"].ToString();
                string currentCasoviPraksa = EDnevnikVranje.DataKeys[e.NewEditIndex]["casoviPraksa"].ToString();
                bool currentStatus = (bool)EDnevnikVranje.DataKeys[e.NewEditIndex]["status"];

                // Postavite trenutne podatke kao placeholder tekst ili vrijednost u TextBox i CheckBox kontrole
                txtTipStudija_id.Text = currentTipStudija_id;
                txtGodinaSemestra_id.Text = currentGodinaSemestra_id;
                ddlKartonPredmeta_id.Text = currentKartonPredmeta_id;
                ddlNastavnik_id.Text = currentNastavnik_id;
                txtCasoviPredavanja.Text = currentCasoviPredavanja;
                txtCasoviVezbe.Text = currentCasoviVezbe;
                txtCasoviDON.Text = currentCasoviDON;
                txtCasoviPraksa.Text= currentCasoviPraksa;
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
                    SqlCommand sqlCmd = new SqlCommand("UPDATE NastavniPlan_GodinaSemestar_TipStudija set tipStudija_id=@tipStudija_id,godinaSemestra_id=@godinaSemestra_id,kartonPredmeta_id=@kartonPredmeta_id,nastavnik_id=@nastavnik_id,casoviPredavanja=@casoviPredavanja,casoviVezbe=@casoviVezbe,casoviDON=@casoviDON,casoviPraksa=@casoviPraksa,status=@status where id=@id", sqlCon);

                    //TextBox txtName = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtName");
                    TextBox txtTipStudija_id = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtTipStudija_id");
                    TextBox txtGodinaSemestra_id = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtGodinaSemestra_id");
                    DropDownList ddlKartonPredmeta_id = (DropDownList)EDnevnikVranje.Rows[e.RowIndex].FindControl("ddlKartonPredmeta_id");
                    DropDownList ddlNastavnik_id = (DropDownList)EDnevnikVranje.Rows[e.RowIndex].FindControl("ddlNastavnik_id");
                    TextBox txtCasoviPredavanja = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtCasoviPredavanja");
                    TextBox txtCasoviVezbe = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtCasoviVezbe");
                    TextBox txtCasoviDON = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtCasoviDON");
                    TextBox txtCasoviPraksa = (TextBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtCasoviPraksa");

                    CheckBox chkStatus = (CheckBox)EDnevnikVranje.Rows[e.RowIndex].FindControl("txtStatus");


                    sqlCmd.Parameters.AddWithValue("@tipStudija_id", txtTipStudija_id.Text);
                    sqlCmd.Parameters.AddWithValue("@godinaSemestra_id", txtGodinaSemestra_id.Text);
                    sqlCmd.Parameters.AddWithValue("@kartonPredmeta_id", ddlKartonPredmeta_id.SelectedValue);
                    sqlCmd.Parameters.AddWithValue("@nastavnik_id", ddlNastavnik_id.Text);
                    sqlCmd.Parameters.AddWithValue("@casoviPredavanja", txtCasoviPredavanja.Text);
                    sqlCmd.Parameters.AddWithValue("@casoviVezbe", txtCasoviVezbe.Text);
                    sqlCmd.Parameters.AddWithValue("@casoviDON", txtCasoviDON.Text);
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
                    string query = "DELETE FROM NastavniPlan_GodinaSemestar_TipStudija WHERE id = @id";
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