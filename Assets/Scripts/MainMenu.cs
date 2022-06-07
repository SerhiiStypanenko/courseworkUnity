using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   
    [SerializeField] private CanvasGroup BackgroundImage;
    [SerializeField] private AudioMixer audioMixer;
                             Animator foxAnimator;
    private float m_Timer;

    private bool fade;

    private void Start() {
        foxAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    private void Update() {
        bool clicked = Input.GetMouseButtonDown(0);
        if(clicked){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)){

                if(hit.transform.name == "Play"){
                    foxAnimator.SetTrigger("StartGame");
                    fade = true;
                    
                }

                else if(hit.transform.name == "Quit") 
                    Application.Quit();

            }
        }
        if(fade){
            if(BackgroundImage.alpha < 1){
                    BackgroundImage.alpha += Time.deltaTime;
                    if(BackgroundImage.alpha >= 1){
                        SceneManager.LoadScene(1);
                    }
                }
        }
         
    }
    public void SetVolume(float volume){
        audioMixer.SetFloat("volume", volume);
    }


   
}
