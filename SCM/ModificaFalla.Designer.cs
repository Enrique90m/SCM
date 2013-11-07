namespace SCM
{
    partial class ModificaFalla
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
            System.Windows.Forms.Label numFallaLabel;
            System.Windows.Forms.Label numComputadoraLabel;
            System.Windows.Forms.Label descripcionFallaLabel;
            System.Windows.Forms.Label solucionadaLabel;
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ActualizarTextbox = new System.Windows.Forms.Button();
            this.numFallaTextBox = new System.Windows.Forms.TextBox();
            this.numComputadoraTextBox = new System.Windows.Forms.TextBox();
            this.descripcionFallaTextBox = new System.Windows.Forms.TextBox();
            this.solucionadaCheckBox = new System.Windows.Forms.CheckBox();
            numFallaLabel = new System.Windows.Forms.Label();
            numComputadoraLabel = new System.Windows.Forms.Label();
            descripcionFallaLabel = new System.Windows.Forms.Label();
            solucionadaLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Franklin Gothic Medium", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Location = new System.Drawing.Point(145, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(202, 37);
            this.label9.TabIndex = 336;
            this.label9.Text = "Modificar Falla";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(198, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 60);
            this.button1.TabIndex = 340;
            this.button1.Text = "Regresar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ActualizarTextbox
            // 
            this.ActualizarTextbox.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ActualizarTextbox.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ActualizarTextbox.Location = new System.Drawing.Point(40, 287);
            this.ActualizarTextbox.Name = "ActualizarTextbox";
            this.ActualizarTextbox.Size = new System.Drawing.Size(132, 60);
            this.ActualizarTextbox.TabIndex = 339;
            this.ActualizarTextbox.Text = "Actualizar informacion";
            this.ActualizarTextbox.UseVisualStyleBackColor = true;
            this.ActualizarTextbox.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // numFallaLabel
            // 
            numFallaLabel.AutoSize = true;
            numFallaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numFallaLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            numFallaLabel.Location = new System.Drawing.Point(49, 67);
            numFallaLabel.Name = "numFallaLabel";
            numFallaLabel.Size = new System.Drawing.Size(94, 20);
            numFallaLabel.TabIndex = 340;
            numFallaLabel.Text = "Num Falla:";
            // 
            // numFallaTextBox
            // 
            this.numFallaTextBox.Location = new System.Drawing.Point(149, 64);
            this.numFallaTextBox.Name = "numFallaTextBox";
            this.numFallaTextBox.ReadOnly = true;
            this.numFallaTextBox.Size = new System.Drawing.Size(200, 20);
            this.numFallaTextBox.TabIndex = 341;
            // 
            // numComputadoraLabel
            // 
            numComputadoraLabel.AutoSize = true;
            numComputadoraLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            numComputadoraLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            numComputadoraLabel.Location = new System.Drawing.Point(49, 93);
            numComputadoraLabel.Name = "numComputadoraLabel";
            numComputadoraLabel.Size = new System.Drawing.Size(163, 20);
            numComputadoraLabel.TabIndex = 342;
            numComputadoraLabel.Text = "Num Computadora:";
            // 
            // numComputadoraTextBox
            // 
            this.numComputadoraTextBox.Location = new System.Drawing.Point(218, 90);
            this.numComputadoraTextBox.Name = "numComputadoraTextBox";
            this.numComputadoraTextBox.Size = new System.Drawing.Size(200, 20);
            this.numComputadoraTextBox.TabIndex = 343;
            // 
            // descripcionFallaLabel
            // 
            descripcionFallaLabel.AutoSize = true;
            descripcionFallaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descripcionFallaLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            descripcionFallaLabel.Location = new System.Drawing.Point(49, 119);
            descripcionFallaLabel.Name = "descripcionFallaLabel";
            descripcionFallaLabel.Size = new System.Drawing.Size(149, 20);
            descripcionFallaLabel.TabIndex = 344;
            descripcionFallaLabel.Text = "descripcion Falla:";
            // 
            // descripcionFallaTextBox
            // 
            this.descripcionFallaTextBox.Location = new System.Drawing.Point(218, 116);
            this.descripcionFallaTextBox.Multiline = true;
            this.descripcionFallaTextBox.Name = "descripcionFallaTextBox";
            this.descripcionFallaTextBox.Size = new System.Drawing.Size(392, 141);
            this.descripcionFallaTextBox.TabIndex = 345;
            // 
            // solucionadaLabel
            // 
            solucionadaLabel.AutoSize = true;
            solucionadaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            solucionadaLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            solucionadaLabel.Location = new System.Drawing.Point(49, 264);
            solucionadaLabel.Name = "solucionadaLabel";
            solucionadaLabel.Size = new System.Drawing.Size(113, 20);
            solucionadaLabel.TabIndex = 350;
            solucionadaLabel.Text = "Solucionada:";
            // 
            // solucionadaCheckBox
            // 
            this.solucionadaCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.solucionadaCheckBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.solucionadaCheckBox.Location = new System.Drawing.Point(168, 263);
            this.solucionadaCheckBox.Name = "solucionadaCheckBox";
            this.solucionadaCheckBox.Size = new System.Drawing.Size(200, 24);
            this.solucionadaCheckBox.TabIndex = 351;
            this.solucionadaCheckBox.Text = "checkBox1";
            this.solucionadaCheckBox.UseVisualStyleBackColor = true;
            // 
            // ModificaFalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1007, 454);
            this.Controls.Add(numFallaLabel);
            this.Controls.Add(this.numFallaTextBox);
            this.Controls.Add(numComputadoraLabel);
            this.Controls.Add(this.numComputadoraTextBox);
            this.Controls.Add(descripcionFallaLabel);
            this.Controls.Add(this.descripcionFallaTextBox);
            this.Controls.Add(solucionadaLabel);
            this.Controls.Add(this.solucionadaCheckBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ActualizarTextbox);
            this.Name = "ModificaFalla";
            this.Text = "ModificaFalla";
            this.Load += new System.EventHandler(this.ModificaFalla_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ActualizarTextbox;
        private System.Windows.Forms.TextBox numFallaTextBox;
        private System.Windows.Forms.TextBox numComputadoraTextBox;
        private System.Windows.Forms.TextBox descripcionFallaTextBox;
        private System.Windows.Forms.CheckBox solucionadaCheckBox;
    }
}