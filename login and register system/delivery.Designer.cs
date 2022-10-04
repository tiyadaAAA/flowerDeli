namespace login_and_register_system
{
    partial class delivery
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.รายการ2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameProduct2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyD2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(214, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 39);
            this.label1.TabIndex = 14;
            this.label1.Text = "Order";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(1, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 32);
            this.label2.TabIndex = 16;
            this.label2.Text = "Sender Information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(1, 293);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 32);
            this.label3.TabIndex = 20;
            this.label3.Text = "Delivery Information";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("JasmineUPC", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(7, 447);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 23;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("JasmineUPC", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ช่วงเช้า | Morning (8.00-12.00)",
            "ช่วงบ่าย | Afternoon (13.00-18.00)",
            "ช่วงเย็น | Evening (19.00-22.00)"});
            this.comboBox1.Location = new System.Drawing.Point(254, 437);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(269, 30);
            this.comboBox1.TabIndex = 24;
            this.comboBox1.Text = "Delivery time | เวลาจัดส่ง";
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("JasmineUPC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox7.Location = new System.Drawing.Point(298, 603);
            this.textBox7.MaxLength = 5;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(225, 33);
            this.textBox7.TabIndex = 26;
            this.textBox7.Text = "ZIP code | รหัสไปรษณีย์";
            this.textBox7.Enter += new System.EventHandler(this.textBox7_Enter);
            this.textBox7.Leave += new System.EventHandler(this.textBox7_Leave);
            // 
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("JasmineUPC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox8.Location = new System.Drawing.Point(7, 479);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(516, 106);
            this.textBox8.TabIndex = 25;
            this.textBox8.Text = "Shipping address | ที่อยู่ในการจัดส่ง";
            this.textBox8.Enter += new System.EventHandler(this.textBox8_Enter);
            this.textBox8.Leave += new System.EventHandler(this.textBox8_Leave);
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("JasmineUPC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox9.Location = new System.Drawing.Point(5, 651);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(516, 33);
            this.textBox9.TabIndex = 28;
            this.textBox9.Text = "Card Message(If) | การ์ดข้อความ(ถ้ามี)";
            this.textBox9.Enter += new System.EventHandler(this.textBox9_Enter);
            this.textBox9.Leave += new System.EventHandler(this.textBox9_Leave);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.DarkRed;
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(184, 747);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(172, 35);
            this.btnSubmit.TabIndex = 30;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("JasmineUPC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox2.Location = new System.Drawing.Point(7, 225);
            this.textBox2.MaxLength = 10;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(516, 33);
            this.textBox2.TabIndex = 32;
            this.textBox2.Text = "Phone Number | เบอร์โทรศัพท์";
            this.textBox2.Enter += new System.EventHandler(this.textBox2_Enter);
            this.textBox2.Leave += new System.EventHandler(this.textBox2_Leave);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("JasmineUPC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox1.Location = new System.Drawing.Point(7, 176);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(516, 33);
            this.textBox1.TabIndex = 31;
            this.textBox1.Text = "Name Lastname | ชื่อ สกุล";
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("JasmineUPC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox5.Location = new System.Drawing.Point(7, 386);
            this.textBox5.MaxLength = 10;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(516, 33);
            this.textBox5.TabIndex = 36;
            this.textBox5.Text = "Phone Number | เบอร์โทรศัพท์";
            this.textBox5.Enter += new System.EventHandler(this.textBox5_Enter);
            this.textBox5.Leave += new System.EventHandler(this.textBox5_Leave);
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("JasmineUPC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox6.Location = new System.Drawing.Point(7, 337);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(516, 33);
            this.textBox6.TabIndex = 35;
            this.textBox6.Text = "Name Lastname | ชื่อ สกุล";
            this.textBox6.Enter += new System.EventHandler(this.textBox6_Enter);
            this.textBox6.Leave += new System.EventHandler(this.textBox6_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("JasmineUPC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(2, 422);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 25);
            this.label6.TabIndex = 37;
            this.label6.Text = "Delivery date | วันที่จัดส่ง";
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox11.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox11.Font = new System.Drawing.Font("JasmineUPC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = new System.Drawing.Point(7, 603);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(269, 33);
            this.textBox11.TabIndex = 38;
            this.textBox11.Text = "Roi-Et | ร้อยเอ็ด";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(2, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 26);
            this.label7.TabIndex = 43;
            this.label7.Text = "subbb";
            this.label7.Visible = false;
            // 
            // dgv2
            // 
            this.dgv2.AllowUserToAddRows = false;
            this.dgv2.AllowUserToDeleteRows = false;
            this.dgv2.AllowUserToResizeColumns = false;
            this.dgv2.AllowUserToResizeRows = false;
            this.dgv2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv2.BackgroundColor = System.Drawing.Color.White;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.รายการ2,
            this.Username2,
            this.nameProduct2,
            this.qty2,
            this.cost2,
            this.buyD2});
            this.dgv2.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgv2.Location = new System.Drawing.Point(311, 38);
            this.dgv2.Name = "dgv2";
            this.dgv2.ReadOnly = true;
            this.dgv2.Size = new System.Drawing.Size(222, 105);
            this.dgv2.TabIndex = 50;
            this.dgv2.Visible = false;
            // 
            // รายการ2
            // 
            this.รายการ2.DataPropertyName = "รายการ2";
            this.รายการ2.HeaderText = "รายการ";
            this.รายการ2.Name = "รายการ2";
            this.รายการ2.ReadOnly = true;
            this.รายการ2.Visible = false;
            // 
            // Username2
            // 
            this.Username2.DataPropertyName = "Username2";
            this.Username2.HeaderText = "ผู้ใช้";
            this.Username2.Name = "Username2";
            this.Username2.ReadOnly = true;
            this.Username2.Visible = false;
            // 
            // nameProduct2
            // 
            this.nameProduct2.DataPropertyName = "nameProduct2";
            this.nameProduct2.FillWeight = 180.9938F;
            this.nameProduct2.HeaderText = "สินค้า";
            this.nameProduct2.Name = "nameProduct2";
            this.nameProduct2.ReadOnly = true;
            // 
            // qty2
            // 
            this.qty2.DataPropertyName = "qty2";
            this.qty2.FillWeight = 60.9137F;
            this.qty2.HeaderText = "จำนวน";
            this.qty2.Name = "qty2";
            this.qty2.ReadOnly = true;
            // 
            // cost2
            // 
            this.cost2.DataPropertyName = "cost2";
            this.cost2.FillWeight = 58.09251F;
            this.cost2.HeaderText = "ราคา";
            this.cost2.Name = "cost2";
            this.cost2.ReadOnly = true;
            // 
            // buyD2
            // 
            this.buyD2.DataPropertyName = "buyD2";
            this.buyD2.HeaderText = "วันที่";
            this.buyD2.Name = "buyD2";
            this.buyD2.ReadOnly = true;
            this.buyD2.Visible = false;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(28, 38);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(180, 69);
            this.listBox1.TabIndex = 51;
            this.listBox1.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(311, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 52;
            this.label10.Text = "totalna";
            this.label10.Visible = false;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(321, 703);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 53;
            this.dateTimePicker2.Visible = false;
            // 
            // delivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(562, 533);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "delivery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "delivery";
            this.Load += new System.EventHandler(this.delivery_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.DataGridViewTextBoxColumn รายการ2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameProduct2;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost2;
        private System.Windows.Forms.DataGridViewTextBoxColumn buyD2;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
    }
}