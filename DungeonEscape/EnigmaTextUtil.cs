using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EnigmaUtils
{
    internal class EnigmaTextUtil
    {
        private SpriteFont m_font;
        private Vector2 m_position;

        private float alpha = 0.75f;
        private float  alphaChange = 0.6f;

        public EnigmaTextUtil(SpriteFont font, Vector2 position)
        {
            m_font = font;
            m_position = position;
        }

        public void UpdateMe(GameTime gameTime)
        {
            alpha += alphaChange * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (alpha > 0.9f)
            {
                alphaChange *= -1;
            }
            if (alpha < 0.0f)
            {
                alphaChange *= -1;
            }
        }

        public  void DrawString(SpriteBatch sBatch, string textToDraw)
        {
            sBatch.DrawString(m_font, textToDraw, m_position - m_font.MeasureString(textToDraw) / 2, Color.White * alpha);
        }
    }
}
