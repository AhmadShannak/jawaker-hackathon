using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment : MonoBehaviour {
  public static Vector3 outPos;
  private void OnTriggerExit2D(Collider2D other) {
    if (other.CompareTag("Left")) {
      outPos = this.transform.parent.GetChild(2).localPosition;
      outPos.x +=  18.3098f;
      this.transform.localPosition = outPos;
      this.transform.SetAsLastSibling();
    }
  }
}
