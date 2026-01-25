using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;

namespace UnrealEngineTools
{
    public partial class Form_Tex : Form
    {
        public Form_Tex()
        {
            InitializeComponent();
        }
        private bool TexDataValid = false;
        private string filepath;
        private Mat img;
        private Mat[] mats;

        private void Form_Tex_Load(object sender, EventArgs e)
        {

        }

        private void button_split_Click(object sender, EventArgs e)
        {
            if(TexDataValid)
            {
                // 读取图像
                img = Cv2.ImRead(filepath, ImreadModes.Unchanged);
                if(img != null)
                {
                    mats = Cv2.Split(img);//BGRA
                    FolderBrowserDialog dialog = new FolderBrowserDialog();
                    dialog.Description = "灰度通道保存路径";
                    dialog.InitialDirectory = Path.GetDirectoryName(filepath);
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string outpath = dialog.SelectedPath + Path.GetFileNameWithoutExtension(filepath);
                        mats[0].SaveImage(outpath + "_B.png");
                        mats[1].SaveImage(outpath + "_G.png");
                        mats[2].SaveImage(outpath + "_R.png");
                        int a = img.Channels();
                        if (img.Channels() > 3 )
                        {
                            mats[3].SaveImage(outpath + "_A.png");     
                        }
                    }
                }
            }
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "请选择文件";
            dialog.Filter = "图像文件(*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filepath = dialog.FileName;
                TexDataValid = true;
                pictureBox.Image = Image.FromFile(filepath);
            }
        }
    }
}
