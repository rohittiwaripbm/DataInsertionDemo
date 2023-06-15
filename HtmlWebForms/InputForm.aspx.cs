using DemoDataCode.Csfiles;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Xml.Linq;
using System.Drawing;

namespace DemoDataCode.HtmlWebForms
{
    public partial class InputForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Inputname.Value = string.Empty;
                Inputemail.Value = string.Empty;
                Inputmob.Value = string.Empty;
                
                #region Commented code
                //foreach (var items in dt.Rows)
                //{
                //    HtmlTableRow tableRow = new HtmlTableRow();
                //    HtmlTableCell cellId = new HtmlTableCell();
                //    HtmlTableCell cellName = new HtmlTableCell();
                //    HtmlTableCell cellEmail = new HtmlTableCell();
                //    HtmlTableCell cellMobileNumber = new HtmlTableCell();
                //    HtmlTableCell cellIsActive = new HtmlTableCell();

                //    // Set the cell values
                //    cellId.InnerText = items.Id.ToString();
                //    cellName.InnerText = items.UName;
                //    cellEmail.InnerText = items.UEmail;
                //    cellMobileNumber.InnerText = items.MobileNo;
                //    cellIsActive.InnerText = items.Uisactive.ToString();

                //    // Add the cells to the row
                //    tableRow.Cells.Add(cellId);
                //    tableRow.Cells.Add(cellName);
                //    tableRow.Cells.Add(cellEmail);
                //    tableRow.Cells.Add(cellMobileNumber);
                //    tableRow.Cells.Add(cellIsActive);

                //    // Add the row to the table

                //    TableData.Rows.Add(tableRow);
                //}
                #endregion
            }
            FetchData f = new FetchData();
            //List<UserData> users = f.Fetch();
            DataTable dt = f.Fetch();
            grid1.DataSource = dt;
            grid1.DataBind();

        }

        protected void Save(object sender, EventArgs e)
        {
           
            string Name = Inputname.Value;
            string Email = Inputemail.Value;
            string Mob_no = Inputmob.Value;
            Encryption c = new Encryption();
            
            EncryptionKey key = new EncryptionKey();    
            MySqlConnection con = new MySqlConnection();
            //if (string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Mob_no))
            //{
                try
                {
                    con = new MySqlConnection(ConnString.connectionString);
                    Name = Name.Trim();
                    Email = Email.Trim();
                    Mob_no = Mob_no.Trim();
                    // writing sql query  
                    MySqlCommand cm = new MySqlCommand("INSERT INTO DemoTable " +
                        "(Uname, Uemail, Mob_no, Isactive) VALUES (@Name, @Email, @MobNo, 1);", con);
                    cm.Parameters.AddWithValue("@Name",Name);
                    cm.Parameters.AddWithValue("@Email", c.EncryptString(EncryptionKey.key, Email));
                    cm.Parameters.AddWithValue("@MobNo", c.EncryptString(EncryptionKey.key, Mob_no));

                    // Opening Connection  
                    con.Open();
                    cm.ExecuteNonQuery();

                    // Display an alert when the button is clicked
                    string script = "alert('Successfully Saved!');";
                    ClientScript.RegisterStartupScript(this.GetType(), "ButtonAlertScript", script, true);
                    Response.Redirect("InputForm.aspx");
            }
                catch (Exception ex)
                {
                    // Display an alert when the button is clicked
                    string script = "alert('Some Error Occured!');";
                    ClientScript.RegisterStartupScript(this.GetType(), "ButtonAlertScript", script, true);
                }
                finally
                {
                    con.Close();

                    Inputname.Value = null;
                    Inputemail.Value = null;
                    Inputmob.Value = null;
                }

           // }

            //else
            //{
            //    string script = "alert('Fields Cannot be null');";
            //    ClientScript.RegisterStartupScript(this.GetType(), "ButtonAlertScript", script, true);
            //}
            // Creating Connection  
        }

        protected void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Encryption Enc = new Encryption();
                

                Label Email = (Label)e.Row.FindControl("DecryptedEmail");
                Email.Text = Enc.DecryptString(EncryptionKey.key,Email.Text );

                Label Mobno = (Label)e.Row.FindControl("DecryptedMobno");
                Mobno.Text = Enc.DecryptString(EncryptionKey.key, Mobno.Text);



            }
        }
    }
}