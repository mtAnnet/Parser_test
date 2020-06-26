using Parser.Core;
using Parser.Core.Inspections;
using System;
using System.Windows.Forms;

namespace Parser
{
    public partial class Form1 : Form
    {
        ParserWorker<string[]> parser;
        

        public Form1()
        {
            InitializeComponent();
            parser = new ParserWorker<string[]>(new InspectionsParser());
            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
           
            
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            listBox1.Items.AddRange(arg2);
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("Done");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parser.Settings = new InspectionsSettings((int)numericStart.Value, (int)numericEnd.Value);
            parser.Start();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parser.Abort();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://inspections.gov.ua" + listBox1.SelectedItem);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("G:\\Links.csv"))
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                    sw.WriteLine("https://inspections.gov.ua" + listBox1.Items[i].ToString());
            }
        }
    }
}
