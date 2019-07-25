using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Assets.Resources.Scripts.RandomMode;
using System.Text;

public class Rand_ButtonHandeler : MonoBehaviour
{
    // Start is called before the first frame update
    private MultiTargetDisabler mtd;
    private UI_Main ui;
    radMode_RenderBoxAtPosition redModeRende;
    bool firstTimeLucky = true;
    Text scrollViewText;
    GameObject ScrollRect;

    void Start()
    {
        mtd = GameObject.FindObjectOfType<MultiTargetDisabler>();
        ui = GameObject.FindObjectOfType<UI_Main>();
        redModeRende = GameObject.FindObjectOfType<radMode_RenderBoxAtPosition>();
        ScrollRect = GameObject.FindGameObjectWithTag("rand_ScrollView");
        this.scrollViewText = ScrollRect.GetComponentInChildren<Text>();
        this.ScrollRect.SetActive(false);

    }

    public void nextScan()
    {
        if (this.firstTimeLucky)
        {
            this.startPacking();
            this.firstTimeLucky = false;
            return;
        }
        mtd.destroyCollider(ui.name);
      //  mtd.boxPlaced(ui.name);
        mtd.enableMultiTargets();

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
        this.startPacking();

    }
    public void startPacking()
    {
        Box nextBox = redModeRende.NextBox();
        if (nextBox == null)
        {
            ui.setUIALL(UIStatus.Grey, "All Boxex placed", "", false, "DONE");
            return;
        }
        string message = "Next box to be placed is: " + nextBox.Name;
        ui.setUIALL(UIStatus.Grey, message, nextBox.Name, false, "");

    }

    public void btnPalletPreview()
    {
       if (ScrollRect.activeSelf)
            ScrollRect.gameObject.SetActive(false);
        else
        {
            StringBuilder msg = new StringBuilder();
            msg.AppendLine("PALLET STAT");
            foreach (Box box in this.redModeRende.getBoxesAtPallet())
            {
                // Text tmp = ScrollRect.transform.GetComponent<Text>();
                //Text tmp = ScrollRect.GetComponentInChildren<Text>();
                msg.Append("Box name:");
                msg.Append(box.Name);
                msg.Append(" ,box size: ");
                msg.Append(box.Size.ToString());
                msg.AppendLine();
            }
            scrollViewText.text = msg.ToString();
            ScrollRect.gameObject.SetActive(true);
        }
    }

}

