namespace cassandratest
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
            this.IP_Text = new System.Windows.Forms.TextBox();
            this.IP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ConnectDB = new System.Windows.Forms.Button();
            this.Port = new System.Windows.Forms.NumericUpDown();
            this.constatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.keyspace = new System.Windows.Forms.TextBox();
            this.listdata = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Disconnect_Bt = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.query = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.PutDB = new System.Windows.Forms.Button();
            this.DbPath = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Port)).BeginInit();
            this.SuspendLayout();
            // 
            // IP_Text
            // 
            this.IP_Text.Location = new System.Drawing.Point(93, 18);
            this.IP_Text.Name = "IP_Text";
            this.IP_Text.Size = new System.Drawing.Size(115, 22);
            this.IP_Text.TabIndex = 0;
            this.IP_Text.Text = "127.0.0.1";
            this.IP_Text.TextChanged += new System.EventHandler(this.IP_Text_TextChanged);
            // 
            // IP
            // 
            this.IP.AutoSize = true;
            this.IP.Location = new System.Drawing.Point(15, 18);
            this.IP.Name = "IP";
            this.IP.Size = new System.Drawing.Size(75, 17);
            this.IP.TabIndex = 1;
            this.IP.Text = "IP address";
            this.IP.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port";
            // 
            // ConnectDB
            // 
            this.ConnectDB.Location = new System.Drawing.Point(231, 15);
            this.ConnectDB.Name = "ConnectDB";
            this.ConnectDB.Size = new System.Drawing.Size(87, 23);
            this.ConnectDB.TabIndex = 4;
            this.ConnectDB.Text = "Connect";
            this.ConnectDB.UseVisualStyleBackColor = true;
            this.ConnectDB.Click += new System.EventHandler(this.ConnectDB_Click);
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(93, 56);
            this.Port.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(120, 22);
            this.Port.TabIndex = 5;
            this.Port.Value = new decimal(new int[] {
            9042,
            0,
            0,
            0});
            this.Port.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // constatus
            // 
            this.constatus.AutoSize = true;
            this.constatus.Location = new System.Drawing.Point(324, 15);
            this.constatus.Name = "constatus";
            this.constatus.Size = new System.Drawing.Size(82, 17);
            this.constatus.TabIndex = 6;
            this.constatus.Text = "Disconnect.";
            this.constatus.Click += new System.EventHandler(this.constatus_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Keyspace";
            // 
            // keyspace
            // 
            this.keyspace.Location = new System.Drawing.Point(93, 93);
            this.keyspace.Name = "keyspace";
            this.keyspace.Size = new System.Drawing.Size(120, 22);
            this.keyspace.TabIndex = 8;
            this.keyspace.Text = "ctc";
            // 
            // listdata
            // 
            this.listdata.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listdata.Location = new System.Drawing.Point(21, 261);
            this.listdata.Name = "listdata";
            this.listdata.Size = new System.Drawing.Size(794, 282);
            this.listdata.TabIndex = 9;
            this.listdata.UseCompatibleStateImageBehavior = false;
            this.listdata.View = System.Windows.Forms.View.Details;
            this.listdata.SelectedIndexChanged += new System.EventHandler(this.listdata_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "daycode";
            this.columnHeader1.Width = 83;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "time";
            this.columnHeader2.Width = 102;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "alarm";
            this.columnHeader3.Width = 129;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "annotation";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "eventtext";
            this.columnHeader5.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "object";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "operator";
            this.columnHeader7.Width = 86;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "priority";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "site";
            // 
            // Disconnect_Bt
            // 
            this.Disconnect_Bt.Location = new System.Drawing.Point(231, 49);
            this.Disconnect_Bt.Name = "Disconnect_Bt";
            this.Disconnect_Bt.Size = new System.Drawing.Size(90, 23);
            this.Disconnect_Bt.TabIndex = 10;
            this.Disconnect_Bt.Text = "Disconnect";
            this.Disconnect_Bt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Disconnect_Bt.UseVisualStyleBackColor = true;
            this.Disconnect_Bt.Click += new System.EventHandler(this.Disconnect_Bt_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(439, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Insert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Insert_Bt);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Table";
            // 
            // query
            // 
            this.query.Location = new System.Drawing.Point(24, 232);
            this.query.Name = "query";
            this.query.Size = new System.Drawing.Size(75, 23);
            this.query.TabIndex = 15;
            this.query.Text = "Query";
            this.query.UseVisualStyleBackColor = true;
            this.query.Click += new System.EventHandler(this.query_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(93, 134);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 89);
            this.checkedListBox1.TabIndex = 13;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            this.checkedListBox1.SelectedValueChanged += new System.EventHandler(this.checkedListBox1_SelectedValueChanged);
            // 
            // PutDB
            // 
            this.PutDB.Location = new System.Drawing.Point(717, 53);
            this.PutDB.Name = "PutDB";
            this.PutDB.Size = new System.Drawing.Size(75, 23);
            this.PutDB.TabIndex = 16;
            this.PutDB.Text = "PutDB";
            this.PutDB.UseVisualStyleBackColor = true;
            this.PutDB.Click += new System.EventHandler(this.button2_Click);
            // 
            // DbPath
            // 
            this.DbPath.Location = new System.Drawing.Point(452, 56);
            this.DbPath.Name = "DbPath";
            this.DbPath.Size = new System.Drawing.Size(259, 22);
            this.DbPath.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 573);
            this.Controls.Add(this.DbPath);
            this.Controls.Add(this.PutDB);
            this.Controls.Add(this.query);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Disconnect_Bt);
            this.Controls.Add(this.listdata);
            this.Controls.Add(this.keyspace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.constatus);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.ConnectDB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IP);
            this.Controls.Add(this.IP_Text);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Port)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IP_Text;
        private System.Windows.Forms.Label IP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ConnectDB;
        public System.Windows.Forms.NumericUpDown Port;
        private System.Windows.Forms.Label constatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox keyspace;
        private System.Windows.Forms.ListView listdata;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button Disconnect_Bt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button query;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button PutDB;
        private System.Windows.Forms.TextBox DbPath;
    }
}

