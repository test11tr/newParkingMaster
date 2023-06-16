using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using test11.Managers;
using UniqueVehicleController;
using TMPro;

namespace test11.Managers
{
    public class ParkingManager : MonoBehaviour
    {
        [Header("Important References - Don't Assign")]
        [SerializeField] private LevelManager _levelManager;
        [SerializeField] private UVCUniqueVehicleController _carController;
        [SerializeField] private ParkingManager _parkingManager;
        [SerializeField] private GameObject _hud;
        [SerializeField] private GameObject parkingNotify;

        [HideInInspector]
        public bool fl,fr,rl,rr,front,rear;
        [Header("Menu References")]
        public GameObject FinishMenu;
        public GameObject FailedMenu;
        public GameObject TimeFailedMenu;

        [Header("Score Settings")]
        public int CollisionScore0 = 0;
        public int CollisionScore1 = 0;
        public int CollisionScore2 = 0;
        public int CollisionScore3 = 0;
        public int collisionLimit = 3;
        private bool isFinish, Finished, Score;

        [Header("UI Text References")]
        public TMP_Text CollisionCountText;
        public TMP_Text FinishScoreText;
        [HideInInspector] public int CollisionCount;
        
        [Header("Visual Stuff")]
        public MeshRenderer ParkingArea;
        public MeshRenderer ParkingAreaEmission;
        public GameObject star0, star1, star2, star3;

        [Header("Is Time Limited?")]
        public bool timeLimit;
        public GameObject TimeDownMenu;
        public TMP_Text bestTime, currentTime;
        
        [Header("Is Bonus Rewarded?")]
        public bool isBonusRewarded;
        public GameObject bonusInfoText;
        public int bonusDiamondAmount;
        public GameObject bonusReward;
        public TMP_Text bonusText;

        [Header("Audio Related")]
        public AudioSource AlarmSound;
        public AudioClip clipSuccess, clipLost;
        private AudioSource _audioSource;

        void Start(){
            if (_levelManager == null)
            {
                _levelManager = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelManager>();
            }
            if (_carController == null)
            {
                _carController = _levelManager.SpawnedPlayerVehicle.GetComponent<UVCUniqueVehicleController>();
            }
            if (_parkingManager == null)
            {
                _parkingManager = this;
            }
            if (_hud == null)
            {
                _hud = GameObject.FindGameObjectWithTag("HUD");
            }
            
            if(timeLimit)
                TimeDownMenu.SetActive(true);
            else{
                TimeDownMenu.SetActive(false);
            }

            // Audiosource
            //_audioSource = gameObject.AddComponent<AudioSource>();
            //_audioSource.spatialBlend = 0;
            //_audioSource.playOnAwake = false;
            //_audioSource.loop = false;
        }

        void Update(){
            if(!Finished){
                if(fl && fr && rl && rr && front && rear && _levelManager.SpawnedPlayerVehicle.GetComponent<UVCUniqueVehicleController>().speedOnKmh < 5){
                        ParkingArea.material.color = Color.green;
                        ParkingAreaEmission.gameObject.SetActive(true);
                        parkingNotify.SetActive(true);
                        if(_levelManager.SpawnedPlayerVehicle.GetComponent<UVCUniqueVehicleController>().isparking == true){
                            parkingNotify.SetActive(false);
                            //checking when timer is reaching to 0
                            CheckTimeToFinished();
                            isFinish = true;
                        }
                }else{
                    //Not parked correctly
                    //StopCoroutine(CheckTimeToFinished());
                    parkingNotify.SetActive(false);
                    isFinish = false;
                    ParkingArea.material.color = Color.white;
                    ParkingAreaEmission.gameObject.SetActive(false);
                }

                if(timeLimit)
                    TimeDown();
            }
        }

        void CheckTimeToFinished(){
            //yield return new WaitForSeconds(4f);
            if(isFinish){
                if(!Score){
                    Score = true;
                    Finished = true;

                    if(CollisionCount == 0){
                        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore0);
                        FinishScoreText.text = CollisionScore0.ToString();
                        star3.SetActive(true);
                        PlayerPrefs.SetInt("Star" + PlayerPrefs.GetInt("LevelID").ToString(), 3);
                        //_audioSource.clip = clipSuccess;
                        //_audioSource.Play();

                        if (PlayerPrefs.GetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString ()) == minutes) {
                            if (PlayerPrefs.GetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString ()) != seconds) {
                                if (PlayerPrefs.GetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString ()) < seconds)
                                    PlayerPrefs.SetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString (), seconds);
                            }
                        }
                        
                            if (PlayerPrefs.GetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString ()) < minutes) {
                                PlayerPrefs.SetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString (), minutes);
                                PlayerPrefs.SetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString (), seconds);
                            }
                        

                        PlayerPrefs.SetInt("LevelXP", PlayerPrefs.GetInt("LevelXP") + CollisionScore0);
                        bestTime.text = ReadBestTime();
                        currentTime.text = ReadCurrentTime();
                        _levelManager.SpawnedPlayerVehicle.GetComponent<Rigidbody>().isKinematic = true;

                        if(isBonusRewarded){
                            PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + bonusDiamondAmount);
                            bonusReward.SetActive(true);
                            bonusText.text = bonusDiamondAmount.ToString();
                        }
                    }

                    if(CollisionCount == 1){
                        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore1);
                        FinishScoreText.text = CollisionScore1.ToString();
                        star2.SetActive(true);
                        PlayerPrefs.SetInt("Star" + PlayerPrefs.GetInt("LevelID").ToString(), 2);
                        //_audioSource.clip = clipSuccess;
                        //_audioSource.Play();

                        if (PlayerPrefs.GetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString ()) == minutes) {
                            if (PlayerPrefs.GetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString ()) != seconds) {
                                if (PlayerPrefs.GetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString ()) < seconds)
                                    PlayerPrefs.SetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString (), seconds);
                            }
                        }
                        
                            if (PlayerPrefs.GetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString ()) < minutes) {
                                PlayerPrefs.SetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString (), minutes);
                                PlayerPrefs.SetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString (), seconds);
                            }
                        

                        PlayerPrefs.SetInt("LevelXP", PlayerPrefs.GetInt("LevelXP") + CollisionScore1);
                        bestTime.text = ReadBestTime();
                        currentTime.text = ReadCurrentTime();
                        _levelManager.SpawnedPlayerVehicle.GetComponent<Rigidbody>().isKinematic = true;

                        if(isBonusRewarded){
                            bonusInfoText.SetActive(true);
                        }
                    }

                    if(CollisionCount == 2){
                        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore2);
                        FinishScoreText.text = CollisionScore2.ToString();
                        star1.SetActive(true);
                        PlayerPrefs.SetInt("Star" + PlayerPrefs.GetInt("LevelID").ToString(), 1);
                        //_audioSource.clip = clipSuccess;
                        //_audioSource.Play();

                        if (PlayerPrefs.GetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString ()) == minutes) {
                            if (PlayerPrefs.GetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString ()) != seconds) {
                                if (PlayerPrefs.GetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString ()) < seconds)
                                    PlayerPrefs.SetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString (), seconds);
                            }
                        }
                        
                            if (PlayerPrefs.GetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString ()) < minutes) {
                                PlayerPrefs.SetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString (), minutes);
                                PlayerPrefs.SetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString (), seconds);
                            }
                        

                        PlayerPrefs.SetInt("LevelXP", PlayerPrefs.GetInt("LevelXP") + CollisionScore2);
                        bestTime.text = ReadBestTime();
                        currentTime.text = ReadCurrentTime();
                        _levelManager.SpawnedPlayerVehicle.GetComponent<Rigidbody>().isKinematic = true;

                        if(isBonusRewarded){
                            bonusInfoText.SetActive(true);
                        }
                    }

                    if(CollisionCount == 3){
                        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore3);
                        FinishScoreText.text = CollisionScore3.ToString();
                        star0.SetActive(true);
                        PlayerPrefs.SetInt("Star" + PlayerPrefs.GetInt("LevelID").ToString(), 0);
                        //_audioSource.clip = clipSuccess;
                        //_audioSource.Play();

                        if (PlayerPrefs.GetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString ()) == minutes) {
                            if (PlayerPrefs.GetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString ()) != seconds) {
                                if (PlayerPrefs.GetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString ()) < seconds)
                                    PlayerPrefs.SetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString (), seconds);
                            }
                        }
                        
                            if (PlayerPrefs.GetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString ()) < minutes) {
                                PlayerPrefs.SetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString (), minutes);
                                PlayerPrefs.SetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString (), seconds);
                            }
                        

                        PlayerPrefs.SetInt("LevelXP", PlayerPrefs.GetInt("LevelXP") + CollisionScore3);
                        bestTime.text = ReadBestTime();
                        currentTime.text = ReadCurrentTime();
                        _levelManager.SpawnedPlayerVehicle.GetComponent<Rigidbody>().isKinematic = true;

                        if(isBonusRewarded){
                            bonusInfoText.SetActive(true);
                        }
                    }

                    PlayerPrefs.SetInt("TotalPassed", PlayerPrefs.GetInt("TotalPassed") + 1);
                    if (PlayerPrefs.GetInt ("LevelID") + 1 == PlayerPrefs.GetInt ("LevelNum")) {
                        PlayerPrefs.SetInt ("LevelNum", PlayerPrefs.GetInt ("LevelNum") + 1);
                        PlayerPrefs.SetInt ("PassedLevels", PlayerPrefs.GetInt ("PassedLevels") + 1);
                    }
                    print("here");
                    _hud.SetActive(false);
                    FinishMenu.SetActive (true);
                    _levelManager.SpawnedPlayerVehicle.GetComponent<UVCUniqueVehicleController>().engineIsStarted = false;
                    print("here2");
                }
            }
        }

        public void TimeFailed(){
            //_audioSource.clip = clipLost;
            //_audioSource.Play();
            TimeFailedMenu.SetActive(true);
            PlayerPrefs.SetInt("TotalFailed", PlayerPrefs.GetInt("TotalFailed") + 1);
             _levelManager.SpawnedPlayerVehicle.GetComponent<UVCUniqueVehicleController>().engineIsStarted = false;
             _levelManager.SpawnedPlayerVehicle.GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<ParkingManager>().enabled = false;
            _text.text = "00:00";
        }

        public TMP_Text _text;
        public float seconds = 59;
        public float minutes = 0;

        public void TimeDown(){
            if (seconds <= 0) {
			    seconds = 59;

                if (minutes >= 1) {
                    minutes --;
                } else {
                    minutes = 0;
                    seconds = 0;
                    _text.text  = minutes.ToString ("f0") + ":0" + seconds.ToString ("f0");
                }
            } else 
            {
                seconds -= Time.deltaTime;
                string min;
                string sec;

                if (minutes < 10)
                    min = "0" + minutes.ToString ();
                else
                    min = minutes.ToString ();

                if (seconds < 10)
                    sec = "0" +( Mathf.FloorToInt(seconds)).ToString ();
                else
                    sec = (Mathf.FloorToInt(seconds)).ToString ();


                _text.text = min + ":"+ sec;
            }

            if (minutes <= 0 && seconds <= 0)
                TimeFailed ();
        }

        string ReadBestTime()
        {
            float min = 0, secn = 0 ;

            min = PlayerPrefs.GetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString ());
            secn = PlayerPrefs.GetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString ());
            string minS,secS;

            minS = min.ToString ();
            secS = Mathf.Floor(secn).ToString ();

            if (min < 10)
                minS = "0" + min.ToString ();

            if (secn < 10)
                secS = "0" + Mathf.Floor(secn).ToString ();

            return "Best Time : "+ minS + ":"+secS;
        }

        string ReadCurrentTime()
        {

            string min;
            string sec;

            if (minutes < 10)
                min = "0" + minutes.ToString ();
            else
                min = minutes.ToString ();

            if (seconds < 10)
                sec = "0" +( Mathf.FloorToInt(seconds)).ToString ();
            else
                sec = (Mathf.FloorToInt(seconds)).ToString ();

            return "CurrentTime : "+min + ":"+ sec;
        }
    }
}
