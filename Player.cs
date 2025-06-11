using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JevonTimeLibrary;

namespace WackyRaceProject
{
    public class Player
    {
        private JevonTime bestTime;
        private int life;
        private string name;
        private Vehicle playerVehicle;

        public JevonTime BestTime { get => bestTime; set => bestTime = value; }
        public int Life { get => life; set => life = value; }
        public string Name { get => name; set => name = value; }
        public Vehicle PlayerVehicle { get => playerVehicle; set => playerVehicle = value; }

        public Player(string pName, Vehicle pVehicle, int pLife)
        {
            this.Name = pName;
            this.PlayerVehicle = pVehicle;
            this.Life = pLife;
            this.BestTime = new JevonTime();
        }
    }
}