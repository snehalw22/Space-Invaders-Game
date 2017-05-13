using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    class FactoryManager
    {

        private AlienFactory alienFactory;
        private BombFactory bombFactory;
        private MissileFactory missileFactory;
        private ShieldFactory shieldFactory;
        private ShipFactory shipFactory;
        private WallFactory wallFactory;
        private UFOFactory ufoFactory;
        private static FactoryManager facMInstance = null;
        private IrrKlang.ISoundEngine sndEngine = null;

        private FactoryManager()
        {

            SpriteBatch alienBatch = SpriteBatchManager.add(SpriteBatch.SpriteBatchName.Aliens);
            PCSTree alienPcsTree = new PCSTree();
            this.alienFactory = new AlienFactory(alienPcsTree,alienBatch);

            SpriteBatch bombBatch = SpriteBatchManager.add(SpriteBatch.SpriteBatchName.Bombs);
            PCSTree bombPcsTree = new PCSTree();
            this.bombFactory = new BombFactory(bombPcsTree, bombBatch);

            SpriteBatch missileBatch = SpriteBatchManager.add(SpriteBatch.SpriteBatchName.Missiles);
            PCSTree missilePcsTree = new PCSTree();
            this.missileFactory = new MissileFactory(missilePcsTree, missileBatch);


            SpriteBatch shieldBatch = SpriteBatchManager.add(SpriteBatch.SpriteBatchName.Shields);
            PCSTree shieldPcsTree = new PCSTree();
            this.shieldFactory = new ShieldFactory(shieldPcsTree, shieldBatch);

            SpriteBatch shipBatch = SpriteBatchManager.add(SpriteBatch.SpriteBatchName.Ships);
            PCSTree shipPcsTree = new PCSTree();
            this.shipFactory = new ShipFactory(shipPcsTree, shipBatch);

            SpriteBatch wallBatch = SpriteBatchManager.add(SpriteBatch.SpriteBatchName.Walls);
            PCSTree wallPcsTree = new PCSTree();
            this.wallFactory = new WallFactory(wallPcsTree,wallBatch);


            SpriteBatch ufoBatch = SpriteBatchManager.add(SpriteBatch.SpriteBatchName.UFOs);
            PCSTree ufoPcsTree = new PCSTree();
            this.ufoFactory = new UFOFactory(ufoPcsTree, ufoBatch);

            sndEngine = new IrrKlang.ISoundEngine();
        }
        public static void createMInstance()
        {
            if (facMInstance == null)
            {
                facMInstance = new FactoryManager();
            }
            Debug.Assert(facMInstance != null);
        }
        public static FactoryManager getSingleton()
        {       
            Debug.Assert(facMInstance != null);
            return facMInstance;
        }

        public static AlienFactory getAlienFactry()
        {
            return facMInstance.alienFactory;
        }
        public static BombFactory getBombFactry()
        {
            return facMInstance.bombFactory;
        }
        public static MissileFactory getMissileFactry()
        {
            return facMInstance.missileFactory;

        }
        public static ShieldFactory getShieldFactry()
        {
            return facMInstance.shieldFactory;
        }
        public static ShipFactory getShipFactry()
        {
            return facMInstance.shipFactory;
        }
        public static WallFactory getWallFactry()
        {
            return facMInstance.wallFactory;
        }
        public static UFOFactory getUfoFactry()
        {
            return facMInstance.ufoFactory;
        }
        public static IrrKlang.ISoundEngine getSoundEngine()
        {
            return facMInstance.sndEngine;
        }
    }
}
