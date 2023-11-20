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
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using BTD_Mod_Helper;
using Il2CppAssets.Scripts.Utils;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using System.Linq;
using Il2Cpp;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using Kirby;
using CamsPack;

[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace MaxLevelIdot;
public class DartlingGunner230 : ModTower
{
    public override string Portrait => "DIcon";
    public override string Name => "230 Dartling Gunner";
    public override TowerSet TowerSet => TowerSet.Military;
    public override string BaseTower => "DartlingGunner-230";

    public override bool DontAddToShop => true;
    public override int Cost => 0;

    public override int TopPathUpgrades => 0;
    public override int MiddlePathUpgrades => 0;
    public override int BottomPathUpgrades => 0;


    public override string DisplayName => "Dartling Gunner 230";
    public override string Description => "";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.isSubTower = true;
        towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 16f, 1, false, false));
    }
    public class DG230Display : ModTowerDisplay<DartlingGunner230>
    {
        public override string BaseDisplay => GetDisplay(TowerType.DartlingGunner, 2, 3, 0);

        public override bool UseForTower(int[] tiers)
        {
            return true;
        }
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {

        }
    }

}

public class NinjaMonkey204 : ModTower
{
    public override string Portrait => "NIcon";
    public override string Name => "204 Ninja Monkey";
    public override TowerSet TowerSet => TowerSet.Magic;
    public override string BaseTower => "NinjaMonkey-204";

    public override bool DontAddToShop => true;
    public override int Cost => 0;

    public override int TopPathUpgrades => 0;
    public override int MiddlePathUpgrades => 0;
    public override int BottomPathUpgrades => 0;


    public override string DisplayName => "Ninja Monkey 204";
    public override string Description => "";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.isSubTower = true;
        towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 25f, 1, false, false));
    }
    public class NM230Display : ModTowerDisplay<NinjaMonkey204>
    {
        public override string BaseDisplay => GetDisplay(TowerType.NinjaMonkey, 2, 0, 4);

        public override bool UseForTower(int[] tiers)
        {
            return true;
        }
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {

        }
    }

}
public class DartlingGunner250 : ModTower
{
    public override string Portrait => "D2Icon";
    public override string Name => "250 Dartling Gunner";
    public override TowerSet TowerSet => TowerSet.Military;
    public override string BaseTower => "DartlingGunner-250";

    public override bool DontAddToShop => true;
    public override int Cost => 0;

    public override int TopPathUpgrades => 0;
    public override int MiddlePathUpgrades => 0;
    public override int BottomPathUpgrades => 0;


    public override string DisplayName => "Dartling Gunner 250";
    public override string Description => "";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.isSubTower = true;
        towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 25f, 1, false, false));
    }
    public class DG250Display : ModTowerDisplay<DartlingGunner250>
    {
        public override string BaseDisplay => GetDisplay(TowerType.DartlingGunner, 2, 5, 0);

        public override bool UseForTower(int[] tiers)
        {
            return true;
        }
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {

        }
    }

}
public class MaxHatDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "MaxHatDisplay");
    }
}

public class MaxHatSDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "MaxHatSDisplay");
    }
}
public class MaxLevelIdot : ModTower<YoutubeTowers>
{
   // public override TowerSet TowerSet => TowerSet.Primary;
    public override string BaseTower => TowerType.BoomerangMonkey;
    public override int Cost => 700;
    public override int TopPathUpgrades => 5;
    public override int MiddlePathUpgrades => 5;
    public override int BottomPathUpgrades => 5;
    public override string Description => "Look It's the youtuber MAXLEVELIDOT! He Uses His Hat to Pop the Bloons! (2 Damage)";

    public override bool Use2DModel => true;
    public override string Icon => "MILIcon";

    public override string Portrait => "MILIcon";
    public override ParagonMode ParagonMode => ParagonMode.Base555;
    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
     towerModel.GetAttackModel().weapons[0].projectile = Game.instance.model.GetTower(TowerType.BoomerangMonkey).GetAttackModel().weapons[0].projectile.Duplicate();
     towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 2;
     towerModel.GetAttackModel().weapons[0].projectile.ApplyDisplay<MaxHatDisplay>();
    }
    public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
    {
        return towerSet.First(model => model.towerId == TowerType.DartlingGunner).towerIndex + 1;
    }
    public override string Get2DTexture(int[] tiers)
    {
        return "MLIDisplay";
    }
}

public class LongerHat : ModUpgrade<MaxLevelIdot>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 1;
    public override int Cost => 195;
    public override string Description => "Max's Hat Can Pop More Bloons";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].projectile.pierce += 5;
    }
}

public class SpikeyHat : ModUpgrade<MaxLevelIdot>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 2;
    public override int Cost => 620;
    public override string Description => "Max's Hat Does Two More Damage";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage += 2;
        towerModel.GetAttackModel().weapons[0].projectile.ApplyDisplay<MaxHatSDisplay>();
    }
}

public class ButterflyClicks : ModUpgrade<MaxLevelIdot>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 3;
    public override int Cost => 1850;
    public override string Description => "Max's Butterfly Clicks Causes Him to Attack Faster";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].rate -= .3f;
    }
}

public class Mafia : ModUpgrade<MaxLevelIdot>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 4;
    public override int Cost => 6850;
    public override string Description => "Max Gets Help From the Mafia to Pop the Bloons and Earn Some Cash";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var Mafia = Game.instance.model.GetTowerFromId("BombShooter-420").GetAttackModel().Duplicate();
        Mafia.range = towerModel.range;
        Mafia.name = "A_Weapon";
        towerModel.AddBehavior(Mafia);

        towerModel.AddBehavior(Game.instance.model.GetTowerFromId("BananaFarm-005").GetBehavior<PerRoundCashBonusTowerModel>().Duplicate());
        towerModel.GetBehavior<PerRoundCashBonusTowerModel>().cashPerRound = 370;
    }
}
public class Level1000Boss : ModUpgrade<MaxLevelIdot>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 5;
    public override int Cost => 46850;
    public override string Description => "Max Levels Up to the 1000 Level Boss of the Mafia";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var Mafia2 = Game.instance.model.GetTowerFromId("BombShooter-205").GetAttackModel().Duplicate();
        Mafia2.range = towerModel.range;
        Mafia2.name = "B_Weapon";
        towerModel.AddBehavior(Mafia2);

        towerModel.AddBehavior(Game.instance.model.GetTowerFromId("BananaFarm-005").GetBehavior<PerRoundCashBonusTowerModel>().Duplicate());
        towerModel.GetBehavior<PerRoundCashBonusTowerModel>().cashPerRound = 670;

        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage += 25;
        towerModel.GetAttackModel().weapons[0].projectile.pierce += 35;
    }
}

public class StrongArm : ModUpgrade<MaxLevelIdot>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 1;
    public override int Cost => 350;
    public override string Description => "Max Attacks Faster";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].rate -= .1f;
    }
}

public class StrongerArm : ModUpgrade<MaxLevelIdot>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 2;
    public override int Cost => 850;
    public override string Description => "Max Attacks Faster";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].rate -= .2f;
    }
}

public class RocketMinions : ModUpgrade<MaxLevelIdot>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 3;
    public override int Cost => 15285;
    public override string Description => "Max Summons Rocket Minions to Fight the Bloons";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var minon = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
        minon.range = towerModel.range;
        minon.name = "Minon_Weapon";
        minon.weapons[0].Rate = 13f;
        minon.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
    //    farm.weapons[0].projectile.ApplyDisplay<weapondisplays.BananaDisplay>();
        minon.weapons[0].projectile.AddBehavior(new CreateTowerModel("DartlingGunner230place", GetTowerModel<DartlingGunner230>().Duplicate(), 0f, true, false, false, true, true));
        towerModel.AddBehavior(minon);
    }
}

public class RocketPower : ModUpgrade<MaxLevelIdot>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 4;
    public override int Cost => 17500;
    public override string Description => "Max Gets the Power of the Hydra Rocket Pods";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].projectile.pierce += 6;
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage += 3;
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = 0;


        var Ability = Game.instance.model.GetTower(TowerType.DartlingGunner, 2, 4, 0).GetAbilities()[0].Duplicate();
        Ability.maxActivationsPerRound = 9999999;
        Ability.canActivateBetweenRounds = true;
        Ability.resetCooldownOnTierUpgrade = true;
        Ability.cooldown = 25;
        Ability.icon = GetSpriteReference("RocketPower-Icon");
        towerModel.AddBehavior(Ability);
    }
}
public class StickyArmy : ModUpgrade<MaxLevelIdot>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 5;
    public override int Cost => 57500;
    public override string Description => "Max Summons Sticky Bombs to Destroy Moab Class Bloons";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var minon2 = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
        minon2.range = towerModel.range;
        minon2.name = "Minon2_Weapon";
        minon2.weapons[0].Rate = 10f;
        minon2.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
        //    farm.weapons[0].projectile.ApplyDisplay<weapondisplays.BananaDisplay>();
        minon2.weapons[0].projectile.AddBehavior(new CreateTowerModel("NinjaMonkey204place", GetTowerModel<NinjaMonkey204>().Duplicate(), 0f, true, false, false, true, true));
        towerModel.AddBehavior(minon2);

        var minon3 = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
        minon3.range = towerModel.range;
        minon3.name = "Minon3_Weapon";
        minon3.weapons[0].Rate = 10f;
        minon3.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
        //    farm.weapons[0].projectile.ApplyDisplay<weapondisplays.BananaDisplay>();
        minon3.weapons[0].projectile.AddBehavior(new CreateTowerModel("DartlingGunner230place2", GetTowerModel<DartlingGunner230>().Duplicate(), 0f, true, false, false, true, true));
        towerModel.AddBehavior(minon3);

    }
}

public class MoreIq : ModUpgrade<MaxLevelIdot>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 1;
    public override int Cost => 280;
    public override string Description => "Max Gets More Range";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().range += 10;
        towerModel.range += 10;
    }
}

public class EvenMoreIq : ModUpgrade<MaxLevelIdot>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 2;
    public override int Cost => 480;
    public override string Description => "Max Gets Even More Range and Can Pop Camo Bloons";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().range += 15;
        towerModel.range += 15;
        towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel", true));
    }
}

public class BTD7 : ModUpgrade<MaxLevelIdot>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 3;
    public override int Cost => 12480;
    public override string Description => "Max Gets Early Access to BTD7";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var B2 = Game.instance.model.GetTowerFromId("SniperMonkey-302").GetAttackModel().Duplicate();
        B2.range = towerModel.range;
        B2.name = "C_Weapon";
        towerModel.AddBehavior(B2);

        var B22 = Game.instance.model.GetTowerFromId("CaptainChurchill 12").GetAttackModel().Duplicate();
        B22.range = towerModel.range;
        B22.name = "D_Weapon";
        B22.ApplyDisplay<NothingDisplay>();
        towerModel.AddBehavior(B22);
    }
}

public class Hank : ModUpgrade<MaxLevelIdot>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 4;
    public override int Cost => 15290;
    public override string Description => "Max Works With Hank to Make the Bloons Weaker";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().range += 10;
        towerModel.range += 10;
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = 0;

        var C2 = Game.instance.model.GetTowerFromId("IceMonkey-420").GetAttackModel().Duplicate();
        C2.range = towerModel.range;
        C2.name = "E_Weapon";
        towerModel.AddBehavior(C2);

    }
}

public class MrMaxIdot : ModUpgrade<MaxLevelIdot>
{
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 5;
    public override int Cost => 762480;
    public override string Description => "The President Of Monkey City";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().range += 30;
        towerModel.range += 30;

        var W2 = Game.instance.model.GetTowerFromId("DartlingGunner-520").GetAttackModel().Duplicate();
        W2.range = towerModel.range;
        W2.name = "F_Weapon";
        W2.ApplyDisplay<NothingDisplay>();
        towerModel.AddBehavior(W2);
    }
}

public class D : ModParagonUpgrade<MaxLevelIdot>
{
    public override int Cost => 1700000;
    public override string Description => "Djungelskog... the TRUE Monkeys Lord and Savior";
    public override string DisplayName => "Djungelskog";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var Ability = Game.instance.model.GetTower(TowerType.NinjaMonkey, 0, 5, 0).GetAbilities()[0].Duplicate();
        Ability.maxActivationsPerRound = 9999999;
        Ability.canActivateBetweenRounds = true;
        Ability.resetCooldownOnTierUpgrade = true;
        Ability.cooldown = 20;
        Ability.icon = GetSpriteReference("D-Icon");
        towerModel.AddBehavior(Ability);

        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 500;
        towerModel.GetAttackModel().weapons[0].rate *= .2f;    
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = 0;

        var minon4 = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
        minon4.range = towerModel.range;
        minon4.name = "Minon3_Weapon";
        minon4.weapons[0].Rate = 8;
        minon4.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
        //    farm.weapons[0].projectile.ApplyDisplay<weapondisplays.BananaDisplay>();
        minon4.weapons[0].projectile.AddBehavior(new CreateTowerModel("DartlingGunner250place", GetTowerModel<DartlingGunner250>().Duplicate(), 0f, true, false, false, true, true));
        towerModel.AddBehavior(minon4);
    }
}