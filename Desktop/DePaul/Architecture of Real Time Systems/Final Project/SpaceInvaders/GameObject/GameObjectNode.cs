using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameObjectNode : MLink
    {
        private GameObject rcGameObject;
        private PCSTree cTree;
        public GameObjectNode() : base()
        {
            this.rcGameObject = null;
        }

        public GameObject getGameObject()
        {
            return rcGameObject;
        }
        public void setGameObject(GameObject mGameObject)
        {
            this.rcGameObject = mGameObject;
        }

        public void setAll(GameObject mGameObject)
        {
            this.rcGameObject = mGameObject;
        }
        public PCSTree getPCSTree()
        {
            return cTree;
        }
      

        protected override void nodeStatistics()
        {
            Debug.Assert(this.rcGameObject != null);
            Debug.WriteLine("Hash : {0}", this.GetHashCode());

            this.rcGameObject.nodeStatistics();
        }
        public void set(GameObject pGameObject, PCSTree pTree)
        {
            Debug.Assert(pGameObject != null);
            this.rcGameObject = pGameObject;

            Debug.Assert(pTree != null);
            this.cTree = pTree;
        }

        public void removeNode(GameObject gameObj)
        {
            cTree.Remove(gameObj);
        }
    }
}
