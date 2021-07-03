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

namespace GalleryForm
{
    public partial class GalleryForm : Form
    {
        public GalleryForm()
        {
            InitializeComponent();
            if (Directory.Exists("Images/")) {
                Directory.GetFiles("Images/").ToList().ForEach((image)=> {
                    Button imageLabel = new Button();
                    imageLabel.BackgroundImage = (Image)Image.FromFile(image).Clone();
                    imageLabel.BackgroundImageLayout = ImageLayout.Stretch;
                    imageLabel.Size = new Size(90,90);
                    imageLabel.Name = image;
                    imageLabel.Click += (s, e) => {
                        var img = s as Button;
                        this.pictureBox.Image = img.BackgroundImage;
                    };
                    if (this.imagePanel.Controls.Count == 0)
                    {
                        imageLabel.Location = new Point(10, 10);
                    }
                    else {
                        imageLabel.Location = new Point(this.imagePanel.Controls.OfType<Button>().Last().Location.X+101, 10);
                    }


                    this.imagePanel.Controls.Add(imageLabel);
                    
                });
            }


        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            var arr = this.imagePanel.Controls.OfType<Button>().ToArray();
            if (arr.Last().Location.X >= this.imagePanel.Width-50)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i].Location = new Point(arr[i].Location.X - 101, 10);
                }
            }

        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            var arr = this.imagePanel.Controls.OfType<Button>().ToArray();
            if (arr.First().Location.X < 0) 
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i].Location = new Point(arr[i].Location.X + 101, 10);
                }
            }
        }
    }
}
