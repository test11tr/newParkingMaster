using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using test11.Managers;

namespace test11.Managers
{
    public class ParkingManager : MonoBehaviour
    {
        [Header("Important References - Don't Assign")]
        [SerializeField] private LevelManager _levelManager;
        [SerializeField] private CarController _carController;
        [SerializeField] private ParkingManager _parkingManager;

        [HideInInspector]
        public bool fl,fr,rl,rr,front,rear;
        [Header("Menu References")]
        public GameObject FinishMenu;
        public GameObject TimerCountMen;
        public GameObject FailedMenu;

        [Header("Score Settings")]
        public int CollisionScore0 = 3, CollisionScore1 = 2, CollisionScore2 = 1, CollisionScore3 = 0;
        private bool isFinish, Finished, Score, canLoad = true;
        float endTime;

        [Header("UI Text References")]
        public Text CountDownText;
        public Text CollisionCountText;
        public Text FinishScoreText;
        [HideInInspector] public int CollisionCount;
        
        [Header("Visual Stuff")]
        public MeshRenderer ParkingArea;
        public GameObject Helper;
        public GameObject star1, star2, star3;

        [Header("Is Time Limited?")]
        public bool timeLimit;
        public GameObject TimeDownMenu;
        public Text bestTime, currentTime;

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
                _carController = _levelManager.SpawnedPlayerVehicle.GetComponent<CarController>();
            }
            if (_parkingManager == null)
            {
                _parkingManager = GetComponentInParent<ParkingManager>();
            }

            if(timeLimit)
                TimeDownMenu.SetActive(true);
            else{
                TimeDownMenu.SetActive(false);
            }

            // Parking Timer
            endTime = Time.time + 4;
            // Start count down
            CountDownText.text = "3";

            // Audiosource
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.spatialBlend = 0;
            _audioSource.playOnAwake = false;
            _audioSource.loop = false;
        }

        void Update(){
            if(!Finished){
                if(fl && fr && rl && rr && front && rear){
                    //checking when timer is reaching to 0
                    StartCoroutine(CheckTimeToFinished());
                    isFinish = true;
                    ParkingArea.material.color = Color.green;

                    if(canLoad){
                        TimerCountMen.SetActive(true);
                        CountDownText.gameObject.SetActive(true);
                    }

                    int timeLeft = (int)(endTime - Time.time);
                    if(timeLeft < 0){
                        timeLeft = 0;
                    }

                    //Timer to 3..2..1..
                    CountDownText.text = timeLeft.ToString();
                }else{
                    //Not parked correctly
                    StopCoroutine(CheckTimeToFinished());
                    isFinish = false;
                    TimerCountMen.SetActive(false);
                    endTime = Time.time + 4;
                    CountDownText.text = "3";
                    ParkingArea.material.color = Color.white;
                }

                if(timeLimit)
                    TimeDown();
            }
        }

        IEnumerator CheckTimeToFinished(){
            yield return new WaitForSeconds(4f);
            if(isFinish){
                if(!Score){
                    Score = true;
                    Finished = true;

                    if(CollisionCount == 0){
                        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore0);
                        FinishScoreText.text = "Awarded Coins : " + CollisionScore0.ToString();
                        star3.SetActive(true);
                        PlayerPrefs.SetInt("Star" + PlayerPrefs.GetInt("LevelID").ToString(), 3);
                        _audioSource.clip = clipSuccess;
                        _audioSource.Play();

                        if (PlayerPrefs.GetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString ()) == minutes) {
                            if (PlayerPrefs.GetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString ()) != seconds) {
                                if (PlayerPrefs.GetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString ()) < seconds)
                                    PlayerPrefs.SetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString (), seconds);
                            }
                        }
                        {
                            if (PlayerPrefs.GetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString ()) < minutes) {
                                PlayerPrefs.SetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString (), minutes);
                                PlayerPrefs.SetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString (), seconds);
                            }
                        }

                        PlayerPrefs.SetInt("LevelXP", PlayerPrefs.GetInt("LevelXP") + CollisionScore0);
                        bestTime.text = ReadBestTime();
                        currentTime.text = ReadCurrentTime();
                        _levelManager.SpawnedPlayerVehicle.GetComponent<Rigidbody>().isKinematic = true;
                    }

                    if(CollisionCount == 1){
                        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore1);
                        FinishScoreText.text = "Awarded Coins : " + CollisionScore1.ToString();
                        star3.SetActive(true);
                        PlayerPrefs.SetInt("Star" + PlayerPrefs.GetInt("LevelID").ToString(), 3);
                        _audioSource.clip = clipSuccess;
                        _audioSource.Play();

                        if (PlayerPrefs.GetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString ()) == minutes) {
                            if (PlayerPrefs.GetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString ()) != seconds) {
                                if (PlayerPrefs.GetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString ()) < seconds)
                                    PlayerPrefs.SetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString (), seconds);
                            }
                        }
                        {
                            if (PlayerPrefs.GetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString ()) < minutes) {
                                PlayerPrefs.SetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString (), minutes);
                                PlayerPrefs.SetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString (), seconds);
                            }
                        }

                        PlayerPrefs.SetInt("LevelXP", PlayerPrefs.GetInt("LevelXP") + CollisionScore1);
                        bestTime.text = ReadBestTime();
                        currentTime.text = ReadCurrentTime();
                        _levelManager.SpawnedPlayerVehicle.GetComponent<Rigidbody>().isKinematic = true;
                    }

                    if(CollisionCount == 2){
                        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore2);
                        FinishScoreText.text = "Awarded Coins : " + CollisionScore2.ToString();
                        star3.SetActive(true);
                        PlayerPrefs.SetInt("Star" + PlayerPrefs.GetInt("LevelID").ToString(), 3);
                        _audioSource.clip = clipSuccess;
                        _audioSource.Play();

                        if (PlayerPrefs.GetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString ()) == minutes) {
                            if (PlayerPrefs.GetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString ()) != seconds) {
                                if (PlayerPrefs.GetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString ()) < seconds)
                                    PlayerPrefs.SetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString (), seconds);
                            }
                        }
                        {
                            if (PlayerPrefs.GetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString ()) < minutes) {
                                PlayerPrefs.SetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString (), minutes);
                                PlayerPrefs.SetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString (), seconds);
                            }
                        }

                        PlayerPrefs.SetInt("LevelXP", PlayerPrefs.GetInt("LevelXP") + CollisionScore2);
                        bestTime.text = ReadBestTime();
                        currentTime.text = ReadCurrentTime();
                        _levelManager.SpawnedPlayerVehicle.GetComponent<Rigidbody>().isKinematic = true;
                    }

                    if(CollisionCount == 3){
                        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + CollisionScore3);
                        FinishScoreText.text = "Awarded Coins : " + CollisionScore3.ToString();
                        star3.SetActive(true);
                        PlayerPrefs.SetInt("Star" + PlayerPrefs.GetInt("LevelID").ToString(), 3);
                        _audioSource.clip = clipSuccess;
                        _audioSource.Play();

                        if (PlayerPrefs.GetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString ()) == minutes) {
                            if (PlayerPrefs.GetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString ()) != seconds) {
                                if (PlayerPrefs.GetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString ()) < seconds)
                                    PlayerPrefs.SetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString (), seconds);
                            }
                        }
                        {
                            if (PlayerPrefs.GetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString ()) < minutes) {
                                PlayerPrefs.SetFloat ("Minutes" + PlayerPrefs.GetInt ("LevelID").ToString (), minutes);
                                PlayerPrefs.SetFloat ("Seconds" + PlayerPrefs.GetInt ("LevelID").ToString (), seconds);
                            }
                        }

                        PlayerPrefs.SetInt("LevelXP", PlayerPrefs.GetInt("LevelXP") + CollisionScore3);
                        bestTime.text = ReadBestTime();
                        currentTime.text = ReadCurrentTime();
                        _levelManager.SpawnedPlayerVehicle.GetComponent<Rigidbody>().isKinematic = true;
                    }

                    PlayerPrefs.SetInt("TotalPassed", PlayerPrefs.GetInt("TotalPassed") + 1);
                    if (PlayerPrefs.GetInt ("LevelID") + 1 == PlayerPrefs.GetInt ("LevelNum")) {
                        PlayerPrefs.SetInt ("LevelNum", PlayerPrefs.GetInt ("LevelNum") + 1);
                        PlayerPrefs.SetInt ("PassedLevels", PlayerPrefs.GetInt ("PassedLevels") + 1);
                    }

                    FinishMenu.SetActive (true);
                    TimerCountMen.SetActive (false);
                    CountDownText.gameObject.SetActive (false);
                    _levelManager.SpawnedPlayerVehicle.GetComponent<CarController>().EngineSwitch();
                }
            }
        }

        public void TimeFailed(){
            _audioSource.clip = clipLost;
            _audioSource.Play();
            FailedMenu.SetActive(true);
            PlayerPrefs.SetInt("TotalFailed", PlayerPrefs.GetInt("TotalFailed") + 1);
            TimerCountMen.SetActive(false);
            CountDownText.gameObject.SetActive(false);
            _levelManager.SpawnedPlayerVehicle.GetComponent<CarController>().EngineSwitch();
            _levelManager.SpawnedPlayerVehicle.GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<ParkingManager>().enabled = false;
            _text.text = "00:00";
        }

        public Text _text;
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
