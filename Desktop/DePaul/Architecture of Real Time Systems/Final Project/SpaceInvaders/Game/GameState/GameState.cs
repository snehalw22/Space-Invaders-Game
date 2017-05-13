using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract class GameState
    {
        public abstract void load();
        public abstract void update(float totalTime);
        public abstract void draw();
    }
}
