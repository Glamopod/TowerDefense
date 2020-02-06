//Author:Tahsin Tiryaki
//Date:19.05.2016
//Dozent: Lukas Kumai
using System;
using System.Timers;
using System.Windows.Controls;

namespace TowerDefense
{
    public class MyLabel : Label
    {
        MainWindow mainWindow;

        public MyLabel(MainWindow mainWindow) : base()
        {
            this.mainWindow = mainWindow;
        }

        public void LabelTimer(object sender, ElapsedEventArgs e)
        {


            mainWindow.Dispatcher.Invoke(
                () => { mainWindow.canvas.Children.Remove(this); }
            );

            Timer t = (Timer)sender;
            t.Stop();
            t.Close();
            t.Dispose();

        }


        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            Timer t = new Timer(2000);
            t.AutoReset = false;
            t.Elapsed += LabelTimer;
            t.Start();
        }

    }
}