using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class MLink
    {
        public MLink pNext;
        public MLink pPrev;

        protected MLink()
        {
            this.wash();
        }

        // clear the object instances

        public void wash()
        {
            this.pNext = null;
            this.pPrev = null;
        }

        // This will add a node to the front of any list

        public static void addToFront(MLink linkNode,ref MLink list )
        {
            Debug.Assert(linkNode != null);

            if (list == null)
            {
                list = linkNode;
                linkNode.pNext = null;
                linkNode.pNext = null;
            }
            else
            {
                linkNode.pPrev = null;
                linkNode.pNext = list;

                list.pPrev = linkNode;
                list = linkNode;
            }
        
        }
        // remove the head node of the list
        public static MLink removeFromFront(ref MLink listHead)
        {
            Debug.Assert(listHead != null);

            MLink linkNode = listHead;

            listHead = listHead.pNext;

            if (listHead!= null)
            {
                listHead.pPrev = null;
            }

            linkNode.wash();

            return linkNode;
        }

        // remove the node from the given list
        public static void removeNode(MLink dataNode, ref MLink list)
        {
            Debug.Assert(dataNode != null);
            //if data node position is at head
            if (dataNode.pPrev == null)
            {
                if (dataNode.pNext == null)
                    list = null;
                else
                dataNode.pNext.pPrev = null;
                list = dataNode.pNext;
                dataNode.pNext = null;
            }
            //if data node position is last
            else if (dataNode.pNext == null)
            {
                dataNode.pPrev.pNext = null;
                dataNode.pPrev = null;
            }
            // if data node position is in between
            else
            {
                dataNode.pPrev.pNext = dataNode.pNext;
                dataNode.pNext.pPrev = dataNode.pPrev;

                dataNode.pPrev = null;
                dataNode.pNext = null;
            }

        }
        public void print()
        {
            nodeStatistics();
        }
        protected abstract void nodeStatistics();
    }
}
