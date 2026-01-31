using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

enum FormType
{
    Form_Tex,
    Form_Manager
}

namespace UnrealEngineTools
{
    public partial class Form_Main : Form
    {
        private string inipath;
        private List<string> ue_project;
        private string default_version = "4.27\\Saved\\Config\\Windows\\EditorSettings.ini";
        private Dictionary<FormType, Form> Forms = new Dictionary<FormType, Form>();

        public Form_Main()
        {
            InitializeComponent();
            InitializeListView();
        }

        private void InitializeListView()
        {
            inipath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\UnrealEngine\\" + default_version;
            // 读取文件所有行
            string[] lines = File.ReadAllLines(inipath);

            // 筛选符合条件的行并提取路径
            int i = 0;
            string text;
            foreach (var line in lines)
            {
                i++;
                if (line.StartsWith("RecentlyOpenedProjectFiles=", StringComparison.Ordinal))
                {
                    ListViewItem lvi = new ListViewItem(i.ToString());
                    text = line.Split('=', 2)[1];
                    lvi.SubItems.Add(text);
                    listView1.Items.Add(lvi);
                }
            }
        }


        private void add_form(FormType ftype) // 添加窗口
        {
            if (!Forms.ContainsKey(ftype))
            {
                Form newform;
                switch (ftype)
                {
                    case FormType.Form_Tex:
                        newform = new Form_Tex();
                        break;
                    case FormType.Form_Manager:
                        newform = new Form_Manager();
                        break;

                    default:
                        Console.WriteLine("Unknown");
                        return;
                }
                newform.Show();
                newform.FormClosed += (s, args) =>
                {
                    Forms.Remove(ftype);
                };
                Forms[ftype] = newform;

            }
            else
                Forms[ftype].Activate();

        }




        private void button_refresh_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            InitializeListView();
        }

        private void button_tex_Click(object sender, EventArgs e)
        {
            add_form(FormType.Form_Tex);
        }

        private void button_blueprint_Click(object sender, EventArgs e)
        {
            add_form(FormType.Form_Manager);
        }
    }
}
