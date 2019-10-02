using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {
  [SerializeField]
  Controller controller;
  [SerializeField]
  GameObject panel;
  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }
  public void GoBack() {
    SceneManager.LoadScene("MainMenu");
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
}
