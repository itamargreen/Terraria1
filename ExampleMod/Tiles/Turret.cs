using System;
using System.Threading;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExampleMod.Tiles {
public class Turret : ModTile
{
    float R = 1f;
    float G = 1f;
    float B = 1f;
    public override void SetDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        Main.tileLighted[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
        TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18, 16, 18 };
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleHorizontal = true;
        
        TileObjectData.addTile(Type);
        
        mapColor = new Color(200, 200, 200);
        
    }
    public static int cooldown = 0;    
    public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
    {
        r = R;
        g = G;
        b = B;
    }
    
    public Vector2 tileCoords;
    public Vector2 worldCoords
    {
        get { return new Vector2(tileCoords.X * 16f, tileCoords.Y * 16f); }
    }

    public override bool Autoload(ref string name, ref string texture) // Makes sure the builder does not look for a visual
    {
        return true;
    }

    
    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        tileCoords = new Vector2(i, j);

        
        num = 1;
    }

    public override bool CreateDust(int i, int j, ref int type)
    {
        ModDust.NewDust(new Vector2(i, j) * 16f, 16, 16, mod, "Sparkle");
        return false;
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        Item.NewItem(i * 16, j * 16, 32, 48, mod.ItemType("TurretItem"));
    }
    public override void HitWire(int i, int j)
    {
        cooldown++;
        NPC[] npc = Main.npc;
        Vector2 pos = new Vector2(i, j) * 16f;
        
        for (int k = 0; k < 200; k++)
        {
            if (!npc[k].friendly && npc[k].active && npc[k].lifeMax > 5 && !npc[k].boss)
            {
                Vector2 enemy = npc[k].position;
                Vector2 toEnemy = Vector2.Subtract(enemy, pos);

                if (Main.rand.Next(5) == 0)
                {
                    ModDust.NewDust(enemy, 16, 16, mod, "Sparkle");
                }
                float dist = Vector2.Distance(enemy, pos);

                if (dist < 750f)
                {
                    if (cooldown > 15)
                    {
                        cooldown = 0;
                        int proj = Projectile.NewProjectile(pos.X, pos.Y - 32f, 0, 0, mod.ProjectileType("Friend"), npc[k].lifeMax/10, 10f, Main.myPlayer, enemy.X, enemy.Y);
                    }
                }

            }
            else if (!npc[k].friendly && npc[k].active && npc[k].lifeMax > 5 && npc[k].boss)
            {
                Vector2 enemy = npc[k].position;
                Vector2 toEnemy = Vector2.Subtract(enemy, pos);

                if (Main.rand.Next(5) == 0)
                {
                    ModDust.NewDust(enemy, 16, 16, mod, "Sparkle");
                }
                float dist = Vector2.Distance(enemy, pos);

                if (dist < 500f)
                {

                    int proj = Projectile.NewProjectile(pos.X, pos.Y - 32f, 0, 0, mod.ProjectileType("Friend"), 50, 10f, Main.myPlayer, enemy.X, enemy.Y);
                }

            }
        }
            
    }
    
}}