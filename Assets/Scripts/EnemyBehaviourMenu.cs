using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourMenu : MonoBehaviour
{
    private Vector3 direction = Vector3.left;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * 0.02f;

        if(transform.position.x <= -6f){
            transform.Rotate(0,180f,0);
            direction = Vector3.right;
        }
        else if (transform.position.x >= 5f){
            transform.Rotate(0,180f,0);
            direction = Vector3.left;
        }

        
    }
}
