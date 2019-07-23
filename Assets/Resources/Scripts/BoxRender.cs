using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxRender : MonoBehaviour
{

    [SerializeField]
    private GameObject boxPrefab;
    private Dictionary<string,GameObject> dictBox;

    private void UI_Control(string name)
    {
        UI_Main ui_main = GameObject.FindObjectOfType<UI_Main>();
        ui_main.setUiStatusSprite(name);
        ui_main.setUiStatusText("Box is detected!");
        ui_main.setUiStatusButtonText("Scan box");
    }
    public void RenderBox(string name, Vector3 pos, Vector3 size)
    {
        if (!dictBox.ContainsKey(name))
        {

            GameObject b = Instantiate(boxPrefab, this.transform.GetChild(0).transform);
            b.transform.localPosition = pos ;
            b.transform.localScale = size;
            b.transform.rotation = transform.rotation;
            dictBox.Add(name, b);
            // Veza sa UI
            UI_Control(name);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        dictBox = new Dictionary<string, GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
