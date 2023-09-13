using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        TesteThread teste;
        public Boolean _isRun = false;
        ThreadStart testeRun;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            teste = new TesteThread(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {

          
           // testeRun = new ThreadStart(delegate { teste.WriteTextSafe("Modificando o label."); });
            //testeRun.Start();

            //var threadParameters = new System.Threading.ThreadStart(delegate { teste.WriteTextSafe("This text was set safely."); });
            var thread2  = new Thread(it => teste.Schedule());
            thread2.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (teste._isRun == false)
            {
                teste._isRun = true;
            }
            else {
                teste._isRun = false;
            }
        }
    }
}
