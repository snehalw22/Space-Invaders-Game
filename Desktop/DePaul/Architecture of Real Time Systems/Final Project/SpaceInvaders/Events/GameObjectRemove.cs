using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GameObjectRemove : Command
    {
        private GameObject gameObject;

        public GameObjectRemove()
        {
        }
        public GameObjectRemove(GameObject mGameObject)
        {
            Debug.Assert(mGameObject != null);
            this.gameObject = mGameObject;
        }

        public override void execute(float deltaTime)
        {
            Debug.WriteLine("Inside Game Object Remove");
            gameObject.remove();          
        }
    }
}
