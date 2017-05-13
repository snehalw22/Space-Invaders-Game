using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipRemove : Command
    {
        private GameObject gameObject;

        public ShipRemove()
        {
        }
        public ShipRemove(GameObject mGameObject)
        {
            Debug.Assert(mGameObject != null);
            this.gameObject = mGameObject;
        }

        public override void execute(float deltaTime)
        {
            Debug.WriteLine("Inside Game Object Remove");
            // gameObject.remove();
            gameObject.removeFromSpriteBatch();
        }
    }
}
