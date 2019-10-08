using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1 {
    public class InputManager {

        public Dictionary<Keys, Input> KeyBindingsKeyboard;
        public Dictionary<Buttons, Input> KeyBindingGamepad;

        private bool isUsingKeyboard;
        private int playerInput;

        public InputManager(bool pIsUsingKeyboard = true) {
            isUsingKeyboard = pIsUsingKeyboard;

            KeyBindingsKeyboard = new Dictionary<Keys, Input> {
                { Keys.Z,Input.Up },
                { Keys.S,Input.Down },
                { Keys.D,Input.Right },
                { Keys.Q,Input.Left },
                { Keys.Escape,Input.Back }

            };
            KeyBindingGamepad = new Dictionary<Buttons, Input> {
                { Buttons.DPadUp,Input.Up },
                { Buttons.DPadDown,Input.Down },
                { Buttons.DPadRight,Input.Right },
                { Buttons.DPadLeft,Input.Left },
                { Buttons.Back,Input.Back }

            };
        }

        public void Update(PlayerIndex pPlayer = PlayerIndex.One) {
            playerInput = 0;
            if (isUsingKeyboard) {
                Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

                foreach (Keys key in pressedKeys) {
                    if (KeyBindingsKeyboard.ContainsKey(key))
                    {/*in case we pressed other key than up down..*/
                        playerInput |= (int)KeyBindingsKeyboard[key];/*binding/casting all the keys pressed by the player*/
                    }
                }
            }
            else {
                var gamepadState = GamePad.GetState(pPlayer);
                foreach (var kvp in KeyBindingGamepad)
                {
                    /*checking the pressed keys on maneta..*/
                    if (gamepadState.IsButtonDown(kvp.Key))
                    {
                        playerInput |= (int)kvp.Value;
                    }
                }
            }
        }

        /* want to be able to do : 
        * if (inputManager.Pressed(Input.Up))
        * or:  if (inputManager.Pressed(Input.Up,Input.Left))*/
        public bool Pressed(params Input[] pInputs) {
            int n = 0;
            foreach (var pi in pInputs) {
                n |= (int)pi;
            }
            return playerInput == n;

        }
    }
}
