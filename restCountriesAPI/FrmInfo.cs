using CefSharp.WinForms;
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
    public partial class FrmInfo : Form
    {
        Country _country;
        public FrmInfo(Country country)
        {
            InitializeComponent();
            _country = country;

            this.Load += FrmInfo_Load;
        }

        private async void FrmInfo_Load(object sender, EventArgs e)
        {
            imgFlag.ImageLocation = _country.Flags[1];
            lblName.Text = _country.Name.NativeName?.Ara == null ? _country.Name.Official : _country.Name.NativeName.Ara.Official;
            lblCapital.Text = "العاصـــمة : ";
            if (_country.Capital != null) _country.Capital.ForEach(x => lblCapital.Text += x + "_"); else lblCapital.Text = "_";
            lblRegion.Text = "المنطـــقة : " + _country.Region;

            await chromiumWebBrowser1.LoadUrlAsync($"{Application.StartupPath}/Pages/loading.html");
            await chromiumWebBrowser1.LoadUrlAsync(_country.Maps.GoogleMaps);

        }
    }
}
