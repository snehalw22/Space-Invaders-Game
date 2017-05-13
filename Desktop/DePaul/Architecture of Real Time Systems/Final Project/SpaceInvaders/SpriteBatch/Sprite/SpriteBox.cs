using System;
using System.Diagnostics;

namespace SpaceInvaders
{
   
    public class SpriteBox : SpriteBase
    {
        public enum SpriteBoxName
        {
            Box,
            Uninitilized
        }
        public SpriteBoxName cSpriteBoxName;
        public Azul.Rect cSpriteBoxRect;
        public Azul.Color cSpriteBoxColor;
        public Azul.SpriteBox azulSpriteBox;

        public float x;
        public float y;
        public float sx;
        public float sy;
        public float angle;
        // default ...
        private static Azul.Rect cDefScreenRect = new Azul.Rect(0, 0, 1, 1);
        public static Azul.Color cDefColor = new Azul.Color(0,0,0);
        public SpriteBox()
        {
            this.cSpriteBoxName = SpriteBox.SpriteBoxName.Uninitilized;
            this.cSpriteBoxRect = new Azul.Rect(cDefScreenRect);
            this.cSpriteBoxColor = new Azul.Color();
           // this.cSpriteBoxColor = cDefColor;

            Debug.Assert(this.cSpriteBoxColor != null);

             this.azulSpriteBox = new Azul.SpriteBox(this.cSpriteBoxRect, this.cSpriteBoxColor);
             Debug.Assert(this.azulSpriteBox != null);

            this.x = azulSpriteBox.x;
            this.y = azulSpriteBox.y;
            this.sx = azulSpriteBox.sx;
            this.sy = azulSpriteBox.sy;
            this.angle = azulSpriteBox.angle;
        }

        public SpriteBox(SpriteBoxName spriteBoxName,Azul.Rect spriteBoxRect)
        {
            setAll(spriteBoxName, spriteBoxRect);
        }

        //set all method

        public void setAll(SpriteBoxName spriteBoxName, Azul.Rect spriteBoxRect)
        {
            this.cSpriteBoxName = spriteBoxName;
            this.cSpriteBoxRect = spriteBoxRect;
            //    this.cSpriteBoxColor = cDefColor;
            this.cSpriteBoxColor.Set(cDefColor.red, cDefColor.green, cDefColor.blue);
            this.azulSpriteBox.Swap(spriteBoxRect,this.cSpriteBoxColor);

            this.x = azulSpriteBox.x;
            this.y = azulSpriteBox.y;
            this.sx = azulSpriteBox.sx;
            this.sy = azulSpriteBox.sy;
            this.angle = azulSpriteBox.angle;
            //this.azulSpriteBox = new Azul.SpriteBox(spriteBoxRect, spriteBoxColor);

        }
        public override void  update()
        {
            this.azulSpriteBox.x = this.x;
            this.azulSpriteBox.y = this.y;
            this.azulSpriteBox.sx = this.sx;
            this.azulSpriteBox.sy = this.sy;
            this.azulSpriteBox.angle = this.angle;

            this.azulSpriteBox.Update();
        }
        public void Set(SpriteBox.SpriteBoxName boxName, float x, float y, float width, float height)
        {
            Debug.Assert(cDefScreenRect != null);
            //Debug.Assert(cDefColor != null);
            Debug.Assert(this.azulSpriteBox != null);
            Debug.Assert(this.cSpriteBoxRect != null);

            this.cSpriteBoxName = boxName;

            // this.cSpriteBoxColor.Set(cDefColor);
         //   this.cSpriteBoxColor.Set(cDefColor.red, cDefColor.green, cDefColor.blue);
            this.cSpriteBoxRect.Set(x, y, width, height);

            this.azulSpriteBox.Swap(this.cSpriteBoxRect, this.cSpriteBoxColor);
         
            Debug.Assert(this.azulSpriteBox != null);

            this.x = azulSpriteBox.x;
            this.y = azulSpriteBox.y;
            this.sx = azulSpriteBox.sx;
            this.sy = azulSpriteBox.sy;
            this.angle = azulSpriteBox.angle;
        }
        public void setSpriteBoxRect(float x, float y, float width, float height)
        {
            this.Set(this.cSpriteBoxName,x, y, width, height);
        }
     
        public override void render()
        {
            this.azulSpriteBox.Render();
        }
        public void wash()
        {
            this.cSpriteBoxName = SpriteBox.SpriteBoxName.Uninitilized;
            // this.cSpriteBoxColor = new Azul.Color(cDefColor);
          //  this.cSpriteBoxColor = cDefColor ;
            Debug.Assert(this.cSpriteBoxColor != null);

           // this.azulSpriteBox.Swap(cDefScreenRect, cDefColor);
            Debug.Assert(this.azulSpriteBox != null);

            this.x = azulSpriteBox.x;
            this.y = azulSpriteBox.y;
            this.sx = azulSpriteBox.sx;
            this.sy = azulSpriteBox.sy;
            this.angle = azulSpriteBox.angle;

        }

        protected override void nodeStatistics()
        {
            throw new NotImplementedException();
        }

        public override Enum getSpriteName()
        {
            return cSpriteBoxName;
        }
  
        public void setColor(float red, float green, float blue, float alpha = 1.0f)
        {
            this.cSpriteBoxColor.Set(red, green, blue, alpha);
            this.azulSpriteBox.SwapColor(cSpriteBoxColor);

        }
        public void setColor(Azul.Color color)
        {
            this.cSpriteBoxColor.Set(color);
            this.azulSpriteBox.SwapColor(color);
        }
    }
}
