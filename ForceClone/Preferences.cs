using MelonLoader;

namespace ForceClone
{
    public static class Preferences
    {
        public static MelonPreferences_Category forceCloneCategory;
        public static MelonPreferences_Entry<bool> autoHook;

        public static MelonPreferences_Entry<UnityEngine.KeyCode> hookKey;
        public static MelonPreferences_Entry<UnityEngine.KeyCode> unhookKey;

        public static void Initialize()
        {
            forceCloneCategory = MelonPreferences.CreateCategory("ForceClone");

            autoHook = forceCloneCategory.CreateEntry("AutoHook", true);
            hookKey = forceCloneCategory.CreateEntry("HookKey", UnityEngine.KeyCode.F9);
            unhookKey = forceCloneCategory.CreateEntry("UnhookKey", UnityEngine.KeyCode.F10);

            MelonPreferences.Save();
        }
    }
}
