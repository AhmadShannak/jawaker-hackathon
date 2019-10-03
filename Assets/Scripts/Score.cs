using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {
  public int score;
  public static float levelFactor = 1f;
  public int nextLevel;
  public static int currentLevel = 1;
  public static float speed = 0;
  public GameObject player;
    public static int avilableItems = 1;
    [SerializeField]
    TextMeshProUGUI scoreLabel;
  // Start is called before the first frame update
  void Start() {
    Jumpy.Time.timeScale =1; 
    currentLevel = 1;
    speed = 0;
    avilableItems = 1;
    levelFactor = 1;
    score = 1;
    nextLevel = 50;
  }

  // Update is called once per frame
  void Update() {
    UpdateScore();
    scoreLabel.text = score.ToString();
  }

  void UpdateScore() {
    if (player != null){
    int position = (int)player.transform.position.x;
    position = position < 0 ? 0 : position;
    score = (int)(position * levelFactor);
    if (score >= nextLevel) {
      LevelUp();
    }
    }
  }

  void LevelUp() {
    currentLevel++;
    levelFactor = levelFactor + 0.1f;
    nextLevel *= (int)(1 + levelFactor);
    speed += 0.07f;
    Jumpy.Time.timeScale = (1 + speed);
    UnityEngine.Time.timeScale = (1 + speed * 2f);
    avilableItems = currentLevel;
    
  }
}
