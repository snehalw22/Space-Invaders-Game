using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class StartStateLoader
    {
        public void load()
        {
            TextureManager.createMInstance(2, 4);
            ImageManager.createMInstance(2, 4);
            SpriteManager.createMInstance(2, 4);
            SpriteBoxManager.createMInstance(2, 4);
            SpriteBatchManager.createMInstance(2, 1);
            TimerManager.createMInstance(2, 4);
            ProxySpriteManager.createMInstance(2, 4);
            GameObjectNodeManager.createMInstance(2, 4);
            CollisionPairManager.createMInstance(2, 4);
            ShipManager.createMInstance();
            FactoryManager.createMInstance();
            InputManager.createMInstance();
            PlayerManager.createMInstance();
            GhostManager.createMInstance(1, 2);
            GlyphManager.Create(3, 1);
            FontManager.createMInstance(1, 1);
            loadTexture();
            loadImages();
            loadSprites();
            loadFont();
            loadPointSystem();
        }
        public void loadTexture()
        {
            TextureManager.add(Texture.TextureName.GITex, "Final_Sprites.tga");
            TextureManager.add(Texture.TextureName.Consolas36pt, "Consolas36pt.tga");
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
            SpriteManager.add(Sprite.SpriteName.MissileExplosion, Image.ImageName.StraightMissile, 10.0f, 10.0f, 30, 30, Unit.redColor);
            // Add Shield
            SpriteManager.add(Sprite.SpriteName.ShieldBrick, Image.ImageName.ShieldBrick, 10, 10, 10, 10, Unit.greenColor);
            //Wall
            SpriteManager.add(Sprite.SpriteName.Wall, Image.ImageName.Wall, 10.0f, 10.0f, 10.0f, 30.0f, Unit.redColor);
            // Add Ship
            SpriteManager.add(Sprite.SpriteName.CannonShip, Image.ImageName.CannonShip, 0, 0, 50.0f, 20.0f, Unit.whiteColor);
            SpriteManager.add(Sprite.SpriteName.ShipExplosion, Image.ImageName.ShipExplosion, 0, 0, 70.0f, 40.0f, Unit.redColor);
            //UFO
            SpriteManager.add(Sprite.SpriteName.AlienUFO, Image.ImageName.AlienUFO, 450, 400, 80, 40, Unit.redColor);
            // Debug.WriteLine("Printing Sprites");
            //SpriteManager.printList();
        }
        public void loadFont()
        {
            SpriteBatch pSB_Texts = SpriteBatchManager.add(SpriteBatch.SpriteBatchName.Text);
            GlyphManager.addXml(Glyph.Name.Consolas36pt, "Consolas36pt.xml", Texture.TextureName.Consolas36pt);
            FontManager.add(Font.FontName.Welcome, SpriteBatch.SpriteBatchName.Text, "Welcome To Space Inavders Game", Glyph.Name.Consolas36pt, 150, 800, Unit.whiteColor);
            //FontManager.add(Font.FontName.ModeSelection1, SpriteBatch.SpriteBatchName.Text, "Press 1 to Start Single Player Game", Glyph.Name.Consolas36pt, 100, 400,Unit.redColor);
            FontManager.add(Font.FontName.ModeSelection2, SpriteBatch.SpriteBatchName.Text, "Press 1 to Start Single Player Game", Glyph.Name.Consolas36pt, 100, 340,Unit.blueColor);

            FontManager.add(Font.FontName.Points, SpriteBatch.SpriteBatchName.Text, "30 Points", Glyph.Name.Consolas36pt, 400, 700, Unit.blueColor);
            FontManager.add(Font.FontName.Points, SpriteBatch.SpriteBatchName.Text, "20 Points", Glyph.Name.Consolas36pt, 400, 630, Unit.purpleColor);
            FontManager.add(Font.FontName.Points, SpriteBatch.SpriteBatchName.Text, "10 Points", Glyph.Name.Consolas36pt, 400, 560, Unit.whiteColor);
            FontManager.add(Font.FontName.Points, SpriteBatch.SpriteBatchName.Text, "100 Points", Glyph.Name.Consolas36pt, 400, 500, Unit.redColor);

        }
        public void loadPointSystem()
        {





        }
      }
    }

