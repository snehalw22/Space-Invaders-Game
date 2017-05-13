using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Glyph : MLink
    {
        public Name glyphName;
        public int key;
        public Azul.Rect glyphRect;
        public Texture glyphTex;
        public enum Name
        {
            Consolas36pt,
            NullObject,
            Uninitialized
        }

        public Glyph(): base()
        {
            this.glyphName = Name.Uninitialized;
            this.glyphTex = null;
            this.glyphRect = new Azul.Rect();
            this.key = 0;
        }

        public void setAll(Glyph.Name name, int key, Texture.TextureName textName, float x, float y, float width, float height)
        {
            Debug.Assert(this.glyphRect != null);
            this.glyphName = name;

            this.glyphTex = TextureManager.find(textName);
            Debug.Assert(this.glyphTex != null);

            this.glyphRect.Set(x, y, width, height);

            this.key = key;

        }

        protected override void nodeStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
