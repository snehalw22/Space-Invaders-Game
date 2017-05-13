using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class UFOFactory
    {
        public PCSTree cPCSTree;
        SpriteBatch cSpriteBatch;
        public PCSNode cParent;

        public UFOFactory(PCSTree mPCSTree, SpriteBatch mSpriteBatch)
        {
            this.cPCSTree = mPCSTree;
            this.cSpriteBatch = mSpriteBatch;
        }
        public void setParent(PCSNode parentNode)
        {
            this.cParent = parentNode;
            Debug.Assert(this.cParent != null);
        }
        public UFO createUFO(UFO.UFOType mUfoType, GameObject.GameObjectName gameName, int index = 0, float mX = 0.0f, float mY = 0.0f)
        {
            UFO ufo = null;
            switch (mUfoType)
            {
                case UFO.UFOType.UFORoot:
                    ufo = new UFORoot(gameName, Sprite.SpriteName.NullObject, index, mX, mY, UFO.UFOType.UFORoot);
                    GameObjectNodeManager.add(ufo, cPCSTree);
                    break;
                case UFO.UFOType.AlienUFO:
                    ufo = new AlienUFO(gameName, Sprite.SpriteName.AlienUFO, index, mX, mY, UFO.UFOType.AlienUFO);
                    break;

                case UFO.UFOType.Uninitilized:
                    Debug.WriteLine("ufo Type is Uninitilized");
                    break;
            }

            this.cPCSTree.Insert(ufo, this.cParent);
            ufo.addSpriteToBatch(this.cSpriteBatch);
            ufo.addCollisionToBatch(SpriteBatchManager.find(SpriteBatch.SpriteBatchName.Boxes));
            return ufo;
        }
    }
}
