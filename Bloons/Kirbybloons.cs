using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Scenarios;
using BTD_Mod_Helper.Extensions;
using CamsPack;
using Il2Cpp;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Difficulty;
using Il2CppAssets.Scripts.Models.Rounds;
using MelonLoader;
using System;
using UnityEngine.UIElements;

[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace Kirbybloons;

public class Kirbyb : ModBloon
{
    public override string BaseBloon => BloonType.Pink;


    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.speed *= 1.5f;
        bloonModel.speedFrames *= 1.5f;

        bloonModel.overlayClass = BloonOverlayClass.Pink;

        bloonModel.maxHealth = 8;
        bloonModel.leakDamage = 10;
     

        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonType.Pink);
        bloonModel.AddToChildren(BloonType.PinkCamo);
        bloonModel.AddToChildren(BloonType.PinkRegrow);
        bloonModel.AddToChildren(BloonType.PinkRegrowCamo);

        bloonModel.hasChildrenWithDifferentTotalHealths = true;
        bloonModel.distributeDamageToChildren = false;
    }
}

public class MetaKnightb : ModBloon
{
    public override string BaseBloon => BloonType.Blue;


    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.speed *= 1.1f;
        bloonModel.speedFrames *= 1.1f;

        bloonModel.overlayClass = BloonOverlayClass.Blue;

        bloonModel.maxHealth = 25;
        bloonModel.leakDamage = 30;
     


        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonType.Yellow);
        bloonModel.AddToChildren(BloonType.Yellow);
        bloonModel.AddToChildren(BloonType.Red);
        bloonModel.AddToChildren(BloonType.Lead);
        bloonModel.AddToChildren(BloonType.Blue);
        bloonModel.AddToChildren(BloonType.PurpleRegrow);

        bloonModel.hasChildrenWithDifferentTotalHealths = true;
        bloonModel.distributeDamageToChildren = false;
    }
}

public class MetaKnightbCamo : ModBloon<MetaKnightb>
{
    public override bool Camo => true;
    public override string Icon => "MetaKnightb";

    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.MakeChildrenCamo();
    }
}

public class Kingdededeb : ModBloon
{
    public override string BaseBloon => BloonType.Yellow;


    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.speed *= 0.2f;
        bloonModel.speedFrames *= 0.2f;

        bloonModel.overlayClass = BloonOverlayClass.Yellow;

        bloonModel.maxHealth = 100;
        bloonModel.leakDamage = 85;



        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonType.Yellow);
        bloonModel.AddToChildren(BloonType.YellowRegrow);
        bloonModel.AddToChildren(BloonType.Red);
        bloonModel.AddToChildren(BloonType.BlackRegrow);
        bloonModel.AddToChildren(BloonType.Blue);
        bloonModel.AddToChildren(BloonType.WhiteRegrow);
        bloonModel.AddToChildren(BloonType.WhiteRegrow);

        bloonModel.hasChildrenWithDifferentTotalHealths = true;
        bloonModel.distributeDamageToChildren = false;
    }
}

public class Waddledeeb : ModBloon
{
    public override string BaseBloon => BloonType.Pink;


    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.speed *= 1.7f;
        bloonModel.speedFrames *= 1.7f;

        bloonModel.overlayClass = BloonOverlayClass.Pink;

        bloonModel.maxHealth = 2;
        bloonModel.leakDamage = 3;



        bloonModel.RemoveAllChildren();
        

        bloonModel.hasChildrenWithDifferentTotalHealths = true;
        bloonModel.distributeDamageToChildren = false;
    }
}

public class Waddledoob : ModBloon<Waddledeeb>
{
    public override bool Camo => true;
    public override string Icon => "Waddledoob";

    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.MakeChildrenCamo();
    }
}

public class GalactaKnightb : ModBloon
{
    public override string BaseBloon => BloonType.Yellow;

   
    public override void ModifyBaseBloonModel(BloonModel bloonModel)
    {
        bloonModel.speed *= 2.1f;
        bloonModel.speedFrames *= 2.1f;

        bloonModel.overlayClass = BloonOverlayClass.Yellow;

        bloonModel.maxHealth = 125;
        bloonModel.leakDamage = 140;



        bloonModel.RemoveAllChildren();
        bloonModel.AddToChildren(BloonType.Pink);
        bloonModel.AddToChildren(BloonType.PinkRegrow);
        bloonModel.AddToChildren(BloonType.White);
        bloonModel.AddToChildren(BloonType.PinkRegrowCamo);
        bloonModel.AddToChildren(BloonType.YellowRegrowCamo);
        bloonModel.AddToChildren(BloonType.LeadRegrow);
        bloonModel.AddToChildren(BloonType.LeadRegrowCamo);
        bloonModel.AddToChildren(BloonType.PurpleCamo);

        bloonModel.hasChildrenWithDifferentTotalHealths = true;
        bloonModel.distributeDamageToChildren = false;
    }
}