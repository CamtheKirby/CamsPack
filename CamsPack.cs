using MelonLoader;
using BTD_Mod_Helper;
using CamsPack;
using Il2CppAssets.Scripts.Models.Towers;
using PathsPlusPlus;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Api.ModOptions;

[assembly: MelonInfo(typeof(CamsPack.CamsPack), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace CamsPack;

public class CamsPack : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<CamsPack>("CamsTowerPack loaded! Why are you reading this?");
    }
}

public class Settings : ModSettings
{
    public static readonly ModSettingBool OpTowers = new(true)
    {
        displayName = "Op Towers",
        description = "If you want OP Towers or not (Shadow Kirby) (RESTART GAME TO APPLY)",
        button = true,
    };
    public static readonly ModSettingBool UselessTowers = new(true)
    {
        displayName = "Useless Towers",
        description = "If you want useless towers or not (Sleepy Monkey) (RESTART GAME TO APPLY)",
        button = true,
    };
    public static readonly ModSettingBool UnfinshedTowers = new(false)
    {
        displayName = "Unfinshed Towers",
        description = "If you want unfinshed towers towers or not (Sand Monekey) (RESTART GAME TO APPLY)",
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
    public override string Tower => ModContent.TowerID<WaddleDee.WaddleDee>(0, 0, 0);
    public override int ExtendVanillaPath => 0;
    public override int UpgradeCount => 7;
}