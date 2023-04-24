using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace p4DovizOfisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string gunun_tarihi = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldoysa= new XmlDocument();
            xmldoysa.Load(gunun_tarihi);

            string dolar_alis = xmldoysa.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            lblDolarAlis.Text = dolar_alis; 

            string dolar_satis= xmldoysa.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lblDolarSatis.Text = dolar_satis;

            string euro_alis = xmldoysa.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            lblEuroAlis.Text = euro_alis;

            string euro_satis = xmldoysa.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lblEuroSatis.Text = euro_satis;
        }

        private void btnDolarAlis_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblDolarAlis.Text;
        }

        private void btnDolarSatis_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblDolarSatis.Text;
        }

        private void btnEuroAl_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblEuroAlis.Text;
        }

        private void btnEuroSatis_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblEuroSatis.Text;
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur= Convert.ToDouble(txtKur.Text);
            miktar= Convert.ToDouble(txtMiktar.Text);
            tutar = kur * miktar;
            txtTutar.Text=tutar.ToString();

        }

        private void txtKur_TextChanged(object sender, EventArgs e)
        {
            txtKur.Text=txtKur.Text.Replace(".",",");
        }

        private void btnSatis2_Click(object sender, EventArgs e)
        {
            double kur = Convert.ToDouble(txtKur.Text);
            kur = Math.Round(kur, 3);
            double miktar= Convert.ToDouble(txtMiktar.Text);
            miktar= Math.Round(miktar,3);
            double tutar = Convert.ToDouble(miktar / kur);
            tutar = Math.Round(tutar, 3);
            txtTutar.Text= tutar.ToString();
            double kalan;
            kalan = Convert.ToDouble(miktar % tutar);
            kalan = Math.Round(kalan, 3);
            txtKalan.Text=kalan.ToString();
        }
    }
}
