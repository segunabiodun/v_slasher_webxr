using UnityEngine;

public class Virus : MonoBehaviour
{
    public float rotationAmount = 40;
    public bool stayStill = false;
    public bool isAlive = true;
    

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isPaused)
            return;

        if (!stayStill)
        {
            transform.position += Time.deltaTime * Vector3.forward * 2;
            transform.Rotate(Time.deltaTime * Vector3.right * rotationAmount);
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
        Slicer.SplitMesh(gameObject, transform);
        Destroy(gameObject);
    }
}
