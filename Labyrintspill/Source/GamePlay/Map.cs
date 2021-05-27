using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;

namespace LabyrintSpill {
    public class Map {
        Basic2D[,] tiles = new Basic2D[101, 100];

        List<string> TexturePaths = new List<string> {
            "2D/Blank",
            "2D/Wall",
            "2D/Ground",
            "2D/Door"
        };

        int[,] map = new int[,] {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
            { 1, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
            { 1, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
            { 1, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
            { 1, 2, 2, 2, 2, 2, 2, 2, 2, 3 },
            { 1, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
            { 1, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
            { 1, 2, 2, 2, 2, 2, 2, 2, 2, 1 },
            { 1, 1, 1, 1, 2, 1, 1, 1, 1, 1 }
        };

        public Map() {
            MapDecoder();
        }

        public void MapDecoder() {
            for (int i = 0; i < 10; i++) {
                for(int j = 0; j < 10; j++) {
                    tiles[i, j] = new Basic2D(TexturePaths[map[i, j]], new Vector2(i * 64, j * 64), new Vector2(64, 64));
                }
            }
        }

        public virtual bool IsColliding(Vector2 pos, bool objectiv = false) {
            bool collided = false;
            
            if(objectiv) {

            } else {
                int x = (int)pos.X / 64;
                int y = (int)pos.Y / 64;

            }

            return collided;
        }

        public virtual void Draw(Vector2 OffSet) {
            for(int i = 0; i < 10; i++) {
                for(int j = 0; j < 10; j++) {
                    tiles[i, j].Draw(OffSet);
                }
            }
        }
    }
}