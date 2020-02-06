//Author:Tahsin Tiryaki
//Date:19.05.2016
//Dozent: Lukas Kumai
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;


namespace TowerDefense
{
    
    public class WaveController
    {      
        private MainWindow mainWindow;
        private MainController mainController;
        private VirusPathController virusPathController;

        public WaveController(MainWindow mainWindow,MainController mainController)
        {
            this.mainController = mainController;
            this.mainWindow = mainWindow;
            CreateWave();
        }
        public void CreateWave()
        {         
            for (int i = 0; i < mainController.virus.Group; i++)
            {
                virusPathController = new VirusPathController(mainWindow,mainController);               
            }
        } 
    }
}