namespace UnrealEngineTools
{
    partial class Form_Manager
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            b_Query = new Button();
            b_add = new Button();
            t_name = new TextBox();
            t_desc = new TextBox();
            groupBox1 = new GroupBox();
            label_add = new Label();
            b_inputIMG = new Button();
            b_iputbpn = new Button();
            err_BPNdata = new ErrorProvider(components);
            err_name = new ErrorProvider(components);
            b_copynode = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)err_BPNdata).BeginInit();
            ((System.ComponentModel.ISupportInitialize)err_name).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(732, 306);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // b_Query
            // 
            b_Query.Location = new Point(12, 312);
            b_Query.Name = "b_Query";
            b_Query.Size = new Size(75, 23);
            b_Query.TabIndex = 1;
            b_Query.Text = "查询";
            b_Query.UseVisualStyleBackColor = true;
            b_Query.Click += b_Query_Click;
            // 
            // b_add
            // 
            b_add.Location = new Point(93, 312);
            b_add.Name = "b_add";
            b_add.Size = new Size(75, 23);
            b_add.TabIndex = 2;
            b_add.Text = "添加节点";
            b_add.UseVisualStyleBackColor = true;
            b_add.Click += b_add_Click;
            // 
            // t_name
            // 
            t_name.Location = new Point(6, 22);
            t_name.MaxLength = 32;
            t_name.Name = "t_name";
            t_name.PlaceholderText = "输入唯一名字";
            t_name.Size = new Size(100, 23);
            t_name.TabIndex = 3;
            t_name.Leave += t_name_Leave;
            // 
            // t_desc
            // 
            t_desc.Location = new Point(242, 22);
            t_desc.Multiline = true;
            t_desc.Name = "t_desc";
            t_desc.PlaceholderText = "输入功能描述";
            t_desc.Size = new Size(301, 52);
            t_desc.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox1.Controls.Add(label_add);
            groupBox1.Controls.Add(b_inputIMG);
            groupBox1.Controls.Add(b_iputbpn);
            groupBox1.Controls.Add(t_name);
            groupBox1.Controls.Add(t_desc);
            groupBox1.Location = new Point(174, 312);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(549, 88);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "节点数据添加";
            // 
            // label_add
            // 
            label_add.AutoSize = true;
            label_add.Location = new Point(6, 54);
            label_add.Name = "label_add";
            label_add.Size = new Size(80, 17);
            label_add.TabIndex = 7;
            label_add.Text = "写入尚未就绪";
            // 
            // b_inputIMG
            // 
            b_inputIMG.Location = new Point(141, 54);
            b_inputIMG.Name = "b_inputIMG";
            b_inputIMG.Size = new Size(75, 23);
            b_inputIMG.TabIndex = 6;
            b_inputIMG.Text = "粘贴截图";
            b_inputIMG.UseVisualStyleBackColor = true;
            b_inputIMG.Click += b_inputIMG_Click;
            // 
            // b_iputbpn
            // 
            b_iputbpn.Location = new Point(141, 22);
            b_iputbpn.Name = "b_iputbpn";
            b_iputbpn.Size = new Size(75, 23);
            b_iputbpn.TabIndex = 5;
            b_iputbpn.Text = "粘贴节点";
            b_iputbpn.UseVisualStyleBackColor = true;
            b_iputbpn.Click += b_iputbpn_Click;
            // 
            // err_BPNdata
            // 
            err_BPNdata.ContainerControl = this;
            // 
            // err_name
            // 
            err_name.ContainerControl = this;
            // 
            // b_copynode
            // 
            b_copynode.Enabled = false;
            b_copynode.Location = new Point(12, 360);
            b_copynode.Name = "b_copynode";
            b_copynode.Size = new Size(75, 23);
            b_copynode.TabIndex = 6;
            b_copynode.Text = "复制选中节点";
            b_copynode.UseVisualStyleBackColor = true;
            b_copynode.Click += b_copynode_Click;
            // 
            // Form_Manager
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 411);
            Controls.Add(b_copynode);
            Controls.Add(groupBox1);
            Controls.Add(b_add);
            Controls.Add(b_Query);
            Controls.Add(dataGridView1);
            Name = "Form_Manager";
            Text = "蓝图节点管理";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)err_BPNdata).EndInit();
            ((System.ComponentModel.ISupportInitialize)err_name).EndInit();
            ResumeLayout(false);
        }



        #endregion

        private DataGridView dataGridView1;
        private Button b_Query;
        private Button b_add;
        private TextBox t_name;
        private TextBox t_desc;
        private GroupBox groupBox1;
        private Button b_iputbpn;
        private ErrorProvider err_BPNdata;
        private Button b_inputIMG;
        private Label label_add;
        private ErrorProvider err_name;
        private Button b_copynode;
    }
}
