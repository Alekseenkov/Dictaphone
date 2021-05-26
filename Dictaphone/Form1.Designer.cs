
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
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(3, 92);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(94, 29);
            this.buttonPlay.TabIndex = 2;
            this.buttonPlay.Text = "Play";
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
            this.buttonDelete.Location = new System.Drawing.Point(163, 92);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(72, 29);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 150);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelTimeRecord);
            this.Controls.Add(this.buttonRecord);
            this.Controls.Add(this.buttonPlay);
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
    }
}

