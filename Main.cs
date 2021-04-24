﻿using System;
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

        // Fichiers à ignorer systématiquement
        static readonly String ignoreStore = ".DS_Store";
        static readonly String ignoreStoreAlt = "._.DS_Store";

        List<String> ignoreFileList = new List<String>() { ".DS_Store", "._.DS_Store", "desktop.ini", "Thumbs.db" };


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

                    // Contrôle si le fichier doit être ignoré
                    if (fileToIgnore(currentFilename, currentFilePath)) {
                        ignored++;
                        continue;
                    }

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
                        // Sinon, copie du fichier
                        SecureCopyFile(currentFilePath, targetDirectory, currentFilename);
                        copied++;
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

        private bool fileToIgnore(String currentFilename, String currentFilePath) {

            // Fichier dans la liste des fichiers à ignorer ?
            if (ignoreFileList.Contains(currentFilename)) { 
                return true; 
            }

            // Fichier temporaire avec image équivalente dans le répertoire
            if (currentFilename.StartsWith("."))
            {
                    String compareFileName = currentFilename[2..];
                    String compareFilePath = Path.GetDirectoryName(currentFilePath) + "\\" + compareFileName;
                    return File.Exists(compareFilePath);

            }


            // Si on arrive ici, le fichier est à prendre en compte
            return false;
        }

        private void SecureCopyFile(String sourcePath, String targetPath, String filename) {

            String definitiveCopyPath = targetPath + "\\" + filename;

            if (! Directory.Exists(targetPath)) {
                Directory.CreateDirectory(targetPath);
            }

            File.Copy(sourcePath, definitiveCopyPath);
        }


        // This method accepts two strings the represent two files to
        // compare. A return value of 0 indicates that the contents of the files
        // are the same. A return value of any other value indicates that the
        // files are not the same.
        private bool FileCompare(string file1, string file2)
        {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            // Determine if the same file was referenced two times.
            if (file1 == file2)
            {
                // Return true to indicate that the files are the same.
                return true;
            }

            // Open the two files.
            fs1 = new FileStream(file1, FileMode.Open);
            fs2 = new FileStream(file2, FileMode.Open);

            // Check the file sizes. If they are not the same, the files
            // are not the same.
            if (fs1.Length != fs2.Length)
            {
                // Close the file
                fs1.Close();
                fs2.Close();

                // Return false to indicate files are different
                return false;
            }

            // Read and compare a byte from each file until either a
            // non-matching set of bytes is found or until the end of
            // file1 is reached.
            do
            {
                // Read one byte from each file.
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));

            // Close the files.
            fs1.Close();
            fs2.Close();

            // Return the success of the comparison. "file1byte" is
            // equal to "file2byte" at this point only if the files are
            // the same.
            return ((file1byte - file2byte) == 0);
        }

    }
}
