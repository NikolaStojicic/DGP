using Assets.Resources.Scripts.RandomMode;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Rand_ScrollView : MonoBehaviour
{
    radMode_RenderBoxAtPosition redModeRende;
    Text scrollViewText;

    // Start is called before the first frame update
    void Start()
    {
        this.redModeRende= GameObject.FindObjectOfType<radMode_RenderBoxAtPosition>();
        this.scrollViewText = this.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void palletPreview()
    {
        if (this.enabled)
            this.enabled = false;
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
            this.enabled = true;
        }
    }
}
