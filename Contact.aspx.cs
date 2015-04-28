using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

public partial class Contact : Page
{

    private string[] selectedList;
    private DatabaseHandler database;

    protected void Page_Load(object sender, EventArgs e)
    {
        database = new DatabaseHandler();
        //read the passed variables
        String selectedCourse = Request.QueryString["selected"];
        selectedList = selectedCourse.Split(',');

    }
    protected void ButtonCont_Click(object sender, EventArgs e)
    {

        foreach (string id in selectedList)
        {

            database = new DatabaseHandler();

            DataTable dt = database.RetrieveTablefromCourseTable();

            //update number of students who take this course
            int currentNum = 0;
            int courseId = int.Parse(id);

            foreach (DataRow row in dt.Rows)
            {
                string test = row["currentNum"].ToString();
                //we add one to currentNum
                if (row["currentNum"].ToString() != "")
                {
                    currentNum = (int)row["currentNum"];
                    currentNum += 1;

                }
                else
                {
                    //if currentNUM = null, you are the first student to register for this class
                    currentNum = 1;
                }
            }
        }

        Response.Redirect("Default.aspx");
    }

}
