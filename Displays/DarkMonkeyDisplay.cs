using System.Linq;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using UnityEngine;

namespace DarkMonkey.Displays
{
    public class DarkMonkeyBaseDisplay : ModTowerDisplay<DarkMonkey>
    {
        public override string BaseDisplay => GetDisplay(TowerType.DartMonkey);

        public override bool UseForTower(int[] tiers)
        {
            return tiers.Max() < 5;
        }

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            SetMeshTexture(node, "DarkMonkeyBlinkingDisplay");
            SetMeshTexture(node, Name, 2);
        }
    }

    public class DarkMonkey5xxDisplay : ModTowerDisplay<DarkMonkey>
    {
        public override string BaseDisplay => GetDisplay(TowerType.DartMonkey, 5, 0, 0);

        public override bool UseForTower(int[] tiers)
        {
            return tiers[0] == 5;
        }

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            SetMeshTexture(node, "DarkMonkeyBlinkingDisplay");
            SetMeshTexture(node, Name, 1);
        }
    }

    public class DarkMonkeyx5xDisplay : ModTowerDisplay<DarkMonkey>
    {
        public override string BaseDisplay => GetDisplay(TowerType.TackShooter);

        public override bool UseForTower(int[] tiers)
        {
            return tiers[1] == 5;
        }

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            SetMeshTexture(node, Name);
        }
    }

    public class DarkMonkeyxx5Display : ModTowerDisplay<DarkMonkey>
    {
        public override string BaseDisplay => GetDisplay(TowerType.SniperMonkey);

        public override bool UseForTower(int[] tiers)
        {
            return tiers[2] == 5;
        }

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            SetMeshTexture(node, "DarkMonkeyBlinkingDisplayxx5");
            SetMeshTexture(node, Name, 1);
        }
    }
}