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

namespace WaddleDee.TopPath;

public class SpearDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "SpearDisplay");
    }
}

public class SpearTraining : UpgradePlusPlus<WaddledeeTopPath>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Tier => 6;
    public override int Cost => 950000;
    public override string Container => UpgradeContainerDiamond;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "The Traning Makes Bandana Dee Stronger";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.pierce += 35;
        attackModel.weapons[0].projectile.GetDamageModel().damage += 10;
        attackModel.range += 20;
        towerModel.range += 20;

       
        foreach (var attacks in towerModel.GetAttackModels())
        {
            if (attacks.name.Contains("SpearDee"))
            {
                attackModel.range += 20;
                towerModel.range += 20;
                attacks.weapons[0].projectile.GetDamageModel().damage += 105;
                attacks.weapons[0].projectile.pierce += 305;
            }

        }
    }

    public class SpearMaster : UpgradePlusPlus<WaddledeeTopPath>
    {
        // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
        // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
        public override string Portrait => "LuigiIcon";
        public override int Tier => 7;
        public override int Cost => 1200000;

        public override string Container => UpgradeContainerRainbow;

        // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

        public override string Description => "The One Who Holds The Spears";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            attackModel.weapons[0].projectile.pierce += 1000;
            attackModel.weapons[0].projectile.GetDamageModel().damage += 1000;
            attackModel.range += 20;
            towerModel.range += 20;

            var Spears = Game.instance.model.GetTowerFromId("MonkeySub-021").GetAttackModel().Duplicate();
            Spears.range = towerModel.range;
            Spears.name = "Spears_Weapon";
            Spears.weapons[0].projectile.ApplyDisplay<SpearDisplay>();
            towerModel.AddBehavior(Spears);
            Spears.weapons[0].rate *= .4f;
            Spears.weapons[0].emission = new ArcEmissionModel("ArcEmissionModel_", 3, 0, 20, null, false, false);

            foreach (var attacks in towerModel.GetAttackModels())
            {
                if (attacks.name.Contains("SpearDee"))
                {
                    attacks.weapons[0].projectile.GetDamageModel().damage += 5000;
                    attacks.weapons[0].projectile.pierce += 5000;
                    attackModel.range += 20;
                    towerModel.range += 20;
                }

            }
        }
    }
}


