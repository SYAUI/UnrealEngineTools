

using IniParser;

namespace UnrealEngineTools
{
    partial class Form_Main
    {

        private System.ComponentModel.IContainer components = null;

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
            button_refresh = new Button();
            listView1 = new ListView();
            index = new ColumnHeader();
            path = new ColumnHeader();
            radio_427 = new RadioButton();
            groupBox1 = new GroupBox();
            radio_426 = new RadioButton();
            radio_51 = new RadioButton();
            panel1 = new Panel();
            button_tex = new Button();
            button_blueprint = new Button();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button_refresh
            // 
            button_refresh.Location = new Point(12, 284);
            button_refresh.Name = "button_refresh";
            button_refresh.Size = new Size(75, 23);
            button_refresh.TabIndex = 1;
            button_refresh.Text = "刷新";
            button_refresh.UseVisualStyleBackColor = true;
            button_refresh.Click += button_refresh_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { index, path });
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(452, 266);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // index
            // 
            index.Text = "序号";
            index.Width = 40;
            // 
            // path
            // 
            path.Text = "工程路径";
            path.Width = 408;
            // 
            // radio_427
            // 
            radio_427.AutoSize = true;
            radio_427.Checked = true;
            radio_427.Location = new Point(6, 49);
            radio_427.Name = "radio_427";
            radio_427.Size = new Size(50, 21);
            radio_427.TabIndex = 3;
            radio_427.TabStop = true;
            radio_427.Text = "4.27\r\n";
            radio_427.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radio_426);
            groupBox1.Controls.Add(radio_51);
            groupBox1.Controls.Add(radio_427);
            groupBox1.Location = new Point(470, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 109);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "引擎版本";
            // 
            // radio_426
            // 
            radio_426.AutoSize = true;
            radio_426.Location = new Point(6, 22);
            radio_426.Name = "radio_426";
            radio_426.Size = new Size(50, 21);
            radio_426.TabIndex = 5;
            radio_426.TabStop = true;
            radio_426.Text = "4.26";
            radio_426.UseVisualStyleBackColor = true;
            // 
            // radio_51
            // 
            radio_51.AutoSize = true;
            radio_51.Location = new Point(6, 76);
            radio_51.Name = "radio_51";
            radio_51.Size = new Size(43, 21);
            radio_51.TabIndex = 4;
            radio_51.TabStop = true;
            radio_51.Text = "5.1";
            radio_51.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(button_blueprint);
            panel1.Controls.Add(button_tex);
            panel1.Location = new Point(588, 338);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 100);
            panel1.TabIndex = 5;
            // 
            // button_tex
            // 
            button_tex.Location = new Point(3, 3);
            button_tex.Name = "button_tex";
            button_tex.Size = new Size(75, 23);
            button_tex.TabIndex = 0;
            button_tex.Text = "图片处理";
            button_tex.UseVisualStyleBackColor = true;
            button_tex.Click += button_tex_Click;
            // 
            // button_blueprint
            // 
            button_blueprint.Location = new Point(84, 3);
            button_blueprint.Name = "button_blueprint";
            button_blueprint.Size = new Size(75, 23);
            button_blueprint.TabIndex = 1;
            button_blueprint.Text = "蓝图管理";
            button_blueprint.UseVisualStyleBackColor = true;
            button_blueprint.Click += button_blueprint_Click;
            // 
            // Form_Main
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Controls.Add(listView1);
            Controls.Add(button_refresh);
            Name = "Form_Main";
            Text = "Form_Main";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button button_refresh;
        private ListView listView1;
        private ColumnHeader index;
        private ColumnHeader path;
        private RadioButton radio_427;
        private GroupBox groupBox1;
        private RadioButton radio_51;
        private RadioButton radio_426;
        private Panel panel1;
        private Button button_tex;
        private Button button_blueprint;
    }
}