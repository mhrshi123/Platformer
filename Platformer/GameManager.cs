using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{

    public enum GameState
    {
        Playing,
        GameOver,
        Win
    }
    public class GameManager
    {


        private Hero _hero;
        private Flag _flag;
        private Map _map;
        private SpriteFont _font;
        public static GameState gameState;
        private readonly float _bgSpeed = 200f;
        public float BgMovement { get; set; }
        private readonly BackgroundManager _bgm = new();


        public GameManager()
        {
            _map = new Map();
            _hero = new Hero(Globals.Content.Load<Texture2D>("Images/hero"), new Vector2(200, 200));
            _flag = new Flag(Globals.Content.Load<Texture2D>("Images/Flag"), new Vector2(1536, 128), 0.128f); 

            _font = Globals.Content.Load<SpriteFont>("Fonts/gameOverFont");
            _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("Images/Layer0"), 0.0f, 0.0f));
            _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("Images/Layer1"), 0.1f, 0.2f));
            _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("Images/Layer2"), 0.2f, 0.5f));
            _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("Images/Layer3"), 0.3f, 1.0f));
            _bgm.AddLayer(new(Globals.Content.Load<Texture2D>("Images/Layer4"), 0.4f, 0.2f, -100.0f));

            gameState = GameState.Playing;
        }

        public void Update()
        {
            if (gameState == GameState.Playing)
            {
                _hero.Update();


                if (_hero.position.Y > Globals.WindowSize.Y)
                {
                    gameState = GameState.GameOver;
                }

                if (_flag.CheckCollision(_hero.Bounds))
                {
                    gameState = GameState.Win;
                }

                // Update parallax layers
                KeyboardState ks = Keyboard.GetState();
                BgMovement = 0;

                if (ks.IsKeyDown(Keys.D))
                {
                    BgMovement = -_bgSpeed;
                }
                else if (ks.IsKeyDown(Keys.A))
                {
                    BgMovement = _bgSpeed;
                }

                _bgm.Update(BgMovement);
            }
        }

        public void Draw()
        {
            Globals.SpriteBatch.Begin();

            if (gameState == GameState.Playing)
            {
                _bgm.Draw();
                _map.Draw();
                _hero.Draw();
                _flag.Draw();

            }
            else if (gameState == GameState.GameOver)
            {
                Globals.SpriteBatch.DrawString(_font, "Game Over", new Vector2(Globals.WindowSize.X / 3, Globals.WindowSize.Y / 2), Color.Red);
            }
            else if (gameState == GameState.Win)
            {
                Globals.SpriteBatch.DrawString(_font, "You Win!", new Vector2(Globals.WindowSize.X / 3, Globals.WindowSize.Y / 2), Color.Green);
            }

            Globals.SpriteBatch.End();
        }
    }
}
