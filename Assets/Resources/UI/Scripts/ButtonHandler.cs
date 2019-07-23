using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private MultiTargetDisabler mtd;
    private UI_Main ui_main;
    void Start()
    {
        mtd = GameObject.FindObjectOfType<MultiTargetDisabler>();
        ui_main = GameObject.FindObjectOfType<UI_Main>();
    }

    public void nextScan()
    {
        mtd.destroyCollider(ui_main.name);
        mtd.boxPlaced(ui_main.name);
        mtd.enableMultiTargets();
        ui_main.setUIALL(UIStatus.Grey, "Scan next box!", "", false, "Scan next");
    }
}
