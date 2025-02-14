using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Dinamica
{
    public partial class Form1 : Form
    {
        private Button btnAddControls;
        private List<Button> dynamicButtons = new List<Button>();
        private List<TextBox> dynamicTextBoxes = new List<TextBox>();
        private int controlCounter = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Configuración de la ventana
            this.Text = "Creación Dinámica de Controles";
            this.Size = new Size(400, 400);

            // Botón para agregar controles dinámicamente
            btnAddControls = new Button();
            btnAddControls.Text = "Agregar Controles";
            btnAddControls.Location = new Point(20, 20);
            btnAddControls.Click += new EventHandler(AddControls);
            this.Controls.Add(btnAddControls);
        }

        private void AddControls(object sender, EventArgs e)
        {
            // Crear un nuevo botón
            Button newButton = new Button();
            newButton.Text = "Botón " + controlCounter;
            newButton.Size = new Size(100, 30);
            newButton.Location = new Point(20, 60 + dynamicButtons.Count * 40);
            newButton.Click += DynamicButtonClick;

            // Crear una nueva caja de texto
            TextBox newTextBox = new TextBox();
            newTextBox.Size = new Size(150, 30);
            newTextBox.Location = new Point(140, 60 + dynamicTextBoxes.Count * 40);

            dynamicTextBoxes.Add(newTextBox);
            dynamicButtons.Add(newButton);

            this.Controls.Add(newTextBox);
            this.Controls.Add(newButton);

            controlCounter++;
        }
        private void DynamicButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            MessageBox.Show("Has presionado: " + clickedButton.Text);
        }

    }
}
