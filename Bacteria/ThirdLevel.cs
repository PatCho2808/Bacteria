using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;


namespace Bacteria
{
    class ThirdLevel : LevelBase
    {
        SecondLevel secondLevel; 
        string pathToWaterSprite = "G:\\Documents\\VisualStudioProjects\\Bacteria\\Content\\Water.png";
        Water water;
        float timeToNextSpawnWater;
        int minTimeToNextSpawnWater = 1;
        int maxTimeToNextSpawnWater = 5;
        static Random Rand = new Random();
        Clock newWaterClock = new Clock();
        Clock speedClock = new Clock();
        SFML.System.Vector2f WindowSize;
        bool canSpawnNewWater = true;
        float addSpeed = .05f;
        float speedEffectDuration = 3;
        bool speedEffectInProcess = false; 

        public ThirdLevel(Font newFont, SFML.System.Vector2f WindowSize)
        {
            LevelData.initialNumberOfBacteria = 15;
            LevelData.initialTime = 9;
            secondLevel = new SecondLevel(newFont, WindowSize);
            this.WindowSize = WindowSize;
           
        }

        public override void Update()
        {
            secondLevel.Update();
            if(water!=null && CheckIfPillCollectedWater())
            {
                speedClock.Restart();
                Game.SpeedUpPill(addSpeed);
                speedEffectInProcess = true; 
                water.collected = true;
                canSpawnNewWater = true;
                timeToNextSpawnWater = Rand.Next(minTimeToNextSpawnWater, maxTimeToNextSpawnWater);
                newWaterClock.Restart();
                Console.WriteLine("time to spawn water: " + timeToNextSpawnWater);
            }
            if (canSpawnNewWater && newWaterClock.ElapsedTime.AsSeconds() > timeToNextSpawnWater)
            {
                water = new Water(pathToWaterSprite, (int)WindowSize.X, (int)WindowSize.Y);
                canSpawnNewWater = false;
            }
            if(speedEffectInProcess && speedClock.ElapsedTime.AsSeconds() >= speedEffectDuration)
            {
                Game.ResetPillSpeed();
                speedEffectInProcess = false; 
            }

        }

        public override void SetLevel()
        {
            secondLevel.SetLevel();
            newWaterClock.Restart();
            timeToNextSpawnWater = 0.5f;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(secondLevel, states);
            if(water != null && water.collected == false)
            {
                target.Draw(water, states);
            }
        }

        public bool CheckIfPillCollectedWater()
        {
            if(water.collected == false && Game.GetPillBoundingBox().Intersects(water.GetBoundingBox()))
            {
                return true; 
            }
            return false; 
        }
    }
}