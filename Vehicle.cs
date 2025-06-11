using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WackyRaceProject
{
    public class Vehicle
    {
        private string name;
        private PictureBox picture;
        private List<Image> listVehicleImg;
        private int currentSpriteIndex;

        public string Name { get => name; set => name = value; }
        public PictureBox Picture { get => picture; set => picture = value; }
        public List<Image> ListVehicleImg { get => listVehicleImg; set => listVehicleImg = value; }
        public int CurrentSpriteIndex { get => currentSpriteIndex; set => currentSpriteIndex = value; }

        public Vehicle(string pName, List<Image> pListImage)
        {
            Name = pName;
            ListVehicleImg = pListImage;

            this.Picture = new PictureBox();
            this.Picture.Image = pListImage[0];
            this.Picture.Size = new Size(100, 100);
            this.Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Picture.BackColor = Color.Transparent;

            CurrentSpriteIndex = 0;
        }

        public void SetLocation(Point newLoc)
        {
            this.Picture.Location = newLoc;
        }
        public void DisplayPicture(Control container)
        {
            this.Picture.Parent = container;
            this.Picture.BringToFront();
        }
    }
}