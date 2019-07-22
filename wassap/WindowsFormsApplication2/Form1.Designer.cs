namespace WindowsFormsApplication2
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
            this.msg = new System.Windows.Forms.TextBox();
            this.send = new System.Windows.Forms.Button();
            this.open = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.axcopc1 = new AxCOPC32.Axcopc();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.add = new System.Windows.Forms.Button();
            this.nomor = new System.Windows.Forms.TextBox();
            this.msg2 = new System.Windows.Forms.TextBox();
            this.time = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.axcopc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // msg
            // 
            this.msg.Location = new System.Drawing.Point(112, 81);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(138, 20);
            this.msg.TabIndex = 1;
            this.msg.TextChanged += new System.EventHandler(this.msg_TextChanged);
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(73, 179);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(126, 36);
            this.send.TabIndex = 2;
            this.send.Text = "Aktifkan";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(31, 29);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(219, 23);
            this.open.TabIndex = 3;
            this.open.Text = "Login dahulu!";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nomor Tujuan:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "M1000 value :";
            // 
            // axcopc1
            // 
            this.axcopc1.Enabled = true;
            this.axcopc1.Location = new System.Drawing.Point(0, -2);
            this.axcopc1.Name = "axcopc1";
            this.axcopc1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axcopc1.OcxState")));
            this.axcopc1.Size = new System.Drawing.Size(41, 37);
            this.axcopc1.TabIndex = 6;
            this.axcopc1.datChange += new System.EventHandler(this.axcopc1_datChange);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(281, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(313, 146);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(543, 31);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(51, 21);
            this.add.TabIndex = 10;
            this.add.Text = "Add";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // nomor
            // 
            this.nomor.Location = new System.Drawing.Point(362, 31);
            this.nomor.Name = "nomor";
            this.nomor.Size = new System.Drawing.Size(175, 20);
            this.nomor.TabIndex = 11;
            // 
            // msg2
            // 
            this.msg2.Location = new System.Drawing.Point(112, 107);
            this.msg2.Name = "msg2";
            this.msg2.Size = new System.Drawing.Size(138, 20);
            this.msg2.TabIndex = 12;
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(109, 55);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(0, 13);
            this.time.TabIndex = 13;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 227);
            this.Controls.Add(this.time);
            this.Controls.Add(this.msg2);
            this.Controls.Add(this.nomor);
            this.Controls.Add(this.add);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.axcopc1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.open);
            this.Controls.Add(this.send);
            this.Controls.Add(this.msg);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axcopc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox msg;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private AxCOPC32.Axcopc axcopc1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.TextBox nomor;
        private System.Windows.Forms.TextBox msg2;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Timer timer1;
    }
}

