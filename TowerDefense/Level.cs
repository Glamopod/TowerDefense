//Author:Tahsin Tiryaki
//Date:19.05.2016
//Dozent: Lukas Kumai
using System;

namespace TowerDefense
{
    public class Level
    {
        public Level()
        {
            ActualLevel = GameConst.START_LEVEL;
            LevelDiffuculty = GameConst.DIFFUCULTY_LEVEL;
        }
        private int actualLevel;      
        public int ActualLevel
        {
            get { return actualLevel; }
            set { actualLevel = value; }
        }

        private bool gameOver;

        public bool GameOver
        {
            get { return gameOver; }
            set { gameOver = value; }
        }

        public void NextLevel()
        {
            ActualLevel+=1;
        }
        private int levelDiffuculty;

        public int LevelDiffuculty
        {
            get { return levelDiffuculty; }
            set { levelDiffuculty = value; }
        }


    }
}