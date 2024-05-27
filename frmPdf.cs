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
using PdfiumViewer;

namespace SDD2
{
    public partial class frmPdf : Form
    {
        PdfiumViewer.PdfViewer pdf;
        public frmPdf(string filePath)
       
        {
            InitializeComponent();
            pdf = new PdfiumViewer.PdfViewer();
            this.Controls.Add(pdf);
            openfile(filePath);
        }
        private PdfDocument OpenDocument(string fileName)
        {
            try
            {
                return PdfDocument.Load(this, fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public void openfile(string filepath)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(filepath);
            var stream = new MemoryStream(bytes);
            PdfiumViewer.PdfDocument pdfDocument = PdfiumViewer.PdfDocument.Load(stream);
            pdf.Document = pdfDocument;
        }

        private void frmPdf_Load(object sender, EventArgs e)
        {

        }
    }
}
