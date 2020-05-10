using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
	public GameObject[] virusStrains;
    public BoxCollider spawnVolume;
	public float beat;
	private float timer;	

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > beat)
        {
            Vector3 minPoint = spawnVolume.bounds.min;
            Vector3 maxPoint = spawnVolume.bounds.max;
            Vector3 spawnPoint = new Vector3(
                Random.Range(minPoint.x, maxPoint.x),
                Random.Range(minPoint.y, maxPoint.y),
                Random.Range(minPoint.z, maxPoint.z));
            GameObject cube = Instantiate(virusStrains[Random.Range(0, virusStrains.Length - 1)], spawnPoint, Random.rotation);
            //cube.transform.localPosition = Vector3.zero;
            //cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
            timer -= beat;
        }

        timer += Time.deltaTime;
    }
}
