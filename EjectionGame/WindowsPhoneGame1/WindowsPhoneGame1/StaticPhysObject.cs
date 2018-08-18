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
    public class StaticPhysObject : DrawableGameComponent
    {
        #region Fields
        // pointers
        public GameWorld GameWorld
        {
            get;
            protected set;
        }
        public SpriteBatch SpriteBatch
        {
            get;
            protected set;
        }
        public PrimitiveBatch PrimitiveBatch
        {
            get;
            protected set;
        }
        public World World
        {
            get;
            protected set;
        }

        // contain
        public Fixture Fixture;
        public Texture2D Texture
        {
            get;
            protected set;
        }
        public SoundEffect HitSound
        {
            get;
            protected set;
        }


        protected Rectangle drawRectangle;
        protected Vector2 textureCenter;
        protected BodyDef groundBodyDef;

        public VertexPositionColor[] DebugModel
        {
            get;
            protected set;
        }

        #endregion

        public StaticPhysObject(Game Game) : base(Game)
        {
        }

        public StaticPhysObject(GameWorld GameWorld, Vector2 Position, Texture2D Texture, SoundEffect HitSound)
            : this(GameWorld.ScreenManager.Game)
        {
            this.GameWorld = GameWorld;
            this.PrimitiveBatch = GameWorld.primitiveBatch;
            this.SpriteBatch = GameWorld.spriteBatch;
            this.World = GameWorld.physWorld;
            this.Texture = Texture;
            this.HitSound = HitSound;

            groundBodyDef = new BodyDef();
            groundBodyDef.position = Position;

            if (Texture != null)
            {
                textureCenter.X = (float)Texture.Width / 2.0f;
                textureCenter.Y = (float)Texture.Height / 2.0f;
            }
        }
    }
}
