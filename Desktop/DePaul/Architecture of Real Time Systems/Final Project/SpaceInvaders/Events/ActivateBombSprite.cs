using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    class ActivateBombSprite : Command
    {
        Bomb bomb;
        bool associated;
        public ActivateBombSprite()
        {
            this.bomb = null;
            this.associated = false;
        }
        public ActivateBombSprite(Bomb b)
        {
            this.bomb = b;
        }
      
        public void setBomb(Bomb b)
        {
            Debug.Assert(b != null);
            this.bomb = b;
        }
        public override void execute(float deltaTime)
        {
            associateBombs();
            if (bomb == null)
            {
                Debug.WriteLine("bonb null");
                TimerManager.sortedAdd(TimerEvent.TimerEventName.ActivateGameEnd, this, deltaTime);
            }
            else
            {
                bomb.active = true;
            }
         //  TimerManager.sortedAdd(TimerEvent.TimerEventName.ActivateBomb, this, deltaTime);
        }

        public void associateBombs()
        {
            UFO ufo = (UFO)FactoryManager.getUfoFactry().cParent.pChild;

            if (ufo.launch)
            {
                if (ufo.x > 50)
                {
                    Random random = new Random(DateTime.UtcNow.Millisecond);
                    int number = random.Next(1, 3);

                    if (number == 2)
                    {
                        Bomb bomb = getActivatedBomb();
                        bomb.x = ufo.x;
                        bomb.y = ufo.y;
                        associated = true;
                    }
                }
            }
            if (!associated)
            {
                int colCount = FactoryManager.getAlienFactry().columnCount;
                if (colCount > 0)
                {
                    Random random = new Random(DateTime.UtcNow.Millisecond);
                    int number = random.Next(1, colCount);
                    PCSTree columnPcsTree = FactoryManager.getAlienFactry().cPCSTree;
                    GameObject column = (GameObject)columnPcsTree.getRoot().pChild;

                    while (column != null)
                    {
                        number--;
                        if (number == 0)
                        {
                            GameObject alien = (GameObject)column.pChild;

                            if (bomb == null)
                            {
                             Bomb bomb = getActivatedBomb();
                            //bomb = (Bomb)GhostManager.find(GameObject.GameObjectName.Bomb);

                            //GhostManager.remove(bomb);
                            //BombFactory bombF = FactoryManager.getBombFactry();
                            //bombF.activate(bomb);
                            if (bomb == null)
                            {
                                Debug.WriteLine("bomb null");
                            }
                        }
                            bomb.x = alien.x;
                            bomb.y = alien.y;
                            break;
                        }
                        column = (GameObject)column.pSibling;
                    }
                }
            }
            associated = false;
        }

        public Bomb getActivatedBomb()
        {
            bomb = (Bomb)GhostManager.find(GameObject.GameObjectName.Bomb);
            GhostManager.remove(bomb);
            BombFactory bombF = FactoryManager.getBombFactry();
            bombF.activate(bomb);
            return bomb;
        }
       }
    }
