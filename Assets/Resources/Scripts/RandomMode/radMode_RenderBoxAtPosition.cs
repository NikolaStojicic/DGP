﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Scripts.RandomMode;



public class radMode_RenderBoxAtPosition : MonoBehaviour
{
    private Dictionary<string, Vector3> paletPosition;
    private XML_Reader xmlReader;
    private BoxRender boxRender;
    private int boxPointer;

    List<Box> boxesAtPallet ;
    List<Box> scanBoxes;

    public Box NextBox()    //prvo vrati sve sa prvog nivoa
    {
        if (boxPointer < this.scanBoxes.Count)
            return this.scanBoxes[boxPointer++];
        return null;

    }
    public void BoxScaned(string boxName)
    {
        Vector3 size = xmlReader.getSizeByName(boxName);
        Vector3 position = this.paletPosition[boxName];
        Box tmp = this.scanBoxes.Find(el => el.Name == boxName);
        if (tmp == null)
            this.scanBoxes.Add(new Box(boxName, size, position));
    }
    public void RenderBox(string name)
    {
        this.BoxScaned(name);
        // boxRender = GameObject.FindObjectsOfType<BoxRender>()[0];
        Vector3 size = xmlReader.getSizeByName(name);
        size = size * 1;
        Debug.Log("Detektujem: " + name + ", sa Vektrom3: " + size);
        Vector3 vek = paletPosition[name];
        boxRender.RenderBox(name, paletPosition[name], size);

    }
    private void initialization()
    {
        paletPosition.Add("k7", new Vector3(-.2f, -.1f, -.075f));
        paletPosition.Add("k1", new Vector3(-0.2f, 0.25f, -0.02f));
        paletPosition.Add("k6", new Vector3(-.05f, -.1f, -.04f));
        paletPosition.Add("k5", new Vector3(-0.04f, 0.25f, -0.05f));
        paletPosition.Add("k2", new Vector3(-0.04f, 0.075f, -0.02f));
        paletPosition.Add("k3", new Vector3(-.2f, 0.05f, -.05f));
        paletPosition.Add("k4", new Vector3(0.06f, -0.1f, -0.035f));

    }
    // Start is called before the first frame update
    void Start()
    {
        boxRender = GameObject.FindObjectsOfType<BoxRender>()[0];

        paletPosition = new Dictionary<string, Vector3>();
        this.initialization();
        xmlReader = GameObject.FindObjectOfType<XML_Reader>();

        this.scanBoxes = new List<Box>();
        this.boxesAtPallet = new List<Box>();
        this.boxPointer = 0;

    }

    // Update is called once per frame
    void Update()
    {

    }
}