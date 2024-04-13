namespace PDF_Tools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBoxFile1 = new TextBox();
            buttonFile1 = new Button();
            buttonFile2 = new Button();
            textBoxFile2 = new TextBox();
            buttonMerge = new Button();
            textBoxDestination = new TextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            groupBox1 = new GroupBox();
            progressBar1 = new ProgressBar();
            buttonDestination = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxFile1
            // 
            textBoxFile1.Location = new Point(103, 70);
            textBoxFile1.Name = "textBoxFile1";
            textBoxFile1.Size = new Size(473, 23);
            textBoxFile1.TabIndex = 0;
            textBoxFile1.UseWaitCursor = true;
            textBoxFile1.TextChanged += textBoxFile1_TextChanged;
            // 
            // buttonFile1
            // 
            buttonFile1.Location = new Point(598, 72);
            buttonFile1.Name = "buttonFile1";
            buttonFile1.Size = new Size(75, 23);
            buttonFile1.TabIndex = 1;
            buttonFile1.Text = "File 1";
            buttonFile1.UseVisualStyleBackColor = true;
            buttonFile1.UseWaitCursor = true;
            buttonFile1.Click += buttonFile1_Click;
            // 
            // buttonFile2
            // 
            buttonFile2.Location = new Point(598, 147);
            buttonFile2.Name = "buttonFile2";
            buttonFile2.Size = new Size(75, 23);
            buttonFile2.TabIndex = 3;
            buttonFile2.Text = "File 2";
            buttonFile2.UseVisualStyleBackColor = true;
            buttonFile2.UseWaitCursor = true;
            buttonFile2.Click += buttonFile2_Click;
            // 
            // textBoxFile2
            // 
            textBoxFile2.Location = new Point(103, 145);
            textBoxFile2.Name = "textBoxFile2";
            textBoxFile2.Size = new Size(473, 23);
            textBoxFile2.TabIndex = 2;
            textBoxFile2.UseWaitCursor = true;
            textBoxFile2.TextChanged += textBoxFile2_TextChanged;
            // 
            // buttonMerge
            // 
            buttonMerge.Enabled = false;
            buttonMerge.Location = new Point(626, 352);
            buttonMerge.Name = "buttonMerge";
            buttonMerge.Size = new Size(75, 23);
            buttonMerge.TabIndex = 4;
            buttonMerge.Text = "Merge Files";
            buttonMerge.UseVisualStyleBackColor = true;
            buttonMerge.UseWaitCursor = true;
            buttonMerge.Click += buttonMerge_Click;
            // 
            // textBoxDestination
            // 
            textBoxDestination.Location = new Point(131, 294);
            textBoxDestination.Name = "textBoxDestination";
            textBoxDestination.Size = new Size(473, 23);
            textBoxDestination.TabIndex = 5;
            textBoxDestination.UseWaitCursor = true;
            textBoxDestination.TextChanged += textBoxDestination_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.AccessibleRole = AccessibleRole.TitleBar;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(13, 33);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(72, 72);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.UseWaitCursor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.AccessibleRole = AccessibleRole.TitleBar;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(13, 121);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(72, 72);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            pictureBox2.UseWaitCursor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox2);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(textBoxFile1);
            groupBox1.Controls.Add(buttonFile1);
            groupBox1.Controls.Add(buttonFile2);
            groupBox1.Controls.Add(textBoxFile2);
            groupBox1.Location = new Point(28, 33);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(685, 230);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Files to Merge";
            groupBox1.UseWaitCursor = true;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(131, 352);
            progressBar1.MarqueeAnimationSpeed = 0;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(473, 23);
            progressBar1.Step = 100;
            progressBar1.TabIndex = 10;
            progressBar1.UseWaitCursor = true;
            // 
            // buttonDestination
            // 
            buttonDestination.Location = new Point(626, 293);
            buttonDestination.Name = "buttonDestination";
            buttonDestination.Size = new Size(75, 23);
            buttonDestination.TabIndex = 11;
            buttonDestination.Text = "Destination";
            buttonDestination.UseVisualStyleBackColor = true;
            buttonDestination.UseWaitCursor = true;
            buttonDestination.Click += buttonDestination_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonDestination);
            Controls.Add(progressBar1);
            Controls.Add(textBoxDestination);
            Controls.Add(buttonMerge);
            Controls.Add(groupBox1);
            Name = "Form1";
            ShowIcon = false;
            Text = "PDF Merge";
            UseWaitCursor = true;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxFile1;
        private Button buttonFile1;
        private Button buttonFile2;
        private TextBox textBoxFile2;
        private Button buttonMerge;
        private TextBox textBoxDestination;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private GroupBox groupBox1;
        private ProgressBar progressBar1;
        private Button buttonDestination;
    }
}
