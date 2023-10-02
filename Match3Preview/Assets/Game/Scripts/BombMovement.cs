using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BombMovement : MonoBehaviour
{
    [SerializeField] float speed;
    CellScript[] cells;
    GameObject cellContainer;
    Transform bomb;
    void Start(){
        bomb = GetComponent<Transform>();
        cellContainer = GameObject.FindGameObjectWithTag("cellContainer");
    }

    void Update(){
        cells = cellContainer.GetComponent<CellContainer>().cells;
        for(int i = 0; i < cells.Count(); i++){
           // if(bomb.transform.position.y == cells[i].transform.position.y && cells[i+1].isFree == true && bomb.transform.position.y <= -3.15f){
                bomb.transform.position = bomb.transform.position + new Vector3(0, -speed * Time.deltaTime, 0);
            //}
        }
    }
}
