using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppNotatnik
{
    public partial class Form1 : Form
    {
        

        private const String MyFilter = "Plik tekstowy|*.txt|Skrypty|*.bat|Wszystkie pliki|*.*";

        private String myFileName = "";
        private Boolean textEdited = true;

        public String MyFileName
        {
            get
            {
                return myFileName;
            }
            set
            {
                myFileName = value;
                SetInfo();
            }
        }
        public bool TextEdited
        {
            get
            {
                return textEdited;
            }
            set
            {
                textEdited = value;
                SetInfo();
            }
        }

        void SetInfo()
        {
            if (MyFileName == "")
            {
                this.Text = "Nowy plik";
            }
            else
            {
                this.Text = Path.GetFileName(MyFileName);
            }
            if (TextEdited)
            {
                this.Text += " *";
            }
        }
        public Form1()
        {
            InitializeComponent();
            SetInfo();
            
        }

        private void NowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textEdited)
            {
                DialogResult result = MessageBox.Show("Czy chcesz zapisac zanim otworzysz nowy", "zapisano");
                if(result == DialogResult.Yes)
                {
                    zapiszJakoToolStripMenuItem_Click(sender, e);
                }
                return;
            }
            richTextBox1.Text = "";
        }


        private void otworzToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (textEdited)
            {
                DialogResult result = MessageBox.Show("Czy chcesz zapisac zmiany?", "Plik został zapisany");
                if (result == DialogResult.Yes)
                {
                    zapiszJakoToolStripMenuItem_Click(sender, e);
                }
                return;
            }
            OpenFileDialog OFDialog = new OpenFileDialog();
            OFDialog.Filter = MyFilter; // OFDialog.Filter = "Plik tekstowy|*.txt";
            if (OFDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(OFDialog.FileName);
                MyFileName = OFDialog.FileName;
                TextEdited = false;
            }
        }

        private void zapiszToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MyFileName == "")
            {
                zapiszJakoToolStripMenuItem_Click(sender, e);
            }
            else
            {
                File.WriteAllText(MyFileName, richTextBox1.Text);
                TextEdited = false;
            }
        }

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFDialog = new SaveFileDialog();
            SFDialog.Filter = MyFilter;
            if (SFDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(SFDialog.FileName, richTextBox1.Text);
                MyFileName = SFDialog.FileName;
                TextEdited = false;
            }
        }

        private void zamknijToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Close();
            //Application.Exit();
        }

        private void koToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConfig fc = new FormConfig();
            //fc.Show(); można przechodzić miedzy oknami, można wyświetlić okien dialogowych wiele okien
            // DialogResult rs = fc.ShowDialog();
            fc.ConfigHintColor = richTextBox1.ForeColor;
            fc.ConfigBackColor = richTextBox1.BackColor;
            fc.ConfigFont = richTextBox1.Font;

            if (fc.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Zmieniono ustawienia");
                richTextBox1.BackColor = fc.ConfigBackColor;
                richTextBox1.ForeColor = fc.ConfigHintColor;
                richTextBox1.Font = fc.ConfigFont;
                
            }
        }

        
    }
}
