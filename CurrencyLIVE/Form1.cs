using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CurrencyLIVE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool loaded = false;
        List<CurrencyRate> currencyList = new List<CurrencyRate>();

        private void Form1_Load(object sender, EventArgs e)
        {
            StaticSQL.SetConnectionString("Server=DESKTOP-6CLE20J\\SQLEXPRESS;Database=CurrencyLIVE;Trusted_Connection=true;");

            XmlReader xmlReader = XmlReader.Create("http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml");
            currencyList = ReadValuesFromXML(xmlReader);
            FillDataBaseWithCurrencies(currencyList);
            dataGridView1.DataSource = currencyList.Select(CurrencyRate => new { CurrencyRate.Date, CurrencyRate.Name, CurrencyRate.Value }).ToList();
            dataGridView1.ClearSelection();
            FillComboBoxes(currencyList);
            loaded = true;
        }

        public List<CurrencyRate> ReadValuesFromXML(XmlReader xmlReader)
        {
            List<CurrencyRate> currencyList = new List<CurrencyRate>();
            DateTime date = new DateTime();
            string name = "";
            decimal value = 0;


            while (xmlReader.Read())
            {
                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Cube"))
                {
                    if (xmlReader.HasAttributes)
                    {
                        name = xmlReader.GetAttribute("currency");
                        if (xmlReader.GetAttribute("time") != null)
                        {
                            date = XMLDateStringToDateTime(xmlReader.GetAttribute("time"));
                        }
                        if (xmlReader.GetAttribute("rate") != null)
                        {

                            value = Decimal.Parse(xmlReader.GetAttribute("rate"));
                        }



                        CurrencyRate currency = new CurrencyRate(date, name, value);
                        currencyList.Add(currency);
                    }
                }
            }
            currencyList.RemoveAt(0);
            return currencyList;
        }

        public DateTime XMLDateStringToDateTime(string date)
        {
            string[] separators = { "-" };
            string[] elements = date.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int year = Int32.Parse(elements[0]);
            int month = Int32.Parse(elements[1]);
            int day = Int32.Parse(elements[2]);
            DateTime datetime = new DateTime(year, month, day);
            return datetime;
        }

        public void FillDataBaseWithCurrencies(List<CurrencyRate> currencyList)
        {
            if (currencyList.First().Date == StaticSQL.GetLatestUpdateDate()) return;

            foreach (CurrencyRate currency in currencyList)
            {
                StaticSQL.InsertCurrencyData(currency);
            }
        }

        public void FillComboBoxes(List<CurrencyRate> currencyList)
        {
            foreach (CurrencyRate currency in currencyList)
            {
                cbCurrencyA.Items.Add(currency.Name);
                cbCurrencyB.Items.Add(currency.Name);
            }
            //cbCurrencyA.DataSource = currencyList; //.Select(CurrencyRate => new { CurrencyRate.Name, CurrencyRate.Value }).ToList();
            //cbCurrencyB.DataSource = currencyList; //.Select(CurrencyRate => new { CurrencyRate.Name, CurrencyRate.Value }).ToList();
        }

        private void cbCurrencyA_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItemIndex = cbCurrencyA.SelectedIndex;
            CurrencyRate item = currencyList.ElementAt(selectedItemIndex);
            tbCurrencyA.Text = item.Value.ToString();
        }

        private void cbCurrencyB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItemIndex = cbCurrencyB.SelectedIndex;
            CurrencyRate item = currencyList.ElementAt(selectedItemIndex);
            tbCurrencyB.Text = item.Value.ToString();
        }

        private void tbCurrencyA_TextChanged(object sender, EventArgs e)
        {
            if (cbCurrencyA.SelectedIndex != -1 && cbCurrencyB.SelectedIndex != -1)
            {
                decimal insertedValue = 0;
                if (decimal.TryParse(tbCurrencyA.Text, out decimal baseAmount))
                {
                    insertedValue = baseAmount;
                }

                int selectedItemIndexA = cbCurrencyA.SelectedIndex;
                CurrencyRate itemA = currencyList.ElementAt(selectedItemIndexA);
                decimal multiplerA = itemA.Value;

                int selectedItemIndexB = cbCurrencyB.SelectedIndex;
                CurrencyRate itemB = currencyList.ElementAt(selectedItemIndexB);
                decimal multiplerB = itemB.Value;

                decimal final = insertedValue * multiplerB / multiplerA;

                tbCurrencyB.Text = final.ToString("#.000");
            }

        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            int tempSelectedIndex = cbCurrencyA.SelectedIndex;
            cbCurrencyA.SelectedIndex = cbCurrencyB.SelectedIndex;
            cbCurrencyB.SelectedIndex = tempSelectedIndex;

            string tempValueText = tbCurrencyA.Text;
            tbCurrencyA.Text = tbCurrencyB.Text;
            tbCurrencyB.Text = tempValueText;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                if (((DataGridView)sender).SelectedRows != null && ((DataGridView)sender).SelectedRows.Count > 0)
                {

                    //chart1.Series.Clear();
                    List<CurrencyRate> currencyList = new List<CurrencyRate>();

                    DataGridViewRow row = ((DataGridView)sender).SelectedRows[0];
                    string name = row.Cells["Name"].Value.ToString();
                    DataTable dt = StaticSQL.GetCurrencyHistoryByName(name);

                    if (!chart1.Series.Any(x => x.Name == name))
                    {
                        chart1.Series.Add(name);
                        chart1.Series[name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                        chart1.Series[name].ToolTip = name;
                    }

                    foreach (DataRow item in dt.Rows)
                    {
                        decimal value = (decimal)item["Value"];
                        DateTime date = (DateTime)item["Date"];
                        chart1.Series[name].Points.AddXY(date, value);
                        //currencyList.Add(item);
                    }
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).SelectedRows != null && ((DataGridView)sender).SelectedRows.Count > 0)
            {
                DataGridViewRow row = ((DataGridView)sender).SelectedRows[0];
                string name = row.Cells["Name"].Value.ToString();

                List<CurrencyRate> currencyList = new List<CurrencyRate>();

                if (chart1.Series.Any(x => x.Name == name))
                {
                    chart1.Series.Remove(chart1.Series[name]);
                }


            }
        }
    }
}
