using UnityEngine;

public class Virus : MonoBehaviour
{
    public float rotationAmount = 40;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * Vector3.forward * 2;
        transform.Rotate( Time.deltaTime * Vector3.right * rotationAmount);
    }

    private void OnTriggerEnter(Collider other)
    {
        Logger.Debug("ontrigger");
        if(other.tag == "DeathPoint" || other.tag == "Hand")
        {
            Destroy(this.gameObject);
        }
    }
}
