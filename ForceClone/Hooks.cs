using System.Reflection;
using VRC.Core;
using MelonLoader;

namespace ForceClone
{
    namespace Hooks
    {
        public class AllowAvatarCopying
        {
            readonly private HarmonyLib.Harmony harmonyInstance;

            public AllowAvatarCopying(HarmonyLib.Harmony harmonyInstance)
            {
                this.harmonyInstance = harmonyInstance;
            }

            private readonly MethodBase originalMethod = typeof(APIUser).GetProperty(nameof(APIUser.allowAvatarCopying)).GetSetMethod();
            private readonly HarmonyLib.HarmonyMethod hookedMethod = new HarmonyLib.HarmonyMethod(typeof(AllowAvatarCopying).GetMethod(nameof(AllowAvatarCopying.Hook),
                BindingFlags.NonPublic | BindingFlags.Static));

            public bool isHooked = false;

            public void Initialize()
            {
                harmonyInstance.Patch(originalMethod, hookedMethod);
                isHooked = true;
            }

            public void Release()
            {
                harmonyInstance.Unpatch(originalMethod, hookedMethod.method);
                isHooked = false;
            }

            private static void Hook(ref bool __0)
            {
                MelonLogger.Msg("Setted");
                __0 = true;
            }
        }
    }
}
