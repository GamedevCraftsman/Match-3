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

    int iSave;
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

    void FixedUpdate(){       
        for(int i = 0; i < cells.Count(); i++){
            if(bomb.transform.position.x == cells[i].transform.position.x && bomb.transform.position.y <= cells[i].transform.position.y + 0.015f && bomb.transform.position.y >= cells[i].transform.position.y - 1.2f){
                cells[i].isFree = false;
                if (cells[i+1].isFree == false)
                {                                   
                    speed = 0;
                }
                else if (cells[i + 1].isFree == true)
                {
                    speed = saveSpeed;
                    iSave = i;
                }
                

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
        if (bomb.transform.position.y <= cells[iSave].transform.position.y - 1.2f)
        {
            cells[iSave].isFree = true;
            //cells[i].isFree = true;
            //speed = saveSpeed;
        };
        bomb.transform.position = bomb.transform.position + new Vector3(0, -speed * Time.deltaTime, 0);
    }
}
