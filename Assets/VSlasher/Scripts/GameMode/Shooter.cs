using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] VRInputManager vrInputManager = null;
    [SerializeField] Laser laser = null;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject leftHandModel;
    [SerializeField] GameObject righHandModel;
    [SerializeField] GameObject gun;
    [SerializeField] GameObject playerRig;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject canvasCollider;
    [SerializeField] GameObject virusSpawner;
    [SerializeField] GameObject virusDeathPoint;

    public float playerMoveSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isPaused)
            return;

        if(vrInputManager.IsAnyTriggerDown())
        {
            audioSource.Play();
        }

        //if (laser.hit3DObject)
        if (vrInputManager.IsAnyTriggerDown() && laser.hit3DObject)
        {
            Virus virus = laser.hit3DObject.GetComponent<Virus>();
            if (virus)
                OnVirusShot(virus);
        }

        //move the player gradually

        playerRig.transform.position += Vector3.back * playerMoveSpeed * Time.deltaTime;
        virusSpawner.transform.position += Vector3.back * playerMoveSpeed * Time.deltaTime;
        canvas.transform.position += Vector3.back * playerMoveSpeed * Time.deltaTime;
        canvasCollider.transform.position += Vector3.back * playerMoveSpeed * Time.deltaTime;
        virusDeathPoint.transform.position += Vector3.back * playerMoveSpeed * Time.deltaTime;

    }

    public void InitializeShooterMode()
    {
        leftHandModel.SetActive(true);
        righHandModel.SetActive(false);
        gun.SetActive(true);
    }

    void OnVirusShot(Virus virus)
    {
        if (virus.isAlive)
        {
            Debug.Log($"OnVirusShot {virus.gameObject.name}");
            virus.isAlive = false;
            GameManager.score += 1;
            virus.DieFromShot();
        }
    }
}
