using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using MelonLoader;
using PathsPlusPlus;
using CamsPack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using System;

[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace WaddleDee.BottomPath;

public class what : ModUpgrade<WaddleDee>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 1;
    public override int Cost => 300;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Waddle Dee Gets More Pierce";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.pierce += 10;
    }
}


