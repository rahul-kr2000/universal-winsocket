using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//using WebSocket4Net;
using WebSocketSharp;

namespace WinSocket
{
    public partial class Form1 : Form
    {
        [DllImport("ole32.dll")]
        private static extern int CLSIDFromProgID([MarshalAs(UnmanagedType.LPWStr)] string string_15, out Guid guid_0);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr intptr_0, uint uint_0);

        Type AmiBrokerType;
        dynamic AmiBroker;
        Process AmiBrokerProces;

        const string DBPath = @"D:\temp\AmiFeeder-Data\db";
        const string Outfile = @"D:\temp\AmiFeeder-Data\outfile.txt";

        WebSocket webSocket;

        public Form1()
        {
            InitializeComponent();
            Application.DoEvents();
            //InitAmiBroker();
        }

        private void InitAmiBroker()
        {
            AmiBrokerType = Type.GetTypeFromProgID("Broker.Application");
            AmiBroker = Activator.CreateInstance(AmiBrokerType);
            AmiBroker.LoadDatabase(@"C:\AmiFeeds\Amibroker\AFData\");
        }

        public void dataRefresher(string defaylPath)
        {
            string dataFormat = @"C:\AmiFeeds\Amibroker\dataFormat.dll";
            try
            {
                AmiBroker.Import(0, defaylPath, dataFormat);
                AmiBroker.RefreshAll();
                Thread.Sleep(50);
                //File.Delete(defaylPath);
            }
            catch (Exception ex)
            {
                //options.logger.logMsg(ex.Message, LogItemSeverity.logSeverityError);
            }
        }


        ///*
        #region WebSocket
        private void btnConnect_Click(object sender, EventArgs e)
        {
            string url = "wss://awspricefeed.finvasia.com/price-feed";
            url = "wss://ws.zerodha.com/?api_key=kitefront&user_id=II2332&public_token=57tF0gpULTj4ntx67LqppO58KUQwHLhL&uid=1559652323413&user-agent=kite3-web&version=2.1.0";
            string token = txtToken.Text;
            webSocket = new WebSocket(url);



            /*
            webSocket.EnableAutoSendPing = true;
            webSocket.DataReceived += WebSocket_DataReceived;
            webSocket.Closed += WebSocket_Closed;
            webSocket.Error += WebSocket_Error;
            webSocket.MessageReceived += WebSocket_MessageReceived;
            webSocket.Opened += WebSocket_Opened;
            webSocket.Open();
            */

            //webSocket.o
            webSocket.OnClose += WebSocket_Closed;
            webSocket.OnError += WebSocket_OnError;
            webSocket.OnMessage += WebSocket_OnMessage;
            webSocket.OnOpen += WebSocket_Opened;

            webSocket.Connect();

            //webSocket.Send("{\"a\":\"mode\",\"v\":[\"ltp\",[54599687]]}");

            List<string> listCommand = new List<string>();
            /*
            listCommand.Add("{\"a\":\"subscribe\",\"v\":[256265]}");
            listCommand.Add("{\"a\":\"mode\",\"v\":[\"quote\",[256265]]}");
            listCommand.Add("{\"a\":\"subscribe\",\"v\":[265]}");
            listCommand.Add("{\"a\":\"mode\",\"v\":[\"quote\",[265]]}");
            listCommand.Add("{\"a\":\"subscribe\",\"v\":[54599687]}");
            listCommand.Add("{\"a\":\"mode\",\"v\":[\"quote\",[54599687]]}");
            */

            //listCommand.Add("{\"a\":\"mode\",\"v\":[\"ltp\",[54599687]]}");
            listCommand.Add("{\"a\":\"mode\",\"v\":[\"full\",[54599687]]}");

            foreach (string s in listCommand)
            {
                webSocket.Send(s);
            }
        }

        private void WebSocket_OnMessage(object sender, MessageEventArgs e)
        {
            bool _debug = true;

            if (e.IsBinary)
            {
                byte[] Data = e.RawData;

                var byt = e.RawData;
                string str = ASCIIEncoding.UTF8.GetString(byt);

                int offset = 0;
                ushort num = ReadShort(Data, ref offset);
                //if (_debug)
                {
                    //Console.WriteLine("No of packets: " + num);
                }
                //if (_debug)
                {
                    //Console.WriteLine("No of bytes: " + Count);
                }
                for (ushort num2 = 0; num2 < num; num2 = (ushort)(num2 + 1))
                {
                    ushort num3 = ReadShort(Data, ref offset);
                    if (_debug)
                    {
                        Console.WriteLine("Packet Length " + num3);
                    }
                    Tick tickData = default(Tick);
                    switch (num3)
                    {
                        case 8:
                            tickData = ReadLTP(Data, ref offset);
                            break;
                        case 28:
                            tickData = ReadIndexQuote(Data, ref offset);
                            break;
                        case 32:
                            tickData = ReadIndexFull(Data, ref offset);
                            break;
                        case 44:
                            tickData = ReadQuote(Data, ref offset);
                            break;
                        case 184:
                            tickData = ReadFull(Data, ref offset);
                            break;
                    }

                    //txtMessage.Text = $"Inst: {tickData.InstrumentToken} Ltp: {tickData.LastPrice} Quantity: {tickData.LastQuantity} Vol: {tickData.Volume} OI: {tickData.OI} Time: {tickData.Timestamp}";

                    if (txtMessage.InvokeRequired)
                    {
                        txtMessage.Invoke((MethodInvoker)delegate
                        {
                            //txtMessage.Text = $"Inst: {tickData.InstrumentToken} Ltp: {tickData.LastPrice} Quantity: {tickData.LastQuantity} Vol: {tickData.Volume} OI: {tickData.OI} Time: {tickData.Timestamp}";
                            //string line = $"{tickData.InstrumentToken},{tickData.LastPrice},{tickData.LastQuantity},{tickData.Volume},{tickData.OI},{tickData.Timestamp},{tickData.LastTradeTime}";
                            string line = $"CRUDEOILM-I,{tickData.Timestamp.Value.ToString("yyyy-MM-dd")},{tickData.Timestamp.Value.ToString("HH:mm:ss")},{tickData.LastPrice},{tickData.LastPrice},{tickData.LastPrice},{tickData.LastPrice},{tickData.LastQuantity},{tickData.OI}";
                            //File.WriteAllText(@"C:\AmiFeeds\Amibroker\rtDataRefresh.txt", line + "\n");
                            //dataRefresher(@"C:\AmiFeeds\Amibroker\rtDataRefresh.txt");
                            File.AppendAllLines(@"D:\temp\data-6-6-2019.csv", new string[] { line });

                            txtMessage.Text = line;
                        });

                    }
                    else
                    {
                        txtMessage.Text = $"Inst: {tickData.InstrumentToken} Ltp: {tickData.LastPrice}";
                    }


                    /*
                    if (tickData.InstrumentToken != 0 && IsConnected && offset <= Count)
                    {
                        this.OnTick(tickData);
                    }
                    */
                }
            }
            else
            {
                txtMessage.AppendText(e.Data);
            }
        }

        private void WebSocket_OnError(object sender, WebSocketSharp.ErrorEventArgs e)
        {
            //MessageBox.Show("Error: " + e.Exception.ToString());
        }

        private void WebSocket_Opened(object sender, EventArgs e)
        {
            //MessageBox.Show("Connected");
        }


        /*
        private void WebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            //throw new NotImplementedException();
            if (txtMessage.InvokeRequired)
            {
                txtMessage.Invoke((MethodInvoker)delegate {
                    txtMessage.AppendText(Decrypt(e.Message));
                });
            }
        }

        private void WebSocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            //throw new NotImplementedException();
        }
        */

        private void WebSocket_Closed(object sender, EventArgs e)
        {
            webSocket.Connect();
        }

        private void WebSocket_DataReceived(object sender, DataReceivedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public string Decrypt(string encText)
        {
            string result = "Error in parsing!";
            byte[] inputBytes = Convert.FromBase64String(encText);

            using (var inputStream = new MemoryStream(inputBytes))

            using (var gZipStream = new Ionic.Zlib.ZlibStream(inputStream, Ionic.Zlib.CompressionMode.Decompress))
            using (var streamReader = new StreamReader(gZipStream))
            {
                var decompressed = streamReader.ReadToEnd();

                result = decompressed;
            }
            return result;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string data;
            using (WebClient web = new WebClient())
            {
                data = web.DownloadString("http://213.136.71.212/newlogo12.jpg");
            }

            
            //webSocket.Send("{\"a\":\"mode\",\"v\":[\"ltp\",[54599687]]}");

            //SendAuth();

            //string orderDetails = "{\"orderDetail\":{\"exch\":\"MCX\",\"symbol\":\"CRUDEOILM19JUNFUT\",\"date\":\"2019-05-23T08:44:29.444Z\",\"Pcode\":\"NRML\",\"Ttranstype\":\"S\",\"ret\":\"DAY\",\"QTY\":1,\"discqty\":0,\"price\":\"4280.00\",\"TrigPrice\":\"0.00\",\"MktPro\":0,\"Prctype\":\"L\",\"AMO\":\"NO\"}}";

            //webSocket.Send(orderDetails);
        }

        public void SendAuth()
        {
            string auth = $"{{\"auth\":\"{txtToken.Text}\",\"defaults\":[1,2]}}";
            webSocket.Send(auth);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            webSocket.Close();
        }
        #endregion
        // */

        private void button1_Click(object sender, EventArgs e)
        {
            string backfillFile = @"D:\temp\dataZ.csv";
            string from = "2019-06-05";
            string to = "2019-06-05";

            int i = 10;

            for (int j = i; j > 0; j--)
            {
                txtMessage.AppendText($"Downloading...{j}/{i}");
                DateTime t = DateTime.Now.AddDays(-j);
                from = to = t.ToString("yyyy-MM-dd");
                BackFill(backfillFile, from, to);
            }

            MessageBox.Show("Done");
        }

        private void BackFill(string backfillFile, string from, string to)
        {
            //string backfillFile = @"D:\temp\dataZ.csv";
            //string from = "2019-06-05";
            //string to = "2019-06-05";
            string url = $"https://kitecharts-aws.zerodha.com/api/chart/54599687/minute?public_token=zVjpn3lIjKD87dbXHMtINwxEUv7x124p&user_id=II2332&api_key=kitefront&access_token=&from={from}&to={to}&ciqrandom=1556964942331";
            string data = "";

            using (WebClient webClient = new WebClient())
            {
                data = webClient.DownloadString(url);
            }

            var root = JObject.Parse(data);

            JArray Candles = (JArray)root["data"]["candles"];

            foreach (JToken dataValues in Candles)
            {
                string[] g = dataValues.ToObject<string[]>();

                DateTime d = DateTime.Parse(g[0]);
                g[0] = d.ToString("yyyy-MM-dd") + "," + d.ToString("HH:mm:ss");
                string line = "CRUDEOILM-I," + string.Join(",", g);

                File.AppendAllText(backfillFile, line + "\n");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ReadDataFromFile();
        }


        private ushort ReadShort(byte[] b, ref int offset)
        {
            ushort result = (ushort)(b[offset + 1] + (b[offset] << 8));
            offset += 2;
            return result;
        }

        private uint ReadInt(byte[] b, ref int offset)
        {
            uint result = BitConverter.ToUInt32(new byte[4]
            {
                b[offset + 3],
                b[offset + 2],
                b[offset + 1],
                b[offset]
            }, 0);
            offset += 4;
            return result;
        }

        private Tick ReadLTP(byte[] b, ref int offset)
        {
            Tick result = default(Tick);
            result.Mode = "ltp";
            result.InstrumentToken = ReadInt(b, ref offset);
            decimal d = ((result.InstrumentToken & 0xFF) == 3) ? 10000000.0m : 100.0m;
            result.Tradable = ((result.InstrumentToken & 0xFF) != 9);
            result.LastPrice = (decimal)ReadInt(b, ref offset) / d;
            return result;
        }

        private Tick ReadIndexQuote(byte[] b, ref int offset)
        {
            Tick result = default(Tick);
            result.Mode = "quote";
            result.InstrumentToken = ReadInt(b, ref offset);
            decimal d = ((result.InstrumentToken & 0xFF) == 3) ? 10000000.0m : 100.0m;
            result.Tradable = ((result.InstrumentToken & 0xFF) != 9);
            result.LastPrice = (decimal)ReadInt(b, ref offset) / d;
            result.High = (decimal)ReadInt(b, ref offset) / d;
            result.Low = (decimal)ReadInt(b, ref offset) / d;
            result.Open = (decimal)ReadInt(b, ref offset) / d;
            result.Close = (decimal)ReadInt(b, ref offset) / d;
            result.Change = (decimal)ReadInt(b, ref offset) / d;
            return result;
        }

        private Tick ReadIndexFull(byte[] b, ref int offset)
        {
            Tick result = default(Tick);
            result.Mode = "full";
            result.InstrumentToken = ReadInt(b, ref offset);
            decimal d = ((result.InstrumentToken & 0xFF) == 3) ? 10000000.0m : 100.0m;
            result.Tradable = ((result.InstrumentToken & 0xFF) != 9);
            result.LastPrice = (decimal)ReadInt(b, ref offset) / d;
            result.High = (decimal)ReadInt(b, ref offset) / d;
            result.Low = (decimal)ReadInt(b, ref offset) / d;
            result.Open = (decimal)ReadInt(b, ref offset) / d;
            result.Close = (decimal)ReadInt(b, ref offset) / d;
            result.Change = (decimal)ReadInt(b, ref offset) / d;
            uint num = ReadInt(b, ref offset);
            result.Timestamp = Utils.UnixToDateTime(num);
            return result;
        }

        private Tick ReadQuote(byte[] b, ref int offset)
        {
            Tick result = default(Tick);
            result.Mode = "quote";
            result.InstrumentToken = ReadInt(b, ref offset);
            decimal d = ((result.InstrumentToken & 0xFF) == 3) ? 10000000.0m : 100.0m;
            result.Tradable = ((result.InstrumentToken & 0xFF) != 9);
            result.LastPrice = (decimal)ReadInt(b, ref offset) / d;
            result.LastQuantity = ReadInt(b, ref offset);
            result.AveragePrice = (decimal)ReadInt(b, ref offset) / d;
            result.Volume = ReadInt(b, ref offset);
            result.BuyQuantity = ReadInt(b, ref offset);
            result.SellQuantity = ReadInt(b, ref offset);
            result.Open = (decimal)ReadInt(b, ref offset) / d;
            result.High = (decimal)ReadInt(b, ref offset) / d;
            result.Low = (decimal)ReadInt(b, ref offset) / d;
            result.Close = (decimal)ReadInt(b, ref offset) / d;
            return result;
        }

        private Tick ReadFull(byte[] b, ref int offset)
        {
            Tick result = default(Tick);
            result.Mode = "full";
            result.InstrumentToken = ReadInt(b, ref offset);
            decimal d = ((result.InstrumentToken & 0xFF) == 3) ? 10000000.0m : 100.0m;
            result.Tradable = ((result.InstrumentToken & 0xFF) != 9);
            result.LastPrice = (decimal)ReadInt(b, ref offset) / d;
            result.LastQuantity = ReadInt(b, ref offset);
            result.AveragePrice = (decimal)ReadInt(b, ref offset) / d;
            result.Volume = ReadInt(b, ref offset);
            result.BuyQuantity = ReadInt(b, ref offset);
            result.SellQuantity = ReadInt(b, ref offset);
            result.Open = (decimal)ReadInt(b, ref offset) / d;
            result.High = (decimal)ReadInt(b, ref offset) / d;
            result.Low = (decimal)ReadInt(b, ref offset) / d;
            result.Close = (decimal)ReadInt(b, ref offset) / d;
            result.LastTradeTime = Utils.UnixToDateTime(ReadInt(b, ref offset));
            result.OI = ReadInt(b, ref offset);
            result.OIDayHigh = ReadInt(b, ref offset);
            result.OIDayLow = ReadInt(b, ref offset);
            result.Timestamp = Utils.UnixToDateTime(ReadInt(b, ref offset));

            /*
            result.Bids = new DepthItem[5];
            for (int i = 0; i < 5; i++)
            {
                result.Bids[i].Quantity = ReadInt(b, ref offset);
                result.Bids[i].Price = (decimal)ReadInt(b, ref offset) / d;
                result.Bids[i].Orders = ReadShort(b, ref offset);
                offset += 2;
            }
            result.Offers = new DepthItem[5];
            for (int j = 0; j < 5; j++)
            {
                result.Offers[j].Quantity = ReadInt(b, ref offset);
                result.Offers[j].Price = (decimal)ReadInt(b, ref offset) / d;
                result.Offers[j].Orders = ReadShort(b, ref offset);
                offset += 2;
            }
            */
            return result;
        }

    }
}
