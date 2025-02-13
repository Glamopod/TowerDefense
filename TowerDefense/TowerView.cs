//Author:Tahsin Tiryaki
//Date:19.05.2016
//Dozent: Lukas Kumai
using System;
using System.Collections.Generic;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace TowerDefense
{
    public class BulletImage : System.Windows.Controls.Image
    {

    }
    public class imageTower : System.Windows.Controls.Image
    {

    }

    public class TowerView
    {
        private MainController mainController;
        private MainWindow mainWindow;
        private System.Windows.Point mousePoint;
        public List<Tower> towerListe;

        private BulletImage imageBullet = new BulletImage();
        private System.Windows.Controls.Image towerImage;
        private DoubleAnimation da;
        private Random random = new Random(Guid.NewGuid().GetHashCode());
        private int bulletRotation;


        public TowerView(MainWindow mainWindow, Object sender, MainController mainController)
        {
            this.mainWindow = mainWindow;
            this.mainController = mainController;
            mainWindow.PreviewMouseDown += MainWindow_PreviewMouseDown;

            this.towerImage = new System.Windows.Controls.Image();

            Ellipse circle = sender as Ellipse;
            System.Windows.Point circlePos = new System.Windows.Point(Canvas.GetLeft(circle) + 12, Canvas.GetTop(circle) + 12);

            towerImage.Source = mainWindow.tower.Source;
            towerImage.Width = mainWindow.tower.Width;
            towerImage.Height = mainWindow.tower.Height;

            Canvas.SetLeft(towerImage, -48 + circlePos.X);
            Canvas.SetTop(towerImage, -48 + circlePos.Y);
            mainWindow.canvas.Children.Add(towerImage);


            SoundPlayer audio = new SoundPlayer(TowerDefense.Properties.Resources.bell);
            audio.Play();


            //     this.imageTower = image;
            imageBullet.Source = mainWindow.rocket.Source;
            imageBullet.Width = mainWindow.rocket.Width;
            imageBullet.Height = mainWindow.rocket.Height;
            imageBullet.SetValue(Canvas.TopProperty, mainWindow.rocket.GetValue(Canvas.TopProperty));
            imageBullet.SetValue(Canvas.LeftProperty, mainWindow.rocket.GetValue(Canvas.LeftProperty));
            mainWindow.canvas.Children.Add(imageBullet);

            da = new DoubleAnimation();
            da.Completed += AnimateBullet;
            imageBullet.BeginAnimation(Canvas.LeftProperty, da);
        }

        private void MainWindow_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            mousePoint = e.GetPosition(mainWindow);
            //mainWindow.Title = "x:" + Convert.ToString(mousePoint.X) + " y:" + Convert.ToString(mousePoint.Y);
        }

        private void AnimateBullet(object sender, EventArgs e)
        {
            if (!mainController.level.GameOver)
            {
                da = new DoubleAnimation();
                imageBullet.BeginAnimation(Canvas.LeftProperty, da);
                imageBullet.BeginAnimation(Canvas.TopProperty, da);


                da.From = Canvas.GetLeft(this.towerImage) + 45;
                da.To = mousePoint.X;

                double seconds = random.Next(2, 7);
                da.Duration = new Duration(TimeSpan.FromSeconds(seconds / GameConst.BULLET_SPEED));
                imageBullet.BeginAnimation(Canvas.LeftProperty, da);

                da.From = Canvas.GetTop(this.towerImage) + 20;
                da.To = mousePoint.Y;

                da.Completed += AnimateBullet;



                SoundPlayer audio = new SoundPlayer(TowerDefense.Properties.Resources._throw);
                audio.Play();



                this.imageBullet.RenderTransform = new RotateTransform(bulletRotation += 45, 0, 0);
                imageBullet.BeginAnimation(Canvas.TopProperty, da);
            }
        }
    }
}