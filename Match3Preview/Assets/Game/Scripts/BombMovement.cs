using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BombMovement : MonoBehaviour
{
    [SerializeField] float speed;
    public CellScript[] cells;
    GameObject cellContainer;
    Transform bomb;
    int num = 0;
    void Start(){
        bomb = GetComponent<Transform>();
        cellContainer = GameObject.FindGameObjectWithTag("cellContainer");
        cells = cellContainer.GetComponent<CellContainer>().cells;
    }

    void Update(){       
        for(int i = 0; i < cells.Count(); i++){
            if(bomb.transform.position.x == cells[i].transform.position.x && bomb.transform.position.y <= cells[i].transform.position.y + 0.015f && bomb.transform.position.y >= cells[i].transform.position.y - 0.015f){
                //Debug.Log(num + ": " + cells[i].transform.position.x + ";" + cells[i].transform.position.y);
                bomb.transform.position = cells[i].transform.position;
                speed = 0;
                //num++;
                break;
            }
        }
        bomb.transform.position = bomb.transform.position + new Vector3(0, -speed * Time.deltaTime, 0);
    }
}
