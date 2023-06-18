using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test11
{
    [CreateAssetMenu(fileName = "New World", menuName = "ParkingMaster/World")]
    public class World : ScriptableObject
    {
       [Header("World Info")] 
       public int worldIndex;
       public string worldName;
       public string worldDescription;

       [Header("World References")] 
       public Sprite worldImage;
       public Object worldSceneName;
    }
}
