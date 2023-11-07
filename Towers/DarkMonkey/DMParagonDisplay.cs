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
        /// <summary>
        /// All classes that derive from ModContent MUST have a zero argument constructor to work
        /// </summary>
        public DarkMonkeyParagonDisplay()
        {
        }

        public DarkMonkeyParagonDisplay(int i)
        {
            ParagonDisplayIndex = i;
        }

        public override float Scale => .75f + ParagonDisplayIndex * .025f;

        public override string BaseDisplay =>
            Game.instance.model.GetTower("DartMonkey").GetAttackModel().GetBehavior<DisplayModel>().display
                .GUID;

        public override int ParagonDisplayIndex { get; }

        public override string Name => nameof(DarkMonkeyParagonDisplay) + ParagonDisplayIndex;

        public override bool UseForTower(int[] tiers) => IsParagon(tiers);


        /// <summary>
        /// Create a display for each possible ParagonDisplayIndex
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<ModContent> Load()
        {
            for (var i = 0; i < TotalParagonDisplays; i++)
            {
                yield return new DarkMonkeyParagonDisplay(i);
            }
        }

        /// <summary>
        /// Could use the ParagonDisplayIndex property to use different effects based on the paragon strength
        /// <seecref="ModTowerDisplay.ParagonDisplayIndex" />
        /// </summary>
        /// <paramname="node"></param>
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
#if DEBUG
            node.PrintInfo();
            node.SaveMeshTexture();
#endif

            SetMeshTexture(node, nameof(DarkMonkeyParagonDisplay));
        }
    }
}