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
public class WaddleDee : ModTower
{
    public override TowerSet TowerSet => TowerSet.Support;
    public override string BaseTower => TowerType.DartMonkey;
    public override int Cost => 450;
    public override int TopPathUpgrades => 0;
    public override int MiddlePathUpgrades => 5;
    public override int BottomPathUpgrades => 0;
    public override string Description => "Aww Look it's a Waddle Dee!";

    public override bool Use2DModel => true;
    public override string Icon => "WaddleIcon";

    public override string Portrait => "WaddleIcon";

   
    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].projectile = Game.instance.model.GetTower(TowerType.DartMonkey).GetAttackModel().weapons[0].projectile.Duplicate();
        towerModel.GetAttackModel().weapons[0].projectile.ApplyDisplay<WahDisplay>();
        towerModel.GetAttackModel().weapons[0].rate *= .7f;
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 2;
    }
    public override string Get2DTexture(int[] tiers)
    {
        if (tiers[1] == 5)
        {
            return "WaddleGoldDisplay";
        }
        return "WaddleDisplay";
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
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 3;
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
        towerModel.GetAttackModel().weapons[0].projectile.pierce = 6;
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
        var MoneyDee = Game.instance.model.GetTowerFromId("BananaFarm-220").GetAttackModel().Duplicate();
        MoneyDee.name = "BananaFarm_Dee";
        MoneyDee.weapons[0].projectile.GetBehavior<CashModel>().maximum = 65;
        MoneyDee.weapons[0].projectile.GetBehavior<CashModel>().minimum = 48; // Buff
        towerModel.AddBehavior(MoneyDee);
        towerModel.GetAttackModel().weapons[0].rate *= .4f;
    }
}
public class DoubleWah : ModUpgrade<WaddleDee>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 4;
    public override int Cost => 7860;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Waddle Dee Gets Two Umbrellas!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].projectile.ApplyDisplay<UmbrellaDisplay>();
        var Wah2 = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        Wah2.range = towerModel.range;
        Wah2.name = "Wah2_Weapon";
        towerModel.AddBehavior(Wah2);
        Wah2.weapons[0].projectile.ApplyDisplay<UmbrellaDisplay>();
        Wah2.weapons[0].rate *= .4f;
        Wah2.weapons[0].projectile.pierce = 6;
        Wah2.weapons[0].projectile.GetDamageModel().damage = 3;
    }
}

public class GoldenDee : ModUpgrade<WaddleDee>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 5;
    public override int Cost => 159960;

        
        // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

        public override string Description => "The Golden Waddle Dee....";

    public override void ApplyUpgrade(TowerModel towerModel)
    {

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

        towerModel.GetAttackModel().weapons[0].rate *= .2f;
        towerModel.GetAttackModel().range += 50;
        towerModel.range += 50;
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 58;
        towerModel.GetWeapon().projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel", "Moabs", 1, 390, false, true));

            
    }
}
   

