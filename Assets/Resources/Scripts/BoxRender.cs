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
        UI_Main ui = GameObject.FindObjectOfType<UI_Main>();
        ui.setUiStatusSprite(name);
        ui.setUiStatusText("Box is detected!");
        ui.setUiStatusButtonText("Place box");
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
            SoundManager soundManager = GameObject.FindObjectOfType<SoundManager>();
            soundManager.source.Play(0);
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
