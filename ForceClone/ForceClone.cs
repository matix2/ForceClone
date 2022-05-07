using MelonLoader;
using UnityEngine;

namespace ForceClone
{
    public class ForceClone : MelonMod
    {
        Hooks.AllowAvatarCopying allowAvatarCopyingHook;

        public override void OnApplicationStart()
        {
            allowAvatarCopyingHook = new Hooks.AllowAvatarCopying(HarmonyInstance);

            Preferences.Initialize();

            if (Preferences.autoHook.Value)
            {
                allowAvatarCopyingHook.Initialize();
                MelonLogger.Msg("Force clone has been auto hooked successfully..");
            }
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(Preferences.hookKey.Value))
            {
                if (!allowAvatarCopyingHook.isHooked)
                {
                    allowAvatarCopyingHook.Initialize();
                    MelonLogger.Msg("Force clone hooked successfully, you may need to rejoin your current world.");
                }
                else
                {
                    MelonLogger.Error("Force clone has already been hooked.");
                }

            }

            if (Input.GetKeyDown(Preferences.unhookKey.Value))
            {
                if (allowAvatarCopyingHook.isHooked)
                {
                    allowAvatarCopyingHook.Release();
                    MelonLogger.Msg("Force clone unhooked successfully, you may need to rejoin your current world.");
                }
                else
                {
                    MelonLogger.Error("Force clone has not been hooked yet.");
                }
            }
        }
    }
}
