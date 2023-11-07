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

[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace CamsNinjaMonkey;


public class CamsNinjaMonkey : ModTower
{
    public override TowerSet TowerSet => TowerSet.Magic;
    public override string BaseTower => TowerType.NinjaMonkey;
    public override int Cost => 570;
    public override int TopPathUpgrades => 0;
    public override int MiddlePathUpgrades => 5;
    public override int BottomPathUpgrades => 0;
    public override string Description => "My Fav Upgrades In One Tower!";

    public override string Icon => "000NinjaMonkey";

    public override string Portrait => "000NinjaMonkey";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].projectile = Game.instance.model.GetTower(TowerType.NinjaMonkey).GetAttackModel().weapons[0].projectile.Duplicate();
        towerModel.GetAttackModel().range = 40;
        towerModel.range = 40;
        towerModel.GetAttackModel().weapons[0].projectile.pierce = 2;
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 2;
    }
    public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
    {
        return towerSet.First(model => model.towerId == TowerType.NinjaMonkey).towerIndex + 1;
    }
    public class CamsNinjaMonkeyDisplay : ModTowerDisplay<CamsNinjaMonkey>
    {
        public override string BaseDisplay => GetDisplay("NinjaMonkey");

        public override bool UseForTower(int[] tiers)
        {
            return tiers.Sum() == 0;
        }

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            SetMeshTexture(node, Name);

        }
        public class Knockback : ModUpgrade<CamsNinjaMonkey>
        {
            // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
            // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
            public override string Portrait => "LuigiIcon";
            public override int Path => MIDDLE;
            public override int Tier => 1;
            public override int Cost => 3000;

            // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

            public override string Description => "Bloons get pushed backwards or slowed after each hit.";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var Knockback = Game.instance.model.GetTowerFromId("NinjaMonkey-010").GetWeapon().projectile.GetBehavior<WindModel>().Duplicate<WindModel>();
                Knockback.chance = 0.5f;
                Knockback.distanceMin = 25;
                Knockback.distanceMax = 50;
                var attackModel = towerModel.GetAttackModel();
                attackModel.weapons[0].projectile.AddBehavior(Knockback);
            }

            public class RedHotShuriken : ModUpgrade<CamsNinjaMonkey>
            {
                // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
                // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
                public override string Portrait => "LuigiIcon";
                public override int Path => MIDDLE;
                public override int Tier => 2;
                public override int Cost => 350;

                // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

                public override string Description => "Shurikens now pop Frozen and Lead Bloons and do more damage to all.";

                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = 0;
                    towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 3;
                }
            }

            public class ClusterBombs : ModUpgrade<CamsNinjaMonkey>
            {
                // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
                // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
                public override string Portrait => "LuigiIcon";
                public override int Path => MIDDLE;
                public override int Tier => 3;
                public override int Cost => 880;

                // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

                public override string Description => "Throws out secondary bombs every shot.";

                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    towerModel.GetAttackModel().weapons[0].rate = .4f;

                    var Bomb = Game.instance.model.GetTowerFromId("BombShooter-203").GetAttackModel().Duplicate();
                    Bomb.range = towerModel.range;
                    Bomb.name = "Bomb_Weapon";
                    towerModel.AddBehavior(Bomb);
                }
            }
            public class ArcaneSpike : ModUpgrade<CamsNinjaMonkey>
            {
                // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
                // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
                public override string Portrait => "LuigiIcon";
                public override int Path => MIDDLE;
                public override int Tier => 4;
                public override int Cost => 10000;

                // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

                public override string Description => "Faster firing shurikens does huge damage.";

                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    towerModel.GetAttackModel().weapons[0].rate = 0.275f;
                    towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 7;
                    towerModel.GetAttackModel().weapons[0].projectile.pierce = 7;
                    towerModel.GetWeapon().projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel", "Moabs", 1, 10, false, true));
                }

                public class MAD : ModUpgrade<CamsNinjaMonkey>
                {
                    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
                    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
                    public override string Portrait => "LuigiIcon";
                    public override int Path => MIDDLE;
                    public override int Tier => 5;
                    public override int Cost => 70000;

                    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

                    public override string Description => "Moab Assured Destroyer. Slower firing mega missiles deal extreme damage to MOAB class Bloons.";

                    public override void ApplyUpgrade(TowerModel towerModel)
                    {
                        var MAD = Game.instance.model.GetTowerFromId("DartlingGunner-250").GetAttackModel().Duplicate();
                        MAD.range = towerModel.range;
                        MAD.name = "MAD_Weapon";
                        towerModel.AddBehavior(MAD);
                        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 550;
                        towerModel.GetWeapon().projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel", "Moabs", 1, 553, false, true));

                        var Ability = Game.instance.model.GetTower(TowerType.DartlingGunner, 2, 5, 0).GetAbilities()[0].Duplicate();
                        Ability.maxActivationsPerRound = 9999999;
                        Ability.canActivateBetweenRounds = true;
                        Ability.resetCooldownOnTierUpgrade = true;
                        Ability.cooldown = 35;
                        Ability.icon = GetSpriteReference("MAD2-Icon");
                        towerModel.AddBehavior(Ability);
                    }
                }
            }
        }
    }
}





