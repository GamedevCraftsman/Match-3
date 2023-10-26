using System.Collections;
using System.Linq;
using UnityEngine;
public class BombsGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    [SerializeField] GameObject parent;
    [SerializeField] float secondsForWait;

    public CellScript[] cells;

    const int cellsNumber = 30;
    const int rowsNumber = 6;
    const int fromNumberOfPrefabs = 0;
    GameObject cellContainer;
    void Start()
    {
        cellContainer = GameObject.FindGameObjectWithTag("cellContainer");
        cells = cellContainer.GetComponent<CellContainer>().cells;
    }

    void FixedUpdate()
    {
        StartCoroutine(SpawnBombs());
    }

    IEnumerator SpawnBombs()
    {
        for (int i = 0; i <= cellsNumber; i += rowsNumber)
        {
            yield return new WaitForSeconds(secondsForWait);
            BombSpawner(i);
        }
    }

    void BombSpawner(int i)
    {
        if (cells[i].isFree == true)
        {
            Instantiate(prefabs[UnityEngine.Random.Range(fromNumberOfPrefabs, prefabs.Count())], cells[i].transform.position, Quaternion.identity, parent.transform);
            cells[i].isFree = false;
        }
    }
}
