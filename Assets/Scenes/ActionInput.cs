using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class ActionInput : MonoBehaviour
{
    private InputDevice targetDevice;
    public List<GameObject> controllers;
    Animator anim;
    public float newAnimationSpeed = 2f; 

   // public GameObject[] keyPoints;
    //int kpLevel = 0;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetFloat("speed", 0.1f);
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if(devices.Count > 0)
        {
            targetDevice = devices[0];
     
        }

        anim = gameObject.GetComponent<Animator>();



    }

    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);

        if (triggerValue > 0.105f)
        {
            anim.speed += 1;
        }

        
        anim.speed = newAnimationSpeed; 
        
    }
}
