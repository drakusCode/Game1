using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*a sprite that contains many sprites*/
namespace Game1
{/*to be able to draw a certain frame (cell(x,y)) of the texture*/
   public class FramedSprite :Sprite {
        private int framesX;
        private int framesY;
        private int borderSize;

        private Size frameSize;/*all frames in our texture have same size*/
        private int currentFrame;//the cell(frame) we are in
        
        //int pFramesX,int pFramesY,int pBorderSize aded to normal sprite
        public FramedSprite(int pFramesX,int pFramesY,int pBorderSize, Texture2D pTexture,Vector2 pPosition,Color pTint,bool pIsPlayerControlled) :base(pTexture,pPosition,pTint,pIsPlayerControlled) {
            currentFrame = 0;/*useful for animation*/
            framesX = pFramesX;
            framesY = pFramesY;
            borderSize = pBorderSize;
           
        }  
        public void SetCurrentFrame(int pFrame)
        {
            currentFrame = pFrame;
        }
    }
}
