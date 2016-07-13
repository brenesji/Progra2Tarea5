using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WFA4
{
    public partial class Form1 : Form
    {
                   
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string sqlquery;
            string conexion = "Data Source=(local); " +
                "Initial Catalog=bd_empresa;" +
                "Integrated Security=True;"; 
            //'User ID=UserName;Password=Password;
            DataTable dt = new DataTable();
            sqlquery = "select cedula as 'Cédula', nombre, apellido, ubicacion, sexo from empleado";
            SqlConnection sqlconn = new SqlConnection(conexion);
            sqlconn.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlquery, sqlconn);
            sqlda.Fill(dt);
            sqlconn.Close();
            dataGridView1.DataSource = dt;  

        }      

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";            
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string conexion = "Data Source=(local);" + // en vez de Data Source=LAB210-01 uso (local)
                "Initial Catalog=bd_empresa;" +
                "Integrated Security=True;";
            string sqlquery;
            //'User ID=UserName;Password=Password;
            SqlConnection sqlconn = new SqlConnection(conexion);
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand();
            
            DataTable dt = new DataTable();
           
            sqlquery = "insert into empleado (" +
                "cedula," +
                "nombre," +
                "apellido," +
                "ubicacion," +
                "sexo" +
                ") values (" +
                    "'" + textBox1.Text + "'," +
                    "'" + textBox2.Text + "'," +
                    "'" + textBox3.Text + "'," +
                    "'" + textBox4.Text + "'," +  
                    "'" + textBox5.Text + "')";
            sqlcomm.Connection = sqlconn;
            sqlcomm.CommandText = sqlquery;
            sqlcomm.CommandType = CommandType.Text;
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
            sqlquery = "select cedula, nombre, apellido, ubicacion, sexo from empleado";
            sqlconn.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlquery, sqlconn);
            sqlda.Fill(dt);
            sqlconn.Close();
            dataGridView1.DataSource = dt;
        }

      

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string conexion = "Data Source=(local);" +
                              "Initial Catalog=bd_empresa;" +
                              "Integrated Security=True;";
            string sqlquery;
            //'User ID=UserName;Password=Password;
            SqlConnection sqlconn = new SqlConnection(conexion);
            sqlconn.Open();
            SqlCommand sqlcomm = new SqlCommand();
            DataTable dt = new DataTable();

            sqlquery =
            "UPDATE empleado " +
            "SET nombre = '" + textBox2.Text + "', " +
            "apellido = '" + textBox3.Text + "', " +
            "ubicacion = '" + textBox4.Text + "', " +
            "sexo = '" + textBox5.Text + "' " +
            "WHERE cedula =  '" + textBox1.Text + "' ;";

            sqlcomm.Connection = sqlconn;
            sqlcomm.CommandText = sqlquery;
            sqlcomm.CommandType = CommandType.Text;
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
            sqlquery = "select cedula, nombre, apellido, ubicacion, sexo from empleado";
            sqlconn.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(sqlquery, sqlconn);
            sqlda.Fill(dt);
            sqlconn.Close();
            dataGridView1.DataSource = dt;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!textBox1.Text.Equals(""))
                {
                    string conexion =
                    "Data Source=(local);" +
                    "Initial Catalog=bd_empresa;" +
                    "Integrated Security=True;";
                    string sqlquery;
                    //'User ID=UserName;Password=Password;
                    SqlConnection sqlconn = new SqlConnection(conexion);
                    sqlconn.Open();
                    SqlCommand sqlcomm = new SqlCommand();
                    DataTable dt = new DataTable();
                    sqlquery =
                    "DELETE FROM EMPLEADO WHERE " +
                    "cedula = " + textBox1.Text + ";";

                    sqlcomm.Connection = sqlconn;
                    sqlcomm.CommandText = sqlquery;
                    sqlcomm.CommandType = CommandType.Text;
                    sqlcomm.ExecuteNonQuery();
                    sqlconn.Close();
                    sqlquery = "select cedula, nombre, apellido, ubicacion, sexo from empleado";
                    sqlconn.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter(sqlquery, sqlconn);
                    sqlda.Fill(dt);
                    sqlconn.Close();
                    dataGridView1.DataSource = dt;
                }
            }
            catch (System.Exception exc)
            {
                Console.WriteLine(exc.GetType());
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //TextBox1.Text = DataGridView1(0, DataGridView1.CurrentRow.Index).Value
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            }
        }

    }
}
