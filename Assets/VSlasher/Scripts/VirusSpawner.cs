using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
	public GameObject[] virusStrains;
    public BoxCollider spawnVolume;
	public float spawnInterval = 2;
	private float timeSinceLastSpawn;	

    // Start is called before the first frame update
    void Start()
    {
        Logger.Debug($"vstr count: {virusStrains.Length}");
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.instance.isDemo)
            return;

        if (GameManager.isPaused)
            return;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            Vector3 minPoint = spawnVolume.bounds.min;
            Vector3 maxPoint = spawnVolume.bounds.max;
            Vector3 spawnPoint = new Vector3(
                Random.Range(minPoint.x, maxPoint.x),
                Random.Range(minPoint.y, maxPoint.y),
                Random.Range(minPoint.z, maxPoint.z));
            var rand = Random.Range(0, virusStrains.Length);
            Logger.Debug($"randIndex: {rand}");
            Instantiate(virusStrains[(int)rand], spawnPoint, Random.rotation);
            timeSinceLastSpawn = 0;
        }

        timeSinceLastSpawn += Time.deltaTime;
    }
}
