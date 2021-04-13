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

        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            // Méthode principale du tri des photos

            // Contrôle des paramètres (les deux arborescences ne doivent pas se chevaucher) - Si c'est le cas : message d'erreur et arrêt
            

            // Boucle sur l'ensemble des fichiers de l'arborescence

            // Pour chaque fichier :
            // Si fichier image -> Contrôle de ses métadonnées et copie
            // Si pas de métadonnées lisibles --> Copie dans un autre répertoire

            // Si fichier doublon -> Logs et pas de copie

            // Si fichier cache -> Confirmation cache (contrôle fichier source) et pas de copie


        }
    }
}
