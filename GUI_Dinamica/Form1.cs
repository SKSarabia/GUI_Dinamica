using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GUI_Dinamica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeFlowLayoutPanel();
            LoadImages();
        }

        private void InitializeFlowLayoutPanel()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel1.Dock = DockStyle.Fill;
            this.Controls.Add(flowLayoutPanel1);
        }

        private void LoadImages()
        {
            string directoryPath = "D:\\luist\\Documents\\ImagenesDinamicas"; //CAMBIAR EL DIRECTORIO AQUI
            if (Directory.Exists(directoryPath))
            {
                string[] files = Directory.GetFiles(directoryPath, "*.jpg"); //CAMBIAR EL TIPO DE ARCHIVO AQUI
                foreach (string file in files)
                {
                    PictureBox picBox = new PictureBox();
                    picBox.Image = Image.FromFile(file);
                    picBox.SizeMode = PictureBoxSizeMode.Zoom;
                    picBox.Width = 100;
                    picBox.Height = 100;
                    picBox.Click += (sender, e) => ShowImageInNewWindow(file);
                    flowLayoutPanel1.Controls.Add(picBox);
                }
            }
            else
            {
                MessageBox.Show("El directorio no existe");
            }
        }

        private void ShowImageInNewWindow(string filePath)
        {
            Form imageForm = new Form();
            imageForm.Text = Path.GetFileName(filePath);
            PictureBox picBox = new PictureBox();
            picBox.Image = Image.FromFile(filePath);
            picBox.Dock = DockStyle.Fill;
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
            imageForm.Controls.Add(picBox);
            imageForm.ShowDialog();
        }
    }

}
