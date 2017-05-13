using System;
using System.Diagnostics;

namespace SpaceInvaders
{
 abstract class Level
    {
        public LevelType type;
        public enum LevelType
        {
           Level1,
           Level2
        }

        public abstract void load();
    }
}
