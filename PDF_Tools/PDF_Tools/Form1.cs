using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf.IO;
using PdfSharpCore.Pdf;
using System.Windows.Forms;
using PDF_Tools.Properties;
using PdfSharpCore.Internal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;

namespace PDF_Tools
{
    public partial class Form1 : Form
    {
        private bool inProcess = false;
        private Image imageDormant = Resources.icons8_add_to_collection_static;
        private Image imageActive = Resources.icons8_add_to_collection;

        public Form1()
        {
            InitializeComponent();
            //ImageAnimator.Animate(pictureBox3, new EventHandler(OnFrameChanged));

        }

        private void OnFrameChanged(object o, EventArgs e)
        {
            //Update the frames of the animation
            ImageAnimator.UpdateFrames();

            //Invalidate the PictureBox to redraw the image
            //pictureBoxGif.Invalidate();
        }

        private void buttonFile1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button x = (System.Windows.Forms.Button)sender;
            textBoxFile1.Text = SelectFile(x.Text);
        }

        private void buttonFile2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button x = (System.Windows.Forms.Button)sender;
            textBoxFile2.Text = SelectFile(x.Text);
        }

        private string SelectFile(string senderName)
        {
            var filePath = string.Empty;
            using (OpenFileDialog selectFileDialog = new OpenFileDialog())
            {
                string title = "";
                switch (senderName)
                {
                    case "File 1":
                        title = "Select the 1st file to appear in the merged file";
                        break;
                    case "File 2":
                        title = "Select the file to append on the end of the merged file";
                        break;
                }
                selectFileDialog.InitialDirectory = "c:\\";
                selectFileDialog.Title = title;
                selectFileDialog.Filter = "pdf files|*.pdf";
                selectFileDialog.FilterIndex = 2;
                selectFileDialog.RestoreDirectory = true;



                if (selectFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of the specified file
                    filePath = selectFileDialog.FileName;

                   // return filePath;
                }
            }
            return filePath;
        }

        private string SelectFolder(string senderName)
        {
            var filePath = string.Empty;
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "pdf files|*.pdf";
                saveFileDialog.AddExtension = true;
                saveFileDialog.Title = senderName;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of the specified file
                    filePath = saveFileDialog.FileName;

                    //return filePath;
                }

            }
            //using (FolderBrowserDialog selectFolderDialog = new FolderBrowserDialog())
            //{
            //    string title = "";
            //   selectFolderDialog.UseDescriptionForTitle = true;
            //    selectFolderDialog.Description = title;
            //    selectFolderDialog.InitialDirectory = "c:\\";
           




            //    if (selectFolderDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        // Get the path of the specified file
            //        filePath = selectFolderDialog.SelectedPath;

            //        return filePath;
            //    }
            //}
            return filePath;
        }

        private void buttonMerge_Click(object sender, EventArgs e)
        {
            string File1Name = Path.GetFileNameWithoutExtension(textBoxFile1.Text);
            string File2Name = Path.GetFileNameWithoutExtension(textBoxFile2.Text);
            PdfDocument inputDocument1 = PdfReader.Open(textBoxFile1.Text, PdfDocumentOpenMode.Import);
            PdfDocument inputDocument2 = PdfReader.Open(textBoxFile2.Text, PdfDocumentOpenMode.Import);
            int pageCount = inputDocument1.PageCount + inputDocument2.PageCount;
            progressBar1.Maximum = pageCount;
            //decimal pageIncrement = 1 / pageCount;
            // Create the output document
            PdfDocument outputDocument = new PdfDocument();

            // Show consecutive pages facing. Requires Acrobat 5 or higher.
            outputDocument.PageLayout = PdfPageLayout.TwoColumnLeft;

            /* XFont font = new XFont("Verdana", 10, XFontStyle.Bold);
            XStringFormat format = new XStringFormat();
            format.Alignment = XStringAlignment.Center;
            format.LineAlignment = XLineAlignment.Far; */
            // XGraphics gfx;
            // XRect box;
            int count = inputDocument1.PageCount;
            for (int idx = 0; idx < count; idx++)
            {
                PdfPage page = inputDocument1.Pages[idx];
                //progressBar1.Value = (int)Math.Round((idx + 1) * pageIncrement * 100, 0);
                progressBar1.Increment(1);
                page = outputDocument.AddPage(page);

            }
            int count2 = inputDocument2.PageCount;
            for (int idx = 0; idx < count2; idx++)
            {
                PdfPage page = inputDocument2.Pages[idx];
                progressBar1.Increment(1);
                //progressBar1.Value = (int)Math.Round((count + idx + 1) * pageIncrement * 100, 0);
                page = outputDocument.AddPage(page);
                
            }


            /* int count = Math.Max(inputDocument1.PageCount, inputDocument2.PageCount);
            for (int idx = 0; idx < count; idx++)
            {
                // Get page from 1st document
                PdfPage page1 = inputDocument1.PageCount > idx ?
                  inputDocument1.Pages[idx] : new PdfPage();

                // Get page from 2nd document
                PdfPage page2 = inputDocument2.PageCount > idx ?
                  inputDocument2.Pages[idx] : new PdfPage();

                // Add both pages to the output document
                page1 = outputDocument.AddPage(page1);
                page2 = outputDocument.AddPage(page2);
            */
            // Write document file name and page number on each page
            /* gfx = XGraphics.FromPdfPage(page1);
             box = page1.MediaBox.ToXRect();
             box.Inflate(0, -10);
             gfx.DrawString(String.Format("{0} • {1}", textBoxFile1.Text, idx + 1),
               font, XBrushes.Red, box, format);

             gfx = XGraphics.FromPdfPage(page2);
             box = page2.MediaBox.ToXRect();
             box.Inflate(0, -10);
             gfx.DrawString(String.Format("{0} • {1}", textBoxFile2.Text, idx + 1),
               font, XBrushes.Red, box, format);

         }*/

            // Save the document...
            string filename = textBoxDestination.Text;
            outputDocument.Save(filename);
            MessageBox.Show("Process has completed");
            progressBar1.Value = 0;
        }

        private void textBoxFile1_TextChanged(object sender, EventArgs e)
        {
            validateFiles();
        }

        private void textBoxFile2_TextChanged(object sender, EventArgs e)
        {
            validateFiles();
        }

        private void buttonDestination_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button x = (System.Windows.Forms.Button)sender;
            textBoxDestination.Text = SelectFolder(x.Text);
        }

        private void textBoxDestination_TextChanged(object sender, EventArgs e)
        {
            validateFiles();
        }

        private void validateFiles()
        {
            bool file1Exists = Path.Exists(textBoxFile1.Text);
            bool file2Exists = Path.Exists(textBoxFile2.Text);
            bool fileDestinationIsNew = !Path.Exists(textBoxDestination.Text);
            bool fileDesinationIsPdf = Path.GetExtension(textBoxDestination.Text).Equals(".pdf");
            buttonMerge.Enabled = (file1Exists && file2Exists && fileDestinationIsNew && fileDesinationIsPdf);
        }

        //private void pictureBox3_Click(object sender, EventArgs e)
        //{
        //    pictureBox3.Image = inProcess ? imageActive : imageDormant;
        //    inProcess = !inProcess;
        //    return;
        //}

        //private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        //{

        //        // Open the input files
        //        PdfDocument inputDocument1 = PdfReader.Open(textBoxFile1.Text, PdfDocumentOpenMode.Import);
        //        PdfDocument inputDocument2 = PdfReader.Open(textBoxFile2.Text, PdfDocumentOpenMode.Import);
        //    decimal pageCount = inputDocument1.PageCount + inputDocument2.PageCount;
        //    decimal     pageIncrement = 1/ pageCount;
        //        // Create the output document
        //        PdfDocument outputDocument = new PdfDocument();

        //        // Show consecutive pages facing. Requires Acrobat 5 or higher.
        //        outputDocument.PageLayout = PdfPageLayout.TwoColumnLeft;

        //        /* XFont font = new XFont("Verdana", 10, XFontStyle.Bold);
        //        XStringFormat format = new XStringFormat();
        //        format.Alignment = XStringAlignment.Center;
        //        format.LineAlignment = XLineAlignment.Far; */
        //        // XGraphics gfx;
        //        // XRect box;
        //        int count = inputDocument1.PageCount;
        //        for (int idx = 0; idx < count; idx++)
        //        {
        //            PdfPage page = inputDocument1.Pages[idx];
        //            page = outputDocument.AddPage(page);
        //        progressBar1.Value = (int)Math.Round((idx+1) * pageIncrement * 100,0);
        //        }
        //        int count2 = inputDocument2.PageCount;
        //        for (int idx = 0; idx < count2; idx++)
        //        {
        //            PdfPage page = inputDocument2.Pages[idx];
        //            page = outputDocument.AddPage(page);
        //        progressBar1.Value = (int)Math.Round((count + idx+1) * pageIncrement * 100, 0);
        //    }


        //        /* int count = Math.Max(inputDocument1.PageCount, inputDocument2.PageCount);
        //        for (int idx = 0; idx < count; idx++)
        //        {
        //            // Get page from 1st document
        //            PdfPage page1 = inputDocument1.PageCount > idx ?
        //              inputDocument1.Pages[idx] : new PdfPage();

        //            // Get page from 2nd document
        //            PdfPage page2 = inputDocument2.PageCount > idx ?
        //              inputDocument2.Pages[idx] : new PdfPage();

        //            // Add both pages to the output document
        //            page1 = outputDocument.AddPage(page1);
        //            page2 = outputDocument.AddPage(page2);
        //        */
        //        // Write document file name and page number on each page
        //        /* gfx = XGraphics.FromPdfPage(page1);
        //         box = page1.MediaBox.ToXRect();
        //         box.Inflate(0, -10);
        //         gfx.DrawString(String.Format("{0} • {1}", textBoxFile1.Text, idx + 1),
        //           font, XBrushes.Red, box, format);

        //         gfx = XGraphics.FromPdfPage(page2);
        //         box = page2.MediaBox.ToXRect();
        //         box.Inflate(0, -10);
        //         gfx.DrawString(String.Format("{0} • {1}", textBoxFile2.Text, idx + 1),
        //           font, XBrushes.Red, box, format);

        //     }*/

        //        // Save the document...
        //        const string filename = "CompareDocument1_tempfile.pdf";
        //        outputDocument.Save(filename);
        //        //System.Threading.Thread.Sleep(5000);

        //}

        //private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        //{
        //    SetPictureAnimation(false);
        //    MessageBox.Show("Process has completed");
        //}
    }
}
