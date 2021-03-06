
namespace Dictaphone
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonRecord = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelTimeRecord = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.labelTimeMode = new System.Windows.Forms.Label();
            this.labelModeDictaphone = new System.Windows.Forms.Label();
            this.labelChargePercent = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackgroundImage = global::Dictaphone.Properties.Resources.play;
            this.buttonPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonPlay.Location = new System.Drawing.Point(12, 80);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(40, 40);
            this.buttonPlay.TabIndex = 2;
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonRecord
            // 
            this.buttonRecord.BackgroundImage = global::Dictaphone.Properties.Resources.on;
            this.buttonRecord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRecord.Location = new System.Drawing.Point(301, 61);
            this.buttonRecord.Name = "buttonRecord";
            this.buttonRecord.Size = new System.Drawing.Size(60, 60);
            this.buttonRecord.TabIndex = 4;
            this.buttonRecord.UseVisualStyleBackColor = true;
            this.buttonRecord.Click += new System.EventHandler(this.buttonRecord_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelTimeRecord
            // 
            this.labelTimeRecord.AutoSize = true;
            this.labelTimeRecord.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTimeRecord.Location = new System.Drawing.Point(312, 13);
            this.labelTimeRecord.Name = "labelTimeRecord";
            this.labelTimeRecord.Size = new System.Drawing.Size(40, 28);
            this.labelTimeRecord.TabIndex = 5;
            this.labelTimeRecord.Text = ".......";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(232, 28);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Audio recordings";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(163, 86);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(72, 29);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.BackgroundImage = global::Dictaphone.Properties.Resources.stop;
            this.buttonStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonStop.Location = new System.Drawing.Point(58, 81);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(40, 40);
            this.buttonStop.TabIndex = 9;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // labelTimeMode
            // 
            this.labelTimeMode.AutoSize = true;
            this.labelTimeMode.Location = new System.Drawing.Point(13, 140);
            this.labelTimeMode.Name = "labelTimeMode";
            this.labelTimeMode.Size = new System.Drawing.Size(12, 20);
            this.labelTimeMode.TabIndex = 10;
            this.labelTimeMode.Text = ".";
            // 
            // labelModeDictaphone
            // 
            this.labelModeDictaphone.AutoSize = true;
            this.labelModeDictaphone.Location = new System.Drawing.Point(107, 140);
            this.labelModeDictaphone.Name = "labelModeDictaphone";
            this.labelModeDictaphone.Size = new System.Drawing.Size(12, 20);
            this.labelModeDictaphone.TabIndex = 11;
            this.labelModeDictaphone.Text = ".";
            // 
            // labelChargePercent
            // 
            this.labelChargePercent.AutoSize = true;
            this.labelChargePercent.Location = new System.Drawing.Point(245, 140);
            this.labelChargePercent.Name = "labelChargePercent";
            this.labelChargePercent.Size = new System.Drawing.Size(12, 20);
            this.labelChargePercent.TabIndex = 12;
            this.labelChargePercent.Text = ".";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(301, 140);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(83, 24);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = ">-------";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 163);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.labelChargePercent);
            this.Controls.Add(this.labelModeDictaphone);
            this.Controls.Add(this.labelTimeMode);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelTimeRecord);
            this.Controls.Add(this.buttonRecord);
            this.Controls.Add(this.buttonPlay);
            this.MaximumSize = new System.Drawing.Size(400, 210);
            this.MinimumSize = new System.Drawing.Size(400, 210);
            this.Name = "Form1";
            this.Text = "Dictaphone";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonRecord;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelTimeRecord;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label labelTimeMode;
        private System.Windows.Forms.Label labelModeDictaphone;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label labelChargePercent;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

