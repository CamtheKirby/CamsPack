using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using MelonLoader;
using static Il2CppSystem.TypeIdentifiers;
using Kirby;
using WaddleDee;
using System.Collections.Generic;
using System.Linq;

[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace MetaKnight;


    public class DMDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "DMDisplay");
    }
}

public class BSDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "BSDisplay");
    }
}
public class MetaKnight : ModTower<CamsPack.KirbyTowers>
{
   // public override TowerSet TowerSet => TowerSet.Magic;
    public override string BaseTower => TowerType.NinjaMonkey;
    public override int Cost => 830;
    public override int TopPathUpgrades => 5;
    public override int MiddlePathUpgrades => 5;
    public override int BottomPathUpgrades => 5;
    public override string Description => "The Star Warrior...";

    public override bool Use2DModel => true;
    public override string Icon => "MetaKIcon";

    public override string Portrait => "MetaKIcon";

    public override ParagonMode ParagonMode => ParagonMode.Base555;
    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile = Game.instance.model.GetTower(TowerType.Sauda).GetAttackModel().weapons[0].projectile.Duplicate();
        attackModel.weapons[0].rate *= .8f;
        attackModel.weapons[0].projectile.GetDamageModel().damage = 3;
        attackModel.range = Game.instance.model.GetTower(TowerType.Sauda).GetAttackModel().range;
        towerModel.range = Game.instance.model.GetTower(TowerType.Sauda).range;
        attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = 0;
    }
    public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
    {
        return towerSet.First(model => model.towerId == TowerType.Druid).towerIndex + 1;
    }
    public override string Get2DTexture(int[] tiers)
    {
        if (tiers[0] == 5)
        {
            return "MetaKTop5";
        }
        if (tiers[1] == 3)
        {
            return "MetaKMiddle3";
        }
        if (tiers[1] == 4)
        {
            return "MetaKMiddle3";
        }
        if (tiers[1] == 5)
        {
            return "MetaKMiddle5";
        }
        if (tiers[2] == 3)
        {
            return "MetaKBottom3";
        }
        if (tiers[2] == 4)
        {
            return "MetaKBottom4";
        }
        if (tiers[2] == 5)
        {
            return "MetaKBottom5";
        }
        return "MetaKDisplay";
    }
}

public class FastSlashing : ModUpgrade<MetaKnight>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 1;
    public override int Cost => 530;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Meta Knight Gets More Speed";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].rate *= .6f;
    }
}

public class StrongerSlashing : ModUpgrade<MetaKnight>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 2;
    public override int Cost => 995;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Meta Knight Does More Damage and Speed";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].rate *= .4f;
        attackModel.weapons[0].projectile.GetDamageModel().damage = 6;
    }
}

public class WingBashing : ModUpgrade<MetaKnight>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 3;
    public override int Cost => 3760;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Meta Knight Uses His Cold Wings To Attack";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.range += 3;
        towerModel.range += 3;
       var Wings = Game.instance.model.GetTowerFromId("SentryCold").GetAttackModel().Duplicate();
        Wings.range = towerModel.range;
        Wings.name = " Wings_Weapon";
        Wings.ApplyDisplay<NothingDisplay>();
        towerModel.AddBehavior(Wings);
       
    }
}

public class SharpenSword : ModUpgrade<MetaKnight>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 4;
    public override int Cost => 56575;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Meta Knight Does More Damage And Attacks Even Faster And Gets More Range!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].rate *= .2f;
        attackModel.weapons[0].projectile.GetDamageModel().damage = 10;
        attackModel.range += 3;
        towerModel.range += 3;
    }
}

public class GalactaPower : ModUpgrade<MetaKnight>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => TOP;
    public override int Tier => 5;
    public override int Cost => 498975;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Let Me Tell You What Happened After Meta Knight Defeated Galacta Knight Well Of Course He Got His Powers...";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].rate *= .1f;
        attackModel.weapons[0].projectile.GetDamageModel().damage = 50;
        attackModel.range += 9;
        towerModel.range += 9;
    }
}

public class LongerSword : ModUpgrade<MetaKnight>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 1;
    public override int Cost => 499;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Meta Knight Gets More Range";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.range += 15;
        towerModel.range += 15;
    }
}

public class EvenLongerSword : ModUpgrade<MetaKnight>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 2;
    public override int Cost => 799;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Meta Knight Gets Even More Range and a little pierce";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.range += 20;
        towerModel.range += 20;
        attackModel.weapons[0].projectile.pierce += 7;
    }
}

public class SyrupSword : ModUpgrade<MetaKnight>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 3;
    public override int Cost => 5499;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Meta Knight Can Now Slow Bloons With His Sitcky Sword and Can Do Gets Little More Range";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.range += 8;
        towerModel.range += 8;
        var Slower = Game.instance.model.GetTowerFromId("GlueGunner-023").GetAttackModel().Duplicate();
        Slower.range = towerModel.range;
        Slower.name = "Slower_Weapon";
        towerModel.AddBehavior(Slower);
        Slower.weapons[0].rate *= .8f;
    }
}

public class SitckyBloonuation : ModUpgrade<MetaKnight>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 4;
    public override int Cost => 8999;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Attack Gets More Speed and Can Knock Back Bloons!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].rate = .6f;

        var Knockback = Game.instance.model.GetTowerFromId("NinjaMonkey-010").GetWeapon().projectile.GetBehavior<WindModel>().Duplicate<WindModel>();
        Knockback.chance = 0.5f;
        Knockback.distanceMin = 25;
        Knockback.distanceMax = 50;
        
        attackModel.weapons[0].projectile.AddBehavior(Knockback);
    }
}

public class AButterfly : ModUpgrade<MetaKnight>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => MIDDLE;
    public override int Tier => 5;
    public override int Cost => 463770;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Bro What Is A Butterfly Gonna Do?";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].rate = .3f;
        attackModel.range += 6;
        towerModel.range += 6;
        attackModel.weapons[0].projectile.GetDamageModel().damage = 65;

        var Ability = Game.instance.model.GetTower(TowerType.BombShooter, 0, 5, 0).GetAbilities()[0].Duplicate();
        Ability.maxActivationsPerRound = 9999999;
        Ability.canActivateBetweenRounds = true;
        Ability.resetCooldownOnTierUpgrade = true;
        Ability.cooldown = 30;
        Ability.icon = GetSpriteReference("Butterfly_Icon");
        towerModel.AddBehavior(Ability);

        var Buttert = Game.instance.model.GetTowerFromId("DartlingGunner-250").GetAttackModel().Duplicate();
        Buttert.range = towerModel.range;
        Buttert.name = " Buttert_Weapon";
        Buttert.weapons[0].projectile.ApplyDisplay<BSDisplay>();
        towerModel.AddBehavior(Buttert);
    }
}

public class SharperBlade : ModUpgrade<MetaKnight>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 1;
    public override int Cost => 230;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Meta Knight Gets More Pierce";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.pierce += 5;
    }
}

public class SuperSharpedBlade : ModUpgrade<MetaKnight>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 2;
    public override int Cost => 830;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Meta Knight Gets More ALOT of Pierce";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].projectile.pierce += 23;
    }
}

public class DarkMagic : ModUpgrade<MetaKnight>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 3;
    public override int Cost => 7499;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Meta Knight Gets The Power of Dark Magic";

     public override void ApplyUpgrade(TowerModel towerModel)
    {
        var DM = Game.instance.model.GetTowerFromId("WizardMonkey-402").GetAttackModel().Duplicate();
        DM.range = towerModel.range + 12; // Cool This Works
        DM.name = "DM_Weapon";
        DM.weapons[0].projectile.ApplyDisplay<DMDisplay>();
        towerModel.AddBehavior(DM);
    }
}
public class DarkSword : ModUpgrade<MetaKnight>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 4;
    public override int Cost => 13499;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "The Power of Dark Magic Goes into Meta Knight's Sword";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].rate = .4f;
        attackModel.weapons[0].projectile.pierce += 50;
        attackModel.range += 15;
        towerModel.range += 15;
        attackModel.weapons[0].projectile.GetDamageModel().damage =+ 30;
    }
}

public class OverTakingDarkness : ModUpgrade<MetaKnight>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Path => BOTTOM;
    public override int Tier => 5;
    public override int Cost => 93499;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "The Power of Dark Magic.... It's Taking Over Him....";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].rate = .2f;
        attackModel.weapons[0].projectile.pierce += 90;
        attackModel.range += 5;
        towerModel.range += 5;
        attackModel.weapons[0].projectile.GetDamageModel().damage =+ 50;

        var broThisIsTheMostEdgynessUpgradeever = Game.instance.model.GetTowerFromId("SentryParagon").GetAttackModel().Duplicate();
        broThisIsTheMostEdgynessUpgradeever.range = towerModel.range + 12;
        broThisIsTheMostEdgynessUpgradeever.name = "broThisIsTheMostEdgynessUpgradeever_Weapon";
        broThisIsTheMostEdgynessUpgradeever.weapons[0].projectile.GetDamageModel().damage =+ 50;
        broThisIsTheMostEdgynessUpgradeever.ApplyDisplay<NothingDisplay>();
        towerModel.AddBehavior(broThisIsTheMostEdgynessUpgradeever);
    }
}


public class KnightMerge : ModParagonUpgrade<MetaKnight>
{
    public override int Cost => 807144;
    public override string Description => "How About We Merge All the Knights!";
    public override string DisplayName => "The Merged Knight";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        attackModel.weapons[0].rate *= .1f;
        attackModel.weapons[0].projectile.pierce += 490;
        var Ability = Game.instance.model.GetTower(TowerType.MortarMonkey, 0, 5, 0).GetAbilities()[0].Duplicate();
        Ability.maxActivationsPerRound = 9999999;
        Ability.canActivateBetweenRounds = true;
        Ability.resetCooldownOnTierUpgrade = true;
        Ability.cooldown = 15;
        Ability.icon = GetSpriteReference("Butterfly_Icon");
        towerModel.AddBehavior(Ability);
    }
 }
