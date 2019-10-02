using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountains : MonoBehaviour {
  [SerializeField]
  float speed;
  // Update is called once per frame
  void Update() {
    this.transform.Translate(new Vector3( -speed, 0, 0) * Jumpy.Time.timeScale);
  }
}
