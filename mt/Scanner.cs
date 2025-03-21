using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace MagTek {
    public class Scanner : IDisposable {
        private ScannedCheck _check;
        private bool _disposing;
        private bool _downloadingImage;
        private List<byte> _file;
        private SerialPort _port;
        public event DataReceivedEventHandler DataReceived;

        public event CheckScannedEventHandler CheckScanned;

        // callback for printing text of event
        public delegate void ScannerCallback(ScannedCheck scannedCheck);

        public delegate void ImageCallback(byte[] image);

        private ScannerCallback _callback;
        private ImageCallback _imageCallback;

        public Scanner(string portName, int baudRate, int dataBits,
            Parity parity, StopBits stopBits, bool breakState, ScannerCallback callback, ImageCallback imageCallback) {
            PortName = portName; // e.g. COM1, COM2, etc.
            BaudRate = baudRate;
            DataBits = dataBits;
            Parity = parity;
            StopBits = stopBits;
            BreakState = breakState;
            _callback = callback;
            _imageCallback = imageCallback;
        }

        public string PortName { get; set; }
        public int BaudRate { get; set; }
        public int DataBits { get; set; }
        public Parity Parity { get; set; }
        public StopBits StopBits { get; set; }
        public bool BreakState { get; set; }

        public void Dispose() {
            if (_disposing) return;
            _disposing = true;

            try {
                _port?.Close();
                _port?.Dispose();
                _port = null;
                _downloadingImage = false;
                _disposing = false;
            }
            catch (Exception) { }
        }

        public bool Initialize() {
            _port = new SerialPort(PortName);
            try {
                _port.Open();
            }
            catch (Exception ex) {
                MessageBox.Show("Error opening port: " + ex.Message);
                return false;
            }

            _port.BaudRate = BaudRate;
            _port.BreakState = BreakState;
            _port.DataBits = DataBits;
            _port.Parity = Parity;
            _port.StopBits = StopBits;

            _port.DataReceived += PortOnDataReceived;

            // configure
            SendRequest("SWA 00100010"); // host port parameters
            SendRequest("SWB 00100010"); // message format
            SendRequest("SWC 00100000"); // miscellaneous
            SendRequest("SWD 00100010"); // auxiliary port parameters
            SendRequest("SWE 00000010"); // data transfer
            SendRequest("SWF 00001101"); // miscellaneous
            SendRequest("SWI 00000000"); // image parameters
            SendRequest("HW 00111100"); // hardware
            SendRequest("FC 6200"); // format: T[transit]T[account]A[check #]
            return true;
        }

        public void SendRequest(string s) {
            var request = $"{s}\r";
            _port?.Write(request);
        }

        private void RequestImage() {
            _port.DataReceived += ImageReceived;
            SendRequest("SF C0 F4");
        }

        //
        private void PortOnDataReceived(object sender, SerialDataReceivedEventArgs e) {
            var cnt = _port.BytesToRead;
            var bytes = new byte[cnt];

            _port.Read(bytes, 0, cnt);

            var response = Encoding.ASCII.GetString(bytes);

            // send if anyone is listening
            DataReceived?.Invoke(null, new DataReceivedEventArgs(response));

            if (_downloadingImage) {
                // caught after SI is sent
                _port.DataReceived -= PortOnDataReceived;
                RequestImage();
            }
            else {
                const string pattern =
                    @"T(?<routing>[a-zA-Z0-9]*)T(?<account>[a-zA-Z0-9]*)A(?<checknumber>[a-zA-Z0-9]*)S?";

                if (!Regex.IsMatch(response, pattern)) return;
                var m = Regex.Match(response, pattern);

                _check = new ScannedCheck {
                    CheckNumber = m.Groups["checknumber"].Value,
                    AccountNumber = m.Groups["account"].Value,
                    RoutingNumber = m.Groups["routing"].Value
                };
                // callback to print text of event
                // _callback(_check);

                _file = new List<byte>();

                // received an image
                _downloadingImage = true;

                // save image
                SendRequest("SI");
            }
        }

        private void ImageReceived(object sender, SerialDataReceivedEventArgs e) {
            if (_port == null) return; // Add null check for _port
            _port.DataReceived -= ImageReceived;

            if (!_downloadingImage) return;

            if (_port.BytesToRead == 0) return;

            while (_port.BytesToRead > 0) {
                var cnt = _port.BytesToRead;

                var bytes = new byte[cnt];
                _port.Read(bytes, 0, cnt);

                _file.AddRange(bytes);

                Thread.Sleep(250); // need to slow this down to ensure everything is captured
            }

            // have all bytes
            _check.CheckImage = _file.ToArray();

            // callback to print text of event
            // _imageCallback(_check.CheckImage);

            _callback(_check);

            _file.Clear();

            _downloadingImage = false;
            if (_port == null) return;
            _port.DataReceived += PortOnDataReceived;

            SendRequest("FM ERASE");
        }
    }
}