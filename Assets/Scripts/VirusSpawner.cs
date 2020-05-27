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
        Logger.Debug($"vstr count: {virusStrains.Length}");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isPaused)
            return;

        if (timer > beat)
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
            timer -= beat;
        }

        timer += Time.deltaTime;
    }
}
