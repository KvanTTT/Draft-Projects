#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Devices;
using System.Xml.Linq;
using Box2D.XNA;
#endregion

namespace EjectionGame
{
	public class Chip : DrawableGameComponent
	{
		#region Fields
		// pointers
		GameWorld gameWorld;
		SpriteBatch spriteBatch;
		World world;        

		// contain
		public readonly Fixture fixture;

		Texture2D texture;
		SoundEffect hitSound;

		Rectangle drawRectangle;
		Vector2 textureCenter;
        GestureSample? prevSample;
		#endregion

		#region Initialization
		public Chip(Game game): base(game)
		{
		}

		// потом заменить на загрузку из storage
		public Chip(GameWorld gameWorld,
			Vector2 Pos, float radius, float density, float friction, float restitution,
			Texture2D texture, SoundEffect hitSound)
			: this(gameWorld.ScreenManager.Game)
		{
			this.gameWorld = gameWorld;
			this.spriteBatch = gameWorld.ScreenManager.SpriteBatch;
			this.world = gameWorld.physWorld;
			this.texture = texture;
			this.hitSound = hitSound;

			BodyDef BodyDef;
			FixtureDef FixtureDef;
			Body B;

			BodyDef = new BodyDef();
			FixtureDef = new FixtureDef();
			BodyDef.type = BodyType.Dynamic;
			BodyDef.position = Pos;
			B = world.CreateBody(BodyDef);
			CircleShape dynamicCircle = new CircleShape();
			dynamicCircle._radius = radius;
			FixtureDef.shape = dynamicCircle;
			FixtureDef.density = density;
			FixtureDef.friction = friction;
			FixtureDef.restitution = restitution;
			fixture = B.CreateFixture(FixtureDef);

			textureCenter.X = (float)texture.Width / 2.0f;
			textureCenter.Y = (float)texture.Height / 2.0f;
		}

		#endregion

        public void HandleInput(GestureSample gestureSample)
        {
            if (gestureSample.Delta.Length() != 0)
                fixture.GetBody().ApplyForce(new Vector2(gestureSample.Delta.X / 100.0f, gestureSample.Delta.Y / 100.0f),
                                            fixture.GetBody().Position);
        }

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
            Vector2 dif = this.fixture.GetBody().Position - camera.Target.fixture.GetBody().Position;
            /*dif.X *= 480 * camera.Scale.X;
            if (camera.topBound || camera.bottomBound)
                dif.Y *= 800 * camera.Scale.Y;
            else
                dif.Y *= 480 * camera.Scale.Y;*/
            dif.X *= 480 * camera.Scale.X;
            dif.Y *= 480 * camera.Scale.Y;

            Vector2 pos = camera.DrawCenter + dif;
            
            Vector2 Pos = this.fixture.GetBody().Position;
            Vector2 Center = camera.Target.fixture.GetBody().Position;

			float coef = gameWorld.ScreenManager.GraphicsDevice.Viewport.Width;
			Rectangle targetRect = new Rectangle(
               (int)Math.Round(pos.X),
               (int)Math.Round(pos.Y),
               (int)Math.Round((fixture.GetShape() as CircleShape)._radius * 2 * 480 * camera.Scale.X),
               (int)Math.Round((fixture.GetShape() as CircleShape)._radius * 2 * 480 * camera.Scale.Y));

            if (gameWorld.DebugDraw)
            {
                gameWorld.primitiveBatch.Begin(PrimitiveType.TriangleList);
                gameWorld.primitiveBatch.AddVertex(new Vector2(targetRect.X - targetRect.Width / 2, targetRect.Y - targetRect.Height / 2), Color.Green);
                gameWorld.primitiveBatch.AddVertex(new Vector2(targetRect.X + targetRect.Width / 2, targetRect.Y - targetRect.Height / 2), Color.Green);
                gameWorld.primitiveBatch.AddVertex(new Vector2(targetRect.X + targetRect.Width / 2, targetRect.Y + targetRect.Height / 2), Color.Green);
                gameWorld.primitiveBatch.AddVertex(new Vector2(targetRect.X - targetRect.Width / 2, targetRect.Y + targetRect.Height / 2), Color.Green);
                gameWorld.primitiveBatch.AddVertex(new Vector2(targetRect.X - targetRect.Width / 2, targetRect.Y - targetRect.Height / 2), Color.Green);
                gameWorld.primitiveBatch.End();
            }
            else
			    spriteBatch.Draw(texture, targetRect, null, Color.White, fixture.GetBody().Rotation, textureCenter, SpriteEffects.None, 0);

			Draw(gameTime);
		}

		#endregion

	}
}
