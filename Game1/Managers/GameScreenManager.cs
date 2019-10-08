using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Game1 {
    public class GameScreenManager {

        private Stack<Gamescreen> gamescreens;
        public Stack<Gamescreen> Gamescreens {
            get {
                return gamescreens;
            }
        }

        public GameScreenManager() {
            //stack:last in first out
            gamescreens = new Stack<Gamescreen>();
         }

        public void Push(Gamescreen pGamescreen) {

            gamescreens.Push(pGamescreen);
         }

        public void Update(GameTime pGameTime) {
            bool gamescreenPopped = false;
            do {
                gamescreenPopped = false;
                //if there are no gamescreens in the stack quit
                if (gamescreens.Count == 0) {
                    Game1.Instance.Exit();
                    return;//quiting out of the game complitly
                }
                //look at the first gamescreen on the stack
                var gs = gamescreens.Peek();

                //initialize if not initialized
                if (gs.Initialized == false) {
                    gs.Initialize();
                    //after initialization comes :load content
                    gs.LoadContent(Game1.Instance.ContentManager);
                }
                //update it
                gs.Update(pGameTime);

                //if quit, then pop it and do ..while again 
                if (gs.Quit) {
                    gamescreens.Pop();
                    gamescreenPopped = true;
                }
            } while (gamescreenPopped);
            
        }
        public void Draw(SpriteBatch pSpriteBatch) {
            gamescreens.Peek().Draw(pSpriteBatch);//Peek-->look at the top of the strack (LIFO)
        }
    }
}
