using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace TFLabelTool
{
    public partial class FormMain : Form
    {
        string outputPath = "";
        string imagePath = "";
        string labelMapPath = "";
        

        string imageDownloadPath = "";
        int imageDownloadCount = 10;
        string imageDownloadKey = "";
        string imageDownloadPre = "";
        int zoomWidth = 0;
        int zoomHeight = 0;

        string currentJPGName = "";
        string currentObjName = "";
        int currentObjIndex = -1;

        const int MaxPageIndex = 1000;

        const string LabelMapItemTemplate =
        @"item {
          id: {0}
          name: '{1}'
        }";

        BackgroundWorker downloadImageThread = new BackgroundWorker();
        bool isDownloadImageThreadRun = false;


        void CreateLabelMap()
        {
            var labelMapPathContent = "";
            int i = 1;
            foreach (var item in listBoxLableIndex.Items)
            {
                labelMapPathContent += LabelMapItemTemplate.Replace("{0}", i.ToString()).Replace("{1}", item.ToString()) + Environment.NewLine;
                i++;
            }
            File.WriteAllText(labelMapPath, labelMapPathContent);

        }

        void SaveObjectToConfig()
        {
            string lines = "";
            foreach (var item in listBoxLableIndex.Items)
            {
                lines += item + Environment.NewLine;
            }
            Properties.Settings.Default.objects = lines;
            Properties.Settings.Default.Save();
        }

        void LoadObjectFromConfig()
        {
            foreach (var item in Properties.Settings.Default.objects.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries))
            {
                listBoxLableIndex.Items.Add(item);
            }
            if (listBoxLableIndex.Items.Count > 0)
            {
                listBoxLableIndex.SelectedIndex = 0;
            }

        }

        void LoadFiles()
        {
            listBoxFiles.Items.Clear();
            var dir = new DirectoryInfo(imagePath);
            foreach (var file in dir.GetFiles())
            {
                if (file.Extension == ".jpg")
                    listBoxFiles.Items.Add(file.FullName);
            }
        }

        void SaveLabelFile()
        {
            var txt = GetLableFilePath(listBoxFiles.SelectedItem.ToString());
            File.Delete(txt);
            var content = "";
            foreach (var item in listBoxLable.Items)
            {
                content += item+"\n";
            }
            File.AppendAllText(txt, content.Trim());


        }


        public FormMain()
        {
            InitializeComponent();
        }


        private void FormMain_Load(object sender, EventArgs e)
        {



            outputPath = String.Format("{0}\\{1}", Application.StartupPath, "output");
            imagePath = String.Format("{0}\\{1}\\", outputPath, "image");
            labelMapPath = String.Format("{0}\\{1}", outputPath, "label_map.pbtxt");
            imageDownloadPath = String.Format("{0}\\{1}", Application.StartupPath, "download");


            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }
            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }
            if (!Directory.Exists(imageDownloadPath))
            {
                Directory.CreateDirectory(imageDownloadPath);
            }

            //DownloadPic.process("小兔子", 1, imageDownloadPath);

            LoadFiles();

            textBoxImport.Text = Properties.Settings.Default.imagePath;
            LoadObjectFromConfig();
            CreateLabelMap();
            downloadImageThread.DoWork += new DoWorkEventHandler(downloadImageThread_DoWork);
            downloadImageThread.ProgressChanged += new ProgressChangedEventHandler(downloadImageThread_ProgressChanged);
            downloadImageThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(downloadImageThread_RunWorkerCompleted);
            downloadImageThread.WorkerReportsProgress = true;

        }

        void downloadImageThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarDownloadImage.Value = 0;
            buttonDownlaodImage.Text = "启动";
        }

        void downloadImageThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelCount.Text =((int) e.ProgressPercentage).ToString();
            progressBarDownloadImage.Value = (int)((float)e.ProgressPercentage * 100 / (int)numericUpDownCount.Value);

        }

        void downloadImageThread_DoWork(object sender, DoWorkEventArgs e)
        {
            int imageCount = 0;
            for (int i = 0; i < MaxPageIndex; i++)
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://image.baidu.com/search/avatarjson?tn=resultjsonavatarnew&ie=utf-8&word="
                    + Uri.EscapeUriString(imageDownloadKey) + "&cg=girl&pn=" + (i + 1) * 60 + "&rn=60&itg=0&z=0&fr=&width=&height=&lm=-1&ic=0&s=0&st=-1&gsm=360600003c");
                using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
                {
                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream stream = res.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                string json = reader.ReadToEnd();
                                JObject objRoot = (JObject)JsonConvert.DeserializeObject(json);
                                JArray imgs = (JArray)objRoot["imgs"];
                                for (int j = 0; j < imgs.Count; j++)
                                {
                                    if (!isDownloadImageThreadRun)
                                    {
                                        return;
                                    }
                                    JObject img = (JObject)imgs[j];
                                    string objUrl = (string)img["objURL"];
                                    try
                                    {
                                        string path = String.Format("{0}/{1}.jpg", imageDownloadPath,imageDownloadPre+ imageCount.ToString());
                                        HttpWebRequest reqImage = (HttpWebRequest)WebRequest.Create(objUrl);
                                        reqImage.Referer = "http://image.baidu.com/";
                                        using (HttpWebResponse resImage = (HttpWebResponse)reqImage.GetResponse())
                                        {
                                            if (resImage.StatusCode == HttpStatusCode.OK)
                                            {
                                                using (Stream streamImage = resImage.GetResponseStream())
                                                {
                                                        Bitmap b=new Bitmap(streamImage);
                                                        ZoomImage(b, zoomHeight, zoomWidth).Save(path,System.Drawing.Imaging.ImageFormat.Jpeg);
                                                        imageCount++;
                                                        downloadImageThread.ReportProgress(imageCount);
                                                        if (imageCount>=imageDownloadCount)
                                                        {
                                                            return;
                                                        }
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        BeginInvoke(new Action(() => {
                                            richTextBoxInfo.AppendText(ex.Message);
                                        }));
                                    }
                                }

                            }
                        }
                    }
                    else
                    {

                    }

                }
            }
        }



        private void listBoxFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            label7.Text = "";
            if (listBoxFiles.SelectedItem != null)
            {
                currentJPGName = Path.GetFileName(listBoxFiles.SelectedItem.ToString());


                var jpgPath = listBoxFiles.SelectedItem.ToString();
                pictureBox1.ImageLocation = jpgPath;
                var txt = jpgPath.Replace(".jpg", ".txt");
                listBoxLable.Items.Clear();
                if (File.Exists(txt))
                {
                    foreach (var item in File.ReadAllLines(txt.Trim()))
                    {
                        listBoxLable.Items.Add(item);
                    }

                }
                ClearSelect();
            }
        }
        private Point RectStartPoint;
        private Rectangle Rect = new Rectangle();
        private Brush selectionBrush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));


        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            RectStartPoint = e.Location;
            Invalidate();
        }

        private void pictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            Debug.WriteLine(e.Location.ToString());
            Point tempEndPoint = e.Location;
            Rect.Location = new Point(
                Math.Min(RectStartPoint.X, tempEndPoint.X),
                Math.Min(RectStartPoint.Y, tempEndPoint.Y));
            Rect.Size = new Size(
                Math.Abs(RectStartPoint.X - tempEndPoint.X),
                Math.Abs(RectStartPoint.Y - tempEndPoint.Y));
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (Rect != null && Rect.Width > 0 && Rect.Height > 0)
                {
                    e.Graphics.FillRectangle(selectionBrush, Rect);
                }
            }
        }


        void ClearSelect()
        {
            Rect.Size = new Size(0, 0);
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (listBoxLableIndex.Items.Count == 0)
                {
                    MessageBox.Show("请先在界面右上角处添加对象，比如car");
                    ClearSelect();
                    return;
                }
                if (listBoxLableIndex.SelectedIndex == -1)
                {
                    MessageBox.Show("请先在界面右上角对象列表里选择一个对象");
                    ClearSelect();
                    return;
                }
                if (RectStartPoint == e.Location)
                {
                    return;
                }

                if (RectStartPoint.X > e.Location.X || RectStartPoint.Y > e.Location.Y)
                {
                    MessageBox.Show("亲,只能从左上向右下选");
                    ClearSelect();
                    return;
                }



                var height = (double)pictureBox1.Height;
                var width = (double)pictureBox1.Width;
                var filename = currentJPGName;
                var image_format = "Jpeg";

                var xmins = RectStartPoint.X / width;
                var ymins = RectStartPoint.Y / height;

                var xmaxs = e.Location.X / width;
                var ymaxs = e.Location.Y / height;
                var classes_text = currentObjName;
                var classes = currentObjIndex + 1;


                listBoxLable.Items.Add(String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", width, height, filename, image_format, xmins, xmaxs, ymins, ymaxs, classes, classes_text));
                SaveLabelFile();
            }
            if (e.Button == MouseButtons.Right)
            {

                SaveLabelFile();
                if (listBoxFiles.Items.Count - 1 > listBoxFiles.SelectedIndex)
                {
                    var index = listBoxFiles.SelectedIndex;
                    listBoxFiles.ClearSelected();
                    listBoxFiles.SelectedIndex = index + 1;
                }
                listBoxLable.Items.Clear();
                ClearSelect();

            }
        }

        private void listBoxLable_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listBoxLable.SelectedItem != null)
                {
                    listBoxLable.Items.RemoveAt(listBoxLable.SelectedIndex);
                    if (listBoxLable.Items.Count > 0)
                    {
                        SaveLabelFile();
                    }
                    else
                    {
                        File.Delete(GetLableFilePath(listBoxFiles.SelectedItem.ToString()));
                    }
                }
            }
        }



        string GetLableFilePath(string jpgFilePath)
        {
            return String.Format("{0}\\{1}.txt", Path.GetDirectoryName(jpgFilePath), Path.GetFileNameWithoutExtension(jpgFilePath));
        }


        private void listBoxFiles_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listBoxFiles.SelectedItems != null)
                {
                    if (listBoxFiles.SelectedItems.Count == 1)
                    {
                        File.Delete(listBoxFiles.SelectedItem.ToString());
                        File.Delete(listBoxFiles.SelectedItem.ToString().Replace(".jpg", ".txt"));
                        listBoxLable.Items.Clear();
                        int i = listBoxFiles.SelectedIndex;
                        listBoxFiles.Items.RemoveAt(listBoxFiles.SelectedIndex);
                        if (i < listBoxFiles.Items.Count)
                        {
                            listBoxFiles.SelectedIndex = i;
                        }
                    }
                    else
                    {

                        foreach (var item in listBoxFiles.SelectedItems)
                        {
                            File.Delete(item.ToString());
                            File.Delete(item.ToString().Replace(".jpg", ".txt"));
                            listBoxLable.Items.Clear();
                        }
                        listBoxFiles.Items.Clear();
                        var dir = new DirectoryInfo(outputPath);
                        foreach (var file in dir.GetFiles())
                        {
                            if (file.Extension == ".jpg")
                            {
                                listBoxFiles.Items.Add(file.FullName);
                            }
                        }
                    }

                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            foreach (var item in listBoxFiles.Items)
            {
                var txtFile = item.ToString().Replace(".jpg", ".txt").Replace(".JPG", ".txt");
                if (item.ToString().Contains("6733"))
                {
                    int i = 111;
                    i++;
                }
                if (!File.Exists(txtFile))
                {
                    File.Delete(item.ToString());
                }
                else
                {
                    if (item.ToString().EndsWith(".JPG"))
                    {
                        File.Move(item.ToString(), item.ToString().Replace(".JPG", ".jpg"));
                    }

                }
            }
            LoadFiles();
        }

        private void buttonAddObj_Click(object sender, EventArgs e)
        {
            var obj = textBoxAddObj.Text.Trim();
            if (obj.Contains(' '))
            {
                MessageBox.Show("对象不允许带空格");
            }
            if (obj != "")
            {
                listBoxLableIndex.Items.Add(obj);
                listBoxLableIndex.SelectedIndex = listBoxLableIndex.Items.Count - 1;
                SaveObjectToConfig();
            }
            CreateLabelMap();
        }

        private void listBoxLableIndex_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (listBoxLableIndex.SelectedItem != null)
                {
                    int i = listBoxLableIndex.SelectedIndex;
                    listBoxLableIndex.Items.RemoveAt(listBoxLableIndex.SelectedIndex);
                    if (i < listBoxLableIndex.Items.Count)
                    {
                        listBoxLableIndex.SelectedIndex = i;
                    }
                    SaveObjectToConfig();
                    CreateLabelMap();
                }
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            ImportFiles(textBoxImport.Text);
            Properties.Settings.Default.imagePath = textBoxImport.Text;
            Properties.Settings.Default.Save();
        }


        void ImportFiles(string path)
        {
            if (Directory.Exists(path))
            {
                var importDir = new DirectoryInfo(path);
                foreach (var file in importDir.GetFiles())
                {
                    if (file.Extension == ".jpg")
                    {
                        string desFilePath = imagePath + file.Name;
                        if (!File.Exists(desFilePath))
                        {
                            File.Copy(file.FullName, imagePath + file.Name, true);
                            listBoxFiles.Items.Add(imagePath + file.Name);
                        }

                    }
                }
            }
         
        }

        private void listBoxLableIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentObjIndex = listBoxLableIndex.SelectedIndex;
            currentObjName = listBoxLableIndex.Text;
        }

        private void listBoxLable_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxLable.SelectedIndex != -1)
            {
                var line = listBoxLable.SelectedItem.ToString();
                if (line != "")
                {
                    var items = line.Split(' ');
                    MessageBox.Show(String.Format("width={0}\nheight={1}\nfilename={2}\nimage_format={3} \nxmins={4} \nxmaxs={5} \nymins={6} \nymaxs={7} \nclasses={8} \nclasses_text={9}",
                        items[0], items[1], items[2], items[3], items[4], items[5], items[6], items[7], items[8], items[9]), "样本标注信息");
                }
            }
        }

        private void buttonDownlaodImage_Click(object sender, EventArgs e)
        {
            if (textBoxKey.Text.Trim()=="")
            {
                MessageBox.Show("请填搜索关键字");
                return;
            }
             imageDownloadCount = (int)numericUpDownCount.Value;
             imageDownloadKey = textBoxKey.Text;
             imageDownloadPre = textBoxPreName.Text;
             zoomHeight = (int)numericUpDownZoomHeight.Value;
             zoomWidth = (int)numericUpDownZoomWidth.Value;
             if (buttonDownlaodImage.Text == "启动")
             {
                 if (downloadImageThread.IsBusy)
                 {
                     MessageBox.Show("线程还没停止，请稍候再试");
                 }
                 else
                 {
                     isDownloadImageThreadRun = true;
                     downloadImageThread.RunWorkerAsync();
                     buttonDownlaodImage.Text = "停止";
                     
                 }
             }
             else
             {
                 isDownloadImageThreadRun = false;
             }
         
        }

        private void buttonOpenDownloadPath_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", imageDownloadPath);
        }

        private void buttonClearDownloadFolder_Click(object sender, EventArgs e)
        {
            foreach (var item in new DirectoryInfo(imageDownloadPath).GetFiles())
            {
                File.Delete(item.FullName);
            }
        }

        private void buttonImportDownload_Click(object sender, EventArgs e)
        {
            ImportFiles(imageDownloadPath);
        }


        private Bitmap ZoomImage(Bitmap bitmap, int destHeight, int destWidth)
        {
            try
            {
                System.Drawing.Image sourImage = bitmap;
                int width = 0, height = 0;
                //按比例缩放             
                int sourWidth = sourImage.Width;
                int sourHeight = sourImage.Height;
                if (sourHeight > destHeight || sourWidth > destWidth)
                {
                    if ((sourWidth * destHeight) > (sourHeight * destWidth))
                    {
                        width = destWidth;
                        height = (destWidth * sourHeight) / sourWidth;
                    }
                    else
                    {
                        height = destHeight;
                        width = (sourWidth * destHeight) / sourHeight;
                    }
                }
                else
                {
                    width = sourWidth;
                    height = sourHeight;
                }
                Bitmap destBitmap = new Bitmap(destWidth, destHeight);
                Graphics g = Graphics.FromImage(destBitmap);
                g.Clear(Color.Transparent);
                //设置画布的描绘质量           
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                
                g.DrawImage(sourImage, new Rectangle((destWidth - width) / 2, (destHeight - height) / 2, width, height), 0, 0, sourImage.Width, sourImage.Height, GraphicsUnit.Pixel);
                g.Dispose();
                //设置压缩质量       
                System.Drawing.Imaging.EncoderParameters encoderParams = new System.Drawing.Imaging.EncoderParameters();
                long[] quality = new long[1];
                quality[0] = 100;
                System.Drawing.Imaging.EncoderParameter encoderParam = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                encoderParams.Param[0] = encoderParam;
                sourImage.Dispose();
                return destBitmap;
            }
            catch
            {
                return bitmap;
            }
        }

        private void buttonOpenImageFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", imagePath);
        }  
    }
}
