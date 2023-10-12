using System.Collections;
using System.Linq;
using UnityEngine;

public class BombsGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    [SerializeField] GameObject parent;
    [SerializeField] float secondsForWait;

    public CellScript[] cells;
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
        for (int i = 0; i <= 30; i += 6)
        {
            yield return new WaitForSeconds(secondsForWait);
            BombSpawner(i);
        }
        
    }

    void BombSpawner(int i)
    {
        if (cells[i].isFree == true)
        {
            Instantiate(prefabs[UnityEngine.Random.Range(0, prefabs.Count())], cells[i].transform.position, Quaternion.identity, parent.transform);
            cells[i].isFree = false;
        }
    }
}
