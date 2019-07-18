using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class XMLReader : MonoBehaviour
{

    [SerializeField]
    public TextAsset xmlFile;
    private readonly string _path = "C://Users/EDIT/Documents/UnityEditREPOS/DigitalPalletizingTake2/Assets/Resources/edit.xml";
    XmlDocument _doc;

    public Dictionary<string, Vector3> readSizeOfAllBoxesFromXML()
    {
        Dictionary<string, Vector3> dict = new Dictionary<string, Vector3>();
        _doc = new XmlDocument();
        _doc.Load(_path);
        // _doc.LoadXml(xmlFile.text);
        List<string> boxNamesLeft = new List<string> { "k1.Front", "k2.Front", "k3.Front", "k4.Front", "k5.Front", "k6.Front", "k7.Front" };
        List<string> boxNamesBottom = new List<string> { "k1.Bottom", "k2.Bottom", "k3.Bottom", "k4.Bottom", "k5.Bottom", "k6.Bottom", "k7.Left" };
        foreach (XmlNode node in _doc.DocumentElement.SelectNodes("/QCARConfig/Tracking/ImageTarget"))
        {
            string boxName = node.Attributes["name"]?.InnerText;
            if (boxNamesLeft.Contains(boxName))
            {
                string boxId = boxName.Split('.')[0];
                if (!dict.ContainsKey(boxId))
                    dict.Add(boxId, (new Vector3()));

                string atrSize = node.Attributes["size"]?.InnerText;
                string[] size = atrSize.Split(' ');
                float y = float.Parse(size[0]);
                float x = float.Parse(size[1]);

                dict[boxId] = new Vector3(x, y, dict[boxId].z);
                //dict[boxId].x = x;
                //dict[boxId].x = x;

            }
            if (boxNamesBottom.Contains(boxName))
            {
                string boxId = boxName.Split('.')[0];
                if (!dict.ContainsKey(boxId))
                    dict.Add(boxId, (new Vector3()));

                string atrSize = node.Attributes["size"]?.InnerText;
                string[] size = atrSize.Split(' ');
                float z = float.Parse(size[1]);

                dict[boxId] = new Vector3(dict[boxId].x, dict[boxId].y, z);
                //dict[boxId].Set(dict[boxId].x, dict[boxId].y,z);

            }
        }
        return dict;
    }


    public Vector3 readBoxSizeFromXML(string boxName)
    {
        _doc = new XmlDocument();

        //_doc.LoadXml(xmlFile.text);
        // Debug.Log(xmlFile);
        _doc.Load(this._path);

        Vector3 vec = new Vector3();
        foreach (XmlNode node in _doc.DocumentElement.SelectNodes("/QCARConfig/Tracking/ImageTarget"))
        {
            string name = node.Attributes["name"]?.InnerText;

            if (name == boxName + ".Left")
            {
                string atrSize = node.Attributes["size"]?.InnerText;
                string[] size = atrSize.Split(' ');
                vec.x = float.Parse(size[0]);
                vec.y = float.Parse(size[1]);
                //Debug.Log(vec);

            }
            if (name == boxName + ".Bottom")
            {
                string atrSize = node.Attributes["size"]?.InnerText;
                string[] size = atrSize.Split(' ');

                vec.z = float.Parse(size[0]);

            }

        }
        return vec;
    }

    /*  protected override void OnTrackingFound()
      {
          if (mTrackableBehaviour)
          {
              var rendererComponents = mTrackableBehaviour.GetComponentsInChildren<Renderer>(true);
              var colliderComponents = mTrackableBehaviour.GetComponentsInChildren<Collider>(true);
              var canvasComponents = mTrackableBehaviour.GetComponentsInChildren<Canvas>(true);

              // Enable rendering:
              foreach (var component in rendererComponents)
                  component.enabled = true;

              // Enable colliders:
              foreach (var component in colliderComponents)
                  component.enabled = true;

              // Enable canvas':
              foreach (var component in canvasComponents)
                  component.enabled = true;

              string name = mTrackableBehaviour.TrackableName;
              Debug.Log(readBoxSizeFromXML(name));


          }
      }*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
