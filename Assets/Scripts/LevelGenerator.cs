using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
  [SerializeField]
  Transform inScreen, outScreen;
  [SerializeField]
  Transform leftWall, rightWall;

  // Start is called before the first frame update
  void Awake() {
    rightWall.position = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0));
    leftWall.position = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0));
  }

  // Update is called once per frame
  void Update() {
     

  }
}
