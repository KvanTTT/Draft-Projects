using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using Box2D.XNA;

namespace EjectionGame
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class EjectionGame : Microsoft.Xna.Framework.Game
	{
		#region Fields;

		GraphicsDeviceManager graphics;
		ScreenManager screenManager;

		#endregion

		const int graphicsWidth = 480;
		const int graphicsHeight = 800;

		const float ratio = 800.0f / 480.0f;
		//float FieldWidth = 1.0f;
		//float FieldHeight = 800.0f / 480.0f * 1.0f;
		float FieldWidth = 5.0f;
		float FieldHeight = 3.0f * ratio;
		float BorderWidth = 0.2f;

		// half of the backbuffer width used for spawning enemies and creating stars
		const int graphicsWidthHalf = graphicsWidth / 2;

		// half of the backbuffer height used for spawning enemies and creating stars
		const int graphicsHeightHalf = graphicsHeight / 2;


		SpriteBatch spriteBatch;
		Texture2D Background;

		private Texture2D blank;

		static SoundEffect sound;

		World World;

		Vector2 viewCenter = new Vector2(0.0f, 20.0f);
		Vector2[] DynamicPolygon;
		MouseJoint MouseJoint;
		Vector2 MouseWorldPhys;
		CircleModel[] circleModel;


		Vector2 pos;

		WorldManifold worldManifold;

		public class Test : IContactListener
		{
			public void BeginContact(Contact contact) { }
			public void EndContact(Contact contact) { }
			public virtual void PreSolve(Contact contact, ref Manifold oldManifold)
			{
				/*Manifold manifold;
				contact.GetManifold(out manifold);

				if (manifold._pointCount == 0)
				{
					return;
				}

				Fixture fixtureA = contact.GetFixtureA();
				Fixture fixtureB = contact.GetFixtureB();

				FixedArray2<PointState> state1, state2;
				Collision.GetPointStates(out state1, out state2, ref oldManifold, ref manifold);

				WorldManifold worldManifold;
				contact.GetWorldManifold(out worldManifold);

				for (int i = 0; i < manifold._pointCount && _pointCount < k_maxContactPoints; ++i)
				{
					if (fixtureA == null)
					{
						_points[i] = new ContactPoint();
					}
					ContactPoint cp = _points[_pointCount];
					cp.fixtureA = fixtureA;
					cp.fixtureB = fixtureB;
					cp.position = worldManifold._points[i];
					cp.normal = worldManifold._normal;
					cp.state = state2[i];
					_points[_pointCount] = cp;
					++_pointCount;
				}*/

				WorldManifold worldManifold;
				contact.GetWorldManifold(out worldManifold);

				FixedArray2<PointState> state1 = new FixedArray2<PointState>();
				FixedArray2<PointState> state2 = new FixedArray2<PointState>();

				Manifold manifold;
				contact.GetManifold(out manifold);

				Box2D.XNA.Collision.GetPointStates(out state1, out state2, ref oldManifold, ref manifold);

				if (state2[0] == PointState.Add)
				{

					Body bodyA = contact.GetFixtureA().GetBody();
					Body bodyB = contact.GetFixtureB().GetBody();

					Vector2 point = worldManifold._points[0];

					Vector2 vA = bodyA.GetLinearVelocityFromWorldPoint(point);
					Vector2 vB = bodyB.GetLinearVelocityFromWorldPoint(point);

					float approachVelocity = Vector2.Dot(Vector2.Subtract(vB, vA), worldManifold._normal);

					if (approachVelocity < -0.1f)
					{
						sound.Play();
					}

				}
			}
			public void PostSolve(Contact contact, ref ContactImpulse impulse) { }

			public Test() { }
		}


		class CircleModel
		{
			public readonly Texture2D texture;			
			public readonly Body physModel;
			SpriteBatch spriteBatch;
			GraphicsDeviceManager graphics;

			Rectangle drawRectangle;
			Vector2 texCenter;

			public CircleModel(Texture2D texture, Body physModel, SpriteBatch spriteBatch,
				GraphicsDeviceManager graphics)
			{
				this.texture = texture;
				this.physModel = physModel;
				this.spriteBatch = spriteBatch;
				this.graphics = graphics;

				drawRectangle.Width = (int)Math.Round(
					(physModel.GetFixtureList().GetShape() as CircleShape)._radius * 
					graphics.PreferredBackBufferWidth * 2);
				drawRectangle.Height = drawRectangle.Width;

				texCenter = new Vector2(texture.Width / 2, texture.Height / 2);
			}

			public void Draw()
			{
				drawRectangle.X = (int)Math.Round((physModel.Position.X) * graphics.PreferredBackBufferWidth);
				drawRectangle.Y = (int)Math.Round((physModel.Position.Y) * graphics.PreferredBackBufferWidth);

				spriteBatch.Draw(texture, drawRectangle, null, Color.White, physModel.Rotation,
					texCenter, SpriteEffects.None, 0);
			}
		}

		/// <summary>
		/// Helper method to the initialize the game to be a portrait game.
		/// </summary>
		private void InitializePortraitGraphics()
		{
			graphics.PreferredBackBufferWidth = 480;
			graphics.PreferredBackBufferHeight = 800;
		}

		/// <summary>
		/// Helper method to initialize the game to be a landscape game.
		/// </summary>
		private void InitializeLandscapeGraphics()
		{
			graphics.PreferredBackBufferWidth = 800;
			graphics.PreferredBackBufferHeight = 480;
		}

		public EjectionGame()
		{
			Content.RootDirectory = "Content";			

			TargetElapsedTime = TimeSpan.FromTicks(333333); // 30 fps

			graphics = new GraphicsDeviceManager(this);
			graphics.IsFullScreen = true;
			graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft |
															 DisplayOrientation.LandscapeRight |
															 DisplayOrientation.Portrait;
			graphics.ApplyChanges();

			InitializePortraitGraphics();

			screenManager = new ScreenManager(this);

			Components.Add(screenManager);

			

			// attempt to deserialize the screen manager from disk. if that
			// fails, we add our default screens.
			if (!screenManager.DeserializeState())
			{
				// Activate the first screens.
				screenManager.AddScreen(new BackgroundScreen(), null);
				screenManager.AddScreen(new MainMenuScreen(), null);
			}
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			base.Initialize();
		}

		Vector2[] PrepareCircleShape(float Radius, int VertexCount)
		{
			Vector2[] Result = new Vector2[VertexCount];
			float Ang = 0;
			float dAng = (float)(Math.PI * 2.0 / VertexCount);
			for (int i = 0; i < VertexCount; i++)
			{
				Result[i].X = Radius * (float)Math.Cos(Ang);
				Result[i].Y = Radius * (float)Math.Sin(Ang);
				Ang += dAng;
			}
			return Result;
		}


		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
            //primitiveBatch = new PrimitiveBatch(graphics.GraphicsDevice);
			spriteBatch = new SpriteBatch(GraphicsDevice);

			Background = Content.Load<Texture2D>("Textures/background");
			sound = Content.Load<SoundEffect>("Sounds/Hit");


			// create our 1x1 blank texture
			blank = new Texture2D(GraphicsDevice, 1, 1);
			blank.SetData(new[] { Color.White });
			

			Vector2 gravity = new Vector2(0, 0.98f);
			World = new World(gravity, true);				

			Random Rand = new Random();

			double radius;
			Vector2 Pos;

			/*for (int i = 0; i < circleModel.Length; i++)
			{
				double radius = (float)(Rand.NextDouble() * 0.2 + 0.03);                
				Vector2 Pos = new Vector2((float)(Rand.NextDouble() * (1.0 - 2 * radius) + radius),
					(float)(Rand.NextDouble() * (ratio - 2 * radius) + radius));
				circleModel[i] = new CircleModel(Content.Load<Texture2D>("circle"),
					CreateCircle(Pos, (float)radius, 1.0f, (float)Rand.NextDouble(), (float)Rand.NextDouble()),
					spriteBatch, graphics);
			}*/
			/*
			radius = 0.07;
			Pos = new Vector2(0.5f, 0.4f);
			circleModel[0] = new CircleModel(Content.Load<Texture2D>("Textures/circle"),
				CreateCircle(Pos, (float)radius, 1.0f, (float)Rand.NextDouble(), (float)Rand.NextDouble()),
				spriteBatch, graphics);
			
			radius = 0.05;
			Pos = new Vector2(0.5f, 0.7f);
			circleModel[1] = new CircleModel(Content.Load<Texture2D>("Textures/ball"),
				CreateCircle(Pos, (float)radius, 1.5f, (float)Rand.NextDouble(), (float)Rand.NextDouble()),
				spriteBatch, graphics);

			DistanceJointDef distJoint = new DistanceJointDef();
			distJoint.Initialize(circleModel[0].physModel, circleModel[1].physModel, 
				circleModel[0].physModel.Position, circleModel[1].physModel.Position);
			distJoint.collideConnected = true;
			distJoint.frequencyHz = 4.0f;
			distJoint.dampingRatio = 0.5f;

			var joint = World.CreateJoint(distJoint);

			worldManifold = new WorldManifold();

			World.ContactListener = test;*/
		}

		protected override void UnloadContent()
		{
			
		}

		

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// Allows the game to exit
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
				this.Exit(); 
/*
			World.Step((float)gameTime.ElapsedGameTime.TotalSeconds, 6, 2);
			World.ClearForces();


			var touches = TouchPanel.GetState();
			foreach (var touch in touches)
			{
				Random rand = new Random();
			   // if (touch.State == TouchLocationState.Pressed)
			   //     circleModel[0].physModel.ApplyForce(new Vector2((float)rand.NextDouble() - 0.5f, -0.5f), circleModel[0].physModel.Position);
				MouseWorldPhys = touch.Position / graphicsWidth + pos;

				//MouseWorldPhys = circleModel[0].physModel.Position;

				if (touch.State == TouchLocationState.Pressed)
				{
					Body B = circleModel[0].physModel;
					if (B != null)
					{
						Box2D.XNA.MouseJointDef MouseJointDef = new Box2D.XNA.MouseJointDef();
						MouseJointDef.bodyA = groundBody;
						MouseJointDef.bodyB = B;
						MouseJointDef.target = MouseWorldPhys;
						MouseJointDef.collideConnected = true;
						MouseJointDef.maxForce = 30.0f * B.GetMass();
						MouseJoint = World.CreateJoint(MouseJointDef) as Box2D.XNA.MouseJoint;
						B.SetAwake(true);
					}
				}
				else
					if (touch.State == TouchLocationState.Released)
					{

						if (MouseJoint != null)
						{
							World.DestroyJoint(MouseJoint);
							MouseJoint = null;
						}
					}
					else
						if (MouseJoint != null)
						{
							MouseJoint.SetTarget(MouseWorldPhys);
						}
			}
			*/

			base.Update(gameTime);
		}

		Body B;
		Fixture F;
		Vector2 mousePVec;
		bool includeStatic;

		protected Body GetBodyAtMouse(bool includeStatic)
		{
			// Make a small box.
			mousePVec = MouseWorldPhys;
			AABB aabb = new AABB();
			aabb.lowerBound = MouseWorldPhys - new Vector2(0.001f, 0.001f);
			aabb.upperBound = MouseWorldPhys + new Vector2(0.001f, 0.001f);
			B = null;
			this.includeStatic = includeStatic;

			World.QueryAABB(GetBodyCallback, ref aabb);
			return B;
		}

		// Query the world for overlapping shapes.
		bool GetBodyCallback(Fixture F)
		{
			Shape S = F.GetShape();
			if (F.GetBody().GetType() != BodyType.Static || includeStatic)
			{
				Transform trans;
				F.GetBody().GetTransform(out trans);
				bool inside = S.TestPoint(ref trans, mousePVec);
				if (inside)
				{
					B = F.GetBody();
					return false;
				}
			}
			return true;
		}

	}

	#region Entry Point

	#if WINDOWS || XBOX
		static class Program
		{
			/// <summary>
			/// The main entry point for the application.
			/// </summary>
			static void Main(string[] args)
			{
				using (Game1 game = new Game1())
				{
					game.Run();
				}
			}
		}
	#endif

	#endregion
}
