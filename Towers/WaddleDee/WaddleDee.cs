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
using System.Linq;
using System.Collections.Generic;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Filters;

[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace WaddleDee;

    public class WahDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "WahDisplay");
    }
}

public class UmbrellaDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "UmbrellaDisplay");
    }
}

public class WaddleDee : ModTower<KirbyTowers>
{
    //public override TowerSet TowerSet => TowerSet.Support;
    public override string BaseTower => TowerType.DartMonkey;
    public override int Cost => 350;
    public override int TopPathUpgrades => 5;
    public override int MiddlePathUpgrades => 5;
    public override int BottomPathUpgrades => 0;
    public override string Description => "Aww Look it's a Waddle Dee!";

    public override bool Use2DModel => true;
    public override string Icon => "WaddleIcon";

    public override string Portrait => "WaddleIcon";

   
    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile = Game.instance.model.GetTower(TowerType.DartMonkey).GetAttackModel().weapons[0].projectile.Duplicate();
        attackModel.weapons[0].projectile.ApplyDisplay<WahDisplay>();
        attackModel.weapons[0].rate *= .8f;
    }
    public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
    {
        return towerSet.First(model => model.towerId == TowerType.Druid).towerIndex + 1;
    }
    public override string Get2DTexture(int[] tiers)
    {
        if (tiers[0] == 3)
        {
            return "WaddleTop3";
        }
        if (tiers[0] == 4)
        {
            return "WaddleTop4";
        }
        if (tiers[0] == 5)
        {
            return "WaddleTop5";
        }
        if (tiers[1] == 5)
        {
            return "WaddleGoldDisplay";
        }
        if (tiers[1] == 6) // WHY DON'T YOU WORK YOU-
        {
            return "WaddleSDisplay";
        }
        return "WaddleDisplay";
    }
}
public class SharpWahing : ModUpgrade<WaddleDee>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 1;
    public override int Cost => 300;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Waddle Dee Gets More Pierce";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.pierce += 5;
    }
}

public class SharperWahing : ModUpgrade<WaddleDee>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 2;
    public override int Cost => 600;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Waddle Dee Gets Even More Pierce";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.pierce += 10;
    }
}

public class TheSpear : ModUpgrade<WaddleDee>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 3;
    public override int Cost => 850;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Waddle Dee Gets A Close Spear Attack";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.range += 20;
        towerModel.range += 20;
        var Spear = Game.instance.model.GetTowerFromId("Sauda 3").GetAttackModel().Duplicate();
        Spear.name = "SpearDee";
        Spear.weapons[0].projectile.pierce += 3;
        Spear.weapons[0].rate *= .7f;
        Spear.weapons[0].projectile.GetDamageModel().damage += 2;
        Spear.range = Game.instance.model.GetTowerFromId("Sauda 3").GetAttackModel().range;
        Spear.range = Game.instance.model.GetTowerFromId("Sauda 3").range;
        towerModel.AddBehavior(Spear);
    }
}

public class TheBandana : ModUpgrade<WaddleDee>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 4;
    public override int Cost => 3850;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Waddle Dee Gets Blue Bandana to get more price and damage";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.GetDamageModel().damage += 5;
        attackModel.weapons[0].projectile.pierce += 10;

        foreach (var attacks in towerModel.GetAttackModels())
        {
            if (attacks.name.Contains("SpearDee"))
            {
                attacks.weapons[0].projectile.GetDamageModel().damage += 7;
                attacks.weapons[0].projectile.pierce += 10;
                attacks.weapons[0].rate *= .6f;
            }

        }
    }
}

public class BandanaWaddleDee : ModUpgrade<WaddleDee>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 5;
    public override int Cost => 500000;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Waddle Dee Turns into Bandana Waddle dee!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.GetDamageModel().damage += 10;
        attackModel.weapons[0].projectile.pierce += 30;
        attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        foreach (var attacks in towerModel.GetAttackModels())
        {
            if (attacks.name.Contains("SpearDee"))
            {
                attacks.weapons[0].projectile.GetDamageModel().damage += 20;
                attacks.weapons[0].projectile.pierce += 80;
                attacks.weapons[0].rate *= .3f;
                attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            }

        }
    }
}



public class StrongerWahing : ModUpgrade<WaddleDee>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 1;
    public override int Cost => 210;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Waddle Dee Does More Damage";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.GetDamageModel().damage += 2;
    }
}

public class PiercingWah : ModUpgrade<WaddleDee>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 2;
    public override int Cost => 380;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Waddle Dee Gets More Pierce and Can Hit Camo!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.pierce += 5;
        towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel", true));
        towerModel.towerSelectionMenuThemeId = "Camo";
    }
}

public class WahingMoney : ModUpgrade<WaddleDee>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 3;
    public override int Cost => 5860;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Waddle Dee Gets Money and attack speed is increased!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var MoneyDee = Game.instance.model.GetTowerFromId("BananaFarm-220").GetAttackModel().Duplicate();
        MoneyDee.name = "BananaFarm_Dee";
        MoneyDee.weapons[0].projectile.GetBehavior<CashModel>().maximum = 75; // More Buff
        MoneyDee.weapons[0].projectile.GetBehavior<CashModel>().minimum = 60; // Buff
        towerModel.AddBehavior(MoneyDee);
        attackModel.weapons[0].rate *= .4f;
    }
}
public class DoubleWah : ModUpgrade<WaddleDee>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 4;
    public override int Cost => 7950;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Waddle Dee Gets Two Umbrellas!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.ApplyDisplay<UmbrellaDisplay>();
        attackModel.weapons[0].projectile.pierce += 5;
        attackModel.weapons[0].rate *= .4f;
        attackModel.weapons[0].projectile.GetDamageModel().damage += 5;
        attackModel.weapons[0].emission = new ArcEmissionModel("ArcEmissionModel_", 2, 0, 20, null, false, false);



        // ------Bad Old Code--------- \\
        //var Wah2 = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        //Wah2.range = towerModel.range;
        //Wah2.name = "Wah2_Weapon";
        //towerModel.AddBehavior(Wah2);
        //Wah2.weapons[0].projectile.ApplyDisplay<UmbrellaDisplay>();
        //Wah2.weapons[0].rate *= .4f;
        //Wah2.weapons[0].projectile.pierce = 6;
        //Wah2.weapons[0].projectile.GetDamageModel().damage =+ 5;
    }
}

public class GoldenDee : ModUpgrade<WaddleDee>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 5;
    public override int Cost => 600000;

        
        // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

        public override string Description => "The Golden Waddle Dee....";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var MoneyDee2 = Game.instance.model.GetTowerFromId("BananaFarm-520").GetAttackModel().Duplicate();
        MoneyDee2.name = "BananaFarm_Dee2";
        MoneyDee2.weapons[0].projectile.GetBehavior<CashModel>().maximum = 1999;
        MoneyDee2.weapons[0].projectile.GetBehavior<CashModel>().minimum = 750;
        towerModel.AddBehavior(MoneyDee2);

        var Gold = Game.instance.model.GetTowerFromId("SuperMonkey-302").GetAttackModel().Duplicate();
        Gold.range = towerModel.range;
        Gold.name = "Gold_Weapon";
        Gold.weapons[0].projectile.pierce = 10000;
        Gold.weapons[0].projectile.GetDamageModel().damage = 50;
        towerModel.AddBehavior(Gold);

        var Ability = Game.instance.model.GetTower(TowerType.SniperMonkey, 0, 5, 0).GetAbilities()[0].Duplicate();
        Ability.maxActivationsPerRound = 9999999;
        Ability.canActivateBetweenRounds = true;
        Ability.resetCooldownOnTierUpgrade = true;
        Ability.cooldown = 37;
        Ability.icon = GetSpriteReference("WaddleIcon");
        towerModel.AddBehavior(Ability);

        var Ability2 = Game.instance.model.GetTower(TowerType.SuperMonkey, 0, 4, 0).GetAbilities()[0].Duplicate();
        Ability2.maxActivationsPerRound = 9999999;
        Ability2.canActivateBetweenRounds = true;
        Ability2.resetCooldownOnTierUpgrade = true;
        Ability2.cooldown = 37;
        Ability2.icon = GetSpriteReference("WaddleIcon");
        towerModel.AddBehavior(Ability2);

        attackModel.weapons[0].rate *= .2f;
        attackModel.range += 50;
        towerModel.range += 50;
        attackModel.weapons[0].projectile.GetDamageModel().damage += 48;
        towerModel.GetWeapon().projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel", "Moabs", 1, 390, false, true));

            
    }
}

public class SliverDee : UpgradePlusPlus<WaddledeeMiddlePath>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Tier => 6;
    public override int Cost => 85000;

    public override string Container => UpgradeContainerPlatinum;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "THE ULTIMATE WADDLE DEE!!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        towerModel.GetWeapon().projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel", "Moabs", 1, 590, false, true));
        attackModel.range += 50;
        towerModel.range += 50;
        attackModel.weapons[0].projectile.pierce += 50;

        foreach (var attacks in towerModel.GetAttackModels())
        {
            if (attacks.name.Contains("Gold_Weapon"))
            {
                attacks.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel", "Moabs", 1, 390, false, true));
                attacks.weapons[0].projectile.GetDamageModel().damage += 70;
                attacks.weapons[0].projectile.pierce += 50;
            }

        }

        foreach (var attacks in towerModel.GetAttackModels())
        {
            if (attacks.name.Contains("BananaFarm_Dee2"))
            {
                attacks.weapons[0].projectile.GetBehavior<CashModel>().maximum = 3999;
                attacks.weapons[0].projectile.GetBehavior<CashModel>().minimum = 1750;
            }

        }
     }
}


