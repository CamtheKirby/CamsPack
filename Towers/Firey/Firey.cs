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
using MaxLevelIdot;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Models.Towers.Filters;

[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace Firey;

public class FireFDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "FireDisplay");
    }
}

public class FireFMDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "FireMDisplay");
    }
}

public class FireFGDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "FireGDisplay");
    }
}

public class LaserDisplay : ModDisplay
{
    public override string BaseDisplay => "7c001a7fcad3c6d48b14aacba03a98bc";
}

public class FJDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "FirejrDisplay");
    }
}
public class FJMDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "FirejrMDisplay");
    }
}

public class FJGDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "FirejrGDisplay");
    }
}



public class Laser2Display : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "Laser2Display");
    }
}
public class FSB : ModTower<CamsPack.BfdiTowers>
{
    public override string Portrait => "FireyBoxlcon";
    public override string Name => "Firey Speaker Box";
    public override string BaseTower => "DartMonkey-202";

    public override bool DontAddToShop => true;
    public override int Cost => 0;
    public override bool Use2DModel => true;
    public override int TopPathUpgrades => 0;
    public override int MiddlePathUpgrades => 0;
    public override int BottomPathUpgrades => 0;


    public override string DisplayName => "Firey Speaker Box";
    public override string Description => "";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        towerModel.isSubTower = true;
        towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 20f, 1, false, false));
        attackModel.weapons[0].projectile.GetDamageModel().damage = 10;
        attackModel.weapons[0].rate = 2;
        attackModel.weapons[0].projectile.ApplyDisplay<LaserDisplay>();
    }
    public override string Get2DTexture(int[] tiers)
    {
        return "FireyBoxDisplay";
    }
}

public class FSBG : ModTower<CamsPack.BfdiTowers>
{
    public override string Portrait => "FireyBoxGlcon";
    public override string Name => " Giant Firey Speaker Box";
    public override string BaseTower => "DartMonkey-302";

    public override bool DontAddToShop => true;
    public override int Cost => 0;

    public override int TopPathUpgrades => 0;
    public override int MiddlePathUpgrades => 0;
    public override int BottomPathUpgrades => 0;
    public override bool Use2DModel => true;

    public override string DisplayName => "Firey Speaker Box";
    public override string Description => "";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        towerModel.isSubTower = true;
        towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 40f, 1, false, false));
        attackModel.weapons[0].projectile.GetDamageModel().damage = 85;
        attackModel.weapons[0].rate = 0.7f;
        attackModel.weapons[0].projectile.ApplyDisplay<Laser2Display>();
    }
    public override string Get2DTexture(int[] tiers)
    {
        return "FireyBoxGDisplay";
    }
}



public class Firey : ModTower<CamsPack.BfdiTowers>
{
   // public override TowerSet TowerSet => TowerSet.Magic;
    public override string BaseTower => TowerType.DartMonkey;
    public override int Cost => 780;
    public override int TopPathUpgrades => 5;
    public override int MiddlePathUpgrades => 5;
    public override int BottomPathUpgrades => 5;
    public override string Description => "Firey from BFDI pops some bloons! (Watch BFDI to understand this tower)";

    public override bool Use2DModel => true;
    public override string Icon => "FireyIcon";
    public override ParagonMode ParagonMode => ParagonMode.Base555;
    public override string Portrait => "FireyIcon2";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var projectile = attackModel.weapons[0].projectile;
        attackModel.weapons[0].projectile = Game.instance.model.GetTower(TowerType.WizardMonkey, 0, 1, 0).GetAttackModel().weapons[0].projectile.Duplicate();
        attackModel.weapons[0].projectile.GetDamageModel().damage = 2;
        attackModel.weapons[0].projectile.ApplyDisplay<FireFDisplay>();
        attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties &= ~BloonProperties.Lead;
        var Fire = Game.instance.model.GetTower(TowerType.MortarMonkey, 0, 0, 2).GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetBehavior<AddBehaviorToBloonModel>();
        attackModel.weapons[0].projectile.AddBehavior(Fire);
        attackModel.weapons[0].projectile.collisionPasses = new[] { -1, 0 };
    }
    public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
    {
        return towerSet.First(model => model.towerId == TowerType.Druid).towerIndex + 1;
    }

    public override string Get2DTexture(int[] tiers)
    {
        if (tiers[2] == 4)
        {
            return "FireyMDisplay";
        }
        if (tiers[2] == 5)
        {
            return "FireyGDisplay";
        }
        return "FireyDisplay";
    }
}

public class BetterFire : ModUpgrade<Firey>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 1;
    public override int Cost => 215;
    public override string Description => "His Fire gets +3 pierce and attacks faster";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].rate -= 0.2f;
        attackModel.weapons[0].projectile.pierce += 3;
    }
}

public class BiggerFlames : ModUpgrade<Firey>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 2;
    public override int Cost => 800;
    public override string Description => "His Fire gets bigger, +1 damage, and gets +2 pierce";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.GetDamageModel().damage += 1;
        attackModel.weapons[0].projectile.pierce += 2;
        attackModel.weapons[0].projectile.scale *= 2;
    }
}
public class HomingFlames : ModUpgrade<Firey>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 3;
    public override int Cost => 2760;
    public override string Description => "His Fire now seek and gets +4 pierce and +2 Damage";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var projectile = attackModel.weapons[0].projectile;
        attackModel.weapons[0].projectile.pierce += 4;
        attackModel.weapons[0].projectile.GetDamageModel().damage += 2;
        projectile.AddBehavior(new TrackTargetModel("Testname", 9999999, true, false, 144, false, 300, false, true));
    }
}

public class EndlessFlames : ModUpgrade<Firey>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 4;
    public override int Cost => 3300;
    public override string Description => "He Fires Nonstop Flames if the bloons get close";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var EF = Game.instance.model.GetTowerFromId("HotSauceCreatureTowerV2").GetAttackModel().Duplicate();
        EF.range = Game.instance.model.GetTower(TowerType.Sauda).range;
        EF.range = Game.instance.model.GetTower(TowerType.Sauda).GetAttackModel().range;
        EF.name = "Firey_Weapon";
        towerModel.AddBehavior(EF);
    }
}

public class ForestFire : ModUpgrade<Firey>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 5;
    public override int Cost => 35000;
    public override string Description => "That's a LOT of fire";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.scale *= 2;
        attackModel.weapons[0].projectile.pierce += 10;
        attackModel.weapons[0].projectile.GetDamageModel().damage += 15;
        attackModel.weapons[0].rate -= 0.4f;
        foreach (var attacks in towerModel.GetAttackModels())
        {
            if (attacks.name.Contains("Firey_Weapon"))
            {
                attacks.weapons[0].projectile.GetDamageModel().damage += 5;
                attacks.range = 40;
            }
        }
    }

    public class FartherThrowing : ModUpgrade<Firey>
    {
        public override string Portrait => "LuigiIcon";
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 210;
        public override string Description => "He gets more range and +1 pierce";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            attackModel.range += 15;
            towerModel.range += 15;
            attackModel.weapons[0].projectile.pierce += 1;
        }
    }

    public class Slap : ModUpgrade<Firey>
    {
        public override string Portrait => "LuigiIcon";
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 2763;
        public override string Description => "The Slaps Knockbacks the bloons and gets more range, +1 Pierce and can hit camos";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var Knockback = Game.instance.model.GetTowerFromId("NinjaMonkey-010").GetWeapon().projectile.GetBehavior<WindModel>().Duplicate<WindModel>();
            Knockback.chance = 0.5f;
            Knockback.distanceMin = 25;
            Knockback.distanceMax = 50;
            Knockback.name = "Firey2_Weapon";
            var attackModel = towerModel.GetAttackModel();
            attackModel.weapons[0].projectile.AddBehavior(Knockback);
            attackModel.range += 10;
            towerModel.range += 10;
            attackModel.weapons[0].projectile.pierce += 1;
            towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel", true));

        }
    }
    public class SlapMaster : ModUpgrade<Firey>
    {
        public override string Portrait => "LuigiIcon";
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override int Cost => 5763;
        public override string Description => "The Slaps get more powerful.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var Knockback2 = Game.instance.model.GetTowerFromId("NinjaMonkey-010").GetWeapon().projectile.GetBehavior<WindModel>().Duplicate<WindModel>();
            Knockback2.chance = 0.7f;
            Knockback2.distanceMin = 50;
            Knockback2.distanceMax = 65;
            Knockback2.name = "Firey3_Weapon";
            var attackModel = towerModel.GetAttackModel();
            attackModel.weapons[0].projectile.AddBehavior(Knockback2);
            foreach (var attacks in towerModel.GetAttackModels())
            {
                if (attacks.name.Contains("Firey2_Weapon"))
                {
                    attacks.RemoveBehavior<AttackModel>();
                }
            }
        }

    }

    public class BackupSpeakerBox : ModUpgrade<Firey>
    {
        public override string Portrait => "LuigiIcon";
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override int Cost => 10500;
        public override string Description => "Firey gets his Speaker Box to attack the bloons with a slow high damage laser attack.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var minonF = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModels()[1].Duplicate();
            minonF.range = towerModel.range;
            minonF.name = "Minon_Weapon";
            minonF.weapons[0].Rate = 35;
            minonF.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            minonF.weapons[0].projectile.AddBehavior(new CreateTowerModel("FSBplace", GetTowerModel<FSB>().Duplicate(), 0f, true, false, false, true, true));
            towerModel.AddBehavior(minonF);
        }

        public class MegaSpeakerBox : ModUpgrade<Firey>
        {
            public override string Portrait => "LuigiIcon";
            public override int Path => MIDDLE;
            public override int Tier => 5;
            public override int Cost => 45000;
            public override string Description => "Firey Spawns his Speaker Box faster and a Mega Speaker Box every 45 seconds.";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var Ability = Game.instance.model.GetTower(TowerType.BombShooter, 0, 4, 0).GetAbilities()[0].Duplicate();

                AttackModel[] support = { Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModels()[1].Duplicate()};
                support[0].weapons[0].projectile.RemoveBehavior<CreateTowerModel>();

                support[0].weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTowerInAbility", GetTowerModel<FSBG>(), 0, true, false, false, true, false));
                support[0].weapons[0].projectile.display = new() { guidRef = "" };

                Ability.GetBehavior<ActivateAttackModel>().attacks = support;
                Ability.maxActivationsPerRound = 9999999;
                Ability.canActivateBetweenRounds = true;
                Ability.resetCooldownOnTierUpgrade = true;
                Ability.cooldown = 45;
                Ability.icon = GetSpriteReference("FireyBoxGlcon");

                towerModel.AddBehavior(Ability);

                foreach (var attacks in towerModel.GetAttackModels())
                {
                    if (attacks.name.Contains("Minon_Weapon"))
                    {
                        attacks.weapons[0].Rate = 23;
                    }
                }
            }

        }

        public class LongFire : ModUpgrade<Firey>
        {
            public override string Portrait => "LuigiIcon";
            public override int Path => BOTTOM;
            public override int Tier => 1;
            public override int Cost => 320;
            public override string Description => "Gets +20 range";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();
                attackModel.range += 20;
                towerModel.range += 20;
            }
        }

        public class EvenLongerFire : ModUpgrade<Firey>
        {
            public override string Portrait => "LuigiIcon";
            public override int Path => BOTTOM;
            public override int Tier => 2;
            public override int Cost => 640;
            public override string Description => "Gets +20 range again and can see camo";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();
                attackModel.range += 20;
                towerModel.range += 20;
                towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel", true));
            }
        }

        public class FireyJr : ModUpgrade<Firey>
        {
            public override string Portrait => "LuigiIcon";
            public override int Path => BOTTOM;
            public override int Tier => 3;
            public override int Cost => 640;
            public override string Description => "Fires Firey Jrs Everywhere";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
               var FJ = Game.instance.model.GetTowerFromId("TackShooter-300").GetAttackModel().Duplicate();
               FJ.name = "FJ_Weapon";
               FJ.weapons[0].projectile.ApplyDisplay<FJDisplay>();
               towerModel.AddBehavior(FJ);
               var Fire = Game.instance.model.GetTower(TowerType.MortarMonkey, 0, 0, 2).GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetBehavior<AddBehaviorToBloonModel>();
                FJ.weapons[0].projectile.AddBehavior(Fire);
            }
        }
        public class YoyleBerry : ModUpgrade<Firey>
        {
            public override string Portrait => "LuigiIcon";
            public override int Path => BOTTOM;
            public override int Tier => 4;
            public override int Cost => 10000;
            public override string Description => "Turns him into metal and adds x5 for price and damage and attacks faster";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();
                attackModel.weapons[0].projectile.pierce *= 5;
                attackModel.weapons[0].projectile.GetDamageModel().damage *= 5;
                attackModel.weapons[0].rate -= 0.4f;
                attackModel.weapons[0].projectile.ApplyDisplay<FireFMDisplay>();
                foreach (var attacks in towerModel.GetAttackModels())
                {
                    if (attacks.name.Contains("FJ_Weapon"))
                    {
                        attacks.weapons[0].projectile.ApplyDisplay<FJMDisplay>();
                        attacks.weapons[0].projectile.pierce *= 5;
                        attacks.weapons[0].projectile.GetDamageModel().damage *= 5;
                        attacks.weapons[0].rate -= 0.4f;
                    }
                }
            }
        }

        public class Golden : ModUpgrade<Firey>
        {
            public override string Portrait => "LuigiIcon";
            public override int Path => BOTTOM;
            public override int Tier => 5;
            public override int Cost => 350000;
            public override string Description => "The golden firey..";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();
                attackModel.weapons[0].projectile.pierce *= 10;
                attackModel.weapons[0].projectile.GetDamageModel().damage *= 4;
            //    attackModel.weapons[0].rate -= 0.3f;
                attackModel.weapons[0].projectile.ApplyDisplay<FireFGDisplay>();
                foreach (var attacks in towerModel.GetAttackModels())
                {
                    if (attacks.name.Contains("FJ_Weapon"))
                    {
                        attacks.weapons[0].projectile.ApplyDisplay<FJGDisplay>();
                        attacks.weapons[0].projectile.pierce *= 5;
                        attacks.weapons[0].projectile.GetDamageModel().damage *= 5;
                    }
                }
            }
        }

        public class FB : ModParagonUpgrade<Firey>
        {
            public override int Cost => 735000;
            public override string Description => "The strongest fire..";
            public override string DisplayName => "Firey Blue";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();
                var projectile = attackModel.weapons[0].projectile;
                towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false);
                towerModel.towerSelectionMenuThemeId = "Camo";
                projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;

                var Ability = Game.instance.model.GetTower(TowerType.BombShooter, 0, 4, 0).GetAbilities()[0].Duplicate();

                AttackModel[] support = { Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModels()[1].Duplicate() };
                support[0].weapons[0].projectile.RemoveBehavior<CreateTowerModel>();

                support[0].weapons[0].projectile.AddBehavior(new CreateTowerModel("CreateTowerInAbility", GetTowerModel<FSBG>(), 0, true, false, false, true, false));
                support[0].weapons[0].projectile.display = new() { guidRef = "" };

                Ability.GetBehavior<ActivateAttackModel>().attacks = support;
                Ability.maxActivationsPerRound = 9999999;
                Ability.canActivateBetweenRounds = true;
                Ability.resetCooldownOnTierUpgrade = true;
                Ability.cooldown = 45;
                Ability.icon = GetSpriteReference("FireyBoxGlcon");

                towerModel.AddBehavior(Ability);

                attackModel.weapons[0].rate = 0.4f;
            }
        }
    }
}






