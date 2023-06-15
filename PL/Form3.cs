using MODEL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public partial class Form3 : Form
    {
        private HttpClient client;
        public Form3()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        List<TbPlayerInMatch> GetPinMatchRed(Match match)
        {
            List<TbPlayerInMatch> list = new List<TbPlayerInMatch>();
            foreach (TbPlayerInMatch r in match.TeamBlue)
            {
                list.Add(r);
            }
            return list;
        }

        List<TbPlayerInMatch> GetPinMatchBlue(Match match)
        {
            List<TbPlayerInMatch> list = new List<TbPlayerInMatch>();
            foreach (TbPlayerInMatch r in match.TeamBlue)
            {
                list.Add(r);
            }
            return list;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var response = await client.GetAsync("https://localhost:7071/api/Match/" + textBox1.Text);
            var jsonM = await response.Content.ReadAsStringAsync();
            Match MatchJson = JsonConvert.DeserializeObject<Match>(jsonM);
            label1.Text = MatchJson.WinsBlue.ToString();
            GetPinMatchRed(MatchJson);
            GetPinMatchBlue(MatchJson);
            dataGridView1.DataSource = GetPinMatchRed(MatchJson);
            dataGridView2.DataSource = GetPinMatchBlue(MatchJson);
            dataGridView1.Refresh();
            dataGridView2.Refresh();
            label1.Refresh();
        }
    }
}
