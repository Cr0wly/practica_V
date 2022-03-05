using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica_V
{
    public partial class Page : Form
    {
        private Form _main;
        private Animal _animal;
        private SoundPlayer _SoundPlayer;
        ApplicationContext _db;
        string imageFolder = @".\Images\";
        string soundFolder = @".\Sounds\";

        public Page(Form1 main, string name, ApplicationContext db)
        {
            InitializeComponent();

            _db = db;
            var animals = _db.Animals;

            _main = main;
            _animal = _db.Animals.Where(p => p.name == name).Single();
            label1.Text = _animal.name;
            label2.Text = _animal.description;

            string imgPath = $"{imageFolder}{_animal.imgPath}";
            pictureBox1.Image = Image.FromFile(imgPath);
            string soundPath = $"{soundFolder}{_animal.soundPath}";
            _SoundPlayer = new SoundPlayer(soundPath);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _main.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _SoundPlayer.Play();
        }

        private void Page_FormClosed(object sender, FormClosedEventArgs e)
        {
            _SoundPlayer.Stop();
        }
    }
}
