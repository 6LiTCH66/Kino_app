using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino_app
{
    public partial class start_app : Form
    {
        ComboBox comboBox;
        int i, j;
        int suuremus;
        static string[] Filmid = new string[] { "Jõulud džunglis", "Koletisekütt", "Hing", "Tulemeri", "Laululind" };
        static int FilLen = Filmid.Length;
        CheckBox[] checkBoxes = new CheckBox[FilLen];
        Label lbl, lbl2, lbl3;
        CheckBox GetCheck;
        DateTimePicker timePicker;
        Button btn;
        string selectedFilm;
        
        public start_app()
        {
            comboBox = new ComboBox();

            btn = new Button()
            {
                Text = "Osta pilet",
            };
            btn.Click += Btn_Click;
            InitializeComponent();
            lbl = new Label()
            {
                Text = "Vali saali suuremus: ",
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

            int x = 5, y = 20;
            for (int i = 0; i < FilLen; i++)
            {
                checkBoxes[i] = new CheckBox() { Text = Filmid[i] };
                checkBoxes[i].Location = new Point(x * 30, y * 5);
                checkBoxes[i].CheckedChanged += Start_app_CheckedChanged;
                Controls.Add(checkBoxes[i]);
                y = y + 10;

            }


            comboBox.Items.Add("Väike");
            comboBox.Items.Add("Keskmine");
            comboBox.Items.Add("Suur");
            lbl2.Location = new Point(6, 100);
            lbl.Location = new Point(6, 31);
            timePicker.Location = new Point(446, 32);
            comboBox.Location = new Point(130, 31);
            btn.Location = new Point(19, 353);
            lbl3.Location = new Point(377, 32);
            this.Controls.Add(lbl3);
            this.Controls.Add(timePicker);
            this.Controls.Add(btn);
            this.Controls.Add(lbl2);
            this.Controls.Add(lbl);
            this.Controls.Add(comboBox);


            comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox.SelectedIndex > -1 && GetCheck.Checked == true)
                {
                    selectedFilm = GetCheck.Text;

                    Form1 form1 = new Form1(i, j, suuremus, selectedFilm, timePicker);
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

                MessageBox.Show("Vali Film!!!");
            }
            
            
        }

        private void Start_app_CheckedChanged(object sender, EventArgs e)
        {
            GetCheck = (CheckBox)sender;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex == 0)
            {
                i = 5; j = 5;
                suuremus = 1;
                checkBoxes[4].Enabled = false;
                checkBoxes[3].Enabled = false;
                checkBoxes[2].Enabled = false;
                checkBoxes[4].Checked = false;
                checkBoxes[2].Checked = false;
                checkBoxes[3].Checked = false;


            }
            else if (comboBox.SelectedIndex == 1)
            {
                i = 10; j = 10;
                suuremus = 2;
                checkBoxes[4].Enabled = false;
                checkBoxes[3].Enabled = true;
                checkBoxes[2].Enabled = false;
                checkBoxes[4].Enabled = false;
                checkBoxes[2].Enabled = false;
            }
            else
            {
                i = 15; j = 15;
                suuremus = 3;
                checkBoxes[4].Enabled = true;
                checkBoxes[3].Enabled = true;
                checkBoxes[2].Enabled = true;
            }

        }
    }
}
