using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl=new FolderBrowserDialog();
            fl.ShowDialog();
            string[] files = System.IO.Directory.GetFiles(fl.SelectedPath, "*.*", System.IO.SearchOption.AllDirectories);

            foreach (var filename in files)
            {
                File.WriteAllText(filename, string.Format("{0}\n{1}", $"#if {textBox1.Text}", File.ReadAllText(filename)));
            }

            foreach (var filename in files)
            {
                File.AppendAllText(filename, string.Format("\n{0}", "#endif"));
            }
        }
    }
}
