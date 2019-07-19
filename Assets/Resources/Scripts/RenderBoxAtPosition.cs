using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RenderBoxAtPosition : MonoBehaviour
{
    private Dictionary<string, Vector3> _paletPositions;
    private XML_Nikola xml_nikola;
    private BoxRender box_render;
    public void RenderBox(string name)
    {
        Vector3 size = xml_nikola.getSizeByName(name);
        size = size * 2;
        Debug.Log("Detektujem: " + name + ", sa Vektrom3: " + size);
        Vector3 vek = _paletPositions[name];
        box_render.RenderBox(name, _paletPositions[name], size);
    }
    private void initialization()
    {
        _paletPositions.Add("k7", new Vector3(-.35f,-.308f,.42f));
        _paletPositions.Add("k1", new Vector3(-0.35f, 0, 0.5f));
        _paletPositions.Add("k6", new Vector3(0.5962f, 0, 0.10f));
        _paletPositions.Add("k5", new Vector3(.3f, 0, 0));
        _paletPositions.Add("k2", new Vector3(0.1588f, 0, 0.4f));
        _paletPositions.Add("k3", new Vector3(-.520f, 0, 0.4973f));
        _paletPositions.Add("k4", new Vector3(-0.5962f, 0, 0.4992f));

    }
    // Start is called before the first frame update
    void Start()
    {
        _paletPositions = new Dictionary<string, Vector3>();
        this.initialization();
        xml_nikola = GameObject.FindObjectOfType<XML_Nikola>();
        box_render = GameObject.FindObjectOfType<BoxRender>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
