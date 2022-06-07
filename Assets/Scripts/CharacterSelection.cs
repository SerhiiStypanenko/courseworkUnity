using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
   [SerializeField] private GameObject [] characters;
   [SerializeField] private CanvasGroup BackgroundImage;
                    private int selectedCharacter = 0;
                    private bool fadeOut;
                    private bool fadeIn;

    public void NextCharacter(){
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter(){
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter < 0){
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void StartGame(){
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        fadeIn = true;

    }

    private void Start() {
        fadeOut = true;
    }
    private void Update() {
        if(fadeOut){
            if(BackgroundImage.alpha >= 0)
            BackgroundImage.alpha -= Time.deltaTime;
            if(BackgroundImage.alpha == 0){
                fadeOut = false;
            }
        }  
        if(fadeIn){
            if(BackgroundImage.alpha < 1){
                    BackgroundImage.alpha += Time.deltaTime;
                    if(BackgroundImage.alpha >= 1){
                        SceneManager.LoadScene(2,LoadSceneMode.Single);
                    }
                }
        }
                
    }

}
