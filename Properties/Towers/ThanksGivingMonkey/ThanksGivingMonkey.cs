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
using CamsPack;
using System.Collections.Generic;
using System.Linq;
using Kirby;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using TGMonkey.ForthPath;

[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace TGMonkey;

public class Eggs : ModTower
{
    public override string Portrait => "EggIcon";
    public override string Name => "Egg";
    public override TowerSet TowerSet => TowerSet.Support;
    public override string BaseTower => TowerType.DartMonkey;

    public override bool DontAddToShop => true;
    public override int Cost => 0;
    public override bool Use2DModel => true;
    public override int TopPathUpgrades => 0;
    public override int MiddlePathUpgrades => 0;
    public override int BottomPathUpgrades => 0;


    public override string DisplayName => "Egg";
    public override string Description => "idk just E G G";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        
        towerModel.RemoveBehavior<AttackModel>();
        var MoneyE1 = Game.instance.model.GetTowerFromId("BananaFarm").GetAttackModel().Duplicate();
        MoneyE1.name = "Eggy";
        MoneyE1.weapons[0].projectile.GetBehavior<CashModel>().maximum = 70;
        MoneyE1.weapons[0].projectile.GetBehavior<CashModel>().minimum = 70;
        towerModel.AddBehavior(MoneyE1);
        towerModel.AddBehavior(new CollectCashZoneModel("CollectCashZoneModel_", 45, 19, 3, "", true, true, true, true));
        towerModel.isSubTower = true;
        towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 20, 1, false, false));
    }
    public override string Get2DTexture(int[] tiers)
    {
        return "EggDisplay";
    }
}

public class Eggs2 : ModTower
{
    public override string Portrait => "EggIcon";
    public override string Name => "Egg 2";
    public override TowerSet TowerSet => TowerSet.Support;
    public override string BaseTower => TowerType.DartMonkey;

    public override bool DontAddToShop => true;
    public override int Cost => 0;
    public override bool Use2DModel => true;
    public override int TopPathUpgrades => 0;
    public override int MiddlePathUpgrades => 0;
    public override int BottomPathUpgrades => 0;


    public override string DisplayName => "Egg 2";
    public override string Description => "idk just E G G";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.RemoveBehavior<AttackModel>();
        var MoneyE2 = Game.instance.model.GetTowerFromId("BananaFarm-300").GetAttackModel().Duplicate();
        MoneyE2.name = "Eggy";
        MoneyE2.weapons[0].projectile.GetBehavior<CashModel>().maximum = 150;
        MoneyE2.weapons[0].projectile.GetBehavior<CashModel>().minimum = 150;
        towerModel.AddBehavior(MoneyE2);
        towerModel.AddBehavior(new CollectCashZoneModel("CollectCashZoneModel_", 45, 19, 3, "", true, true, true, true));
        towerModel.isSubTower = true;
        towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 35, 1, false, false));
    }
    public override string Get2DTexture(int[] tiers)
    {
        return "EggDisplay";
    }
}


public class EggsT : ModTower
{
    public override string Portrait => "TurkeyIcon";
    public override string Name => "Turkey";
    public override TowerSet TowerSet => TowerSet.Support;
    public override string BaseTower => TowerType.DartMonkey;

    public override bool DontAddToShop => true;
    public override int Cost => 0;
    public override bool Use2DModel => true;
    public override int TopPathUpgrades => 0;
    public override int MiddlePathUpgrades => 0;
    public override int BottomPathUpgrades => 0;


    public override string DisplayName => "Turkey";
    public override string Description => "idk just E G G";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.GetDamageModel().damage = 10;
        attackModel.weapons[0].projectile.ApplyDisplay<NothingDisplay>();
        var EggsT2 = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModels()[1].Duplicate();
        EggsT2.range = towerModel.range;
        EggsT2.name = "Eggs2_Weapon";
        EggsT2.weapons[0].Rate = 13;
        EggsT2.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
        EggsT2.weapons[0].projectile.AddBehavior(new CreateTowerModel("Eggs2place", GetTowerModel<Eggs2>().Duplicate(), 0f, true, false, false, true, true));
        towerModel.AddBehavior(EggsT2);
        towerModel.isSubTower = true;
        towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 20, 1, false, false));
    }
    public override string Get2DTexture(int[] tiers)
    {
        return "TurkeyDisplay";
    }
}


public class TurkeyDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "TurkeyDisplay");
    }
}

public class RawTDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "RawTDisplay");
    }
}

public class MWTDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "MediumWellTDisplay");
    }
}

public class WDTDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "WellDoneTDisplay");
    }
}

public class TLDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "TurkeyLDisplay");
    }
}

public class TLBDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "TurkeyLBDisplay");
    }
}

public class TLBGDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "TurkeyLBGDisplay");
    }
}

public class ThanksgivingMonkey : ModTower<CamsTowers>
{
    
    public override string BaseTower => TowerType.DartMonkey;
    public override int Cost => 2335;
    public override int TopPathUpgrades => 5;
    public override int MiddlePathUpgrades => 5;
    public override int BottomPathUpgrades => 5;
    public override string Description => "It's Thanksgiving time!";
  //  public override bool DontAddToShop => !Settings.UselessTowers == true;
    public override bool Use2DModel => true;
    public override ParagonMode ParagonMode => ParagonMode.Base555;
    public override string Icon => "TGIcon";

    public override string Portrait => "TGIcon";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile = Game.instance.model.GetTower(TowerType.NinjaMonkey).GetAttackModel().weapons[0].projectile.Duplicate();
        attackModel.weapons[0].projectile.ApplyDisplay<TurkeyDisplay>();
        attackModel.weapons[0].projectile.GetDamageModel().damage = 4;
        attackModel.weapons[0].projectile.pierce += 7;
        attackModel.weapons[0].rate -= 0.3f;
    }
    public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
    {
        return towerSet.First(model => model.towerId == TowerType.GlueGunner).towerIndex + 1;
    }
    public override string Get2DTexture(int[] tiers)
    {
        if (tiers[0] == 3)
        {
            return "TGRDisplay";
        }
        if (tiers[0] == 4)
        {
            return "TGMWDisplay";
        }
        if (tiers[0] == 5)
        {
            return "TGWDDisplay";
        }
        if (tiers[1] == 3)
        {
            return "TGCLDisplay";
        }
        if (tiers[1] == 4)
        {
            return "TGBCLDisplay";
        }
        if (tiers[1] == 5)
        {
            return "TGGDisplay";
        }
        if (tiers[2] == 3)
        {
            return "TGEDisplay";
        }
        if (tiers[2] == 4)
        {
            return "TGTDisplay";
        }
        if (tiers[2] == 5)
        {
            return "TGT2Display";
        }
        return "TGDisplay";
    }
}
public class FatTurkey : ModUpgrade<ThanksgivingMonkey>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 1;
    public override int Cost => 965;
    public override string Description => "The Fatter Turkey is bigger can pop more bloons and do more damage";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.GetDamageModel().damage += 2;
        attackModel.weapons[0].projectile.pierce += 7;
        attackModel.weapons[0].projectile.scale += 0.5f;
    }
}

public class FatterTurkey : ModUpgrade<ThanksgivingMonkey>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 2;
    public override int Cost => 1295;
    public override string Description => "The Turkey gets even bigger";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.GetDamageModel().damage += 1;
        attackModel.weapons[0].projectile.pierce += 21;
        attackModel.weapons[0].projectile.scale += 0.5f;
    }
}

public class RawTurkey : ModUpgrade<ThanksgivingMonkey>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 3;
    public override int Cost => 3970;
    public override string Description => "Well it had to happen (Gets 5+ Damage)";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.GetDamageModel().damage += 5;
        attackModel.weapons[0].projectile.ApplyDisplay<RawTDisplay>();
    }
}

public class MediumWellTurkey : ModUpgrade<ThanksgivingMonkey>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 4;
    public override int Cost => 5995;
    public override string Description => "A Perfect Turkey! (Gets 10+ Damage and pierce and the turkey gets bigger)";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.GetDamageModel().damage += 10;
        attackModel.weapons[0].projectile.pierce += 11;
        attackModel.weapons[0].projectile.scale += 0.5f;
        attackModel.weapons[0].projectile.ApplyDisplay<MWTDisplay>();
    }
}

public class WellDoneTurkey : ModUpgrade<ThanksgivingMonkey>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 5;
    public override int Cost => 50000;
    public override string Description => "Too Well done..";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.ApplyDisplay<WDTDisplay>();
        attackModel.weapons[0].projectile.GetDamageModel().damage += 50;
        attackModel.weapons[0].projectile.pierce += 1000;
        var Fire5 = Game.instance.model.GetTower(TowerType.MortarMonkey, 0, 0, 2).GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetBehavior<AddBehaviorToBloonModel>();
        attackModel.weapons[0].projectile.AddBehavior(Fire5);
        attackModel.weapons[0].projectile.collisionPasses = new[] { -1, 0 };
    }
}

public class FasterLegs : ModUpgrade<ThanksgivingMonkey>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 1;
    public override int Cost => 560;
    public override string Description => "Gets more speed";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].rate *= .8f;
    }
}

public class EvenFasterLegs : ModUpgrade<ThanksgivingMonkey>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 2;
    public override int Cost => 1000;
    public override string Description => "Gets more speed";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].rate *= .6f;
    }
}

public class TurkeyLegs : ModUpgrade<ThanksgivingMonkey>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 3;
    public override int Cost => 6550;
    public override string Description => "(Set it to normal so it works) Shoots Turkey Legs Fast and aims where you point on the screen but the main attack gets weaker";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].rate /= .6f;
        attackModel.weapons[0].projectile.pierce -= 4;
        attackModel.weapons[0].projectile.scale -= 0.3f;
        var TL = Game.instance.model.GetTowerFromId("DartlingGunner-102").GetAttackModel().Duplicate();
        TL.name = "TL_Weapon";
        //  TL.weapons[0].projectile.ApplyDisplay<DMDisplay>();
        TL.weapons[0].projectile.GetDamageModel().damage = 6;
        TL.weapons[0].projectile.pierce += 9;
        TL.ApplyDisplay<NothingDisplay>();
        TL.weapons[0].projectile.ApplyDisplay<TLDisplay>();
        towerModel.AddBehavior(TL);
    }
}

public class BurntTurkeyLegs : ModUpgrade<ThanksgivingMonkey>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 4;
    public override int Cost => 62980;
    public override string Description => "(Set it to normal so it works) The turkey legs Burn the bloons and do more damage";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var Ability = Game.instance.model.GetTowerFromId("Gwendolin 10").GetAbilities()[1].Duplicate();
        Ability.maxActivationsPerRound = 9999999;
        Ability.canActivateBetweenRounds = true;
        Ability.resetCooldownOnTierUpgrade = true;
        Ability.cooldown = 15;
        Ability.name = "G1";
        Ability.icon = GetSpriteReference("TUKAb");
        towerModel.AddBehavior(Ability);
        foreach (var attacks in towerModel.GetAttackModels())
        {
            if (attacks.name.Contains("TL_Weapon"))
            {
                var Fire = Game.instance.model.GetTower(TowerType.MortarMonkey, 0, 0, 2).GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetBehavior<AddBehaviorToBloonModel>();
                attacks.weapons[0].projectile.AddBehavior(Fire);
                attacks.weapons[0].projectile.collisionPasses = new[] { -1, 0 };
                attacks.weapons[0].projectile.GetDamageModel().damage += 7;
                attacks.weapons[0].projectile.ApplyDisplay<TLBDisplay>();
            }

        }
    }
}

public class GourmetTurkeyLegs : ModUpgrade<ThanksgivingMonkey>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 5;
    public override int Cost => 99800;
    public override string Description => "(Set it to normal so it works) Shoots slower but packs a punch and pierce gets better";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        foreach (var attacks in towerModel.GetAttackModels())
        {
            if (attacks.name.Contains("TL_Weapon"))
            {
                attacks.weapons[0].projectile.GetDamageModel().damage += 35;
                attacks.weapons[0].projectile.pierce += 50;
                attacks.weapons[0].rate /= .4f;
                attacks.weapons[0].projectile.ApplyDisplay<TLBGDisplay>();
                attacks.weapons[0].emission = new ArcEmissionModel("ArcEmissionModel_", 3, 0, 20, null, false, false);
            }

        }
    }
}

public class LongBeak : ModUpgrade<ThanksgivingMonkey>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 1;
    public override int Cost => 350;
    public override string Description => "Gets more Range and Pierce";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.range += 5;
        towerModel.range += 5;
        attackModel.weapons[0].projectile.pierce += 8;
    }
}

public class EvenLongerBeak : ModUpgrade<ThanksgivingMonkey>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 2;
    public override int Cost => 700;
    public override string Description => "Gets even more Range and Pierce and can pop camo";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.range += 10;
        towerModel.range += 10;
        attackModel.weapons[0].projectile.pierce += 16;
        towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel", true));
        towerModel.towerSelectionMenuThemeId = "Camo";
    }
}

public class TurkeyEggs : ModUpgrade<ThanksgivingMonkey>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 3;
    public override int Cost => 1365;
    public override string Description => "The Turkey lays eggs that people buy";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var Eggs = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModels()[1].Duplicate();
        Eggs.range = towerModel.range;
        Eggs.name = "Eggs_Weapon";
        Eggs.weapons[0].Rate = 15;
        Eggs.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
        Eggs.weapons[0].projectile.AddBehavior(new CreateTowerModel("Eggsplace", GetTowerModel<Eggs>().Duplicate(), 0f, true, false, false, true, true));
        towerModel.AddBehavior(Eggs);
    }
}

public class TurkeyFarm : ModUpgrade<ThanksgivingMonkey>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 4;
    public override int Cost => 4565;
    public override string Description => "Places Turkeys to lay eggs and attack bloons";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        foreach (var attacks in towerModel.GetAttackModels())
        {
            if (attacks.name.Contains("Eggs_Weapon"))
            {
                attacks.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            }
        }
        var EggsT = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModels()[1].Duplicate();
        EggsT.range = towerModel.range;
        EggsT.name = "EggsT_Weapon";
        EggsT.weapons[0].Rate = 10;
        EggsT.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
        EggsT.weapons[0].projectile.AddBehavior(new CreateTowerModel("EggsTplace", GetTowerModel<EggsT>().Duplicate(), 0f, true, false, false, true, true));
        towerModel.AddBehavior(EggsT);
    }
}

public class TurkeyFactory : ModUpgrade<ThanksgivingMonkey>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 5;
    public override int Cost => 75595;
    public override string Description => "The mass production..";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        foreach (var attacks in towerModel.GetAttackModels())
        {
            if (attacks.name.Contains("EggsT_Weapon"))
            {
                attacks.weapons[0].Rate = 5;
            }
        }
    }
}

public class TGG : ModParagonUpgrade<ThanksgivingMonkey>
{
    public override int Cost => 797950;
    public override string Description => "The best thanksgiving for the monkeys...";
    public override string DisplayName => "THE THANKSGIVING MASTER";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var LeafP = Game.instance.model.GetTowerFromId("DartMonkey-500").GetAttackModel().Duplicate();
        LeafP.name = "Leaf_Weapon";
        LeafP.weapons[0].projectile.ApplyDisplay<LeafSDisplay>();
        towerModel.AddBehavior(LeafP);
        var Knockback = Game.instance.model.GetTowerFromId("NinjaMonkey-010").GetWeapon().projectile.GetBehavior<WindModel>().Duplicate<WindModel>();
        Knockback.chance = 0.8f;
        Knockback.distanceMin = 75;
        Knockback.distanceMax = 150;
        attackModel.weapons[0].projectile.AddBehavior(Knockback);
        LeafP.weapons[0].projectile.AddBehavior(Knockback);
        attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = 0;
        LeafP.weapons[0].projectile.GetDamageModel().immuneBloonProperties = 0;
        LeafP.weapons[0].projectile.GetDamageModel().damage += 10;
        attackModel.weapons[0].projectile.GetDamageModel().damage += 50;
        attackModel.weapons[0].rate *= .1f;
        LeafP.weapons[0].rate *= .2f;
        LeafP.weapons[0].projectile.pierce += 300;
        attackModel.weapons[0].projectile.pierce += 300;
        attackModel.range += 50;
        towerModel.range += 50;

        var LeafBP = Game.instance.model.GetTowerFromId("BombShooter-520").GetAttackModel().Duplicate();
        LeafBP.name = "LeafB_Weapon";
        LeafBP.weapons[0].projectile.ApplyDisplay<LeafBDisplay>();
        towerModel.AddBehavior(LeafBP);

        var LeafFP = Game.instance.model.GetTowerFromId("WizardMonkey-022").GetAttackModels()[1].Duplicate();
        LeafFP.name = "LeafF_Weapon";
        LeafFP.weapons[0].projectile.ApplyDisplay<LeafFDisplay>();
        towerModel.AddBehavior(LeafFP);

        var LeafTP = Game.instance.model.GetTowerFromId("TackShooter-205").GetAttackModels()[0].Duplicate();
        LeafTP.name = "LeafT_Weapon";
        LeafTP.weapons[0].projectile.ApplyDisplay<LeafTDisplay>();
        towerModel.AddBehavior(LeafTP);

        var LeafWP = Game.instance.model.GetTowerFromId("Druid-025").GetAttackModel().Duplicate();
        LeafWP.name = "LeafW_Weapon";
        LeafWP.weapons[0].projectile.ApplyDisplay<LeafWDisplay>();
        towerModel.AddBehavior(LeafWP);

        var Ability = Game.instance.model.GetTowerFromId("Gwendolin 20").GetAbilities()[1].Duplicate();
        Ability.maxActivationsPerRound = 9999999;
        Ability.canActivateBetweenRounds = true;
        Ability.resetCooldownOnTierUpgrade = true;
        Ability.cooldown = 15;
        Ability.name = "G1";
        Ability.icon = GetSpriteReference("TUKAb");
        towerModel.AddBehavior(Ability);
    }
}











