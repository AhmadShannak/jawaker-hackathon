using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountains : MonoBehaviour {

  // Update is called once per frame
  void Update() {
    this.transform.Translate(new Vector3( -0.1f, 0, 0) * Jumpy.Time.timeScale);
  }
}
