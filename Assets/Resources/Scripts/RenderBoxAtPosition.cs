using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class RenderBoxAtPosition : MonoBehaviour
{
    private Dictionary<string, Vector3> _paletPositions;   
    private XML_Reader _xmlReader;
    private BoxRender _boxRender;
    //private int box;

    public void RenderBox(string name)
    {
        _boxRender = GameObject.FindObjectsOfType<BoxRender>()[0];
        Vector3 size = _xmlReader.getSizeByName(name);
        //size = size * 1;
        //Debug.Log("Detektujem: " + name + ", sa Vektrom3: " + size);

        Vector3 vek = _paletPositions[name];
        _boxRender.RenderBox(name, _paletPositions[name], size);
    }

    /// <summary>
    /// Funkcija inicijalizuje Dictionary, koji mapira naziv kutije na njenu poziciju na paleti
    /// Pozicije na paleti su unapred definisane i rucno izracunate
    /// Sve kutije su direktno postavljene na paletu(u direktnom kontaktu sa njom) 
    /// Broj nivoa: 1
    /// </summary>
    private void initialization1()
    {
        _paletPositions.Add("k7", new Vector3(-.2f,-.1f,-.075f));
        _paletPositions.Add("k1", new Vector3(-0.2f, 0.25f, -0.02f));
        _paletPositions.Add("k6", new Vector3(-.05f,-.1f,-.04f));
        _paletPositions.Add("k5", new Vector3(-0.04f, 0.25f, -0.05f));
        _paletPositions.Add("k2", new Vector3(-0.04f,0.075f,-0.02f));
        _paletPositions.Add("k3", new Vector3(-.2f, 0.05f, -.05f));
        _paletPositions.Add("k4", new Vector3(0.06f, -0.1f, -0.035f));

    }

    /// <summary>
    /// Funkcija inicijalizuje Dictionary, koji mapira naziv kutije na njenu poziciju na paleti
    /// Pozicije na paleti su unapred definisane i rucno izracunate
    /// Kutije ne moraju da budu direktno postavljene na paletu
    /// Broj nivoa: 2
    /// </summary>
    private void initialization2()
    {
        _paletPositions.Add("k7", new Vector3(-.2f, -.1f, -.075f));
        _paletPositions.Add("k1", new Vector3(-0.2f, 0.25f, -0.02f)); //Kozel
        _paletPositions.Add("k6", new Vector3(-.05f, -.1f, -.04f));
        _paletPositions.Add("k5", new Vector3(-0.04f, 0.25f, -0.05f));
        _paletPositions.Add("k2", new Vector3(-0.2f, 0.25f, -0.07f)); //Tuborg
        _paletPositions.Add("k3", new Vector3(-.2f, 0.05f, -.05f));
        _paletPositions.Add("k4", new Vector3(0.06f, -0.1f, -0.035f));

    }

    public List<Vector3> getBoxesAtLevel(int i)
    {
        List<Vector3> boxesAtLevel = new List<Vector3>();

        if(i == 1)
        {
            foreach(KeyValuePair<string,Vector3> _paletPosition in _paletPositions)
            {
                Vector3 _sizeOfCurrentBox = _xmlReader.getSizeByName(_paletPosition.Key);

            }

        }
        if(i == 2)
        {

        }
        return null;
    }

    /// <summary>
    /// Postavlja zeljenu kombinaciju, koju korisnik zadaje iz User interfacea
    /// </summary>
    /// <param name="i">Redni broj kombinacije</param>
    public void setPosition(int i)
    {
        _paletPositions = new Dictionary<string, Vector3>();

        if (i == 1)
        {
            initialization1();
        }
        if(i == 2)
        {
            initialization2();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _paletPositions = new Dictionary<string, Vector3>();
        this.initialization2();

        _xmlReader = GameObject.FindObjectOfType<XML_Reader>();
        //for (int i = 1; i < 8; i++)
        //{
        //    RenderBox("k" + i);
        //}
        //box = 1;
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
