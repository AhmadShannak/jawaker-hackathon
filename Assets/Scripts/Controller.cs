using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Controller : MonoBehaviour {
  [SerializeField]
  Player player;

  Transform camera;
  float pauseFuel = 15;
  bool outOfFuel = false;
  bool useFuel = false;
  float maxFuel = 15;

  void Start() {
    this.transform.localScale = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 1.5f, Screen.height * 1.5f, Camera.main.nearClipPlane));
    camera = this.transform.parent;
  }

  void Update() {
    if (player.transform.position.x >= this.transform.position.x) {
      camera.transform.position = new Vector3(player.transform.position.x, camera.transform.position.y, camera.transform.position.z);
    }
    Fuel();
  }

  public void OnMouseDown() {
    if (outOfFuel)
      return;
    useFuel = true;
  }

  public void OnMouseUp() {
    useFuel = false;
  }

  void Fuel() {
    if (useFuel) {
      if (pauseFuel > 0.2f) {
        pauseFuel -= Time.unscaledDeltaTime;
        Jumpy.Time.SlowTime();
      } else {
        useFuel = false;
      }
    } else {
      if (pauseFuel < maxFuel) {
        pauseFuel += Time.unscaledDeltaTime / 5;
        Jumpy.Time.ReseTime();
      }
    }
  }

}
