using System.Collections.Generic;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Extensions;
using UnityEngine;

namespace Kirby.Displays
{
    public class KirbyParagonDisplay : ModTowerDisplay<Kirby>
    {
        /// <summary>
        /// All classes that derive from ModContent MUST have a zero argument constructor to work
        /// </summary>
        public KirbyParagonDisplay()
        {
        }

        public KirbyParagonDisplay(int i)
        {
            ParagonDisplayIndex = i;
        }
        public override string BaseDisplay => Generic2dDisplay;
        public override int ParagonDisplayIndex { get; }

        public override string Name => nameof(KirbyParagonDisplay) + ParagonDisplayIndex;

        public override bool UseForTower(int[] tiers) => IsParagon(tiers);


        /// <summary>
        /// Create a display for each possible ParagonDisplayIndex
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<ModContent> Load()
        {
            for (var i = 0; i < TotalParagonDisplays; i++)
            {
                yield return new KirbyParagonDisplay(i);
            }
        }

        /// <summary>
        /// Could use the ParagonDisplayIndex property to use different effects based on the paragon strength
        /// <seecref="ModTowerDisplay.ParagonDisplayIndex" />
        /// </summary>
        /// <paramname="node"></param>
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "StarRodDisplay");
        }
    }
}