
//* system references
using System.Collections.Generic;

//* Harmony hook references
using HarmonyLib;
using HarmonyLib.Tools;

//* BepInEx references
using BepInEx;
using BepInEx.Logging;

//* Project Highrise references
using Game.Services;
using Game.Services.Settings;
using Game.Util;

namespace ProjectHighriseAchievementMod
{

	[BepInPlugin("ProjectHighriseAchievementMod.main", "ProjectHighriseAchievementMod", "1.0.0.0")]
	public class ProjectHighriseAchievementMod : BaseUnityPlugin
	{
		void Awake()
		{
			Log.logger = Logger;
			Log.Message("Mod is active!");
			new Harmony("ProjectHighriseAchievementMod.main").PatchAll();
		}
	}

	public static class Log
	{
		public static ManualLogSource logger;
		public static void Message(object data) => logger.LogMessage(data);
		public static void Error(object data) => logger.LogError(data);
		public static void Debug(object data) => logger.LogDebug(data);
		public static void Warning(object data) => logger.LogWarning(data);
	}

	[HarmonyPatch(typeof(AchievementsService), nameof(AchievementsService.OnSessionChange))]
	public static class EnableAchievements
	{
		public static void Postfix(AchievementsService __instance)
		{

			Log.Message("Checking achievement state.");
			__instance._disabled = AchievementsService.DisabledFlags.None;
			
			if (Game.Game.serv.tutorial.IsAnyRunning)
			{
				Log.Message("Achievements are disabled due to tutorial.");
				__instance._disabled |= AchievementsService.DisabledFlags.DueToTutorial;
			}
			if (Game.Game.serv.mods.CountEnabledMods() > 0)
			{
				Log.Message("Workshop mods detected!  Enabling achievements with mods!");
				//// _disabled |= DisabledFlags.DueToMods;
			}
			if (Game.Game.ctx.scenario.unlimited)
			{
				Log.Message("Achievements are disabled due to sandbox mode.");
				__instance._disabled |= AchievementsService.DisabledFlags.DueToUnlimitedMode;
			}
			

			if (__instance._refreshCount >= 1)
			{
				Log.Message("AchievementsService.OnSessionChange(): _refreshCount - " + __instance._refreshCount);
				__instance.CacheGrantedAchievements();
				DictionaryUtil.Clear(__instance._achdefs);
				List<AchievementDefinition> data = Game.Game.serv.globals.settings.achievements.data;
				int i = 0;
				for (int count = data.Count; i < count; i++)
				{
					AchievementDefinition achievementDefinition = data[i];
					DictionaryUtil.Add(__instance._achdefs, achievementDefinition.type, achievementDefinition);
				}
			}
		}
	}

}
