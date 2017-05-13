using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class WallFactory
    { 
     PCSTree cPCSTree;
    SpriteBatch cSpriteBatch;
    private PCSNode cParent;
    public WallFactory(PCSTree mPCSTree, SpriteBatch mSpriteBatch)
    {
        this.cPCSTree = mPCSTree;
        // this.cSpriteBatch = SpriteBatchManager.find(mSpriteBatch);
        this.cSpriteBatch = mSpriteBatch;
        cParent = null;
    }
    public void setParent(PCSNode parentNode)
    {
        this.cParent = parentNode;
        //  Debug.Assert(this.cParent != null);
    }
    public Wall createWall(Wall.WallType mWallType, GameObject.GameObjectName gameName, int index = 0, float x = 0.0f, float y = 0.0f, float width = 0.0f, float height = 0.0f)
    {
        Wall wall = null;
        switch (mWallType)
        {
            case Wall.WallType.WallTop:
                    wall = new WallTop(gameName, index,Sprite.SpriteName.NullObject, x, y, width, height,Wall.WallType.WallTop);
                break;
            case Wall.WallType.WallDown:
                    wall = new WallDown(gameName, index,Sprite.SpriteName.NullObject, x, y, width, height, Wall.WallType.WallDown);
                break;
            case Wall.WallType.WallLeft:
                    wall = new WallLeft(gameName, index,Sprite.SpriteName.NullObject, x, y, width, height, Wall.WallType.WallLeft);
                break;
            case Wall.WallType.WallRight:
                    wall = new WallRight(gameName, index,Sprite.SpriteName.NullObject, x, y, width, height, Wall.WallType.WallRight);
                break;
            case Wall.WallType.WallRoot:
                 wall = new WallRoot(gameName, index,Sprite.SpriteName.NullObject, Wall.WallType.WallRoot);
                GameObjectNodeManager.add(wall, cPCSTree);
                break;
            case Wall.WallType.Uninitilized:
                Debug.WriteLine("Wall Type is Uninitilized");
                break;
        }

            this.cPCSTree.Insert(wall, this.cParent);

            wall.addSpriteToBatch(this.cSpriteBatch);
            wall.addCollisionToBatch(SpriteBatchManager.find(SpriteBatch.SpriteBatchName.Boxes));
        return wall;
    }
}
}

