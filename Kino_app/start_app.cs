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
    public partial class start_app : Form
    {
        ComboBox comboBox, comboBox1;
        int i, j;
        int suuremus;

        CheckBox[] checkBoxes;
        Label lbl, lbl2, lbl3, lbl4;
        CheckBox GetCheck;
        DateTimePicker timePicker;
        Button btn;
        ListBox listBox;
        DateTime SelecetedTime;


        Button AdminPanelBtn;

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Kino_app\Kino_app\AppData\KinnoBaas.mdf;Integrated Security=True");
        SqlCommand command;
        List<DateTime> dateTimes;
        List<string> GetCategory;
        int GetIdFilm;
        int GetIdTime;

        public start_app()
        {
            InitializeComponent();

            List<string> valueList = new List<string>();
            dateTimes = new List<DateTime>();

            GetCategory = new List<string>();

            try
            {
                command = new SqlCommand("SELECT KategooriNime, Id FROM dbo.Category", connection);
                connection.Open();
                SqlDataReader sqlData = command.ExecuteReader();
                while (sqlData.Read())
                {
                    GetCategory.Add(sqlData[0].ToString());
                }
                sqlData.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Viga!!!");
            }
            finally
            {
                connection.Close();
            }

            try
            {
                command = new SqlCommand("SELECT aeg, Id FROM dbo.FilmTime", connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    dateTimes.Add(DateTime.Parse(dataReader[0].ToString()));
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Viga!!!");
            }
            finally
            {
                connection.Close();
            }


            try
            {
                command = new SqlCommand("SELECT FilmiNimi, Id FROM dbo.Film", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    valueList.Add(reader[0].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Viga!!!");
            }
            finally
            {
                connection.Close();
            }
            checkBoxes = new CheckBox[valueList.Count];


            comboBox = new ComboBox();

            comboBox1 = new ComboBox();

            btn = new Button()
            {
                Text = "Osta pilet",
            };
            btn.Click += Btn_Click;

            lbl = new Label()
            {
                Text = "Vali Kategoori: ",
            };
            lbl2 = new Label()
            {
                Text = "Vali filmi: ",
            };

            timePicker = new DateTimePicker()
            {
                Size = new Size(152, 20)
            };
            lbl3 = new Label()
            {
                Text = "Vali aeg: ",
                Size = new Size(50, 13),
            };

            lbl4 = new Label()
            {
                Text = "Saal"

            };

            listBox = new ListBox()
            {
                Size = new Size(215, 82),

            };
            AdminPanelBtn = new Button()
            {
                Text = "Admin Panel",
                Size = new Size(93, 28)
            };
            AdminPanelBtn.Location = new Point(695, 410);
            AdminPanelBtn.Click += AdminPanelBtn_Click;
            


            int x = 5, y = 20;
            for (int i = 0; i < valueList.Count; i++)
            {
                checkBoxes[i] = new CheckBox() { Text = valueList[i] };
                checkBoxes[i].Location = new Point(x * 30, y * 5);
                checkBoxes[i].CheckedChanged += Start_app_CheckedChanged;
                Controls.Add(checkBoxes[i]);
                y = y + 10;
            }


            comboBox.Items.Add("Väike");
            comboBox.Items.Add("Keskmine");
            comboBox.Items.Add("Suur");

            for (int i = 0; i < GetCategory.Count; i++)
            {
                comboBox1.Items.Add(GetCategory[i]);
            }

            lbl2.Location = new Point(6, 100);
            lbl.Location = new Point(6, 31);

            comboBox.Location = new Point(350, 31);

            comboBox1.Location = new Point(130, 31);

            btn.Location = new Point(19, 353);
            lbl3.Location = new Point(377, 150);
            listBox.Location = new Point(446, 150);


            this.Controls.Add(lbl3);
            this.Controls.Add(btn);
            this.Controls.Add(lbl2);
            this.Controls.Add(lbl);
            this.Controls.Add(comboBox);
            this.Controls.Add(listBox);
            this.Controls.Add(comboBox1);
            this.Controls.Add(AdminPanelBtn);


            comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            comboBox.Enabled = false;

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;


            listBox.SelectedValueChanged += ListBox_SelectedValueChanged;

        }

        private void AdminPanelBtn_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.Show();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {

                listBox.Items.Clear();
                i = 5; j = 5;
                suuremus = 1;
                checkBoxes[4].Enabled = false;
                checkBoxes[3].Enabled = false;
                checkBoxes[2].Enabled = false;
                checkBoxes[4].Checked = false;
                checkBoxes[2].Checked = false;
                checkBoxes[3].Checked = false;

                for (int i = 0; i < 4; i++)
                {
                    listBox.Items.Add(dateTimes[i]);
                }
                comboBox.SelectedItem = "Väike";


            }
            else if (comboBox1.SelectedIndex == 1)
            {
                listBox.Items.Clear();
                i = 10; j = 10;
                suuremus = 2;
                checkBoxes[4].Enabled = false;
                checkBoxes[3].Enabled = true;
                checkBoxes[2].Enabled = false;
                checkBoxes[4].Enabled = false;
                checkBoxes[2].Enabled = false;

                for (int i = 0; i < 7; i++)
                {
                    listBox.Items.Add(dateTimes[i]);
                }
                comboBox.SelectedItem = "Keskmine";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                listBox.Items.Clear();
                i = 15; j = 15;
                suuremus = 3;
                checkBoxes[4].Enabled = true;
                checkBoxes[3].Enabled = true;
                checkBoxes[2].Enabled = true;

                for (int i = 0; i < 10; i++)
                {
                    listBox.Items.Add(dateTimes[i]);
                }
                comboBox.SelectedItem = "Suur";
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                listBox.Items.Clear();
                i = 15; j = 15;
                suuremus = 3;
                checkBoxes[4].Enabled = true;
                checkBoxes[3].Enabled = true;
                checkBoxes[2].Enabled = false;

                for (int i = 0; i < dateTimes.Count; i++)
                {
                    listBox.Items.Add(dateTimes[i]);
                }
                comboBox.SelectedItem = "Keskmine";
            }
        }

        private void ListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ListBox GetListBox = (ListBox)sender;
            SelecetedTime = DateTime.Parse(GetListBox.SelectedItem.ToString());
            MessageBox.Show(GetListBox.SelectedItem.ToString());
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox.SelectedIndex > -1 && GetCheck.Checked == true)
                {

                    // get FilmiNime_Id from Film Table 
                    // GetCheck = Film Name
                    try
                    {
                        connection.Open();
                        command = new SqlCommand("SELECT Id FROM dbo.Film WHERE FilmiNimi=@FilmNime", connection);
                        command.Parameters.AddWithValue("@FilmNime", GetCheck.Text);
                        GetIdFilm = Convert.ToInt32(command.ExecuteScalar());

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        connection.Close();
                    }

                    try
                    {
                        connection.Open();
                        command = new SqlCommand("SELECT Id FROM FilmTime WHERE aeg=@SelectedAeg", connection);
                        command.Parameters.AddWithValue("@SelectedAeg", SelecetedTime);
                        GetIdTime = Convert.ToInt32(command.ExecuteScalar());


                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        connection.Close();
                    }

                    Form1 form1 = new Form1(i, j, suuremus, GetIdFilm, GetIdTime);
                    form1.Show();
                }
                else if (comboBox.SelectedText == "" && GetCheck.Checked == true)
                {
                    MessageBox.Show("Vali saal!!!");
                }
                else if (GetCheck.Checked == false && comboBox.SelectedIndex > -1)
                {
                    MessageBox.Show("Vali Film!!!");
                }
                else if (comboBox.SelectedText == "" && GetCheck.Checked == false)
                {
                    MessageBox.Show("Vali Film ja saal");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Sa midagi ei valitud!!!");
            }
            
            
        }

        private void Start_app_CheckedChanged(object sender, EventArgs e)
        {
            GetCheck = (CheckBox)sender;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}
