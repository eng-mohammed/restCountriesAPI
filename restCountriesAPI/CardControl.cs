using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restCountriesAPI
{
    public partial class CardControl : UserControl
    {
        private string _flag;

        public string flag
        {
            get { return _flag; }
            set { flagImg.ImageLocation = _flag = value; }
        }

        private string _name;

        public string name
        {
            get { return _name; }
            set { lblName.Text = _name = value; }
        }

        public event EventHandler OnImageClick;

        public CardControl()
        {
            InitializeComponent();
            flagImg.Click += FlagImg_Click; ;
        }

        private void FlagImg_Click(object sender, EventArgs e)
        {
            if (OnImageClick != null) OnImageClick(this, EventArgs.Empty);
        }
    }
}
