using System;
using System.Diagnostics;

namespace SpaceInvaders
{ 
   abstract  class LinkedList
    {
    public LinkedList pColNext;
    public LinkedList pColPrev;

    protected LinkedList()
    {
        pColPrev = null;
        pColNext = null;
    }
}
}
