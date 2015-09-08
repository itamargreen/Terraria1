using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExampleMod.Tiles {
public class ExampleWorkbench : ModTile
{
    public override void SetDefaults()
    {
        Main.tileSolidTop[Type] = true;
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileTable[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
        TileObjectData.newTile.CoordinateHeights = new int[]{18};
        TileObjectData.addTile(Type);
        AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
        mapColor = new Color(200, 200, 200);
        mapName = "Example Workbench";
        adjTiles = new int[]{TileID.WorkBenches};
    }

    public override void NumDust(int i, int j, bool fail, ref int num)
    {
        num = fail ? 1 : 3;
    }

    public override bool CreateDust(int i, int j, ref int type)
    {
        ModDust.NewDust(new Vector2(i, j) * 16f, 16, 16, mod, "Sparkle");
        return false;
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("ExampleWorkbench"));
    }
}}