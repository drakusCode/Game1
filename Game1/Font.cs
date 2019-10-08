using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Font {
        private FramedSprite sprite;
        public FramedSprite Sprite {/*having more control over"tint.."*/
            get {
                return sprite;
            }
        }
        private Size spacing;/*if u need spacing between letters..*/
        private Dictionary<int,int> mapping;

        /*load all this things*/
        public Font(FramedSprite pSprite,Dictionary<int,int> pMapping,int pHorizontalSpace,int pVerticalSpace,Color pFontColor){
            sprite = pSprite;
            sprite.SetCurrentFrame(0);
            sprite.SetTint(pFontColor);

            mapping = pMapping;

            spacing = new Size { Width = pHorizontalSpace, Height = pVerticalSpace };
        }
    }
}
