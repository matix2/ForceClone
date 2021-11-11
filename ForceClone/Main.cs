using System;
using System.Collections;
using MelonLoader;
using UnityEngine;
using VRC;
using VRC.UI;
using VRC.Core;

namespace ForceClone
{
    public class Main : MelonMod
    {
        public override void OnApplicationStart()
        {
            MelonCoroutines.Start(UiManagerInitializer());
        }

        private IEnumerator UiManagerInitializer()
        {
            while (VRCUiManager.prop_VRCUiManager_0 == null)
                yield return null;

            OnUiManagerInit();
        }

        private void OnUiManagerInit()
        {
            Utils.CreateDefaultButton("Force Clone Public Avatar", "Forces the cloning of target's public avatar", Color.white, 0, 1,
                QuickMenu.prop_QuickMenu_0.transform.Find("UserInteractMenu"), new Action(() =>
            {
                string avatarID = QuickMenu.prop_QuickMenu_0.field_Public_MenuController_0.activeAvatar.id;

                if (QuickMenu.prop_QuickMenu_0.field_Public_MenuController_0.activeAvatar.releaseStatus != "private")
                {
                    MelonLogger.Msg("Force Cloning avatar with ID: " + avatarID);
                    VRC.UI.PageAvatar avatarMenu = GameObject.Find("Screens").transform.Find("Avatar").GetComponent<VRC.UI.PageAvatar>();
                    avatarMenu.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar
                    {
                        id = avatarID
                    };
                    avatarMenu.ChangeToSelectedAvatar();
                }
                else
                {
                    MelonLogger.Msg("Avatar ID " + avatarID + " is private!");
                }
            }));
        }
    }
}
