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
            button_merge = new Button();
            checkBox_merge = new CheckBox();
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
            pictureBox.Size = new Size(575, 334);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 2;
            pictureBox.TabStop = false;
            // 
            // button_merge
            // 
            button_merge.Location = new Point(174, 352);
            button_merge.Name = "button_merge";
            button_merge.Size = new Size(75, 23);
            button_merge.TabIndex = 3;
            button_merge.Text = "合并通道";
            button_merge.UseVisualStyleBackColor = true;
            button_merge.Click += button_merge_Click;
            // 
            // checkBox_merge
            // 
            checkBox_merge.AutoSize = true;
            checkBox_merge.Location = new Point(255, 352);
            checkBox_merge.Name = "checkBox_merge";
            checkBox_merge.Size = new Size(112, 21);
            checkBox_merge.TabIndex = 4;
            checkBox_merge.Text = "含有Alpha 通道";
            checkBox_merge.UseVisualStyleBackColor = true;
            // 
            // Form_Tex
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(606, 450);
            Controls.Add(button_merge);
            Controls.Add(checkBox_merge);
            Controls.Add(pictureBox);
            Controls.Add(button_load);
            Controls.Add(button_split);
            Name = "Form_Tex";
            Text = "Form_Tex";
            Load += Form_Tex_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_split;
        private Button button_load;
        private PictureBox pictureBox;
        private Button button_merge;
        private ListView listView1;
        private CheckBox checkBox_merge;
    }
}