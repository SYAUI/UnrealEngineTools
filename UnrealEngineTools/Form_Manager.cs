using System.Data;
using System.Data.SQLite;
using System.Reflection;


namespace UnrealEngineTools
{

    public partial class Form_Manager : Form
    {
        public Form_Manager()
        {
            InitializeComponent();
        }
        private string BPNClipboardData = string.Empty;
        private Bitmap? BPNBitMap;
        private bool BPNDataValid = false;
        private bool BPNNameValid = false;



        private void b_Query_Click(object sender, EventArgs e)
        {
            DataSet ds = DBUtility.SQLiteHelper.GetList("blueprintnode", "name,desc,image", "");
            dataGridView1.DataSource = ds.Tables[0];
            b_copynode.Enabled = true;
        }



        private void t_name_Leave(object sender, EventArgs e)
        {
            if (DBUtility.SQLiteHelper.IsDataExists("blueprintnode", "name", t_name.Text) || (t_name.Text == ""))
            {
                label_add.Text = "命名不可用";
                err_name.SetError(t_name, "请使用唯一命名，不可为空");
                BPNNameValid = false;
            }
            else
            {
                if (BPNDataValid)
                    label_add.Text = "写入准备就绪";
                else
                    label_add.Text = "命名可用";
                BPNNameValid = true;
                err_name.Clear();
            }
        }

        private void b_iputbpn_Click(object sender, EventArgs e)
        {
            IDataObject data = Clipboard.GetDataObject();
            if (data.GetDataPresent(typeof(string)))//验证是否是字符串
            {
                BPNClipboardData = (string)data.GetData(typeof(string));
                if (BPNClipboardData.StartsWith("Begin Object Class"))
                {
                    BPNDataValid = true;
                    if (BPNNameValid)
                        label_add.Text = "写入准备就绪";
                    else
                        label_add.Text = "蓝图已载入缓存";
                    err_BPNdata.Clear();
                }
                else
                {
                    err_BPNdata.SetError(b_iputbpn, "剪贴板内容不为蓝图节点");
                    BPNDataValid = false;
                }
            }


        }
        private void b_inputIMG_Click(object sender, EventArgs e)
        {
            IDataObject data = Clipboard.GetDataObject();
            if (data.GetDataPresent(typeof(Bitmap)))//验证是否是图片
            {
                BPNBitMap = (Bitmap)data.GetData(typeof(Bitmap));
                label_add.Text = "截图已载入缓存";
            }
            else
            {
                label_add.Text = "错误图片类型";
            }
        }

        private void b_add_Click(object sender, EventArgs e)
        {
            if (BPNDataValid && BPNNameValid)
            {
                SQLiteParameter[] parameters = {
                    new SQLiteParameter("@name", DbType.String,32),
                    new SQLiteParameter("@src", DbType.String),
                    new SQLiteParameter("@desc", DbType.String),
                    new SQLiteParameter("@image", DbType.Binary)};
                parameters[0].Value = t_name.Text;
                parameters[1].Value = BPNClipboardData;
                parameters[2].Value = t_desc.Text;
                parameters[3].Value = BPNBitMap;
                DBUtility.SQLiteHelper.ExecuteNonQuery("insert into blueprintnode VALUES (@name,@src,@desc,@image)", parameters);

            }
            else { MessageBox.Show("数据输入有误！请检查！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void b_copynode_Click(object sender, EventArgs e)
        {
            string? localname = "'" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
            DataSet ds = DBUtility.SQLiteHelper.GetList("blueprintnode", "src", "name = " + localname);
            localname = ds.Tables[0].Rows[0][0].ToString();
            ds.Dispose();
            Clipboard.SetDataObject(localname);
            MessageBox.Show("节点已复制到剪贴板，请到引擎中粘贴。", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public partial class BPNInfo
    {
        public BPNInfo()
        { }
        #region Structure
        private string _Name = string.Empty;
        private string _BPNClipboardData = string.Empty;
        private string _Desc = string.Empty;
        private Bitmap? _BPNBitMap;

        /// <summary>
        /// 名字
        /// </summary>
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }

        /// <summary>
        /// 剪贴板蓝图节点数据
        /// </summary>
        public string BPNClipboardData
        {
            set { _BPNClipboardData = value; }
            get { return _BPNClipboardData; }
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string Desc
        {
            set { _Desc = value; }
            get { return _Desc; }
        }

        /// <summary>
        /// 截图数据
        /// </summary>
        public Bitmap? BPNBitMap
        {
            set { _BPNBitMap = value; }
            get { return _BPNBitMap; }
        }

        #endregion Structure

    }
}
