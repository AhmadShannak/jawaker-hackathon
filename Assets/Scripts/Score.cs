using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Spine.Unity;
using Spine;

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
  [SerializeField]
  GameObject eshmaratab;

  void Start() {
    Jumpy.Time.timeScale =1; 
    currentLevel = 1;
    speed = 0;
    avilableItems = 1;
    levelFactor = 1;
    score = 1;
    nextLevel = 50;
  }

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
    GameObject go = Instantiate(eshmaratab, eshmaratab.transform.position,Quaternion.identity, eshmaratab.transform.parent);
    SkeletonGraphic skeleton = go.GetComponent<SkeletonGraphic>();
    skeleton.timeScale = 0.7f;
    go.SetActive(true);
    Destroy(go,1.5f);
    
  }
}
