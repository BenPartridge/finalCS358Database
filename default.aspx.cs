using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;


    public partial class _Default : Page
    {
        private DatabaseHandler database;

        protected void Page_Load(object sender, EventArgs e)
        {
            database = new DatabaseHandler();
            //database.ConnectDatabase();
            //database.CreateTable();
            //ShowAllTables();
            Lable1.Text = "successful connection";
            //database.ImportData();
            ShowResultsFromCourseTable();
        }

        public void ShowAllTables()
        {
            MySqlDataReader reader = database.RetrieveData("Show Tables;");
            while (reader.Read())
            {
                Lable1.Text += reader[0] + "--";
            }
            database.CloseConnection();
        }

        public void ShowResultsFromCourseTable()
        {
            DataTable dt = database.RetrieveTablefromCourseTable();

            CourseGV.DataSource = dt;
            CourseGV.DataBind();
        }
    }

