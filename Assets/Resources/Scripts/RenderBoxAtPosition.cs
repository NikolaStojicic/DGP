using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RenderBoxAtPosition : MonoBehaviour
{
    private Dictionary<string, Vector3> paletPosition;
    private XML_Reader xmlReader;
    private BoxRender boxRender;
    private int box;
    private MultiTargetDisabler mtd;
    


    public void RenderBox(string name)
    {
        boxRender = GameObject.FindObjectsOfType<BoxRender>()[0];
        Vector3 size = xmlReader.getSizeByName(name);
        size = size * 1;
        Debug.Log("Detektujem: " + name + ", sa Vektrom3: " + size);
        Vector3 vek = paletPosition[name];
        boxRender.RenderBox(name, paletPosition[name], size);
        mtd.disableMultiTargets(name);
    }
    private void initialization()
    {
        paletPosition.Add("k7", new Vector3(-.2f,-.1f,-.075f));
        paletPosition.Add("k1", new Vector3(-0.2f, 0.25f, -0.02f));
        paletPosition.Add("k6", new Vector3(-.05f,-.1f,-.04f));
        paletPosition.Add("k5", new Vector3(-0.04f, 0.25f, -0.05f));
        paletPosition.Add("k2", new Vector3(-0.04f,0.075f,-0.02f));
        paletPosition.Add("k3", new Vector3(-.2f, 0.05f, -.05f));
        paletPosition.Add("k4", new Vector3(0.06f, -0.1f, -0.035f));

    }
    // Start is called before the first frame update
    void Start()
    {
        mtd = FindObjectOfType<MultiTargetDisabler>();
        paletPosition = new Dictionary<string, Vector3>();
        this.initialization();
        xmlReader = GameObject.FindObjectOfType<XML_Reader>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
