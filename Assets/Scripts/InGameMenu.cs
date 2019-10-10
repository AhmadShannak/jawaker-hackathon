using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InGameMenu : MonoBehaviour {
  [SerializeField]
  ControllerCollider controller;
  [SerializeField]
  GameObject panel;
  [SerializeField]
  TextMeshProUGUI score, highScore;

  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }

  public void GoBack() {
    SceneManager.LoadScene("MainMenu");
  }
  public void Retry() {
    Score.currentLevel = 1;
    Application.LoadLevel(Application.loadedLevel);
    Debug.Log("reset");
    Jumpy.Time.ReseTime();
  }

  public void Pause() {
    panel.SetActive(true);
    controller.enabled = false;
    Time.timeScale = 0;
    Jumpy.Time.timeScale = 0;
  }

  public void Resume() {
    panel.SetActive(false);
    controller.enabled = true;
    Jumpy.Time.ReseTime();
  }

  public void Defeat(string _score, string _highScore) {
    score.text = _score;
    highScore.text = _highScore;
  }
}
