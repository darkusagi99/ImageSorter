using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageSorter
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void textBoxSrc_TextChanged(object sender, EventArgs e)
        {

        }

        private void sourceDirBtn_Click(object sender, EventArgs e)
        {
            // Ouverture fenetre dialogue
            DialogResult dialogResult = folderBrowserDialogSrc.ShowDialog();

            // Si OK, MAJ de la valeur
            if (dialogResult.Equals(DialogResult.OK)) {
                textBoxSrc.Text = folderBrowserDialogSrc.SelectedPath;
            }
        }

        private void buttonDirTarget_Click(object sender, EventArgs e)
        {
            // Ouverture de la fenetre dialogue
            DialogResult dialogResult = folderBrowserDialogTarget.ShowDialog();

            // Si OK, MAJ de la valeur
            if (dialogResult.Equals(DialogResult.OK))
            {
                textBoxTarget.Text = folderBrowserDialogTarget.SelectedPath;
            }
        }

        private void textBoxTarget_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
