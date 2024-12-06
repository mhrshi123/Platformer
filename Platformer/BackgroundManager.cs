using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Platformer.ParallaxLayer;

namespace Platformer
{
    public class BackgroundManager
    {
        private readonly List<ParallaxLayer> _layers;

        public BackgroundManager()
        {
            _layers = new();
        }

        public void AddLayer(ParallaxLayer layer)
        {
            _layers.Add(layer);
        }

        public void Update(float movement)
        {
            foreach (var layer in _layers)
            {
                layer.Update(movement);
            }
        }

        public void Draw()
        {
            foreach (var layer in _layers)
            {
                layer.Draw();
            }
        }
    }
}
