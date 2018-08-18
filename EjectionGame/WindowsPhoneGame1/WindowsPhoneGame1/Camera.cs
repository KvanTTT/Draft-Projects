using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Box2D.XNA;

namespace EjectionGame
{
    public class Camera : GameComponent
    {
        GameWorld gameWorld;
        Chip target;        
        Vector2 scale = new Vector2(1.0f, 1.0f);
        public bool leftBound
        {
            get;
            protected set;
        }
        public bool rightBound
        {
            get;
            protected set;
        }
        public bool topBound
        {
            get;
            protected set;
        }
        public bool bottomBound
        {
            get;
            protected set;
        }

        public GameWorld GameWorld
        {
            get { return gameWorld; }
            protected set { gameWorld = value; }
        }
        public Chip Target
        {
            get { return target; }
            protected set { target = value; }
        }
        public Vector2 Scale
        {
            get { return scale; }
            protected set { scale = value; }
        }


        // render to this rectangle of phone7 screen (default 0, 0, 480, 800)
        Rectangle destRect;
        public Rectangle DestRect
        {
            get { return destRect; }
            protected set { destRect = value; }
        }

        /// <summary>
        /// output parameters
        // render from this rectangle of background texture
        Rectangle backgroundRect;
        // Real coordinates of screen of camera target
        Vector2 drawCenter;
        int screenWidth, screenHeight;
        /// <summary>
        /// 

        public Rectangle BackgroundRect
        {
            get { return backgroundRect; }
            set { backgroundRect = value; }
        }
        public Vector2 DrawCenter
        {
            get { return drawCenter; }
            set { drawCenter = value; }
        }

        Vector2 defaultDrawCenter;
        float destHeightWidthRatio;
        

        public Camera(Game game) : base(game)
        {
            
        }

        public Camera(GameWorld gameWorld, Rectangle destRect, Chip target, Vector2 scale)
            : this(gameWorld.ScreenManager.Game)
        {
            this.gameWorld = gameWorld;
            this.destRect = destRect;
            this.target = target;
            this.scale = scale;

            screenWidth = gameWorld.ScreenManager.GraphicsDevice.Viewport.Width;
            screenHeight = gameWorld.ScreenManager.GraphicsDevice.Viewport.Height;

            destHeightWidthRatio = (float)screenHeight / screenWidth;            
        
            backgroundRect = new Rectangle();
            backgroundRect.Width = (int)Math.Round(
                (float)destRect.Width / (screenWidth * gameWorld.width) * gameWorld.background.Width / scale.X);
            backgroundRect.Height = (int)Math.Round(
                (float)destRect.Height / (screenHeight * gameWorld.height) * gameWorld.background.Height / scale.Y);

            defaultDrawCenter = new Vector2(
                ((float)destRect.Width / 2 + destRect.Left) ,
                ((float)destRect.Height / 2 + destRect.Top));

            leftBound = rightBound = topBound = bottomBound = false;
        }

        Vector2 prevCenter;
        public override void Update(GameTime gameTime)
        {        
            destRect = new Rectangle(0, 0, gameWorld.ScreenManager.GraphicsDevice.Viewport.Width,
                gameWorld.ScreenManager.GraphicsDevice.Viewport.Height);

            defaultDrawCenter = new Vector2(
                ((float)destRect.Width / 2 + destRect.Left),
                ((float)destRect.Height / 2 + destRect.Top));

            leftBound = rightBound = topBound = bottomBound = false;

            drawCenter = defaultDrawCenter;
            Vector2 center = target.fixture.GetBody().Position;
            prevCenter = center;

            Vector2 pos = new Vector2(
                center.X - (float)destRect.Width / screenWidth / 2 / scale.X,
                center.Y - (float)destRect.Height / screenWidth / 2 / scale.Y);
            
            if (pos.X < 0.0f)
            {
                drawCenter.X += pos.X * screenWidth * scale.X;
                pos.X = 0.0f;
                leftBound = true;
            }
            else
                if (pos.X >= gameWorld.width - (float)destRect.Width / screenWidth / scale.X)
                {
                    drawCenter.X += (pos.X + (float)destRect.Width / screenWidth / scale.X - gameWorld.width) * screenWidth * scale.X;
                    pos.X = gameWorld.width - (float)destRect.Width / screenWidth / scale.X;
                    rightBound = true;
                }

            if (pos.Y < 0.0f)
            {
                drawCenter.Y += pos.Y * screenWidth * scale.Y;
                pos.Y = 0.0f;
                topBound = true;
            }
            else
                if (pos.Y >= gameWorld.height - (float)destRect.Height / screenWidth / scale.Y)
            {
                drawCenter.Y += (pos.Y + (float)destRect.Height / screenWidth / scale.Y - gameWorld.height) * screenWidth * scale.Y;
                pos.Y = gameWorld.height - (float)destRect.Height / screenWidth / scale.Y;
                bottomBound = true;
            }

			backgroundRect.X = (int)Math.Round(pos.X / gameWorld.width * gameWorld.background.Width);
			backgroundRect.Y = (int)Math.Round(pos.Y / gameWorld.height * gameWorld.background.Height);
			backgroundRect.Width = (int)Math.Round(
				(float)destRect.Width / (screenWidth * gameWorld.width) * gameWorld.background.Width / scale.X);
			backgroundRect.Height = (int)Math.Round(
				(float)destRect.Height / (screenHeight * gameWorld.height) * gameWorld.background.Height / scale.Y);
            

 	        base.Update(gameTime);
        }
    }
}
