using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] VRInputManager vrInputManager = null;
    [SerializeField] Laser laser = null;
    [SerializeField] AudioSource audioSource;

    //public bool fakeTriggerDown = false;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isPaused)
            return;

        if(vrInputManager.IsAnyTriggerDown())
        {
            audioSource.Play();
        }

        //if (fakeTriggerDown && laser.hit3DObject)
        if (vrInputManager.IsAnyTriggerDown() && laser.hit3DObject)
        {
            Virus virus = laser.hit3DObject.GetComponent<Virus>();
            if (virus)
                OnVirusShot(virus);
        }

    }

    void OnVirusShot(Virus virus)
    {
        if (virus.isAlive)
        {
            Debug.Log($"OnVirusShot {virus.gameObject.name}");
            virus.isAlive = false;
            GameManager.score += 1;
        }
        virus.DieFromShot();
    }
}
