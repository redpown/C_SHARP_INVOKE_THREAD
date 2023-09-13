using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class TesteThread : IDisposable
    {
        private Form1 Formulario;
        private bool IsRunning;
        public bool _isRun;
        public TesteThread(Form1 Formulario)
        {
            IsRunning = true;
            this.Formulario = Formulario;
            //processor = new GhostscriptProcessor();
        }
        public void Dispose()
        {
            IsRunning = false;
        }
        //public void Looping()
        //{
        //    try
        //    {
        //        if (Formulario.label1.InvokeRequired)
        //        {
        //            // Call this same method but append THREAD2 to the text
        //            Action safeWrite = delegate { WriteTextSafe($"{text} (THREAD2)"); };
        //            Formulario.label1.Invoke(safeWrite);

        //           // Formulario.label1.Text = "0000000000001";
        //        }
        //        //Formulario.Text = "0000000000009";

        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        public void Schedule() {
            int I = 0;
            while (_isRun) {
                Thread.Sleep(1000);
                PopulateListView(I);
                Thread.Sleep(5000);
                I++;
            }
        }
        public void WriteTextSafe(string text)
        {
        
            if (Formulario.label1.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action safeWrite = delegate { WriteTextSafe(text); };
                //Formulario.label1.Text = "Modificando o label";
                Formulario.label1.Invoke(safeWrite);

            }
            else
            {
              
                Formulario.label1.Text = "iniciado o processo";
                Formulario.Text = "Processando";

                // Add the pet to our listview
                string[] row = { "1", DateTime.Now.ToString() };
                var listViewItem = new ListViewItem(row);



                Formulario.listView1.Items.Add(listViewItem);


            }
        }

        public void PopulateListView(int C)
        {

            if (Formulario.listView1.InvokeRequired)
            {
                // Call this same method but append THREAD2 to the text
                Action PopulateList = delegate { PopulateListView(C); };
                //Formulario.label1.Text = "Modificando o label";
                Formulario.listView1.Invoke(PopulateList);

            }
            else
            {

                // Add the pet to our listview
                string[] row = { C.ToString(), DateTime.Now.ToString() };
                var listViewItem = new ListViewItem(row);

                Formulario.listView1.Items.Add(listViewItem);


            }
        }

    }
}
