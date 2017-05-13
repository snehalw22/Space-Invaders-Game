using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Utilty
    {
        private static readonly Random random = new Random();

        public static int getRandomNum(int minValue, int maxValue)
        {
            int next = random.Next(minValue,maxValue);
            return next;
        }
    }
}
