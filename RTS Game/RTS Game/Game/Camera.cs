﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace RTS_Game
{
    class Camera
    {
        public const float CameraSpeed = 6;

        //The cameras matrix that will be used in spriteBatch.Begin()
        private Matrix matrix = new Matrix();

        //The position of the top left corner of the screen relative to the camera
        private Vector2 position = new Vector2(0,0);

        //Zoom variable represents how far zoomed in the camera is
        private float zoom = 1f;

        //We initially assume a 30 x 30 tilemap
        //We have methods that re-workout these values
        private int WorldWidth = 2400;
        private int WorldHeight = 2400;

        #region Properties
        public Matrix CameraMatrix
        {
            get { return matrix; }
        }

        public Vector2 Position
        {
            get { return position; }
            set 
            {
                position = ClampCamera(value);
            }
        }

        /*public float X
        {
            get { return X; }

            set { Position = }
        }*/

        public float Zoom
        {
            get { return zoom; }
            set 
            { 
                zoom = value;
                if (zoom < 0.5f)
                {
                    //A limiter to stop zoom going too low
                    zoom = 0.5f;
                }
            }
        }
        #endregion

        public Camera()
        {
            Position = new Vector2(0, 0);
        }

        //This allows the camera to know the width and height of the map in pixels
        //By default the camera assumes the map is 30 x 30
        //For now all our maps are 30 x 30, but that might change
        public void GiveTilemap(TileMap tilemap)
        {
            WorldHeight = tilemap.Width * GameClass.Tile_Width;
            WorldWidth = tilemap.Height * GameClass.Tile_Width;
        }

        //Returns a vector2 that is within the gamefield
        private Vector2 ClampCamera(Vector2 vector)
        {
            //Unfinished
            if (vector.X < 0) { vector.X = 0; }
            if (vector.X > (WorldWidth - GameClass.Game_Width)) { vector.X = (WorldWidth - GameClass.Game_Width); }
            if (vector.Y < 0) { vector.Y = 0; }
            if (vector.Y > (WorldHeight - GameClass.Game_Height)) { vector.Y = (WorldHeight - GameClass.Game_Height); }
            return vector;
        }


        //Offsets the target position by half of the screen so we can center on it
        public void CenterCameraOn(Vector2 target)
        {
            Position = target - new Vector2(GameClass.Game_Width / 2, GameClass.Game_Height / 2);
        }

        //This is where we change the camera depending on our inputs
        public void Update(KeyboardState keyboard, MouseState mouse)
        {
            Vector2 movementVector = new Vector2(0, 0);
            //camera movement logic
            if (keyboard.IsKeyDown(Keys.Left))
            {
                movementVector.X--;
            }
            if (keyboard.IsKeyDown(Keys.Right))
            {
                movementVector.X++;
            }
            if (keyboard.IsKeyDown(Keys.Up))
            {
                movementVector.Y--;
            }
            if (keyboard.IsKeyDown(Keys.Down))
            {
                movementVector.Y++;
            }

            if (movementVector != Vector2.Zero)
            {
                movementVector.Normalize();
                Position += (movementVector * CameraSpeed);
            }

            //Set the matrix
            matrix = Matrix.CreateScale(new Vector3(Zoom, Zoom, 0)) *
                     Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0));
            
            
            //Giving Credit
            //I understand some of this, but most came from this tutorial:
            //http://www.youtube.com/watch?v=c_SPRT7DAeM
        }
    }
}
