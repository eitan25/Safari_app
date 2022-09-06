
using System;

namespace Safari_app
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Zebra_radioButton = new System.Windows.Forms.RadioButton();
            this.Deer_radioButton = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.hunt_check_box = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lion_progress_bar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1000, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Zebra_radioButton);
            this.groupBox1.Controls.Add(this.Deer_radioButton);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(1009, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 192);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create animals";
            // 
            // Zebra_radioButton
            // 
            this.Zebra_radioButton.AutoSize = true;
            this.Zebra_radioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Zebra_radioButton.Location = new System.Drawing.Point(14, 126);
            this.Zebra_radioButton.Name = "Zebra_radioButton";
            this.Zebra_radioButton.Size = new System.Drawing.Size(69, 24);
            this.Zebra_radioButton.TabIndex = 4;
            this.Zebra_radioButton.TabStop = true;
            this.Zebra_radioButton.Text = "Zebra";
            this.Zebra_radioButton.UseVisualStyleBackColor = true;
            this.Zebra_radioButton.CheckedChanged += new System.EventHandler(this.Zebra_radioButton_CheckedChanged);
            // 
            // Deer_radioButton
            // 
            this.Deer_radioButton.AutoSize = true;
            this.Deer_radioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Deer_radioButton.Location = new System.Drawing.Point(14, 96);
            this.Deer_radioButton.Name = "Deer_radioButton";
            this.Deer_radioButton.Size = new System.Drawing.Size(62, 24);
            this.Deer_radioButton.TabIndex = 3;
            this.Deer_radioButton.TabStop = true;
            this.Deer_radioButton.Text = "Deer";
            this.Deer_radioButton.UseVisualStyleBackColor = true;
            this.Deer_radioButton.CheckedChanged += new System.EventHandler(this.Deer_radioButton_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton3.Location = new System.Drawing.Point(14, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(75, 24);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Giraffe";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.Giraffe_radioButton_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton2.Location = new System.Drawing.Point(14, 35);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(74, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Rabbit";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.Rabbit_radioButton_CheckedChanged);
            // 
            // hunt_check_box
            // 
            this.hunt_check_box.AutoSize = true;
            this.hunt_check_box.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hunt_check_box.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hunt_check_box.Location = new System.Drawing.Point(1031, 279);
            this.hunt_check_box.Name = "hunt_check_box";
            this.hunt_check_box.Size = new System.Drawing.Size(67, 24);
            this.hunt_check_box.TabIndex = 0;
            this.hunt_check_box.Text = "Hunt!";
            this.hunt_check_box.UseVisualStyleBackColor = true;
            this.hunt_check_box.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.moveTimerEvent);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(1023, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.save_button_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(1023, 422);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 29);
            this.button2.TabIndex = 3;
            this.button2.Text = "Load";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.open_button_Click);
            // 
            // lion_progress_bar
            // 
            this.lion_progress_bar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lion_progress_bar.ForeColor = System.Drawing.Color.Chartreuse;
            this.lion_progress_bar.Location = new System.Drawing.Point(1014, 309);
            this.lion_progress_bar.MarqueeAnimationSpeed = 20;
            this.lion_progress_bar.Name = "lion_progress_bar";
            this.lion_progress_bar.Size = new System.Drawing.Size(125, 23);
            this.lion_progress_bar.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1151, 507);
            this.Controls.Add(this.lion_progress_bar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.hunt_check_box);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Safary Application";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox hunt_check_box;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ProgressBar lion_progress_bar;
        private System.Windows.Forms.RadioButton Zebra_radioButton;
        private System.Windows.Forms.RadioButton Deer_radioButton;
    }
}

