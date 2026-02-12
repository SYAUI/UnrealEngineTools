using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;
using OpenCvSharp.Extensions;

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
            if (TexDataValid)
            {
                // 读取图像
                img = Cv2.ImRead(filepath, ImreadModes.Unchanged);
                if (img != null)
                {
                    mats = Cv2.Split(img);//BGRA
                    FolderBrowserDialog dialog = new FolderBrowserDialog();
                    dialog.Description = "灰度通道保存路径";
                    dialog.InitialDirectory = Path.GetDirectoryName(filepath);
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string outpath = dialog.SelectedPath + '\\' + Path.GetFileNameWithoutExtension(filepath);
                        mats[0].SaveImage(outpath + "_B.png");
                        mats[0].Dispose();
                        mats[1].SaveImage(outpath + "_G.png");
                        mats[1].Dispose();
                        mats[2].SaveImage(outpath + "_R.png");
                        mats[2].Dispose();
                        if (img.Channels() == 4)
                        {
                            mats[3].SaveImage(outpath + "_A.png");
                            mats[3].Dispose();
                        }
                        Array.Clear(mats);
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

        private void button_merge_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "请按RGBA顺序选择灰度图文件";
            dialog.Filter = "图像文件(*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            img = new Mat();

            if (checkBox_merge.Checked == true)
                mats = new Mat[4];
            else
                mats = new Mat[3];

            for (int i = 2;i >= 0; i--)
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    mats[i] = Cv2.ImRead(dialog.FileName, ImreadModes.Grayscale);//RGB -> BGR
                else
                    return;
            }

            if(checkBox_merge.Checked == true)
                if (dialog.ShowDialog() == DialogResult.OK)
                    mats[3] = Cv2.ImRead(dialog.FileName, ImreadModes.Grayscale);//A
                else
                    return;

            Cv2.Merge(mats, img);
            SaveFileDialog outpath = new SaveFileDialog();
            outpath.Title = "保存路径";
            outpath.FileName = Path.GetFileNameWithoutExtension(dialog.FileName) + "_ORM.png";//默认文档名
            outpath.Filter = "图像文件(*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            if (outpath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                Cv2.ImWrite(outpath.FileName, img);
            Bitmap bitmap = BitmapConverter.ToBitmap(img);
            //显示图片
            pictureBox.Image = bitmap;
        }
    }
}
