using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class EndStateLoader
    {
        public void load()
        {
            loadFont();
        }
        public void loadFont()
        {
            TextureManager.add(Texture.TextureName.GITex, "Final_Sprites.tga");
            TextureManager.add(Texture.TextureName.Consolas36pt, "Consolas36pt.tga");
            SpriteBatch pSB_Texts = SpriteBatchManager.add(SpriteBatch.SpriteBatchName.Text);
            GlyphManager.addXml(Glyph.Name.Consolas36pt, "Consolas36pt.xml", Texture.TextureName.Consolas36pt);
            FontManager.add(Font.FontName.GameOver, SpriteBatch.SpriteBatchName.Text, "Game Over!!!!!", Glyph.Name.Consolas36pt, 300, 600, Unit.redColor);
            FontManager.add(Font.FontName.Instruction1, SpriteBatch.SpriteBatchName.Text, "Your Score is "+PlayerManager.getCurrentPlayer().score, Glyph.Name.Consolas36pt, 300,550, Unit.redColor);
        }

    }
}
