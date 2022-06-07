using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{   
    [SerializeField] private GameEnding gameEnding;
                     private Transform player;
                     private bool m_IsPlayerInRange;
    
    void OnTriggerEnter(Collider other){
        if(other.transform == player){
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if(other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }


    private void Update() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
      
        if(m_IsPlayerInRange){
            Vector3 direction = player.position - transform.position;

            Ray ray = new Ray(transform.position, direction);
            RaycastHit hit;
           
            if(Physics.Raycast(ray, out hit)){
                if(hit.collider.transform == player){
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }

}
