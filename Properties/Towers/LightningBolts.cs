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
using System;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using System.Collections.Generic;
using System.Linq;
using Il2Cpp;

[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace LightningBolts;


public class LightningBolts : ModTower<CamsPack.CamsTowers>
{
//    public override TowerSet TowerSet => TowerSet.Support;
    public override string BaseTower => TowerType.DartMonkey;
    public override int Cost => 2450;
    public override int TopPathUpgrades => 0;
    public override int MiddlePathUpgrades => 0;
    public override int BottomPathUpgrades => 0;
    public override string Description => "Place a lighting tower to strike out bloons on the screen.";

    public override bool Use2DModel => true;
    public override string Icon => "LBIcon";

    public override string Portrait => "LBIcon";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile = Game.instance.model.GetTower(TowerType.Druid, 2, 0, 0).GetAttackModel().weapons[1].projectile.Duplicate();
        attackModel.weapons[0].rate *= .5f;
        attackModel.weapons[0].projectile.GetDamageModel().damage = 5;
        attackModel.range = 50;
        towerModel.range = 50;
        towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel", true));
        towerModel.towerSelectionMenuThemeId = "Camo";
        attackModel.weapons[0].projectile.pierce = 35;
    }
    public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
    {
        return towerSet.First(model => model.towerId == TowerType.GlueGunner).towerIndex + 1;
    }
    public override string Get2DTexture(int[] tiers)
    {
        return "LBDisplay";
    }
}


