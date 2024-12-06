using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    public class Flag : Sprite
    {
        private float _scale;

        public Flag(Texture2D texture, Vector2 position, float scale = 0.128f) : base(texture, position)
        {
            _scale = scale;
        }

        public bool CheckCollision(Rectangle heroBounds)
        {
            return heroBounds.Intersects(new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height));
        }

        public override void Draw()
        {
            Globals.SpriteBatch.Draw(Texture, position, null, Color.White, 0f, Vector2.Zero, _scale, SpriteEffects.None, 0f);
        }


    }
}
