//Author:Tahsin Tiryaki
//Date:19.05.2016
//Dozent: Lukas Kumai
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace TowerDefense
{
    public class VirusPathController 
    {
        private MainWindow mainWindow;
        private VirusPathList virusPathList = new VirusPathList();
        private VirusView virusPathView;
        private MainController mainController;
        
        Virus virus;

        //Dieser wird von Wave Controller audgeführt.Hier wird der Weg von Gegnerishen einheiten vor definiert.
        public VirusPathController(MainWindow mainWindow,MainController mainController)
        {
            this.mainWindow = mainWindow;
            this.mainController = mainController;
           
       
          // this.virus("Ebola", 1, 50, new Point(0, 0), true);
            this.virusPathList.virusPathData.Add(new VirusPathElement(110, false));
            this.virusPathList.virusPathData.Add(new VirusPathElement(-100, true));
            this.virusPathList.virusPathData.Add(new VirusPathElement(100, false));
            this.virusPathList.virusPathData.Add(new VirusPathElement(145, true));
            this.virusPathList.virusPathData.Add(new VirusPathElement(135, false));
            this.virusPathList.virusPathData.Add(new VirusPathElement(-81, true));
            this.virusPathList.virusPathData.Add(new VirusPathElement(220, false));



            this.virusPathView = new VirusView(virusPathList, mainWindow,mainController);

            Timer t = new Timer();
            t.Interval = GameConst.VIRUS_SHIELD;
            t.AutoReset = true;
            t.Elapsed += this.virusPathView.T_Elapsed;
            t.Start();            

        }


    }
}
