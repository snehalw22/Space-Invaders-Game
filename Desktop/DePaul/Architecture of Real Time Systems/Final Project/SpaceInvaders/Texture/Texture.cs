using System;
using System.Diagnostics;

namespace SpaceInvaders {
    public class Texture : MLink
    {
        public TextureName textureName;
        public Azul.Texture azulTexture;
        public enum TextureName
        {          
            AlienTex,
            ShieldTex,
            MissileTex,
            BombTex,
            NullObject,
            ZigZagTex,
            FlippingTex,
            Uninitilized,
            StraightTex,
            GITex,
            Consolas36pt
        }

        // Default constructor
        public Texture()
        {
            textureName = TextureName.Uninitilized;
            azulTexture = null;
        }

        // Parameterized constructor

        public Texture(TextureName texureName, string azulTexName)
        {
            Debug.Assert(azulTexName != null);

            setAll(textureName, azulTexName);

        }
        // all setters

        public void setAll(TextureName texureName, string azulTexName)
        {
            this.textureName = texureName;
            this.azulTexture = createAzulTexture(azulTexName);
        }
        //Setters 
        public void setTextureName(TextureName texName)
        {
            this.textureName = texName;
        }

        public void setAzulTexture(Azul.Texture azulTex)
        {
            this.azulTexture = azulTex;
        }
        public Azul.Texture getAzulTexture()
        {
            return azulTexture;
        }
       
        // Clear the Texture
        public void wash()
        {
            textureName = TextureName.Uninitilized;
            azulTexture = null;
        }

        //create a Azul Texture
        public Azul.Texture GetAzulTexture()
        {
            Debug.Assert(this.azulTexture != null);
            return this.azulTexture;
        }
        private Azul.Texture createAzulTexture(string azulTextureName)
        {
            Azul.Texture azulTex = new Azul.Texture(azulTextureName,Azul.Texture_Filter.NEAREST, Azul.Texture_Filter.NEAREST);
            Debug.Assert(azulTex != null);
            return azulTex;
        }
        protected override void nodeStatistics()
        {
            Debug.WriteLine(" {0} ({1})", this.textureName, this.GetHashCode());
        }
    }
}
