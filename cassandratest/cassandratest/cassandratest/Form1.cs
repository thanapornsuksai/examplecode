using Cassandra;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cassandratest
{
    public partial class Form1 : Form
    {
        private Cluster cluster = null;
        private ISession session = null;
        string checkvalue = null;
        public Guid ID;
        private PreparedStatement ps = null;
        char SEP = ';';
        ListViewItem list;
       

        RowSet rowset;
      
        ICollection<string> collection = null;
        public Form1()
        {
            InitializeComponent();
            constatus.ForeColor = Color.Red;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to exit?", "Exit", MessageBoxButtons.YesNo)
                  != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ConnectDB_Click(object sender, EventArgs e)
        {
            try
            {
                cluster = Cluster.Builder().AddContactPoint(IP_Text.Text).WithPort((Convert.ToInt32(Port.Value))).Build();
                session = cluster.Connect(keyspace.Text);
                collection = cluster.Metadata.GetTables(keyspace.Text);
                constatus.Text = "Connect";
                constatus.ForeColor = Color.Green;
                var item = checkedListBox1.Items;
                foreach (string value in collection)
                {
                    item.Add(value);
                }
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i) == true)
                    {
                        for (int a = 0; a < checkedListBox1.Items.Count; a++)
                            if (a != i)
                            {
                                checkedListBox1.SetItemChecked(a, false);
                            }
                    }
                }
                ps = session.Prepare("INSERT INTO ctc.log(id,time, alarm, priority, site, object, eventtext, operator, annotation) VALUES (" +
                  "?,?, ?, ?, ?, ?, ?, ?, ?)");

                ConnectDB.Enabled = false;
                Disconnect_Bt.Enabled = true;
            }


             




            catch (Exception ex)
            {
                Console.Write(ex.Message);
                constatus.Text = "Disconnect";
                constatus.ForeColor = Color.Red;
            }
        }

        private void IP_Text_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void constatus_Click(object sender, EventArgs e)
        {

        }

        private void Disconnect_Bt_Click(object sender, EventArgs e)
        {
            session.Dispose();
            cluster = null;
            session = null;
            constatus.Text = "Disconnect";
            constatus.ForeColor = Color.Red;
            listdata.Clear();
            checkedListBox1.Text = "";
            checkedListBox1.Items.Clear();
            Disconnect_Bt.Enabled = false;
            ConnectDB.Enabled = true;

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
           
            for (int ix = 0; ix < checkedListBox1.Items.Count; ++ix)
            {
                 if (ix != e.Index) checkedListBox1.SetItemChecked(ix, false);
                else
                {
                    checkvalue = (string)checkedListBox1.Items[ix];

                }
                 
            }

        }

        private void query_Click(object sender, EventArgs e)

        {
            if (checkvalue == null)
            {
                MessageBox.Show("Please select table");

            }
            else
            {

                rowset = session.Execute("SELECT id,time, alarm, priority, site, object, eventtext, operator, annotation " +
                 "FROM " + keyspace.Text + "." + checkvalue);
                
                update_q();


            }
        }

        private void update_q()
        {
            foreach (Row r in rowset)
            {

                 list = new ListViewItem();
                list.Text = r.GetValue(typeof(String), 0).ToString();
                list.SubItems.Add(r.GetValue(typeof(DateTime), 1).ToString());
                list.SubItems.Add(r.GetValue(typeof(String), 2).ToString());
                list.SubItems.Add(r.GetValue(typeof(String), 3).ToString());
                list.SubItems.Add((String)r.GetValue(typeof(String), 4));
                list.SubItems.Add((String)r.GetValue(typeof(String), 5));
                list.SubItems.Add((String)r.GetValue(typeof(String), 6));
                list.SubItems.Add((String)r.GetValue(typeof(String), 7));
             
                listdata.Items.Add(list);
                listdata.EnsureVisible(listdata.Items.Count - 1);
            }
          
        }

        private void checkedListBox1_SelectedValueChanged(object sender, EventArgs e)
        {
           

        }

        private void CheckBox1_CheckedChanged(Object sender, EventArgs e)
        {

            MessageBox.Show("You are in the CheckBox.CheckedChanged event.");

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Insert_Bt(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbd = new OpenFileDialog();
            String[] items;
    
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    DbPath.Text = fbd.FileName;
                    StreamReader sr = new StreamReader(fbd.FileName);
                    var lines = File.ReadAllLines(DbPath.Text);
                for (var i = 0; i < lines.Length; i += 1)
                {
                    var line = lines[i];
                    items = line.Split(SEP);


                    BoundStatement bs;

                    try
                    {
                        if (i > 0)
                        {
                            // Console.WriteLine("[{0}] - [{1}] - [{2}] -[{3}] -[{4}] - [{5}] - [{6}] - [{7}]", items);
                            CultureInfo provider = CultureInfo.InvariantCulture;
                            string[] format = { "M/d/yyyy h:mm:ss tt", "dd.MM.yy  HH:mm:ss.fff", "dd.MM.yy HH:mm:ss.f" };

                            DateTime newDate;
                            DateTime.TryParseExact(items[0], format, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out newDate);
                            Guid uuid = Guid.NewGuid();
                            bs = ps.Bind(
                                   uuid,
                                   newDate,
                                     items[1],
                                      items[2].ToString(),
                                     items[3],
                                      items[4],
                                      items[5],
                                      items[6],
                                      items[7]);
                            session.Execute(bs);
                        }
                    }
                    catch (InvalidQueryException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                    
               }


                }
              MessageBox.Show("Done");
 

            }

     

        private void listdata_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }


