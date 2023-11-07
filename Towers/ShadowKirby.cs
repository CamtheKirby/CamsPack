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

public class ShadowKirby : ModTower
{
    public override TowerSet TowerSet => TowerSet.Magic;
    public override string BaseTower => TowerType.SuperMonkey;
    public override int Cost => 590000;
    public override int TopPathUpgrades => 0;
    public override int MiddlePathUpgrades => 5;
    public override int BottomPathUpgrades => 0;
    public override string Description => "....'The Bloons Are No Match For Me'....";

    public override bool Use2DModel => true;
    public override string Icon => "SKIcon";

    public override string Portrait => "SKIcon";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].projectile = Game.instance.model.GetTower(TowerType.SuperMonkey, 2, 0, 5).GetAttackModel().weapons[0].projectile.Duplicate();
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = 0;
        towerModel.GetAttackModel().weapons[0].projectile.ApplyDisplay<ShadDisplay>();
        towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel", true));
        towerModel.towerSelectionMenuThemeId = "Camo";
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 1500000;
        towerModel.GetAttackModel().range += 50;
        towerModel.range += 50;
        towerModel.GetAttackModel().weapons[0].projectile.pierce = 1000;
        towerModel.GetWeapon().projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel", "Moabs", 1, 185, false, true));
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = 0;
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

    public override string Description => "'Nice Now I Can Take These Bloons Down More easliy'";

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

    public override string Description => "'Here's Some Money Spend it Wisely...'";

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

    public override string Description => "'Even More Projectiles? SIGN ME UP!'";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var TornadoS = Game.instance.model.GetTowerFromId("Druid-520").GetAttackModel().Duplicate();
        TornadoS.range = towerModel.range;
        TornadoS.name = "TornadoS_Weapon";
        towerModel.AddBehavior(TornadoS);
        towerModel.GetAttackModel().weapons[0].projectile.pierce += 2;
        towerModel.GetAttackModel().range += 1;
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

    public override string Description => "'Little More Speed Is Perfect and I Guess I Help Others To...'";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].rate *= .003f;

        var buffM1S = new RateSupportModel("RateSupport1", 0.96f, true, "ShadowKirby:Rate", false, 1, null, null, null);
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

    public override string Description => "'YES YES I FEEL THE POWER!'";

    public override void ApplyUpgrade(TowerModel towerModel)
    {

        var Ability = Game.instance.model.GetTower(TowerType.DartlingGunner, 0, 5, 0).GetAbilities()[0].Duplicate();
        Ability.maxActivationsPerRound = 9999999;
        Ability.canActivateBetweenRounds = true;
        Ability.resetCooldownOnTierUpgrade = true;
        Ability.cooldown = 15;
        Ability.icon = GetSpriteReference("KirbyPath4Icon_Icon");
        towerModel.AddBehavior(Ability);

        var AttackModel = towerModel.GetAttackModel();
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 2140000;

        var OP = Game.instance.model.GetTowerFromId("Druid-025").GetAttackModel().Duplicate();
        OP.range = towerModel.range;
        OP.name = "OP_Weapon";
        towerModel.AddBehavior(OP);
        OP.weapons[0].projectile.GetDamageModel().damage = 99999999;
        OP.weapons[0].projectile.pierce = 9999999999999999999;

        towerModel.GetAttackModel().range += 9999999999;
        towerModel.range += 99999999999;

    

        var UltraSwordS = Game.instance.model.GetTowerFromId("SuperMonkey-302").GetAttackModel().Duplicate();
        UltraSwordS.range = towerModel.range;
        UltraSwordS.name = "UltraSwordS_Weapon";
        UltraSwordS.weapons[0].projectile.pierce = 9999999999999999999; // inf lol
        UltraSwordS.weapons[0].projectile.GetDamageModel().damage = 20000;
        towerModel.AddBehavior(UltraSwordS);
        towerModel.GetWeapon().projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel", "Moabs", 1, 485, false, true));
        towerModel.GetAttackModel().weapons[0].projectile.pierce += 1000;
        towerModel.GetAttackModel().range += 50;
        towerModel.range += 50;
    }
}






