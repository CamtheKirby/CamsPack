using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using CamsPack;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using MelonLoader;
using System.Collections.Generic;
using System.Linq;

[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace ShadowKirby;
public class ShadDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "ShadDisplay");
    }
}
public class SKirbyBuffIcon : ModBuffIcon
{
    protected override int Order => 1;
    public override string Icon => "KirbyBuffIcon";
    public override int MaxStackSize => 5;
}

public class ShadowKirby : ModTower<KirbyTowers>
{
    //public override TowerSet TowerSet => TowerSet.Magic;
    public override string BaseTower => TowerType.SuperMonkey;
    public override int Cost => 1500000;
    public override int TopPathUpgrades => 0;
    public override int MiddlePathUpgrades => 5;
    public override int BottomPathUpgrades => 0;
    public override bool DontAddToShop => !Settings.OpTowers == true;
    public override string Description => "(This is the OP version of Shadow Kirby the balanced version will be in the next update) Shadow Kirby got some power and is now trying destory all bloons";

    public override bool Use2DModel => true;
    public override string Icon => "SKIcon";

    public override string Portrait => "SKIcon";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile = Game.instance.model.GetTower(TowerType.SuperMonkey, 2, 0, 5).GetAttackModel().weapons[0].projectile.Duplicate();
        attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = 0;
        attackModel.weapons[0].projectile.ApplyDisplay<ShadDisplay>();
        towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel", true));
        towerModel.towerSelectionMenuThemeId = "Camo";
        attackModel.weapons[0].projectile.GetDamageModel().damage = 1500000;
        attackModel.range += 50;
        towerModel.range += 50;
        attackModel.weapons[0].projectile.pierce = 1000;
        towerModel.GetWeapon().projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel", "Moabs", 1, 185, false, true));
        attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
    }

    public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
    {
        return towerSet.First(model => model.towerId == TowerType.Druid).towerIndex + 1;
    }
    public override string Get2DTexture(int[] tiers)
    {
        //if (tiers[3] == 1)
        //{
        // return "KirbyFireDisplay";
        // }
        return "SKDisplay";
    }
}

public class ShadowRay : ModUpgrade<ShadowKirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 1;
    public override int Cost => 770904;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Gives Shadow Kirby a Ray attack";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var Ray2 = Game.instance.model.GetTowerFromId("SuperMonkey-202").GetAttackModel().Duplicate();
        Ray2.range = towerModel.range;
        Ray2.name = "Ray2_Weapon";
        towerModel.AddBehavior(Ray2);
        Ray2.weapons[0].projectile.GetDamageModel().damage = 1500000;
        Ray2.weapons[0].projectile.ApplyDisplay<ShadDisplay>();
    }
}

public class ShadowMoney : ModUpgrade<ShadowKirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 2;
    public override int Cost => 789999;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Shadow Kirby makes money";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var MoneyS = Game.instance.model.GetTowerFromId("BananaFarm-520").GetAttackModel().Duplicate();
        MoneyS.name = "BananaFarm_";
        MoneyS.weapons[0].projectile.GetBehavior<CashModel>().maximum = 8000;
        MoneyS.weapons[0].projectile.GetBehavior<CashModel>().minimum = 1000;
        towerModel.AddBehavior(MoneyS);
    }
}

public class ShadowSpread : ModUpgrade<ShadowKirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 3;
    public override int Cost => 989999;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Gives Shadow Kirby More Projectiles";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var TornadoS = Game.instance.model.GetTowerFromId("Druid-520").GetAttackModel().Duplicate();
        TornadoS.range = towerModel.range;
        TornadoS.name = "TornadoS_Weapon";
        towerModel.AddBehavior(TornadoS);
        attackModel.weapons[0].projectile.pierce += 2;
        attackModel.range += 1;
        TornadoS.weapons[0].projectile.GetDamageModel().damage = 1500000;
        towerModel.range += 1;

        var WusicS = Game.instance.model.GetTowerFromId("TackShooter-205").GetAttackModel().Duplicate();
        WusicS.range = towerModel.range;
        WusicS.name = "Wusic_Weapon";
        WusicS.weapons[0].projectile.GetDamageModel().damage = 1500000;
        WusicS.weapons[0].projectile.ApplyDisplay<ShadDisplay>();
        towerModel.AddBehavior(WusicS);
    }
}
public class ShadowCopy : ModUpgrade<ShadowKirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 4;
    public override int Cost => 999999;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Attacks faster and buffs the other towers";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].rate *= .003f;

        var buffM1S = new RateSupportModel("RateSupportModel_", 0.20f, true, "Village:Rate", false, 1, null, null, null);
        buffM1S.ApplyBuffIcon<SKirbyBuffIcon>();
        towerModel.AddBehavior(buffM1S);

    }
}

public class ShadowDeath : ModUpgrade<ShadowKirby>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 5;
    public override int Cost => 29999999;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Reaches his TRUE POWER!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var Ability = Game.instance.model.GetTower(TowerType.DartlingGunner, 0, 5, 0).GetAbilities()[0].Duplicate();
        Ability.maxActivationsPerRound = 9999999;
        Ability.canActivateBetweenRounds = true;
        Ability.resetCooldownOnTierUpgrade = true;
        Ability.cooldown = 15;
        Ability.icon = GetSpriteReference("KirbyPath4Icon_Icon");
        towerModel.AddBehavior(Ability);

        var AttackModel = attackModel;
        attackModel.weapons[0].projectile.GetDamageModel().damage = 2140000;

        var OP = Game.instance.model.GetTowerFromId("Druid-025").GetAttackModel().Duplicate();
        OP.range = towerModel.range;
        OP.name = "OP_Weapon";
        towerModel.AddBehavior(OP);
        OP.weapons[0].projectile.GetDamageModel().damage = 99999999;
        OP.weapons[0].projectile.pierce = 9999999999999999999;

        attackModel.range += 9999999999;
        towerModel.range += 99999999999;

    

        var UltraSwordS = Game.instance.model.GetTowerFromId("SuperMonkey-302").GetAttackModel().Duplicate();
        UltraSwordS.range = towerModel.range;
        UltraSwordS.name = "UltraSwordS_Weapon";
        UltraSwordS.weapons[0].projectile.pierce = 9999999999999999999; // inf lol
        UltraSwordS.weapons[0].projectile.GetDamageModel().damage = 20000;
        towerModel.AddBehavior(UltraSwordS);
        towerModel.GetWeapon().projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel", "Moabs", 1, 485, false, true));
        attackModel.weapons[0].projectile.pierce += 1000;
        attackModel.range += 50;
        towerModel.range += 50;
    }
}






