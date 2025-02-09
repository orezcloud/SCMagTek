namespace SCMagTek
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.click = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.front = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Web.UI.WebControls.Button();
            this.back = new System.Windows.Forms.RadioButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // click
            // 
            this.click.Location = new System.Drawing.Point(24, 128);
            this.click.Name = "click";
            this.click.Size = new System.Drawing.Size(75, 23);
            this.click.TabIndex = 0;
            this.click.Text = "Initialize";
            this.click.UseVisualStyleBackColor = true;
            this.click.Click += new System.EventHandler(this.InitBtnClick);
            // 
            // textBox1
            // 
            this.textBox1.AccessibleName = "";
            this.textBox1.Location = new System.Drawing.Point(24, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(113, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(169, 66);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(303, 66);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 3;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(727, 62);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 24);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Break State";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(433, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "Parity";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(580, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "Stop Bits";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 15;
            this.label3.Text = "port name";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(170, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 16;
            this.label4.Text = "bout rate";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(303, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "data bit";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(24, 223);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(409, 260);
            this.textBox4.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(24, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 23);
            this.label6.TabIndex = 19;
            this.label6.Text = "Result";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(433, 65);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 20;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(580, 65);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(27, 96);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(110, 23);
            this.label7.TabIndex = 22;
            this.label7.Text = "e.g. COM1, COM2, etc.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(461, 231);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(533, 205);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 547);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.close_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(461, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 25;
            this.label8.Text = "Image Display Here";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label9.ForeColor = System.Drawing.Color.Gray;
            this.label9.Location = new System.Drawing.Point(160, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 46);
            this.label9.TabIndex = 26;
            this.label9.Text = "usually 9600, 19200, 38400, 57600, or 115200";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label10.ForeColor = System.Drawing.Color.Gray;
            this.label10.Location = new System.Drawing.Point(309, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 27;
            this.label10.Text = "Usually 7 or 8";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Calibri", 36F, ((System.Drawing.FontStyle) ((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(824, 517);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(208, 67);
            this.label11.TabIndex = 28;
            this.label11.Text = "MAGTEK SCANNER";
            // 
            // front
            // 
            this.front.Checked = true;
            this.front.Location = new System.Drawing.Point(185, 149);
            this.front.Name = "front";
            this.front.Size = new System.Drawing.Size(104, 24);
            this.front.TabIndex = 29;
            this.front.TabStop = true;
            this.front.Text = "Front";
            this.front.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.ID = null;
            this.button2.Text = "button2";
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(247, 149);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(104, 24);
            this.back.TabIndex = 30;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon) (resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.openToolStripMenuItem, this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 593);
            this.Controls.Add(this.back);
            this.Controls.Add(this.front);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.click);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

        private System.Windows.Forms.NotifyIcon notifyIcon1;

        private System.Windows.Forms.RadioButton back;
        private System.Windows.Forms.RadioButton front;

        private System.Web.UI.WebControls.Button button2;

        private System.Windows.Forms.RadioButton radioButton1;

        private System.Windows.Forms.Label label11;

        private System.Windows.Forms.Label label10;

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.ComboBox comboBox2;

        private System.Windows.Forms.ComboBox comboBox1;

        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.TextBox textBox4;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.CheckBox checkBox1;

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;

        #endregion

        private System.Windows.Forms.Button click;
    }
}

