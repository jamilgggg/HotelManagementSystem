namespace Hotel_Management_System_Guardiana
{
    partial class DisplayInvoice
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
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.RoomNo = new System.Windows.Forms.Label();
            this.RoomNum = new System.Windows.Forms.TextBox();
            this.Days = new System.Windows.Forms.TextBox();
            this.Total = new System.Windows.Forms.TextBox();
            this.IssuedBy = new System.Windows.Forms.TextBox();
            this.IssuedTo = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(102, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "The Palms Resort";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Room No:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "No of Days:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(132, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 30;
            this.label3.Text = "Total:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(12, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Issued to (Guest):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(99, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "Issued by:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(122, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 34);
            this.button1.TabIndex = 31;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RoomNo
            // 
            this.RoomNo.AutoSize = true;
            this.RoomNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.RoomNo.Location = new System.Drawing.Point(102, 59);
            this.RoomNo.Name = "RoomNo";
            this.RoomNo.Size = new System.Drawing.Size(0, 20);
            this.RoomNo.TabIndex = 30;
            // 
            // RoomNum
            // 
            this.RoomNum.Enabled = false;
            this.RoomNum.Location = new System.Drawing.Point(148, 59);
            this.RoomNum.Name = "RoomNum";
            this.RoomNum.Size = new System.Drawing.Size(126, 20);
            this.RoomNum.TabIndex = 33;
            // 
            // Days
            // 
            this.Days.Enabled = false;
            this.Days.Location = new System.Drawing.Point(148, 92);
            this.Days.Name = "Days";
            this.Days.Size = new System.Drawing.Size(126, 20);
            this.Days.TabIndex = 33;
            // 
            // Total
            // 
            this.Total.Enabled = false;
            this.Total.Location = new System.Drawing.Point(178, 199);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(126, 20);
            this.Total.TabIndex = 33;
            // 
            // IssuedBy
            // 
            this.IssuedBy.Enabled = false;
            this.IssuedBy.Location = new System.Drawing.Point(178, 231);
            this.IssuedBy.Name = "IssuedBy";
            this.IssuedBy.Size = new System.Drawing.Size(201, 20);
            this.IssuedBy.TabIndex = 33;
            // 
            // IssuedTo
            // 
            this.IssuedTo.Enabled = false;
            this.IssuedTo.Location = new System.Drawing.Point(148, 127);
            this.IssuedTo.Name = "IssuedTo";
            this.IssuedTo.Size = new System.Drawing.Size(201, 20);
            this.IssuedTo.TabIndex = 33;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(320, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(11, 10);
            this.dataGridView1.TabIndex = 41;
            this.dataGridView1.Visible = false;
            // 
            // DisplayInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(391, 322);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Total);
            this.Controls.Add(this.IssuedTo);
            this.Controls.Add(this.IssuedBy);
            this.Controls.Add(this.Days);
            this.Controls.Add(this.RoomNum);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RoomNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Name = "DisplayInvoice";
            this.Text = "Payables";
            this.Load += new System.EventHandler(this.DisplayInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label RoomNo;
        private System.Windows.Forms.TextBox RoomNum;
        private System.Windows.Forms.TextBox Days;
        private System.Windows.Forms.TextBox Total;
        private System.Windows.Forms.TextBox IssuedBy;
        private System.Windows.Forms.TextBox IssuedTo;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}