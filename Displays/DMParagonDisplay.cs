using System.Collections.Generic;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using UnityEngine;

namespace DarkMonkey.Displays
{
    public class DarkMonkeyParagonDisplay : ModTowerDisplay<DarkMonkey>
    {
        public DarkMonkeyParagonDisplay()
        {
        }

        public DarkMonkeyParagonDisplay(int i)
        {
            ParagonDisplayIndex = i;
        }

        public override string BaseDisplay => GetDisplay(TowerType.DartMonkey);

        public override int ParagonDisplayIndex { get; }

        public override string Name => nameof(DarkMonkeyParagonDisplay) + ParagonDisplayIndex;

        public override bool UseForTower(int[] tiers) => IsParagon(tiers);

        public override IEnumerable<ModContent> Load()
        {
            for (var i = 0; i < TotalParagonDisplays; i++)
            {
                yield return new DarkMonkeyParagonDisplay(i);
            }
        }

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            SetMeshTexture(node, "DarkMonkeyBlinkingDisplayParagon");
            SetMeshTexture(node, nameof(DarkMonkeyParagonDisplay), 1);
            SetMeshTexture(node, nameof(DarkMonkeyParagonDisplay), 2);
            SetMeshOutlineColor(node, new Color(169, 169, 169));
            SetMeshOutlineColor(node, new Color(169, 169, 169), 2);
        }
    }
}