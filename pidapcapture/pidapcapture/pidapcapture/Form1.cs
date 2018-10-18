using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace pidapcapture
{
    enum msg
    {
        MESSAGE_POLLING = 1,
        NETWORK_ALIVE_STATUS,
        LOAD_DEVICE_STATUS,
        DEVICE_STATUS_BITMAP,
        DEVICE_STATUS_CHANGE,
        SIGNAL_ROUTE_STATUS,
        DEPOT_PLAN,
        TRAIN_RECORD,
        TRAIN_INDICATION_INIT,
        TRAIN_INDICATION_UPDATE,
        TRAIN_INDICATION_REMOVE,
        REPORT_ASK,
        GROUP_RUNNING_REPORT,
        DRIVER_DISTANCE_REPORT,
        DISPATCHER_REPORT,
        GROUP_BAK_REPORT,
        GROUP_STATUS_REPORT,
        ALARM_ASK,
        ACTION_REPORT,
        ALARM_REPORT,
        LOAD_HISTORY_TG_DATA,
        INUSED_SCHEDULE,
        HISTORY_SCHEDULE,
        Resume_ASK,
        Resume_Begin_ACK,
        Resume_END_ACK,
        REPORT_NACK,
        REPORT_BEGIN,
        REPORT_END,
        Resume_DATA
    }
    enum devtype
    {
        DEVICE_TYPE_UNKNOW = 0,
        /// <summary>
        /// Centralized station.
        /// </summary>
        DEVICE_TYPE_RTU = 1,
        /// <summary>
        /// Stations.
        /// </summary>
        DEVICE_TYPE_STATION = 2,
        /// <summary>
        /// Signaling device
        /// </summary>
        DEVICE_TYPE_SIGNAL = 3,
        /// <summary>
        /// Switch.
        /// </summary>
        DEVICE_TYPE_SWITCH = 4,
        /// <summary>
        /// Track.
        /// </summary>
        DEVICE_TYPE_TRACK = 5,
        /// <summary>
        /// Direction.
        /// </summary>
        DEVICE_TYPE_ENTRY = 6,
        /// <summary>
        /// Platform.
        /// </summary>
        DEVICE_TYPE_PLATFORM = 7,
        /// <summary>
        /// Fire Alarm.
        /// </summary>
        DEVICE_TYPE_FAS = 8,
        /// <summary>
        /// Power Supply Section.
        /// </summary>
        DEVICE_TYPE_SCADA = 9,
        /// <summary>
        /// Fans
        /// </summary>
        DEVICE_TYPE_BAS = 10,
        /// <summary>
        /// Flood Door.
        /// </summary>
        DEVICE_TYPE_WATERPROOF_DOOR = 11,
        /// <summary>
        /// The working area.
        /// </summary>
        DEVICE_TYPE_WORK_AREA = 12,
        /// <summary>
        /// Automatic Driving Region.
        /// </summary>
        DEVICE_TYPE_GAMA = 13
    }
    enum definertustatus
    {
        IP_RTU_STUS_DOWN = 32768,
        IP_RTU_STUS_IN_LOCAL_CTRL=1,
        IP_RTU_STUS_IN_CENTRAL_CTRL=2,
        IP_RTU_STUS_IN_EMERGENCY_CTRL=4,
    }
    enum definesignalstatus
    {
        IP_SIGNAL_STUS_RED_OPEN = 1,
IP_SIGNAL_STUS_RED_FLASH = 2,
IP_SIGNAL_STUS_GREEN_OPEN =4,
IP_SIGNAL_STUS_GREEN_FLASH=8,
IP_SIGNAL_STUS_YELLOW_OPEN=16,
IP_SIGNAL_STUS_YELLOW_FLASH=32,
IP_SIGNAL_STUS_WHITE_OPEN=64,
IP_SIGNAL_STUS_WHITE_FLASH=128,
IP_SIGNAL_STUS_BLUE_OPEN=256,
IP_SIGNAL_STUS_BLUE_FLASH=512,
IP_SIGNAL_STUS_FLEET_MODE=65536,
IP_SIGNAL_STUS_AUTO_MODE=262144,
IP_SIGNAL_STUS_EXTINGUISH=1048576,
IP_SIGNAL_STUS_APPROACH_LOCK=2097152,
IP_SIGNAL_STUS_CALLON=16777216,
IP_SIGNAL_STUS_YELLOW_YELLOW=33554432,
IP_SIGNAL_STUS_YELLOW_GREEN=33554432*2
    }
    enum defineswitchstatus
    {
        IP_SINGLE_SWITCH_STUS_CI_OCCUPIED = 2,
IP_SINGLE_SWITCH_STUS_CBTC_OCCUPIED=4,
IP_SINGLE_SWITCH_STUS_LOCKED=8,
IP_SINGLE_SWITCH_STUS_FAIL_LOCKED=16,
IP_SINGLE_SWITCH_STUS_NORMAL=32,
IP_SINGLE_SWITCH_STUS_REVERSE=64,
IP_SINGLE_SWITCH_STUS_BLOCKED=128,
IP_SINGLE_SWITCH_STUS_JAMMED=256,
IP_SINGLE_SWITCH_STUS_CUT= 131072,
IP_SINGLE_SWITCH_STUS_ATC_INVALID = 131072*2,
IP_SINGLE_SWITCH_STUS_OVERLAP = 131072*4,
IP_SINGLE_SWITCH_STUS_TSR_CBTC_MAIN = 131072*8,
IP_SINGLE_SWITCH_STUS_TSR_CBTC_NORMAL = 131072*16,
IP_SINGLE_SWITCH_STUS_TSR_CBTC_REVERSE= 131072*32,
IP_SINGLE_SWITCH_STUS_TSR_BM_MAIN= 131072*64,
IP_SINGLE_SWITCH_STUS_TSR_BM_NORMAL = 131072*128,
IP_SINGLE_SWITCH_STUS_TSR_BM_REVERSE= 131072*256

    }
    enum definetrackstatus
    {
        IP_TRACK_STUS_CI_OCCUPIED = 2,
IP_TRACK_STUS_CBTC_OCCUPIED=4,
IP_TRACK_STUS_LOCKED=8,
IP_TRACK_STUS_FAIL_LOCKED=16,
IP_TRACK_STUS_CUT=256,
IP_TRACK_STUS_ATC_INVALID = 512,
IP_TRACK_STUS_OVERLAP=1024


    }
    enum defineplatformstatus
    {
        IP_PLATFORM_STUS_EMERGSTOP = 1,
IP_PLATFORM_STUS_TRAINBERTH= 2,
IP_PLATFORM_STUS_UP_HOLD= 16,
IP_PLATFORM_STUS_DOWN_HOLD=32,
IP_PLATFORM_STUS_UP_OCC_HOLD=64,
IP_PLATFORM_STUS_DOWN_OCC_HOLD=128,
IP_PLATFORM_STUS_PSD_OPEN=256,
IP_PLATFORM_STUS_PSD_CUT=512,
IP_PLATFORM_STUS_UP_SKIPSTOP=1024,
IP_PLATFORM_STUS_DOWN_SKIPSTOP=2048,
IP_PLATFORM_STUS_UP_TRAIN_SKIPSTOP=4096



    }
    enum outflag
    {
        Not_Out =0,
        Already_Out =1

    }
    enum outschedule
    {
        No =0,
        Yes

    }
    enum inflag
    {
        Not_in = 0,
        Already_in = 1

    }
    enum traintype
    {
        Planned_train =1,
        head_train = 2,
        M0_train =3,
        MM_train = 4

    }
   enum reportid
    {
        TRAIN_GROUP_OPERATION =1,
        DRIVING_MILEAGE_REPORT,
        OPERATION_LOG_REPORT,
        TRAIN_STORAGE_REPORT,
        TRAIN_SERVICE_STATUS_REPORT,
        OPERATION_COMMANDS,
        TRAIN_INFORMATION_EVENTS

    }
    enum groupbakstatus
    {
        ONLINE_OPERATIONS = 1,
        TRAIN_PREPAREATION,
        MAINTENANCE
    }
    enum groupbakdepot
    {
        TRAIN_DEPOT_1 =1,
        PARKING_LOT_1 =2,
        TRAIN_DEPOT_2=4,
        PARKING_LOT_2 =8

    }
    enum groupstatusdepot
    {
        TRAIN_DEPOT = 1,
        MAIN_TRACK,

    }
    enum alarmackmsgtype
    {
        OPERATION_COMMAND = 1,
        TRAIN_INFORMATION = 2

    }
    enum unittype
    {
        STATION = 1,
        CENTER = 2,
        UNKNOW = 0,
    }
    enum operationtype
    {
        ROUTE_CONTROL =1,
        SIGNAL_CONTROL,
        TRAIN_MANAGEMENT,
        SCHEDULE_MANAGEMENT,
        OTHER_COMMAND,

    }
    enum alarmtype
    {
        OPERATION_COMMAND_RELATED_ALARM =1,
        SIGNAL_RELATED_ALARM,
        ROUTE_RELATED_ALARM,
        TRAIN_RELATED_ALARM,
        SYSTEM_EVENTS


    }
    enum tgtype
    {
        PLANNING_CHART=1,
        RUNNING_HISTORY

    }
    enum mode
    {
        IP_MODE_TRAIN_DRIVE_MODE_AM = 1,
        IP_MODE_TRAIN_DRIVE_MODE_CM,
        IP_MODE_TRAIN_DRIVE_MODE_RMF,
        IP_MODE_TRAIN_DRIVE_MODE_DTO,
        IP_MODE_TRAIN_DRIVE_MODE_ATB,
        IP_MODE_TRAIN_DRIVE_BLOCK_AM,
        IP_MODE_TRAIN_DRIVE_BLOCK_CM,


    }
    enum routestatus
    {
        ATS_AUTOMATIC_SIGNAL_MODE = 85,
        NON_ATS_AUTOMATIC_SIGNAL_MODE = 170
    }
    public partial class Form1 : Form
    {
        string IP1select = null;
        string Port1select = null;
        string IP2select = null;
        string Port2select = null;
        string writeframe;
        int msglenremain;
        string completedata;
        static string devname;
        static string signame;
        static string routename;
        List<int> len1 = new List<int>();
        ListViewItem listv = null;
        List<Capdata> list = new List<Capdata>();
        List<selectdata1> datalist1 = new List<selectdata1>();
        List<selectdata2> datalist2 = new List<selectdata2>();
        private static string groupid;
        private string msgtypeja;

        public Form1()
        {

            InitializeComponent();
            listview.FullRowSelect = true;

        }

        private void Read_bt_Click(object sender, EventArgs e)
        {
            string path = "";

            OpenFileDialog fbd = new OpenFileDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                IPlist.Items.Clear();
                IP2list.Items.Clear();
                Port1list.Items.Clear();
                Port2list.Items.Clear();
                listview.Items.Clear();
                Detial_box.Text = "";
                listv = null;
                list.Clear();
                datalist1.Clear();
                datalist2.Clear();
                path = fbd.FileName;
                Filepath.Text = fbd.FileName;
            }
            ICaptureDevice device;

            try
            {
                // Get an offline device
                device = new CaptureFileReaderDevice(path);

                // Open the device
                device.Open();
            }
            catch (Exception eex)
            {
                Console.WriteLine("Caught exception when opening file" + eex.ToString());
                return;
            }
            string filter = "ip and tcp";
            device.Filter = filter;
            // Register our handler function to the 'packet arrival' event
            device.OnPacketArrival +=
                new PacketArrivalEventHandler(device_OnPacketArrival);

            Console.WriteLine();
            Console.WriteLine
                ("-- Capturing from '{0}', hit 'Ctrl-C' to exit...",
                path);

            // Start capture 'INFINTE' number of packets
            // This method will return when EOF reached.
            device.Capture();

            // Close the pcap device
            device.Close();
            Console.WriteLine("-- End of file reached.");
            Console.Write("Hit 'Enter' to exit...");
            Console.ReadLine();


        }
        public class Capdata
        {
            public string datetime { get; set; }
            public string sourceip { get; set; }
            public string sourceport { get; set; }
            public string desip { get; set; }
            public string desport { get; set; }
            public string len { get; set; }
            public string info { get; set; }
            public string direction { get; set; }
            public string systemid { get; set; }

            public string multiflag { get; set; }
            public string msgid { get; set; }
            public byte[] storedt { get; set; }

        }
        public class selectdata1
        {
            public string datetime { get; set; }
            public string sourceip { get; set; }
            public string sourceport { get; set; }
            public string desip { get; set; }
            public string desport { get; set; }
            public string len { get; set; }
            public string info { get; set; }
            public string direction { get; set; }
            public string systemid { get; set; }
            public string multiflag { get; set; }
            public string msgid { get; set; }
            public byte[] storedt { get; set; }

        }
        public class selectdata2
        {
            public string datetime { get; set; }
            public string sourceip { get; set; }
            public string sourceport { get; set; }
            public string desip { get; set; }
            public string desport { get; set; }
            public string len { get; set; }
            public string info { get; set; }
            public string direction { get; set; }
            public string systemid { get; set; }
            public string multiflag { get; set; }
            public string msgid { get; set; }
            public byte[] storedt { get; set; }

        }
        private void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {

            var t = e.Packet.Timeval.Date;
            CultureInfo ci = CultureInfo.InvariantCulture;


            string dt = t.ToString("dd-mm-yy hh:mm:ss.fff", ci);

            var packet = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);

            var tcpPacket = (PacketDotNet.TcpPacket)packet.Extract(typeof(PacketDotNet.TcpPacket));
            if (tcpPacket != null)
            {
                var ipPacket = (PacketDotNet.IpPacket)tcpPacket.ParentPacket;
                System.Net.IPAddress srcIp = ipPacket.SourceAddress;
                System.Net.IPAddress dstIp = ipPacket.DestinationAddress;
                int srcPort = tcpPacket.SourcePort;
                int dstPort = tcpPacket.DestinationPort;
                var data = ipPacket.PayloadPacket.PayloadData;
                var len = ipPacket.PayloadPacket.PayloadData.Length;
                if (ipPacket == null)
                {
                    return;
                }
                if (ipPacket.PayloadPacket == null)
                {
                    return;
                }
                if ((ipPacket.PayloadPacket.PayloadData == null) ||
                    (ipPacket.PayloadPacket.PayloadData.Length < 14))
                {

                    return;
                }

               
                list.Add(new Capdata
                {
                    datetime = dt,
                    sourceip = srcIp.ToString(),
                    sourceport = srcPort.ToString(),
                    desip = dstIp.ToString(),
                    desport = dstPort.ToString(),
                    len = len.ToString(),
                    info = BitConverter.ToString(data).Replace("-", " "),
                    systemid = ipPacket.PayloadPacket.PayloadData[0].ToString(),
                    multiflag = ipPacket.PayloadPacket.PayloadData[3].ToString(),
                    msgid = ipPacket.PayloadPacket.PayloadData[13].ToString(),
                    storedt = data
                });

                if (!IPlist.Items.Contains(list[list.Count - 1].sourceip))
                {
                    IPlist.Items.Add(list[list.Count - 1].sourceip);


                }

                //Console.WriteLine(String.Format("    Sender: {0}:{1}", ipPacket.SourceAddress, tcpPacket.SourcePort));
                //Console.WriteLine(String.Format("  Receiver: {0}:{1}", ipPacket.DestinationAddress, tcpPacket.DestinationPort));
                //Console.WriteLine(" System Id: " + ipPacket.PayloadPacket.PayloadData[0]);
                //Console.WriteLine("Multi-Flag: " + ipPacket.PayloadPacket.PayloadData[3]);
                //Console.WriteLine(" Packet Id: " + ipPacket.PayloadPacket.PayloadData[13]);
                //Console.WriteLine("{0} AT: Len={1} {2}:{3} -> {4}:{5}   = {6}",
                //e.Packet.Timeval.Date.ToString(), len,
                //srcIp, srcPort, dstIp, dstPort, BitConverter.ToString(data).Replace("-", " "));
            }


        }


        private void IPlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item.sourceport);

            //}
            datalist1.Clear();
            datalist2.Clear();
            IP1select = IPlist.SelectedItem.ToString();
            List<Capdata> results = list.FindAll(x => x.sourceip == IP1select);
            IP2list.Items.Clear();
            Port1list.Items.Clear();
            Port2list.Items.Clear();
            foreach (var item in results)
            {

                if (!Port1list.Items.Contains(item.sourceport))
                {

                    Port1list.Items.Add(item.sourceport);

                }

                if (!IP2list.Items.Contains(item.sourceport) && !IP2list.Items.Contains(item.desip))
                {
                    IP2list.Items.Add(item.desip);
                }

                if (!Port2list.Items.Contains(item.sourceport) && !Port2list.Items.Contains(item.desport))
                {
                    Port2list.Items.Add(item.desport);
                }

            }

        }
        private void IP2list_SelectedIndexChanged(object sender, EventArgs e)
        {

            IP2select = IP2list.SelectedItem.ToString();
            List<Capdata> results = list.FindAll(x => x.sourceip == IP2select);
            foreach (var item in results)
            {

            }


        }

        private void Port1list_SelectedIndexChanged(object sender, EventArgs e)
        {
            Port1select = Port1list.SelectedItem.ToString();
            List<Capdata> results = list.FindAll(x => x.sourceport == Port1select);
            List<Capdata> resultdes = list.FindAll(x => x.desport == Port1select);
            IP2list.Items.Clear();
            Port2list.Items.Clear();
            int a = 0;
            foreach (var item in results)
            {
                datalist1.Add(new selectdata1
                {
                    datetime = item.datetime,
                    sourceip = item.sourceip,
                    sourceport = item.sourceport,
                    desip = item.desip,
                    desport = item.desport,
                    len = item.len,
                    info = item.info,
                    direction = "-->",
                    systemid = item.systemid,
                    multiflag = item.multiflag,
                    msgid = item.msgid,
                    storedt = item.storedt

                });

                //Console.WriteLine(datalist[a].len);
                if (!IPlist.Items.Contains(item.sourceip))
                {
                    IPlist.Items.Add(item.sourceip);

                }
                if (!IP2list.Items.Contains(item.desip))
                {
                    IP2list.Items.Add(item.desip);

                }
                if (!Port2list.Items.Contains(item.desport))
                {
                    Port2list.Items.Add(item.desport);

                }
                a++;

            }
            foreach (var item in resultdes)
            {

                datalist1.Add(new selectdata1
                {
                    datetime = item.datetime,
                    sourceip = item.sourceip,
                    sourceport = item.sourceport,
                    desip = item.desip,
                    desport = item.desport,
                    len = item.len,
                    info = item.info,
                    direction = "<--",
                    systemid = item.systemid,
                    multiflag = item.multiflag,
                    msgid = item.msgid,
                    storedt = item.storedt
                });

                //listv = new ListViewItem();
                //listv.Text = item.datetime;
                //listv.SubItems.Add(item.len);
                //listv.SubItems.Add(item.info);
                //listv.SubItems.Add("<--");
                //listview.Items.Add(listv);
            }


        }

        private void Port2list_SelectedIndexChanged(object sender, EventArgs e)
        {

            Port2select = Port2list.SelectedItem.ToString();
            List<Capdata> results = list.FindAll(x => x.sourceport == Port2select);
            List<selectdata1> resultport2sou = datalist1.FindAll(b => b.sourceport == Port2select);
            List<selectdata1> resultport2des = datalist1.FindAll(x => x.desport == Port2select);
            foreach (var item in resultport2sou)
            {
                datalist2.Add(new selectdata2
                {
                    datetime = item.datetime,
                    sourceip = item.sourceip,
                    sourceport = item.sourceport,
                    desip = item.desip,
                    desport = item.desport,
                    len = item.len,
                    info = item.info,
                    direction = "<--",
                    systemid = item.systemid,
                    multiflag = item.multiflag,
                    msgid = item.msgid,
                    storedt = item.storedt


                });

            }
            foreach (var item in resultport2des)
            {
                datalist2.Add(new selectdata2
                {
                    datetime = item.datetime,
                    sourceip = item.sourceip,
                    sourceport = item.sourceport,
                    desip = item.desip,
                    desport = item.desport,
                    len = item.len,
                    info = item.info,
                    direction = "-->",
                    systemid = item.systemid,
                    multiflag = item.multiflag,
                    msgid = item.msgid,
                    storedt = item.storedt


                });

            }
        }

        private void Load_bt_Click(object sender, EventArgs e)
        {
            listview.Items.Clear();
            if (IP1select == null || IP2select == null || Port2select == null || Port1select == null)
            {
                MessageBox.Show("Please select IP/Port completely");
            }
            else
            {
               
                datalist2.Sort((x, y) => x.datetime.CompareTo(y.datetime));
                for (int i = 0; i < datalist2.Count; i++)
                {
                    string conmsg;
                    if (Convert.ToInt32(datalist2[i].msgid) < 31)
                    {
                        msg day = (msg)Convert.ToInt32(datalist2[i].msgid);
                        conmsg = day.ToString();
                        //textBox1.Text = conmsg;
                    }
                    else
                    {
                        conmsg = datalist2[i].msgid;
                    }

                    msg y = (msg)Convert.ToInt32(datalist2[i].msgid);
                    listv = new ListViewItem();
                    listv.Text = datalist2[i].datetime;
                    listv.SubItems.Add(datalist2[i].len);
                    listv.SubItems.Add(datalist2[i].info);
                    listv.SubItems.Add(datalist2[i].direction);
                    listv.SubItems.Add(datalist2[i].systemid);
                    listv.SubItems.Add(datalist2[i].multiflag);
                    listv.SubItems.Add(conmsg);
                    listview.Items.Add(listv);

                }

            }
        
            datalist2.Clear();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listview_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (listview.SelectedItems.Count > 0)
            {
                ListViewItem item = listview.SelectedItems[0];
                msgtypeja = item.SubItems[6].Text;
                int index = listview.Items.IndexOf(item);
                int len = Convert.ToInt32(listview.Items[index].SubItems[1].Text);
                int firstframe = 0;
                string _data = item.SubItems[2].Text;
                string[] words = _data.Split(' ');
                string checkflag = listview.Items[index].SubItems[5].Text;
                Console.WriteLine(checkflag);
                int compress = Convert.ToInt16(words[3]);
                int count = 0;
                int msgflagnext = 0;
                writeframe = "";
                string remaindata = "";
                if (compress == 1)
                {
                 if(firstframe == 0)
                  {
                        if (words.Length > 1028)
                        {
                            for (int i = 0; i < 1028; i++)
                            {

                                remaindata += words[i] + " ";

                            }
                            msgflagnext = Convert.ToInt32(words[1028 + 3]);
                            for (int i = 1028 + 4; i < words.Length; i++)
                            {
                                remaindata += words[i] + " ";
                                count++;
                            }
                            firstframe = 1;
                           
                            writeframe += remaindata;
                        }
                        else
                        {
                            firstframe = 1;
                            writeframe += _data + " ";
                            msgflagnext = 1;
                        }
                  }
                 else
                  {
                        
                  }
                    while (msgflagnext ==1 )
                    {
                         remaindata = "";
                        _data = "";
                        words = null;
                       
                        _data = listview.Items[++index].SubItems[2].Text;
                        words = _data.Split(' ');
                       var remainlen = listview.Items[index].SubItems[1].Text;
                        if (Convert.ToInt32(remainlen) > 1028)
                        {
                         
                            for (int i = 4; i < 1028; i++)
                            {

                                remaindata += words[i] + " ";
                                
                            }
                            msgflagnext = Convert.ToInt32(words[1028 + 3]);
                            if(count >= 1024)
                            {
                                count = 0;
                            }
                            for (int i = 1028+4; i< Convert.ToInt32(remainlen) ;i++)
                            {
                                remaindata += words[i] + " ";
                                count++;
                            }
                            writeframe += remaindata;
                            
                        }
                        else
                        {
                            
                            if (count < 1024 && count != 0)
                            {
                              
                                writeframe += _data + " ";
                               count += Convert.ToInt32(listview.Items[index].SubItems[1].Text);
                               
                            }
                            else if (count == 1024)
                            {
                                msgflagnext = Convert.ToInt32(words[3]);
                            
                                for (int i = 4; i < Convert.ToInt16(remainlen); i++)
                                {
                                     remaindata += words[i] + " ";
                                
                                }
                                writeframe += remaindata;
                                count = 0;
                            }
                            else
                            {
                              
                                msgflagnext = Convert.ToInt32(words[3]);
                                for (int i = 4; i < Convert.ToInt16(remainlen); i++)
                                {
                                    remaindata += words[i] + " ";

                                }
                                writeframe += remaindata;
                                count = 0;

                            }
                            
                        }
                        
                        
                    }
               
                  
                }
                else
                {

                         writeframe = _data + " ";

                }

                completedata = writeframe;
                firstframe = 0;
                count = 0;
                writeframe = "";
            }
                else
                {

              


                }
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine(completedata);
            Console.WriteLine("------------------------------------------------------------");
            Encode endata = new Encode();
            string showdata = endata.encodeall(completedata,msgtypeja);
            Detial_box.Text = showdata;


        }

        class Encode
        {
            private static string devname;
            private static string groupid;
            private int id;

            public string encodeall(string data, string msgtype)
            {

                string[] words = data.Split(' ');
                Console.WriteLine(data);
                StringBuilder builder = new StringBuilder();

                StringBuilder append = Basemessage(words, builder);
                int pos = 0;

                if (msgtype == msg.MESSAGE_POLLING.ToString())
                {
                    // return append.ToString();
                }
                else if (msgtype == msg.NETWORK_ALIVE_STATUS.ToString())
                {

                    string lineid = Getbyte2(words, 13);
                    string status = Int32.Parse(words[16], System.Globalization.NumberStyles.HexNumber).ToString();
                    append.Append("lineid:" + lineid + Environment.NewLine + "status:" + status);

                }

                else if (msgtype == msg.LOAD_DEVICE_STATUS.ToString())
                {
                    string lineid = Getbyte2(words, 13);
                    append.Append("lineid:" + lineid);

                }
                else if (msgtype == msg.DEVICE_STATUS_BITMAP.ToString())
                {
                    int posloop1 = 13;
                    string lineid = Getbyte2(words, posloop1);
                    posloop1 += 2;

                    string rtuid = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    string typecnt = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    append.Append("lineid:" + lineid + Environment.NewLine + "rtuid:" + rtuid + Environment.NewLine + "typecnt:" + typecnt +
                    Environment.NewLine);
                    append = (Endevname(words, append, posloop1, Convert.ToInt32(typecnt)));
                    //string type = Getbyte2(words, 19);
                    //devtype _devtype = (devtype)Convert.ToInt32(type);
                    //string devtupe = _devtype.ToString();
                    //string obj_count = Getbyte2(words, 21);





                }
                else if (msgtype == msg.DEVICE_STATUS_CHANGE.ToString())
                {

                    int posloop1 = 13;
                    string lineid = Getbyte2(words, posloop1);
                    posloop1 += 2;

                    string rtuid = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    string type = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    devtype _devtype = (devtype)Convert.ToInt32(type);
                    string devtupe = _devtype.ToString();
                    append.Append("lineid:" + lineid + Environment.NewLine + "rtuid:" + rtuid + Environment.NewLine + "type:" + type + Environment.NewLine + "devtype:" + devtupe + Environment.NewLine);
                    string devname = unicode(words, posloop1, 24);
                    posloop1 += 24;

                    string devicestatus = Getbyte4(words, posloop1);
                    posloop1 += 4;
                    append.Append("devname:" + devname + Environment.NewLine + "devicestatus :" + devicestatus + Environment.NewLine);


                }
                else if (msgtype == msg.SIGNAL_ROUTE_STATUS.ToString())
                {
                    /// ask p'new/p'bright for make sure ///
                    string lineid = Getbyte2(words, 13);
                    string rtuid = Getbyte2(words, 15);
                    string signal_count = Getbyte2(words, 17);
                    append.Append("lineid:" + lineid + Environment.NewLine + "rtuid:" + rtuid + Environment.NewLine + "signal_count:" + signal_count + Environment.NewLine);
                    append = (Ensignalname(words, append, 19, Convert.ToInt32(signal_count)));

                }

                else if (msgtype == msg.DEPOT_PLAN.ToString())
                {
                    string lineid = Getbyte2(words, 13);

                    string date1 = date(words, 15);
                    string depot_count = Getbyte2(words, 22);
                    append.Append("lineid:" + lineid + Environment.NewLine + "date:" + date1 + Environment.NewLine + "depot_count:" + depot_count + Environment.NewLine);
                    append = Endepot(words, append, 24, Convert.ToInt32(depot_count));



                }
                else if (msgtype == msg.TRAIN_RECORD.ToString())
                {
                    pos = 13;
                    string lineid = Getbyte2(words, pos);
                    pos += 2;
                    string trainid = unicode(words, pos, 9);
                    pos += 9;
                    string globalid = unicode(words, pos, 12);
                    pos += 12;
                    string localsubid = "0000";
                    pos += 4;
                    string groupid = unicode(words, pos, 9);
                    pos += 9;
                    string destinationid = Getbyte4(words, pos);
                    pos += 4;
                    string traintype = Getbyte2(words, pos);
                    pos += 2;
                    string dir = Int32.Parse(words[++pos], System.Globalization.NumberStyles.HexNumber).ToString();
                    string stationid = Getbyte2(words, pos);
                    pos += 2;
                    string sideid = Getbyte2(words, pos);
                    pos += 2;
                    string trackname = unicode(words, pos, 20);
                    pos += 20;
                    string recordtype = Getbyte2(words, pos);
                    pos += 2;
                    string recordtime = date(words, pos);
                    append.Append("lineid:" + lineid + Environment.NewLine);
                    append.Append("trainid:" + trainid + Environment.NewLine);
                    append.Append("globalid:" + globalid + Environment.NewLine);
                    append.Append("localsubid:" + localsubid + Environment.NewLine);
                    append.Append("groupid:" + groupid + Environment.NewLine);
                    append.Append("destinationid:" + destinationid + Environment.NewLine);
                    append.Append("traintype :" + traintype + Environment.NewLine);
                    append.Append("direction:" + dir + Environment.NewLine);
                    append.Append("stationid:" + stationid + Environment.NewLine);
                    append.Append("sideid :" + sideid + Environment.NewLine);
                    append.Append("trackname:" + trackname + Environment.NewLine);
                    append.Append("recordtype:" + recordtype + Environment.NewLine);
                    append.Append("recordtime:" + recordtime + Environment.NewLine);


                }

                else if (msgtype == msg.TRAIN_INDICATION_INIT.ToString())
                {
                    string lineid = Getbyte2(words, 13);
                    string traincount = Getbyte2(words, 15);
                    append.Append("lineid:" + lineid + Environment.NewLine + "traincount:" + traincount + Environment.NewLine);
                    append = Entrainint(words, append, 17, Convert.ToInt32(traincount));

                }
                else if (msgtype == msg.TRAIN_INDICATION_UPDATE.ToString())
                {
                    string lineid = Getbyte2(words, 13);
                    string traincount = Getbyte2(words, 15);
                    append.Append("lineid:" + lineid + Environment.NewLine + "traincount:" + traincount + Environment.NewLine);
                    append = Entrainint(words, append, 17, Convert.ToInt32(traincount));

                }
                else if (msgtype == msg.TRAIN_INDICATION_REMOVE.ToString())
                {
                    int posloop = 13;
                    string lineid = Getbyte2(words, 13);
                    posloop += 2;
                    append.Append("lineid:" + lineid + Environment.NewLine);

                    string rtuid = Getbyte2(words, posloop);
                    posloop += 2;
                    append.Append("rtuid:" + rtuid + Environment.NewLine);
                    string window = Getbyte2(words, posloop);
                    posloop += 2;
                    append.Append("window:" + window + Environment.NewLine);
                    string windowoffset = Int32.Parse(words[++posloop], System.Globalization.NumberStyles.HexNumber).ToString();
                    append.Append("windowoffset:" + windowoffset + Environment.NewLine);
                    string devtype = Getbyte2(words, posloop);
                    posloop += 2;
                    append.Append("devtype:" + devtype + Environment.NewLine);
                    string devname = unicode(words, posloop, 24);
                    posloop += 24;
                    append.Append("devname:" + devname + Environment.NewLine);
                    string trainindex = unicode(words, posloop, 10);
                    posloop += 10;
                    append.Append("trainindex:" + trainindex + Environment.NewLine);
                    string groupid = unicode(words, posloop, 9);
                    posloop += 9;

                }
                else if (msgtype == msg.REPORT_ASK.ToString())
                {
                    //string[] da= {"FF", "0", "1F", "0", "0", "1C", "0", "0", "0", "0", "0", "1", "0", "12", "0", "2", "0", "1", "0", "1", "14", "12", "5", "7", "0", "0", "0", "0", "0", "0", "0", "0", "0","0"};
                    int posloop1 = 13;
                    string lineid1 = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    string reportid1 = id++.ToString();
                    posloop1 += 2;
                    string msgflag = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    string msgcontent = "";


                    msgcontent = date(words, posloop1);



                    reportid _msgflag = (reportid)Convert.ToInt32(msgflag);
                    msgflag = _msgflag.ToString();
                    append.Append("lineid:" + lineid1 + Environment.NewLine);
                    append.Append("reportid:" + reportid1 + Environment.NewLine);
                    append.Append(" msgflag:" + msgflag + Environment.NewLine);
                    append.Append("msgcontent :" + msgcontent + Environment.NewLine);


                }
                else if (msgtype == msg.REPORT_BEGIN.ToString())
                {
                    int posloop1 = 13;
                    string lineid1 = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    string reportid1 = id++.ToString();
                    posloop1 += 2;
                    string reporttype = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    reportid _reporttype = (reportid)Convert.ToInt32(reporttype);
                    reporttype = _reporttype.ToString();
                    append.Append("lineid:" + lineid1 + Environment.NewLine);
                    append.Append("reportid:" + reportid1 + Environment.NewLine);
                    append.Append("reporttype:" + reporttype + Environment.NewLine);


                }
                else if (msgtype == msg.REPORT_END.ToString())
                {
                    int posloop1 = 13;
                    string lineid1 = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    string reportid1 = id++.ToString();
                    posloop1 += 2;
                    string reporttype = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    reportid _reporttype = (reportid)Convert.ToInt32(reporttype);
                    reporttype = _reporttype.ToString();
                    append.Append("lineid:" + lineid1 + Environment.NewLine);
                    append.Append("reportid:" + reportid1 + Environment.NewLine);
                    append.Append("reporttype:" + reporttype + Environment.NewLine);



                }
                else if (msgtype == msg.GROUP_RUNNING_REPORT.ToString())
                {
                    int posloop1 = 13;
                    append = Basequery(words, append);
                    posloop1 += 8;
                    string count = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    append.Append("count:" + count + Environment.NewLine);
                    append = Engrouprunning(words, append, posloop1, Convert.ToInt32(count));



                }
                else if (msgtype == msg.DRIVER_DISTANCE_REPORT.ToString())
                {
                    int posloop1 = 13;
                    append = Basequery(words, append);
                    posloop1 += 8;
                    string count = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    append.Append("count:" + count + Environment.NewLine);
                    for (int i = 0; i < Convert.ToInt32(count); i++)
                    {
                        string _date = date(words, posloop1);
                        posloop1 += 7;
                        string driverid = unicode(words, posloop1, 13);
                        posloop1 += 13;
                        string distance = Getbyte4(words, posloop1);
                        posloop1 += 4;
                        append.Append("date :" + _date + Environment.NewLine);
                        append.Append("driverid:" + driverid + Environment.NewLine);
                        append.Append("distance:" + distance + Environment.NewLine);

                    }



                }
                else if (msgtype == msg.DISPATCHER_REPORT.ToString())
                {
                    int posloop1 = 13;
                    append = Basequery(words, append);
                    posloop1 += 8;
                    string count = Getbyte2(words, posloop1);
                    posloop1 += 2;

                    append.Append("count:" + count + Environment.NewLine);
                    for (int i = 0; i < Convert.ToInt32(count); i++)
                    {
                        string _date = date(words, posloop1);
                        posloop1 += 7;
                        string username = unicode(words, posloop1, 32);
                        posloop1 += 32;
                        string logitem = unicode(words, posloop1, 256);
                        posloop1 += 256;
                        append.Append("report time:" + _date + Environment.NewLine);
                        append.Append("driverid:" + username + Environment.NewLine);
                        append.Append("distance:" + logitem + Environment.NewLine);

                    }



                }
                else if (msgtype == msg.GROUP_BAK_REPORT.ToString())
                {

                    int posloop1 = 13;
                    append = Basequery(words, append);
                    posloop1 += 8;
                    string count = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    append.Append("count:" + count + Environment.NewLine);
                    for (int i = 0; i < Convert.ToInt32(count); i++)
                    {
                        string groupid = unicode(words, posloop1, 9);
                        posloop1 += 9;
                        string status = Int32.Parse(words[++posloop1], System.Globalization.NumberStyles.HexNumber).ToString();
                        groupbakstatus _status = (groupbakstatus)Convert.ToInt32(status);
                        status = _status.ToString();

                        string depot = Int32.Parse(words[++posloop1], System.Globalization.NumberStyles.HexNumber).ToString();
                        groupbakdepot _depot = (groupbakdepot)Convert.ToInt32(depot);
                        depot = _depot.ToString();
                        string trackname = unicode(words, posloop1, 20);
                        posloop1 += 20;
                        append.Append("groupid:" + groupid + Environment.NewLine);
                        append.Append("status:" + status + Environment.NewLine);
                        append.Append("depot:" + depot + Environment.NewLine);
                        append.Append("trackname:" + trackname + Environment.NewLine);

                    }
                }
                else if (msgtype == msg.GROUP_STATUS_REPORT.ToString())
                {

                    int posloop1 = 13;
                    append = Basequery(words, append);
                    posloop1 += 8;
                    string count = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    append.Append("count:" + count + Environment.NewLine);
                    for (int i = 0; i < Convert.ToInt32(count); i++)
                    {
                        string groupid = unicode(words, posloop1, 9);
                        posloop1 += 9;

                        string depot = Int32.Parse(words[++posloop1], System.Globalization.NumberStyles.HexNumber).ToString();
                        groupstatusdepot _depot = (groupstatusdepot)Convert.ToInt32(depot);
                        depot = _depot.ToString();
                        string status = unicode(words, posloop1, 42);
                        posloop1 += 42;
                        append.Append("groupid:" + groupid + Environment.NewLine);
                        append.Append("depot:" + depot + Environment.NewLine);
                        append.Append("status:" + status + Environment.NewLine);

                    }

                }
                else if (msgtype == msg.ALARM_ASK.ToString())
                {
                    int posloop1 = 13;
                    string lineid1 = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    string reportid1 = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    posloop1 += 1;
                    string _msgtype = Int32.Parse(words[++posloop1], System.Globalization.NumberStyles.HexNumber).ToString();
                    alarmackmsgtype msg_type = (alarmackmsgtype)Convert.ToInt32(_msgtype);
                    _msgtype = msg_type.ToString();
                    string starttime = date(words, posloop1);
                    posloop1 += 7;
                    string endtime = date(words, posloop1);
                    posloop1 += 7;
                    append.Append("lineid1:" + lineid1 + Environment.NewLine);
                    append.Append("reportid1:" + reportid1 + Environment.NewLine);
                    append.Append("msgtype:" + _msgtype + Environment.NewLine);
                    append.Append("starttime:" + starttime + Environment.NewLine);
                    append.Append("endtime:" + endtime + Environment.NewLine);

                }
                else if (msgtype == msg.ACTION_REPORT.ToString())
                {
                    int posloop1 = 13;
                    append = Basequery(words, append);
                    posloop1 += 8;
                    string count = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    append.Append("count:" + count + Environment.NewLine);
                    for (int i = 0; i < Convert.ToInt32(count); i++)
                    {
                        string actionsite = Int32.Parse(words[++posloop1], System.Globalization.NumberStyles.HexNumber).ToString();
                        unittype _actionsite = (unittype)Convert.ToInt32(actionsite);
                        actionsite = _actionsite.ToString();
                        string actionsiteid = Getbyte2(words, posloop1);
                        posloop1 += 2;
                        string actionname = unicode(words, posloop1, 20);
                        posloop1 += 20;
                        string actiontime = date(words, posloop1);
                        posloop1 += 7;
                        string actionuser = unicode(words, posloop1, 20);
                        posloop1 += 20;
                        string actiontype = Getbyte2(words, posloop1);
                        operationtype _actiontype = (operationtype)Convert.ToInt32(actiontype);
                        actiontype = _actiontype.ToString();
                        posloop1 += 2;
                        string actionsubtype = Getbyte2(words, posloop1);
                        posloop1 += 2;
                        string actionlen = Getbyte2(words, posloop1);
                        posloop1 += 2;
                        string actioncontent = unicode(words, posloop1, Convert.ToInt32(actionlen));
                        posloop1 += Convert.ToInt32(actionlen);
                        append.Append("actionsite:" + actionsite + Environment.NewLine);
                        append.Append("actionsiteid:" + actionsiteid + Environment.NewLine);
                        append.Append("actionname:" + actionname + Environment.NewLine);
                        append.Append("actiontime:" + actiontime + Environment.NewLine);
                        append.Append("actionuser:" + actionuser + Environment.NewLine);
                        append.Append("actiontype:" + actiontype + Environment.NewLine);
                        append.Append("actionsubtype:" + actionsubtype + Environment.NewLine);
                        append.Append("actionlen:" + actionlen + Environment.NewLine);
                        append.Append("actioncontent:" + actioncontent + Environment.NewLine);



                    }



                }
                else if (msgtype == msg.ALARM_REPORT.ToString())
                {
                    int posloop1 = 13;
                    append = Basequery(words, append);
                    posloop1 += 8;
                    string count = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    append.Append("count:" + count + Environment.NewLine);
                    for (int i = 0; i < Convert.ToInt32(count); i++)
                    {
                        string alarmsite = Int32.Parse(words[++posloop1], System.Globalization.NumberStyles.HexNumber).ToString();
                        unittype _alarmsite = (unittype)Convert.ToInt32(alarmsite);
                        alarmsite = _alarmsite.ToString();
                        string alarmsiteid = Getbyte2(words, posloop1);
                        posloop1 += 2;
                        string alarmname = unicode(words, posloop1, 20);
                        posloop1 += 20;
                        string alarmtime = date(words, posloop1);
                        posloop1 += 7;
                        string alarmtype = Getbyte2(words, posloop1);
                        alarmtype _alarmtype = (alarmtype)Convert.ToInt32(alarmtype);
                        alarmtype = _alarmtype.ToString();
                        posloop1 += 2;
                        string alarmsubtype = Getbyte2(words, posloop1);
                        posloop1 += 2;
                        string alarmlen = Getbyte2(words, posloop1);
                        posloop1 += 2;
                        string alarmcontent = unicode(words, posloop1, Convert.ToInt32(alarmlen));
                        posloop1 += Convert.ToInt32(alarmlen);
                        string alarmacksiteid = Getbyte2(words, posloop1);
                        posloop1 += 2;
                        string alarmacksite = unicode(words, posloop1, 32);
                        posloop1 += 32;
                        string alarmackname = unicode(words, posloop1, 32);
                        posloop1 += 32;
                        string alarmacktime = date(words, posloop1);
                        posloop1 += 7;
                        append.Append("alarmsite:" + alarmsite + Environment.NewLine);
                        append.Append("alarmsiteid:" + alarmsiteid + Environment.NewLine);
                        append.Append("alarmname:" + alarmname + Environment.NewLine);
                        append.Append("alarmtime:" + alarmtime + Environment.NewLine);
                        append.Append("alarmtype:" + alarmtype + Environment.NewLine);
                        append.Append("alarmsubtype:" + alarmsubtype + Environment.NewLine);
                        append.Append("alarmlen:" + alarmlen + Environment.NewLine);
                        append.Append("alarmcontent:" + alarmcontent + Environment.NewLine);
                        append.Append("alarmacksiteid:" + alarmacksiteid + Environment.NewLine);
                        append.Append("alarmacksite:" + alarmacksite + Environment.NewLine);
                        append.Append("alarmackname:" + alarmackname + Environment.NewLine);
                        append.Append("alarmacktime:" + alarmacktime + Environment.NewLine);

                    }
                }
                else if (msgtype == msg.REPORT_NACK.ToString())
                {
                    int posloop1 = 13;
                    string lineid1 = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    string reportid1 = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    string result = Getbyte4(words, posloop1);
                    posloop1 += 4;
                    string content = unicode(words, posloop1, 50);
                    append.Append("lineid1:" + lineid1 + Environment.NewLine);
                    append.Append("reportid1:" + reportid1 + Environment.NewLine);
                    append.Append("result:" + result + Environment.NewLine);
                    append.Append("content:" + content + Environment.NewLine);




                }
                else if (msgtype == msg.LOAD_HISTORY_TG_DATA.ToString())
                {
                    int posloop1 = 13;
                    string lineid1 = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    string _date = date(words, posloop1);
                    posloop1 += 7;
                    string tg_type = Int32.Parse(words[++posloop1], System.Globalization.NumberStyles.HexNumber).ToString();
                    tgtype _tgtype = (tgtype)Convert.ToInt32(tg_type);
                    tg_type = _tgtype.ToString();
                    append.Append("lineid1:" + lineid1 + Environment.NewLine);
                    append.Append("date:" + _date + Environment.NewLine);
                    append.Append(" tgtype:" + tg_type + Environment.NewLine);



                }
                else if (msgtype == msg.INUSED_SCHEDULE.ToString())
                {
                    int posloop1 = 13;
                    string lineid1 = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    string _date = date(words, posloop1);
                    posloop1 += 7;
                    string subid = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    append.Append("lineid1:" + lineid1 + Environment.NewLine);
                    append.Append("date:" + _date + Environment.NewLine);
                    append.Append("subid:" + subid + Environment.NewLine);


                    if (Convert.ToInt32(subid) == 1)
                    {

                    }
                    else if (Convert.ToInt32(subid) == 2)
                    {
                        string trainid = unicode(words, posloop1, 9);
                        posloop1 += 9;
                        string tripcount = Getbyte2(words, posloop1);
                        posloop1 += 2;
                        append.Append("trainid:" + trainid + Environment.NewLine);
                        append.Append("tripcount:" + tripcount + Environment.NewLine);

                        for (int i = 0; i < Convert.ToInt32(tripcount); i++)
                        {
                            string globalid = unicode(words, posloop1, 12);
                            posloop1 += 12;
                            string groupid = unicode(words, posloop1, 9);
                            posloop1 += 9;
                            string destinationid = Getbyte4(words, posloop1);
                            posloop1 += 4;
                            string reccount = Getbyte2(words, posloop1);
                            posloop1 += 2;
                            append.Append("globalid:" + globalid + Environment.NewLine);
                            append.Append("groupid:" + groupid + Environment.NewLine);
                            append.Append("destinationid:" + destinationid + Environment.NewLine);
                            append.Append("reccount:" + reccount + Environment.NewLine);
                            for (int a = 0; a < Convert.ToInt32(reccount); a++)
                            {
                                string stationid = Getbyte2(words, posloop1);
                                posloop1 += 2;
                                string platformid = Getbyte2(words, posloop1);
                                posloop1 += 2;
                                string arrivaltime = date(words, posloop1);
                                posloop1 += 7;
                                string departtime = date(words, posloop1);
                                posloop1 += 7;
                                string flag = Getbyte2(words, posloop1);
                                posloop1 += 2;
                                string spare = Getbyte4(words, posloop1);
                                posloop1 += 4;
                                append.Append("stationid:" + stationid + Environment.NewLine);
                                append.Append("platformid:" + platformid + Environment.NewLine);
                                append.Append("arrivaltime:" + arrivaltime + Environment.NewLine);
                                append.Append("departtime:" + departtime + Environment.NewLine);
                                append.Append("flag:" + flag + Environment.NewLine);
                                append.Append("spare:" + spare + Environment.NewLine);

                            }


                        }


                    }
                    else if (Convert.ToInt32(subid) == 3)
                    {


                    }


                }
                else if (msgtype == msg.HISTORY_SCHEDULE.ToString())
                {
                    int posloop1 = 13;
                    string lineid1 = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    string _date = date(words, posloop1);
                    posloop1 += 7;
                    string subid = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    append.Append("lineid1:" + lineid1 + Environment.NewLine);
                    append.Append("date:" + _date + Environment.NewLine);
                    append.Append("subid:" + subid + Environment.NewLine);


                    if (Convert.ToInt32(subid) == 1)
                    {

                    }
                    else if (Convert.ToInt32(subid) == 2)
                    {
                        string groupid = unicode(words, posloop1, 9);
                        posloop1 += 9;
                        string reccount = Getbyte2(words, posloop1);
                        posloop1 += 2;

                        append.Append("groupid:" + groupid + Environment.NewLine);

                        append.Append("reccount:" + reccount + Environment.NewLine);
                        for (int a = 0; a < Convert.ToInt32(reccount); a++)
                        {
                            string stationid = Getbyte2(words, posloop1);
                            posloop1 += 2;
                            string platformid = Getbyte2(words, posloop1);
                            posloop1 += 2;
                            string arrivaltime = date(words, posloop1);
                            posloop1 += 7;
                            string departtime = date(words, posloop1);
                            posloop1 += 7;
                            string flag = Getbyte2(words, posloop1);
                            posloop1 += 2;
                            string serviceid = unicode(words, posloop1, 9);
                            posloop1 += 9;
                            string globalid = unicode(words, posloop1, 12);
                            posloop1 += 12;
                            string destinationid = Getbyte4(words, posloop1);
                            posloop1 += 4;
                            string type = Getbyte2(words, posloop1);
                            posloop1 += 2;
                            if (Convert.ToInt32(type) == 0)
                            {
                                type = "NON_SCHEDULED_TRAIN";
                            }
                            else
                            {
                                type = "SCHEDULED_TRAIN";
                            }
                            string spare = Getbyte4(words, posloop1);
                            posloop1 += 4;
                            append.Append("stationid:" + stationid + Environment.NewLine);
                            append.Append("platformid:" + platformid + Environment.NewLine);
                            append.Append("arrivaltime:" + arrivaltime + Environment.NewLine);
                            append.Append("departtime:" + departtime + Environment.NewLine);
                            append.Append("flag:" + flag + Environment.NewLine);
                            append.Append("trainid:" + serviceid + Environment.NewLine);
                            append.Append("globalid:" + globalid + Environment.NewLine);
                            append.Append("destinationid:" + destinationid + Environment.NewLine);
                            append.Append("type :" + type + Environment.NewLine);
                            append.Append("spare:" + spare + Environment.NewLine);
                        }

                    }
                    else if (Convert.ToInt32(subid) == 3)
                    {

                    }
                }
                else if (msgtype == msg.Resume_ASK.ToString())
                {
                    int posloop1 = 13;
                    string lineid1 = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    string begintime = date(words, posloop1);
                    posloop1 += 7;
                    string endtime = date(words, posloop1);
                    posloop1 += 7;

                    append.Append("lineid:" + lineid1 + Environment.NewLine);
                    append.Append("begintime:" + begintime + Environment.NewLine);
                    append.Append("endtime:" + endtime + Environment.NewLine);

                }
                else if (msgtype == msg.Resume_Begin_ACK.ToString() || msgtype == msg.Resume_END_ACK.ToString())
                {

                    int posloop1 = 13;
                    string lineid1 = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    string begintime = date(words, posloop1);
                    posloop1 += 7;
                    string endtime = date(words, posloop1);
                    posloop1 += 7;

                    append.Append("lineid:" + lineid1 + Environment.NewLine);
                    append.Append("begintime:" + begintime + Environment.NewLine);
                    append.Append("endtime:" + endtime + Environment.NewLine);


                }
                else if (msgtype == msg.Resume_DATA.ToString())
                {
                    int posloop1 = 13;
                    string lineid1 = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    string totalmessage = Getbyte2(words, posloop1);
                    posloop1 += 2;
                    int messagesequence = 1;
                    for (int a = 0; a < Convert.ToInt32(totalmessage); a++)
                    {
                       
                        posloop1 += 2;
                        string msgcount = Getbyte2(words, posloop1);
                        posloop1 += 2;
                        append = Baseresumedata(words, append,posloop1);

                        messagesequence++;
                    }

                    


                }
               

                    return append.ToString();
            }



        }
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        public static StringBuilder Basemessage(string[] words, StringBuilder builder)
        {

            int pos = 0;

            string systemid = Int32.Parse(words[pos], System.Globalization.NumberStyles.HexNumber).ToString();
            string ttlen = Int32.Parse(words[pos + 1] + words[pos + 2], System.Globalization.NumberStyles.HexNumber).ToString();
            string multi = Int32.Parse(words[pos + 3], System.Globalization.NumberStyles.HexNumber).ToString();
            string msglen = Int32.Parse(words[pos + 4] + words[pos + 5], System.Globalization.NumberStyles.HexNumber).ToString();
            string time = Int32.Parse(words[pos + 6] + words[pos + 7] + words[pos + 8] + words[pos + 9], System.Globalization.NumberStyles.HexNumber).ToString();
            string version = Int32.Parse(words[pos + 10] + words[pos + 11], System.Globalization.NumberStyles.HexNumber).ToString();
            string msgid = Int32.Parse(words[pos + 12] + words[pos + 13], System.Globalization.NumberStyles.HexNumber).ToString();
            msg day = (msg)Convert.ToInt32(msgid);
            string msgidtf = day.ToString();

            builder.Append("system id:" + systemid + Environment.NewLine + "totallength:" + ttlen + Environment.NewLine + "multi-flag:" + multi + Environment.NewLine);
            builder.Append("msglen:" + msglen + Environment.NewLine + "time:" + time + Environment.NewLine + "version" + version + Environment.NewLine + "message id:" + msgidtf + Environment.NewLine);
            return builder;

        }
        public static StringBuilder Baseresumedata(string[] words, StringBuilder builder,int pos)
        {
            int posloop = pos;

            string systemid = Int32.Parse(words[++posloop], System.Globalization.NumberStyles.HexNumber).ToString();
            string ttlen = Getbyte2(words, posloop);
            posloop += 2;
            string multi = Int32.Parse(words[++posloop], System.Globalization.NumberStyles.HexNumber).ToString();
            string msglen = Getbyte2(words, posloop);
            posloop += 2;
            string time = Getbyte4(words, posloop);
            posloop += 4;
            string version = Getbyte2(words, posloop);
            posloop += 2;
            string msgid = Getbyte2(words, posloop);
            posloop += 2;
            msg day = (msg)Convert.ToInt32(msgid);
            string msgidtf = day.ToString();
            builder.Append("system id:" + systemid + Environment.NewLine + "totallength:" + ttlen + Environment.NewLine + "multi-flag:" + multi + Environment.NewLine);
            builder.Append("msglen:" + msglen + Environment.NewLine + "time:" + time + Environment.NewLine + "version" + version + Environment.NewLine + "message id:" + msgidtf + Environment.NewLine);
            Encode endata = new Encode();
            string sentdata = "";
            for(int i = 0;i < words.Length;i++)
            {
                sentdata += words[i] + " ";

            }
            string showdata = endata.encodeall(sentdata, msgidtf);
            builder.Append(showdata);

            return builder;
        }
            public static StringBuilder Basequery(string[] words, StringBuilder builder)
        {
            int posloop1 = 13;
            string lineid1 = Getbyte2(words, posloop1);
            posloop1 += 2;
            string reportid1 = Getbyte2(words, posloop1);
            posloop1 += 2;
            string totalmessage = Getbyte2(words, posloop1);
            posloop1 += 2;
            string messagesequence = Getbyte2(words, posloop1);
            posloop1 += 2;

            builder.Append("lineid:" + lineid1 + Environment.NewLine);
            builder.Append("reportid:" + reportid1 + Environment.NewLine);
            builder.Append("totalmessage:" + totalmessage + Environment.NewLine);
            builder.Append("messagesequence:" + messagesequence + Environment.NewLine);
           
            return builder;
        }
        public static string Getbyte2(string[] words, int position)
        {
            int pos = position;
            string re = words[++pos];
            re += words[++pos];

            string getbyte= Int32.Parse(re, System.Globalization.NumberStyles.HexNumber).ToString();
            return getbyte;

        }

        public static string Getbyte4(string[] words, int position)
        {
            int pos = position;
            string re = words[++pos];
            re += words[++pos];
            re += words[++pos];
            re += words[++pos];
            string getbyte = Int32.Parse(re, System.Globalization.NumberStyles.HexNumber).ToString();
            return getbyte;

        }
        public static StringBuilder Endevname (string[] words,StringBuilder append,int position,int typecount)
        {
            int posloop = position;
            int count = typecount;
            for (int k = 0; k < count; k++)
            {
                string type = Getbyte2(words, posloop);
                posloop += 2;
                devtype _devtype = (devtype)Convert.ToInt32(type);
                string devtupe = _devtype.ToString();
                string obj_count = Getbyte2(words, posloop);
                string define = "";
                posloop += 2;
                append.Append("devtype:" + devtupe + Environment.NewLine + "object count:" + obj_count + Environment.NewLine);
                for (int j = 0; j < Convert.ToInt32(obj_count); j++)
                {
                    if (posloop + 24 < words.Length)
                    {
                        devname = unicode(words, posloop, 24);
                        posloop += 24;
                        Console.WriteLine(devname);

                        string status = Getbyte4(words, posloop);

                        posloop += 4;
                        if (Convert.ToInt32(type) == 1)
                        {
                            definertustatus _status = (definertustatus)Convert.ToInt32(status);
                            status = _status.ToString();
                        }
                        else if (Convert.ToInt32(type) == 3)
                        {
                            definesignalstatus _status = (definesignalstatus)Convert.ToInt32(status);
                            status = _status.ToString();
                        }
                        else if (Convert.ToInt32(type) == 4)
                        {
                            defineswitchstatus _status = (defineswitchstatus)Convert.ToInt32(status);
                            status = _status.ToString();
                        }
                        else if (Convert.ToInt32(type) == 5)
                        {
                            definetrackstatus _status = (definetrackstatus)Convert.ToInt32(status);
                            status = _status.ToString();
                        }
                        else if (Convert.ToInt32(type) == 7)
                        {
                            defineplatformstatus _status = (defineplatformstatus)Convert.ToInt32(status);
                            status = _status.ToString();
                        }
                       
                      

                        string spare = Getbyte4(words, posloop);
                        append.Append("devname:" + devname + Environment.NewLine + "status:" + status + Environment.NewLine + "spare" + spare + Environment.NewLine);
                        posloop += 4;
                        devname = "";
                    }
                }
            }
            return append;

        }
        public static StringBuilder Ensignalname(string[] words, StringBuilder append, int position,int sigcount)
        {
            int posloop = position;
            for (int a = 0; a < sigcount; a++)
            {

                signame = unicode(words, posloop, 20);
                posloop += 20;
           
                      
                Console.WriteLine(signame);
                append.Append("signame:" + signame + Environment.NewLine);
                int route_count = Int32.Parse(words[++posloop], System.Globalization.NumberStyles.HexNumber);
                append.Append("routecount:" + route_count + Environment.NewLine);
                    if (route_count > 0)
                    {
                        for (int b = 0; b < route_count; b++)
                        {

                            routename = unicode(words, posloop, 64);

                           
                            posloop += 64;
                            string _routestatus = Int32.Parse(words[++posloop], System.Globalization.NumberStyles.HexNumber).ToString();
                            routestatus route_status = (routestatus)Convert.ToInt32(_routestatus);
                             _routestatus = route_status.ToString();
                            append.Append("routename:" + routename + Environment.NewLine + "routestatus:"+_routestatus + Environment.NewLine);
                          
                            
                          
                            
                        }
                    
                
                    


                    }
            }

            return append;

        }
        public static StringBuilder Endepot(string[] words, StringBuilder append, int position,int count)
        {
            int posloop = position;
          
            for (int loop = 0; loop < count; loop++)
            {

                string depot_station = Getbyte2(words, posloop);
                posloop += 2;

                string _groupid = unicode(words, posloop, 9);
                posloop += 9;
                string _driverid = unicode(words, posloop, 13);
                posloop += 13;
                append.Append("depot station:"+depot_station + Environment.NewLine + "groupid:" + _groupid + Environment.NewLine+"driverid:"+_driverid + Environment.NewLine);
             
                string outflag = Getbyte2(words, posloop);
                outflag day = (outflag)Convert.ToInt32(outflag);
                outflag = day.ToString();
              
                posloop += 2;
                string outschedule = Int64.Parse(words[++posloop], System.Globalization.NumberStyles.HexNumber).ToString();
                outschedule tran = (outschedule)Convert.ToInt32(outschedule);
                outschedule = tran.ToString();

                string outtime = date(words, posloop);
                
                append.Append("outflag:" + outflag + Environment.NewLine + "outschedule:" + outschedule + Environment.NewLine + "outtime:" + outtime + Environment.NewLine);
                posloop+=7;
                string outstation = Getbyte2(words, posloop);
                posloop +=2;
                string outside = Getbyte2(words, posloop);
                posloop += 2;
                append.Append("outstation:" + outstation + Environment.NewLine + "outside:" + outside + Environment.NewLine );
               

                string _outname = unicode(words, posloop, 20);
                posloop += 20;
                append.Append("outname:" + _outname + Environment.NewLine);

                string _outtrainid = unicode(words, posloop, 9);
                posloop += 9;
                string outdestination = Getbyte4(words, posloop);
                posloop += 4;
                append.Append("outtrainid:" + _outtrainid + Environment.NewLine + "outdestination:"+ outdestination +Environment.NewLine);
             
                string _outglobalid = unicode(words, posloop, 12);
                posloop += 12;


                append.Append("outglabelid:" + _outglobalid + Environment.NewLine + "outlocalsubid:0000" + Environment.NewLine);
                posloop += 4;
                string inflag = Getbyte2(words, posloop);
                inflag tran1 = (inflag)Convert.ToInt32(inflag);
                inflag = tran1.ToString();
                posloop += 2;
                string inschedule = Int64.Parse(words[++posloop], System.Globalization.NumberStyles.HexNumber).ToString();
                outschedule tran2 = (outschedule)Convert.ToInt32(inschedule);
                inschedule = tran2.ToString();
                string intime = date(words, posloop);

                append.Append("inflag:" + inflag + Environment.NewLine + "inschedule:" + inschedule + Environment.NewLine + "intime:" + intime + Environment.NewLine);
                posloop += 7;
                string instation = Getbyte2(words, posloop);
                posloop += 2;
                string inside = Getbyte2(words, posloop);
                posloop += 2;
                append.Append("instation:" + instation + Environment.NewLine + "inside:" + inside + Environment.NewLine);
               
                string _inname = unicode(words, posloop, 20);
                posloop += 20;
                append.Append("inname:" + _inname + Environment.NewLine);
               
                string _intrainid = unicode(words, posloop, 9);
                posloop += 9;
                string indestination = Getbyte4(words, posloop);
                posloop += 4;
                append.Append("intrainid:" + _intrainid + Environment.NewLine + "indestination:" + indestination + Environment.NewLine);
               
                string _inglobalid = unicode(words, posloop, 12);
                posloop += 12;

                append.Append("inglabelid:" + _inglobalid + Environment.NewLine + "inlocalsubid:0000" + Environment.NewLine +" -----------------------"+Environment.NewLine);
                posloop += 4;

            }
            return append;

        }
        public static StringBuilder Entrainint(string[] words, StringBuilder append, int position, int count)
        {
            int posloop = position;

            for (int loop = 0; loop < count; loop++)
            {
                string rtuid = Getbyte2(words, posloop);
                posloop += 2;
                append.Append("rtuid:" + rtuid + Environment.NewLine);
                 string window = Getbyte2(words, posloop);
                posloop += 2;
                append.Append("window:" + window + Environment.NewLine);
                 string windowoffset = Int32.Parse(words[++posloop], System.Globalization.NumberStyles.HexNumber).ToString();
                append.Append("windowoffset:" + windowoffset + Environment.NewLine);
                string devtype = Getbyte2(words, posloop);
                posloop += 2;
                append.Append("devtype:" + devtype + Environment.NewLine);
                string devname = unicode(words, posloop, 24);
                posloop += 24;
                append.Append("devname:" + devname + Environment.NewLine);
                string trainindex = unicode(words, posloop, 10);
                posloop += 10;
                append.Append("trainindex:" + trainindex + Environment.NewLine);
                string groupid = unicode(words, posloop, 9);
                posloop += 9;
                append.Append("groupid:" + groupid + Environment.NewLine);
                string trainid = unicode(words, posloop, 9);
                posloop += 9;
                append.Append("trainid:" + trainid+ Environment.NewLine);
                string globalid = unicode(words, posloop, 12);
                posloop += 12;
                append.Append("globalid:" + globalid + Environment.NewLine);
                string destinationid = Getbyte4(words, posloop);
                posloop += 4;
                append.Append("destinationid:" + destinationid + Environment.NewLine);
                string rollingstock = Int32.Parse(words[++posloop], System.Globalization.NumberStyles.HexNumber).ToString();
                append.Append("rollingstock:" + rollingstock + Environment.NewLine);
                string driverid = unicode(words, posloop, 13);
                append.Append("driverid:" + driverid + Environment.NewLine);
                posloop += 13;
                string otptime = Getbyte4(words, posloop);
                posloop += 4;
                append.Append("otptime:" + otptime + Environment.NewLine);
                string Mode = Getbyte4(words, posloop);
                posloop += 4;
                mode _mode = (mode)Convert.ToInt32(Mode);
                Mode = _mode.ToString();
                append.Append("Mode:" + Mode+ Environment.NewLine);
                string arrivetime = date(words, posloop);
                posloop += 7;
                append.Append("arrivetime:" + arrivetime + Environment.NewLine);
                string departtime = date(words, posloop);
                posloop += 7;
                append.Append("departtime:" + departtime + Environment.NewLine);
                string rate = Getbyte4(words, posloop);
                posloop += 4;
                append.Append("rate:" + rate + Environment.NewLine);
                string speed= Int32.Parse(words[++posloop], System.Globalization.NumberStyles.HexNumber).ToString();
                append.Append("speed:" + speed + Environment.NewLine);
                posloop += 2;
                
            }

                return append;
        }
        public static StringBuilder Engrouprunning(string[] words, StringBuilder append, int position, int count)
        {
            int posloop = position;

            for (int loop = 0; loop < count; loop++)
            {
                string groupid = unicode(words, posloop,9);
                posloop += 9;
                string totalrunning = Getbyte4(words, posloop);
                posloop += 4;
                string monthrepair = Getbyte4(words, posloop);
                posloop += 4;
                string shelfrepair = Getbyte4(words, posloop);
                posloop += 4;
                string periodrepair = Getbyte4(words, posloop);
                posloop += 4;
                string factoryrepair = Getbyte4(words, posloop);
                posloop += 4;
                append.Append(" groupid:" + groupid + Environment.NewLine);
                append.Append("totalrunning:" + totalrunning + Environment.NewLine);
                append.Append(" monthrepair :" + monthrepair + Environment.NewLine);
                append.Append("shelfrepair:" + shelfrepair + Environment.NewLine);
                append.Append("periodrepair:" + periodrepair + Environment.NewLine);
                append.Append("factoryrepair :" + factoryrepair + Environment.NewLine);
            }
            return append;
        }
        public static string date (string[] words,int position)
        {
            int posloop = position;
            string year1 = Int64.Parse(words[++posloop], System.Globalization.NumberStyles.HexNumber).ToString();
            string year2 = Int64.Parse(words[++posloop], System.Globalization.NumberStyles.HexNumber).ToString();
            string month = Int64.Parse(words[++posloop], System.Globalization.NumberStyles.HexNumber).ToString();
            string day = Int64.Parse(words[++posloop], System.Globalization.NumberStyles.HexNumber).ToString();
            string hour = Int64.Parse(words[++posloop], System.Globalization.NumberStyles.HexNumber).ToString();
            string minute = Int64.Parse(words[++posloop], System.Globalization.NumberStyles.HexNumber).ToString();
            string second = Int64.Parse(words[++posloop], System.Globalization.NumberStyles.HexNumber).ToString();
            string date= year1 + year2 + "-" + month + "-" + day + " " + hour + ":" + minute + ":" + second;
            


            return date;
        }
        public static string unicode (string[] words,int position,int loopcount)
        {
            int posloop = position;
            int loop = loopcount;
            for (int i = 0; i < loop; i++)
            {
              
                    posloop++;
                    if ((words[posloop]) != "00")
                        groupid += words[posloop].ToString();
                
            }
            Console.WriteLine(groupid);
            System.Text.Encoding utf_8 = System.Text.Encoding.UTF8;
            byte[] test = StringToByteArray(groupid);
            
            string _groupid = System.Text.Encoding.UTF8.GetString(test);
            groupid = "";
            Console.WriteLine(_groupid);
            return _groupid;




        }
        private void Detial_box_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
