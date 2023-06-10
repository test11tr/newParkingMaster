using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test11.Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject PlayerVehicle;
        [SerializeField] private Transform SpawnPoint;

        private GameObject p_spawnedPlayerVehicle;
        public GameObject SpawnedPlayerVehicle => p_spawnedPlayerVehicle;

        [SerializeField] bool drawGizmos = true;

        private void Awake()
        {
            //Pool Vehicle
            p_spawnedPlayerVehicle = Instantiate(PlayerVehicle, new Vector3(SpawnPoint.position.x, SpawnPoint.position.y, SpawnPoint.position.z), Quaternion.identity);
            p_spawnedPlayerVehicle.SetActive(false);
        }
        
        private void Start()
        {
            p_spawnedPlayerVehicle.transform.position = SpawnPoint.position;
            p_spawnedPlayerVehicle.transform.rotation = SpawnPoint.rotation;
            p_spawnedPlayerVehicle.SetActive(true);
            print("Player is in a Vehicle");
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
