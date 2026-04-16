using Microsoft.VisualBasic.FileIO;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

enum FormType
{
    Form_Tex,
    Form_Manager
}

namespace UnrealEngineTools
{
    public partial class Form_Main : Form
    {
        private string inipath, project_path;
        StringBuilder tmp_sb = new StringBuilder(60);
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
                    //i++;
                    ListViewItem lvi = new ListViewItem(i.ToString());
                    text = line.Split('=', 2)[1];
                    lvi.SubItems.Add(text);
                    listView1.Items.Add(lvi);
                }
            }
        }

        private string openfilepath(string title, string filter)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = title;
            dialog.Filter = filter;
            if (dialog.ShowDialog() == DialogResult.OK)
                return dialog.FileName;
            else
                return "\0";
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

        private void radio_426_CheckedChanged(object sender, EventArgs e)
        {
            default_version = "4.26\\Saved\\Config\\Windows\\EditorSettings.ini";
            listView1.Items.Clear();
            InitializeListView();
        }

        private void radio_427_CheckedChanged(object sender, EventArgs e)
        {
            default_version = "4.27\\Saved\\Config\\Windows\\EditorSettings.ini";
            listView1.Items.Clear();
            InitializeListView();
        }

        private void radio_51_CheckedChanged(object sender, EventArgs e)
        {
            default_version = "5.1\\Saved\\Config\\WindowsEditor\\EditorSettings.ini";
            listView1.Items.Clear();
            InitializeListView();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                project_path = listView1.SelectedItems[0].SubItems[1].Text.ToString(); //第二项的值
                if (!File.Exists(project_path))
                {
                    MessageBox.Show("项目不存在或已被删除！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    b_launch.Enabled = false;
                    return;
                }
                tmp_sb.Clear();
                tmp_sb.Append(project_path);

                tmp_sb.Remove(tmp_sb.Length - 8, 8);
                tmp_sb.Append("png");
                // 释放图片内存
                if (project_tex.Image != null)
                    project_tex.Image.Dispose();

                if (File.Exists(tmp_sb.ToString())) // 判断自定义项目文件存在
                    project_tex.Image = System.Drawing.Image.FromFile(tmp_sb.ToString());
                else
                {
                    for (int i = tmp_sb.Length - 1; i > 0; i--)
                        if (tmp_sb[i] == '/')
                        {
                            tmp_sb.Length = i + 1;
                            break;
                        }
                    tmp_sb.Append("Saved/AutoScreenshot.png");
                    project_tex.Image = System.Drawing.Image.FromFile(tmp_sb.ToString());
                }
                b_launch.Enabled = true;
            }
        }

        private void b_launch_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo processStartInfo = new ProcessStartInfo(project_path);
            process.StartInfo = processStartInfo;
            process.StartInfo.UseShellExecute = true;
            process.Start();
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (project_path != null && project_path.Length != 0)
                project_path = Path.GetDirectoryName(project_path);
            else
                return;
            if ((int)MessageBox.Show("你确定需要删除此项目(" + project_path + ")吗", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != 1) { return; }
            {
                // 删除索引
                List<string> lines = System.IO.File.ReadAllLines(inipath, Encoding.Default).ToList();
                int i = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text.ToString()) - 1;
                lines.RemoveAt(i);//删除该项目所在行
                System.IO.File.WriteAllLines(inipath, lines, Encoding.Default);// 写回文件
                // 判断文件夹是否存在
                if (Directory.Exists(project_path))
                {
                    FileSystem.DeleteDirectory(project_path, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                    MessageBox.Show("已移除至回收站！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                listView1.Items.Clear();
                InitializeListView();
                return;
            }
        }

        private void b_getlink_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = false;

            string path = "文件或文件夹";
            ofd.FileName = path;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!ofd.FileName.Contains(path))
                {
                    path = ofd.FileName;
                    if (File.Exists(path))
                    {
                        MessageBox.Show("目标路径为：" + path, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    path = ofd.FileName;
                    path = path.Substring(0, path.Length - 6);
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    if (dirInfo.Attributes.HasFlag(FileAttributes.ReparsePoint))
                    {
                        path = Directory.ResolveLinkTarget(path, true).FullName;
                        MessageBox.Show("文件夹真实路径为：" + path, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show("目标文件夹不是一个目录链接", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }



        }

        private void b_getlink2_Click(object sender, EventArgs e)
        {
            string linkPath = t_link.Text;
            if (File.Exists(linkPath))
            {
                FileInfo fileInfo = new FileInfo(linkPath);
                if (fileInfo.LinkTarget != null)
                    linkPath = fileInfo.LinkTarget;
               
                MessageBox.Show("目标路径为：" + linkPath, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (Directory.Exists(linkPath))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(linkPath);
                if (dirInfo.LinkTarget != null)
                    linkPath = dirInfo.LinkTarget;

                MessageBox.Show("目标路径为：" + linkPath, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("目标不存在", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
