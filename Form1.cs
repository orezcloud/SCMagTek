using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using MagTek;

namespace SCMagTek
{
    public partial class Form1 : Form
    {
        private Scanner _scanner;
        private Stream _ms;

        public Form1()
        {
            InitializeComponent();
            // TITLE
            this.Text = "MagTek Scanner";

            // select parity in combobox1
            comboBox1.Items.Add("None");
            comboBox1.Items.Add("Odd");
            comboBox1.Items.Add("Even");
            comboBox1.Items.Add("Mark");
            comboBox1.Items.Add("Space");

            // select stopbits in combobox2
            comboBox2.Items.Add("None");
            comboBox2.Items.Add("One");
            comboBox2.Items.Add("Two");
            comboBox2.Items.Add("OnePointFive");

            // enter the default settings
            textBox1.Text = "COM1";
            textBox2.Text = "115200"; // usually 9600, 19200, 38400, 57600, or 115200
            textBox3.Text = "8"; // usually 8 or 7
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;

            // image to contain 
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

            // serverThread = new Thread(StartServer);
            // serverThread.Start();
        }

        // Initialize the scanner with the selected settings
        private void InitBtnClick(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a parity.");
                return;
            }

            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a stop bits.");
                return;
            }

            if (textBox2.Text == "" || !textBox2.Text.All(char.IsDigit))
            {
                MessageBox.Show("Please enter a boud name.");
                return;
            }

            if (textBox3.Text == "" || !textBox3.Text.All(char.IsDigit))
            {
                MessageBox.Show("Please enter a dataBits rate.");
                return;
            }

            // get the selected settings
            string portName = textBox1.Text;
            int baudRate = Convert.ToInt32(textBox2.Text);
            int dataBits = Convert.ToInt32(textBox3.Text);
            Parity parity = (Parity) comboBox1.SelectedIndex;
            StopBits stopBits = (StopBits) comboBox2.SelectedIndex;
            bool breakState = checkBox1.Checked;

            // initialize the scanner
            _scanner = new Scanner(portName, baudRate, dataBits, parity, stopBits, breakState, Callback, ImageCallback);
            _scanner.Initialize();

            textBox4.Text += "Scanner Initialized" + "\r\n";
        }

        private void Callback(string data)
        {
            textBox4.Text += data;
        }

        private void ImageCallback(byte[] data)
        {
            if (data == null || data.Length == 0)
            {
                MessageBox.Show("Error: 0");
                return;
            }

            string desktopPath1 = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string smartCashTemp = Path.Combine(desktopPath1, "AppData\\Local\\Temp\\smart-cash");

            try
            {
                Image image = ByteArrayToImage(data);

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
                string filePath = Path.Combine(desktopPath, "image.jpg");
                image.Save(filePath, ImageFormat.Jpeg);

                pictureBox1.Image = image;
            }
            catch (Exception e)
            {
                // alert the user
                MessageBox.Show("Error: " + e.Message);
                throw;
            }
        }

        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                _ms = new MemoryStream(byteArrayIn);
                // sleep for .3 seconds
                Thread.Sleep(500);
                // create a new image from the memory stream
                Image returnImage = Image.FromStream(_ms);
                Thread.Sleep(200);
                // return the image
                return returnImage;
            }
            catch (Exception e)
            {
                // alert the user
                MessageBox.Show("Error1: " + e.Message);
                throw;
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            _scanner?.Dispose();
            textBox4.Text += "Scanner Closed" + "\r\n";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _scanner?.Dispose();
        }
    }
}