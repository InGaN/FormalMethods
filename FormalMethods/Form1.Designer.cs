namespace FormalMethods
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_NDFA1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_regex = new System.Windows.Forms.Label();
            this.regexTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.rb1_grammar = new System.Windows.Forms.RadioButton();
            this.rb1_regex = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_NDFA2 = new System.Windows.Forms.Button();
            this.btn_Grammar = new System.Windows.Forms.Button();
            this.grammarTextBox = new System.Windows.Forms.TextBox();
            this.label_grammar = new System.Windows.Forms.Label();
            this.LanguageTextBox = new System.Windows.Forms.TextBox();
            this.label_language = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_NDFA1
            // 
            this.btn_NDFA1.Location = new System.Drawing.Point(3, 242);
            this.btn_NDFA1.Name = "btn_NDFA1";
            this.btn_NDFA1.Size = new System.Drawing.Size(93, 37);
            this.btn_NDFA1.TabIndex = 2;
            this.btn_NDFA1.Text = "Draw NDFA (1)";
            this.btn_NDFA1.UseVisualStyleBackColor = true;
            this.btn_NDFA1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label_regex, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.regexTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_NDFA1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.grammarTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_grammar, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.LanguageTextBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_language, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(615, 377);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label_regex
            // 
            this.label_regex.AutoSize = true;
            this.label_regex.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_regex.Location = new System.Drawing.Point(253, 27);
            this.label_regex.Name = "label_regex";
            this.label_regex.Size = new System.Drawing.Size(359, 13);
            this.label_regex.TabIndex = 5;
            this.label_regex.Text = "Enter Regular Expression:";
            // 
            // regexTextBox
            // 
            this.regexTextBox.Location = new System.Drawing.Point(253, 43);
            this.regexTextBox.Name = "regexTextBox";
            this.regexTextBox.Size = new System.Drawing.Size(344, 20);
            this.regexTextBox.TabIndex = 6;
            this.regexTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.regexTextBox_KeyDown);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(253, 242);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(213, 132);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.rb1_grammar, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.rb1_regex, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(100, 53);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // rb1_grammar
            // 
            this.rb1_grammar.AutoSize = true;
            this.rb1_grammar.Location = new System.Drawing.Point(3, 29);
            this.rb1_grammar.Name = "rb1_grammar";
            this.rb1_grammar.Size = new System.Drawing.Size(67, 17);
            this.rb1_grammar.TabIndex = 1;
            this.rb1_grammar.Text = "Grammar";
            this.rb1_grammar.UseVisualStyleBackColor = true;
            this.rb1_grammar.CheckedChanged += new System.EventHandler(this.rb2_grammar_CheckedChanged);
            // 
            // rb1_regex
            // 
            this.rb1_regex.AutoSize = true;
            this.rb1_regex.Checked = true;
            this.rb1_regex.Location = new System.Drawing.Point(3, 3);
            this.rb1_regex.Name = "rb1_regex";
            this.rb1_regex.Size = new System.Drawing.Size(56, 17);
            this.rb1_regex.TabIndex = 0;
            this.rb1_regex.TabStop = true;
            this.rb1_regex.Text = "Regex";
            this.rb1_regex.UseVisualStyleBackColor = true;
            this.rb1_regex.CheckedChanged += new System.EventHandler(this.rb1_regex_CheckedChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btn_NDFA2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Grammar, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(109, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(101, 100);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btn_NDFA2
            // 
            this.btn_NDFA2.Location = new System.Drawing.Point(3, 3);
            this.btn_NDFA2.Name = "btn_NDFA2";
            this.btn_NDFA2.Size = new System.Drawing.Size(95, 44);
            this.btn_NDFA2.TabIndex = 7;
            this.btn_NDFA2.Text = "Draw NDFA (2)";
            this.btn_NDFA2.UseVisualStyleBackColor = true;
            this.btn_NDFA2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Grammar
            // 
            this.btn_Grammar.Location = new System.Drawing.Point(3, 53);
            this.btn_Grammar.Name = "btn_Grammar";
            this.btn_Grammar.Size = new System.Drawing.Size(95, 38);
            this.btn_Grammar.TabIndex = 8;
            this.btn_Grammar.Text = "Draw Grammar";
            this.btn_Grammar.UseVisualStyleBackColor = true;
            this.btn_Grammar.Click += new System.EventHandler(this.btn_Grammar_Click);
            // 
            // grammarTextBox
            // 
            this.grammarTextBox.Location = new System.Drawing.Point(253, 88);
            this.grammarTextBox.Multiline = true;
            this.grammarTextBox.Name = "grammarTextBox";
            this.grammarTextBox.Size = new System.Drawing.Size(207, 145);
            this.grammarTextBox.TabIndex = 1;
            // 
            // label_grammar
            // 
            this.label_grammar.AutoSize = true;
            this.label_grammar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_grammar.Location = new System.Drawing.Point(253, 72);
            this.label_grammar.Name = "label_grammar";
            this.label_grammar.Size = new System.Drawing.Size(359, 13);
            this.label_grammar.TabIndex = 4;
            this.label_grammar.Text = "Enter Regular Grammar:";
            // 
            // LanguageTextBox
            // 
            this.LanguageTextBox.Location = new System.Drawing.Point(3, 88);
            this.LanguageTextBox.Multiline = true;
            this.LanguageTextBox.Name = "LanguageTextBox";
            this.LanguageTextBox.Size = new System.Drawing.Size(201, 145);
            this.LanguageTextBox.TabIndex = 0;
            // 
            // label_language
            // 
            this.label_language.AutoSize = true;
            this.label_language.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_language.Location = new System.Drawing.Point(3, 72);
            this.label_language.Name = "label_language";
            this.label_language.Size = new System.Drawing.Size(244, 13);
            this.label_language.TabIndex = 2;
            this.label_language.Text = "Enter Language Nodes:        ex:  S,q1,q2";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 3);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 34);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 377);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Formal Methods";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_NDFA1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox grammarTextBox;
        private System.Windows.Forms.Label label_language;
        private System.Windows.Forms.TextBox LanguageTextBox;
        private System.Windows.Forms.Label label_grammar;
        private System.Windows.Forms.Label label_regex;
        private System.Windows.Forms.TextBox regexTextBox;
        private System.Windows.Forms.Button btn_NDFA2;
        private System.Windows.Forms.RadioButton rb1_regex;
        private System.Windows.Forms.RadioButton rb1_grammar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_Grammar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

