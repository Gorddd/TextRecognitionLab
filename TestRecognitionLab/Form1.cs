using IronOcr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestRecognitionLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            pictureBox1.Image = Image.FromFile(openFileDialog.FileName);

            ProcessImage(openFileDialog.FileName);
        }

        private void ProcessImage(string fileName)
        {
            var ocr = new IronTesseract();
            ocr.Language = OcrLanguage.English;
            ocr.Configuration.TesseractVersion = TesseractVersion.Tesseract5;

            using (var Input = new OcrInput())
            {
                Input.AddImage(fileName);
                var result = ocr.Read(Input);
                textBox1.Text = result.Text;
            }
        }
    }
}
