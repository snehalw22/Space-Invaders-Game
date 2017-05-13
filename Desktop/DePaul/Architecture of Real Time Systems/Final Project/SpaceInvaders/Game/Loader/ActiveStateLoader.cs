using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    class ActiveStateLoader
    {

        public void load()
        {
            clearScreen();
            Unit.level1();

            loadFont();
            SpriteBatch boxBatch = SpriteBatchManager.add(SpriteBatch.SpriteBatchName.Boxes);
            loadAliens();
            loadBombs();
            loadShields();
            loadMissile();
            loadShip();
            loadWalls();
            loadUFO();
            loadAnimationsTimer();
            activateCollisions();
        }
        public void clearScreen()
        {

            Font ModeSelection2 = FontManager.find(Font.FontName.ModeSelection2);
            FontManager.remove(ModeSelection2);
            Font welcome = FontManager.find(Font.FontName.Welcome);
            FontManager.remove(welcome);
            Font points = FontManager.find(Font.FontName.Points);
            FontManager.remove(points);
            points = FontManager.find(Font.FontName.Points);
            FontManager.remove(points);
            points = FontManager.find(Font.FontName.Points);
            FontManager.remove(points);
            points = FontManager.find(Font.FontName.Points);
            FontManager.remove(points);
        }
        public void loadFont()
        {
         
            FontManager.add(Font.FontName.Player1, SpriteBatch.SpriteBatchName.Text, "Player 1", Glyph.Name.Consolas36pt, 20, 980,Unit.whiteColor);
            FontManager.add(Font.FontName.Score, SpriteBatch.SpriteBatchName.Text, "Score", Glyph.Name.Consolas36pt, 200, 980, Unit.whiteColor);
            FontManager.add(Font.FontName.ScoreNum1, SpriteBatch.SpriteBatchName.Text, "<0>", Glyph.Name.Consolas36pt, 310, 980, Unit.redColor);
            FontManager.add(Font.FontName.Player1, SpriteBatch.SpriteBatchName.Text, "Player 2", Glyph.Name.Consolas36pt, 480, 980, Unit.whiteColor);
            FontManager.add(Font.FontName.Score, SpriteBatch.SpriteBatchName.Text, "Score : ", Glyph.Name.Consolas36pt, 660, 980, Unit.whiteColor);
            FontManager.add(Font.FontName.ScoreNum2, SpriteBatch.SpriteBatchName.Text, "<0>", Glyph.Name.Consolas36pt, 800, 980, Unit.blueColor);
        }
      
        public void loadPlayers()
        {
            Player player = PlayerManager.add(Player.PlayerType.Player1);
            PlayerManager.setCurrentPlayer(player);
        }
        public void loadImages()
        {
            ImageManager.add(Image.ImageName.CrabO, Texture.TextureName.GITex, new Azul.Rect(280, 2, 80, 80));
            ImageManager.add(Image.ImageName.CrabC, Texture.TextureName.GITex, new Azul.Rect(408, 2, 80, 80));
            ImageManager.add(Image.ImageName.SquidO, Texture.TextureName.GITex, new Azul.Rect(9, 2, 110, 80));
            ImageManager.add(Image.ImageName.SquidC, Texture.TextureName.GITex, new Azul.Rect(136, 2, 111, 80));
            ImageManager.add(Image.ImageName.OctopusO, Texture.TextureName.GITex, new Azul.Rect(4, 87, 120, 80));
            ImageManager.add(Image.ImageName.OctopusC, Texture.TextureName.GITex, new Azul.Rect(132, 87, 120, 80));
            ImageManager.add(Image.ImageName.AlienUFO, Texture.TextureName.GITex, new Azul.Rect(2, 440, 123, 57));
            ImageManager.add(Image.ImageName.AlienExplosion, Texture.TextureName.GITex, new Azul.Rect(400, 439, 96, 58));

            ImageManager.add(Image.ImageName.Splat, Texture.TextureName.GITex, new Azul.Rect(318,547,23,27));

            ImageManager.add(Image.ImageName.ZigZagU, Texture.TextureName.GITex, new Azul.Rect(172, 536, 12, 32));
            ImageManager.add(Image.ImageName.ZigZagD, Texture.TextureName.GITex, new Azul.Rect(188, 536, 12, 32));
            ImageManager.add(Image.ImageName.FlippingU, Texture.TextureName.GITex, new Azul.Rect(141, 536, 12, 32));
            ImageManager.add(Image.ImageName.FlippingD, Texture.TextureName.GITex, new Azul.Rect(157, 536, 12, 32));
            ImageManager.add(Image.ImageName.PlungerU, Texture.TextureName.GITex, new Azul.Rect(205, 536, 12, 32));
            ImageManager.add(Image.ImageName.PlungerD, Texture.TextureName.GITex, new Azul.Rect(221, 536, 12, 32));

            ImageManager.add(Image.ImageName.StraightMissile, Texture.TextureName.GITex, new Azul.Rect(237, 536, 4, 32));
            ImageManager.add(Image.ImageName.MissileExplosion, Texture.TextureName.GITex, new Azul.Rect(309, 545, 30, 31));

            ImageManager.add(Image.ImageName.ShieldBrick, Texture.TextureName.GITex, new Azul.Rect(50, 520, 5, 5));

            ImageManager.add(Image.ImageName.CannonShip, Texture.TextureName.GITex, new Azul.Rect(155, 442, 73, 52));
            ImageManager.add(Image.ImageName.ShipExplosion, Texture.TextureName.GITex, new Azul.Rect(270, 439, 103, 61));

            ImageManager.add(Image.ImageName.Wall, Texture.TextureName.GITex, new Azul.Rect(40, 185, 20, 10));

        }
     
        public void loadAliens()
        {

            AlienFactory alienFactory = FactoryManager.getAlienFactry();
            AlienGrid alienGrid = (AlienGrid)alienFactory.createAlien(Alien.AlienType.AlienGrid, GameObject.GameObjectName.AlienGrid, 0);

            alienFactory.setParent(alienGrid);

            for (int i = 0; i <11; i++)
            {
                alienFactory.setParent(alienGrid);

                Alien pColumn = alienFactory.createAlien(Alien.AlienType.Column, GameObject.GameObjectName.Column, i + 1, 0.0f, 0.0f);

                //set Parent
                alienFactory.setParent(pColumn);
                float x = Unit.alienPosX;
                float y = Unit.alienPosY;

                alienFactory.createAlien(Alien.AlienType.Crab, GameObject.GameObjectName.Crab, i + 2, x + i * 50.0f, y);

                alienFactory.createAlien(Alien.AlienType.Squid, GameObject.GameObjectName.Squid, i + 3, x + i * 50.0f, y - 60);

                 alienFactory.createAlien(Alien.AlienType.Squid, GameObject.GameObjectName.Squid, i + 4, x + i * 50.0f, y - 120);

                 alienFactory.createAlien(Alien.AlienType.Octopus, GameObject.GameObjectName.Octopus, i + 5, x + i * 50.0f, y - 180);

                alienFactory.createAlien(Alien.AlienType.Octopus, GameObject.GameObjectName.Octopus, i + 6, x + i * 50.0f, y - 240);

            }
            IrrKlang.ISoundEngine sndEngine = FactoryManager.getSoundEngine();
            AlienGridAnimation alienGridAni = new AlienGridAnimation(alienGrid, sndEngine);
            TimerManager.sortedAdd(TimerEvent.TimerEventName.SpriteAnimation, alienGridAni, Unit.AlienGridMoveEventTime);
        }
        public void loadSprites()
        {
            SpriteManager.add(Sprite.SpriteName.Crab, Image.ImageName.CrabO, 0, 100, 40, 40, Unit.tealColor);
            SpriteManager.add(Sprite.SpriteName.Squid, Image.ImageName.SquidO, 700, 400, 40, 40, Unit.purpleColor);
            SpriteManager.add(Sprite.SpriteName.Octopus, Image.ImageName.OctopusO, 450, 400, 40, 40, Unit.whiteColor);
            SpriteManager.add(Sprite.SpriteName.AlienExplosion, Image.ImageName.AlienExplosion, 0, 100, 40, 40, Unit.redColor);
            // Add bombs to sprite manager
            SpriteManager.add(Sprite.SpriteName.ZigZag, Image.ImageName.ZigZagU, 10.0f, 10.0f, 10.0f, 30.0f, Unit.redColor);
            SpriteManager.add(Sprite.SpriteName.Flipping, Image.ImageName.FlippingU, 10.0f, 10.0f, 10.0f, 30.0f, Unit.greenColor);
            SpriteManager.add(Sprite.SpriteName.Plunger, Image.ImageName.PlungerU, 10.0f, 10.0f, 10.0f, 30.0f, Unit.blueColor);
            //Missile
            SpriteManager.add(Sprite.SpriteName.StraightMissile, Image.ImageName.StraightMissile, 10.0f, 10.0f, 4.0f, 10.0f, Unit.redColor);
            SpriteManager.add(Sprite.SpriteName.MissileExplosion, Image.ImageName.MissileExplosion, 10.0f, 10.0f, 10, 10, Unit.redColor);
            // Add Shield
            SpriteManager.add(Sprite.SpriteName.ShieldBrick, Image.ImageName.ShieldBrick, 10, 10, 10,10, Unit.greenColor);
            //Wall
            SpriteManager.add(Sprite.SpriteName.Wall, Image.ImageName.Wall, 10.0f, 10.0f, 10.0f, 30.0f, Unit.redColor);
            // Add Ship
            SpriteManager.add(Sprite.SpriteName.CannonShip, Image.ImageName.CannonShip, 0, 0, 50.0f, 20.0f, Unit.whiteColor);
            SpriteManager.add(Sprite.SpriteName.ShipExplosion, Image.ImageName.ShipExplosion, 0, 0, 70.0f, 40.0f, Unit.redColor);
            //UFO
            SpriteManager.add(Sprite.SpriteName.AlienUFO, Image.ImageName.AlienUFO, 450, 400, 80, 40, Unit.redColor);
            //SpriteManager.add(Sprite.SpriteName.Splat, Image.ImageName.Splat, 450, 400, 10, 10, Unit.whiteColor);
            // Debug.WriteLine("Printing Sprites");
            //SpriteManager.printList();
        }
        public void loadShields()
        {

            ShieldFactory shieldFactory = FactoryManager.getShieldFactry();
            Shield shieldGrid = shieldFactory.createShield(Shield.ShieldType.ShieldGrid, GameObject.GameObjectName.ShieldGrid);

            shieldFactory.setParent(shieldGrid);


            for (int x = 0; x < 8; x = x + 2)
            {
                shieldFactory.setParent(shieldGrid);
                Shield shieldUnit = shieldFactory.createShield(Shield.ShieldType.ShieldUnit, GameObject.GameObjectName.ShieldUnit);
                shieldFactory.setParent(shieldUnit);

                Shield pColumn;
                pColumn = shieldFactory.createShield(Shield.ShieldType.ShieldColumn, GameObject.GameObjectName.ShieldColumn, 0);
                shieldFactory.setParent(pColumn);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (100 + (x * 100)), 150);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (100 + (x * 100)), 140);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (100 + (x * 100)), 130);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (100 + (x * 100)), 120);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (100 + (x * 100)), 110);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (100 + (x * 100)), 100);

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
                pColumn = shieldFactory.createShield(Shield.ShieldType.ShieldColumn, GameObject.GameObjectName.Column, 0);
                shieldFactory.setParent(pColumn);

                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (120 + (x * 100)), 170);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (120 + (x * 100)), 160);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (120 + (x * 100)), 150);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (120 + (x * 100)), 140);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (120 + (x * 100)), 130);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (120 + (x * 100)), 120);


                shieldFactory.setParent(shieldUnit);
                pColumn = shieldFactory.createShield(Shield.ShieldType.ShieldColumn, GameObject.GameObjectName.Column, 0);
                shieldFactory.setParent(pColumn);

                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (130 + (x * 100)), 170);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (130 + (x * 100)), 160);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (130 + (x * 100)), 150);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (130 + (x * 100)), 140);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (130 + (x * 100)), 130);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (130 + (x * 100)), 120);

                shieldFactory.setParent(shieldUnit);
                pColumn = shieldFactory.createShield(Shield.ShieldType.ShieldColumn, GameObject.GameObjectName.Column, 0);
                shieldFactory.setParent(pColumn);

                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (140 + (x * 100)), 170);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (140 + (x * 100)), 160);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (140 + (x * 100)), 150);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (140 + (x * 100)), 140);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (140 + (x * 100)), 130);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (140 + (x * 100)), 120);

                shieldFactory.setParent(shieldUnit);
                pColumn = shieldFactory.createShield(Shield.ShieldType.ShieldColumn, GameObject.GameObjectName.Column, 0);
                shieldFactory.setParent(pColumn);

                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (150 + (x * 100)), 160);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (150 + (x * 100)), 150);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (150 + (x * 100)), 140);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (150 + (x * 100)), 130);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (150 + (x * 100)), 120);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (150 + (x * 100)), 110);

                shieldFactory.setParent(shieldUnit);
                pColumn = shieldFactory.createShield(Shield.ShieldType.ShieldColumn, GameObject.GameObjectName.ShieldColumn, 0);
                shieldFactory.setParent(pColumn);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (160 + (x * 100)), 150);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (160 + (x * 100)), 140);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (160 + (x * 100)), 130);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (160 + (x * 100)), 120);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (160 + (x * 100)), 110);
                shieldFactory.createShield(Shield.ShieldType.ShieldBrick, GameObject.GameObjectName.ShieldBrick, 0, (160 + (x * 100)), 100);

            }
        }
     
        public void loadMissile()
        {

            MissileFactory missileFactory = FactoryManager.getMissileFactry();
            Missile missileRoot = missileFactory.createMissile(Missile.MissileType.MissileRoot, GameObject.GameObjectName.MissileRoot, 0, 0, 0);

            missileFactory.setParent(missileRoot);

         //   Missile missile = missileFactory.createMissile(Missile.MissileType.MissileExplosion, GameObject.GameObjectName.MissileExplosion, 0,0,0);
        }

        public void loadShip()
        {
            ShipFactory shipFactory = FactoryManager.getShipFactry();
            Ship shipRoot = shipFactory.createShip(Ship.ShipType.ShipRoot, GameObject.GameObjectName.ShipRoot, 0);

            shipFactory.setParent(shipRoot);

            CannonShip cannonShip = (CannonShip)shipFactory.createShip(Ship.ShipType.CannonShip, GameObject.GameObjectName.CannonShip, 1, 40, 30);
            ShipManager.setShip(cannonShip);

            cannonShip = (CannonShip)shipFactory.createShip(Ship.ShipType.CannonShip, GameObject.GameObjectName.CannonShip, 1, 110, 30);
            ShipManager.setShip(cannonShip);

            cannonShip = (CannonShip)shipFactory.createShip(Ship.ShipType.CannonShip, GameObject.GameObjectName.CannonShip, 1, Unit.shipPosX, Unit.shipPosY);
            ShipManager.setShip(cannonShip);
            ShipManager.getShip().setShipState(ShipManager.ShipStateType.Ready);
        }
        public void loadWalls()
        {
            WallFactory wallFactory = FactoryManager.getWallFactry();
            Wall wallRoot = wallFactory.createWall(Wall.WallType.WallRoot, GameObject.GameObjectName.WallRoot);

            wallFactory.setParent(wallRoot);
            // 0, 448, 900, 850, 30
            //wallFactory.createWall(Wall.WallType.WallTop, GameObject.GameObjectName.Wall, 0, 448, 900, 850, 10);
            wallFactory.createWall(Wall.WallType.WallTop, GameObject.GameObjectName.WallTop, 0, 446, 950, 892, 1);
            wallFactory.createWall(Wall.WallType.WallDown, GameObject.GameObjectName.WallDown,0, 446, 1, 1000, 100);
            // wallFactory.createWall(Wall.WallType.WallRight, GameObject.GameObjectName.WallRight, 2, 892, 500, 1, 1020);
            wallFactory.createWall(Wall.WallType.WallRight, GameObject.GameObjectName.WallRight, 0, 860, 500,1, 1024);
            wallFactory.createWall(Wall.WallType.WallLeft, GameObject.GameObjectName.WallLeft,0,    20, 510, 1, 1024);
        //      wallFactory.createWall(Wall.WallType.WallRight, GameObject.GameObjectName.WallRight, 0, 625, 500, 50, 900);
        //    wallFactory.createWall(Wall.WallType.WallLeft, GameObject.GameObjectName.WallLeft, 0, 100, 500, 50, 900);

        }
        public void loadAnimationsTimer()
        {
            AlienImageAnimation squidSprite = new AlienImageAnimation(Sprite.SpriteName.Squid);
            squidSprite.attachImg(Image.ImageName.SquidO);
            squidSprite.attachImg(Image.ImageName.SquidC);

            AlienImageAnimation crabSprite = new AlienImageAnimation(Sprite.SpriteName.Crab);
            crabSprite.attachImg(Image.ImageName.CrabO);
            crabSprite.attachImg(Image.ImageName.CrabC);

            AlienImageAnimation octopusSprite = new AlienImageAnimation(Sprite.SpriteName.Octopus);
            octopusSprite.attachImg(Image.ImageName.OctopusO);
            octopusSprite.attachImg(Image.ImageName.OctopusC);


            TimerManager.sortedAdd(TimerEvent.TimerEventName.SpriteAnimation, squidSprite, Unit.AlienImageSwapEventTime);
            TimerManager.sortedAdd(TimerEvent.TimerEventName.SpriteAnimation, crabSprite, Unit.AlienImageSwapEventTime);
            TimerManager.sortedAdd(TimerEvent.TimerEventName.SpriteAnimation, octopusSprite, Unit.AlienImageSwapEventTime);

            // Bomb Animations

            AlienImageAnimation zigZagSprite = new AlienImageAnimation(Sprite.SpriteName.ZigZag);
            zigZagSprite.attachImg(Image.ImageName.ZigZagU);
            zigZagSprite.attachImg(Image.ImageName.ZigZagD);

            AlienImageAnimation flippingSprite = new AlienImageAnimation(Sprite.SpriteName.Flipping);
            flippingSprite.attachImg(Image.ImageName.FlippingU);
            flippingSprite.attachImg(Image.ImageName.FlippingD);

            AlienImageAnimation plungerSprite = new AlienImageAnimation(Sprite.SpriteName.Plunger);
            plungerSprite.attachImg(Image.ImageName.PlungerU);
            plungerSprite.attachImg(Image.ImageName.PlungerD);

            TimerManager.sortedAdd(TimerEvent.TimerEventName.SpriteAnimation, zigZagSprite, Unit.bombImageSwapTime);
            TimerManager.sortedAdd(TimerEvent.TimerEventName.SpriteAnimation, flippingSprite, Unit.bombImageSwapTime);
            TimerManager.sortedAdd(TimerEvent.TimerEventName.SpriteAnimation, plungerSprite, Unit.bombImageSwapTime);
        }
        public void activateCollisions()
        {
            IrrKlang.ISoundEngine sndEngine = FactoryManager.getSoundEngine();
            CollisionPair Bomb_Ship = CollisionPairManager.add(CollisionPair.CollisionPairName.Bomb_Ship, GameObjectNodeManager.find(GameObject.GameObjectName.BombRoot), GameObjectNodeManager.find(GameObject.GameObjectName.ShipRoot));
            Bomb_Ship.attach(new GameEndObserver());
            Bomb_Ship.attach(new ShipDeathFreezeObserver(Unit.gameFreezeTime));
            Bomb_Ship.attach(new SoundObserver(sndEngine, "Explosion.wav"));
            Bomb_Ship.attach(new BombCollideObserver());
            Bomb_Ship.attach(new BombShipCollideObserver());

            CollisionPair Alien_Missile = CollisionPairManager.add(CollisionPair.CollisionPairName.Alien_Missile, GameObjectNodeManager.find(GameObject.GameObjectName.AlienGrid), GameObjectNodeManager.find(GameObject.GameObjectName.MissileRoot));
            Alien_Missile.attach(new AlienMissileObserver());
            Alien_Missile.attach(new SoundObserver(sndEngine, "invaderkilled.wav"));
            Alien_Missile.attach(new ShipReadyObserver());

            CollisionPair Alien_Wall = CollisionPairManager.add(CollisionPair.CollisionPairName.Alien_Wall, GameObjectNodeManager.find(GameObject.GameObjectName.AlienGrid), GameObjectNodeManager.find(GameObject.GameObjectName.WallRoot));
            Alien_Wall.attach(new AlienWallObserver());
            // Alien_Wall.attach(new SoundObserver(sndEngine, "Explosion.wav"));

            CollisionPair Alien_Shield = CollisionPairManager.add(CollisionPair.CollisionPairName.Alien_Shield, GameObjectNodeManager.find(GameObject.GameObjectName.AlienGrid), GameObjectNodeManager.find(GameObject.GameObjectName.ShieldGrid));
            Alien_Shield.attach(new ShieldHitObserver());


            CollisionPair Alien_Ship = CollisionPairManager.add(CollisionPair.CollisionPairName.Alien_Ship, GameObjectNodeManager.find(GameObject.GameObjectName.AlienGrid), GameObjectNodeManager.find(GameObject.GameObjectName.ShipRoot));
             Alien_Ship.attach(new SoundObserver(sndEngine, "invaderkilled.wav"));
             Alien_Ship.attach(new GameOverObserver());
            Alien_Ship.attach(new GameEndObserver());

            CollisionPair Missile_Wall = CollisionPairManager.add(CollisionPair.CollisionPairName.Missile_Wall, GameObjectNodeManager.find(GameObject.GameObjectName.MissileRoot), GameObjectNodeManager.find(GameObject.GameObjectName.WallRoot));
            Missile_Wall.attach(new ShipReadyObserver());
            //   Missile_Wall.attach(new SoundObserver(sndEngine, "invaderkilled.wav"));
            Missile_Wall.attach(new MissileRemoveObserver());

            CollisionPair Missile_Shield = CollisionPairManager.add(CollisionPair.CollisionPairName.Missile_Shield, GameObjectNodeManager.find(GameObject.GameObjectName.MissileRoot), GameObjectNodeManager.find(GameObject.GameObjectName.ShieldGrid));
            Missile_Shield.attach(new SoundObserver(sndEngine, "invaderkilled.wav"));
            Missile_Shield.attach(new ShieldHitObserver());
            Missile_Shield.attach(new ShieldMissileObserver());
            Missile_Shield.attach(new ShipReadyObserver());

            CollisionPair Ship_Wall = CollisionPairManager.add(CollisionPair.CollisionPairName.Ship_Wall, GameObjectNodeManager.find(GameObject.GameObjectName.ShipRoot), GameObjectNodeManager.find(GameObject.GameObjectName.WallRoot));
            //   Ship_Wall.attach(new SoundObserver(sndEngine, "invaderkilled.wav"));
            Ship_Wall.attach(new ShipWallObserver());

            CollisionPair Bomb_Wall = CollisionPairManager.add(CollisionPair.CollisionPairName.Bomb_Wall, GameObjectNodeManager.find(GameObject.GameObjectName.BombRoot), GameObjectNodeManager.find(GameObject.GameObjectName.WallRoot));
            //  Bomb_Wall.attach(new SoundObserver(sndEngine, "invaderkilled.wav"));
            Bomb_Wall.attach(new BombCollideObserver());

            CollisionPair Bomb_Missile = CollisionPairManager.add(CollisionPair.CollisionPairName.Bomb_Missile, GameObjectNodeManager.find(GameObject.GameObjectName.BombRoot), GameObjectNodeManager.find(GameObject.GameObjectName.MissileRoot));
            Bomb_Missile.attach(new BombCollideObserver());
            //  Bomb_Missile.attach(new SoundObserver(sndEngine, "invaderkilled.wav"));
            Bomb_Missile.attach(new ShipReadyObserver());
            Bomb_Missile.attach(new MissileRemoveObserver());

            CollisionPair Bomb_Shield = CollisionPairManager.add(CollisionPair.CollisionPairName.Bomb_Shield, GameObjectNodeManager.find(GameObject.GameObjectName.BombRoot), GameObjectNodeManager.find(GameObject.GameObjectName.ShieldGrid));
            Bomb_Shield.attach(new BombCollideObserver());
            //   Bomb_Shield.attach(new SoundObserver(sndEngine, "invaderkilled.wav"));
            Bomb_Shield.attach(new ShieldHitObserver());

            CollisionPair Misisle_UFO = CollisionPairManager.add(CollisionPair.CollisionPairName.Misisle_UFO, GameObjectNodeManager.find(GameObject.GameObjectName.MissileRoot), GameObjectNodeManager.find(GameObject.GameObjectName.UFORoot));
            Misisle_UFO.attach(new UFOMissileObserver());
            Misisle_UFO.attach(new ShipReadyObserver());
            Misisle_UFO.attach(new SoundObserver(sndEngine, "ufo_highpitch.wav"));
           // Misisle_UFO.attach(new UFOLaunchObserver());

            CollisionPair UFO_Wall = CollisionPairManager.add(CollisionPair.CollisionPairName.UFO_Wall, GameObjectNodeManager.find(GameObject.GameObjectName.UFORoot), GameObjectNodeManager.find(GameObject.GameObjectName.WallRoot));
            UFO_Wall.attach(new UFOLaunchObserver());
        }
        public void loadBombs()
        {
            BombFactory bombFactory = FactoryManager.getBombFactry();
            Bomb bombRoot = bombFactory.createBomb(Bomb.BombType.BombRoot, GameObject.GameObjectName.BombRoot);
            bombFactory.setParent(bombRoot);

            Bomb ZigZag = null;
            ZigZag = bombFactory.createBomb(Bomb.BombType.ZigZag, GameObject.GameObjectName.Bomb, 0, 996, 1024);
            ActivateBombSprite abs = new ActivateBombSprite(ZigZag);
            TimerManager.sortedAdd(TimerEvent.TimerEventName.ActivateGameEnd, abs, 1);

            Bomb FlippingBomb = null;
            FlippingBomb = bombFactory.createBomb(Bomb.BombType.Flipping, GameObject.GameObjectName.Bomb, 1, 996, 1024);
            ActivateBombSprite abs2 = new ActivateBombSprite(FlippingBomb);
            TimerManager.sortedAdd(TimerEvent.TimerEventName.ActivateGameEnd, abs2, 3);

            Bomb plungerBomb = null;
            plungerBomb = bombFactory.createBomb(Bomb.BombType.Plunger, GameObject.GameObjectName.Bomb, 2, 996, 1024);
            ActivateBombSprite abs3 = new ActivateBombSprite(plungerBomb);
            TimerManager.sortedAdd(TimerEvent.TimerEventName.ActivateGameEnd, abs3, 5);

            Bomb ZigZag1 = null;
            ZigZag1 = bombFactory.createBomb(Bomb.BombType.ZigZag, GameObject.GameObjectName.Bomb, 0, 996, 1024);
            ActivateBombSprite abs4 = new ActivateBombSprite(ZigZag1);
            TimerManager.sortedAdd(TimerEvent.TimerEventName.ActivateGameEnd, abs4, 6);

            Bomb FlippingBomb1 = null;
            FlippingBomb1= bombFactory.createBomb(Bomb.BombType.Flipping, GameObject.GameObjectName.Bomb, 1, 996, 1024);
            ActivateBombSprite abs5 = new ActivateBombSprite(FlippingBomb1);
            TimerManager.sortedAdd(TimerEvent.TimerEventName.ActivateGameEnd, abs5, 7);

            Bomb plungerBomb1 = null;
            plungerBomb1 = bombFactory.createBomb(Bomb.BombType.Plunger, GameObject.GameObjectName.Bomb, 2, 996, 1024);
            ActivateBombSprite abs6 = new ActivateBombSprite(plungerBomb1);
            TimerManager.sortedAdd(TimerEvent.TimerEventName.ActivateGameEnd, abs6, 8);

  
        }

        public void loadUFO()
        {
            UFOFactory ufoFactory = FactoryManager.getUfoFactry();
            UFORoot ufoRoot = (UFORoot)ufoFactory.createUFO(UFO.UFOType.UFORoot, GameObject.GameObjectName.UFORoot, 0, 0, 0);
            ufoFactory.setParent(ufoRoot);

            UFO ufo = ufoFactory.createUFO(UFO.UFOType.AlienUFO, GameObject.GameObjectName.AlienUFO, 1, Unit.ufoPosX, Unit.ufoPosY);
            Random random = new Random(DateTime.UtcNow.Millisecond);
            int number = random.Next(1, 40);
            UFOActivate ufoAct = new UFOActivate(ufo);
            TimerManager.sortedAdd(TimerEvent.TimerEventName.ActivateUFO, ufoAct,number);
        }
    }
}
