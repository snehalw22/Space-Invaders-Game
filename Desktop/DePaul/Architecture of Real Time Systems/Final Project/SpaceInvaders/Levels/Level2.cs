using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Level2 : Level
    {
        public override void load()
        {
            Unit.level2Start();

            AlienFactory alienFactory = FactoryManager.getAlienFactry();
            AlienGrid alienGrid = (AlienGrid)FactoryManager.getAlienFactry().cPCSTree.getRoot();
            alienGrid.updateDelta();
            PCSTree pcsTree = FactoryManager.getAlienFactry().cPCSTree;
            SpriteBatch cSpriteBatch = FactoryManager.getAlienFactry().cSpriteBatch;
            for (int i = 0; i < 11; i++)
            {
                FactoryManager.getAlienFactry().setParent(alienGrid);
                Alien pColumn = (Alien)GhostManager.find(GameObject.GameObjectName.Column);
                GhostManager.remove(pColumn);

                pColumn.set(Sprite.SpriteName.NullObject, i + 1, 0, 0);
                alienFactory.activate(pColumn);
                alienFactory.setParent(pColumn);

                float x = Unit.alienPosX;
                float y = Unit.alienPosY;

                Alien alien = (Alien)GhostManager.find(GameObject.GameObjectName.Crab);
                GhostManager.remove(alien);
                alien.set(Sprite.SpriteName.Crab, i + 2, x + i * 60.0f, y);
                alienFactory.activate(alien);

                Alien alien2 = (Alien)GhostManager.find(GameObject.GameObjectName.Squid);
                GhostManager.remove(alien2);
                alien2.set(Sprite.SpriteName.Squid, i + 2, x + i * 60.0f, y - 60);
                alienFactory.activate(alien2);

                Alien alien3 = (Alien)GhostManager.find(GameObject.GameObjectName.Squid);
                GhostManager.remove(alien3);
                alien3.set(Sprite.SpriteName.Squid, i + 2, x + i * 60.0f, y - 120);
                alienFactory.activate(alien3);

                Alien alien4 = (Alien)GhostManager.find(GameObject.GameObjectName.Octopus);
                GhostManager.remove(alien4);
                alien4.set(Sprite.SpriteName.Octopus, i + 2, x + i * 60.0f, y - 180);
                alienFactory.activate(alien4);

                Alien alien5 = (Alien)GhostManager.find(GameObject.GameObjectName.Octopus);
                GhostManager.remove(alien5);
                alien5.set(Sprite.SpriteName.Octopus, i + 6, x + i * 60.0f, y - 240);
                alienFactory.activate(alien5);


                //  alienFactory.createAlien(Alien.AlienType.Squid, GameObject.GameObjectName.Squid, i + 3, x + i * 60.0f, y - 60);

                // alienFactory.createAlien(Alien.AlienType.Squid, GameObject.GameObjectName.Squid, i+4, x + i * 60.0f, y-120);

                // alienFactory.createAlien(Alien.AlienType.Octopus, GameObject.GameObjectName.Octopus, i+5, x + i * 60.0f, y-180);

                // alienFactory.createAlien(Alien.AlienType.Octopus, GameObject.GameObjectName.Octopus, i+6, x + i * 60.0f, y-240);

            }
           
        }
    }
}
