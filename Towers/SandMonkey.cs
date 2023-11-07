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
using UnityEngine;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;

[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace SandMonkey;


public class SandMonkey : ModTower
{
    public override TowerSet TowerSet => TowerSet.Primary;
    public override string BaseTower => TowerType.GlueGunner;
    public override int Cost => 895;
    public override int TopPathUpgrades => 5;
    public override int MiddlePathUpgrades => 2;
    public override int BottomPathUpgrades => 0;
    public override string Description => "Makes Sand to Stun and Slow the Bloons Down. Sanded bloons are immune to sharp damage (UNFINSHED)";


    public override string Icon => "SandMonkeyIcon";

    public override string Portrait => "SandMonkeyIcon";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile = Game.instance.model.GetTower(TowerType.GlueGunner, 0, 0, 2).GetAttackModel().weapons[0].projectile.Duplicate();
        attackModel.range = 40;
        towerModel.range = 40;
        attackModel.name = "Sand_Weapon";
        attackModel.weapons[0].rate = 2;
        attackModel.weapons[0].projectile.pierce = 2;
        ProjectileModelBehaviorExt.AddBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attackModel.weapons)[0].projectile, ModelExt.Duplicate<FreezeModel>(ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)TowerModelExt.GetAttackModel(Game.instance.model.GetTowerFromId("IceMonkey-320")).weapons)[0].projectile)));
        ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attackModel.weapons)[0].projectile).lifespan = 0.3f;
        ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attackModel.weapons)[0].projectile).canFreezeMoabs = false;
    }
    public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
    {
        return towerSet.First(model => model.towerId == TowerType.IceMonkey).towerIndex + 1;
    }

    public class SandMonkeyDisplay : ModTowerDisplay<SandMonkey>
    {
        public override string BaseDisplay => GetDisplay(TowerType.DartMonkey);

        public override bool UseForTower(int[] tiers)
        {
            return tiers.Max() < 5;
        }

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            SetMeshTexture(node, "SandMonkeyDisplay");
            //   SetMeshOutlineColor(node, new Color32(255, 203, 254, 162));
        }
    }

    public class SandDrench : ModUpgrade<SandMonkey>
    {
        // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
        // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
        public override string Portrait => "LuigiIcon";
        public override int Path => TOP;
        public override int Tier => 1;
        public override int Cost => 350;

        // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

        public override string Description => "Bloons get covered in so much sand that it lasts every layer and gets stunned longer.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            foreach (var attacks in towerModel.GetAttackModels())
            {
                if (attacks.name.Contains("Sand_Weapon"))
                {
                    attacks.weapons[0].projectile = Game.instance.model.GetTower(TowerType.GlueGunner, 1, 0, 2).GetAttackModel().weapons[0].projectile.Duplicate();
                    attacks.range = 40;
                    towerModel.range = 40;
                    attacks.weapons[0].rate = 2;
                    attacks.weapons[0].projectile.pierce = 2;
                    ProjectileModelBehaviorExt.AddBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attacks.weapons)[0].projectile, ModelExt.Duplicate<FreezeModel>(ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)TowerModelExt.GetAttackModel(Game.instance.model.GetTowerFromId("IceMonkey-320")).weapons)[0].projectile)));
                    ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attacks.weapons)[0].projectile).lifespan *= 0.6f;
                    ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attacks.weapons)[0].projectile).canFreezeMoabs = false;
                }
            }
        }
            public class DeadlySand : ModUpgrade<SandMonkey>
        {
            // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
            // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
            public override string Portrait => "LuigiIcon";
            public override int Path => TOP;
            public override int Tier => 2;
            public override int Cost => 630;

            // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

            public override string Description => "The Sand gets covered with poison from the Alchemist which damages the bloons over time and the Sand Monkey can hit camo";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                foreach (var attacks in towerModel.GetAttackModels())
                {
                    if (attacks.name.Contains("Sand_Weapon"))
                    {
                        attacks.weapons[0].projectile = Game.instance.model.GetTower(TowerType.GlueGunner, 2, 0, 2).GetAttackModel().weapons[0].projectile.Duplicate();
                        attacks.range = 40;
                        towerModel.range = 40;
                        attacks.weapons[0].rate = 2;
                        attacks.weapons[0].projectile.pierce = 2;
                        towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel", true));
                        ProjectileModelBehaviorExt.AddBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attacks.weapons)[0].projectile, ModelExt.Duplicate<FreezeModel>(ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)TowerModelExt.GetAttackModel(Game.instance.model.GetTowerFromId("IceMonkey-320")).weapons)[0].projectile)));
                        ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attacks.weapons)[0].projectile).lifespan *= 0.6f;
                        ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attacks.weapons)[0].projectile).canFreezeMoabs = false;
                    }
                    towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel", true));
                }
            }
        }
    }

    public class SandFragments : ModUpgrade<SandMonkey>
    {
        // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
        // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
        public override string Portrait => "LuigiIcon";
        public override int Path => TOP;
        public override int Tier => 3;
        public override int Cost => 4500;

        // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

        public override string Description => "The poison gets more stronger and the sand goes everywhere!";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            foreach (var attacks in towerModel.GetAttackModels())
            {
                if (attacks.name.Contains("Sand_Weapon"))
                {
                    attacks.weapons[0].projectile = Game.instance.model.GetTower(TowerType.GlueGunner, 3, 0, 2).GetAttackModel().weapons[0].projectile.Duplicate();
                    attacks.range = 40;
                    towerModel.range = 40;
                    attacks.weapons[0].rate = 2;
                    attacks.weapons[0].projectile.pierce = 2;
                    ProjectileModelBehaviorExt.AddBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attacks.weapons)[0].projectile, ModelExt.Duplicate<FreezeModel>(ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)TowerModelExt.GetAttackModel(Game.instance.model.GetTowerFromId("IceMonkey-320")).weapons)[0].projectile)));
                    ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attacks.weapons)[0].projectile).lifespan *= 0.6f;
                    ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attacks.weapons)[0].projectile).canFreezeMoabs = false;
                }
            }
            var attackModel = towerModel.GetAttackModel();
            var newWeapon = Game.instance.model.GetTowerFromId("GlueGunner-302").GetAttackModel().weapons[0].Duplicate();
            newWeapon.rate *= 3.5f;
            newWeapon.projectile.pierce += 2;
            newWeapon.emission = new ArcEmissionModel("ArcEmissionModel_", 5, 0.0f, 360.0f, null, false, false);
          //  newWeapon.projectile.ApplyDisplay<fartDisplay>();
            attackModel.AddWeapon(newWeapon);
        }
    }

    public class SandMelt : ModUpgrade<SandMonkey>
    {
        // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
        // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
        public override string Portrait => "LuigiIcon";
        public override int Path => TOP;
        public override int Tier => 4;
        public override int Cost => 7205;

        // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

        public override string Description => "The poison melts the bloons, gets more pierce and stuns bloons longer.";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            foreach (var attacks in towerModel.GetAttackModels())
            {
                if (attacks.name.Contains("Sand_Weapon"))
                {
                    attacks.weapons[0].projectile = Game.instance.model.GetTower(TowerType.GlueGunner, 4, 0, 2).GetAttackModel().weapons[0].projectile.Duplicate();
                    attacks.range = 40;
                    towerModel.range = 40;
                    attacks.weapons[0].rate = 2;
                    attacks.weapons[0].projectile.pierce = +5;
                    ProjectileModelBehaviorExt.AddBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attacks.weapons)[0].projectile, ModelExt.Duplicate<FreezeModel>(ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)TowerModelExt.GetAttackModel(Game.instance.model.GetTowerFromId("IceMonkey-320")).weapons)[0].projectile)));
                    ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attacks.weapons)[0].projectile).lifespan *= 0.8f;
                    ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attacks.weapons)[0].projectile).canFreezeMoabs = true;
                }
            }
        }


        public class TheMostDangerousSand : ModUpgrade<SandMonkey>
        {
            // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
            // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
            public override string Portrait => "LuigiIcon";
            public override int Path => TOP;
            public override int Tier => 5;
            public override int Cost => 50000;

            // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

            public override string Description => "I think the alchemist put the wrong chemicals....";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                foreach (var attacks in towerModel.GetAttackModels())
                {
                    if (attacks.name.Contains("Sand_Weapon"))
                    {
                        attacks.weapons[0].projectile = Game.instance.model.GetTower(TowerType.GlueGunner, 5, 0, 2).GetAttackModel().weapons[0].projectile.Duplicate();
                        attacks.range += 40;
                        towerModel.range += 40;
                        attacks.weapons[0].rate = 2;
                        attacks.weapons[0].projectile.pierce += 35;
                        ProjectileModelBehaviorExt.AddBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attacks.weapons)[0].projectile, ModelExt.Duplicate<FreezeModel>(ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)TowerModelExt.GetAttackModel(Game.instance.model.GetTowerFromId("IceMonkey-320")).weapons)[0].projectile)));
                        ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attacks.weapons)[0].projectile).lifespan *= 10.5f;
                        ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attacks.weapons)[0].projectile).canFreezeMoabs = true;
                    }
                }
            }
            public class EnhancedThrowing : ModUpgrade<SandMonkey>
            {
                // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
                // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
                public override string Portrait => "LuigiIcon";
                public override int Path => MIDDLE;
                public override int Tier => 1;
                public override int Cost => 325;

                // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

                public override string Description => "Gets more Speed, gets +1 pierce, and stuns bloons longer";

                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    foreach (var attacks in towerModel.GetAttackModels())
                    {
                        if (attacks.name.Contains("Sand_Weapon"))
                        {
                            attacks.weapons[0].rate -= 0.7f;
                            attacks.weapons[0].projectile.pierce += 1;
                            ProjectileModelBehaviorExt.AddBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attacks.weapons)[0].projectile, ModelExt.Duplicate<FreezeModel>(ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)TowerModelExt.GetAttackModel(Game.instance.model.GetTowerFromId("IceMonkey-320")).weapons)[0].projectile)));
                            ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attacks.weapons)[0].projectile).lifespan *= 0.8f;
                            ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attacks.weapons)[0].projectile).canFreezeMoabs = false;
                        }
                    }
                }

                public class MoreEnhancedThrowing : ModUpgrade<SandMonkey>
                {
                    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
                    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
                    public override string Portrait => "LuigiIcon";
                    public override int Path => MIDDLE;
                    public override int Tier => 2;
                    public override int Cost => 2105;

                    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

                    public override string Description => "Gets even more Speed, gets +5 pierce, and stuns bloons for even longer";

                    public override void ApplyUpgrade(TowerModel towerModel)
                    {
                        foreach (var attacks in towerModel.GetAttackModels())
                        {
                            if (attacks.name.Contains("Sand_Weapon"))
                            {
                                attacks.weapons[0].rate -= 0.4f;
                                attacks.weapons[0].projectile.pierce += 5;
                                ProjectileModelBehaviorExt.AddBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attacks.weapons)[0].projectile, ModelExt.Duplicate<FreezeModel>(ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)TowerModelExt.GetAttackModel(Game.instance.model.GetTowerFromId("IceMonkey-320")).weapons)[0].projectile)));
                                ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attacks.weapons)[0].projectile).lifespan *= 1.1f;
                                ProjectileModelBehaviorExt.GetBehavior<FreezeModel>(((Il2CppArrayBase<WeaponModel>)attacks.weapons)[0].projectile).canFreezeMoabs = false;
                            }
                        }
                    }
                }
            }
        }
    }
}



