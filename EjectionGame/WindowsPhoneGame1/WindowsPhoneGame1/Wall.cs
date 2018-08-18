using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Box2D.XNA;

namespace EjectionGame
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Wall : StaticPhysObject
    {
        #region Fields
        float width, height;
        #endregion        

        #region Initialization
        public Wall(Game game): base(game)
        {
        }

        public Wall(GameWorld gameWorld,
            Vector2 Position, Vector2 Size, Texture2D Texture, SoundEffect HitSound, Camera Camera)
            : base(gameWorld, Position, Texture, HitSound)
        {
            this.width = Size.X;
            this.height = Size.Y;
            
            PolygonShape groundBox = new PolygonShape();            
            groundBox.SetAsBox(Size.X / 2, Size.Y / 2);
            Body groundBody = World.CreateBody(groundBodyDef);
            Fixture = groundBody.CreateFixture(groundBox, 1.0f);

            /*DebugModel = new VertexPositionColor[4];
            float width2 = width * 480 * Camera.Scale.X / 2;
            float height2 = height * 480 * Camera.Scale.Y / 2;
            DebugModel[0].Position.X = Position.X * 480 * Camera.Scale.X - width2;
            DebugModel[0].Position.Y = Position.Y * 480 * Camera.Scale.Y - height2;
            DebugModel[1].Position.X = Position.X * 480 * Camera.Scale.X + width2;
            DebugModel[1].Position.Y = Position.Y * 480 * Camera.Scale.Y - height2;
            DebugModel[2].Position.X = Position.X * 480 * Camera.Scale.X + width2;
            DebugModel[2].Position.Y = Position.Y * 480 * Camera.Scale.Y + height2;
            DebugModel[3].Position.X = Position.X * 480 * Camera.Scale.X - width2;
            DebugModel[3].Position.Y = Position.Y * 480 * Camera.Scale.Y + height2;*/
        }

        #endregion
        

        #region Update and Render

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public void Draw(GameTime gameTime, Camera camera)
        {
            Vector2 dif = this.Fixture.GetBody().Position - camera.Target.fixture.GetBody().Position;
            dif.X *= 480 * camera.Scale.X;
            dif.Y *= 480 * camera.Scale.Y;

            Vector2 pos = camera.DrawCenter + dif;

            Vector2 Center = camera.Target.fixture.GetBody().Position;

            float coef = GameWorld.ScreenManager.GraphicsDevice.Viewport.Width;
            Rectangle targetRect = new Rectangle(
               (int)Math.Round(pos.X),
               (int)Math.Round(pos.Y),
               (int)Math.Round(width * 480 * camera.Scale.X),
               (int)Math.Round(height * 480 * camera.Scale.Y));

            if (GameWorld.DebugDraw)
            {
                //Matrix.CreateTranslation()
                PrimitiveBatch.Begin(PrimitiveType.TriangleList);
                PrimitiveBatch.AddVertex(new Vector2(targetRect.X - targetRect.Width / 2, targetRect.Y - targetRect.Height / 2), Color.Green);
                PrimitiveBatch.AddVertex(new Vector2(targetRect.X + targetRect.Width / 2, targetRect.Y - targetRect.Height / 2), Color.Green);
                PrimitiveBatch.AddVertex(new Vector2(targetRect.X + targetRect.Width / 2, targetRect.Y + targetRect.Height / 2), Color.Green);
                PrimitiveBatch.AddVertex(new Vector2(targetRect.X + targetRect.Width / 2, targetRect.Y + targetRect.Height / 2), Color.Green);
                PrimitiveBatch.AddVertex(new Vector2(targetRect.X - targetRect.Width / 2, targetRect.Y + targetRect.Height / 2), Color.Green);
                PrimitiveBatch.AddVertex(new Vector2(targetRect.X - targetRect.Width / 2, targetRect.Y - targetRect.Height / 2), Color.Green);
                PrimitiveBatch.End();
            }
            else
            {
                if (Texture != null)
                    SpriteBatch.Draw(Texture, targetRect, null, Color.White, Fixture.GetBody().Rotation, textureCenter, SpriteEffects.None, 0);
            }

            Draw(gameTime);
        }

        #endregion
    }
}
