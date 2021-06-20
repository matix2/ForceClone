using System;
using UnityEngine;
using UnityEngine.UI;

namespace ForceClone
{
    class Utils
    {
        public static Transform CreateDefaultButton(string text, string tooltip, Color textColor, float xPos, float yPos, Transform parent, Action listener)
        {
            Transform quickMenu = QuickMenu.prop_QuickMenu_0.transform;
            Transform buttonTransform = UnityEngine.Object.Instantiate(quickMenu.transform.Find("CameraMenu/BackButton").gameObject).transform;

            float buttonWidth = quickMenu.transform.Find("UserInteractMenu/ForceLogoutButton").localPosition.x - quickMenu.transform.Find("UserInteractMenu/BanButton").localPosition.x;
            float buttonHeight = quickMenu.transform.Find("UserInteractMenu/ForceLogoutButton").localPosition.x - quickMenu.transform.Find("UserInteractMenu/BanButton").localPosition.x;

            buttonTransform.localPosition = new Vector3(buttonTransform.localPosition.x + buttonWidth * xPos, buttonTransform.localPosition.y + buttonHeight * yPos, buttonTransform.localPosition.z);

            buttonTransform.SetParent(parent, false);

            buttonTransform.GetComponentInChildren<Text>().text = text;
            buttonTransform.GetComponentInChildren<UiTooltip>().field_Public_String_0 = tooltip;
            buttonTransform.GetComponentInChildren<Text>().color = textColor;

            buttonTransform.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            buttonTransform.GetComponent<Button>().onClick.AddListener(listener);

            return buttonTransform;
        }
    }
}
