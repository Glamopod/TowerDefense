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
    public class TowerListe
    {


        private List<Tower> towerList;

        public TowerListe( List<Tower> towerList)
        {
            this.towerList = towerList;
      
        }
    }
}