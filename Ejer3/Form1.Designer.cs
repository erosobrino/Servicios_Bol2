namespace Ejer3
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbNote = new System.Windows.Forms.TextBox();
            this.btNew = new System.Windows.Forms.Button();
            this.btOpen = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbNote
            // 
            this.tbNote.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbNote.Location = new System.Drawing.Point(0, 0);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNote.Size = new System.Drawing.Size(800, 378);
            this.tbNote.TabIndex = 0;
            this.tbNote.TextChanged += new System.EventHandler(this.tbNota_TextChanged);
            this.tbNote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown1);
            // 
            // btNew
            // 
            this.btNew.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btNew.Location = new System.Drawing.Point(130, 383);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(96, 54);
            this.btNew.TabIndex = 1;
            this.btNew.Text = "New";
            this.btNew.UseVisualStyleBackColor = true;
            this.btNew.Click += new System.EventHandler(this.btNew_Click);
            // 
            // btOpen
            // 
            this.btOpen.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btOpen.Location = new System.Drawing.Point(355, 383);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(96, 54);
            this.btOpen.TabIndex = 2;
            this.btOpen.Text = "Open";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.btOpen_Click);
            // 
            // btSave
            // 
            this.btSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btSave.Location = new System.Drawing.Point(572, 383);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(96, 54);
            this.btSave.TabIndex = 3;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btOpen);
            this.Controls.Add(this.btNew);
            this.Controls.Add(this.tbNote);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Ejer3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.Button btNew;
        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.Button btSave;
    }
}