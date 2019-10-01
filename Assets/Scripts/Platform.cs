using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
  void Awake() {
    Vector3 cameraBounds = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.085f ,10));
    this.transform.position = new Vector3(this.transform.position.x, cameraBounds.y, 0);
  }
}
