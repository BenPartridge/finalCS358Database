using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

public partial class About : Page
{
    static string selectedValue = "";

    private DatabaseHandler database;

    protected void Page_Load(object sender, EventArgs e)
    {
        database = new DatabaseHandler();

        if (!IsPostBack)
        {
            ShowResultsFromCourseTable();
        }

    }

    public void ShowResultsFromCourseTable()
    {
        DataTable dt = database.RetrieveTablefromCourseTable();
        
        foreach (DataRow row in dt.Rows)
        {
            string classNames = row.Field<string>(1);

            ListItem item = new ListItem(classNames);

            ClassList.Items.Add(item);            
        }
    }
 
    protected void ButtonSelect_Click(object sender, EventArgs e)
    {

        DataTable dt = database.RetrieveTablefromCourseTable();

        DataTable classes = new DataTable();

        {
            foreach (GridViewRow row in ClassesGV.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("CheckBox1") as CheckBox);
                    if (chkRow.Checked)
                    {
                        selectedValue += row.Cells[1].Text + ",";
                    }
                }
            }

        }

        {
            int index = ClassList.SelectedIndex;
            string[] name = dt.Rows[index].ItemArray.Select(x => x.ToString()).ToArray();
        
            classes.Columns.Add();
            classes.Columns.Add();
            classes.Columns.Add();
            classes.Columns.Add();
            classes.Columns.Add();
            classes.Columns.Add();
            classes.Columns.Add();
            classes.Columns.Add();
            classes.Rows.Add(name);
            ClassesGV.DataSource = classes;
            ClassesGV.DataBind();
        }
    }

    protected void ButtonYes_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in ClassesGV.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("CheckBox1") as CheckBox);
                if (chkRow.Checked)
                {
                    selectedValue += row.Cells[1].Text + ",";
                }
            }

            if (selectedValue != null)
            {
                selectedValue = selectedValue.Remove(selectedValue.Length - 1);

                Response.Redirect("Contact.aspx?selected=" + selectedValue);
            }
            else
            {
                LabelErrorMsg.Text = "No class selected. Please select a class.";
            }
        }
    }
}
