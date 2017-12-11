using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GameLib;

namespace Asteroids
{
    class AsteroidGame : Game
    {
        Player player = new Player();
        Random r = new Random();
        private int lives = 3;
        bool respawn = false;
        int respawnTicks = 0;
        const int RESPAWN_TICKS = 150;
        
        public AsteroidGame()
        {
            
        }

        public override void Reset()
        {
            objects.Clear();
            objects.Add(new LargeAsteroid(50, 50));
            objects.Add(new LargeAsteroid(350, 50));
            objects.Add(new LargeAsteroid(350, 350));
            objects.Add(new LargeAsteroid(50, 350));
            objects.Add(player);

        }

        public override void Player1Up()
        {
            player.Thrust();
        }


        public override void Player1Down()
        {
            player.Speed--;
        }

        public override void Player1Left()
        {
            player.RotateLeft();
        }

        public override void Player1Right()
        {
            player.RotateRight();
        }

        public override void Player1Fire()
        {

             if (NumPlayerShots() < 5 && respawnTicks == 0)
            {
                PlayerShot ps = new PlayerShot(player.X, player.Y, player.SpriteDirection);
                objects.Add(ps);
                player.Fire();
            }
        }

        public int NumPlayerShots()
        {
            int count = 0;
            foreach (var gobj in objects)
            {
                if (gobj is PlayerShot)
                    count++; 
            }
            return count; //place holder
        }

        public int NumAsteriods()
        {
            int count = 0;
            foreach (var gobj in objects)
            {
                if (gobj is Asteroid)
                    count++;
            }
            return count; //place holder
        }

        public override void Update()
        {
            base.Update();

            CheckForCrash();
            RespawnAsteroidsIfNeeded();
            RespawnPlayerIfNeeded();
            CheckForShotHits();
            
        }//end update

        void CheckForShotHits()
        {
            //loop through objects and find shots
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i] is PlayerShot)
                {
                    //loop through objects and find asteroids
                    for (int j = 0; j < objects.Count; j++)
                    {
                        //is it an asteroid
                        if (objects[j] is Asteroid)
                        {
                            Asteroid a = objects[j] as Asteroid;

                            //is the distance to the shot < 10
                            if (a.GetDistance(objects[i]) < a.Radius)
                            {
                                objects[i].Destroy = true;

                                ((Asteroid)objects[j]).Hit(objects);

                                break;
                            }
                        }
                    }
                }
            }
        }


        void RespawnAsteroidsIfNeeded()
        {
            if (NumAsteriods() == 0)
            {
                int count = 0;
                do
                {
                    while (true)
                    {
                        int x = r.Next(640);
                        int y = r.Next(480);

                        if (player.GetDistance(x, y) > 50)
                        {
                            Asteroid ast = new LargeAsteroid(x, y);
                            objects.Add(ast);
                            count++;
                            break;
                        }
                    }
                } while (count < 5);
            }
        }

        void CheckForCrash()
        {
            foreach (var gobj in objects)
            {
                if(gobj is Asteroid)
                {
                    Asteroid a = gobj as Asteroid; 
                    if(gobj.GetDistance(player) < a.Radius+16)
                    {
                        DestroyPlayer();
                        break;
                    }
                }
            }
        }

        void DestroyPlayer()
        {
            Explosion expl = new Explosion(player.X, player.Y);
            objects.Add(expl);

            //move player out of world
            player.Destroy = true;
            player.X = 1000;
            player.Y = 1000;
            player.Direction = 0;
            player.Speed = 0;

            respawnTicks = RESPAWN_TICKS;

        }

        void RespawnPlayerIfNeeded()
        {
            if (respawnTicks > 0)
            {
                respawnTicks--;
                if (respawnTicks == 0)
                {
                    respawn = true;
                }
            }

            if (respawn==true)
            {
                lives--;

                if (lives > 0)
                {
                    player.X = 320;
                    player.Y = 240;
                    player.Destroy = false;
                    respawn = false;
                    player.SpriteDirection = 0;

                    objects.Add(player);
                }
                else
                {
                    objects.Add(
                        new GameObject(320, 240, Properties.Resources.spr_game_over_0)
                        );
                }
            }
            
        }

        public override void Draw(Graphics g)
        {
            base.Draw(g);

            DrawLives(g); 
        }

        void DrawLives(Graphics g)
        {
            Rectangle srcRct = new Rectangle
            {
                X = 0,
                Y = 0,
                Width = 32,
                Height = 32
            };

            for (int i = 0; i < lives; i++)
            {
                g.DrawImage(Properties.Resources.spr_player_strip72, 10 + i * 40, 10, srcRct, GraphicsUnit.Pixel);
            }
        }
    }
    

}
