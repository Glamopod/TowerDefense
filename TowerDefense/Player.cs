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
    public class Player
    {

        public Player(string name, int money)
        {
            this.name = name;
            this.money = money;

        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int money;
        public int Money
        {
            get { return money; }
            set { money = value; }
        }

    }


}