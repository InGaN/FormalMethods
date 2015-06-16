namespace FormalMethods
{
    partial class Form_Grammar
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_grammarForm = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_grammarForm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 327);
            this.panel1.TabIndex = 0;
            // 
            // lbl_grammarForm
            // 
            this.lbl_grammarForm.AutoSize = true;
            this.lbl_grammarForm.Location = new System.Drawing.Point(13, 13);
            this.lbl_grammarForm.Name = "lbl_grammarForm";
            this.lbl_grammarForm.Size = new System.Drawing.Size(35, 13);
            this.lbl_grammarForm.TabIndex = 0;
            this.lbl_grammarForm.Text = "label1";
            // 
            // Form_Grammar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 327);
            this.Controls.Add(this.panel1);
            this.Name = "Form_Grammar";
            this.Text = "Form_Grammar";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_grammarForm;
    }
}