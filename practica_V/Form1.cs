using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica_V
{
    public partial class Form1 : Form
    {

        ApplicationContext db;
        string imageFolder = @".\Images\";        
        
        
        public Form1()
        {
            InitializeComponent();

            db = new ApplicationContext();

            // заполнить бд 
             db.Load();


            domainUpDown1.Items.Add("Все");
            domainUpDown1.SelectedIndex = 0;

            foreach (AnimalClass a in db.AnimalClasses)
            {
                domainUpDown1.Items.Add(a.name);
            }


            listView1.LargeImageList = imageList1;
            
        }


        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item.Selected)
            {
                this.Hide();
                Page page = new Page(this, e.Item.Text, db);
                page.Show();
            }
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            listView1.Clear();
            if (domainUpDown1.SelectedIndex == 0)
            {
                foreach (Animal animal in db.Animals)
                {
                    addAnimalToList(animal);
                }
            } else
            {
                var curAnimalClass = db.AnimalClasses.Where(
                    p => p.name == domainUpDown1.SelectedItem.ToString()
                    ).Single();
                foreach(Animal animal in curAnimalClass.animals)
                {
                    addAnimalToList(animal);
                }
            }

        }


        private void addAnimalToList(Animal animal)
        {
            ListViewItem row = new ListViewItem();
            row.Text = animal.name;
            row.ImageKey = animal.imgPath;
            

            string imgPath = $"{imageFolder}{animal.imgPath}";
            imageList1.Images.Add(animal.imgPath, Image.FromFile(imgPath));
            
            listView1.Items.Add(row);
        }

    }
}
