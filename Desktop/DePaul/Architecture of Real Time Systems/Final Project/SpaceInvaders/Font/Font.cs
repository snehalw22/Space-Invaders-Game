using System;
using System.Diagnostics;

namespace SpaceInvaders
{
   public class Font : MLink
    {
        public FontName fontName;
        public FontSprite cFontSprite;
        public enum FontName
        {
            Player1,
            Player2,
            Score,
            ScoreNum1,
            NullObject,
            Uninitialized,
            GameOver,
            Instruction1,
            Instruction2,
            ScoreNum2,
            Welcome,
            Points,
            ModeSelection1,
            ModeSelection2,
        };

        public Font(): base()
        {
            this.fontName = FontName.Uninitialized;
            this.cFontSprite = new FontSprite();
        }
        public void updateText(String text)
        {
            Debug.Assert(text != null);
            Debug.Assert(this.cFontSprite != null);
            this.cFontSprite.updateText(text);
        }

        public void set(Font.FontName name, String text, Glyph.Name glyphName, float xStart, float yStart, Azul.Color color)
        {
            Debug.Assert(text != null);
            this.fontName = name;
            this.cFontSprite.set(name, text, glyphName, xStart, yStart,color);
        }

        public void Dump()
        {
        }

        protected override void nodeStatistics()
        {
            throw new NotImplementedException();
        }
    }
}
