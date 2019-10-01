using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
  void Awake() {
    this.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f,0.085f,10));
  }
}
