using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class FontManager : Manager
    {
        private static FontManager fontMInstance = null;
        private static Font cFontRef = new Font();

        private FontManager(int deltaRefillCount = 3, int prefillCount = 5)
                : base(deltaRefillCount, prefillCount)
        {
        }

        public static void createMInstance(int deltaRefillCount = 3, int prefillCount = 5)
        {

            Debug.WriteLine("Creating Font Manager instance");

            Debug.Assert(deltaRefillCount > 0);
            Debug.Assert(prefillCount > 0);
            if (fontMInstance == null)
            {
                fontMInstance = new FontManager(deltaRefillCount, prefillCount);
            }

            Debug.Assert(fontMInstance != null);
        }

        public static Font add(Font.FontName fontName, SpriteBatch.SpriteBatchName sbName, String text, Glyph.Name glyphName, float xStart, float yStart,Azul.Color color)
        {
            FontManager fontMInstance = FontManager.getSingletonInstance();
            Font pNode = (Font)fontMInstance.genericAdd();
            Debug.Assert(pNode != null);
            pNode.set(fontName, text, glyphName, xStart, yStart,color);
            SpriteBatch spriteBatch = SpriteBatchManager.find(sbName);
            Debug.Assert(spriteBatch != null);
            Debug.Assert(pNode.cFontSprite != null);
            spriteBatch.addToBatch(pNode.cFontSprite);
            return pNode;
        }

        public static void remove(Font targetNode)
        {
            FontManager fontMInstance = FontManager.getSingletonInstance();
            Debug.Assert(fontMInstance != null);

            Debug.Assert(targetNode != null);
            fontMInstance.genericRemove(targetNode);

        }
        public static Font find(Font.FontName fontName)
        {
            FontManager fontMInstance = FontManager.getSingletonInstance();
            Debug.Assert(fontMInstance != null);
            Font pseudoFont = cFontRef;
            Debug.Assert(pseudoFont != null);

            pseudoFont.fontName = fontName;

            Font targetFont = (Font)fontMInstance.genericFind(pseudoFont);
            return targetFont;
        }

        protected override bool compareConcreteNode(ref MLink targetNode, ref MLink currNode)
        {
            Debug.Assert(targetNode != null);
            Debug.Assert(currNode != null);

            bool result = false;
            Font targetFont = (Font)targetNode;
            Font currFont = (Font)currNode;

            if (targetFont.fontName.Equals(currFont.fontName))
            {
                result = true;
            }
            return result;
        }
        protected override MLink createConcreteNode()
        {
            Font font = new Font();
            Debug.Assert(font != null);
            return font;
        }

        private static FontManager getSingletonInstance()
        {
            Debug.Assert(fontMInstance != null);
            return fontMInstance;
        }

        protected override void printStats(ref MLink targetNode)
        {
            FontManager texManInst = FontManager.getSingletonInstance();
            Debug.Assert(texManInst != null);

            Debug.WriteLine("");
            Debug.WriteLine("------ Active List: ---------------------------\n");

            MLink pNode = texManInst.activeList;

            int i = 0;
            while (pNode != null)
            {
                Debug.WriteLine("{0}: -------------", i);
                pNode.print();
                i++;
                pNode = pNode.pNext;
            }

            Debug.WriteLine("");
            Debug.WriteLine("------ Reserve List: ---------------------------\n");

            pNode = texManInst.reserveList;
            i = 0;
            while (pNode != null)
            {
                Debug.WriteLine("{0}: -------------", i);
                pNode.print();
                i++;
                pNode = pNode.pNext;
            }
        }
    }
}
