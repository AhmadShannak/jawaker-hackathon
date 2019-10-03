using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

  void Update() {
    this.transform.Translate(new Vector3(-0.1f, 0, 0) * Jumpy.Time.timeScale);
  }

  private void OnTriggerEnter2D(Collider2D other) {

    if (other.CompareTag("Player") && this.CompareTag("Time")) {
      GameObject.Find("Controller").GetComponent<ControllerCollider>().ActivateAddTime();
      Destroy(this.gameObject);
    } else if (other.CompareTag("Player") && this.CompareTag("Shield")) { 
        GameObject.Find("Bottom").GetComponent<Death>().DeathScene(other);
    } else if (other.CompareTag("Left")) {
      Destroy(this.gameObject);
    }
  }
}
