using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour {
  [SerializeField]
  SkeletonGraphic skeletonGraphic;
  [SerializeField]
  GameObject playBtn, highScorePopUp, highScoreButton;
  
  // Start is called before the first frame update
  void Awake() {
    skeletonGraphic.timeScale = 1;
    Invoke("SwitchAnimation",2);
  }
  void SwitchAnimation() {
    skeletonGraphic.AnimationState.SetAnimation(0, "Loop",true);
    playBtn.SetActive(true);
    highScoreButton.SetActive(true);
  }
  public void Play() {
    SceneManager.LoadScene("_Main");
  }
  public void HighScore() {
    string highScore = StorageHelper.ReadStorage(StorageHelper.HIGH_SCORE_KEY);
    highScorePopUp.GetComponentInChildren<TextMeshProUGUI>().text = string.IsNullOrEmpty(highScore) ? "0" : highScore;
    highScorePopUp.gameObject.SetActive(true);
  }
  public void GoBack() {
    highScorePopUp.SetActive(false);
  }
}
