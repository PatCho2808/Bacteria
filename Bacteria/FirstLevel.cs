﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacteria
{
    class FirstLevel : LevelBase
    {
        public FirstLevel()
        {
            LevelData.initialNumberOfBacteria = 20;
            LevelData.initialTime = 10; 
        }

        override public void Update()
        {

        }
    }
}