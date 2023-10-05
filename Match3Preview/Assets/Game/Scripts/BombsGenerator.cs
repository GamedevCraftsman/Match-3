using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class BombsGenerator : MonoBehaviour
{
    [SerializeField] GameObject prefabs;
    [SerializeField] GameObject parent;

    public CellScript[] cells;
    GameObject cellContainer;

    void Start(){
        cellContainer = GameObject.FindGameObjectWithTag("cellContainer");
        cells = cellContainer.GetComponent<CellContainer>().cells;
    }

    void Update(){
        if(cells[0].isFree == true){
            Instantiate(prefabs, cells[0].transform.position, Quaternion.identity, parent.transform);
        }
    }
}
