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
        public start_app()
        {
            comboBox = new ComboBox();

            InitializeComponent();
            comboBox.Items.Add("Väike");
            comboBox.Items.Add("Keskmine");
            comboBox.Items.Add("Suur");
            comboBox.Location = new Point(1, 20);
            this.Controls.Add(comboBox);
            comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged; ;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex == 0)
            {
                i = 5; j = 5;
                suuremus = 1;
            }
            else if (comboBox.SelectedIndex == 1)
            {
                i = 10; j = 10;
                suuremus = 2;
            }
            else
            {
                i = 15; j = 15;
                suuremus = 3;
            }
            Form1 form1 = new Form1(i, j, suuremus);
            form1.Show();
        }
    }
}
