using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using MODEL;
using Newtonsoft.Json;
using System.Text.Json;
using System.Collections;


namespace PL
{
    public partial class Form2 : Form
    {
        private HttpClient client;

        public Form2()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        List<TbPlayer> GetPlayer(TbPlayer tbPlayer)
        {
            List<TbPlayer> list = new List<TbPlayer>();
            list.Add(tbPlayer);
            return list;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var response = await client.GetAsync("https://localhost:7071/api/Player/ById/" + textBox1.Text);
            var jsonP = await response.Content.ReadAsStringAsync();
            TbPlayer tbPlayerJson = JsonConvert.DeserializeObject<TbPlayer>(jsonP);
            GetPlayer(tbPlayerJson);
            dataGridView1.DataSource = GetPlayer(tbPlayerJson);
            dataGridView1.Refresh();
        }

        private void Form2_load(object sender, EventArgs e)
        {

        }


    }



}

