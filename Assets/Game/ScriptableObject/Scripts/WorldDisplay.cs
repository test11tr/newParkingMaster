using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

namespace test11
{
    public class WorldDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text worldName;
        [SerializeField] private TMP_Text worldDescription;
        [SerializeField] private Image worldImage;
        [SerializeField] private Button playButton;
        [SerializeField] private GameObject lockIcon;
        [SerializeField] private LevelSelect _levelSelect;

        private string worldSceneName;

        public void DisplayWorld(World _world){
            worldName.text = _world.worldName;
            worldSceneName = _world.worldSceneName.name;
            //worldName.color = _world.nameColor;
            worldDescription.text = _world.worldDescription;
            worldImage.sprite = _world.worldImage;
        
            bool worldUnlocked = PlayerPrefs.GetInt("currentScene", 0) >= _world.worldIndex;
            lockIcon.SetActive(!worldUnlocked);
            playButton.interactable = worldUnlocked;
            if(worldUnlocked){
                worldImage.color = Color.white;
            }else{
                worldImage.color = Color.gray;
            }


        }

        public void SetLevelSet(){
            _levelSelect.levelName = worldSceneName;
        }
    }
}
