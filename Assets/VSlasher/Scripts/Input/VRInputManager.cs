
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInputManager: MonoBehaviour
{
    [SerializeField] ControllerInputHandler leftController = null;
    [SerializeField] ControllerInputHandler rightController = null;

    public bool IsAnyTriggerDown()
    {
        return leftController.triggerButtonDown || rightController.triggerButtonDown;
    }

    public bool IsAnyTriggerStillPressed()
    {
        return leftController.triggerButton || rightController.triggerButton;
    }


    public bool IsAnyControllerActive()
    {
        return true;
    }
}