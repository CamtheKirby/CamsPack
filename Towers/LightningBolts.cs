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

[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace LightningBolts;


public class LightningBolts : ModTower
{
    public override TowerSet TowerSet => TowerSet.Support;
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
        towerModel.GetAttackModel().weapons[0].projectile = Game.instance.model.GetTower(TowerType.Druid, 2, 0, 0).GetAttackModel().weapons[0].projectile.Duplicate();
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = 0;
        towerModel.GetAttackModel().weapons[0].rate *= .3f;
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 5;
        towerModel.GetAttackModel().range = 50;
        towerModel.range = 50;
        towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel", true));
        towerModel.towerSelectionMenuThemeId = "Camo";
        towerModel.GetAttackModel().weapons[0].projectile.pierce = 35;
    }

    public override string Get2DTexture(int[] tiers)
    {
        return "LBDisplay";
    }
}


