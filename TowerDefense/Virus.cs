//Author:Tahsin Tiryaki
//Date:19.05.2016
//Dozent: Lukas Kumai
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace TowerDefense
{
    public class Virus
    {
        public Virus()
        {
            this.Group = GameConst.VIRUS_GROUP;
            this.Hits = 0;
        }

        private int team;

        public int Group
        {
            get { return team; }
            set { team = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int health;

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        private int hits;

        public int Hits
        {
            get { return hits; }
            set { hits = value; }
        }


    }
}