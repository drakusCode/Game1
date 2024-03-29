﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//using Managers.ContentManager;

namespace Game1 {
    public abstract class Gamescreen {

        protected bool initialized;
        public bool Initialized {
            get {
                return initialized;
            }
        }

        protected bool quit;
        public bool Quit {
            get {
                return quit;
            }
        }

        public virtual void Initialize() {
            initialized = true;
        }
        public virtual void LoadContent(ContentManager pContentManager) {
         
        }
        public virtual void Update(GameTime pGameTime) {


        }
        public virtual void Draw(SpriteBatch pSpriteBatch) {

        }

    }
}
