using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test1;
using DynaCode;
//using Test1; 


namespace TorqueApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            float r, f, t;
            string key;
            r = float.Parse(textBox1.Text);
            f = float.Parse(textBox2.Text);
            t = float.Parse(textBox3.Text);
            key = textBox4.Text;
            //Test1.Class1 obj = new Test1.Class1();
            //textBox4.Text = (obj.torque(r, f, t).ToString());
            DynaCode.Program obj = new DynaCode.Program();
            textBox4.Text = (obj.Main(r, f, t, "dolbydotiodolbyiodolbydotiodolby").ToString());
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
