using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExampleMod.Mounts {
public class Car : ModMountData
{
        public int cool = 0;
    public override void SetDefaults()
    {
        mountData.spawnDust = 57;
        mountData.buff = 118;
        mountData.heightBoost = 20;
        mountData.fallDamage = 0.5f;
        mountData.runSpeed = 11f;
        mountData.dashSpeed = 8f;
        mountData.flightTimeMax = 0;
        mountData.fatigueMax = 0;
        mountData.jumpHeight = 5;
        mountData.acceleration = 0.19f;
        mountData.jumpSpeed = 4f;
        mountData.blockExtraJumps = false;
        mountData.totalFrames = 4;
        mountData.constantJump = true;
        int[] array = new int[mountData.totalFrames];
        for (int l = 0; l < array.Length; l++)
        {
            array[l] = 20;
        } 
        mountData.playerYOffsets = array;
        mountData.xOffset = 13;
        mountData.bodyFrame = 3;
        mountData.yOffset = -12;
        mountData.playerHeadOffset = 22;
        mountData.standingFrameCount = 4;
        mountData.standingFrameDelay = 12;
        mountData.standingFrameStart = 0;
        mountData.runningFrameCount = 4;
        mountData.runningFrameDelay = 12;
        mountData.runningFrameStart = 0;
        mountData.flyingFrameCount = 0;
        mountData.flyingFrameDelay = 0;
        mountData.flyingFrameStart = 0;
        mountData.inAirFrameCount = 1;
        mountData.inAirFrameDelay = 12;
        mountData.inAirFrameStart = 0;
        mountData.idleFrameCount = 4;
        mountData.idleFrameDelay = 12;
        mountData.idleFrameStart = 0;
        mountData.idleFrameLoop = true;
        mountData.swimFrameCount = mountData.inAirFrameCount;
        mountData.swimFrameDelay = mountData.inAirFrameDelay;
        mountData.swimFrameStart = mountData.inAirFrameStart;
        if (Main.netMode != 2)
        {
            mountData.textureWidth = mountData.backTexture.Width + 20;
            mountData.textureHeight = mountData.backTexture.Height;
        }
    }

    public override void UpdateEffects(Player player)
    {
        if (Math.Abs(player.velocity.X) > 4f)
        {
            Rectangle rect = player.getRect();
            int dust = ModDust.NewDust(new Vector2(rect.X, rect.Y), rect.Width, rect.Height, mod, "Smoke");
        }
    }
    public override bool UpdateFrame(Player player, int state, Vector2 velocity)
        {
            cool++;
            Vector2 position = Main.screenPosition;
            position.X += Main.mouseX;
            position.Y += Main.mouseY;
            Vector2 vector = Vector2.Subtract(position,player.position);
            if (velocity.Length() > 2f)
            {
                player.gravity = 0;
            }
            else
            {
                player.gravity = Player.defaultGravity;
            }
            if(cool > 60)
            {
                Main.NewText("X: "+vector.X +"  y: "+vector.Y);
                
            }

            player.position.Y += vector.Y > 5f ? 2.5f : vector.Y / 2;
            player.position.X += vector.X > 5f * player.direction ? 2.5f * player.direction : vector.X / 2;
            //vector = Vector2.Normalize(vector);
            //if (cool > 60)
            //{
            //    Main.NewText("X: " + vector.X + "  y: " + vector.Y);
            //    cool = 0;
            //}
            //player.position.Y += vector.Y * 2f;
            //player.position.X += vector.X;

            return true;
        }
}}