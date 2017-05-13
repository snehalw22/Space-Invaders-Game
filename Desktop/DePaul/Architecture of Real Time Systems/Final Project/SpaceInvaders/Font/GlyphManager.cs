using System;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace SpaceInvaders
{
    class GlyphManager : Manager
    {
        private static GlyphManager glyphMInst = null;
        private Glyph refGlyph;
        private GlyphManager(int reserveNum = 3, int reserveGrow = 1)
            : base(reserveNum, reserveGrow)
        {
            this.refGlyph = new Glyph();
        }

        public static void Create(int deltaRefillCount = 3, int prefillCount = 5)
        {
            Debug.WriteLine("Creating Tex Manager instance");

            Debug.Assert(deltaRefillCount > 0);
            Debug.Assert(prefillCount > 0);
            if (glyphMInst == null)
            {
                glyphMInst = new GlyphManager(deltaRefillCount, prefillCount);
            }

            Debug.Assert(glyphMInst != null);
        }

        public static Glyph Add(Glyph.Name name, int key, Texture.TextureName textName, float x, float y, float width, float height)
        {
            GlyphManager pMan = GlyphManager.getSingleton();

            Glyph pNode = (Glyph)pMan.genericAdd();
            Debug.Assert(pNode != null);

            pNode.setAll(name, key, textName, x, y, width, height);
            return pNode;
        }
        //Converts the character in XML to class Character
        public static void addXml(Glyph.Name glyphName, String assetName, Texture.TextureName textName)
        {
            Character c;
            XmlSerializer serializer = new XmlSerializer(typeof(Character));
            XmlTextReader file = new XmlTextReader(assetName);
            while (file.Read())
            {
                if (file.GetAttribute("key") != null)
                {
                    c = (Character)serializer.Deserialize(file);
                    GlyphManager.Add(glyphName, c.key, textName, c.x, c.y, c.width, c.height);
                }
            }
        }
        public static void Remove(Glyph pNode)
        {
            Debug.Assert(pNode != null);
            GlyphManager pMan = GlyphManager.getSingleton();
            pMan.genericRemove(pNode);
        }
        public static Glyph Find(Glyph.Name name, int key)
        {
            GlyphManager texManInst = GlyphManager.getSingleton();
            Debug.Assert(texManInst != null);
            Glyph pseudoTex = texManInst.refGlyph;
            Debug.Assert(pseudoTex != null);

            pseudoTex.glyphName= name;
            pseudoTex.key = key;

            Glyph targetTex = (Glyph)texManInst.genericFind(pseudoTex);
            return targetTex;
        }

        private static GlyphManager getSingleton()
        {
            Debug.Assert(glyphMInst != null);
            return glyphMInst;
        }

        protected override bool compareConcreteNode(ref MLink targetNode, ref MLink currNode)
        {
            Debug.Assert(targetNode != null);
            Debug.Assert(currNode != null);

            Glyph tarGlymph = (Glyph)targetNode;
            Glyph currGlymph = (Glyph)currNode;
            Boolean status = false;

            if (tarGlymph.glyphName == currGlymph.glyphName && tarGlymph.key == currGlymph.key)
            {
                status = true;
            }
            return status;
        }

        protected override void printStats(ref MLink targetNode)
        {
            throw new NotImplementedException();
        }

        protected override MLink createConcreteNode()
        {
            MLink pNode = new Glyph();
            Debug.Assert(pNode != null);
            return pNode;
        }
    }
}
