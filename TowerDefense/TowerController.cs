//Author:Tahsin Tiryaki
//Date:19.05.2016
//Dozent: Lukas Kumai
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TowerDefense
{
    public class TowerController
    {
        private MainController mainController;
        private MainWindow mainWindow;
        private TowerView towerView;

        public TowerController(MainWindow mainWindow,MainController mainController)
        {
            this.mainWindow = mainWindow;            
            this.mainController =mainController;

            mainWindow.Circle1.MouseUp += Circle_MouseUp;
            mainWindow.Circle2.MouseUp += Circle_MouseUp;
            mainWindow.Circle3.MouseUp += Circle_MouseUp;
            mainWindow.Circle4.MouseUp += Circle_MouseUp;
            mainWindow.Circle5.MouseUp += Circle_MouseUp;
            mainWindow.Circle6.MouseUp += Circle_MouseUp;
            mainWindow.Circle7.MouseUp += Circle_MouseUp;
            mainWindow.Circle8.MouseUp += Circle_MouseUp;

        }

        private void Circle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
            if (mainController.player.Money > GameConst.TOWER_COST)
            {
                mainController.player.Money -= GameConst.TOWER_COST;
                mainWindow.labelMoney.Content = "Money:" + mainController.player.Money;


                towerView = new TowerView(mainWindow, sender, mainController);
            }
            else
            {
                mainController.ShowBlinkMessage("not enaugh Money for Tower\n to set new Towers");            

            }
        }
    }
}