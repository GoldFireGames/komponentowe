using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppNotatnik
{
    public partial class FormConfig : Form
    {
        public Color ConfigBackColor
        {
            get
            {
                return buttonBackGround.BackColor;
            }
            set
            {
                buttonBackGround.BackColor = value;
            }
        }

        public Color ConfigHintColor
        {
            get
            {
                return buttonHintColor.ForeColor;
            }
            set
            {
                buttonHintColor.BackColor = value;
            }
        }
        public Font ConfigFont
        {
            get
            {
                return buttonFont.Font;
            }
            set
            {
                buttonFont.Font = value;
            }
        }

        public FormConfig()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void buttonBackGround_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if(colorDialog.ShowDialog() == DialogResult.OK){

                buttonBackGround.BackColor = colorDialog.Color;
            }
       }

        private void buttonHintColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {

                buttonHintColor.ForeColor = colorDialog.Color;

            }
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if(fontDialog.ShowDialog() == DialogResult.OK)
            {
                buttonFont.Text = $"{fontDialog.Font.Name},{fontDialog.Font.Size} ";
                buttonFont.Font = fontDialog.Font;
            }
        }
    }
}
