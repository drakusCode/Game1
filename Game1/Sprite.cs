using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    //contolling fonts tint of textures..
    //alphabets in diff picsels "cells"
    public class Sprite
    {   
        protected Vector2 position;
        public Vector2 Position{
           get{
                return position;
            }               
        }
        protected Texture2D texture;
        public Texture2D Texture{
             get{
                return texture;
                }
        }
        private bool isPlayerControlled;/*we dnt want to be moving all images on the game..*/
        public bool IsPlayerControlled{
           get{
            return isPlayerControlled;
            }
        }
        protected Color tint;
        public Color Tint{
          get{
                return tint;
          }
            /*set
            {
                tint = value;
            }*/
        }
        public void SetTint(Color pTint)
        {
            tint = pTint;
        }
        public Sprite(Texture2D pTexture, Vector2 pPosition,Color pTint, bool pIsPlayerControlled)
        {
            position = pPosition ;
            texture = pTexture;
            tint=pTint;
            isPlayerControlled = pIsPlayerControlled;
        }

        public void Update(GameTime pGameTime) {
            //KeyboardState state = Keyboard.GetState();
            if (IsPlayerControlled) {

                //if (state.IsKeyDown(Keys.Right))
                if (Game1.Instance.InputManager.Pressed(Input.Right)) {
                    this.position.X += 10 * pGameTime.ElapsedGameTime.Milliseconds / 100f;
                }
                if (Game1.Instance.InputManager.Pressed(Input.Left)) {
                    this.position.X -= 10 * pGameTime.ElapsedGameTime.Milliseconds / 100f;
                }
                if (Game1.Instance.InputManager.Pressed(Input.Up)) {
                    this.position.Y -= 10 * pGameTime.ElapsedGameTime.Milliseconds / 100f;
                }
                if (Game1.Instance.InputManager.Pressed(Input.Down)) {
                    this.position.Y += 10 * pGameTime.ElapsedGameTime.Milliseconds / 100f;
                }
            }
        }

        public void Draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(texture,position,tint);//tint->certan Colore
        }
    }
}
