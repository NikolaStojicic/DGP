using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Main : MonoBehaviour
{
    private Image img_plc;
    private Text ui_status;
    private GameObject ui_btn;
    [SerializeField]
    private GameObject boxLogoList;
    // Start is called before the first frame update
    void Start()
    {
        img_plc = GameObject.FindGameObjectWithTag("Img_plc").GetComponent<Image>();
        ui_status = GameObject.FindGameObjectWithTag("Status").GetComponent<Text>();
        ui_btn = GameObject.FindGameObjectWithTag("btn_plc");
        //setUiStatusSprite("k2");
        //setUiStatusButtonText("hh");
        //setUiStatusText("CAo");
    }

    public void setUiStatusText(string text)
    {
        ui_status.text = text;
    }
    
    public void setUiStatusSprite(string name)
    { 
        for (int i = 0; i < boxLogoList.transform.childCount; i++)
        {
            GameObject bll = boxLogoList.transform.GetChild(i).gameObject;
            if(bll.name == name)
            {
                img_plc.sprite = bll.GetComponent<SpriteRenderer>().sprite;
                break;
            }
        }
    }

    public void setUiStatusBtnInteractable(bool bo)
    {
        ui_btn.GetComponent<Button>().interactable = true;
    }

    public void setUiStatusButtonText(string text)
    {
        ui_btn.transform.GetComponentInChildren<Text>().text = text;
    }
}
