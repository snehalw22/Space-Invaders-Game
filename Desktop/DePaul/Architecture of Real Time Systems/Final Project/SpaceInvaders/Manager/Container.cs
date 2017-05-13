using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Container
    { 
     public MLink activeList;
     public MLink reserveList;

    private int mNumActiveNodes;
    private int mNumReserveNodes;
    private int mTotalNodes;
    private int deltaRefillCount;
       
    protected Container(int deltaRefillCount = 1, int prefillCount = 1)
    {
        Debug.Assert(deltaRefillCount > 0);
        Debug.Assert(prefillCount > 0);

        this.activeList = null;
        this.reserveList = null;

        this.mNumActiveNodes = 0;
        this.mNumReserveNodes = 0;
        this.mTotalNodes = 0;
        this.deltaRefillCount = deltaRefillCount;

        // prefill the nodes in the reserve list
        fillReserve(prefillCount);

    }

    //abstarct methods
    protected abstract MLink createDerivedClassNode();
    protected abstract bool compareDerivedNode(ref MLink targetNode, ref MLink currNode);

    // prefill the 
    protected void fillReserve(int fillCount)
    {
        Debug.Assert(fillCount > 0);
        // create the Data Node of the Derieved class and add it to reserve list at front
        for (int i = 0; i < fillCount; i++)
        {
            MLink dataNode = this.createDerivedClassNode();

            Debug.Assert(dataNode != null);
            MLink.addToFront(dataNode, ref reserveList);
            mNumReserveNodes++;
            mTotalNodes++;
        }

    }

    // Removes a node from reserve and add it to active
    protected MLink genericAdd()
    {
        //Check if the reserve list is empty, If yes, refill

        if (reserveList == null)
        {
            fillReserve(deltaRefillCount);
        }
        // remove from front of reserve list
        MLink dNode = MLink.removeFromFront(ref reserveList);
        Debug.Assert(dNode != null);

        // add it to the front of active list
        MLink.addToFront(dNode, ref activeList);

        mNumReserveNodes--;
        mNumActiveNodes++;

        return dNode;

    }
    // remove a node from active and add it to reserve
    protected void genericRemove(MLink dataNode)
    {
        Debug.Assert(dataNode != null);

        // remove from active
        MLink.removeNode(dataNode, ref this.activeList);

        //wash the data node
        dataNode.wash();

        //add it to reserve list
       MLink.addToFront(dataNode, ref this.reserveList);
        mNumActiveNodes--;
        mNumReserveNodes++;
    }

    // find the node in active list
    protected MLink genericFind(MLink targetNode)
    {
        Debug.Assert(targetNode != null);
        MLink currNode = this.activeList;

        while (currNode != null)
        {
            bool result = this.compareDerivedNode(ref targetNode, ref currNode);
            if (result)
            {
                break;
            }
            else
            {
                currNode = currNode.pNext;
            }
        }
        return currNode;
    }
        // Initially the Refill count and Prefill count is initilized by default during the Node Add
        //This methood is used when setting the reserve and Delta grow 
        // IF the number of nodes in the reserve are less , refill with the differenece
        protected void baseManageReserve(int deltaRefillCount, int prefillCount)
        {
            this.deltaRefillCount = deltaRefillCount;
            
            if(this.mNumReserveNodes<prefillCount)
            {
                this.fillReserve(prefillCount - mNumReserveNodes);
            }
        }
        abstract protected void derivedDumpNode(MLink pLink);
        protected void baseDumpNodes()
        {
            Debug.WriteLine("");
            Debug.WriteLine("      ------ Active List: ---------------------------\n");

            MLink pNode = this.activeList;

            int i = 0;
            while (pNode != null)
            {
                Debug.WriteLine("      {0}: -------------", i);
                this.derivedDumpNode(pNode);
                i++;
                pNode = pNode.pNext;
            }

            Debug.WriteLine("");
            Debug.WriteLine("      ------ Reserve List: ---------------------------\n");

            pNode = this.reserveList;
            i = 0;
            while (pNode != null)
            {
                Debug.WriteLine("      {0}: -------------", i);
                this.derivedDumpNode(pNode);
                i++;
                pNode = pNode.pNext;
            }
        }
    }
}


