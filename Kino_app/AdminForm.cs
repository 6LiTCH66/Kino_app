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
    public partial class AdminForm : Form
    {
        Label LisaFilmLbl, LisaKatLbl, LisaKategooriaLbl;
        Button LisaFilmJaKate, LisaKategoori;
        ComboBox KategooriaComboBox;
        TextBox LisaFilmTxt, LisaKategooriaTxt;
        public AdminForm()
        {
            LisaFilmLbl = new Label()
            {
                Text = "Lisa Film",
                Size = new Size(47, 13)
            };
            LisaFilmLbl.Location = new Point(38, 36);

            LisaFilmTxt = new TextBox()
            {
                Size = new Size(166, 20)
            };
            LisaFilmTxt.Location = new Point(118, 33);



            LisaKatLbl = new Label()
            {
                Text = "Kategooria",
                Size = new Size(58, 13)
            };
            LisaKatLbl.Location = new Point(27, 77);

            KategooriaComboBox = new ComboBox()
            {
                Size = new Size(163, 21),
            };
            KategooriaComboBox.Location = new Point(118, 77);


            LisaFilmJaKate = new Button()
            {
                Size = new Size(138, 23),
                Text = "Lisa Film Ja Kategooria"
            };
            LisaFilmJaKate.Location = new Point(285, 122);

            LisaFilmJaKate.Click += LisaFilmJaKate_Click;

            LisaKategoori = new Button()
            {
                Text = "Lisa Kategooria",
                Size = new Size(110, 23),
            };
            LisaKategoori.Location = new Point(313, 261);

            LisaKategoori.Click += LisaKategoori_Click;

            LisaKategooriaLbl = new Label()
            {
                Text = "Lisa Kategooria",
                Size = new Size(74, 13),
            };
            LisaKategooriaLbl.Location = new Point(11, 261);

            LisaKategooriaTxt = new TextBox()
            {
                Size = new Size(166, 20),
            };
            LisaKategooriaTxt.Location = new Point(104, 261);



            this.Controls.Add(LisaFilmLbl);
            this.Controls.Add(LisaFilmTxt);
            this.Controls.Add(LisaKatLbl);
            this.Controls.Add(KategooriaComboBox);
            this.Controls.Add(LisaFilmJaKate);


            this.Controls.Add(LisaKategoori);
            this.Controls.Add(LisaKategooriaLbl);
            this.Controls.Add(LisaKategooriaTxt);



            InitializeComponent();
        }

        private void LisaFilmJaKate_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LisaKategoori_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
