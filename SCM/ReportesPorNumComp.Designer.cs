﻿namespace SCM
{
    partial class ReportesPorNumComp
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bdDataSet = new SCM.bdDataSet();
            this.BuscaFallaPorNumCompBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BuscaFallaPorNumCompTableAdapter = new SCM.bdDataSetTableAdapters.BuscaFallaPorNumCompTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bdDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuscaFallaPorNumCompBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.BuscaFallaPorNumCompBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SCM.BuscaPorNumComp_REPORTE.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(861, 445);
            this.reportViewer1.TabIndex = 0;
            // 
            // bdDataSet
            // 
            this.bdDataSet.DataSetName = "bdDataSet";
            this.bdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BuscaFallaPorNumCompBindingSource
            // 
            this.BuscaFallaPorNumCompBindingSource.DataMember = "BuscaFallaPorNumComp";
            this.BuscaFallaPorNumCompBindingSource.DataSource = this.bdDataSet;
            // 
            // BuscaFallaPorNumCompTableAdapter
            // 
            this.BuscaFallaPorNumCompTableAdapter.ClearBeforeFill = true;
            // 
            // ReportesPorNumComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 445);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportesPorNumComp";
            this.Text = "ReportesPorNumComp";
            this.Load += new System.EventHandler(this.ReportesPorNumComp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bdDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuscaFallaPorNumCompBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BuscaFallaPorNumCompBindingSource;
        private bdDataSet bdDataSet;
        private bdDataSetTableAdapters.BuscaFallaPorNumCompTableAdapter BuscaFallaPorNumCompTableAdapter;
    }
}