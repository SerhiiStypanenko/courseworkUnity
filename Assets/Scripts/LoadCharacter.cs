using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
   [SerializeField] private GameObject[] characterPrefabs;
   [SerializeField] private Transform spawnPoint;
   [SerializeField] private CanvasGroup BackgroundLoadingImage;
                    private GameObject clone;
                    private GameObject prefab;
                    private int selectedCharacter;
                    private bool fadeOut;

    private void Start() {
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        prefab = characterPrefabs[selectedCharacter];
        clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        fadeOut = true;
    }

    public GameObject GetClone(){
        return clone;
    }

    private void Update() {
        if(fadeOut){
            if(BackgroundLoadingImage.alpha >= 0)
            BackgroundLoadingImage.alpha -= Time.deltaTime;
            if(BackgroundLoadingImage.alpha == 0){
                fadeOut = false;
            }
        }         
    }
}
