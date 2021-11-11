using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ForceClone
{
    class Utils
    {
        public static Transform CreateDefaultButton(string text, Vector3 textPosition, string tooltip, Color textColor, Transform parent, Action listener)
        {
            Transform quickMenu = GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)").transform;
            Transform buttonBase = quickMenu.transform.Find("Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_Respawn");
            Transform buttonTransform = UnityEngine.Object.Instantiate(buttonBase, parent).transform;

            buttonTransform.GetComponentInChildren<TextMeshProUGUI>().text = text;
            buttonTransform.GetComponentInChildren<TextMeshProUGUI>().color = textColor;
            buttonTransform.GetComponentInChildren<TextMeshProUGUI>().rectTransform.localPosition = textPosition;
            buttonTransform.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = tooltip;

            buttonTransform.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            buttonTransform.GetComponent<Button>().onClick.AddListener(listener);

            UnityEngine.Object.Destroy(buttonTransform.transform.Find("Icon").gameObject);
            UnityEngine.Object.Destroy(buttonTransform.transform.Find("Icon_Secondary").gameObject);

            buttonTransform.gameObject.SetActive(true);

            return buttonTransform;
        }
    }
}