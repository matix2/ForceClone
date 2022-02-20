using System;
using System.Collections;
using MelonLoader;
using UnityEngine;
using VRC.UI;
using VRC.Core;
using UnityEngine.UI;

namespace ForceClone
{
    public class Main : MelonMod
    {
        GameObject quickMenu;
        public override void OnApplicationStart()
        {
            MelonCoroutines.Start(QMInitializer());
        }

        private IEnumerator QMInitializer()
        {
            while ((quickMenu = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)")) == null)
                yield return null;

            OnQMInit();
        }

        private void OnQMInit()
        {
            Transform screens =  GameObject.Find("UserInterface/MenuContent/Screens/").transform;
            PageWorldInfo pageWorldInfo = screens.Find("WorldInfo").GetComponent<PageWorldInfo>();

            MenuController menuController = pageWorldInfo.field_Public_MenuController_0;
            PageAvatar avatarPage = screens.Find("Avatar").GetComponent<PageAvatar>();
            ApiAvatar oldApiAvatar = avatarPage.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0;

            Transform buttonParent = quickMenu.transform.Find("Container/Window/QMParent/Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UserActions");

            Utils.CreateDefaultButton("Force Clone Public Avatar", new Vector3(0, -25, 0), "Force the clone of this user's public avatar", Color.white, buttonParent,
                new Action(() => {
                    string avatarID = menuController.activeAvatarId;

                    if (menuController.activeAvatar.releaseStatus != "private")
                    {
                        avatarPage.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = new ApiAvatar { id = avatarID };

                        avatarPage.ChangeToSelectedAvatar();

                        avatarPage.field_Public_SimpleAvatarPedestal_0.field_Internal_ApiAvatar_0 = oldApiAvatar;
                    }
                    else
                    {
                        MelonLogger.Error("Avatar ID " + avatarID + " is private!");
                    }
                }));
        }


    }
}
