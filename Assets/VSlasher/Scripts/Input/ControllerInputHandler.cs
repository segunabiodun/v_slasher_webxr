#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebXR;

public class ControllerInputHandler : MonoBehaviour
{
    private readonly string TRIGGER_BUTTON = "Trigger";
    private readonly string GRIP_BUTTON = "Grip";

    private WebXRController controller;


    public bool triggerButtonDown /*{ get; private set; }*/ = false;
    public bool triggerButton = false;

    void Awake()
    {
        // Retrieve the WebXRController component.
        controller = GetComponent<WebXRController>();
    }

    void Update()
    {
        // Controller hand being used.
        WebXRControllerHand hand = controller.hand;

        // GetButtonDown and GetButtonUp:
        triggerButtonDown = controller.GetButtonDown(TRIGGER_BUTTON);
        if (triggerButtonDown)
        {
            Debug.Log(hand + " controller Trigger is down!");
            //GameManager.instance.StartGame();
        }

        if (controller.GetButtonUp(TRIGGER_BUTTON))
            print(hand + " controller Trigger is up!");

        triggerButton = controller.GetButton(TRIGGER_BUTTON);

        // GetAxis:
        if (controller.GetAxis(GRIP_BUTTON) > 0)
            print(hand + " controller Grip value: " + controller.GetAxis("Grip"));
    }



    //public bool GetIsControllerButtonPressed()
    //{
    //    return controller.GetButton(TRIGGER_BUTTON);
    //}
}

#endif