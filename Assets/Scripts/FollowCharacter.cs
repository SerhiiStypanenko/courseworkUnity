using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowCharacter : MonoBehaviour
{
    private CinemachineVirtualCamera vcam;
    
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        
        
    }

    private void Update() {
        vcam.Follow = GameObject.FindGameObjectWithTag("Player").transform;
    }


}
