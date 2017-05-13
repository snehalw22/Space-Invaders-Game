using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Level1 : Level
    {
        public override void load()
        {

            Unit.level1();
            AlienFactory alienFactory = FactoryManager.getAlienFactry();
            AlienGrid alienGrid = (AlienGrid)alienFactory.cPCSTree.getRoot();
            alienGrid.updateDelta();
            PCSTree pcsTree = FactoryManager.getAlienFactry().cPCSTree;
            SpriteBatch cSpriteBatch = alienFactory.cSpriteBatch;
            for (int i = 0; i < 6; i++)
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

            }


            ShipFactory shipFactory = FactoryManager.getShipFactry();
            ShipRoot shipGrid = (ShipRoot)shipFactory.cPCSTree.getRoot();

            CannonShip Ship =
             Ship = (CannonShip)GhostManager.find(GameObject.GameObjectName.CannonShip);
            GhostManager.remove(Ship);
            shipFactory.activate(Ship);
            Ship.x = Unit.shipPosX;
            Ship.y = Unit.shipPosY;

            Ship = (CannonShip)GhostManager.find(GameObject.GameObjectName.CannonShip);
            GhostManager.remove(Ship);
            shipFactory.activate(Ship);
            Ship.x = 40;
            Ship.y = 30;

            Ship = (CannonShip)GhostManager.find(GameObject.GameObjectName.CannonShip);
            GhostManager.remove(Ship);
            shipFactory.activate(Ship);
            Ship.x = 110;
            Ship.y = 30;


            //42 brics
            //7 col
            //4 bricks
            ShieldFactory shieldFactory = FactoryManager.getShieldFactry();
            ShieldGrid shieldGrid = (ShieldGrid)shieldFactory.cPCSTree.getRoot();

            shieldFactory.setParent(shieldGrid);
            for (int x = 0; x < 8; x = x + 2)
            {
                shieldFactory.setParent(shieldGrid);
                Shield shieldUnit = shieldFactory.createShield(Shield.ShieldType.ShieldUnit, GameObject.GameObjectName.ShieldUnit);
                shieldFactory.setParent(shieldUnit);

                Shield pColumn;
                pColumn = shieldFactory.createShield(Shield.ShieldType.ShieldColumn, GameObject.GameObjectName.ShieldColumn, 0);
                shieldFactory.setParent(pColumn);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (60 + (x * 100)), 150);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (60 + (x * 100)), 140);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (60 + (x * 100)), 130);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (60 + (x * 100)), 120);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (60 + (x * 100)), 110);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (60 + (x * 100)), 100);

                shieldFactory.setParent(shieldUnit);
                pColumn = shieldFactory.createShield(Shield.ShieldType.ShieldColumn, GameObject.GameObjectName.Column, 0);
                shieldFactory.setParent(pColumn);

                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (70 + (x * 100)), 160);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (70 + (x * 100)), 150);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (70 + (x * 100)), 140);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (70 + (x * 100)), 130);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (70 + (x * 100)), 120);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (70 + (x * 100)), 110);

                shieldFactory.setParent(shieldUnit);
                pColumn = shieldFactory.createShield(Shield.ShieldType.ShieldColumn, GameObject.GameObjectName.Column, 0);
                shieldFactory.setParent(pColumn);

                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (80 + (x * 100)), 170);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (80 + (x * 100)), 160);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (80 + (x * 100)), 150);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (80 + (x * 100)), 140);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (80 + (x * 100)), 130);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (80 + (x * 100)), 120);


                shieldFactory.setParent(shieldUnit);
                pColumn = shieldFactory.createShield(Shield.ShieldType.ShieldColumn, GameObject.GameObjectName.Column, 0);
                shieldFactory.setParent(pColumn);

                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (90 + (x * 100)), 170);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (90 + (x * 100)), 160);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (90 + (x * 100)), 150);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (90 + (x * 100)), 140);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (90 + (x * 100)), 130);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (90 + (x * 100)), 120);

                shieldFactory.setParent(shieldUnit);
                pColumn = shieldFactory.createShield(Shield.ShieldType.ShieldColumn, GameObject.GameObjectName.Column, 0);
                shieldFactory.setParent(pColumn);

                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (100 + (x * 100)), 170);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (100 + (x * 100)), 160);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (100 + (x * 100)), 150);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (100 + (x * 100)), 140);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (100 + (x * 100)), 130);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (100 + (x * 100)), 120);

                shieldFactory.setParent(shieldUnit);
                pColumn = shieldFactory.createShield(Shield.ShieldType.ShieldColumn, GameObject.GameObjectName.Column, 0);
                shieldFactory.setParent(pColumn);

                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (110 + (x * 100)), 160);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (110 + (x * 100)), 150);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (110 + (x * 100)), 140);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (110 + (x * 100)), 130);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (110 + (x * 100)), 120);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (110 + (x * 100)), 110);

                shieldFactory.setParent(shieldUnit);
                pColumn = shieldFactory.createShield(Shield.ShieldType.ShieldColumn, GameObject.GameObjectName.ShieldColumn, 0);
                shieldFactory.setParent(pColumn);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (120 + (x * 100)), 150);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (120 + (x * 100)), 140);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (120 + (x * 100)), 130);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (120 + (x * 100)), 120);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (120 + (x * 100)), 110);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (120 + (x * 100)), 100);

            }
        }
    }
    }

