using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IconCheck : MonoBehaviour
{   
    [SerializeField] float endDiapazone;
    GameObject[] bombIcon;
    GameObject[] bomb;
    void Start(){
        bomb = GameObject.FindGameObjectsWithTag("Bomb");
        bombIcon = GameObject.FindGameObjectsWithTag("Free");
    }
    
    void FixedUpdate(){
        BombChecker();
    }

    void BombChecker(){
        for(int i = 0; i < bombIcon.Count(); i++){
            for (int j = 0; j < bomb.Count(); j++){
                if (bombIcon[i].transform.position.y >= bomb[j].transform.position.y && bombIcon[i].transform.position.y <= bomb[j].transform.position.y + endDiapazone){
                    bombIcon[i].tag = "Lock";
                }
            }
        }
    }
    

}
