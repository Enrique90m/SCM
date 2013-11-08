namespace SCM
{
    partial class EquiposFormulario
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
            System.Windows.Forms.Label iDLabel;
            System.Windows.Forms.Label numEquipoLabel;
            System.Windows.Forms.Label marcaLabel;
            System.Windows.Forms.Label numSerieLabel;
            System.Windows.Forms.Label salaLabel;
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.usarElSistemaComoAdministradorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioDeEquiposYModificacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regresarAlMenuPrincipalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.contactenosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.iDTextBox = new System.Windows.Forms.TextBox();
            this.numEquipoTextBox = new System.Windows.Forms.TextBox();
            this.marcaTextBox = new System.Windows.Forms.TextBox();
            this.numSerieTextBox = new System.Windows.Forms.TextBox();
            this.salaTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            iDLabel = new System.Windows.Forms.Label();
            numEquipoLabel = new System.Windows.Forms.Label();
            marcaLabel = new System.Windows.Forms.Label();
            numSerieLabel = new System.Windows.Forms.Label();
            salaLabel = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // iDLabel
            // 
            iDLabel.AutoSize = true;
            iDLabel.Location = new System.Drawing.Point(69, 61);
            iDLabel.Name = "iDLabel";
            iDLabel.Size = new System.Drawing.Size(21, 13);
            iDLabel.TabIndex = 0;
            iDLabel.Text = "ID:";
            // 
            // numEquipoLabel
            // 
            numEquipoLabel.AutoSize = true;
            numEquipoLabel.Location = new System.Drawing.Point(69, 87);
            numEquipoLabel.Name = "numEquipoLabel";
            numEquipoLabel.Size = new System.Drawing.Size(68, 13);
            numEquipoLabel.TabIndex = 2;
            numEquipoLabel.Text = "Num Equipo:";
            // 
            // marcaLabel
            // 
            marcaLabel.AutoSize = true;
            marcaLabel.Location = new System.Drawing.Point(69, 113);
            marcaLabel.Name = "marcaLabel";
            marcaLabel.Size = new System.Drawing.Size(40, 13);
            marcaLabel.TabIndex = 4;
            marcaLabel.Text = "Marca:";
            // 
            // numSerieLabel
            // 
            numSerieLabel.AutoSize = true;
            numSerieLabel.Location = new System.Drawing.Point(69, 139);
            numSerieLabel.Name = "numSerieLabel";
            numSerieLabel.Size = new System.Drawing.Size(59, 13);
            numSerieLabel.TabIndex = 6;
            numSerieLabel.Text = "Num Serie:";
            // 
            // salaLabel
            // 
            salaLabel.AutoSize = true;
            salaLabel.Location = new System.Drawing.Point(69, 165);
            salaLabel.Name = "salaLabel";
            salaLabel.Size = new System.Drawing.Size(31, 13);
            salaLabel.TabIndex = 8;
            salaLabel.Text = "Sala:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.toolStripSeparator2,
            this.toolStripDropDownButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(745, 27);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Image = global::SCM.Properties.Resources.utilities_system_monitor;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(181, 24);
            this.toolStripLabel1.Text = " SCRF-Control de equipos";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usarElSistemaComoAdministradorToolStripMenuItem,
            this.inventarioDeEquiposYModificacionToolStripMenuItem,
            this.regresarAlMenuPrincipalToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::SCM.Properties.Resources.program_group;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(88, 24);
            this.toolStripDropDownButton1.Text = "Archivo";
            // 
            // usarElSistemaComoAdministradorToolStripMenuItem
            // 
            this.usarElSistemaComoAdministradorToolStripMenuItem.Image = global::SCM.Properties.Resources.symbol_add;
            this.usarElSistemaComoAdministradorToolStripMenuItem.Name = "usarElSistemaComoAdministradorToolStripMenuItem";
            this.usarElSistemaComoAdministradorToolStripMenuItem.Size = new System.Drawing.Size(324, 24);
            this.usarElSistemaComoAdministradorToolStripMenuItem.Text = "Agregar equipo";
            this.usarElSistemaComoAdministradorToolStripMenuItem.Click += new System.EventHandler(this.usarElSistemaComoAdministradorToolStripMenuItem_Click);
            // 
            // inventarioDeEquiposYModificacionToolStripMenuItem
            // 
            this.inventarioDeEquiposYModificacionToolStripMenuItem.Image = global::SCM.Properties.Resources.add_files_to_archive_blue;
            this.inventarioDeEquiposYModificacionToolStripMenuItem.Name = "inventarioDeEquiposYModificacionToolStripMenuItem";
            this.inventarioDeEquiposYModificacionToolStripMenuItem.Size = new System.Drawing.Size(324, 24);
            this.inventarioDeEquiposYModificacionToolStripMenuItem.Text = "Inventario de equipos y modificacion";
            this.inventarioDeEquiposYModificacionToolStripMenuItem.Click += new System.EventHandler(this.inventarioDeEquiposYModificacionToolStripMenuItem_Click);
            // 
            // regresarAlMenuPrincipalToolStripMenuItem
            // 
            this.regresarAlMenuPrincipalToolStripMenuItem.Image = global::SCM.Properties.Resources.back_2;
            this.regresarAlMenuPrincipalToolStripMenuItem.Name = "regresarAlMenuPrincipalToolStripMenuItem";
            this.regresarAlMenuPrincipalToolStripMenuItem.Size = new System.Drawing.Size(324, 24);
            this.regresarAlMenuPrincipalToolStripMenuItem.Text = "Regresar al menu principal";
            this.regresarAlMenuPrincipalToolStripMenuItem.Click += new System.EventHandler(this.regresarAlMenuPrincipalToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Image = global::SCM.Properties.Resources.exit;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(324, 24);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contactenosToolStripMenuItem});
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(88, 24);
            this.toolStripDropDownButton2.Text = "Acerca de";
            // 
            // contactenosToolStripMenuItem
            // 
            this.contactenosToolStripMenuItem.Name = "contactenosToolStripMenuItem";
            this.contactenosToolStripMenuItem.Size = new System.Drawing.Size(211, 24);
            this.contactenosToolStripMenuItem.Text = "Detalles del sistema";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(638, 327);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(630, 301);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Inventario";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(iDLabel);
            this.tabPage1.Controls.Add(this.iDTextBox);
            this.tabPage1.Controls.Add(numEquipoLabel);
            this.tabPage1.Controls.Add(this.numEquipoTextBox);
            this.tabPage1.Controls.Add(marcaLabel);
            this.tabPage1.Controls.Add(this.marcaTextBox);
            this.tabPage1.Controls.Add(numSerieLabel);
            this.tabPage1.Controls.Add(this.numSerieTextBox);
            this.tabPage1.Controls.Add(salaLabel);
            this.tabPage1.Controls.Add(this.salaTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(630, 301);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "AgregarEquipo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 207);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 38);
            this.button1.TabIndex = 11;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Agregar Equipo";
            // 
            // iDTextBox
            // 
            this.iDTextBox.Location = new System.Drawing.Point(143, 58);
            this.iDTextBox.Name = "iDTextBox";
            this.iDTextBox.Size = new System.Drawing.Size(100, 20);
            this.iDTextBox.TabIndex = 1;
            // 
            // numEquipoTextBox
            // 
            this.numEquipoTextBox.Location = new System.Drawing.Point(143, 84);
            this.numEquipoTextBox.Name = "numEquipoTextBox";
            this.numEquipoTextBox.Size = new System.Drawing.Size(100, 20);
            this.numEquipoTextBox.TabIndex = 3;
            // 
            // marcaTextBox
            // 
            this.marcaTextBox.Location = new System.Drawing.Point(143, 110);
            this.marcaTextBox.Name = "marcaTextBox";
            this.marcaTextBox.Size = new System.Drawing.Size(100, 20);
            this.marcaTextBox.TabIndex = 5;
            // 
            // numSerieTextBox
            // 
            this.numSerieTextBox.Location = new System.Drawing.Point(143, 136);
            this.numSerieTextBox.Name = "numSerieTextBox";
            this.numSerieTextBox.Size = new System.Drawing.Size(100, 20);
            this.numSerieTextBox.TabIndex = 7;
            // 
            // salaTextBox
            // 
            this.salaTextBox.Location = new System.Drawing.Point(143, 162);
            this.salaTextBox.Name = "salaTextBox";
            this.salaTextBox.Size = new System.Drawing.Size(100, 20);
            this.salaTextBox.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(553, 234);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(630, 301);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // EquiposFormulario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 418);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "EquiposFormulario";
            this.Text = "EquiposFormulario";
            this.Load += new System.EventHandler(this.EquiposFormulario_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem usarElSistemaComoAdministradorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem contactenosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventarioDeEquiposYModificacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regresarAlMenuPrincipalToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox iDTextBox;
        private System.Windows.Forms.TextBox numEquipoTextBox;
        private System.Windows.Forms.TextBox marcaTextBox;
        private System.Windows.Forms.TextBox numSerieTextBox;
        private System.Windows.Forms.TextBox salaTextBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage3;

    }
}