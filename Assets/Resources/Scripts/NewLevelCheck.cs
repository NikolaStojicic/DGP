using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevelCheck : MonoBehaviour
{
   
    private XML_Reader _xmlReader;
    //Vector3 size = _xmlReader.getSizeByName(name);
    Dictionary<string, Vector3> boxesAtPallet=new Dictionary<string, Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        this.init();
        check();
    }

    private void init()
    {
        boxesAtPallet.Add("k1", new Vector3(-0.2f, 0.25f, -0.02f)); //Kozel
        boxesAtPallet.Add("k7", new Vector3(-.2f, -.1f, -.075f));
        boxesAtPallet.Add("k6", new Vector3(-.05f, -.1f, -.04f));
        boxesAtPallet.Add("k5", new Vector3(-0.04f, 0.25f, -0.05f));
        //Tuborg
        boxesAtPallet.Add("k3", new Vector3(-.2f, 0.05f, -.05f));
    }
    private void check()
    {
        checkLeveleBellow(new Vector3(-0.2f, 0.25f, -0.07f), "k2");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void boxAdded(Vector3 boxPosition, string boxName)
    {
        boxesAtPallet.Add(boxName, boxPosition);
    }

    bool checkLeveleBellow(Vector3 newBoxPosition, string newBoxName) {

        _xmlReader = GameObject.FindObjectOfType<XML_Reader>();
        Vector3 newBoxsize = _xmlReader.getSizeByName(newBoxName);
        float projectedY = newBoxPosition.y - newBoxsize.y/2;
        Vector3 projectedCentar = new Vector3(newBoxPosition.x, projectedY, newBoxPosition.z);

        foreach (KeyValuePair<string, Vector3> box in boxesAtPallet)
        {
            //box.Key is name of Box, box.Value is centar of box position
            Vector3 bellowBoxSize = _xmlReader.getSizeByName(box.Key);
            projectedCentar.y -= bellowBoxSize.y/2;

            //Rect boxBase = new Rect(box.Value.x-bellowBoxSize.x/2, box.Value.z+bellowBoxSize.z/2, bellowBoxSize.x, bellowBoxSize.z);    //PROVERI !!!!!!
            float xMin = box.Value.x-bellowBoxSize.x/2;
            float xMax = box.Value.x+bellowBoxSize.x/2;
            float zMin = box.Value.z-bellowBoxSize.z/2;
            float zMax = box.Value.z+bellowBoxSize.z/2;

            Rect boxBase = new Rect(new Vector2(xMin, zMax), new Vector2(bellowBoxSize.x, bellowBoxSize.z));    
            if (boxBase.Contains(projectedCentar,true))
            {

               /* List<Vector2> newBoxCorners = new List<Vector2>();
                newBoxCorners.Add(new Vector2((projectedCentar.x - newBoxsize.x / 2), (projectedCentar.z - newBoxsize.z / 2))); //c0
                newBoxCorners.Add(new Vector2((projectedCentar.x + newBoxsize.x / 2), (projectedCentar.z - newBoxsize.z / 2))); //c1
                newBoxCorners.Add(new Vector2((projectedCentar.x + newBoxsize.x / 2), (projectedCentar.z + newBoxsize.z / 2))); //c3
                newBoxCorners.Add(new Vector2((projectedCentar.x - newBoxsize.x / 2), (projectedCentar.z + newBoxsize.z / 2))); //c2
                */
               

                return true;
            }
           
        }
        return false;
    }


     

}
