namespace SCM
{
    partial class ReporteFecha
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.BuscaFallaEntreFechasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bdDataSet = new SCM.bdDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BuscaFallaEntreFechasTableAdapter = new SCM.bdDataSetTableAdapters.BuscaFallaEntreFechasTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.seleccionarTodosTableAdapter1 = new SCM.bdDataSetTableAdapters.SeleccionarTodosTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.BuscaFallaEntreFechasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BuscaFallaEntreFechasBindingSource
            // 
            this.BuscaFallaEntreFechasBindingSource.DataMember = "BuscaFallaEntreFechas";
            this.BuscaFallaEntreFechasBindingSource.DataSource = this.bdDataSet;
            // 
            // bdDataSet
            // 
            this.bdDataSet.DataSetName = "bdDataSet";
            this.bdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource8.Name = "DataSet1";
            reportDataSource8.Value = this.BuscaFallaEntreFechasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource8);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SCM.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1117, 521);
            this.reportViewer1.TabIndex = 0;
            // 
            // BuscaFallaEntreFechasTableAdapter
            // 
            this.BuscaFallaEntreFechasTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Demi", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(235, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // seleccionarTodosTableAdapter1
            // 
            this.seleccionarTodosTableAdapter1.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(138, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(673, 45);
            this.label2.TabIndex = 2;
            this.label2.Text = "INSTITUTO TECNOLOGICO DE NUEVO LEON";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SCM.Properties.Resources.LogoITNL;
            this.pictureBox1.Location = new System.Drawing.Point(852, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 120);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // ReporteFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 521);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteFecha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteFecha";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReporteFecha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BuscaFallaEntreFechasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BuscaFallaEntreFechasBindingSource;
        private bdDataSet bdDataSet;
        private bdDataSetTableAdapters.BuscaFallaEntreFechasTableAdapter BuscaFallaEntreFechasTableAdapter;
        private System.Windows.Forms.Label label1;
        private bdDataSetTableAdapters.SeleccionarTodosTableAdapter seleccionarTodosTableAdapter1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}