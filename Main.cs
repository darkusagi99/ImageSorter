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
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;

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
            if (!Directory.Exists(textBoxTarget.Text) ||
                !Directory.Exists(textBoxSrc.Text) ||
                textBoxSrc.Text.Contains(textBoxTarget.Text) ||
                textBoxTarget.Text.Contains(textBoxSrc.Text)
                )
            {
                // Affichage d'un message d'erreur
                MessageBox.Show("Les répertoires sélectionnés ne sont pas valides", "Caption", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {

                // Boucle sur l'ensemble des fichiers de l'arborescence
                String[] fileList = Directory.GetFiles(textBoxSrc.Text, "*", SearchOption.AllDirectories);

                // Mise en place d'une date par défaut
                DateTime defaultDate = new DateTime(1900, 01, 01);

                foreach(String currentFilePath in fileList) {

                    // Affichage de chaque fichier traité
                    textBoxLogs.AppendText(Environment.NewLine);
                    textBoxLogs.AppendText(currentFilePath);

                    // Pour chaque fichier :
                    ShellFile currentFile = ShellFile.FromFilePath(currentFilePath);
                    String currentFilename = Path.GetFileName(currentFilePath);

                    // Si fichier image -> Contrôle de ses métadonnées et copie
                    // Si pas de métadonnées lisibles --> Copie dans un autre répertoire (celui de default date)
                    DateTime currentDate = currentFile.Properties.System.Photo.DateTaken.Value.GetValueOrDefault(defaultDate);

                    // Mise en place du chemin de copie et contrôles.
                    String targetPath = textBoxTarget.Text + "\\" 
                            + currentDate.Year.ToString() + "\\"
                            + currentDate.Month.ToString() + "\\"
                            + currentDate.Day.ToString() + "\\"
                            + currentFilename;

                    if (File.Exists(targetPath)) {

                        // TODO - Si fichier doublon -> Logs et pas de copie
                        // TODO - Si pas fichier doublon -> Changer le nom et copier 
                    }
                    else
                    {

                        // TODO - Si fichier cache -> Confirmation cache (contrôle fichier source) et pas de copie
                        if (currentFilename.StartsWith(".")) {
                            String compareFileName = currentFilename.Substring(2);
                            String compareFilePath = "";

                            File.Exists(compareFilePath);

                        } else {
                            // TODO - Sinon, copie du fichier
                            File.Copy(currentFilePath, targetPath);
                        }
                    }


                }

            }
        }

        private void textBoxLogs_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
