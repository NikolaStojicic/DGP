using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Resources.Scripts.RandomMode;

public class Rand_ButtonHandeler : MonoBehaviour
{
    // Start is called before the first frame update
    private MultiTargetDisabler mtd;
    private UI_Main ui;
    radMode_RenderBoxAtPosition redModeRende;
    void Start()
    {
        mtd = GameObject.FindObjectOfType<MultiTargetDisabler>();
        ui = GameObject.FindObjectOfType<UI_Main>();
        redModeRende = GameObject.FindObjectOfType<radMode_RenderBoxAtPosition>();
    }

    public void nextScan()
    {

       
        

        mtd.destroyCollider(ui.name);
      //  mtd.boxPlaced(ui.name);
        mtd.enableMultiTargets();
        ui.setUIALL(UIStatus.Grey, "Scan next box!", "", false, "Scan next");

        SoundManager soundManager = GameObject.FindObjectOfType<SoundManager>();
        soundManager.source.PlayOneShot(soundManager.box);

        GameObject objText = GameObject.FindGameObjectWithTag("box_num").gameObject;
        int num;
        try
        {
            num = int.Parse((objText.GetComponent<Text>().text.Split(' '))[1]);
        }
        catch (System.Exception)
        {

            num = 0;
        }
        objText.GetComponent<Text>().text = "No. " + ++num;
    }



    public void startPacking()
    {
       Box nextBox =redModeRende.NextBox();
        if (nextBox == null)
        {
            ui.setUIALL(UIStatus.Grey, "All Boxex placed", "", false, "DONE");
            return;
        }
        ui.setUIALL(UIStatus.Grey, "Next box to be placed", nextBox.Name, false, "");
       
    }

}

