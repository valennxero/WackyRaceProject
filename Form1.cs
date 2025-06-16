using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JevonTimeLibrary;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

namespace WackyRaceProject
{
    public partial class FormGame : Form
    {
        public FormGame()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.DoubleBuffered = true;
        }

        public List<Vehicle> listVehicle;
        List<Image> horseImages;
        List<Image> bikeImages;
        List<Image> carImages;
        
        void InitializeVehicle()
        {
            horseImages = new List<Image>();
            horseImages.Add(Properties.Resources.horse1);
            horseImages.Add(Properties.Resources.horse2);

            bikeImages = new List<Image>();
            bikeImages.Add(Properties.Resources.bike1);
            bikeImages.Add(Properties.Resources.bike2);
            bikeImages.Add(Properties.Resources.bike3);
            bikeImages.Add(Properties.Resources.bike4);

            carImages.Add(Properties.Resources.car1);
            carImages.Add(Properties.Resources.car1);

            Vehicle newVehicle;
            listVehicle = new List<Vehicle>();
            newVehicle = new Horse("Silence Suzuka", horseImages);
            listVehicle.Add(newVehicle);
            newVehicle = new Bike("Hakuchou Drag", bikeImages);
            listVehicle.Add(newVehicle);
            newVehicle = new Car("Pegassi Ignus", carImages);
            listVehicle.Add(newVehicle);  
        }
        public Player player;
        List<Point> playerPositions;
        int playerCurrentPosition;

        List<Point> spawnPositions;
        void InitializePositions()
        {
            playerPositions = new List<Point>();
            Point playerPos;
            playerPos = new Point(50, 225);
            playerPositions.Add(playerPos);
            playerPos = new Point(50, 350);
            playerPositions.Add(playerPos);
            playerPos = new Point(50, 475);
            playerPositions.Add(playerPos);

            spawnPositions = new List<Point>();
            Point spawnPos;
            spawnPos = new Point(700, 225);
            spawnPositions.Add(spawnPos);
            spawnPos = new Point(700, 350);
            spawnPositions.Add(spawnPos);
            spawnPos = new Point(700, 475);
            spawnPositions.Add(spawnPos);
        }

        List<Obstacle> listObstacle;
        List<Obstacle> listActiveObstacle = new List<Obstacle>();
        void InitializeObstacle()
        {
            listObstacle = new List<Obstacle>();
            Obstacle newObstacle;
            newObstacle = new Obstacle("Log", Properties.Resources.obstacle1);
            listObstacle.Add(newObstacle);
            newObstacle = new Obstacle("Boulder", Properties.Resources.obstacle2);
            listObstacle.Add(newObstacle);

            if (listActiveObstacle.Count > 0)
            {
                for (int index = 0; index < listActiveObstacle.Count; index++)
                {
                    listActiveObstacle[0].RemoveFrom(this);
                    listActiveObstacle.RemoveAt(0);
                }
            }
        }
        public string defaultFileName = "bestTime.dat";
        public void SaveProduct(string fileName)
        {
            FileStream myfile = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(myfile, player.BestTime);
            myfile.Close();
        }
        public void OpenProduct(string fileName)
        {
            if (File.Exists(fileName))
            {
                FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter formatter = new BinaryFormatter();
                player.BestTime = (JevonTime)formatter.Deserialize(file);
                file.Close();
            }
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void playGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSelectVehicle newForm = new FormSelectVehicle();
            newForm.Owner = this;
            newForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
