using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienDeathAnimation : Command
    {
        public Alien alien;

        public AlienDeathAnimation()
        {
        }
        public AlienDeathAnimation(Alien mAlien)
        {
            this.alien = mAlien;
        }
        public override void execute(float deltaTime)
        {
            Column col = (Column)alien.pParent;
            alien.remove();
            AlienFactory af = FactoryManager.getAlienFactry();
            af.reduceCount(alien);

            if(af.alienCount==20)
            {

                Unit.level1Mid();
                AlienGrid ag =(AlienGrid) af.cPCSTree.getRoot();
                ag.updateDelta();
            }
            if (af.alienCount == 5)
            {
                Unit.level1Last();
                AlienGrid ag = (AlienGrid)af.cPCSTree.getRoot();
                ag.updateDelta();
            }

            //Commnetd for level 2
            if (col.death)
            {
               af.reduceCount(col);
                col.remove();
            }         
        }
    }
}