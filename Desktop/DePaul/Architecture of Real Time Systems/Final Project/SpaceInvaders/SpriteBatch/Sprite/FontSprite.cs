using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class FontSprite : SpriteBase
    {
        private String text;
        public Font.FontName fontName;
        private Azul.Sprite azulSprite;
        private Azul.Rect screenRect;
        private Azul.Color fontColor; 
        public Glyph.Name glyphName;
        public float x;
        public float y;

        override public Enum getSpriteName()
        {
            return this.glyphName;
        }

        public FontSprite(): base()
        {
           this.azulSprite = new Azul.Sprite();
            this.screenRect = new Azul.Rect();
            this.fontColor = new Azul.Color(1,0,0);

            this.text = null;
            this.glyphName = Glyph.Name.Uninitialized;

            this.x = 0.0f;
            this.y = 0.0f;
        }

        public void set(Font.FontName name, String text, Glyph.Name glyphName, float xStart, float yStart, Azul.Color color)
        {
            Debug.Assert(text != null);
            this.text = text;
            this.x = xStart;
            this.y = yStart;
            this.fontName = name;
            this.glyphName = glyphName;
            Debug.Assert(color != null);
            this.fontColor.Set(color);
        }

        public void SetColor(float red, float green, float blue, float alpha = 1.0f)
        {
            Debug.Assert(this.fontColor != null);
            this.fontColor.Set(red, green, blue, alpha);
        }

        public void updateText(String text)
        {
            Debug.Assert(text != null);
            this.text = text;
        }

        override public void update()
        {
            Debug.Assert(this.azulSprite != null);

        }

        override public void render()
        {
            Debug.Assert(this.azulSprite != null);
            Debug.Assert(this.fontColor != null);
            Debug.Assert(this.screenRect != null);
            Debug.Assert(this.text != null);
            Debug.Assert(this.text.Length > 0);

            float xTmp = this.x;
            float yTmp = this.y;

            float xEnd = this.x;

            for (int i = 0; i < this.text.Length; i++)
            {
                int key = Convert.ToByte(text[i]);
                Glyph pGlyph = GlyphManager.Find(this.glyphName, key);
                Debug.Assert(pGlyph != null);
                xTmp = xEnd + pGlyph.glyphRect.width / 2;
                this.screenRect.Set(xTmp, yTmp, pGlyph.glyphRect.width, pGlyph.glyphRect.height);
                azulSprite.Swap(pGlyph.glyphTex.getAzulTexture(), pGlyph.glyphRect, this.screenRect, this.fontColor);
                azulSprite.Update();
                azulSprite.Render();
                xEnd = pGlyph.glyphRect.width / 2 + xTmp;
            }
        }


        protected override void nodeStatistics()
        {
            throw new NotImplementedException();
        }

    }
}