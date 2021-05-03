using System;
using MelonLoader;
using UnityEngine;
using VRC;
using VRC.UI;

namespace ForceClone
{
    public class Main : MelonMod
    {
        public override void VRChat_OnUiManagerInit()
        {
            Utils.CreateDefaultButton("Force Clone Public Avatar", "Forces the cloning of target's public avatar", Color.white, 0, 1,
                QuickMenu.prop_QuickMenu_0.transform.Find("UserInteractMenu"), new Action(() =>
            {
                string avatarID = QuickMenu.prop_QuickMenu_0.field_Public_MenuController_0.activeAvatar.id;

                if (QuickMenu.prop_QuickMenu_0.field_Public_MenuController_0.activeAvatar.releaseStatus != "private")
                {
                    MelonLogger.Msg("Force Cloning avatar with ID: " + avatarID);
                    new PageAvatar
                    {
                        field_Public_SimpleAvatarPedestal_0 = new SimpleAvatarPedestal
                        {
                            field_Internal_ApiAvatar_0 = QuickMenu.prop_QuickMenu_0.field_Public_MenuController_0.activeAvatar
                        }
                    }.ChangeToSelectedAvatar();
                    VRCUiManager.prop_VRCUiManager_0.Method_Public_Void_Boolean_2(false);
                }
                else
                {
                    MelonLogger.Msg("Avatar ID " + avatarID + " is private");
                    Utils.PopUpAlert("Error!", "Avatar ID " + avatarID + " is private!", "Back");
                }
            }));
        }
    }
}
