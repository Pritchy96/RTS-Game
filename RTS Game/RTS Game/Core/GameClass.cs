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
using RTS_Game;

namespace RTS_Game
{
    public class GameClass : Microsoft.Xna.Framework.Game
    {
        #region Variables
        //Game constants
        public const int Game_Width = 800;
        public const int Game_Height = 600;
        public const int Tile_Width = 24;

        //Game objects
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private KeyboardState keyboard;
        private MouseState mouse;
        #endregion

        #region Function Explanation
        //Constructor.
        #endregion
        public GameClass()
        {
            //Content setup
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //make the mouse visible, we want to see the mouse
            IsMouseVisible = true;
        }

        #region Function Explanation
        //Sets up screen size.
        #endregion
        protected override void Initialize()
        {
            //Set the size of the game window
            graphics.PreferredBackBufferHeight = Game_Height;
            graphics.PreferredBackBufferWidth = Game_Width;
            graphics.ApplyChanges();

            base.Initialize();
        }

        #region Function Explanation
        //Loads all content used in game.
        #endregion
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            #region Background Textures.

            //Debug Tile
            Texture2D DebugTile = Content.Load<Texture2D>("BackgroundTiles/DebugTile");
            DebugTile.Name = "DebugTile";
            Resources.AddBackgroundTexture(DebugTile);
            
            //Ore
            Texture2D Ore = Content.Load<Texture2D>("BackgroundTiles/Ore");
            Ore.Name = "Ore";
            Resources.AddBackgroundTexture(Ore);

            //Grass01
            Texture2D Grass01 = Content.Load<Texture2D>("BackgroundTiles/Grass/Grass01");
            Grass01.Name = "Grass01";
            Resources.AddBackgroundTexture(Grass01);

            //Grass02
            Texture2D Grass02 = Content.Load<Texture2D>("BackgroundTiles/Grass/Grass02");
            Grass02.Name = "Grass02";
            Resources.AddBackgroundTexture(Grass02);

            //Grass03
            Texture2D Grass03 = Content.Load<Texture2D>("BackgroundTiles/Grass/Grass03");
            Grass03.Name = "Grass03";
            Resources.AddBackgroundTexture(Grass03);

            //Grass04
            Texture2D Grass04 = Content.Load<Texture2D>("BackgroundTiles/Grass/Grass04");
            Grass04.Name = "Grass04";
            Resources.AddBackgroundTexture(Grass04);

            //Road01
            Texture2D Road01 = Content.Load<Texture2D>("BackgroundTiles/Road01");
            Road01.Name = "Road01";
            Resources.AddBackgroundTexture(Road01);

            //Water01
            Texture2D Water01 = Content.Load<Texture2D>("BackgroundTiles/Water01");
            Water01.Name = "Water01";
            Resources.AddBackgroundTexture(Water01);
            #endregion

             #region Level Objects.
            //Debug
            Texture2D Debug = Content.Load<Texture2D>("Levels/Debug");
            Level Level00 = new Level("Level_Test", Debug, 0);
            Resources.AddLevelObject(Level00);

            //Island
            Texture2D Island = Content.Load<Texture2D>("Levels/Island");
            Level Level01 = new Level("Island", Island, 1);
            Resources.AddLevelObject(Level01);

            //Bridge
            Texture2D Bridge = Content.Load<Texture2D>("Levels/Bridge");
            Level Level02 = new Level("Bridge", Bridge, 2);
            Resources.AddLevelObject(Level02);
            #endregion

            #region GUI Textures
            //Splash Screen
            Texture2D SplashScreen = Content.Load<Texture2D>("GUI/Splash");
            SplashScreen.Name = "SplashScreen";
            Resources.AddGUITexture(SplashScreen);

            //Healthbar
            Texture2D HealthBar = Content.Load<Texture2D>("GUI/Healthbar");
            HealthBar.Name = "HealthBar";
            Resources.AddGUITexture(HealthBar);

            //SelectedRectangle
            Texture2D SelectedRectangle = Content.Load<Texture2D>("GUI/SelectedRectangle");
            SelectedRectangle.Name = "SelectedRectangle";
            Resources.AddGUITexture(SelectedRectangle);

            #endregion

            #region Unit Textures

            #region Heavy Tank
            //Up
            Texture2D HeavyTankUp = Content.Load<Texture2D>("Units/HeavyTank/HeavyTankUp");
            HeavyTankUp.Name = "HeavyTankUp";
            Resources.AddUnitTexture(HeavyTankUp);

            //Down
            Texture2D HeavyTankDown = Content.Load<Texture2D>("Units/HeavyTank/HeavyTankDown");
            HeavyTankDown.Name = "HeavyTankDown";
            Resources.AddUnitTexture(HeavyTankDown);

            //Left
            Texture2D HeavyTankLeft = Content.Load<Texture2D>("Units/HeavyTank/HeavyTankLeft");
            HeavyTankLeft.Name = "HeavyTankLeft";
            Resources.AddUnitTexture(HeavyTankLeft);

            //Right
            Texture2D HeavyTankRight = Content.Load<Texture2D>("Units/HeavyTank/HeavyTankRight");
            HeavyTankRight.Name = "HeavyTankRight";
            Resources.AddUnitTexture(HeavyTankRight);

            //Up and Right
            Texture2D HeavyTankUpRight = Content.Load<Texture2D>("Units/HeavyTank/HeavyTankUpRight");
            HeavyTankUpRight.Name = "HeavyTankUpRight";
            Resources.AddUnitTexture(HeavyTankUpRight);

            //Up and Left
            Texture2D HeavyTankUpLeft = Content.Load<Texture2D>("Units/HeavyTank/HeavyTankUpLeft");
            HeavyTankUpLeft.Name = "HeavyTankUpLeft";
            Resources.AddUnitTexture(HeavyTankUpLeft);

            //Down and Right
            Texture2D HeavyTankDownRight = Content.Load<Texture2D>("Units/HeavyTank/HeavyTankDownRight");
            HeavyTankDownRight.Name = "HeavyTankDownRight";
            Resources.AddUnitTexture(HeavyTankDownRight);            
            
            //Down and Left
            Texture2D HeavyTankDownLeft = Content.Load<Texture2D>("Units/HeavyTank/HeavyTankDownLeft");
            HeavyTankDownLeft.Name = "HeavyTankDownLeft";
            Resources.AddUnitTexture(HeavyTankDownLeft);
            #endregion

            //Harvester
            Texture2D Harvester = Content.Load<Texture2D>("Units/Harvester");
            Harvester.Name = "Harvester";
            Resources.AddUnitTexture(Harvester);
            #endregion

            #region Building Textures
            //Contruction Yard
            Texture2D ConstructionYard = Content.Load<Texture2D>("Buildings/ConstructionYard");
            ConstructionYard.Name = "ConstructionYard";
            Resources.AddBuildingTexture(ConstructionYard);

            //Power Plant
            Texture2D PowerPlant = Content.Load<Texture2D>("Buildings/PowerPlant");
            PowerPlant.Name = "PowerPlant";
            Resources.AddBuildingTexture(PowerPlant);

            //Refinery
            Texture2D Refinery = Content.Load<Texture2D>("Buildings/Refinery");
            Refinery.Name = "Refinery";
            Resources.AddBuildingTexture(Refinery);
            #endregion
            
            Resources.TestFont = Content.Load<SpriteFont>("GUI/TestFont");
        }

        #region Function Explanation
        //Dynamically loads a initialTexture.
        #endregion
        /*public Texture2D LoadTexture(string texturePath)
        {
            string name;
            if (texturePath.Contains("/"))
            {
                string[] array = texturePath.Split('/');
                name = array[array.Length - 1];
            }
            else
            {
                name = texturePath;
            }

            Texture2D initialTexture = Content.Load<Texture2D>(texturePath);
            initialTexture.Name = name;

            return initialTexture;
        }*/

        #region Function Explanation
        //Currently Unused.
        #endregion
        protected override void UnloadContent()
        {

        }

        #region Function Explanation
        //Updates Statemanager, rest is temporary.
        #endregion
        protected override void Update(GameTime gameTime)
        {
            //Update the state of the mouse and the keyboard
            keyboard = Keyboard.GetState();
            mouse = Mouse.GetState();

            //Update the StateManager
            StateManager.Instance.Update(gameTime);

            base.Update(gameTime);
        }

        #region Function Explanation
        //Draws State and therefore all of the game world.
        #endregion
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            StateManager.Instance.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
