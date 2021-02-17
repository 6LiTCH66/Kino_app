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

        //static string[] Filmid = new string[] { "Jõulud džunglis", "Koletisekütt", "Hing", "Tulemeri", "Laululind", "Võlukaar" };
        //static int FilLen = Filmid.Length;

        CheckBox[] checkBoxes;
        Label lbl, lbl2, lbl3, lbl4;
        CheckBox GetCheck;
        DateTimePicker timePicker;
        Button btn;
        string selectedFilm;
        ListBox listBox;
        DateTime SelecetedTime;
        DateTime[] VaikeSaalAeg = new DateTime[] { 
            new DateTime(2021, 11, 25, 14, 10, 10),
            new DateTime(2021, 11, 20, 20, 10, 10),
            new DateTime(2021, 11, 15, 12, 25, 00) };

        DateTime[] KeskmineSaalAeg = new DateTime[] { 
            new DateTime(2021, 11, 10, 10, 00, 00),
            new DateTime(2021, 11, 13, 14, 30, 00),
            new DateTime(2021, 11, 14, 19,00,10),
            new DateTime(2021, 12, 15, 20, 30, 10),
            new DateTime(2021, 12, 16, 21, 55, 05)};
        DateTime[] SuurSaalAeg = new DateTime[] { 
            new DateTime(2021, 11, 16, 11, 10, 00),
            new DateTime(2021, 11, 17, 15, 10, 05),
            new DateTime(2021, 11, 18, 19, 45, 00),
            new DateTime(2021, 12, 01, 12, 45, 00),
            new DateTime(2021, 12, 02, 15, 50, 00),
            new DateTime(2021, 12, 03, 18, 55, 00),
            new DateTime(2021, 12, 05, 23, 59, 59)
        };

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\Kino_app\Kino_app\AppData\KinnoBaas.mdf;Integrated Security=True");
        SqlCommand command;

        string[] Ketegooria = new string[] { "Komöödiafilm", "Noortefilm", "Romantilised", "Muusika" };
        public start_app()
        {
            InitializeComponent();

            List<string> valueList = new List<string>();


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

                MessageBox.Show(ex.ToString());
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

            for (int i = 0; i < Ketegooria.Length; i++)
            {
                comboBox1.Items.Add(Ketegooria[i]);
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


            comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;


            listBox.SelectedValueChanged += ListBox_SelectedValueChanged;

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

                for (int i = 0; i < VaikeSaalAeg.Length; i++)
                {
                    listBox.Items.Add(VaikeSaalAeg[i]);
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

                for (int i = 0; i < KeskmineSaalAeg.Length; i++)
                {
                    listBox.Items.Add(KeskmineSaalAeg[i]);
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

                for (int i = 0; i < SuurSaalAeg.Length; i++)
                {
                    listBox.Items.Add(SuurSaalAeg[i]);
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

                for (int i = 0; i < SuurSaalAeg.Length; i++)
                {
                    listBox.Items.Add(SuurSaalAeg[i]);
                }
                comboBox.SelectedItem = "Keskmine";
            }
        }

        private void ListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ListBox GetListBox = (ListBox)sender;
            SelecetedTime = DateTime.Parse(GetListBox.SelectedItem.ToString());
            MessageBox.Show(GetListBox.SelectedItem.ToString()) ;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox.SelectedIndex > -1 && GetCheck.Checked == true)
                {
                    selectedFilm = GetCheck.Text;

                    Form1 form1 = new Form1(i, j, suuremus, selectedFilm, SelecetedTime);
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
