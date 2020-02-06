//Author:Tahsin Tiryaki
//Date:19.05.2016
//Dozent: Lukas Kumai
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    public class VirusPathElement
    {
        public VirusPathElement(double distance, bool top)
        {
            this.top = top;
            this.distance = distance;
        }

        private double distance;
        public double Distance
        {
            get { return distance; }
            set { distance = value; }
        }


        private bool top;
        public bool Top
        {
            get { return top; }
            set { top = value; }
        }


    }
}