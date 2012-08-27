using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace Horror
{
    public class HUD
    {
        private int xStack;
        private int yStack;
        private int xStackCounter;
        public const float redHeartInt = 1.00F;
        public const float yellowHeartInt = 1.33F;
        public const float blackHeartInt = 1.66F;
        enum HeartColor 
        { 
            Green, 
            Red, 
            Yellow, 
            Black 
        }
        public static HeartColor heartColor = HeartColor.Green;
        private Color heartColorObj = new Color();
        private int controllingRec;
        public static Texture2D texture = new Texture2D(Game.graphics.GraphicsDevice, 1, 1),
            nonchangeableTexture = new Texture2D(Game.graphics.GraphicsDevice, 1, 1);

        public static Rectangle hbar1 = new Rectangle(0, Game.screen.Height, /*Player.player.Health*/100, 50),
            hbar2 = new Rectangle(0, Game.screen.Height, /*Player.player.maxHealth*/100, 50);

        private static void HUD_Layout(SpriteBatch a)
        {
            heartDisplay(a);

        }
        private static void heartDisplay(SpriteBatch a)
        {
            if ( /*Player.player.Health*/100 <= (/*Player.player.maxHealth*/100) && /*Player.player.Health*/100 > (/*Player.player.maxHealth*/100) / yellowHeartInt)
            {
                changeHeartColor(HeartColor.Green);
            }
            else if ( /*Player.player.Health*/100 <= (/*Player.player.maxHealth*/100 / yellowHeartInt) && /*Player.player.Health*/100 > (/*Player.player.maxHealth*/100) / blackHeartInt)
            {
                changeHeartColor(HeartColor.Yellow);
            }
            else if ( /*Player.player.Health*/100 <= (/*Player.player.maxHealth*/100 / blackHeartInt) && /*Player.player.Health*/100 > 0)
            {
                changeHeartColor(HeartColor.Red);
            }
            switch (heartColor)
            {
                case HeartColor.Green:
                    texture.SetData(new[] { Color.Red });
                    break;
                case HeartColor.Yellow:
                    texture.SetData(new[] { Color.Yellow });
                    break;
                case HeartColor.Red:
                    texture.SetData(new[] { Color.Black });
                    break;
                default:
                    texture.SetData(new[] { Color.Red });
                    break;
                    a.DrawString(Game.spriteFont, "- Health[" + /*Player.player.Health*/100 + " / " + /*Player.player.maxHealth*/100 + "]", new Vector2(/*Player.player.maxHealth*/100 + 5, Game.screen.Height), Color.Magenta);
                    a.Draw(texture, hbar1, Color.White);
                    a.Draw(nonchangeableTexture, hbar2, Color.White);
            }
        }
        public static void changeHeartColor(HeartColor heartColor)
        {
            /*The reason I'm using different variables even 
             * though I could've made a few Objs
             * is because I have some cool
             * item ideas that influence
             * how your health bar acts!
             */
            if (heartColor == HeartColor.Green)
            {
                HUD.heartColor = HeartColor.Green;
            }
            if (heartColor == HeartColor.Yellow)
            {
                HUD.heartColor = HeartColor.Yellow;
            }
            if (heartColor == HeartColor.Red)
            {
                HUD.heartColor = HeartColor.Red;
            }
        }
    }
}