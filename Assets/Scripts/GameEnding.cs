using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private float displayImageDuration = 1f;           
    [SerializeField] private CanvasGroup exitBackgroundImage;
    [SerializeField] private CanvasGroup caughtBackgroundImage;
    [SerializeField] private AudioSource exitAudio;
    [SerializeField] private AudioSource caughtAudio;

    private GameObject player;
    private bool m_IsPlayerAtExit;
    private bool m_IsPlayerCaught;
    private bool _HasAudioPlayed;
    private float m_Timer;


    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == player){
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer(){
        m_IsPlayerCaught = true;
    }


    private void Update() {
         player = GameObject.FindGameObjectWithTag("Player");

        if(m_IsPlayerAtExit){
            EndLevel(exitBackgroundImage, false, exitAudio);
        }
        else if(m_IsPlayerCaught){
            EndLevel(caughtBackgroundImage, true, caughtAudio);
        }
            
    }
    
    void EndLevel(CanvasGroup image, bool doRestart, AudioSource audioSource){
        if(!_HasAudioPlayed){
            audioSource.Play();
            _HasAudioPlayed = true;
        }
        
        m_Timer += Time.deltaTime;
        image.alpha = m_Timer/fadeDuration;

        if(m_Timer > fadeDuration + displayImageDuration){
            if(doRestart){
                SceneManager.LoadScene(2);
            }
            else{
                SceneManager.LoadScene(0);
            }
        }
    }
}
