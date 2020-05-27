using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] VRInputManager vrInputManager = null;
    [SerializeField] Laser laser = null;


    // Update is called once per frame
    void Update()
    {
        if (GameManager.isPaused)
            return;

        if (vrInputManager.IsAnyTriggerPressed() && laser.hit3DObject)
        {
            Virus virus = laser.hit3DObject.GetComponent<Virus>();
            if (virus)
                shootVirus(virus);

        }

    }

    void shootVirus(Virus virus)
    {
        virus.DieFromShot();
    }
}
