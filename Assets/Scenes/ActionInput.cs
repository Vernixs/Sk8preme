using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class ActionInput : MonoBehaviour
{
    private InputDevice targetDevice;
    public List<GameObject> controllers;
    public float speed = 1f;
    public float maxspeed = 15f;
    private float minspeed = 5f;
    public GameObject player;
    void Start()
    {
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


    }

    void Update()
    {

        
    }
    void MovementSpeed()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);

        if (triggerValue > 0.105f)
        {

            speed = speed + 1f;
            /*.velocity = transform.forward * speed;*/
            Debug.Log(speed);
        }
    }
}
