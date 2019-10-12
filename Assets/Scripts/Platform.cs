using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
  [SerializeField]
  GameObject[] childs;

  Vector3 cameraBoundsLeft;

  void Awake() {
    cameraBoundsLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.085f ,10));
    this.transform.position = new Vector3(this.transform.position.x, cameraBoundsLeft.y, 0);
  }
}
