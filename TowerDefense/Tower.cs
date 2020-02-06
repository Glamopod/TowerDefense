
//Author:Tahsin Tiryaki
//Date:19.05.2016
//Dozent: Lukas Kumai
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace TowerDefense
{
    public class Tower
    {

        public Tower(string name, int damage,int cost)
        {
            this.name = name;
            this.damage = damage;
            this.cost = cost;
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int damage;

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        private int cost;

        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }

    }
}