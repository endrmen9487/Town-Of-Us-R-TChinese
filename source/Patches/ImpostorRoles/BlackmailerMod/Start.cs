using System;
using HarmonyLib;
using TownOfUs.Roles;

namespace TownOfUs.ImpostorRoles.BlackmailerMod
{
    [HarmonyPatch(typeof(IntroCutscene._CoBegin_d__29), nameof(IntroCutscene._CoBegin_d__29.MoveNext))]
    public static class Start
    {
        public static void Postfix(IntroCutscene._CoBegin_d__29 __instance)
        {
            foreach (var role in Role.GetRoles(RoleEnum.Blackmailer))
            {
                var blackmailer = (Blackmailer) role;
                blackmailer.LastBlackmailed = DateTime.UtcNow;
                blackmailer.LastBlackmailed = blackmailer.LastBlackmailed.AddSeconds(CustomGameOptions.InitialCooldowns - CustomGameOptions.BlackmailCd);
            }
        }
    }
}