using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private MultiTargetDisabler mtd;
    private UI_Main ui;

    void Start()
    {
        mtd = GameObject.FindObjectOfType<MultiTargetDisabler>();
        ui = GameObject.FindObjectOfType<UI_Main>();
    }

    public void nextScan()
    {
        mtd.destroyCollider(ui.name);
        mtd.boxPlaced(ui.name);
        mtd.enableMultiTargets();
        ui.setUIALL(UIStatus.Grey, "Scan next box!", "", false, "Scan next");

        SoundManager soundManager = GameObject.FindObjectOfType<SoundManager>();
        soundManager.source.PlayOneShot(soundManager.box);
    }
}
