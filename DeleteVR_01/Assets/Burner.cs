using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burner : MonoBehaviour
{
   //Burner control: dials burner up and down. Turns Collider on and off.
   private AudioClip burn;
   ParticleSystem burnerPS;
    ParticleSystem.EmissionModule emissionModule;

    public int rateValue = 0;


    // Start is called before the first frame update
    void Start()
    {
        burnerPS = GetComponentInParent<ParticleSystem>();
        emissionModule = burnerPS.emission;

        //GameObject.Find("FlameCollider").GetComponent<Collider>().enabled = false;
  
    
    }

    private void Update()
    {
        //GetValue();
        SetValue();

        if (Input.GetButton("Fire1") && rateValue <= 400)
        {
            rateValue = rateValue + 10;
        }

        if (Input.GetButton("Fire2") && rateValue >= 0)
        {
            rateValue = rateValue - 10;
            //GameObject.Find("FlameCollider").GetComponent<Collider>().enabled = false;

        
        }

        if (rateValue >= 10)
        {
            GameObject.Find("FlameCollider").GetComponent<Collider>().enabled = true;
        }
        else
        {
            GameObject.Find("FlameCollider").GetComponent<Collider>().enabled = false;

        }

        //void GetValue()
        //{
        //print("The constant value is" + emissionModule.rateOverTime.constant);
        //}

       
    }

    void SetValue()
    {
        emissionModule.rateOverTime = rateValue;
    }
}
