//Author:Tahsin Tiryaki
//Date:19.05.2016
//Dozent: Lukas Kumai
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense
{
    public class Wave
    {

        private String name;
        public List<Virus> virusList;
        
        public Wave(string name,List<Virus> virusList)
        {
            this.name = name;
            this.virusList = virusList;
        }

       
        public string Name { get; set; }
    }
}