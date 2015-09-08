using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ExampleMod.Items.Placeable{
public class TurretItem : ModItem
{
    public override void SetDefaults()
    {
        item.name = "Turret";
        item.width = 36;
        item.height = 54;
        item.maxStack = 999;
        item.mech = true;
        item.useTurn = true;
        item.autoReuse = true;
        item.useAnimation = 15;
        item.useTime = 10;
        item.useStyle = 1;
        item.consumable = true;
        item.value = 2000;
        item.createTile = mod.TileType("Turret");
    }

    public override void AddRecipes()
    {
        ModRecipe recipe = new ModRecipe(mod);
        
        recipe.AddIngredient(null, "ExampleBlock", 10);
        
        recipe.SetResult(this);
        recipe.AddRecipe();
    }
}}