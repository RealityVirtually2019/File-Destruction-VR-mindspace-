using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MakeStuffFly : MonoBehaviour
{
    bool flew;
    public GameObject[] tgtArray;
    public GameObject mode;

    Text txt;

    // Start is called before the first frame update
    void Start()
    {
        flew = false;
        tgtArray = GameObject.FindGameObjectsWithTag("Target");

    }


    void OnCollisionEnter(Collision collision)
    {
        if (true || flew == false && collision.gameObject.tag == "button")
        {
            GameObject mo = GameObject.Find("MonitorCanvas");
            InstantiateMonitor imScript = mo.GetComponent<InstantiateMonitor>();
            int ct = 0;
            flew = true;
            txt = mode.GetComponentInChildren(typeof(Text)) as Text;
            txt.text = "VR Mode";
            txt.color = new Color(254.0f / 255.0f, 5.0f / 255.0f, 5.0f / 255.0f);
            foreach (GameObject fo in imScript.fileObjectList)
            {
                fo.transform.position = tgtArray[ct].transform.position;
                fo.AddComponent<Rigidbody>();
                ct++;
            }

            Debug.Log("hey");
        }

    }

    void OnTriggerEnter(Collider collision)
    {
        if (true || flew == false && collision.gameObject.tag == "button")
        {
            GameObject mo = GameObject.Find("MonitorCanvas");
            InstantiateMonitor imScript = mo.GetComponent<InstantiateMonitor>();
            int ct = 0;
            flew = true;
            txt = mode.GetComponentInChildren(typeof(Text)) as Text;
            txt.text = "VR Mode";
            txt.color = new Color(254.0f / 255.0f, 5.0f / 255.0f, 5.0f / 255.0f);
            foreach (GameObject fo in imScript.fileObjectList)
            {
                fo.transform.position = tgtArray[ct].transform.position;
                fo.AddComponent<Rigidbody>();
                ct++;
            }

            Debug.Log("hey");
        }

    }
}
