using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class SLink
    {
        public SLink pSNext;

        protected SLink()
        {
            this.pSNext = null;
        }

        public static void addToFront(ref SLink mList,SLink sTargetNode)
        {
            Debug.Assert(sTargetNode != null);

            if(mList ==null)
            {
                mList = sTargetNode;
                sTargetNode.pSNext = null;
            }
            else
            {
                sTargetNode.pSNext = mList;
                mList = sTargetNode;
            }

            Debug.Assert(mList != null);
        }
    }
}
