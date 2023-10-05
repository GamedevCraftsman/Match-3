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
    
    float saveSpeed;
    public CellScript[] cells;
    GameObject cellContainer;
    Transform bomb;
    void Start(){
        bomb = GetComponent<Transform>();
        cellContainer = GameObject.FindGameObjectWithTag("cellContainer");
        cells = cellContainer.GetComponent<CellContainer>().cells;
        saveSpeed = speed;
    }

    void Update(){       
        for(int i = 0; i < cells.Count(); i++){
            if(bomb.transform.position.x == cells[i].transform.position.x && bomb.transform.position.y <= cells[i].transform.position.y + 0.015f && bomb.transform.position.y >= cells[i].transform.position.y - 0.015f){
                if(cells[i+1].isFree == false){ 
                    cells[i].isFree = false;               
                    speed = 0;
                }
                else if (bomb.transform.position.y >= cells[i+1].transform.position.y + 0.55f && bomb.transform.position.y <= cells[i].transform.position.y - 0.5f && cells[i+1].isFree == true){
                    cells[i].isFree = true;
                    speed = saveSpeed;
                };

                switch(i){
                    case 5:
                    speed = 0;
                    cells[i].isFree = false;
                    break;
                    case 11:
                    speed = 0;
                    cells[i].isFree = false;
                    break;
                    case 17:
                    speed = 0;
                    cells[i].isFree = false;
                    break;
                    case 23:
                    speed = 0;
                    cells[i].isFree = false;
                    break;
                    case 29:
                    speed = 0;
                    cells[i].isFree = false;
                    break;
                    case 35:
                    speed = 0;
                    cells[i].isFree = false;
                    break;
                }
                break;
            }
        }
        bomb.transform.position = bomb.transform.position + new Vector3(0, -speed * Time.deltaTime, 0);
    }
}
