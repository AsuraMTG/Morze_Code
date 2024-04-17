using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public Dictionary<char, string> szotar = new Dictionary<char, string>();
        private void button1_Click(object sender, EventArgs e)
        {
            FileStream folyam = new FileStream("morzeabc.txt", FileMode.Open);
            StreamReader olvas = new StreamReader(folyam);
            olvas.ReadLine();
            Dictionary<char, string> szotar = new Dictionary<char, string>();
            string elso = olvas.ReadLine();
            string[] resz;

            while (!olvas.EndOfStream) 
            {
                resz = elso.Split('\t');
                if (!szotar.ContainsKey(Convert.ToChar(resz[0])))
                {
                    szotar.Add((Convert.ToChar(resz[0])), resz[1]); 
                }
                elso = olvas.ReadLine();
            }
            folyam.Close();

            FileStream folyam1 = new FileStream("morze.txt", FileMode.Open);
            StreamReader olvas1 = new StreamReader(folyam1);
            List<string> sor = new List<string>();
            while (!olvas1.EndOfStream)
            {
                elso = olvas1.ReadLine();
                sor.Add(elso);
            }
            folyam1.Close();

            string teszt = sor.ElementAt(0);
            teszt = teszt.Replace("       ","/");
            teszt = teszt.Replace("   "," ");
            //label1.Text = teszt + "\n";
            string[] ketto = teszt.Split(';');
            string[] szerzokb = ketto[0].Split(' ');
            for (int i = 0; i < szerzokb.Length; i++)
            {
                foreach (KeyValuePair<char, string> x in szotar)
                {
                    if (x.Value == szerzokb[i])
                    {
                        label1.Text += x.Key; 
                    }
                }
            }
        }
    }
}
