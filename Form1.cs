using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using MagTek;
using SCMagTek.Settings;

namespace SCMagTek {
    public partial class Form1 : Form {
        private Scanner _scanner;

        private readonly string _folderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        public Form1(bool startWithBackSelected = false) {
            InitializeComponent();
            // TITLE
            Text = "MagTek Scanner";
            // select parity in combobox1
            comboBox1.Items.Add("None");
            comboBox1.Items.Add("Odd");
            comboBox1.Items.Add("Even");
            comboBox1.Items.Add("Mark");
            comboBox1.Items.Add("Space");

            // select stop bits in combobox2
            comboBox2.Items.Add("None");
            comboBox2.Items.Add("One");
            comboBox2.Items.Add("Two");
            comboBox2.Items.Add("OnePointFive");

            // enter the default settings
            // textBox1.Text = "COM1";
            textBox1.Text = !string.IsNullOrEmpty(SettingsManager.Instance.LastComPort)
                ? SettingsManager.Instance.LastComPort
                : "COM1";
            textBox2.Text = "115200"; // usually 9600, 19200, 38400, 57600, or 115200
            textBox3.Text = "8"; // usually 8 or 7
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;

            // image to contain 
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

            // Set initial radio button state based on parameter
            front.Checked = !startWithBackSelected;
            back.Checked = startWithBackSelected;

            Show();
            if (!IsDebug()) {
                InitBtnClick(null, null);
            }
        }

        private static bool IsDebug() {
#if DEBUG
            return true;
#else
            return false;
#endif
        }

        // Initialize the scanner with the selected settings
        private void InitBtnClick(object sender, EventArgs e) {
            if (comboBox1.SelectedIndex == -1) {
                MessageBox.Show("Please select a parity.");
                return;
            }

            if (comboBox2.SelectedIndex == -1) {
                MessageBox.Show("Please select a stop bits.");
                return;
            }

            if (textBox2.Text == "" || !textBox2.Text.All(char.IsDigit)) {
                MessageBox.Show("Please enter a boud name.");
                return;
            }

            if (textBox3.Text == "" || !textBox3.Text.All(char.IsDigit)) {
                MessageBox.Show("Please enter a dataBits rate.");
                return;
            }

            // get the selected settings
            var portName = textBox1.Text;
            var baudRate = Convert.ToInt32(textBox2.Text);
            var dataBits = Convert.ToInt32(textBox3.Text);
            var parity = (Parity)comboBox1.SelectedIndex;
            var stopBits = (StopBits)comboBox2.SelectedIndex;
            var breakState = checkBox1.Checked;

            _scanner?.Dispose();
            Thread.Sleep(500);

            if (_scanner != null) {
                _scanner.Dispose();
                _scanner = null;
            }

            // initialize the scanner
            _scanner = new Scanner(portName, baudRate, dataBits, parity, stopBits, breakState, CheckScannedCallback,
                ImageCallback);
            if (_scanner.Initialize()) {
                textBox4.Text += "Scanner Initialized" + "\r\n";
                SettingsManager.Instance.LastComPort = portName;
            }
        }

        private void CheckScannedCallback(ScannedCheck data) {
            var text = data.CheckNumber + "\r\n" +
                       data.AccountNumber + "\r\n" +
                       data.RoutingNumber + "\r\n";

            if (textBox4.InvokeRequired) {
                textBox4.Invoke(new Action(() => textBox4.Text += text + "\r\n"));
            }
            else {
                textBox4.Text += text + "\r\n";
            }

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            if (front.Checked) {
                var filePath = Path.Combine(_folderPath, "check-front.txt");
                var imageFilePath = Path.Combine(_folderPath, $"check-front-{timestamp}.jpg");
                var standardImagePath = Path.Combine(_folderPath, "check-front.jpg");
                File.WriteAllText(filePath, text);

                // Save the image and ensure it's not being reused
                using (var ms = new MemoryStream(data.CheckImage))
                using (var image = Image.FromStream(ms)) {
                    image.Save(imageFilePath, ImageFormat.Jpeg);
                    image.Save(standardImagePath, ImageFormat.Jpeg);
                    // Update the UI with the newly saved image
                    if (pictureBox1.InvokeRequired) {
                        pictureBox1.Invoke(new Action(() => pictureBox1.Image = new Bitmap(image)));
                    }
                    else {
                        pictureBox1.Image = new Bitmap(image);
                    }
                }

                // SaveToPath(data.CheckImage, imageFilePath);
                if (IsDebug()) return;
                // front.Checked = false;
                // back.Checked = true;


                // Close this instance
                _scanner?.Dispose();
                _scanner = null;

                Thread.Sleep(500);

                // Launch new instance for back scanning
                var exePath = Application.ExecutablePath;
                System.Diagnostics.Process.Start(exePath, "back");

                this.Close();
            }
            else if (back.Checked) {
                var filePath =
                    Path.Combine(_folderPath,
                        "check-back.txt"); // even though there is no data, we still have to save the file
                var imageFilePath = Path.Combine(_folderPath, $"check-back-{timestamp}.jpg");
                var standardImagePath = Path.Combine(_folderPath, "check-back.jpg");
                File.WriteAllText(filePath, text);

                // Save the image with proper disposal
                using (var ms = new MemoryStream(data.CheckImage))
                using (var image = Image.FromStream(ms)) {
                    image.Save(imageFilePath, ImageFormat.Jpeg);
                    image.Save(standardImagePath, ImageFormat.Jpeg);
                    // Update the UI with the newly saved image
                    if (pictureBox1.InvokeRequired) {
                        pictureBox1.Invoke(new Action(() => pictureBox1.Image = new Bitmap(image)));
                    }
                    else {
                        pictureBox1.Image = new Bitmap(image);
                    }
                }

                // SaveToPath(data.CheckImage, imageFilePath);

                if (IsDebug()) return;
                if (_scanner != null) {
                    _scanner.Dispose();
                    _scanner = null;
                }

                Close();
            }
        }

        private void ImageCallback(byte[] data) {
            return; // Let's not save the image
            if (data == null || data.Length == 0) {
                MessageBox.Show("Error: 0 length image.");
                return;
            }

            try {
                var image = ByteArrayToImage(data);

                var filePath = Path.Combine(_folderPath, "check-front.txt");
                if (textBox4.InvokeRequired) {
                    textBox4.Invoke(new Action(() => textBox4.Text += "Image saved to: " + filePath + "\r\n"));
                }
                else {
                    textBox4.Text += "Image saved to: " + filePath + "\r\n";
                }

                image.Save(filePath, ImageFormat.Jpeg);

                pictureBox1.Image = image;
            }
            catch (Exception e) {
                // alert the user
                MessageBox.Show("Error 54: " + e.Message);
                throw;
            }
        }

        private void SaveToPath(byte[] data, string path) {
            if (data == null || data.Length == 0) {
                // MessageBox.Show("Error: 0 " + path + " length image.");
                return;
            }

            try {
                var image = ByteArrayToImage(data);

                image.Save(path, ImageFormat.Jpeg);

                pictureBox1.Image = image;
            }
            catch (Exception e) {
                // alert the user
                MessageBox.Show("Error: " + e.Message);
            }
        }

        private Image ByteArrayToImage(byte[] byteArrayIn) {
            if (byteArrayIn == null || byteArrayIn.Length == 0) {
                MessageBox.Show("Error: Invalid image data.");
                return null;
            }

            try {
                using (var ms = new MemoryStream(byteArrayIn)) {
                    // create a new image from the memory stream
                    var returnImage = Image.FromStream(ms);
                    // return the image
                    return returnImage;
                }
            }
            catch (Exception e) {
                // alert the user
                MessageBox.Show("Error1: " + e.Message);
                return null;
            }
        }

        private void close_Click(object sender, EventArgs e) {
            _scanner?.Dispose();
            textBox4.Text += "Scanner Closed" + "\r\n";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            _scanner?.Dispose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            _scanner?.Dispose();
            // uncomment below all to close only visually
            // if (_close) return;
            // if (e.CloseReason != CloseReason.UserClosing) return;
            // notifyIcon1.Visible = true;
            // Hide();
            // e.Cancel = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) {
            _scanner?.Dispose();
            Close();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) {
            Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            Show();
        }

        private void button3_Click(object sender, EventArgs e) {
            // // if exist both image
            // if (!File.Exists(Path.Combine(_folderPath, "check-front-test.jpg")) ||
            //     !File.Exists(Path.Combine(_folderPath, "check-back-test.jpg"))) return;
            // // front check
            // var frontData = new ScannedCheck {
            //     CheckNumber = "123456789",
            //     AccountNumber = "123456789",
            //     RoutingNumber = "123456789",
            //     CheckImage = File.ReadAllBytes(Path.Combine(_folderPath, "check-front-test.jpg"))
            // };
            // CheckScannedCallback(frontData);
            // // back check
            // var backData = new ScannedCheck {
            //     CheckNumber = "",
            //     AccountNumber = "",
            //     RoutingNumber = "",
            //     CheckImage = File.ReadAllBytes(Path.Combine(_folderPath, "check-back-test.jpg"))
            // };
            // CheckScannedCallback(backData);
        }
    }
}