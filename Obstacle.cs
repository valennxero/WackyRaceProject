using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WackyRaceProject
{
    public class Obstacle
    {
        private bool isDestroyed;
        private string name;
        private PictureBox picture;

        public bool IsDestroyed { get => isDestroyed; set => isDestroyed = value; }
        public string Name { get => name; set => name = value; }
        public PictureBox Picture { get => picture; set => picture = value; }

        public Obstacle(string name, Image pImage)
        {
            this.Name = name;
            this.IsDestroyed = false;
            this.Picture = new PictureBox();
            this.Picture.Image = pImage;
            this.Picture.Size = new Size(100,100);
            this.Picture.BackColor = Color.Transparent;
        }

        public Obstacle (Obstacle newObs)
        {
            this.Name = newObs.Name;
            this.IsDestroyed = newObs.IsDestroyed;

            this.Picture = new PictureBox();
            this.Picture.Image = newObs.Picture.Image;
            this.Picture.Size = new Size(100, 100);
            this.Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Picture.BackColor = Color.Transparent;
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
        public void RemoveFrom(Control container)
        {
            container.Controls.Remove(this.Picture);
            Picture.Dispose();
        }
        public bool CheckCollision(PictureBox otherPic)
        {
            return Picture.Bounds.IntersectsWith(otherPic.Bounds);
        }
    }

}