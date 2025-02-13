//https://gamedev.stackexchange.com/questions/57725/map-building-tower-defense
//http://cartoonsmix.com/cartoons/cartoon-mouse-bomb.html
// http://soundbible.com/2148-Chinese-Gong.html
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
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

#pragma warning disable SYSLIB0011 // Type or member is obsolete
namespace TowerDefense
{
    public class MainController
    {
        MainWindow mainWindow;
        public Level level = new Level();
        public Player player;
        public Virus virus=new Virus();   
        public Highscore highscore = new Highscore();        
                   
        private TowerController towerController;
        public WaveController waveController;
        private List<Highscore> highscoreList = new List<Highscore>();
    

        public MainController(MainWindow mainWindow)
        {           
            this.mainWindow = mainWindow;    
                  
            LoadScore();
        
            mainWindow.Button_Start.Click += Button_Start_Click;           

            SoundPlayer audio = new SoundPlayer(TowerDefense.Properties.Resources.countdown);
            audio.Play();
        }

        private void LoadScore()
        {
            try
            {
                FileStream fileStream = new FileStream(GameConst.SCORE_FILE, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                this.highscoreList = (List<Highscore>)formatter.Deserialize(fileStream);
                fileStream.Close();
                this.ShowBlinkMessage("Highscore_Loaded");
            }
            catch (FileNotFoundException)
            {
                ShowBlinkMessage("noch keine Datei!!");
            }
          
        }


        private void ShowHighscoreList()
        {
            mainWindow.listView.Visibility = Visibility.Visible;
            mainWindow.listView.ItemsSource = this.highscoreList;
        }


        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(mainWindow.textBoxPlayer.Text))
            {
                mainWindow.Title = "Tower Defense";
                this.player = new Player(mainWindow.textBoxPlayer.Text, GameConst.PLAYER_MONEY);
                this.towerController = new TowerController(mainWindow, this);
                this.waveController = new WaveController(mainWindow, this);

                mainWindow.labelGameInfo.Content = "Level"+ this.level.ActualLevel;
                mainWindow.labelMoney.Content = "StartMoney:"+this.player.Money + "€";
                mainWindow.labelHighscore.Content = "Highscore:"+this.highscore.Score;


                mainWindow.labelPlayer.Content += " " + mainWindow.textBoxPlayer.Text;

                mainWindow.labelStartInfo.Visibility = Visibility.Hidden;
                mainWindow.textBoxPlayer.Visibility = Visibility.Hidden;
                mainWindow.Button_Start.Visibility = Visibility.Hidden;

                SoundPlayer audio = new SoundPlayer(TowerDefense.Properties.Resources.horn);
                audio.Play();

            }
            else
            {
                ShowBlinkMessage("Please ENTER your NAME!!");

            }

        }

        public void ShowBlinkMessage(string s)
        {
            MyLabel label = new MyLabel(mainWindow);
            label.Height = 100;
            label.Width = 300;
            label.FontSize = 16;

            label.Content = s;
            Canvas.SetLeft(label, 172);
            Canvas.SetTop(label, 250);
            mainWindow.canvas.Children.Add(label);

            SoundPlayer audio = new SoundPlayer(TowerDefense.Properties.Resources.block);
            audio.Play();
        }

        //DIeser wird oft aufgerufen  (Level_Anzahl X Virus_Group Anzahl )
        public void GameStoryBoard(System.Windows.Controls.Image imageVirus, MainWindow mainWindow)
        {        
            //Wenn alle gegner aus der Bildfläche rausgehen   
            this.virus.Group--;
          
           
            //Wenn nicht eliminierte Gegner aus der Bildfläche rausgehen
            if (imageVirus.IsVisible)
            {

                //Malus auf gegner aus der Bildfläche rausgehen 
                this.highscore.Score -= GameConst.HIT_POINT;
                mainWindow.labelHighscore.Content = "Highscore:" + highscore.Score;
              
            }

            if (this.virus.Group == 0 && !level.GameOver)
            {
                this.virus.Group = GameConst.VIRUS_GROUP;

                this.level.NextLevel();
                this.level.LevelDiffuculty++;

                mainWindow.labelGameInfo.Content = "Level:" + level.ActualLevel;
                mainWindow.Title = this.level.LevelDiffuculty.ToString();


                if (level.ActualLevel > GameConst.FINISH_LEVEL)
                {
                    SaveHighscore();
                    ShowHighscoreList();
                    this.level.GameOver = true;
                    mainWindow.labelGameInfo.Content = "GameOver! ";
                }
                else
                {
                    this.waveController.CreateWave();
                }
            }
        }


        private void SaveHighscore()
        {
            try
            {
                highscore.Name = player.Name;
                highscoreList.Add(highscore);

                FileStream fileStream = new FileStream(GameConst.SCORE_FILE, FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, highscoreList);
                fileStream.Close();
                ShowBlinkMessage("Highscore_Saved");
            }
            catch (Exception e)
            {
                ShowBlinkMessage(e.ToString());
            }

        }
    }
}
#pragma warning restore SYSLIB0011
