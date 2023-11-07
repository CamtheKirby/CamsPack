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

public class Kirby : ModTower
{
    public override TowerSet TowerSet => TowerSet.Magic;
    public override string BaseTower => TowerType.DartMonkey;
    public override int Cost => 825;
    public override int TopPathUpgrades => 5;
    public override int MiddlePathUpgrades => 5;
    public override int BottomPathUpgrades => 5;
    public override string Description => "Look! It's Kirby!";

    public override bool Use2DModel => true;
    public override string Icon => "Kiby2Icon";

    public override string Portrait => "KirbyIcon";
    public override ParagonMode ParagonMode => ParagonMode.Base555;

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].projectile = Game.instance.model.GetTower(TowerType.MonkeySub).GetAttackModel().weapons[0].projectile.Duplicate();
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = 0;
        towerModel.GetAttackModel().weapons[0].projectile.ApplyDisplay<NothingDisplay>();
    }
    public override string Get2DTexture(int[] tiers)
    {
        //if (tiers[3] == 1)
        //{
        // return "KirbyFireDisplay";
        // }
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
        towerModel.GetAttackModel().weapons[0].rate *= .7f;
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
        towerModel.GetAttackModel().weapons[0].rate *= .5f;
    }
}
public class StrongPunching : ModUpgrade<Kirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 3;
    public override int Cost => 7799;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Now Kirby Punching is Faster and Stronger!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].projectile.ApplyDisplay<PunchDisplay>();
        towerModel.GetAttackModel().weapons[0].rate *= .4f;
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 2f;
    }
}

public class FightingSenior : ModUpgrade<Kirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 4;
    public override int Cost => 8169;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Kirby's Damage, Attacking Speed, and Pierce Gets Better";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].rate *= .3f;
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 4f;
        towerModel.GetAttackModel().weapons[0].projectile.pierce += 4;
    }
}

public class FightingMaster : ModUpgrade<Kirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 5;
    public override int Cost => 509305;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "The Master of Fighters";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].rate *= .2f;
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 6f;
        towerModel.GetAttackModel().weapons[0].projectile.pierce += 10;
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
        towerModel.GetAttackModel().range *= 1.0f;
        towerModel.range *= 1.0f;
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
        towerModel.GetAttackModel().range *= 2.2f;
        towerModel.range *= 2.2f;
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

    public override string Description => "Kirby Now Can Get Money! (And also gets more range, damage and price)";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var Money = Game.instance.model.GetTowerFromId("BananaFarm").GetAttackModel().Duplicate();
        Money.name = "BananaFarm_";
        Money.weapons[0].projectile.GetBehavior<CashModel>().maximum = 35;
        Money.weapons[0].projectile.GetBehavior<CashModel>().minimum = 30;
        towerModel.AddBehavior(Money);
        towerModel.GetAttackModel().range += 1f;
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 2;
        towerModel.range += 1;
        towerModel.GetAttackModel().weapons[0].projectile.ApplyDisplay<NoteDisplay>();
        towerModel.GetAttackModel().weapons[0].projectile.pierce += 5;
    }
}
public class SingingClub : ModUpgrade<Kirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 4;
    public override int Cost => 2975;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Kirby Now Shoots His Music In All Directions! Can Buff Towers and With his ability he can attack faster!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
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
        towerModel.GetAttackModel().weapons[0].projectile.pierce += 5;
        towerModel.AddBehavior(Ability);

        var buffM1 = new RateSupportModel("RateSupport1", 0.66f, true, "Kirby:Rate", false, 1, null, null, null);
        buffM1.ApplyBuffIcon<KirbyBuffIcon>();
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
    public override int Cost => 38412;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "MAYBE IF KIRBY SCREAMS IT WILL DO SOMETHING!!!!!!!!!!!!!!!!!!!!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].rate = .5f;
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 75;
        towerModel.GetAttackModel().weapons[0].projectile.pierce += 100;
        towerModel.GetAttackModel().range += 3f;
        towerModel.range += 3;

        var Ability = Game.instance.model.GetTowerFromId("Psi 10").GetAbilities()[1].Duplicate();
        Ability.maxActivationsPerRound = 9999999;
        Ability.canActivateBetweenRounds = true;
        Ability.resetCooldownOnTierUpgrade = true;
        Ability.cooldown = 25;
        Ability.icon = GetSpriteReference("KirbyPath4Icon_Icon");
        towerModel.AddBehavior(Ability);
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
        var Fire = Game.instance.model.GetTower(TowerType.MortarMonkey, 0, 0, 2).GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetBehavior<AddBehaviorToBloonModel>();
        towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(Fire);
        towerModel.GetAttackModel().weapons[0].projectile.collisionPasses = new[] { -1, 0 };
        towerModel.GetAttackModel().weapons[0].projectile.pierce += 2;
        towerModel.GetAttackModel().range += 1;
        towerModel.range += 1;
        towerModel.GetAttackModel().weapons[0].projectile.ApplyDisplay<FireDisplay>();
    }

}

public class BombAbility : ModUpgrade<Kirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 2;
    public override int Cost => 1950;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Kirby Gets The Bomb Ability!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var projectile = Game.instance.model.GetTower(TowerType.BombShooter, 4, 0, 0).GetAttackModel().weapons[0].projectile.Duplicate();
        projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetDamageModel().damage *= 15;
        projectile.display = new() { guidRef = "" };
        var weapon = towerModel.GetAttackModel().Duplicate();
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
        towerModel.GetAttackModel().weapons[0].projectile.pierce += 2;
        towerModel.GetAttackModel().range += 1;
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
    public override int Cost => 879305;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Kirby Gets- wait this ability is special......";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var UltraSword = Game.instance.model.GetTowerFromId("SuperMonkey-302").GetAttackModel().Duplicate();
        UltraSword.range = towerModel.range;
        UltraSword.name = "UltraSword_Weapon";
        UltraSword.weapons[0].projectile.pierce = 9999999999999999999; // inf lol
        UltraSword.weapons[0].projectile.GetDamageModel().damage = 20000;
        towerModel.AddBehavior(UltraSword);
        towerModel.GetWeapon().projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel", "Moabs", 1, 485, false, true));
        towerModel.GetAttackModel().weapons[0].projectile.pierce += 1000;
        towerModel.GetAttackModel().range += 50;
        towerModel.range += 50;
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 100.9f;
    }

}

public class StarRod : ModParagonUpgrade<Kirby>
{
    public override int Cost => 1900019;
    public override string Description => "'Wow What's This Cool Thing?'";
    public override string DisplayName => "The Star Rod";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var Ability = Game.instance.model.GetTowerFromId("Psi 20").GetAbilities()[1].Duplicate();
        Ability.maxActivationsPerRound = 9999999;
        Ability.canActivateBetweenRounds = true;
        Ability.resetCooldownOnTierUpgrade = true;
        Ability.cooldown = 15;
        Ability.icon = GetSpriteReference("KirbyPath4Icon_Icon");
        towerModel.AddBehavior(Ability);

        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 69599299;
        towerModel.GetAttackModel().weapons[0].rate *= .1f;
        towerModel.GetAttackModel().weapons[0].projectile.pierce = 9999999999999999999;
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = 0;
       
  
    }
}
