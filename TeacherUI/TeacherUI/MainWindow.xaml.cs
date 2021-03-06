﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace TeacherUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public DataSet Disconnected()
        {
            DataSet dsCourse = new DataSet();
            SqlConnection conObj = new SqlConnection();
            //Retrieve the config string from config file using the name property
            conObj.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ToString();
            //Initialize DataAdapter to fetch data from DB establishing the connection
            SqlDataAdapter daCrs = new SqlDataAdapter("select * from Group1.Course", conObj);
            //Fill data into the DataSet
            daCrs.Fill(dsCourse, "Course");//using Fill method
          

            return dsCourse;


        }
        public static DataTable LoadDataGrid()
        {
            SqlDataReader rdrCrs = null;
            SqlConnection connObj = new SqlConnection();
            DataTable dtCrs = new DataTable();
            // Initialize the Connection object and set the ConnectionString Property
            try
            {

                connObj.ConnectionString = @"Data Source=ndamssql\sqlilearn;Initial Catalog=Sep19CHN;User ID=sqluser;Password=sqluser";



                SqlCommand cmdObj = new SqlCommand("select * from [Group1].[Course]", connObj);

                // Execute the Command
                connObj.Open();
                rdrCrs = cmdObj.ExecuteReader();
                if (rdrCrs.HasRows)
                {

                    dtCrs.Load(rdrCrs);
                    // binding UI with data
                }

            }
            catch (SqlException se)
            {
                MessageBox.Show("Exception Occurred" + se.Message, "Course Details");
            }

            finally
            {
                rdrCrs.Close();
                if (connObj.State == ConnectionState.Open)
                    connObj.Close();
            }
            return dtCrs;
        }

       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            DataSet ds = Disconnected();
          
          
            txt_empId.Text = GetAutoGeneratedId().ToString();



        }



        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Teacher_info ti = new Teacher_info();
            ti.Show();
        }

        private void btnAssign_Click(object sender, RoutedEventArgs e)
        {
            Assign a = new Assign();
            a.Show();
        }

        private void btnCrs_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
    

