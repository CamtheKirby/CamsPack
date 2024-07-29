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
using Il2CppNinjaKiwi.Common.ResourceUtils;
using System;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using System.Collections.Generic;
using System.Linq;


[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace DarkMonkey;

public class JugDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "JugDisplay");
    }
}

public class CJugDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "CJugDisplay");
    }
}
public class DarkMonkey : ModTower<CamsPack.JokeTowers>
{
   // public override TowerSet TowerSet => TowerSet.Primary;
    public override string BaseTower => TowerType.DartMonkey;
    public override int Cost => 675;
    public override int TopPathUpgrades => 5;
    public override int MiddlePathUpgrades => 5;
    public override int BottomPathUpgrades => 5;
    public override string Description => "(THIS IS A JOKE TOWER) (Cursed Tower Made By u/PawaMV) According to all known laws of avaiation, there is no way a lead bloon should be able to fly. Its shell is too heavy to get its fat little body off the ground. The lead bloon, of course, flies anyway, because bloons don't care what monkeys think is impossible.";

    public override string Icon => "DMIcon";

    public override string Portrait => "DMIcon";
    public override ParagonMode ParagonMode => ParagonMode.Base555;
    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile = Game.instance.model.GetTower(TowerType.DartMonkey).GetAttackModel().weapons[0].projectile.Duplicate();
        attackModel.range = 40;
        towerModel.range = 40;
        attackModel.weapons[0].projectile.pierce = 30;
        attackModel.weapons[0].projectile.GetDamageModel().damage = 4;
    }

    public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
    {
        return towerSet.First(model => model.towerId == TowerType.GlueGunner).towerIndex + 1;
    }
    public class DarkMonkeyDisplay : ModTowerDisplay<DarkMonkey>
    {
         public override string BaseDisplay => GetDisplay(TowerType.DartMonkey);

        public override bool UseForTower(int[] tiers)
        {
            return tiers.Sum() == 0;
        }

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
#if DEBUG
            node.PrintInfo();
            node.SaveMeshTexture();
#endif
            SetMeshTexture(node, Name);

        }

        public class Sharp : ModUpgrade<DarkMonkey>
        {
            // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
            // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
            public override string Portrait => "LuigiIcon";
            public override int Path => TOP;
            public override int Tier => 1;
            public override int Cost => 450;

            // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

            public override string Description => "Big Price";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();
                attackModel.weapons[0].projectile.pierce += 50;
            }

        }

        public class RazorShots : ModUpgrade<DarkMonkey>
        {
            // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
            // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
            public override string Portrait => "LuigiIcon";
            public override int Path => TOP;
            public override int Tier => 2;
            public override int Cost => 850;

            // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

            public override string Description => "Bigger Sharp";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();
                attackModel.weapons[0].projectile.pierce += 100;

                var RS = Game.instance.model.GetTowerFromId("TackShooter-032").GetAttackModel().Duplicate();
                RS.range = towerModel.range;
                RS.name = "A_Weapon";
                towerModel.AddBehavior(RS);
            }

        }

        public class SpikeOPult : ModUpgrade<DarkMonkey>
        {
            // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
            // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
            public override string Portrait => "LuigiIcon";
            public override int Path => TOP;
            public override int Tier => 3;
            public override int Cost => 2850;

            // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

            public override string Description => "Tack Monkey";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();
                attackModel.weapons[0].projectile.pierce += 100;

                var RS2 = Game.instance.model.GetTowerFromId("TackShooter-203").GetAttackModel().Duplicate();
                RS2.range = towerModel.range;
                RS2.name = "B_Weapon";
                towerModel.AddBehavior(RS2);
            }

        }

        public class Jug : ModUpgrade<DarkMonkey>
        {
            // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
            // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
            public override string Portrait => "LuigiIcon";
            public override int Path => TOP;
            public override int Tier => 4;
            public override int Cost => 8850;

            // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

            public override string Description => "Big Jug";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();
                var Alch = Game.instance.model.GetTowerFromId("IceMonkey-024").GetAttackModel().Duplicate();
                Alch.range = towerModel.range;
                Alch.name = "C_Weapon";
                Alch.weapons[0].projectile.ApplyDisplay<JugDisplay>();
                towerModel.AddBehavior(Alch);
                attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = 0;
                attackModel.weapons[0].projectile.GetDamageModel().damage = 50;
            }

        }

        public class ChugJug : ModUpgrade<DarkMonkey>
        {
            // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
            // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
            public override string Portrait => "LuigiIcon";
            public override int Path => TOP;
            public override int Tier => 5;
            public override int Cost => 48850;

            // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

            public override string Description => "We got a... #1 Victory Royale, yeah, Fortnite we 'bout to get down (Get down!) Ten kills on the board right now Just wiped out Tomato Town My friend just got downed, I revived him now we're heading southbound Now we're in the Pleasant Park streets, look at the map, go to the marked sheet Take me to your Xbox to play Fortnite today! You can take me to Moisty Mire, but not Loot Lake! I really love to.. Chug Jug with you !We can be pro Fortnite gamers!";

            public override void ApplyUpgrade(TowerModel towerModel)
            {
                var attackModel = towerModel.GetAttackModel();
                var Alch2 = Game.instance.model.GetTowerFromId("BoomerangMonkey-502").GetAttackModel().Duplicate();
                Alch2.range = towerModel.range;
                Alch2.name = "D_Weapon";
                Alch2.weapons[0].projectile.ApplyDisplay<CJugDisplay>();
                attackModel.weapons[0].projectile.GetDamageModel().damage = 169;
                Alch2.weapons[0].rate *= .2f;
                towerModel.AddBehavior(Alch2);
            }

        }
    }
    public class ShortDarts : ModUpgrade<DarkMonkey>
    {
        // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
        // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
        public override string Portrait => "LuigiIcon";
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 450;

        // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

        public override string Description => "Short Darts = Speed";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            attackModel.weapons[0].rate = .6f;
        }

    }
}

public class VeryShortDarts : ModUpgrade<DarkMonkey>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 2;
    public override int Cost => 995;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Very Short Darts = More Speed";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].rate = .4f;
    }

}

public class TripleTripleShot : ModUpgrade<DarkMonkey>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 3;
    public override int Cost => 1400;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Darts go brrrrrr";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var T1 = Game.instance.model.GetTowerFromId("DartMonkey-030").GetAttackModel().Duplicate();
        T1.range = towerModel.range;
        T1.name = "E_Weapon";
        towerModel.AddBehavior(T1);

        var T2 = Game.instance.model.GetTowerFromId("DartMonkey-030").GetAttackModel().Duplicate();
        T2.range = towerModel.range;
        T2.name = "F_Weapon";
        towerModel.AddBehavior(T2);
    }

}

public class LongSuperMonkeyFanClub : ModUpgrade<DarkMonkey>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 4;
    public override int Cost => 8650;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Super Monkey Fan Club But Good";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.GetDamageModel().damage = 10;
        attackModel.weapons[0].projectile.pierce += 15;

        var Ability = Game.instance.model.GetTower(TowerType.DartMonkey, 0, 4, 0).GetAbilities()[0].Duplicate();
        Ability.maxActivationsPerRound = 9999999;
        Ability.canActivateBetweenRounds = true;
        Ability.resetCooldownOnTierUpgrade = true;
        Ability.cooldown = 45;
        Ability.icon = GetSpriteReference("LongSuperMonkeyFanClub-Icon");
        towerModel.AddBehavior(Ability);
    }

}

public class FanClub : ModUpgrade<DarkMonkey>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 5;
    public override int Cost => 75000;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Fan Noises";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.range += 45;
        towerModel.range += 45;
        attackModel.weapons[0].projectile.pierce += 5;
        attackModel.weapons[0].projectile.GetDamageModel().damage += 2;
        attackModel.weapons[0].rate = .2f;
        attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = 0;

        var Knockback = Game.instance.model.GetTowerFromId("NinjaMonkey-010").GetWeapon().projectile.GetBehavior<WindModel>().Duplicate<WindModel>();
        Knockback.chance = 0.7f;
        Knockback.distanceMin = 250;
        Knockback.distanceMax = 320;
        
        attackModel.weapons[0].projectile.AddBehavior(Knockback);
    }

}

public class LongDarts : ModUpgrade<DarkMonkey>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 1;
    public override int Cost => 170;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Long = Range";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.range += 15;
        towerModel.range += 15;
    }

}

public class EnhancedEyes : ModUpgrade<DarkMonkey>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 2;
    public override int Cost => 370;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Big Old Eyess";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.range += 10;
        towerModel.range += 10;
        towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel", true));
        towerModel.towerSelectionMenuThemeId = "Camo";
    }

}

public class Cross : ModUpgrade<DarkMonkey>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 3;
    public override int Cost => 870;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "IDK";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.range += 10;
        towerModel.range += 10;
        attackModel.weapons[0].projectile.GetDamageModel().damage += 2;
        var Fire = Game.instance.model.GetTower(TowerType.MortarMonkey, 0, 0, 2).GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetBehavior<AddBehaviorToBloonModel>();
        attackModel.weapons[0].projectile.AddBehavior(Fire);
        attackModel.weapons[0].projectile.collisionPasses = new[] { -1, 0 };
    }

}

public class SharpShots : ModUpgrade<DarkMonkey>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 4;
    public override int Cost => 2870;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Sharp dcxfffkfklogxciopjfsdiojpfsadpijfj[puoghoohvvhivfushosfohusffuohfdfsduofshufsdofdshufahusdofdouhufospofsafdosoudfsofdfsdauh";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.pierce += 75;
        attackModel.weapons[0].projectile.GetDamageModel().damage += 3;
    }

}

public class Sn00ferMaster : ModUpgrade<DarkMonkey>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 5;
    public override int Cost => 61500;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Inf Range lol";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.pierce += 99999;
        attackModel.weapons[0].projectile.GetDamageModel().damage += 9;
        attackModel.range += 9999999999;
        towerModel.range += 9999999999;

        var SSS = Game.instance.model.GetTowerFromId("SniperMonkey-502").GetAttackModel().Duplicate();
        SSS.range = towerModel.range;
        SSS.name = "G_Weapon";
        towerModel.AddBehavior(SSS);
    }

}

public class ApexMemerMaster : ModParagonUpgrade<DarkMonkey>
{
    public override string Portrait => "ApexMemerMaster-Icon";
    public override int Cost => 800000;
    public override string Description => "Wow it the Wow it it the it it ojwfjowe Apex Memer Master";
    public override string DisplayName => "Apex Memer Master";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var Ability = Game.instance.model.GetTower(TowerType.DartMonkey, 0, 5, 0).GetAbilities()[0].Duplicate();
        Ability.maxActivationsPerRound = 9999999;
        Ability.canActivateBetweenRounds = true;
        Ability.resetCooldownOnTierUpgrade = true;
        Ability.cooldown = 20;
        Ability.icon = GetSpriteReference("ApexMemerMaster-Icon");
        towerModel.AddBehavior(Ability);

        attackModel.weapons[0].projectile.GetDamageModel().damage += 300;
        attackModel.weapons[0].rate *= .1f;
        attackModel.weapons[0].projectile.pierce = 9999999999999999999;
        attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = 0;

        var SSPS = Game.instance.model.GetTowerFromId("DartMonkey-Paragon").GetAttackModel().Duplicate();
        SSPS.range = towerModel.range;
        SSPS.name = "LOL_Weapon";
        towerModel.AddBehavior(SSPS);

        var SSPS2 = Game.instance.model.GetTowerFromId("SuperMonkey-205").GetAttackModel().Duplicate();
        SSPS2.range = towerModel.range;
        SSPS2.name = "LOL2_Weapon";
        towerModel.AddBehavior(SSPS2);

        towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel", true));
        towerModel.towerSelectionMenuThemeId = "Camo";
    }
}

















