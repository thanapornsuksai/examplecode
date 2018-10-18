namespace pidapcapture
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
            this.Read_bt = new System.Windows.Forms.Button();
            this.Filepath = new System.Windows.Forms.TextBox();
            this.IPlist = new System.Windows.Forms.ComboBox();
            this.Port1list = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.IP2list = new System.Windows.Forms.ComboBox();
            this.Port2list = new System.Windows.Forms.ComboBox();
            this.listview = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.Load_bt = new System.Windows.Forms.Button();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Detial_box = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Read_bt
            // 
            this.Read_bt.Location = new System.Drawing.Point(687, 21);
            this.Read_bt.Name = "Read_bt";
            this.Read_bt.Size = new System.Drawing.Size(75, 23);
            this.Read_bt.TabIndex = 0;
            this.Read_bt.Text = "Readfile";
            this.Read_bt.UseVisualStyleBackColor = true;
            this.Read_bt.Click += new System.EventHandler(this.Read_bt_Click);
            // 
            // Filepath
            // 
            this.Filepath.Location = new System.Drawing.Point(44, 22);
            this.Filepath.Name = "Filepath";
            this.Filepath.Size = new System.Drawing.Size(621, 22);
            this.Filepath.TabIndex = 1;
            // 
            // IPlist
            // 
            this.IPlist.FormattingEnabled = true;
            this.IPlist.Location = new System.Drawing.Point(91, 80);
            this.IPlist.Name = "IPlist";
            this.IPlist.Size = new System.Drawing.Size(121, 24);
            this.IPlist.TabIndex = 2;
            this.IPlist.SelectedIndexChanged += new System.EventHandler(this.IPlist_SelectedIndexChanged);
            // 
            // Port1list
            // 
            this.Port1list.FormattingEnabled = true;
            this.Port1list.Location = new System.Drawing.Point(91, 121);
            this.Port1list.Name = "Port1list";
            this.Port1list.Size = new System.Drawing.Size(121, 24);
            this.Port1list.TabIndex = 3;
            this.Port1list.SelectedIndexChanged += new System.EventHandler(this.Port1list_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "APP1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(983, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "IP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(983, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Port";
            // 
            // IP2list
            // 
            this.IP2list.FormattingEnabled = true;
            this.IP2list.Location = new System.Drawing.Point(1031, 83);
            this.IP2list.Name = "IP2list";
            this.IP2list.Size = new System.Drawing.Size(121, 24);
            this.IP2list.TabIndex = 9;
            this.IP2list.SelectedIndexChanged += new System.EventHandler(this.IP2list_SelectedIndexChanged);
            // 
            // Port2list
            // 
            this.Port2list.FormattingEnabled = true;
            this.Port2list.Location = new System.Drawing.Point(1031, 122);
            this.Port2list.Name = "Port2list";
            this.Port2list.Size = new System.Drawing.Size(121, 24);
            this.Port2list.TabIndex = 10;
            this.Port2list.SelectedIndexChanged += new System.EventHandler(this.Port2list_SelectedIndexChanged);
            // 
            // listview
            // 
            this.listview.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listview.LabelEdit = true;
            this.listview.Location = new System.Drawing.Point(238, 80);
            this.listview.Name = "listview";
            this.listview.Size = new System.Drawing.Size(727, 179);
            this.listview.TabIndex = 11;
            this.listview.UseCompatibleStateImageBehavior = false;
            this.listview.View = System.Windows.Forms.View.Details;
            this.listview.SelectedIndexChanged += new System.EventHandler(this.listview_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Time";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Length";
            this.columnHeader2.Width = 61;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Data";
            this.columnHeader3.Width = 228;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(986, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "APP2";
            // 
            // Load_bt
            // 
            this.Load_bt.Location = new System.Drawing.Point(1062, 165);
            this.Load_bt.Name = "Load_bt";
            this.Load_bt.Size = new System.Drawing.Size(90, 23);
            this.Load_bt.TabIndex = 13;
            this.Load_bt.Text = "Loaddata ";
            this.Load_bt.UseVisualStyleBackColor = true;
            this.Load_bt.Click += new System.EventHandler(this.Load_bt_Click);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "direction";
            this.columnHeader4.Width = 92;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Systemid";
            this.columnHeader5.Width = 74;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Multi-flag";
            this.columnHeader6.Width = 76;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "MsgId";
            this.columnHeader7.Width = 124;
            // 
            // Detial_box
            // 
            this.Detial_box.Location = new System.Drawing.Point(49, 293);
            this.Detial_box.Name = "Detial_box";
            this.Detial_box.Size = new System.Drawing.Size(1045, 145);
            this.Detial_box.TabIndex = 14;
            this.Detial_box.Text = "";
            this.Detial_box.TextChanged += new System.EventHandler(this.Detial_box_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 450);
            this.Controls.Add(this.Detial_box);
            this.Controls.Add(this.Load_bt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.listview);
            this.Controls.Add(this.Port2list);
            this.Controls.Add(this.IP2list);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Port1list);
            this.Controls.Add(this.IPlist);
            this.Controls.Add(this.Filepath);
            this.Controls.Add(this.Read_bt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Read_bt;
        private System.Windows.Forms.TextBox Filepath;
        private System.Windows.Forms.ComboBox IPlist;
        private System.Windows.Forms.ComboBox Port1list;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox IP2list;
        private System.Windows.Forms.ComboBox Port2list;
        private System.Windows.Forms.ListView listview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Load_bt;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        public System.Windows.Forms.RichTextBox Detial_box;
    }
}

