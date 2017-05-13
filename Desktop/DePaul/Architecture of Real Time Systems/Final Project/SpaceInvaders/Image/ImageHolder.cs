using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ImageHolder : SLink
    {
        public Image cImage;
        public ImageHolder(Image image) : base()
        {
            this.cImage = image;
        }

    }
}

