using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Death : MonoBehaviour {
  [SerializeField]
  Score _score;
  [SerializeField]
  GameObject defeatPopUp;

  void Awake() {
    this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f,0,0));
  }
  private void OnTriggerEnter2D(Collider2D other) {
        DeathScene(other);
  }
    public void DeathScene(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            string highScore = StorageHelper.ReadStorage(StorageHelper.HIGH_SCORE_KEY);
            if (!string.IsNullOrEmpty(highScore))
            {
                if (_score.score > Int32.Parse(highScore))
                {
                    highScore = _score.score.ToString();
                    StorageHelper.WriteStorage(StorageHelper.HIGH_SCORE_KEY, _score.score.ToString());
                    Debug.Log("NewHighScore");
                }
                else
                {
                    Debug.Log("OldScoreRocks");
                }
            }
            else
            {
                highScore = _score.score.ToString();
                StorageHelper.WriteStorage(StorageHelper.HIGH_SCORE_KEY, _score.score.ToString());
                Debug.Log("New HighScore");
            }
            defeatPopUp.SetActive(true);
            defeatPopUp.transform.parent.GetComponent<InGameMenu>().Defeat(_score.score.ToString(), highScore);
            Time.timeScale = 0;
            Jumpy.Time.timeScale = 0;
            //  Score.currentLevel = 1;
            //  Debug.Log(Score.speed +"   "+ Score.avilableItems + "  "+_score.score);
            //  Application.LoadLevel(Application.loadedLevel);
            //  Score.currentLevel = 1;
        }
    }
}
