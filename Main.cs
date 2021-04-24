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

        // Compteurs pour l'affichage du contenu
        int total = 0;
        int processed = 0;
        int copied = 0;
        int duplicate = 0;
        int ignored = 0;


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

                // Initialisation des compteurs
                total = fileList.Length;
                processed = 0;
                copied = 0;
                duplicate = 0;
                ignored = 0;

                foreach (String currentFilePath in fileList) {

                    // Affichage de chaque fichier traité
                    buildBoxLogs();

                    // Pour chaque fichier :
                    ShellFile currentFile = ShellFile.FromFilePath(currentFilePath);
                    String currentFilename = Path.GetFileName(currentFilePath);

                    // Si fichier image -> Contrôle de ses métadonnées et copie
                    // Si pas de métadonnées lisibles --> Copie dans un autre répertoire (celui de default date)
                    DateTime currentDate = currentFile.Properties.System.Photo.DateTaken.Value.GetValueOrDefault(defaultDate);

                    // Mise en place du chemin de copie et contrôles.

                    String targetDirectory = textBoxTarget.Text + "\\"
                            + currentDate.Year.ToString() + "\\"
                            + currentDate.Month.ToString() + "\\"
                            + currentDate.Day.ToString();
                    String targetPath = targetDirectory + "\\" + currentFilename;

                    if (File.Exists(targetPath)) {

                        // TODO - Si fichier doublon -> Logs et pas de copie
                        // TODO - Si pas fichier doublon -> Changer le nom et copier 
                        duplicate++;
                    }
                    else
                    {

                        // TODO - Si fichier cache -> Confirmation cache (contrôle fichier source) et pas de copie
                        if (currentFilename.StartsWith(".")) {
                            String compareFileName = currentFilename[3..];
                            String compareFilePath = Path.GetDirectoryName(currentFilePath) + "\\" + compareFileName;

                            if (!File.Exists(compareFilePath))
                            {
                                secureCopyFile(currentFilePath, targetDirectory, currentFilename);
                                copied++;
                            }
                            else {
                                ignored++;
                            }

                        } else {
                            // Sinon, copie du fichier
                            secureCopyFile(currentFilePath, targetDirectory, currentFilename);
                            copied++;
                        }
                    }

                    // Incrément de compteur
                    processed++;
                }

            }
        }

        private void textBoxLogs_TextChanged(object sender, EventArgs e)
        {

        }

        private void buildBoxLogs() {
            String logEntry = "Total : " + total + Environment.NewLine +
                "Traités : " + processed + Environment.NewLine +
                "Copiés : " + copied + Environment.NewLine +
                "Doublon : " + duplicate + Environment.NewLine +
                "Ignorés : " + ignored + Environment.NewLine;

            textBoxLogs.Text = logEntry;
            textBoxLogs.Update();

        }

        private void secureCopyFile(String sourcePath, String targetPath, String filename) {

            String definitiveCopyPath = targetPath + "\\" + filename;

            if (! Directory.Exists(targetPath)) {
                Directory.CreateDirectory(targetPath);
            }

            File.Copy(sourcePath, definitiveCopyPath);
        }

    }
}
