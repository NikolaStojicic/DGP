using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BoxOrder : MonoBehaviour
{

    XMLBoxReader xmlReader;
    // gameObject.AddComponent<FactionData>();
    IEnumerator emu;

    // Start is called before the first frame update
    void Start()
    {
        this.xmlReader = new XMLBoxReader();
        //this.xmlReader = gameObject.AddComponent<XMLBoxReader>();
        Dictionary<string, Vector3> boxes = this.xmlReader.readSizeOfAllBoxesFromXML();
        using (StreamWriter sw = new StreamWriter("C://Users/EDIT/Documents/UnityEditREPOS/DigitalPalletizingTake2/Assets/Resources/dimensions.txt"))
        {
            foreach (var box in boxes)
            {
                sw.WriteLine("[{0} {1},{2},{3}]", box.Key, box.Value.x, box.Value.y, box.Value.z);
            }
           

        }
        // emu = boc.GetEnumerator();
        BoxOrderingControler boc = new BoxOrderingControler();
        Debug.Log(boc.getNextPositon("k2"));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
