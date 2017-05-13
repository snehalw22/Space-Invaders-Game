using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class NullGameObject : GameObject
    {
        public NullGameObject() : base(GameObject.GameObjectName.NullObject,0,Sprite.SpriteName.NullObject)
        {
        }

        public override void Accept(CollisionVisitor other)
        {
            other.visitNullGameObject(this);
        }

        public override void update()
        {
            
        }

    }
}
