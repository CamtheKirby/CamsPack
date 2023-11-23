using BananaGun;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using CamsPack;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppSystem.Linq;
using PathsPlusPlus;

namespace Sabre;

public class Sabre : ModTower
{
    public override TowerSet TowerSet => TowerSet.Support;
    public override string BaseTower => TowerType.DartMonkey;
    public override int Cost => 0;
    public override int TopPathUpgrades => 0;
    public override int MiddlePathUpgrades => 0;
    public override int BottomPathUpgrades => 0;
    public override string Description => "Money I LOVE MONEYY PLS GIVE EJIEMEMEME EEMMONNENIIIDeufihfuifefwoiwfufoehowueofweufhwehfffweui";
    public override bool DontAddToShop => true;
    public override bool Use2DModel => true;
    public override string Icon => "SIcon";

    public override string Portrait => "SIcon";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.RemoveBehavior<AttackModel>();
        towerModel.AddBehavior(Game.instance.model.GetTowerFromId("BananaFarm-005").GetBehavior<PerRoundCashBonusTowerModel>().Duplicate());
        towerModel.GetBehavior<PerRoundCashBonusTowerModel>().cashPerRound = 550;
        var Money = Game.instance.model.GetTowerFromId("BananaFarm").GetAttackModel().Duplicate();
        Money.name = "BananaFarm_";
        Money.weapons[0].projectile.GetBehavior<CashModel>().maximum = 66;
        Money.weapons[0].projectile.GetBehavior<CashModel>().minimum = 60;
        towerModel.AddBehavior(Money);
        towerModel.isSubTower = true;
        towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 16f, 1, false, false));
    }

    public override string Get2DTexture(int[] tiers)
    {
        return "SabreDisplay";
    }
}

public class Sabre2 : ModTower
{
    public override TowerSet TowerSet => TowerSet.Support;
    public override string BaseTower => "SuperMonkey-230";
    public override int Cost => 0;
    public override int TopPathUpgrades => 0;
    public override int MiddlePathUpgrades => 0;
    public override int BottomPathUpgrades => 0;
    public override string Description => "Money I LOVE MONEYY PLS GIVE EJIEMEMEME EEMMONNENIIIDeufihfuifefwoiwfufoehowueofweufhwehfffweui";
    public override bool DontAddToShop => true;
    public override bool Use2DModel => true;
    public override string Icon => "SIcon";
    public override string DisplayName => "Sabre";
    public override string Portrait => "SIcon";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.AddBehavior(Game.instance.model.GetTowerFromId("BananaFarm-005").GetBehavior<PerRoundCashBonusTowerModel>().Duplicate());
        towerModel.GetBehavior<PerRoundCashBonusTowerModel>().cashPerRound = 750;
        var Money = Game.instance.model.GetTowerFromId("BananaFarm").GetAttackModel().Duplicate();
        Money.name = "BananaFarm_2";
        Money.weapons[0].projectile.GetBehavior<CashModel>().maximum = 100;
        Money.weapons[0].projectile.GetBehavior<CashModel>().minimum = 60;
        towerModel.AddBehavior(Money);
        towerModel.isSubTower = true;
        towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 16f, 1, false, false));
    }

    public override string Get2DTexture(int[] tiers)
    {
        return "SabreDisplay";
    }
}

public class Sabre3 : ModTower
{
    public override TowerSet TowerSet => TowerSet.Support;
    public override string BaseTower => "SuperMonkey-250";
    public override int Cost => 0;
    public override int TopPathUpgrades => 0;
    public override int MiddlePathUpgrades => 0;
    public override int BottomPathUpgrades => 0;
    public override string Description => "Money I LOVE MONEYY PLS GIVE EJIEMEMEME EEMMONNENIIIDeufihfuifefwoiwfufoehowueofweufhwehfffweui";
    public override bool DontAddToShop => true;
    public override bool Use2DModel => true;
    public override string Icon => "SIcon";
    public override string DisplayName => "Sabre Player 3 Power!";
    public override string Portrait => "SIcon";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        towerModel.AddBehavior(Game.instance.model.GetTowerFromId("BananaFarm-005").GetBehavior<PerRoundCashBonusTowerModel>().Duplicate());
        towerModel.GetBehavior<PerRoundCashBonusTowerModel>().cashPerRound = 2750;
        var Money = Game.instance.model.GetTowerFromId("BananaFarm").GetAttackModel().Duplicate();
        Money.name = "BananaFarm_3";
        Money.weapons[0].projectile.GetBehavior<CashModel>().maximum = 450;
        Money.weapons[0].projectile.GetBehavior<CashModel>().minimum = 350;
        towerModel.AddBehavior(Money);
        towerModel.isSubTower = true;
        towerModel.AddBehavior(new TowerExpireModel("ExpireModel", 10f, 1, false, false));
    }

    public override string Get2DTexture(int[] tiers)
    {
        return "SabreDisplay";
    }
}

public class PayDay : UpgradePlusPlus<SabrePath>
{
    public override int Cost => 4560;
    public override int Tier => 1;
    public override string Icon => "Paymeup";
    public override string Portrait => "Wizard1";

    public override string Description => "Gets $506 every round";

    public override void ApplyUpgrade(TowerModel towerModel, int tier)
    {
        towerModel.AddBehavior(Game.instance.model.GetTowerFromId("BananaFarm-005").GetBehavior<PerRoundCashBonusTowerModel>().Duplicate());
        towerModel.GetBehavior<PerRoundCashBonusTowerModel>().cashPerRound = 506;

        }
    }

public class Sabres : UpgradePlusPlus<SabrePath>
{
    public override int Cost => 10600;
    public override int Tier => 2;
    public override string Icon => "SIcon";
    public override string Portrait => "Wizard1";

    public override string Description => "Places Sabres for more sweet money";

    public override void ApplyUpgrade(TowerModel towerModel, int tier)
    {
        towerModel.AddBehavior(Game.instance.model.GetTowerFromId("BananaFarm-005").GetBehavior<PerRoundCashBonusTowerModel>().Duplicate());
        towerModel.GetBehavior<PerRoundCashBonusTowerModel>().cashPerRound = 506;

        var attackModel = towerModel.GetAttackModel();
        var minon = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
        minon.range = towerModel.range;
        minon.name = "Minon_Weapon";
        minon.weapons[0].Rate = 9f;
        minon.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
        //    farm.weapons[0].projectile.ApplyDisplay<weapondisplays.BananaDisplay>();
        minon.weapons[0].projectile.AddBehavior(new CreateTowerModel("Sabreplace", GetTowerModel<Sabre>().Duplicate(), 0f, true, false, false, true, true));
        towerModel.AddBehavior(minon);
    }
}

public class SabreEnergy : UpgradePlusPlus<SabrePath>
{
    public override int Cost => 11000;
    public override int Tier => 3;
    public override string Icon => "Cursed";
    public override string Portrait => "Wizard1";

    public override string Description => "Gets another $506 and places Sabres Faster";

    public override void ApplyUpgrade(TowerModel towerModel, int tier)
    {
        towerModel.AddBehavior(Game.instance.model.GetTowerFromId("BananaFarm-005").GetBehavior<PerRoundCashBonusTowerModel>().Duplicate());
        towerModel.GetBehavior<PerRoundCashBonusTowerModel>().cashPerRound = 506;
        foreach (var attacks in towerModel.GetAttackModels())
        {
            if (attacks.name.Contains("Minon_Weapon"))
            {
                attacks.weapons[0].Rate = 7f;
            }
        }

    }
}

public class MadSabres : UpgradePlusPlus<SabrePath>
{
    public override int Cost => 15715;
    public override int Tier => 4;
    public override string Icon => "memad";
    public override string Portrait => "Wizard1";

    public override string Description => "Sabers now attack and give more money";

    public override void ApplyUpgrade(TowerModel towerModel, int tier)
    {
        var minon2 = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
        minon2.range = towerModel.range;
        minon2.name = "Minon2_Weapon";
        minon2.weapons[0].Rate = 7f;
        minon2.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
        //    farm.weapons[0].projectile.ApplyDisplay<weapondisplays.BananaDisplay>();
        minon2.weapons[0].projectile.AddBehavior(new CreateTowerModel("Sabreplace", GetTowerModel<Sabre2>().Duplicate(), 0f, true, false, false, true, true));
        towerModel.AddBehavior(minon2);

        foreach (var attacks in towerModel.GetAttackModels())
        {
            if (attacks.name.Contains("Minon_Weapon"))
            {
                attacks.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
            }
        }

    }
}

public class Player3 : UpgradePlusPlus<SabrePath>
{
    public override int Cost => 98775;
    public override int Tier => 5;
    public override string Icon => "Player3deep";
    public override string Portrait => "Wizard1";

    public override string Description => "Player 3's Secret";

    public override void ApplyUpgrade(TowerModel towerModel, int tier)
    {
        var minon3 = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel().Duplicate();
        minon3.range = towerModel.range;
        minon3.name = "Minon3_Weapon";
        minon3.weapons[0].Rate = 15;
        minon3.weapons[0].projectile.RemoveBehavior<CreateTowerModel>();
        //    farm.weapons[0].projectile.ApplyDisplay<weapondisplays.BananaDisplay>();
        minon3.weapons[0].projectile.AddBehavior(new CreateTowerModel("Sabreplace", GetTowerModel<Sabre3>().Duplicate(), 0f, true, false, false, true, true));
        towerModel.AddBehavior(minon3);

        foreach (var attacks in towerModel.GetAttackModels())
        {
            if (attacks.name.Contains("Minon2_Weapon"))
            {
                attacks.weapons[0].Rate = 3f;
            }
        }

    }
}

