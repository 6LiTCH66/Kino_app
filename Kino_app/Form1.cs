using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino_app
{
    public partial class Form1 : Form
    {
        Label[] labels;
        Label[,] _arr;
        int _i, _j;
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Kino_app\Kino_app\AppData\KinnoBaas.mdf;Integrated Security=True");
        SqlCommand command;
        public Form1(int _i, int _j)
        {
            _arr = new Label[_i, _j];
            labels = new Label[_i];
            this.Text = "Ap_polo_kino";
            this.Size = new Size(300, 430); 

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
                    _arr[i, j].BackColor = Color.Gray;
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
            lbl.BackColor = Color.Yellow;

            var tag = (int[])lbl.Tag;

            connection.Open();
            command = new SqlCommand("INSERT INTO KinnoTable(rida, koht) VALUES(@rida, @koht)", connection);

            command.Parameters.AddWithValue("@rida", (tag[0] + 1));
            command.Parameters.AddWithValue("@koht", (tag[1] + 1));

            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Andmed on lisatud");

            MessageBox.Show((tag[0] + 1) .ToString() + " " + (tag[1] + 1).ToString());
        }
    }
}
