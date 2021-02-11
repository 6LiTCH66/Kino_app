using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino_app
{
    public partial class Form1 : Form
    {
        Label[] labels;
        Label[,] _arr;
        int getData1, getData2;
        int[,] getArray;
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Kino_app\Kino_app\AppData\KinnoBaas.mdf;Integrated Security=True");
        SqlCommand command;
        int Suuremus;
        string SelectedFilm;
        DateTime getDate;


        public Form1(int _i, int _j, int size, string film, DateTimePicker dateTimePicker)
        {
            _arr = new Label[_i, _j];

            getArray = new int[_i, _j];

            labels = new Label[_i];
            
            Suuremus = size;

            SelectedFilm = film;

            getDate = dateTimePicker.Value;



            this.Text = "Ap_polo_kino";
            this.Size = new Size(300, 430);

            connection.Open();
            command = new SqlCommand("SELECT rida, koht FROM dbo.KinnoTable WHERE SaaliSuuremus=@SaaliSuuremus", connection);

            command.Parameters.AddWithValue("@SaaliSuuremus", Suuremus);

            command.ExecuteNonQuery();
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                getData1 = Convert.ToInt32(dataReader.GetValue(0)) - 1;
                getData2 = Convert.ToInt32(dataReader.GetValue(1)) - 1;


                string ConvertInt = (getData1, getData2).ToString();

                for (int x = 0; x < _i; x++)
                {
                    for (int y = 0; y < _j; y++)
                    {
                        if (getData1 == x && getData2 == y)
                        {
                            getArray[x, y] = 1;
                        }
                        
                    }
                }
            }
            connection.Close();

            for (int i = 0; i < _i; i++)
            {
                labels[i] = new Label();
                labels[i].Text = "Rida " + (i + 1);
                labels[i].Size = new Size(50, 50);
                labels[i].Location = new Point(1, i * 50);
                this.Controls.Add(labels[i]);
                for (int j = 0; j < _j; j++)
                {
                    _arr[i, j] = new Label();
                    if (getArray[i,j] == 1)
                    {
                        _arr[i, j].BackColor = Color.Red;
                    }
                    else
                    {
                        _arr[i, j].BackColor = Color.Green;
                    }
                    _arr[i, j].Text = " Koht" + (j + 1);
                    _arr[i, j].Size = new Size(50, 50);
                    _arr[i, j].BorderStyle = BorderStyle.Fixed3D;
                    _arr[i, j].Location = new Point(j * 50 + 50, i * 50);
                    this.Controls.Add(_arr[i, j]);
                    _arr[i, j].Tag = new int[] { i, j };
                    _arr[i, j].Click += Form1_Click;
                    
                }
            }
            

        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;

            var tag = (int[])lbl.Tag;
            if (lbl.BackColor == Color.Red)
            {

                MessageBox.Show("Koht on juba registreeritud!!!!");
                
            }
            else
            {
                

                MailForm mailForm = new MailForm(tag, Suuremus, SelectedFilm, getDate, lbl);

                mailForm.Show();

                lbl.BackColor = Color.Yellow;
            }


           
        }
    }
}
