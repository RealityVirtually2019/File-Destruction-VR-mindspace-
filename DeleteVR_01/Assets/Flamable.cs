using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamable : MonoBehaviour
{
    public GameObject FlameObject;
    //public GameObject Destroyable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "fire")
        {
            Debug.Log("set on fire by");
            FlameObject.SetActive(true);

            StartCoroutine(Disintegrate());
            
        }
    }

   private IEnumerator Disintegrate()
    {
        yield return new WaitForSeconds(5);
        print("Being Desintegrated" + Time.time);
        GetComponent<Renderer>().material.color = Color.black;
        FlameObject.SetActive(false);
    }

   
}
