using MelonLoader;
using BTD_Mod_Helper;
using CamsPack;
using Il2CppAssets.Scripts.Models.Towers;
using PathsPlusPlus;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Api.Towers;
using System.Collections.Generic;
[assembly: MelonInfo(typeof(CamsPack.CamsPack), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace CamsPack;

public class CamsPack : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<CamsPack>("CamsPack loaded! Why are you reading this?");

    }
}

public class CamsTowers : ModTowerSet
{
    public override string DisplayName => "Cams Towers";
    public int GetTowerSetIndex(List<string> towerSets)
    {
        return towerSets.IndexOf("Magic");
    }
}


public class KirbyTowers : ModTowerSet
{
    public override string DisplayName => "Kirby Towers";
    public int GetTowerSetIndex(List<string> towerSets)
    {
        return towerSets.IndexOf("Magic");
    }
}

public class BfdiTowers : ModTowerSet
{
    public override string DisplayName => "Object Show Towers";
    public int GetTowerSetIndex(List<string> towerSets)
    {
        return towerSets.IndexOf("Magic");
    }
}


public class JokeTowers : ModTowerSet
{
    public override string DisplayName => "Joke Towers";
    public int GetTowerSetIndex(List<string> towerSets)
    {
        return towerSets.IndexOf("Primary");
    }
}

public class YoutubeTowers : ModTowerSet
{
    public override string DisplayName => "Youtube Towers";
    public int GetTowerSetIndex(List<string> towerSets)
    {
        return towerSets.IndexOf("Magic");
    }
}


public class Settings : ModSettings
{
   /* public static readonly ModSettingBool Crosspath = new(false)
    {
        displayName = "Ultimate Crosspathing",
        description = "If you want ultimate crosspathing to be applied to every tower (RESTART GAME TO APPLY)",
        requiresRestart = true,
        button = true,
    }; */
    public static readonly ModSettingBool OpTowers = new(true)
    {
        displayName = "Op Towers",
        description = "If you want OP Towers or not (RESTART GAME TO APPLY)",
        requiresRestart = true,
        button = true,
    };
    public static readonly ModSettingBool UselessTowers = new(true)
    {
        displayName = "Useless Towers",
        description = "If you want useless towers or not(RESTART GAME TO APPLY)",
        requiresRestart = true,
        button = true,
    };
    public static readonly ModSettingBool UnfinshedTowers = new(false)
    {
        displayName = "Unfinshed Towers",
        description = "If you want unfinshed towers towers or not (RESTART GAME TO APPLY)",
        requiresRestart = true,
        button = true,
    };
}

public class BananaGunPath : PathPlusPlus
{
    public override string Tower => TowerType.BananaFarm;
    public override int UpgradeCount => 5;
}

public class SabrePath : PathPlusPlus
{
    public override string Tower => TowerType.BananaFarm;
    public override int UpgradeCount => 5;
}

public class WaddledeeMiddlePath : PathPlusPlus
{
    public override string Tower => ModContent.TowerID<WaddleDee.WaddleDee>(0, 0, 0);
    public override int ExtendVanillaPath => 1;
    public override int UpgradeCount => 6;
}

public class WaddledeeTopPath : PathPlusPlus
{
    public override string Tower => TowerID<WaddleDee.WaddleDee>(0, 0, 0);
    public override int ExtendVanillaPath => 0;
    public override int UpgradeCount => 7;
}

public class TGForthPath : PathPlusPlus
{
    public override string Tower => TowerID<TGMonkey.ThanksgivingMonkey>(0, 0, 0);
    public override int UpgradeCount => 6;
}