using System.Linq;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
#if UNITY_EDITOR //code after this line will lose after compilation.
    [SerializeField] GameObject iconPrefab;
    [SerializeField] GameObject[] bombsPrefabs;
    [SerializeField] GameObject iconsParent;
    [SerializeField] GameObject bombsParent;
    [SerializeField] float[,] startPoint = {{-3.2f},{-3.15f}}; // where start cloning.
    [SerializeField] float[,] endPoint = {{3.05f},{3.1f}}; // where end cloning.

    float difference = 1.25f; // distance between spawnpoints.
    [ContextMenu("Spawn Bombs")]
    void Start()
    {
        if (!Application.isPlaying)
        {
        SpawnChart();
        }
    }

    void SpawnChart()
    {
        for(float i = startPoint[0,0]; i <= endPoint[0,0]; i += difference)
        {
            for(float j = startPoint[1,0]; j <= endPoint[1,0]; j += difference)
            {
                BombsSpawning(i, j);
                IconsSpawning(i, j);
            }
        }
    }

    void BombsSpawning(float i, float j)
    {
        Instantiate(bombsPrefabs[UnityEngine.Random.Range(0, bombsPrefabs.Count())], new Vector3(i, j, 0), Quaternion.identity, bombsParent.transform);
    }

    void IconsSpawning(float i, float j)
    {
        Instantiate(iconPrefab, new Vector3(i, j, 0), Quaternion.identity, iconsParent.transform);
    }
#endif
}
