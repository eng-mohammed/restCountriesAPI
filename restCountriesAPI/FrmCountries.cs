using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace restCountriesAPI
{
    public partial class FrmCountries : Form
    {
        string BaseAddress = "https://restcountries.com/v3/";
        public FrmCountries()
        {
            InitializeComponent();
            this.Load += Form1_Load;

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadCountriesData();
        }
        private async Task LoadCountriesData()
        {
            //mainPanel.Dock = DockStyle.Fill;
            await Task.Run(async () =>
            {
                HttpClient httpClient = new HttpClient();

                var response = await httpClient.GetAsync($"{BaseAddress}/all");
                var jsonData = await response.Content.ReadAsStringAsync();
                httpClient.Dispose();

                var countries = JsonConvert.DeserializeObject<List<Country>>(jsonData);
                List<Country> countryList = countries
                               .Where(x => !x.Name.Common.Equals("Israel"))
                               .OrderByDescending(x => x.Name.NativeName?.Ara?.Official).ToList();

                List<Control> controls = new List<Control>();

                foreach (var item in countryList)
                {
                    CardControl cardControl = new CardControl()
                    {
                        flag = item.Flags[1],
                        name = item.Name.NativeName?.Ara == null ? item.Name.Official : item.Name.NativeName.Ara.Official
                    };

                    // click event 
                    cardControl.OnImageClick += ((s, e) =>
                    {
                        var frm = Application.OpenForms["FrmInfo"];
                        if (frm != null) frm.Close();
                        var frmInfo = new FrmInfo(item);
                        frmInfo.MdiParent = this;
                        frmInfo.Show();
                    });


                    cardControl.Margin = new Padding(5);
                    controls.Add((CardControl)cardControl);
                }
                this.Invoke((MethodInvoker)delegate
                {
                    mainPanel.Controls.AddRange(controls.ToArray());
                    lblLoading.Visible = false;
                });


            });

        }


    }
}
