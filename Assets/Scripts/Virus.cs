using UnityEngine;

public class Virus : MonoBehaviour
{
    public float moveSpeed = 5;
    public float rotationAmount = 40;
    public bool isAlive = true;
    public int splitLevel = 0;
    int MAX_SPLIT_LEVEL = 2;
    public bool isSplit = false;

    //DEBUG:
    public bool stayStill = false;


    // Update is called once per frame
    void Update()
    {
        if (GameManager.isPaused)
            return;

        if (!stayStill)
        {
            transform.position += Time.deltaTime * Vector3.forward * moveSpeed;
            transform.Rotate(Time.deltaTime * Vector3.right * rotationAmount);
        }

        //keep disintegrating for more impact effect
        if(!isAlive && !isSplit && splitLevel < MAX_SPLIT_LEVEL)
        {
            splitLevel += 1;
            Slicer.SplitMesh(gameObject, transform);
            isSplit = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        Logger.Debug("ontrigger");
        if(other.tag == "DeathPoint" || other.tag == "Hand")
        {
            Destroy(this.gameObject);
        }
    }

    public void DieFromShot()
    {
        splitLevel = 1;
        //Slicer.SplitMesh(gameObject, transform);
        isSplit = true;
        Destroy(gameObject);
    }
}
