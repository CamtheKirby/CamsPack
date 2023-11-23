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
using PathsPlusPlus;

[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace TGMonkey.ForthPath;

public class LeafDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "LeafDisplay");
    }
}

public class LeafSDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "LeafSDisplay");
    }
}

public class LeafBDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "LeafBDisplay");
    }
}
public class LeafFDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "LeafFDisplay");
    }
}

public class LeafTDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "LeafTDisplay");
    }
}

public class LeafWDisplay : ModDisplay
{
    public override string BaseDisplay => Generic2dDisplay;

    public override void ModifyDisplayNode(UnityDisplayNode node)
    {
        Set2DTexture(node, "LeafWDisplay");
    }
}
public class Leaves : UpgradePlusPlus<TGForthPath>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Tier => 1;
    public override int Cost => 560;
    //public override string Container => UpgradeContainerDiamond;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Shoots out high pierce leaves";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var Leaf = Game.instance.model.GetTowerFromId("DartMonkey-200").GetAttackModel().Duplicate();
        Leaf.name = "Leaf_Weapon";
        Leaf.weapons[0].projectile.ApplyDisplay<LeafDisplay>();
        towerModel.AddBehavior(Leaf);
    }
}

public class WindyLeaves : UpgradePlusPlus<TGForthPath>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Tier => 2;
    public override int Cost => 3000;
    //public override string Container => UpgradeContainerDiamond;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "The leaves knockback the bloons";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        foreach (var attacks in towerModel.GetAttackModels())
        {
            if (attacks.name.Contains("Leaf_Weapon"))
            {
                var Knockback = Game.instance.model.GetTowerFromId("NinjaMonkey-010").GetWeapon().projectile.GetBehavior<WindModel>().Duplicate<WindModel>();
                Knockback.chance = 0.5f;
                Knockback.distanceMin = 25;
                Knockback.distanceMax = 50;
                attacks.weapons[0].projectile.AddBehavior(Knockback);
            }

        }
    }
}

public class SpicyLeaves : UpgradePlusPlus<TGForthPath>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Tier => 3;
    public override int Cost => 520;
    //public override string Container => UpgradeContainerDiamond;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "The leaves do more damage and Can pop Cold and Metal Bloons";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        foreach (var attacks in towerModel.GetAttackModels())
        {
            if (attacks.name.Contains("Leaf_Weapon"))
            {
                attacks.weapons[0].projectile.GetDamageModel().immuneBloonProperties = 0;
                attacks.weapons[0].projectile.GetDamageModel().damage += 5;
                attacks.weapons[0].projectile.ApplyDisplay<LeafSDisplay>();
            }

        }
    }
}

public class ManyLeaves : UpgradePlusPlus<TGForthPath>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Tier => 4;
    public override int Cost => 3100;
    //public override string Container => UpgradeContainerDiamond;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "Leaves shoot super fast and gets more pierce";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        foreach (var attacks in towerModel.GetAttackModels())
        {
            if (attacks.name.Contains("Leaf_Weapon"))
            {
                attacks.weapons[0].rate *= .3f;
                attacks.weapons[0].projectile.pierce += 10;
            }

        }
    }
}

public class LeafMaster : UpgradePlusPlus<TGForthPath>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Tier => 5;
    public override int Cost => 10000;
    //public override string Container => UpgradeContainerDiamond;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "The Master of leaves";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        foreach (var attacks in towerModel.GetAttackModels())
        {
            if (attacks.name.Contains("Leaf_Weapon"))
            {
                attacks.weapons[0].rate *= .2f;
                attacks.weapons[0].projectile.pierce += 100;
            }

        }
    }
}

public class LeafTypes : UpgradePlusPlus<TGForthPath>
{
    // public override string Portrait => "Don't need to override this, using the default of Pair-Portrait.png";
    // public override string Icon => "Don't need to override this, using the default of Pair-Icon.png";
    public override string Portrait => "LuigiIcon";
    public override int Tier => 6;
    public override int Cost => 9500;
    public override string Container => UpgradeContainerDiamond;

    // public override string DisplayName => "Don't need to override this, the default turns it into 'Pair'"

    public override string Description => "The Master of leaves TYPES!";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var LeafB = Game.instance.model.GetTowerFromId("BombShooter-420").GetAttackModel().Duplicate();
        LeafB.name = "LeafB_Weapon";
        LeafB.weapons[0].projectile.ApplyDisplay<LeafBDisplay>();
        towerModel.AddBehavior(LeafB);

        var LeafF = Game.instance.model.GetTowerFromId("WizardMonkey-022").GetAttackModels()[1].Duplicate();
        LeafF.name = "LeafF_Weapon";
        LeafF.weapons[0].projectile.ApplyDisplay<LeafFDisplay>();
        towerModel.AddBehavior(LeafF);

        var LeafT = Game.instance.model.GetTowerFromId("TackShooter-204").GetAttackModels()[0].Duplicate();
        LeafT.name = "LeafT_Weapon";
        LeafT.weapons[0].projectile.ApplyDisplay<LeafTDisplay>();
        towerModel.AddBehavior(LeafT);

        var LeafW = Game.instance.model.GetTowerFromId("Druid-014").GetAttackModel().Duplicate();
        LeafW.name = "LeafW_Weapon";
        LeafW.weapons[0].projectile.ApplyDisplay<LeafWDisplay>();
        towerModel.AddBehavior(LeafW);
    }
}

















