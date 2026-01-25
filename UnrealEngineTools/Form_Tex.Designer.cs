namespace UnrealEngineTools
{
    partial class Form_Tex
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
            button_split = new Button();
            button_load = new Button();
            pictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // button_split
            // 
            button_split.Location = new Point(12, 352);
            button_split.Name = "button_split";
            button_split.Size = new Size(75, 23);
            button_split.TabIndex = 0;
            button_split.Text = "通道拆分";
            button_split.UseVisualStyleBackColor = true;
            button_split.Click += button_split_Click;
            // 
            // button_load
            // 
            button_load.Location = new Point(93, 352);
            button_load.Name = "button_load";
            button_load.Size = new Size(75, 23);
            button_load.TabIndex = 1;
            button_load.Text = "载入图片";
            button_load.UseVisualStyleBackColor = true;
            button_load.Click += button_load_Click;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(12, 12);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(368, 212);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 2;
            pictureBox.TabStop = false;
            // 
            // Form_Tex
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox);
            Controls.Add(button_load);
            Controls.Add(button_split);
            Name = "Form_Tex";
            Text = "Form1";
            Load += Form_Tex_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button_split;
        private Button button_load;
        private PictureBox pictureBox;
    }
}