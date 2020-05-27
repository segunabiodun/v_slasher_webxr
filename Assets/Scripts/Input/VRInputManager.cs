using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInputManager: MonoBehaviour
{
    [SerializeField] ControllerInputHandler leftController;
    [SerializeField] ControllerInputHandler rightController;

    public bool IsAnyTriggerDown()
    {
        return leftController.triggerButtonDown || rightController.triggerButtonDown;
    }

    public bool IsAnyTriggerPressed()
    {
        return leftController.triggerButtonPressed || rightController.triggerButtonPressed;
    }


    public bool IsAnyControllerActive()
    {
        return true;
    }
}
