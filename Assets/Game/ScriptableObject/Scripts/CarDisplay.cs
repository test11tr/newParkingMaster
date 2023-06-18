using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace test11
{
    public class CarDisplay : MonoBehaviour
    {
        [Header("Car Info")]
        [SerializeField] private TMP_Text carName;
        [SerializeField] private TMP_Text carDescription;
        [SerializeField] private TMP_Text carPrice;

        [Header("Car Stats")]
        [SerializeField] private Image carSpeed;
        [SerializeField] private Image carAcceleration;
        [SerializeField] private Image carHandling;

        [Header("Car Model")]
        [SerializeField] public Transform carHolder;
        
        public void DisplayCar(Car _car){
            carName.text = _car.carName;
            carDescription.text = _car.carDescription;
            carPrice.text = _car.carPrice.ToString() + " C";

            carSpeed.fillAmount = _car.carSpeed / 100;
            carHandling.fillAmount = _car.carHandling / 100;
            carAcceleration.fillAmount = _car.carAcceleration / 100;

            if(carHolder.childCount > 0){
                Destroy(carHolder.GetChild(0).gameObject);
            }
        }
    }
}
