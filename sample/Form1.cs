using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Xml.Linq;
using System.IO;

namespace sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Time", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Class", typeof(string));
            dt.Columns.Add("Started", typeof(string));
            dt.Columns.Add("Fee", typeof(string));
            Label[] lbl = {label1,label2,label3,label4,label5};
            Label[] lbl1 = { label6, label7, label8, label9, label10 };

            string uri = string.Format("..\\record.xml");
            XDocument doc = XDocument.Load(uri);

            foreach (var npc in doc.Descendants("time"))
            {
                string aa = (string)npc.Attribute("from");
                string a = (string)npc.Descendants("student").First().Attribute("name");
                string b = (string)npc.Descendants("student").First().Attribute("class");
                string c = (string)npc.Descendants("student").First().Attribute("started_month");
                string d = (string)npc.Descendants("student").First().Attribute("fee");

                {
                    dt.Rows.Add(new object[]
                  {
                      aa, a, b, c,d,
                  });

                }

              for (int i = 0; i < 5; i++)
                {

                   lbl[i].Text = b;
                    lbl1[i].Text = a;

                }
            }
            dataGridView1.DataSource = dt;

        }
    }
}
