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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rb1_NDFA = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_NDFA2 = new System.Windows.Forms.Button();
            this.btn_Grammar = new System.Windows.Forms.Button();
            this.grammarTextBox = new System.Windows.Forms.TextBox();
            this.label_grammar = new System.Windows.Forms.Label();
            this.label_nodes = new System.Windows.Forms.Label();
            this.nodesTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel_NDFA = new System.Windows.Forms.TableLayoutPanel();
            this.table_lableTitle = new System.Windows.Forms.Label();
            this.table_lable1 = new System.Windows.Forms.Label();
            this.table_lable2 = new System.Windows.Forms.Label();
            this.textBox_table1 = new System.Windows.Forms.TextBox();
            this.textBox_table2 = new System.Windows.Forms.TextBox();
            this.textBox_table3 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel_NDFA.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_NDFA1
            // 
            this.btn_NDFA1.Location = new System.Drawing.Point(3, 3);
            this.btn_NDFA1.Name = "btn_NDFA1";
            this.btn_NDFA1.Size = new System.Drawing.Size(93, 27);
            this.btn_NDFA1.TabIndex = 2;
            this.btn_NDFA1.Text = "Draw NDFA (1)";
            this.btn_NDFA1.UseVisualStyleBackColor = true;
            this.btn_NDFA1.Click += new System.EventHandler(this.btn_NDFA1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel1.Controls.Add(this.label_regex, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.regexTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.grammarTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_grammar, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_nodes, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nodesTextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel_NDFA, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(555, 534);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label_regex
            // 
            this.label_regex.AutoSize = true;
            this.label_regex.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_regex.Location = new System.Drawing.Point(243, 7);
            this.label_regex.Name = "label_regex";
            this.label_regex.Size = new System.Drawing.Size(309, 13);
            this.label_regex.TabIndex = 5;
            this.label_regex.Text = "Enter Regular Expression:";
            // 
            // regexTextBox
            // 
            this.regexTextBox.Location = new System.Drawing.Point(243, 23);
            this.regexTextBox.Name = "regexTextBox";
            this.regexTextBox.Size = new System.Drawing.Size(223, 20);
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
            this.tableLayoutPanel3.Location = new System.Drawing.Point(243, 314);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(223, 173);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.rb1_grammar, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.rb1_regex, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.pictureBox1, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.rb1_NDFA, 0, 2);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(100, 133);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // rb1_grammar
            // 
            this.rb1_grammar.AutoSize = true;
            this.rb1_grammar.Location = new System.Drawing.Point(3, 28);
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
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 78);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 52);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // rb1_NDFA
            // 
            this.rb1_NDFA.AutoSize = true;
            this.rb1_NDFA.Location = new System.Drawing.Point(3, 53);
            this.rb1_NDFA.Name = "rb1_NDFA";
            this.rb1_NDFA.Size = new System.Drawing.Size(54, 17);
            this.rb1_NDFA.TabIndex = 13;
            this.rb1_NDFA.TabStop = true;
            this.rb1_NDFA.Text = "NDFA";
            this.rb1_NDFA.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.btn_NDFA2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_Grammar, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btn_NDFA1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(114, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(101, 167);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btn_NDFA2
            // 
            this.btn_NDFA2.Location = new System.Drawing.Point(3, 36);
            this.btn_NDFA2.Name = "btn_NDFA2";
            this.btn_NDFA2.Size = new System.Drawing.Size(95, 27);
            this.btn_NDFA2.TabIndex = 7;
            this.btn_NDFA2.Text = "Draw NDFA (2)";
            this.btn_NDFA2.UseVisualStyleBackColor = true;
            this.btn_NDFA2.Click += new System.EventHandler(this.btn_NDFA2_Click);
            // 
            // btn_Grammar
            // 
            this.btn_Grammar.Location = new System.Drawing.Point(3, 69);
            this.btn_Grammar.Name = "btn_Grammar";
            this.btn_Grammar.Size = new System.Drawing.Size(95, 25);
            this.btn_Grammar.TabIndex = 8;
            this.btn_Grammar.Text = "Draw Grammar";
            this.btn_Grammar.UseVisualStyleBackColor = true;
            this.btn_Grammar.Click += new System.EventHandler(this.btn_Grammar_Click);
            // 
            // grammarTextBox
            // 
            this.grammarTextBox.Location = new System.Drawing.Point(243, 84);
            this.grammarTextBox.Multiline = true;
            this.grammarTextBox.Name = "grammarTextBox";
            this.grammarTextBox.Size = new System.Drawing.Size(223, 141);
            this.grammarTextBox.TabIndex = 1;
            // 
            // label_grammar
            // 
            this.label_grammar.AutoSize = true;
            this.label_grammar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_grammar.Location = new System.Drawing.Point(243, 68);
            this.label_grammar.Name = "label_grammar";
            this.label_grammar.Size = new System.Drawing.Size(309, 13);
            this.label_grammar.TabIndex = 4;
            this.label_grammar.Text = "Enter Regular Grammar:";
            // 
            // label_nodes
            // 
            this.label_nodes.AutoSize = true;
            this.label_nodes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_nodes.Location = new System.Drawing.Point(3, 7);
            this.label_nodes.Name = "label_nodes";
            this.label_nodes.Size = new System.Drawing.Size(234, 13);
            this.label_nodes.TabIndex = 2;
            this.label_nodes.Text = "Enter Node labels:";
            // 
            // nodesTextBox
            // 
            this.nodesTextBox.Location = new System.Drawing.Point(3, 23);
            this.nodesTextBox.Name = "nodesTextBox";
            this.nodesTextBox.Size = new System.Drawing.Size(201, 20);
            this.nodesTextBox.TabIndex = 11;
            // 
            // tableLayoutPanel_NDFA
            // 
            this.tableLayoutPanel_NDFA.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel_NDFA.ColumnCount = 3;
            this.tableLayoutPanel_NDFA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.29268F));
            this.tableLayoutPanel_NDFA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.70732F));
            this.tableLayoutPanel_NDFA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel_NDFA.Controls.Add(this.table_lableTitle, 0, 0);
            this.tableLayoutPanel_NDFA.Controls.Add(this.table_lable1, 1, 0);
            this.tableLayoutPanel_NDFA.Controls.Add(this.table_lable2, 2, 0);
            this.tableLayoutPanel_NDFA.Controls.Add(this.textBox_table1, 0, 1);
            this.tableLayoutPanel_NDFA.Controls.Add(this.textBox_table2, 1, 1);
            this.tableLayoutPanel_NDFA.Controls.Add(this.textBox_table3, 2, 1);
            this.tableLayoutPanel_NDFA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_NDFA.Location = new System.Drawing.Point(3, 84);
            this.tableLayoutPanel_NDFA.Name = "tableLayoutPanel_NDFA";
            this.tableLayoutPanel_NDFA.RowCount = 2;
            this.tableLayoutPanel_NDFA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel_NDFA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_NDFA.Size = new System.Drawing.Size(234, 224);
            this.tableLayoutPanel_NDFA.TabIndex = 12;
            // 
            // table_lableTitle
            // 
            this.table_lableTitle.AutoSize = true;
            this.table_lableTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table_lableTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.table_lableTitle.Location = new System.Drawing.Point(5, 2);
            this.table_lableTitle.Name = "table_lableTitle";
            this.table_lableTitle.Size = new System.Drawing.Size(58, 18);
            this.table_lableTitle.TabIndex = 0;
            this.table_lableTitle.Text = "NDFA";
            // 
            // table_lable1
            // 
            this.table_lable1.AutoSize = true;
            this.table_lable1.Dock = System.Windows.Forms.DockStyle.Left;
            this.table_lable1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.table_lable1.Location = new System.Drawing.Point(71, 2);
            this.table_lable1.Name = "table_lable1";
            this.table_lable1.Size = new System.Drawing.Size(18, 18);
            this.table_lable1.TabIndex = 1;
            this.table_lable1.Text = "a";
            // 
            // table_lable2
            // 
            this.table_lable2.AutoSize = true;
            this.table_lable2.Dock = System.Windows.Forms.DockStyle.Left;
            this.table_lable2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.table_lable2.Location = new System.Drawing.Point(157, 2);
            this.table_lable2.Name = "table_lable2";
            this.table_lable2.Size = new System.Drawing.Size(18, 18);
            this.table_lable2.TabIndex = 2;
            this.table_lable2.Text = "b";
            // 
            // textBox_table1
            // 
            this.textBox_table1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_table1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_table1.Location = new System.Drawing.Point(5, 25);
            this.textBox_table1.Multiline = true;
            this.textBox_table1.Name = "textBox_table1";
            this.textBox_table1.Size = new System.Drawing.Size(58, 194);
            this.textBox_table1.TabIndex = 3;
            // 
            // textBox_table2
            // 
            this.textBox_table2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_table2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_table2.Location = new System.Drawing.Point(71, 25);
            this.textBox_table2.Multiline = true;
            this.textBox_table2.Name = "textBox_table2";
            this.textBox_table2.Size = new System.Drawing.Size(78, 194);
            this.textBox_table2.TabIndex = 4;
            // 
            // textBox_table3
            // 
            this.textBox_table3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_table3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_table3.Location = new System.Drawing.Point(157, 25);
            this.textBox_table3.Multiline = true;
            this.textBox_table3.Name = "textBox_table3";
            this.textBox_table3.Size = new System.Drawing.Size(72, 194);
            this.textBox_table3.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 534);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Formal Methods";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel_NDFA.ResumeLayout(false);
            this.tableLayoutPanel_NDFA.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_NDFA1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox grammarTextBox;
        private System.Windows.Forms.Label label_nodes;
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
        private System.Windows.Forms.TextBox nodesTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_NDFA;
        private System.Windows.Forms.Label table_lableTitle;
        private System.Windows.Forms.Label table_lable1;
        private System.Windows.Forms.Label table_lable2;
        private System.Windows.Forms.TextBox textBox_table1;
        private System.Windows.Forms.TextBox textBox_table2;
        private System.Windows.Forms.TextBox textBox_table3;
        private System.Windows.Forms.RadioButton rb1_NDFA;
    }
}

