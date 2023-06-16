using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace test11
{
    public class WorldDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text worldName;
        [SerializeField] private TMP_Text worldDescription;
        [SerializeField] private Image worldImage;

        public void DisplayWorld(World _world){
            worldName.text = _world.worldName;
            worldDescription.text = _world.worldDescription;
            worldImage.sprite = _world.worldImage;
        }
    }
}
