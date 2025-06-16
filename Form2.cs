using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WackyRaceProject
{
    public partial class FormSelectVehicle : Form
    {
        public FormSelectVehicle()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        FormGame formGame;
        private void button1_Click(object sender, EventArgs e)
        {
            if (formGame.player is null)
            {
                foreach(Image img in formGame.player.PlayerVehicle.ListVehicleImg)
                {
                    img.Dispose();
                }
            }
            Vehicle SelectedVehicle;
            string inputName = textBoxName.Text;

            if (radioButtonHorse.Checked)
            {
                SelectedVehicle = formGame.listVehicle[0];
            }
            else if (radioButtonBike.Checked)
            {
                SelectedVehicle = formGame.listVehicle[1];
            }
            else
            {
                SelectedVehicle = formGame.listVehicle[2];
            }
            formGame.player = new Player(inputName, SelectedVehicle, 1);
            formGame.Load();
            formGame.startGame();
            this.Close();
        }
    }
}
