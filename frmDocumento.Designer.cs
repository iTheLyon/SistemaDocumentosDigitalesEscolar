using System.Drawing;
using System.Windows.Forms;

namespace SDD2
{
    partial class frmDocumento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNombreArchivo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAdjuntar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTiposDocumentos = new System.Windows.Forms.ComboBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.cboAnos = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboNiveles = new System.Windows.Forms.ComboBox();
            this.cboGrados = new System.Windows.Forms.ComboBox();
            this.cboSecciones = new System.Windows.Forms.ComboBox();
            this.cboTurnos = new System.Windows.Forms.ComboBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.btnRotar = new System.Windows.Forms.Button();
            this.pdfViewer2 = new PdfiumViewer.PdfViewer();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo Doc.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Titulo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Año";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 374);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Observaciones";
            // 
            // lblNombreArchivo
            // 
            this.lblNombreArchivo.AutoSize = true;
            this.lblNombreArchivo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreArchivo.Location = new System.Drawing.Point(22, 353);
            this.lblNombreArchivo.Name = "lblNombreArchivo";
            this.lblNombreArchivo.Size = new System.Drawing.Size(116, 17);
            this.lblNombreArchivo.TabIndex = 5;
            this.lblNombreArchivo.Text = "[NombreArchivo]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 22);
            this.label7.TabIndex = 6;
            this.label7.Text = "Archivo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(25, 275);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 22);
            this.label8.TabIndex = 7;
            this.label8.Text = "Turno";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(25, 237);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 22);
            this.label9.TabIndex = 8;
            this.label9.Text = "Sección";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(25, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 22);
            this.label10.TabIndex = 9;
            this.label10.Text = "Grado";
            // 
            // btnAdjuntar
            // 
            this.btnAdjuntar.BackColor = System.Drawing.Color.MediumBlue;
            this.btnAdjuntar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdjuntar.ForeColor = System.Drawing.Color.White;
            this.btnAdjuntar.Location = new System.Drawing.Point(108, 320);
            this.btnAdjuntar.Name = "btnAdjuntar";
            this.btnAdjuntar.Size = new System.Drawing.Size(104, 30);
            this.btnAdjuntar.TabIndex = 11;
            this.btnAdjuntar.Text = "Adjuntar";
            this.btnAdjuntar.UseVisualStyleBackColor = false;
            this.btnAdjuntar.Click += new System.EventHandler(this.btnAdjuntar_Click_1);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGrabar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.ForeColor = System.Drawing.Color.White;
            this.btnGrabar.Location = new System.Drawing.Point(77, 464);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(110, 42);
            this.btnGrabar.TabIndex = 12;
            this.btnGrabar.Text = "Guardar";
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.OrangeRed;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(223, 464);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 42);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(420, 32);
            this.label4.TabIndex = 14;
            this.label4.Text = "Registro de Documento Digital";
            // 
            // cboTiposDocumentos
            // 
            this.cboTiposDocumentos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTiposDocumentos.FormattingEnabled = true;
            this.cboTiposDocumentos.Items.AddRange(new object[] {
            "ACTA CONSOLIDADA",
            "FICHA MATRICULA",
            "CONSTANCIA DE ESTUDIO",
            "OTROS"});
            this.cboTiposDocumentos.Location = new System.Drawing.Point(109, 60);
            this.cboTiposDocumentos.Name = "cboTiposDocumentos";
            this.cboTiposDocumentos.Size = new System.Drawing.Size(261, 26);
            this.cboTiposDocumentos.TabIndex = 15;
            this.cboTiposDocumentos.Text = "ACTA CONSOLIDADA";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.Location = new System.Drawing.Point(108, 89);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(262, 26);
            this.txtTitulo.TabIndex = 16;
            // 
            // cboAnos
            // 
            this.cboAnos.DropDownHeight = 100;
            this.cboAnos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboAnos.FormattingEnabled = true;
            this.cboAnos.IntegralHeight = false;
            this.cboAnos.Items.AddRange(new object[] {
            "1979",
            "1980",
            "1981",
            "1982",
            "1983",
            "1984",
            "1985",
            "1986",
            "1987",
            "1988",
            "1989",
            "1990",
            "1991",
            "1992",
            "1993",
            "1994",
            "1995",
            "1996",
            "1997",
            "1998",
            "1999",
            "2000",
            "2001",
            "2002",
            "2003",
            "2004",
            "2005",
            "2006",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022"});
            this.cboAnos.Location = new System.Drawing.Point(108, 121);
            this.cboAnos.Name = "cboAnos";
            this.cboAnos.Size = new System.Drawing.Size(261, 26);
            this.cboAnos.TabIndex = 17;
            this.cboAnos.Text = "1979";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 22);
            this.label6.TabIndex = 18;
            this.label6.Text = "Nivel";
            // 
            // cboNiveles
            // 
            this.cboNiveles.Enabled = false;
            this.cboNiveles.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNiveles.FormattingEnabled = true;
            this.cboNiveles.Items.AddRange(new object[] {
            "INICIAL",
            "PRIMARIA",
            "SECUNDARIA"});
            this.cboNiveles.Location = new System.Drawing.Point(108, 160);
            this.cboNiveles.Name = "cboNiveles";
            this.cboNiveles.Size = new System.Drawing.Size(261, 26);
            this.cboNiveles.TabIndex = 19;
            this.cboNiveles.Text = "SECUNDARIA";
            // 
            // cboGrados
            // 
            this.cboGrados.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGrados.FormattingEnabled = true;
            this.cboGrados.Items.AddRange(new object[] {
            "1° ERO",
            "2° DO",
            "3° ERO",
            "4° TO",
            "5° TO"});
            this.cboGrados.Location = new System.Drawing.Point(108, 198);
            this.cboGrados.Name = "cboGrados";
            this.cboGrados.Size = new System.Drawing.Size(261, 26);
            this.cboGrados.TabIndex = 20;
            this.cboGrados.Text = "1° ERO";
            // 
            // cboSecciones
            // 
            this.cboSecciones.DropDownHeight = 85;
            this.cboSecciones.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSecciones.FormattingEnabled = true;
            this.cboSecciones.IntegralHeight = false;
            this.cboSecciones.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "CH",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "LL",
            "M",
            "N",
            "Ñ",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.cboSecciones.Location = new System.Drawing.Point(109, 237);
            this.cboSecciones.Name = "cboSecciones";
            this.cboSecciones.Size = new System.Drawing.Size(261, 26);
            this.cboSecciones.TabIndex = 21;
            this.cboSecciones.Text = "A";
            // 
            // cboTurnos
            // 
            this.cboTurnos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTurnos.FormattingEnabled = true;
            this.cboTurnos.Items.AddRange(new object[] {
            "DIURNO (MAÑANA)",
            "TARDE"});
            this.cboTurnos.Location = new System.Drawing.Point(109, 273);
            this.cboTurnos.Name = "cboTurnos";
            this.cboTurnos.Size = new System.Drawing.Size(261, 26);
            this.cboTurnos.TabIndex = 22;
            this.cboTurnos.Text = "DIURNO (MAÑANA)";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(25, 396);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(344, 63);
            this.txtObservaciones.TabIndex = 23;
            // 
            // btnRotar
            // 
            this.btnRotar.BackColor = System.Drawing.Color.MediumBlue;
            this.btnRotar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRotar.ForeColor = System.Drawing.Color.White;
            this.btnRotar.Location = new System.Drawing.Point(878, 25);
            this.btnRotar.Name = "btnRotar";
            this.btnRotar.Size = new System.Drawing.Size(130, 29);
            this.btnRotar.TabIndex = 24;
            this.btnRotar.Text = "Rotar";
            this.btnRotar.UseVisualStyleBackColor = false;
            this.btnRotar.Click += new System.EventHandler(this.btnRotar_Click_1);
            // 
            // pdfViewer2
            // 
            this.pdfViewer2.Location = new System.Drawing.Point(399, 60);
            this.pdfViewer2.Name = "pdfViewer2";
            this.pdfViewer2.Size = new System.Drawing.Size(609, 452);
            this.pdfViewer2.TabIndex = 25;
            // 
            // frmDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 524);
            this.Controls.Add(this.pdfViewer2);
            this.Controls.Add(this.btnRotar);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.cboTurnos);
            this.Controls.Add(this.cboSecciones);
            this.Controls.Add(this.cboGrados);
            this.Controls.Add(this.cboNiveles);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboAnos);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.cboTiposDocumentos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnAdjuntar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblNombreArchivo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDocumento";
            this.Text = "Registro de Documento Digital";
            this.Load += new System.EventHandler(this.frmDocumento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label lblNombreArchivo;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button btnAdjuntar;
        private Button btnGrabar;
        private Button btnCancelar;
        private Label label4;
        private ComboBox cboTiposDocumentos;
        private TextBox txtTitulo;
        private ComboBox cboAnos;
        private Label label6;
        private ComboBox cboNiveles;
        private ComboBox cboGrados;
        private ComboBox cboSecciones;
        private ComboBox cboTurnos;
        private TextBox txtObservaciones;
        private Button btnRotar;
        private PdfiumViewer.PdfViewer pdfViewer2;
    }
}