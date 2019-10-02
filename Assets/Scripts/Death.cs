using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {
  [SerializeField]
  Score _score;
  void Awake() {
    this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f,0,0));
  }
  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Player")) {
      string highScore = StorageHelper.ReadStorage(StorageHelper.HIGH_SCORE_KEY);
      if (!string.IsNullOrEmpty(highScore)){
        if (_score.score < int.Parse(highScore)) {
          Debug.Log("NewHighScore");
        } else {
          Debug.Log("OldScoreRocks");
        }
      } else {
        StorageHelper.WriteStorage(StorageHelper.HIGH_SCORE_KEY, _score.score.ToString());
        Debug.Log("New HighScore");
      }
      // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       Application.LoadLevel(Application.loadedLevel);
    }
  }
}
