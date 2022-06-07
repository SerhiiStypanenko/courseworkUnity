using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutoutObject : MonoBehaviour
{
    [SerializeField]
    private Transform targetObject;

    [SerializeField]
    private LayerMask wallMask;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }
    private void Start() {
        
    }

    private void Update()
    {
        targetObject = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 cutoutPos = mainCamera.WorldToViewportPoint(targetObject.position);
        cutoutPos.y /= (Screen.width / Screen.height);

        Vector3 offset = targetObject.position - transform.position;
        RaycastHit[] hitObjects = Physics.RaycastAll(transform.position, offset, offset.magnitude, wallMask);
        RaycastHit hit;
        if(Physics.Raycast(targetObject.transform.position, Vector3.forward, out hit, 3000, wallMask)){
            Debug.DrawRay(targetObject.transform.position, Vector3.forward, Color.blue);
            if(hit.collider.gameObject.tag == "Wall"){
                hit.collider.gameObject.GetComponent<MeshRenderer>().material.SetFloat("_CutoutSize", 0f);
                hit.collider.gameObject.GetComponent<MeshRenderer>().material.SetFloat("_FalloffSize", 0);
            }else{
                 hit.collider.gameObject.GetComponent<MeshRenderer>().material.SetFloat("_CutoutSize", 0.1f);
                hit.collider.gameObject.GetComponent<MeshRenderer>().material.SetFloat("_FalloffSize", 0.05f);
            }
        }

            
            
            
    }
}
