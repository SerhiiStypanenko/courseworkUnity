using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorInteraction : Interactable
{
    [SerializeField] private GameObject _interactionText;
                     private MeshRenderer _textMesh;
                     private bool interacting;
                     private bool doorOpened;
                     private Animation openAnim;


    private void Start() {
        _textMesh = _interactionText.GetComponent<MeshRenderer>();
        openAnim = GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            _textMesh.enabled = true;
            interacting = true;
        }
           
    }

    private void OnTriggerExit(Collider other) {
       _textMesh.enabled = false;
       interacting = false;
    }

    private void Update() {
        if(interacting) Interact();
           

        
    }
    
    public override void Interact()
    {
        if(openable && !doorOpened){
            if(Input.GetKeyDown(KeyCode.E)){

                openAnim.PlayQueued("DoorAnim");
                doorOpened = true;

            }
        }
        else if(doorOpened && Input.GetKeyDown(KeyCode.E)){
                openAnim.PlayQueued("DoorAnimClose");
                doorOpened = false;
        }
        else if (!openable && Input.GetKeyDown(KeyCode.E)){
            _interactionText.GetComponent<TextMeshPro>().text = "Closed";
        }
    }
}
