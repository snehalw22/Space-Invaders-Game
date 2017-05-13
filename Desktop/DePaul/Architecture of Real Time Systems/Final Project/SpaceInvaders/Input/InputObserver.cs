using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    abstract class InputObserver : MLink
    {
        public InputSubject inputSubject;
        abstract public void notify();      
    }


}
