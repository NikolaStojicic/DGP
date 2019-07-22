using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class RenderBoxAtPosition : MonoBehaviour
{
    private Dictionary<string, Vector3> _paletPositions;    //hard-coded positions of boxes
    private XML_Reader _xmlReader;
    private BoxRender box_render;
    private int box;

    public void RenderBox(string name)
    {
        box_render = GameObject.FindObjectsOfType<BoxRender>()[0];
        Vector3 size = _xmlReader.getSizeByName(name);
        size = size * 1;
        Debug.Log("Detektujem: " + name + ", sa Vektrom3: " + size);
        Vector3 vek = _paletPositions[name];
        box_render.RenderBox(name, _paletPositions[name], size);
    }
    private void initialization()
    {
        _paletPositions.Add("k7", new Vector3(-.2f,-.1f,-.075f));
        _paletPositions.Add("k1", new Vector3(-0.2f, 0.25f, -0.02f));
        _paletPositions.Add("k6", new Vector3(-.05f,-.1f,-.04f));
        _paletPositions.Add("k5", new Vector3(-0.04f, 0.25f, -0.05f));
        _paletPositions.Add("k2", new Vector3(-0.04f,0.075f,-0.02f));
        _paletPositions.Add("k3", new Vector3(-.2f, 0.05f, -.05f));
        _paletPositions.Add("k4", new Vector3(0.06f, -0.1f, -0.035f));

    }
    // Start is called before the first frame update
    void Start()
    {
        _paletPositions = new Dictionary<string, Vector3>();
        this.initialization();
        _xmlReader = GameObject.FindObjectOfType<XML_Reader>();
        /*for (int i = 1; i < 8; i++)
        {
            RenderBox("k" + i);
        }*/
        box = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown("space"))
        //{
        //    RenderBox("k" + box);
        //    box++;
        //}
       
    }
}
