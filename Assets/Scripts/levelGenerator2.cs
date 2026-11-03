using UnityEngine;

public class levelGenerator2 : MonoBehaviour
{
    public GameObject platformPrefab;
    public int startPlatforms = 10;      // so viele direkt beim Start
    public float spawnAhead = 10f;       // wie weit über der Kamera schon Plattformen existieren sollen
    public float levelWidth = 3f;
    public float minY = 0.2f;
    public float maxY = 1.5f;

    private Vector3 spawnPosition;       // jetzt eine Klassenvariable, damit sie zwischen Frames erhalten bleibt
    private Transform cam;

    void Start()
    {
        cam = Camera.main.transform;
        for (int i = 0; i < startPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        // Solange die oberste Plattform nicht weit genug über der Kamera ist: neue spawnen
        while (spawnPosition.y < cam.position.y + spawnAhead)
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        spawnPosition.y += Random.Range(minY, maxY);
        spawnPosition.x = Random.Range(-levelWidth, levelWidth);
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
    }
}