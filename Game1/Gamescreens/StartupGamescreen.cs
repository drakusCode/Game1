using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;


namespace Game1 {
    public class StartupGamescreen : Gamescreen {

        Texture2D sonicTexture;
        Texture2D backgroundTexture;
        Sprite backgroundSprite;
        Sprite sonicSprite;
        Font smallFont;

        public StartupGamescreen() {

        }

        public override void Initialize() {
            base.Initialize();
        }

        public override void LoadContent(ContentManager pContentManager) {
            base.LoadContent(pContentManager);
  
             backgroundTexture = pContentManager.GetTexture("Content/islend_sky.jpg");
            backgroundSprite = new Sprite(backgroundTexture, new Vector2(0, 0),Color.White, false);

            sonicTexture = pContentManager.GetTexture("Content/sonic.jpg");
            sonicSprite = new Sprite(sonicTexture, new Vector2(0, 300),Color.White, true);

            Texture2D fontSpriteTexture = pContentManager.GetTexture("Content/Fonts/small-font.png");
            FramedSprite fontSprite = new FramedSprite(8, 6, 0, fontSpriteTexture, Vector2.Zero, Color.Black, false);
            var mapping =pContentManager.GetFontMapping("Content/Fonts/small-font.fontmapping");
            smallFont = new Font(fontSprite, mapping, 0, 1, Color.Red);
        }

        public override void Update(GameTime pGameTime) {
            base.Update(pGameTime);

            if (Game1.Instance.InputManager.Pressed(Input.Back)) {/*prioritise the exit button*/
                quit = true; // Exit(); instance poped out in GamescreenManager
            }

            sonicSprite.Update(pGameTime);
        }

        public override void Draw(SpriteBatch pSpriteBatch) {
            base.Draw(pSpriteBatch);

            pSpriteBatch.Begin();
            backgroundSprite.Draw(pSpriteBatch);
            sonicSprite.Draw(pSpriteBatch);
            pSpriteBatch.End();

        }

    }
}
