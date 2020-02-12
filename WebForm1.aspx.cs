using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace RegistrationForm
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public object TextBox1 { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nikitha_Chittaluri\Source\Repos\RegistrationForm\RegistrationForm\App_Data\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from Country", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("Select State");

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nikitha_Chittaluri\Source\Repos\RegistrationForm\RegistrationForm\App_Data\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from States where CountryId=" + DropDownList1.SelectedItem.Value, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList3.Items.Clear();
            DropDownList3.Items.Add("Select State");

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nikitha_Chittaluri\Source\Repos\RegistrationForm\RegistrationForm\App_Data\Database1.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from Cities where StateId=" + DropDownList2.SelectedItem.Value, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            DropDownList3.DataSource = dt;
            DropDownList3.DataBind();

        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

       
        // method to execute after clicking re
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            if (LastName.Text.Trim() == String.Empty)
            {

                Response.Write("<script>alert('Last name required!');</script>");
            }
            else
            {
                Response.Redirect("WebForm2.aspx");
            }
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nikitha_Chittaluri\Source\Repos\RegistrationForm\RegistrationForm\App_Data\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into RegistrationTable values(@FirstName, @LastName,@Email, @ContactNumber, @Country, @State, @City, @Stream, @DOB, @Gender)", con);

            cmd.Parameters.AddWithValue("FirstName", FirstName.Text);
            cmd.Parameters.AddWithValue("LastName", LastName.Text);
            cmd.Parameters.AddWithValue("Email", Email.Text);
            cmd.Parameters.AddWithValue("ContactNumber", ContactNumber.Text);
            cmd.Parameters.AddWithValue("Country", DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("State", DropDownList2.SelectedItem.Text);
            cmd.Parameters.AddWithValue("City", DropDownList3.SelectedItem.Text);
            string GenderIs;
            if (Male.Checked)
                GenderIs="Male";
            else
                GenderIs = "Female";
            cmd.Parameters.AddWithValue("Gender", GenderIs);
            var message = "";
            if (c1.Checked)
            {
                message = c1.Text + " ";
            }
            if (c2.Checked)
            {
                message += c2.Text + " ";
            }
            if (c3.Checked)
            {
                message += c3.Text;
            }
            cmd.Parameters.AddWithValue("Stream", message);
            cmd.Parameters.AddWithValue("DOB",Calendar1.SelectedDate.ToShortDateString());
            cmd.ExecuteNonQuery();

           
            //Label7.Visible = true;
            //Label7.Text = "User registered successfully";

            //FnameTxt.Text = "";
            //LnameTxt.Text = "";
            //Email.Text = "";
            //MobileNumber.Text = "";
            //Password.Text = "";
            //FnameTxt.Focus();
        }

        protected void TextBox2_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Gender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}