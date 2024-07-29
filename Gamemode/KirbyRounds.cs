using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Bloons;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Scenarios;
using BTD_Mod_Helper.Extensions;
using CamsPack;
using Il2Cpp;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons;
using Il2CppAssets.Scripts.Models.Difficulty;
using Il2CppAssets.Scripts.Models.Rounds;
using MelonLoader;
using System;
using UnityEngine.UIElements;
using Kirbybloons;
using UnityEngine.Rendering;

[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace Kirbyrounds;

class KirbyRounds : ModGameMode
{
    public override string Difficulty => DifficultyType.Hard;

    public override string BaseGameMode => GameModeType.None;
    public override string Icon => "KBA";

    public override string DisplayName => "Kirby's Bloon Attack! (UNFINSHED)";

    public override void ModifyBaseGameModeModel(ModModel gameModeModel)
    {
        gameModeModel.SetEndingRound(150);
        gameModeModel.UseRoundSet<KBA>();
    }
}

class KBA : ModRoundSet
{
    public override string BaseRoundSet => RoundSetType.Default;

    public override int DefinedRounds => 150;

    public override string DisplayName => "Kirby's Bloon Attack!";

    public override bool CustomHints => false;

    public override void ModifyEasyRoundModels(RoundModel roundModel, int round)
    {
        switch (round)
        {
            case 9:
                roundModel.AddBloonGroup<Waddledeeb>(5, 0, 100);
                break;
        }
    }
}