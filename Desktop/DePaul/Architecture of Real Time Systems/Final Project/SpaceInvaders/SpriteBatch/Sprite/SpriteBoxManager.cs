using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpriteBoxManager : Manager { 

     private static SpriteBoxManager spriteBoxMInstance = null;
    private SpriteBoxManager(int deltaRefillCount = 3, int prefillCount = 5)
            : base(deltaRefillCount, prefillCount)
        {
    }

    public static void createMInstance(int deltaRefillCount = 3, int prefillCount = 5)
    {
        Debug.WriteLine("Creating Sprite Box Manager instance");
        Debug.Assert(deltaRefillCount > 0);
        Debug.Assert(prefillCount > 0);
        if (spriteBoxMInstance == null)
        {
            spriteBoxMInstance = new SpriteBoxManager(deltaRefillCount, prefillCount);
        }

    }


    public static SpriteBox add(SpriteBox.SpriteBoxName sbName, Azul.Rect sbRect)
    {
            SpriteBoxManager spriteBoxMInstance = SpriteBoxManager.getSingletonInstance();
            Debug.Assert(spriteBoxMInstance != null);

            SpriteBox nodeAdded = (SpriteBox)spriteBoxMInstance.genericAdd();

        Debug.Assert(nodeAdded != null);

        //set the attributes of the SpriteBox node 
        nodeAdded.setAll(sbName, sbRect);

        return nodeAdded;
    }

    public static void remove(ref MLink targetNode)
    {
            SpriteBoxManager spriteBoxMInstance = SpriteBoxManager.getSingletonInstance();
            Debug.Assert(spriteBoxMInstance != null);
            Debug.Assert(targetNode != null);
        spriteBoxMInstance.genericRemove(targetNode);

    }
    public static SpriteBox find(SpriteBox.SpriteBoxName sbName)
    {
            SpriteBoxManager spriteBoxMInstance = SpriteBoxManager.getSingletonInstance();
            Debug.Assert(spriteBoxMInstance != null);

            SpriteBox pseudoSb = new SpriteBox();
        pseudoSb.cSpriteBoxName = sbName;

        Debug.Assert(spriteBoxMInstance != null);

        SpriteBox targetSb = (SpriteBox)spriteBoxMInstance.genericFind(pseudoSb);
        return targetSb;
    }
    protected override bool compareConcreteNode(ref MLink targetNode, ref MLink currNode)
    {
        Debug.Assert(targetNode != null);
        Debug.Assert(currNode != null);

        bool result = false;
        SpriteBox targetSb = (SpriteBox)targetNode;
        SpriteBox currSb = (SpriteBox)currNode;

        if (targetSb.cSpriteBoxName.Equals(currSb.cSpriteBoxName))
        {
            result = true;
        }

        return result;
    }

        // create a SpriteBox MLink node and return
        protected override MLink createConcreteNode()
    {
        SpriteBox spriteBox = new SpriteBox(); // different
        Debug.Assert(spriteBox != null);
        return spriteBox;
    }

    private static SpriteBoxManager getSingletonInstance()
    {
        Debug.Assert(spriteBoxMInstance != null);
        return spriteBoxMInstance;
    }

        protected override void printStats(ref MLink targetNode)
        {
            throw new NotImplementedException();
        }
    }
}
