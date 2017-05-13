using System;
using System.Diagnostics;

namespace SpaceInvaders
{
   class Ghost : MLink
    {

        public GameObject cObject;

        public Ghost() : base()
        {
           // this.cObject = null;
            cObject = new NullGameObject();
        }

        public void set(GameObject mObj)
        {
            Debug.Assert(mObj != null);
            this.cObject = mObj;
        }
        public void wash()
        {
            this.cObject = null;
        }
        public Enum getName()
        {
            return this.cObject.cGameObjectName;
        }
        protected override void nodeStatistics()
        {
            Debug.WriteLine("------Node Stats-----");
            Debug.WriteLine("Object Hashcode: {0} ", this.GetHashCode());
            Debug.WriteLine("Name: {0} ", this.cObject.cGameObjectName);
        }
    }
}
