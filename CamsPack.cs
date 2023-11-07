using MelonLoader;
using BTD_Mod_Helper;
using CamsPack;
using Il2CppAssets.Scripts.Models.Towers;
using PathsPlusPlus;

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