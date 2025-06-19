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
using System.Runtime.Serialization.Formatters.Binary;
using System.Media;

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
            carImages = new List<Image>();
            carImages.Add(Properties.Resources.car1);
            carImages.Add(Properties.Resources.car2);

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
        bool canMove = true;

        Image backgroundImage;
        int bgOffset = 0;
        int scrollSpeed = 15;
        SoundPlayer soundPlayer;
        JevonTime currentTime;

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
        public void SaveFile(string fileName)
        {
            FileStream myfile = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(myfile, player.BestTime);
            myfile.Close();
        }
        public void OpenFile(string fileName)
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
            InitializeVehicle();
            InitializeObstacle();
            InitializePositions();
            backgroundImage = Properties.Resources.bg1small;
            pictureBoxLogo.Visible = true;
            labelPlayerInfo.Text = "Player Info";
            labelPlayerInfo.Visible = false;
            labelTimeInfo.Text = "Time Info";
            labelTimeInfo.Visible = false;
            labelBestTime.Visible = false;
            buttonRestart.Visible = false;
            labelGameOver.Visible = false;
        }

        private void playGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSelectVehicle newForm = new FormSelectVehicle();
            newForm.Owner = this;
            newForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        public void StartGame()
        {
            menuStripGame.Visible = false;
            pictureBoxLogo.Visible = false;
            labelGameOver.Visible = false;
            buttonRestart.Visible = false;
            labelTimeInfo.Text = "00:00:00";
            labelTimeInfo.Visible = true;
            labelPlayerInfo.Text = "Player " + player.Name;
            labelPlayerInfo.Visible = true;

            timerBackground.Start();
            timerSurviveTime.Start();
            timerPlayerAnimation.Start();
            timerObstacleSpawner.Start();

            currentTime = new JevonTime();
            player.PlayerVehicle.SetLocation(playerPositions[1]);
            playerCurrentPosition = 1;
            player.PlayerVehicle.DisplayPicture(this);

            InitializeObstacle();
            
        }

        private void timerSurviveTime_Tick(object sender, EventArgs e)
        {
            labelTimeInfo.Text = currentTime.Hour.ToString("D2") + ":" +
                currentTime.Minute.ToString("D2") +
                currentTime.Second.ToString("D2");
            currentTime.AddSec(1);
        }

        private void FormGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && canMove)
            {
                canMove = false;
                if (playerCurrentPosition != 0)
                {
                    playerCurrentPosition--;
                    player.PlayerVehicle.SetLocation(playerPositions[playerCurrentPosition]);
                }
                timerMoveCooldown.Start();                
            }
            else if (e.KeyCode == Keys.Down && canMove)
            {
                canMove = false;
                if (playerCurrentPosition != 2)
                {
                    playerCurrentPosition++;
                    player.PlayerVehicle.SetLocation(playerPositions[playerCurrentPosition]);
                }
                timerMoveCooldown.Start();
             }
            player.PlayerVehicle.DisplayPicture(this);
        }
        private void timerMoveCooldown_Tick(object sender, EventArgs e)
        {
            canMove = true;
            timerMoveCooldown.Stop();
        }
        
        private void timerBackground_Tick(object sender, EventArgs e)
        {
            bgOffset -= scrollSpeed;
            if(Math.Abs(bgOffset)>= backgroundImage.Width)
            {
                bgOffset = 0;
            }
            foreach(Obstacle obs in listActiveObstacle)
            {
                obs.Picture.Location = new Point(obs.Picture.Location.X - scrollSpeed, obs.Picture.Location.Y);
                //obs.DisplayPicture(this);
                if (obs.CheckCollision(player.PlayerVehicle.Picture))
                {
                    player.Life -= 1;
                    if (player.Life <= 0)
                    {
                        GameOver();
                        
                    }
                }
                if (obs.Picture.Location.X <-(obs.Picture.Width))
                {
                    obs.RemoveFrom(this);
                    obs.IsDestroyed = true;
                }
            }
            for (int i = 0; i < listActiveObstacle.Count;)
            {
                if (listActiveObstacle[i].IsDestroyed)
                {
                    listActiveObstacle.RemoveAt(i);
                }
                else
                    i++;
            }
            Invalidate();
        }
        private void DrawScrollingBackground(Graphics g)
        {
            int imgWidth = backgroundImage.Width;
            int imgHeight = backgroundImage.Height;
            g.DrawImage(backgroundImage, bgOffset, 0, imgWidth, imgHeight);
            g.DrawImage(backgroundImage, bgOffset + imgWidth, 0, imgWidth, imgHeight);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawScrollingBackground(e.Graphics);
        }
        private Random rand = new Random();

        private void GameOver()
        {
            foreach(IComponent comp in this.components.Components)
            {
                if (comp is Timer timer)
                {
                    timer.Stop();
                }
            }
            labelGameOver.Visible = true;

            labelTimeInfo.Text = "You survived\nfor : " + currentTime.Hour.ToString("D2") + ":" +
                currentTime.Minute.ToString("D2") + ":" + currentTime.Second.ToString("D2");
            if(player.BestTime == null)
            {
                player.BestTime = currentTime;
                SaveFile(defaultFileName);
            }
            /*else if (player.BestTime.KonversiJamKeDetik() < currentTime.KonversiJamKeDetik())
            {

            }
            */
            labelBestTime.Text = "Best Time :\n" + player.BestTime.Hour.ToString("D2") + ":" +
                player.BestTime.Minute.ToString("D2") + ":" + player.BestTime.Second.ToString("D2");
            buttonRestart.Visible = true;
        }

        private void timerPlayerAnimation_Tick(object sender, EventArgs e)
        {
            player.PlayerVehicle.ToggleAnimation();
        }

        private void timerObstacleSpawner_Tick(object sender, EventArgs e)
        {
            int randomPos = rand.Next(0, 3);
            int randomType = rand.Next(0, listObstacle.Count);

            Obstacle spawnedObstacle = new Obstacle(
                listObstacle[randomType].Name,
                listObstacle[randomType].Picture.Image
            );

            spawnedObstacle.SetLocation(spawnPositions[randomPos]);
            spawnedObstacle.DisplayPicture(this);
            listActiveObstacle.Add(spawnedObstacle);
        }


    }
}
