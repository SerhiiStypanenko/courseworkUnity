using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSync : MonoBehaviour
{
    public static int PosID = Shader.PropertyToID("_Position");
    public static int SizeID = Shader.PropertyToID("_Size");

    [SerializeField] private Material wallMaterial;
    [SerializeField] private Material usedMaterial;
    [SerializeField] private Camera Camera;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform RayForWallPos;
                     private float sizeAppear = 0;
                     private float sizeDisappear = 0.3f;


    private void Start() {
        Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    
    
    void Update()
    {
        var direction = Camera.transform.position - transform.position;
        var ray = new Ray(transform.position,direction.normalized);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, 3000, layerMask)){
            Debug.DrawRay(transform.position, direction, Color.green);
            if(hit.collider.gameObject.transform.rotation.y == 0){
                 if(hit.collider.gameObject.GetComponent<MeshRenderer>()){
                    usedMaterial = hit.collider.gameObject.GetComponent<MeshRenderer>().material;
                    sizeAppear = Mathf.Lerp(sizeAppear, .4f,.08f);
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material.SetFloat(SizeID,sizeAppear);   
                    sizeDisappear = sizeAppear;
                }
            }
           
            


            
        }
        else{
            if(usedMaterial != null){
                sizeDisappear = Mathf.Lerp(sizeDisappear, 0.01f,.03f);
                usedMaterial.SetFloat(SizeID, sizeDisappear);
                sizeAppear = sizeDisappear;
            }

            //wallMaterial.SetFloat(SizeID, 0);
            
        }
        // Raycast for making wall in front of character opaque
        RaycastHit hitInfo;
        int wallLayer = LayerMask.NameToLayer("Wall");
        if(Physics.Raycast(RayForWallPos.position, Vector3.forward*3,out hitInfo)){
            if(hitInfo.collider.gameObject.layer == wallLayer){
                Debug.Log("WALLLLLLLLLLl");
                hitInfo.collider.gameObject.GetComponent<MeshRenderer>().material.SetFloat(SizeID,0);
            }
        }
        Debug.DrawRay(RayForWallPos.position, Vector3.forward*3, Color.red);
        var view = new Vector2(0,-0.03f);
        wallMaterial.SetVector(PosID, view);

    }

}
