//Author:Tahsin Tiryaki
//Date:19.05.2016
//Dozent: Lukas Kumai
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    [Serializable]
    public class Highscore
    {
        private int score;

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}