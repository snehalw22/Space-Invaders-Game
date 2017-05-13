using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MissileFactory
    { 
    PCSTree cPCSTree;
    SpriteBatch cSpriteBatch;
    private PCSNode cParent;

    public MissileFactory(PCSTree mPCSTree, SpriteBatch mSpriteBatch)
    {
        this.cPCSTree = mPCSTree;
         // this.cSpriteBatch = SpriteBatchManager.find(mSpriteBatch);
        this.cSpriteBatch = mSpriteBatch;
    }
    public void setParent(PCSNode parentNode)
    {
        this.cParent = parentNode;
        Debug.Assert(this.cParent != null);
    }
    public Missile createMissile(Missile.MissileType mMissileType, GameObject.GameObjectName gameName, int index = 0, float mX = 0.0f, float mY = 0.0f)
    {
        Missile missile = null;
        switch (mMissileType)
        {
            case Missile.MissileType.MissileRoot:
                 missile = new MissileRoot(gameName, Sprite.SpriteName.NullObject, index, mX, mY, Missile.MissileType.MissileRoot);
                 GameObjectNodeManager.add(missile, cPCSTree);
                 break;
            case Missile.MissileType.StraightMissile:
                missile = new StraightMissile(gameName, Sprite.SpriteName.StraightMissile, index, mX, mY, Missile.MissileType.StraightMissile);
                break;
                case Missile.MissileType.Uninitilized:
                Debug.WriteLine("Missile Type is Uninitilized");
                break;
        }

            this.cPCSTree.Insert(missile, this.cParent);
            //  cSpriteBatch.addToBatch(missile.getProxySprite());
            // cSpriteBatch.addToBatch(missile.getCollisionObj().cSpriteBox);
            missile.addSpriteToBatch(this.cSpriteBatch);
            missile.addCollisionToBatch(SpriteBatchManager.find(SpriteBatch.SpriteBatchName.Boxes));
            return missile;
    }
}
}
