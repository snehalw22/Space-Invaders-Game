using System;
using System.Diagnostics;

namespace SpaceInvaders
{
   abstract class CollisionObserver : MLink
    {
        public abstract void notify();
        public CollisionSubject colSubject;

        public void setColSubject(CollisionSubject mColSubject)
        {
            this.colSubject = mColSubject;
        }
        protected override void nodeStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
