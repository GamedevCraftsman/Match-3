using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    [SerializeField] float speed;

    Transform bomb;
    GameObject[] lockIcon;
    float yPoint = 3.1f; 
    void Start()
    {
        bomb = GetComponent<Transform>();      
    }

    void FixedUpdate()
    {
         Debug.Log("GoUpdate");
        lockIcon = GameObject.FindGameObjectsWithTag("Lock");
         Debug.Log("After find lock");
         for (int i = 0; i < lockIcon.Count(); i++){
            Debug.Log(lockIcon[i].name);
         }
        for (int i = 0; i < lockIcon.Count(); i++){
           if (lockIcon[i].transform.position.y >= (bomb.transform.position.y - 0.8f) && lockIcon[i].GetComponent<Transform>().transform.position.y <= (bomb.transform.position.y - 1.5f)){
            Debug.Log("Go");
            yPoint -= 1.25f;
           } 
           
        }
        if (bomb.transform.position.y >= yPoint){
            transform.position = transform.position + new Vector3(0, -speed * Time.deltaTime, 0);
        }
    }

    void OnTriggerExit2D(Collider2D other){
            other.gameObject.tag = "Free";
    }

}
