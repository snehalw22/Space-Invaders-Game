using System;
using System.Diagnostics;
namespace SpaceInvaders
{
    class AlienExplode : Alien
    {

        public AlienExplode(GameObject.GameObjectName mGameObjectName, Sprite.SpriteName mSpriteName, int index, float mX, float mY) : base(mGameObjectName, index, mSpriteName)
        {
            this.x = mX;
            this.y = mY;
            //this.cCollisionObj.cSpriteBox.setColor(Unit.spriteBoxColor);
        }

        public override void Accept(CollisionVisitor other)
        {
            throw new NotImplementedException();
        }

        public override void update()
        {
           base.update();

        }

    
    }
}