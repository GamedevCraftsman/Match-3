using System.Linq;
using UnityEngine;

public class CellContainer : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject parent;
    
    public CellScript[] cells;

    GameObject[] bombs;
    float[,] startPoint = {{-3.2f},{3.15f}}; // where start cloning.
    float[,] endPoint = {{3.05f},{-3.15f}}; // where end cloning.  
    float difference = 1.25f; // distance between spawnpoints.
    int counter = 0;
    void Start()
    {
        CellSpawn(); // function which fill in chart.     
    }

    void Update(){
         bombs = GameObject.FindGameObjectsWithTag("Bomb");
        for (int j = 0; j < bombs.Count(); j++){
            for(int i = 0; i < cells.Count(); i++){                 
                if (bombs[j].transform.position == cells[i].transform.position){
                    cells[i].isFree = false;
                }
            }
            
        }
    }
    

    void CellSpawn(){
        cells = new CellScript[36];
        for(float i = startPoint[0,0]; i <= endPoint[0,0]; i += difference){    
            for(float j = startPoint[1,0]; j >= endPoint[1,0]; j -= difference){
                GameObject cell = Instantiate(prefab, new Vector3(i,j,0), Quaternion.identity, parent.transform);
                cells[counter] = cell.GetComponent<CellScript>();      
                counter++;
            }  
        }
    }
}  
