using System;
using System.Collections.Generic;

using System.Linq;
using System.Media;
using System.Text;

using System.Threading.Tasks;
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
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            MainController maincontroller = new MainController(this);


        }

        private void textBoxPlayer_TextChanged(object sender, TextChangedEventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(TowerDefense.Properties.Resources.typeWriter);
            audio.Play();
        }
    }
}
