using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UniqueVehicleController;

namespace test11.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Car[] _playerVehicles;
        [SerializeField] public Car _unlockingVehicle;
        [SerializeField] private Transform SpawnPoint;

        private GameObject p_spawnedPlayerVehicle;
        public GameObject SpawnedPlayerVehicle => p_spawnedPlayerVehicle;

        [SerializeField] bool drawGizmos = true;
        private int currentCarIndex;

        private void Awake()
        {
            //Pool Vehicle
            currentCarIndex = PlayerPrefs.GetInt("CurrentCar");
            if(SceneManager.GetActiveScene().name == "00-MainMenu"){
                p_spawnedPlayerVehicle = Instantiate(_playerVehicles[currentCarIndex].carVisualPrefab, SpawnPoint.position, Quaternion.identity, SpawnPoint);
            }else{
                if(_unlockingVehicle == null)
                {
                    p_spawnedPlayerVehicle = Instantiate(_playerVehicles[currentCarIndex].carPlayablePrefab, SpawnPoint.position, Quaternion.identity);
                }
                else
                {
                    p_spawnedPlayerVehicle = Instantiate(_unlockingVehicle.carPlayablePrefab, SpawnPoint.position, Quaternion.identity);
                    int tempCarNumberIndex = p_spawnedPlayerVehicle.GetComponent<UVCUniqueVehicleController>()._carScriptableObject.carNumberIndex;
                    string tempCarIndex= p_spawnedPlayerVehicle.GetComponent<UVCUniqueVehicleController>()._carScriptableObject.carIndex;
                    PlayerPrefs.SetInt(tempCarIndex, 1);
                    PlayerPrefs.SetInt("CurrentCar", tempCarNumberIndex);
                }
                    
            }
        }
        
        private void Start()
        {
            p_spawnedPlayerVehicle.transform.position = SpawnPoint.position;
            p_spawnedPlayerVehicle.transform.rotation = SpawnPoint.rotation;
            p_spawnedPlayerVehicle.SetActive(true);
        }

        private void ReloadScene(){
            string currentScene = SceneManager.GetActiveScene ().name; 
            SceneManager.LoadScene(currentScene);
        }

        public void PlayerCarInstantiate(){
            currentCarIndex = PlayerPrefs.GetInt("CurrentCar");
            if(SpawnPoint.childCount > 0){
                for (int i = 0; i < SpawnPoint.childCount; i++)
                {
                    Destroy(SpawnPoint.GetChild(i).gameObject);
                }
                p_spawnedPlayerVehicle = Instantiate(_playerVehicles[currentCarIndex].carVisualPrefab, SpawnPoint.position, Quaternion.identity, SpawnPoint);
            }
        }

        void OnDrawGizmos()
        {
            if(drawGizmos){
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(SpawnPoint.position, 1);
            }
            
        }
    }
}
