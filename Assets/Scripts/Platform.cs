using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
  [SerializeField]
  Transform inScreen, outScreen;
  [SerializeField]
  GameObject[] childs;

  Vector3 cameraBoundsLeft, cameraBoundsRight;

  void Awake() {
    cameraBoundsLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.085f ,10));
    cameraBoundsRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0));
    this.transform.position = new Vector3(this.transform.position.x, cameraBoundsLeft.y, 0);
  }
  // void Update() {
  //   if (childs[2].transform.position.x <= cameraBoundsLeft.x - 2) {
  //     this.transform.parent = outScreen;
  //   } else {
  //     // Debug.Log(childs[0].transform.localPosition.x + "     "+cameraBoundsRight.x);
  //     if (this.transform.parent != inScreen && (childs[0].transform.position.x <= cameraBoundsRight.x )) {
  //       this.transform.parent = inScreen;
  //     }
  //   }
  // }

  // void OnCollisionEnter2D(Collision2D other) {
  //   if (other.gameObject.CompareTag("Child0")) {

  //   }
  // }
  // void OnCollisionExit2D(Collision2D other) {
  //   if (other.gameObject.CompareTag("Child2")) {

  // //   }
  // }
}
