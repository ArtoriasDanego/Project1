using UnityEngine;

public class levelGenerator : MonoBehaviour
{

    public GameObject platformPrefab;
    public int numberOfPlatforms = 200;
    public float levelWidth = 3f;
    public float minY = 0.2f;
    public float maxY = 1.5f;
    
    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y = spawnPosition.y + Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
