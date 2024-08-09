using BananaGun;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using CamsPack;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Bloons.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using MelonLoader;
using System.Collections.Generic;
using System.Linq;
using static Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors.SlowModel;

[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace Kirby;



public class NothingDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "NothingDisplay");
    }
}

public class FireDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "FireDisplay");
    }
}
public class PunchDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "PunchDisplay");
    }
}

public class NoteDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "NoteDisplay");
    }
}

public class KirbyBuffIcon : ModBuffIcon
{
    protected override int Order => 1;
    public override string Icon => "KirbyBuffIcon";
    public override int MaxStackSize => 1;
}

public class Kirby2BuffIcon : ModBuffIcon
{
    protected override int Order => 1;
    public override string Icon => "SCREAM-Icon";
    public override int MaxStackSize => 1;
}

public class StarRodBuffIcon : ModBuffIcon
{
    protected override int Order => 1;
    public override string Icon => "StarRodBuffIcon";
    public override int MaxStackSize => 1;
}
public class Kirby : ModTower<CamsPack.KirbyTowers>
{
   // public override TowerSet TowerSet => TowerSet.Magic;
    public override string BaseTower => TowerType.DartMonkey;
    public override int Cost => 385;
    public override int TopPathUpgrades => 5;
    public override int MiddlePathUpgrades => 5;
    public override int BottomPathUpgrades => 5;
    public override string Description => "It's Kirby! Punches bloons with medium speed";

    public override bool Use2DModel => true;
    public override string Icon => "Kiby2Icon";

    public override string Portrait => "KirbyIcon";
    public override ParagonMode ParagonMode => ParagonMode.Base555;

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile = Game.instance.model.GetTower(TowerType.DartMonkey).GetAttackModel().weapons[0].projectile.Duplicate();
        attackModel.weapons[0].projectile.ApplyDisplay<NothingDisplay>();
        attackModel.weapons[0].projectile.pierce = 1;
        attackModel.weapons[0].rate *= .8f;
    }

    public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
    {
        return towerSet.First(model => model.towerId == TowerType.Mermonkey).towerIndex + 1;
    }

   /* public override bool IsValidCrosspath(int[] tiers)
    {
        if (!Settings.Crosspath)
        {
            return false;
        }
        return ModHelper.HasMod("UltimateCrosspathing") || base.IsValidCrosspath(tiers);
    } */
    public override string Get2DTexture(int[] tiers)
    {
        if (tiers[0] == 3)
        {
            return "KirbyTop3";
        }
        if (tiers[0] == 4)
        {
            return "KirbyTop3";
        }
        if (tiers[0] == 5)
        {
            return "KirbyTop5";
        }
        if (tiers[1] == 3)
        {
            return "KirbyMiddle3";
        }
        if (tiers[1] == 4)
        {
            return "KirbyMiddle4";
        }
        if (tiers[1] == 5)
        {
            return "KirbyMiddle5";
        }
        if (tiers[2] == 1)
        {
         return "KirbyFireDisplay";
        }
        if (tiers[2] == 2)
        {
            return "KirbyBombDisplay";
        }
        if (tiers[2] == 3)
        {
            return "KirbyTornadoDisplay";
        }
        if (tiers[2] == 4)
        {
            return "KirbySparkDisplay";
        }
        if (tiers[2] == 5)
        {
            return "TheUltraSwordDisplay";
        }
        return "KirbyDisplay";
    }
}

public class FastPunching : ModUpgrade<Kirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 1;
    public override int Cost => 150;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Kirby Attacks Faster!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].rate *= .7f;
    }
}

public class FasterPunching : ModUpgrade<Kirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 2;
    public override int Cost => 355;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Kirby Attacks Even Faster!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].rate *= .5f;
    }
}
public class StrongPunching : ModUpgrade<Kirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 3;
    public override int Cost => 600;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Now Kirby Punching is Stronger!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.ApplyDisplay<PunchDisplay>();
        attackModel.weapons[0].projectile.GetDamageModel().damage += 2;
    }
}

public class FightingSenior : ModUpgrade<Kirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 4;
    public override int Cost => 2000;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Kirby's Damage, Attacking Speed, and Pierce Gets Better";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].rate *= .4f;
        attackModel.weapons[0].projectile.GetDamageModel().damage += 5;
        attackModel.weapons[0].projectile.pierce += 10;
    }
}

public class FightingMaster : ModUpgrade<Kirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 5;
    public override int Cost => 31500;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "The Master of Fighters";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();

        attackModel.weapons[0].projectile.GetDamageModel().damage += 35f;
        attackModel.weapons[0].projectile.pierce += 30;
        // weaponModel.projectile.AddBehavior(new SlowModel("SlowModel_", 0.0f, .2f, "Stun:Weak", 9999999, "Stun", true, false, null, false, false, false, 0, false));
    }
}

public class Reach : ModUpgrade<Kirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 1;
    public override int Cost => 200;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Kirby Gets More Range!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.range *= 1.2f;
        towerModel.range *= 1.2f;
    }
}

public class MoreReach : ModUpgrade<Kirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 2;
    public override int Cost => 350;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Kirby Gets Even More Range and Camo Detection!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.range *= 1.3f;
        towerModel.range *= 1.3f;
        towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel", true));
        towerModel.towerSelectionMenuThemeId = "Camo";
    }
}

public class SingForMoney : ModUpgrade<Kirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 3;
    public override int Cost => 1125;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Kirby Now Can Get Money! (And also gets more range, damage and pierce)";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var Money = Game.instance.model.GetTowerFromId("BananaFarm").GetAttackModel().Duplicate();
        Money.name = "BananaFarm_";
        Money.weapons[0].projectile.GetBehavior<CashModel>().maximum = 35;
        Money.weapons[0].projectile.GetBehavior<CashModel>().minimum = 30;
        towerModel.AddBehavior(Money);
        attackModel.range += 1f;
        attackModel.weapons[0].projectile.GetDamageModel().damage = 2;
        towerModel.range += 1;
        attackModel.weapons[0].projectile.ApplyDisplay<NoteDisplay>();
        attackModel.weapons[0].projectile.pierce += 5;
    }
}
public class SingingClub : ModUpgrade<Kirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 4;
    public override int Cost => 27500;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Kirby Now Shoots His Music In All Directions! Can Buff Towers and With his ability he can attack faster!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var Wusic = Game.instance.model.GetTowerFromId("TackShooter-203").GetAttackModel().Duplicate();
        Wusic.range = towerModel.range;
        Wusic.name = "Wusic_Weapon";
        Wusic.weapons[0].projectile.GetDamageModel().damage = 10;
        Wusic.weapons[0].projectile.ApplyDisplay<NoteDisplay>();
        towerModel.AddBehavior(Wusic);

        var Ability = Game.instance.model.GetTower(TowerType.BoomerangMonkey, 0, 4, 0).GetAbilities()[0].Duplicate();
        Ability.maxActivationsPerRound = 9999999;
        Ability.canActivateBetweenRounds = true;
        Ability.resetCooldownOnTierUpgrade = true;
        Ability.cooldown = 37;
        Ability.icon = GetSpriteReference("KirbyPath4Icon_Icon");
        attackModel.weapons[0].projectile.pierce += 5;
        towerModel.AddBehavior(Ability);

        var buffM1 = new RateSupportModel("RateSupportModel_", 0.80f, true, "Village:Rate", false, 1, null, null, null);
        buffM1.ApplyBuffIcon<KirbyBuffIcon>();
        buffM1.name = "buffM1";
        towerModel.AddBehavior(buffM1);
    }
}

public class SCREAM : ModUpgrade<Kirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 5;
    public override int Cost => 80000;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "MAYBE IF KIRBY SCREAMS IT WILL DO SOMETHING!!!!!!!!!!!!!!!!!!!!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].rate = .5f;
        attackModel.weapons[0].projectile.GetDamageModel().damage = 75;
        attackModel.weapons[0].projectile.pierce += 100;
        attackModel.range += 3;
        towerModel.range += 3;

        var Ability = Game.instance.model.GetTowerFromId("Psi 16").GetAbilities()[1].Duplicate();
        Ability.maxActivationsPerRound = 9999999;
        Ability.canActivateBetweenRounds = true;
        Ability.resetCooldownOnTierUpgrade = true;
        Ability.cooldown = 25;
        Ability.icon = GetSpriteReference("SCREAM-Icon");
        towerModel.AddBehavior(Ability);

        towerModel.RemoveBehavior<RateSupportModel>();
        

        var buffM2 = new RateSupportModel("RateSupportModel_", 0.60f, true, "Village:Rate", false, 1, null, null, null);
        buffM2.ApplyBuffIcon<Kirby2BuffIcon>();
        buffM2.name = "buffM2";
        towerModel.AddBehavior(buffM2);
    }
}
public class FireAbility : ModUpgrade<Kirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 1;
    public override int Cost => 650;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Kirby Gets The Fire Ability!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var Fire = Game.instance.model.GetTower(TowerType.MortarMonkey, 0, 0, 2).GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetBehavior<AddBehaviorToBloonModel>();
        attackModel.weapons[0].projectile.AddBehavior(Fire);
        attackModel.weapons[0].projectile.collisionPasses = new[] { -1, 0 };
        attackModel.weapons[0].projectile.pierce += 2;
        attackModel.range += 1;
        towerModel.range += 1;
        attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
        attackModel.weapons[0].projectile.ApplyDisplay<FireDisplay>();
    }

}

public class BombAbility : ModUpgrade<Kirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 2;
    public override int Cost => 4550;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Kirby Gets The Bomb Ability!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var projectile = Game.instance.model.GetTower(TowerType.BombShooter, 4, 0, 0).GetAttackModel().weapons[0].projectile.Duplicate();
        projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage *= 15;
        projectile.display = new() { guidRef = "" };
        var weapon = attackModel.Duplicate();
        weapon.weapons[0].projectile = projectile;
        weapon.weapons[0].Rate = 8;
        weapon.name = "BombA";
        towerModel.AddBehavior(weapon);
        towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel", true));
        towerModel.towerSelectionMenuThemeId = "Camo";
    }

}

public class TornadoAbility : ModUpgrade<Kirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 3;
    public override int Cost => 7995;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Kirby Gets The Tornado Ability!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var Tornado = Game.instance.model.GetTowerFromId("Druid-300").GetAttackModel().Duplicate();
        Tornado.range = towerModel.range;
        Tornado.name = "Tornado_Weapon";
        towerModel.AddBehavior(Tornado);
        attackModel.weapons[0].projectile.pierce += 2;
        attackModel.range += 1;
        towerModel.range += 1;
    }

}

public class SparkAbility : ModUpgrade<Kirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 4;
    public override int Cost => 19959;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Kirby Gets The Spark Ability!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var Spark = Game.instance.model.GetTowerFromId("Druid-400").GetAttackModel().Duplicate();
        Spark.range = towerModel.range;
        Spark.name = "Spark_Weapon";
        towerModel.AddBehavior(Spark);
        towerModel.GetWeapon().projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel", "Moabs", 1, 185, false, true));
    }

}

public class TheUltraSword : ModUpgrade<Kirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 5;
    public override int Cost => 80000;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Kirby Gets the Ultra Sword Holden by special entities";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.range += 30;
        towerModel.range += 30;
        attackModel.weapons[0].rate = .5f;
        attackModel.weapons[0].projectile.GetDamageModel().damage += 30;
        var Sword = Game.instance.model.GetTowerFromId("Sauda 20").GetAttackModel().Duplicate();
        Sword.name = "Sword_Weapon";
        towerModel.AddBehavior(Sword);
        Sword.weapons[0].projectile.GetDamageModel().damage += 6;
        Sword.weapons[0].projectile.pierce += 70;
        attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
    }

}

public class StarRod : ModParagonUpgrade<Kirby>
{
    public override int Cost => 450000;
    public override string Description => "Holds power many want but can it deal with the bloons?";
    public override string DisplayName => "The Star Rod";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();

        var Ability = Game.instance.model.GetTowerFromId("Psi 20").GetAbilities()[1].Duplicate();
        Ability.maxActivationsPerRound = 9999999;
        Ability.canActivateBetweenRounds = true;
        Ability.resetCooldownOnTierUpgrade = true;
        Ability.cooldown = 60;
        Ability.icon = GetSpriteReference("KirbyPath4Icon_Icon");
        towerModel.AddBehavior(Ability);

        attackModel.weapons[0].projectile.GetDamageModel().damage += 150;
        attackModel.weapons[0].projectile.pierce = 250;
        attackModel.weapons[0].rate = .2f;

        var StarRod = Game.instance.model.GetTowerFromId("BallOfLightTower").GetAttackModel().Duplicate();
        StarRod.range = towerModel.range;
        StarRod.name = "StarRod";
        StarRod.weapons[0].projectile.GetDamageModel().damage += 25;
        towerModel.AddBehavior(StarRod);

        towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel", true));
        towerModel.towerSelectionMenuThemeId = "Camo";
        attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;

        towerModel.RemoveBehavior<RateSupportModel>();

        var buffM3 = new RateSupportModel("RateSupportModel_", 0.35f, true, "Village:Rate", false, 1, null, null, null);
        buffM3.ApplyBuffIcon<StarRodBuffIcon>();
        buffM3.name = "buffM3";
        towerModel.AddBehavior(buffM3);
    }
}
