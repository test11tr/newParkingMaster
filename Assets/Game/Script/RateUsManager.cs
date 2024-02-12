using System;
using UnityEngine;

#if UNITY_ANDROID
using Google.Play.Review;
using System.Collections;
#endif


public class RateUsManager : MonoBehaviour
{
    public bool levelBased = true;
    public int firstRateUsLevel;
    public GameObject RateMenu;
    private RateUsImpl _rateUs;
    

    private void Awake()
    {
    #if UNITY_ANDROID
        _rateUs = new RateUsAndroidImpl(this);
#endif
        int passedLevels = PlayerPrefs.GetInt("01-MallPassedLevels");
        if (passedLevels >= firstRateUsLevel && (passedLevels % firstRateUsLevel == 0) && PlayerPrefs.GetInt("UserRated") < 1)
        {
            RateMenu.SetActive(true);
            //CheckRateUsState();
        }
            
    }

    public void SetDontShow()
    {
        PlayerPrefs.SetInt("DontShow", 1);
        print("DontShow = 1");
    }

    public void CheckRateUsState()
    {
        if(PlayerPrefs.GetInt("DontShow") != 1)
        {
            _rateUs.ShowPrompt();  
        }
    }

    #region Granular Implementation
    private interface RateUsImpl
    {
        void ShowPrompt();
    }

#if UNITY_ANDROID
    private class RateUsAndroidImpl : RateUsImpl {

        private MonoBehaviour _mono;
        private ReviewManager _reviewManager;
        private PlayReviewInfo _playReviewInfo;

        public RateUsAndroidImpl(MonoBehaviour mono) {
            _mono = mono;
            _reviewManager = new ReviewManager();
        }

        public void ShowPrompt() {
            _mono.StartCoroutine(RequestPlayStoreRating());
        }

        IEnumerator RequestPlayStoreRating() {
	        Debug.Log("<color=yellow>RateUsManager --> requesting store review</color>");
            var requestFlowOperation = _reviewManager.RequestReviewFlow();
            yield return requestFlowOperation;
            if (requestFlowOperation.Error != ReviewErrorCode.NoError) {
	            Debug.Log("<color=red>RateUsManager --> cannot request store review</color>");
	            Debug.Log(requestFlowOperation.Error.ToString());
                yield break;
            }
            _playReviewInfo = requestFlowOperation.GetResult();
            _mono.StartCoroutine(LaunchPlayStoreRating());
        }

        IEnumerator LaunchPlayStoreRating() {
	        Debug.Log("<color=yellow>RateUsManager --> launching store review</color>");
            var launchFlowOperation = _reviewManager.LaunchReviewFlow(_playReviewInfo);
            yield return launchFlowOperation;
            _playReviewInfo = null; // Reset the object
            PlayerPrefs.SetInt("DontShow", 1);
            if (launchFlowOperation.Error != ReviewErrorCode.NoError) {
	            Debug.Log("<color=red>RateUsManager --> cannot request store review</color>");
	            Debug.Log(launchFlowOperation.Error.ToString());
                yield break;
            }
        }
    }
#endif

    private class RateUsNoOpImpl : RateUsImpl
    {
        public void ShowPrompt()
        {
            Debug.Log("<color=green>Rate us success :)</color>");
        }
    }
    #endregion
}
