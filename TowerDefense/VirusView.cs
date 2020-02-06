//Author:Tahsin Tiryaki
//Date:19.05.2016
//Dozent: Lukas Kumai
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace TowerDefense
{

    public class VirusView
    {
        private int step;
        private MainController mainController;
        private VirusPathList virusPathList;
        private Image imageVirus;



        private DoubleAnimation da = new DoubleAnimation();
        private Random random = new Random(Guid.NewGuid().GetHashCode());

        private MainWindow mainWindow;

        //von VirusPathController ausgeführt. Die Gegenerishe einheiten werden auf der VirusPathList animiert
        public VirusView(VirusPathList virusPathList, MainWindow mainWindow, MainController mainController)
        {

            this.mainWindow = mainWindow;
            this.virusPathList = virusPathList;

            //this.mainController = MainWindow.maincontroller;
            this.mainController = mainController;

            imageVirus = new Image();
            imageVirus.Height = 23 * mainController.level.LevelDiffuculty/2;
            imageVirus.Width = 39 * mainController.level.LevelDiffuculty/2;
            //imageVirus.Source = mainWindow.virus.Source;
            imageVirus.SetValue(Image.SourceProperty, mainWindow.virus.Source);
            imageVirus.SetValue(Canvas.TopProperty, mainWindow.virus.GetValue(Canvas.TopProperty));
            imageVirus.SetValue(Canvas.LeftProperty, mainWindow.virus.GetValue(Canvas.LeftProperty));
            // Canvas.SetLeft(imageVirus,Canvas.GetLeft(mainWindow.virus));            
            //(Double)imageVirus.GetValue(Canvas.TopProperty);
            mainWindow.canvas.Children.Add(imageVirus);

            da.Completed += AnimateOnPath;
            imageVirus.BeginAnimation(Canvas.LeftProperty, da);
        }

        private void AnimateOnPath(object sender, EventArgs e)
        {
            try
            {

                da = new DoubleAnimation();
                if (virusPathList.virusPathData[step].Top)
                {
                    da.From = Canvas.GetTop(imageVirus);
                }
                else
                {
                    da.From = Canvas.GetLeft(imageVirus); ;
                }
                da.To = da.From + virusPathList.virusPathData[step].Distance;
                double seconds = random.Next(2, 7);
                da.Duration = new Duration(TimeSpan.FromSeconds((double)seconds / GameConst.VIRUS_SPEED));
                da.Completed += AnimateOnPath;
                if (virusPathList.virusPathData[step].Top)
                {
                    imageVirus.BeginAnimation(Canvas.TopProperty, da);
                }
                else
                {
                    imageVirus.BeginAnimation(Canvas.LeftProperty, da);
                }
                step++;


            }
            catch (Exception)
            { //Dieser Exception wird für die Level Steuerung Benutzt

                this.mainController.GameStoryBoard(imageVirus, mainWindow);
            }
        }

        public bool CheckCol(Image image)
        {
            double x = Canvas.GetLeft(image);
            double y = Canvas.GetTop(image);
            double w = image.Width;
            double h = image.Height;

            Rect rect = new Rect(x, y, w, h);


            // foreach (Image bullet in mainWindow.canvas.Children)
            for (int i = 0; i < mainWindow.canvas.Children.Count; i++)
            {
                if (!(mainWindow.canvas.Children[i] is BulletImage))
                {
                    continue;
                }
                if (image == mainWindow.canvas.Children[i])
                {
                    continue;
                }
                BulletImage bullet = (BulletImage)mainWindow.canvas.Children[i];

                double x2 = Canvas.GetLeft(bullet);
                double y2 = Canvas.GetTop(bullet);
                double w2 = bullet.Width;
                double h2 = bullet.Height;

                Rect rc = new Rect(x2, y2, w2, h2);

                if (rc.IntersectsWith(rect) && imageVirus.IsVisible)
                {

                    this.mainController.player.Money += GameConst.HIT_MONEY;
                    this.mainController.highscore.Score += GameConst.HIT_POINT;


                    mainWindow.labelMoney.Content = "Money:" + this.mainController.player.Money;
                    mainWindow.labelHighscore.Content = "Highscore:" + mainController.highscore.Score; ;

                    double check = random.Next(1, (5 * mainController.level.LevelDiffuculty));
                    if (check == 3)
                    {
                        imageVirus.Visibility = Visibility.Hidden;
 
                            SoundPlayer audio = new SoundPlayer(TowerDefense.Properties.Resources.explosion);
                            audio.Play();
                 

                    }
                   


                    ////Eliminierte Gegner abschliesen um schneller zum Nächsten Level zu gelangen
                    //mainController.virus.Hits++;
                    //if (mainController.virus.Hits == GameConst.VIRUS_GROUP)
                    //{

                    //    mainController.virus.Group = GameConst.VIRUS_GROUP;
                    //    mainController.level.NextLevel();
                    //    mainController.waveController.CreateWave();
                    //    //mainController.virus.Hits = 0;
                    //}
                    //mainWindow.Title = "!" + mainController.virus.Hits.ToString();


                    return true;
                }
            }

            return false;

        }

        public void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                mainWindow.Dispatcher.Invoke(() =>
                {
                    CheckCol(imageVirus);

                });
            }
            catch (Exception)
            {
            }

        }
    }
}