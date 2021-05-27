using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LabyrintSpill {
    public class MouseControl {
        public bool dragging, rightDrag;
        public Vector2 newMousePos, oldMousePos, firstMousePos, newMouseAdjustedPos, systemCursorPos, screenLoc;
        public MouseState newMouse, oldMouse, firstMouse;

        public MouseControl() {
            dragging = false;

            newMouse = Mouse.GetState();
            oldMouse = newMouse;
            firstMouse = newMouse;

            newMousePos = new Vector2(newMouse.Position.X, newMouse.Position.Y);
            oldMousePos = new Vector2(newMouse.Position.X, newMouse.Position.Y);
            firstMousePos = new Vector2(newMouse.Position.X, newMouse.Position.Y);

            GetMouseAndAdjust();
        }

        public void Update() {
            GetMouseAndAdjust();

            if(newMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && oldMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released) {
                firstMouse = newMouse;
                firstMousePos = newMousePos = GetScreenPos(firstMouse);
            }
        }

        public static float GetDistance(Vector2 pos, Vector2 target) {
            return (float)Math.Sqrt(Math.Pow(pos.X - target.X, 2) + Math.Pow(pos.Y - target.Y, 2));
        }

        public void UpdateOld() {
            oldMouse = newMouse;
            oldMousePos = GetScreenPos(oldMouse);
        }

        public virtual float GetDistanceFromClick() {
            return GetDistance(newMousePos, firstMousePos);
        }

        public virtual void GetMouseAndAdjust() {
            newMouse = Mouse.GetState();
            newMousePos = GetScreenPos(newMouse);
        }

        public int GetMouseWheelChange() {
            return newMouse.ScrollWheelValue - oldMouse.ScrollWheelValue;
        }


        public Vector2 GetScreenPos(MouseState MOUSE) {
            Vector2 tempVec = new Vector2(MOUSE.Position.X, MOUSE.Position.Y);

            return tempVec;
        }

        public virtual bool LeftClick() {
            if( newMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && oldMouse.LeftButton != Microsoft.Xna.Framework.Input.ButtonState.Pressed && newMouse.Position.X >= 0 && newMouse.Position.X <= Globals.screenWidth && newMouse.Position.Y >= 0 && newMouse.Position.Y <= Globals.screenHeight) {
                return true;
            }

            return false;
        }

        public virtual bool LeftClickHold() {
            bool holding = false;

            if( newMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && oldMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && newMouse.Position.X >= 0 && newMouse.Position.X <= Globals.screenWidth && newMouse.Position.Y >= 0 && newMouse.Position.Y <= Globals.screenHeight) {
                holding = true;

                if(Math.Abs(newMouse.Position.X - firstMouse.Position.X) > 8 || Math.Abs(newMouse.Position.Y - firstMouse.Position.Y) > 8) {
                    dragging = true;
                }
            }

            return holding;
        }

        public virtual bool LeftClickRelease() {
            if(newMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released && oldMouse.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed) {
                dragging = false;
                return true;
            }

            return false;
        }

        public virtual bool RightClick() {
            if(newMouse.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && oldMouse.RightButton != Microsoft.Xna.Framework.Input.ButtonState.Pressed && newMouse.Position.X >= 0 && newMouse.Position.X <= Globals.screenWidth && newMouse.Position.Y >= 0 && newMouse.Position.Y <= Globals.screenHeight) {
                return true;
            }

            return false;
        }

        public virtual bool RightClickHold() {
            bool holding = false;

            if( newMouse.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && oldMouse.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed && newMouse.Position.X >= 0 && newMouse.Position.X <= Globals.screenWidth && newMouse.Position.Y >= 0 && newMouse.Position.Y <= Globals.screenHeight) {
                holding = true;

                if(Math.Abs(newMouse.Position.X - firstMouse.Position.X) > 8 || Math.Abs(newMouse.Position.Y - firstMouse.Position.Y) > 8) {
                    rightDrag = true;
                }
            }

            return holding;
        }

        public virtual bool RightClickRelease() {
            if( newMouse.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Released && oldMouse.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed) {
                dragging = false;
                return true;
            }

            return false;
        }

        public MouseState First {
            get { return firstMouse; }
        }

        public MouseState New {
            get { return newMouse; }
        }

        public MouseState Old {
            get { return oldMouse; }
        }
    }
}
