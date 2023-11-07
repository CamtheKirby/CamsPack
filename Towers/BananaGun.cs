using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using CamsPack;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppSystem.Linq;
using PathsPlusPlus;

namespace BananaGun;
public class Banan : ModDisplay
{
    public override string BaseDisplay => "595c7fb1d3705aa478d0d5171b74fb57";
}

public class Banan2 : ModDisplay
{
    public override string BaseDisplay => "5ea56473fe0c6a441b0ab5891b3aa2ba";
}

public class Banan3 : ModDisplay
{
    public override string BaseDisplay => "0d60d713eef3d3043915b89b35b04670";
}

public class BananaGun : UpgradePlusPlus<BananaGunPath>
{
    public override int Cost => 1800;
    public override int Tier => 1;
    public override string Icon => "BananaGunlol";
    public override string Portrait => "Wizard1";

    public override string Description => "Now attacks bloons with its bananas!";

    public override void ApplyUpgrade(TowerModel towerModel, int tier)
    {
        var BGun = Game.instance.model.GetTowerFromId("DartMonkey-230").GetAttackModel().Duplicate();
        BGun.range = towerModel.range;
        BGun.name = "BGun_Weapon";
        BGun.weapons[0].projectile.ApplyDisplay<Banan>();
        towerModel.AddBehavior(BGun);

        if (IsHighestUpgrade(towerModel))
        {

        }
    }
    public class RiperGun : UpgradePlusPlus<BananaGunPath>
    {
        public override int Cost => 570;
        public override int Tier => 2;
        public override string Icon => "Gunlight";
        public override string Portrait => "Wizard1";

        public override string Description => "Riper Bananas for more damage";

        public override void ApplyUpgrade(TowerModel towerModel, int tier)
        {


            foreach (var attacks in towerModel.GetAttackModels())
            {
                if (attacks.name.Contains("BGun_Weapon"))
                {
                    attacks.weapons[0].projectile.GetDamageModel().damage += 2;
                    attacks.weapons[0].projectile.ApplyDisplay<Banan2>();
                }
            }

                if (IsHighestUpgrade(towerModel))
            {

            }
        }

        public class TougherBananas : UpgradePlusPlus<BananaGunPath>
        {
            public override int Cost => 3170;
            public override int Tier => 3;
            public override string Icon => "StrongBana";
            public override string Portrait => "Wizard1";

            public override string Description => "Tougher Bananas can pop frozen and lead bloons and do more damage";

            public override void ApplyUpgrade(TowerModel towerModel, int tier)
            {


                foreach (var attacks in towerModel.GetAttackModels())
                {
                    if (attacks.name.Contains("BGun_Weapon"))
                    {
                        attacks.weapons[0].projectile.GetDamageModel().immuneBloonProperties = 0;
                        attacks.weapons[0].projectile.GetDamageModel().damage += 2;
                    }
                }

                if (IsHighestUpgrade(towerModel))
                {

                }
            }

            public class PackagedBananas : UpgradePlusPlus<BananaGunPath>
            {
                public override int Cost => 7750;
                public override int Tier => 4;
                public override string Icon => VanillaSprites.BananaResearchFacilityUpgradeIcon;
                public override string Portrait => "Wizard1";

                public override string Description => "Packaged Bananas do x2 damage";

                public override void ApplyUpgrade(TowerModel towerModel, int tier)
                {


                    foreach (var attacks in towerModel.GetAttackModels())
                    {
                        if (attacks.name.Contains("BGun_Weapon"))
                        {
                            attacks.weapons[0].projectile.GetDamageModel().damage += 6;
                            attacks.weapons[0].projectile.ApplyDisplay<Banan3>();
                        }
                    }

                    if (IsHighestUpgrade(towerModel))
                    {

                    }
            }
         }
            public class ConstantBananas : UpgradePlusPlus<BananaGunPath>
            {
                public override int Cost => 48275;
                public override int Tier => 5;
                public override string Icon => VanillaSprites.BananaPlantationUpgradeIcon;
                public override string Portrait => "Wizard1";

                public override string Description => "We got too many bananas we got to use it somehow!";

                public override void ApplyUpgrade(TowerModel towerModel, int tier)
                {


                    foreach (var attacks in towerModel.GetAttackModels())
                    {
                        if (attacks.name.Contains("BGun_Weapon"))
                        {
                            attacks.weapons[0].projectile.GetDamageModel().damage += 1;
                            attacks.weapons[0].rate *= .4f;
                        }
                    }

                    if (IsHighestUpgrade(towerModel))
                    {

                    }
                }
            }
        }
    }
}