﻿using CopySettings.Obje;
using Newtonsoft.Json;
using Serilog.Core;
using System.Collections.Generic;

namespace CopySettings.Hellp
{
    public static class Constants
    {
        public static string Region { get; set; } = "ap";
        public static readonly string ClinePlatform = "ew0KCSJwbGF0Zm9ybVR5cGUiOiAiUEMiLA0KCSJwbGF0Zm9ybU9TIjogIldpbmRvd3MiLA0KCSJwbGF0Zm9ybU9TVmVyc2lvbiI6ICIxMC4wLjE5MDQyLjEuMjU2LjY0Yml0IiwNCgkicGxhdGZvcm1DaGlwc2V0IjogIlVua25vd24iDQp9";
        public static string Version { get; set; } = "release-05.04-shipping-11-751550";
        public static Dictionary<string, string> NameAgents { get; set; } = new()
        {
            {"BountyHunter","Fade"},
            {"Breach","Breach"},
            {"Clay","Raze"},
            {"Deadeye","Chamber"},
            {"Grenadier","KAY/O"},
            {"Guide","Skye"},
            {"Gumshoe","Cypher"},
            {"Hunter_NPE","Sova"},
            {"Hunter","Sova"},
            {"Killjoy","Killjoy"},
            {"Pandemic","Viper"},
            {"Phoenix","Phoenix"},
            {"Rift","Astra"},
            {"Sarge","Brimstone"},
            {"Sprinter","Neon"},
            {"Stealth","Yoru"},
            {"Thorne","Sage"},
            {"Vampire","Reyna"},
            {"Wraith","Omen"},
            {"Wushu","Jett"}
        };

        public static string SettingDefault_string { get; set; } = "{\"actionMappings\":[{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"N\",\"name\":\"InformationalHUD\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"LeftMouseButton\",\"name\":\"PrimaryTrigger\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"RightMouseButton\",\"name\":\"SecondaryTrigger\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"R\",\"name\":\"Reload\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"One\",\"name\":\"Activate_Primary\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"Two\",\"name\":\"Activate_Secondary\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"Three\",\"name\":\"Activate_Melee\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"C\",\"name\":\"Activate_GrenadeAbility\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"C\",\"name\":\"Activate_GrenadeAbility\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"Q\",\"name\":\"Activate_Ability1\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"E\",\"name\":\"Activate_Ability2\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"E\",\"name\":\"Activate_Ability2\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"Four\",\"name\":\"Activate_Level\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"X\",\"name\":\"Activate_Ultimate\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"MouseScrollDown\",\"name\":\"PrevWeapon\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"MouseScrollUp\",\"name\":\"NextWeapon\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"None\",\"name\":\"EquipLastUsed\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"SpaceBar\",\"name\":\"Jump\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"LeftControl\",\"name\":\"Crouch\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"LeftShift\",\"name\":\"Walk\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"F\",\"name\":\"UseObject\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"Z\",\"name\":\"Ping\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"B\",\"name\":\"ToggleShop\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"M\",\"name\":\"ToggleMap\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"F1\",\"name\":\"ToggleCharacterAbilityHUD\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"Tab\",\"name\":\"ShowScoreboard\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"G\",\"name\":\"DropEquippable\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"MiddleMouseButton\",\"name\":\"ToggleMouseCursor\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"CapsLock\",\"name\":\"OpenMegamap\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"T\",\"name\":\"Spray\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"Y\",\"name\":\"Inspect\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"LeftAlt\",\"name\":\"Ghost\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"LeftAlt\",\"name\":\"Ghost\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"None\",\"name\":\"ToggleZoomLevel\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"None\",\"name\":\"ToggleZoomLevel\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"V\",\"name\":\"ToggleFreeCam\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"None\",\"name\":\"ObserverFollowNext\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"None\",\"name\":\"ObserverFollowPrev\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"Period\",\"name\":\"OpenCommMenu\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"None\",\"name\":\"CautionPing\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"None\",\"name\":\"NeedSupportPing\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"None\",\"name\":\"WatchingHerePing\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"Period\",\"name\":\"TogglePlayerLoadoutVisibility\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"F\",\"name\":\"UseAlternateObject\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"F\",\"name\":\"UseAlternateObject\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"None\",\"name\":\"OpenCommTree1\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"None\",\"name\":\"OpenCommTree2\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"None\",\"name\":\"OpenCommTree3\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"None\",\"name\":\"OpenCommTree4\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"None\",\"name\":\"CommWheelIndex\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"None\",\"name\":\"ExpandedCombatCommWheel\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"None\",\"name\":\"StrategyTacticsCommWheel\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"None\",\"name\":\"SocialCommWheel\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"None\",\"name\":\"CountdownPing\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"LeftAlt\",\"name\":\"ShowExtendedInfo\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"One\",\"name\":\"ObservePlayer1\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"Two\",\"name\":\"ObservePlayer2\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"Three\",\"name\":\"ObservePlayer3\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"Four\",\"name\":\"ObservePlayer4\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"Five\",\"name\":\"ObservePlayer5\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"Six\",\"name\":\"ObservePlayer6\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"Seven\",\"name\":\"ObservePlayer7\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"Eight\",\"name\":\"ObservePlayer8\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"Nine\",\"name\":\"ObservePlayer9\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"Zero\",\"name\":\"ObservePlayer10\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"R\",\"name\":\"ToggleSightLines\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"H\",\"name\":\"OutlinesAll\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"J\",\"name\":\"OutlinesFriendly\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"K\",\"name\":\"OutlinesEnemy\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"L\",\"name\":\"OutlinesNone\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"F5\",\"name\":\"VoteOption0\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"F6\",\"name\":\"VoteOption1\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"F7\",\"name\":\"VoteOption2\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"F8\",\"name\":\"VoteOption3\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"LeftShift\",\"name\":\"ModifyObservePlayer\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"None\",\"name\":\"ObserverCycleCinematicCams\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"F\",\"name\":\"ProjectileFollow\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"None\",\"name\":\"ToggleMinimap\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"None\",\"name\":\"VOICE_TeamClutchMuteAction\",\"shift\":false},{\"alt\":false,\"bindIndex\":0,\"characterName\":\"None\",\"cmd\":false,\"ctrl\":false,\"key\":\"None\",\"name\":\"VOICE_PartyClutchMuteAction\",\"shift\":false}],\"axisMappings\":[{\"bindIndex\":0,\"characterName\":\"None\",\"key\":\"W\",\"name\":\"MoveForward\",\"scale\":1},{\"bindIndex\":0,\"characterName\":\"None\",\"key\":\"S\",\"name\":\"MoveForward\",\"scale\":-1},{\"bindIndex\":0,\"characterName\":\"None\",\"key\":\"D\",\"name\":\"MoveRight\",\"scale\":1},{\"bindIndex\":0,\"characterName\":\"None\",\"key\":\"A\",\"name\":\"MoveRight\",\"scale\":-1},{\"bindIndex\":1,\"characterName\":\"None\",\"key\":\"None\",\"name\":\"MoveForward\",\"scale\":-1},{\"bindIndex\":1,\"characterName\":\"None\",\"key\":\"None\",\"name\":\"MoveForward\",\"scale\":1},{\"bindIndex\":1,\"characterName\":\"None\",\"key\":\"None\",\"name\":\"MoveRight\",\"scale\":-1},{\"bindIndex\":1,\"characterName\":\"None\",\"key\":\"None\",\"name\":\"MoveRight\",\"scale\":1}],\"boolSettings\":[{\"settingEnum\":\"EAresBoolSettingName::PushToTalkEnabled\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::FadeCrosshairWithFiringError\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::MuteMusicOnAppWindowDeactivate\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::EnableHRTF\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::ShootingRangeBotArmorEnabled\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::AutoEquipPrioritizeStrongest\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::AutoEquipSkipsMelee\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::ToggleLiveDiagnostics\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::CrosshairDisplayCenterDot\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::CrosshairInnerLinesShowShootingError\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::CrosshairInnerLinesShowLines\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::CrosshairOuterLinesShowMovementError\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::CrosshairOuterLinesShowShootingError\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::CrosshairOuterLinesShowLines\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::CollectionShowOwnedOnly\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::ShowKeybindsOnMinimap\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::CustomPartyVoiceChatEnabled\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::HasSeenNewPlayerSettings\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::MinimapTranslates\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::EnableMinimapVisionCones\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::EnableInstabilityIndicators\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::ShowBulletTracers\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::MouseInverted\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::MinimapRotates\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::MinimapFixedRotation\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::ToggleCrouch\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::DefaultToWalk\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::ToggleWalk\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::RawInputBufferEnabled\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::MouseWheelWrapsInventory\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::MouseWheelIncludesLevelSlot\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::AutoRescopeSniper\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::HoldInputForADS\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::ShowBlood\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::ShowCorpses\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::SpectatorCountWidgetVisible\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::VoipDucksMusicVolume\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::CrosshairUseAdvancedOptions\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::AlwaysShowInventoryWidgets\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::LeftHanded\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::TeamColorCrosshair\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::AllyLoadoutInfoAlwaysVisibile\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::TacticalCalloutsInChat\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::HasSeenSettingsTutorial\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::HasSeenPhotoSensitivityWarning\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::HasEverStartedAMatch\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::HasAcceptedCodeOfConduct\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::IncognitoHideMatchmadePlayerNames\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::IncognitoRejectFriendRequests\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::IncognitoRejectPartyInvitesByDisplayName\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::HideUI\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::HideCrosshair\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::Hide1P\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::ObserversSeeBlinds\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::TeamColorAffectsHUD\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::ShowKeybindsOnMegamap\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::FullscreenMegamap\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::HandednessByTeam\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::HideSpectatedAgentPortrait\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::ObserverToggleScoreboard\",\"value\":false},{\"settingEnum\":\"EAresBoolSettingName::HasEverAppliedRoamingSettings\",\"value\":false}],\"floatSettings\":[{\"settingEnum\":\"EAresFloatSettingName::MouseSensitivity\",\"value\":1},{\"settingEnum\":\"EAresFloatSettingName::MouseSensitivityZoomed\",\"value\":1},{\"settingEnum\":\"EAresFloatSettingName::MinimapSize\",\"value\":1.2},{\"settingEnum\":\"EAresFloatSettingName::MinimapZoom\",\"value\":1},{\"settingEnum\":\"EAresFloatSettingName::OverallVolume\",\"value\":1},{\"settingEnum\":\"EAresFloatSettingName::SoundEffectsVolume\",\"value\":1},{\"settingEnum\":\"EAresFloatSettingName::VoiceOverVolume\",\"value\":1},{\"settingEnum\":\"EAresFloatSettingName::VideoVolume\",\"value\":1},{\"settingEnum\":\"EAresFloatSettingName::AllMusicOverallVolume\",\"value\":1},{\"settingEnum\":\"EAresFloatSettingName::MenuAndLobbyMusicVolume\",\"value\":1},{\"settingEnum\":\"EAresFloatSettingName::CharacterSelectMusicVolume\",\"value\":1},{\"settingEnum\":\"EAresFloatSettingName::PingWheelHoldDelayMS\",\"value\":0},{\"settingEnum\":\"EAresFloatSettingName::GamepadBaseRotationSpeedX\",\"value\":50},{\"settingEnum\":\"EAresFloatSettingName::GamepadBaseRotationSpeedY\",\"value\":50},{\"settingEnum\":\"EAresFloatSettingName::GamepadLookStickInnerDeadzone\",\"value\":0.5},{\"settingEnum\":\"EAresFloatSettingName::GamepadWalkStickInnerDeadzone\",\"value\":0.5},{\"settingEnum\":\"EAresFloatSettingName::ObserverRunSpeedModifier\",\"value\":0.5},{\"settingEnum\":\"EAresFloatSettingName::ObserverWalkSpeedModifier\",\"value\":0.5},{\"settingEnum\":\"EAresFloatSettingName::CrosshairOutlineOpacity\",\"value\":1},{\"settingEnum\":\"EAresFloatSettingName::CrosshairCenterDotSize\",\"value\":1},{\"settingEnum\":\"EAresFloatSettingName::CrosshairCenterDotOpacity\",\"value\":0},{\"settingEnum\":\"EAresFloatSettingName::CrosshairInnerLinesLineLength\",\"value\":2},{\"settingEnum\":\"EAresFloatSettingName::CrosshairInnerLinesLineOffset\",\"value\":20},{\"settingEnum\":\"EAresFloatSettingName::CrosshairInnerLinesOpacity\",\"value\":1},{\"settingEnum\":\"EAresFloatSettingName::CrosshairInnerLinesFiringErrorScale\",\"value\":1},{\"settingEnum\":\"EAresFloatSettingName::CrosshairInnerLinesMovementErrorScale\",\"value\":1},{\"settingEnum\":\"EAresFloatSettingName::CrosshairOuterLinesLineLength\",\"value\":4},{\"settingEnum\":\"EAresFloatSettingName::CrosshairOuterLinesLineOffset\",\"value\":3},{\"settingEnum\":\"EAresFloatSettingName::CrosshairOuterLinesOpacity\",\"value\":1},{\"settingEnum\":\"EAresFloatSettingName::CrosshairSniperCenterDotSize\",\"value\":1.0798875},{\"settingEnum\":\"EAresFloatSettingName::CrosshairSniperCenterDotOpacity\",\"value\":1}],\"intSettings\":[{\"settingEnum\":\"EAresIntSettingName::ColorBlindMode\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::VoiceVolume\",\"value\":50},{\"settingEnum\":\"EAresIntSettingName::MicVolume\",\"value\":50},{\"settingEnum\":\"EAresIntSettingName::MicSensitivityThreshold\",\"value\":50},{\"settingEnum\":\"EAresIntSettingName::PlayerPerfShowFrameTime\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::PlayerPerfShowIdleFrameTime\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::PlayerPerfShowCPUFrameTime\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::PlayerPerfShowGPUFrameTime\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::PlayerPerfShowRHIFrameTime\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::PlayerPerfShowFrameRate\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::PlayerPerfShowServerFrameRate\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::PlayerPerfShowAvailablePhysicalMemory\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::PlayerPerfShowUsedPhysicalMemory\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::PlayerPerfShowNetworkRtt\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::PlayerPerfShowPacketsLostTotal\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::PlayerPerfShowPacketLossPercentage\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::PlayerPerfShowIncomingPacketLossPercentage\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::PlayerPerfShowOutgoingPacketLossPercentage\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::PlayerPerfShowPacketsReceived\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::PlayerPerfShowPacketsSent\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::PlayerPerfShowUploadedData\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::PlayerPerfShowOutgoingPacketSize\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::PlayerPerfShowNetworkJitter\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::PlayerPerfShowEndToEndLatency\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::ShootingRangeSkillTestSetting\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::ShootingRangeDefuseModuleDifficultySetting\",\"value\":0},{\"settingEnum\":\"EAresIntSettingName::MegamapCalloutVisibility\",\"value\":0}],\"roamingSetttingsVersion\":13,\"stringSettings\":[{\"settingEnum\":\"EAresStringSettingName::PushToTalkKey\",\"value\":\"Tilde\"},{\"settingEnum\":\"EAresStringSettingName::CrosshairADSColor\",\"value\":\"(R=254,G=0,B=0,A=255)\"},{\"settingEnum\":\"EAresStringSettingName::CrosshairSniperCenterDotColor\",\"value\":\"(R=254,G=255,B=255,A=255)\"},{\"settingEnum\":\"EAresStringSettingName::CrosshairProfileName\",\"value\":\"Crosshair Profile\"},{\"settingEnum\":\"EAresStringSettingName::SavedCrosshairProfileData\",\"value\":\"{\\\"currentProfile\\\":0,\\\"profiles\\\":[{\\\"primary\\\":{\\\"color\\\":{\\\"b\\\":255,\\\"g\\\":255,\\\"r\\\":255,\\\"a\\\":255},\\\"colorCustom\\\":{\\\"b\\\":255,\\\"g\\\":255,\\\"r\\\":255,\\\"a\\\":255},\\\"bUseCustomColor\\\":false,\\\"bHasOutline\\\":false,\\\"outlineThickness\\\":1,\\\"outlineColor\\\":{\\\"b\\\":0,\\\"g\\\":0,\\\"r\\\":0,\\\"a\\\":255},\\\"outlineOpacity\\\":0.5,\\\"centerDotSize\\\":2,\\\"centerDotOpacity\\\":1,\\\"bDisplayCenterDot\\\":false,\\\"bFadeCrosshairWithFiringError\\\":false,\\\"bShowSpectatedPlayerCrosshair\\\":false,\\\"bHideCrosshair\\\":false,\\\"bTouchCrosshairHighlightEnabled\\\":false,\\\"touchCrosshairHighlightColor\\\":{\\\"b\\\":0,\\\"g\\\":0,\\\"r\\\":255,\\\"a\\\":255},\\\"bFixMinErrorAcrossWeapons\\\":false,\\\"innerLines\\\":{\\\"lineThickness\\\":2,\\\"lineLength\\\":6,\\\"lineLengthVertical\\\":6,\\\"bAllowVertScaling\\\":false,\\\"lineOffset\\\":3,\\\"bShowMovementError\\\":false,\\\"bShowShootingError\\\":false,\\\"bShowMinError\\\":false,\\\"opacity\\\":0.80000001192092896,\\\"bShowLines\\\":false,\\\"firingErrorScale\\\":1,\\\"movementErrorScale\\\":1},\\\"outerLines\\\":{\\\"lineThickness\\\":2,\\\"lineLength\\\":2,\\\"lineLengthVertical\\\":2,\\\"bAllowVertScaling\\\":false,\\\"lineOffset\\\":10,\\\"bShowMovementError\\\":false,\\\"bShowShootingError\\\":false,\\\"bShowMinError\\\":false,\\\"opacity\\\":0.34999999403953552,\\\"bShowLines\\\":false,\\\"firingErrorScale\\\":1,\\\"movementErrorScale\\\":1}},\\\"aDS\\\":{\\\"color\\\":{\\\"b\\\":255,\\\"g\\\":255,\\\"r\\\":255,\\\"a\\\":255},\\\"colorCustom\\\":{\\\"b\\\":255,\\\"g\\\":255,\\\"r\\\":255,\\\"a\\\":255},\\\"bUseCustomColor\\\":false,\\\"bHasOutline\\\":false,\\\"outlineThickness\\\":1,\\\"outlineColor\\\":{\\\"b\\\":0,\\\"g\\\":0,\\\"r\\\":0,\\\"a\\\":255},\\\"outlineOpacity\\\":0.5,\\\"centerDotSize\\\":2,\\\"centerDotOpacity\\\":1,\\\"bDisplayCenterDot\\\":false,\\\"bFadeCrosshairWithFiringError\\\":false,\\\"bShowSpectatedPlayerCrosshair\\\":false,\\\"bHideCrosshair\\\":false,\\\"bTouchCrosshairHighlightEnabled\\\":false,\\\"touchCrosshairHighlightColor\\\":{\\\"b\\\":1,\\\"g\\\":0,\\\"r\\\":0,\\\"a\\\":0},\\\"bFixMinErrorAcrossWeapons\\\":false,\\\"innerLines\\\":{\\\"lineThickness\\\":2,\\\"lineLength\\\":6,\\\"lineLengthVertical\\\":6,\\\"bAllowVertScaling\\\":false,\\\"lineOffset\\\":3,\\\"bShowMovementError\\\":false,\\\"bShowShootingError\\\":false,\\\"bShowMinError\\\":false,\\\"opacity\\\":0.80000001192092896,\\\"bShowLines\\\":false,\\\"firingErrorScale\\\":1,\\\"movementErrorScale\\\":1},\\\"outerLines\\\":{\\\"lineThickness\\\":2,\\\"lineLength\\\":2,\\\"lineLengthVertical\\\":2,\\\"bAllowVertScaling\\\":false,\\\"lineOffset\\\":10,\\\"bShowMovementError\\\":false,\\\"bShowShootingError\\\":false,\\\"bShowMinError\\\":false,\\\"opacity\\\":0.34999999403953552,\\\"bShowLines\\\":false,\\\"firingErrorScale\\\":1,\\\"movementErrorScale\\\":1}},\\\"sniper\\\":{\\\"centerDotColor\\\":{\\\"b\\\":0,\\\"g\\\":0,\\\"r\\\":255,\\\"a\\\":255},\\\"centerDotColorCustom\\\":{\\\"b\\\":255,\\\"g\\\":255,\\\"r\\\":255,\\\"a\\\":255},\\\"bUseCustomCenterDotColor\\\":false,\\\"centerDotSize\\\":1,\\\"centerDotOpacity\\\":0.75,\\\"bDisplayCenterDot\\\":false},\\\"bUsePrimaryCrosshairForADS\\\":false,\\\"bUseCustomCrosshairOnAllPrimary\\\":false,\\\"bUseAdvancedOptions\\\":false,\\\"profileName\\\":\\\"Crosshair Profile\\\"}]}\"}],\"settingsProfiles\":[]}";

        private static Data _SettingDefault;
        private static Data SettingDefault { get => _SettingDefault; }

        private static void inte()
        {
            _SettingDefault = JsonConvert.DeserializeObject<Data>(SettingDefault_string);
        }

        public static Data GetNewData()
        {
            return JsonConvert.DeserializeObject<Data>(SettingDefault_string);
        }



        public static Logger Log { get; set; }
    }
}
