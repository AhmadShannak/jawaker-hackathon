using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Controller : MonoBehaviour {
  [SerializeField]
  Player player;
  Transform camera;
  float pauseFuel = 30f;
  bool outOfFuel = false;
  bool useFuel = false;

  void Start() {
    this.transform.localScale = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 1.5f, Screen.height * 1.5f,Camera.main.nearClipPlane));
    camera = this.transform.parent;
  }
  void Update() {
    if (player.transform.position.x >= this.transform.position.x) {
      camera.transform.position = new Vector3(player.transform.position.x, camera.transform.position.y, camera.transform.position.z);
    }
    if (useFuel) {
      pauseFuel -= Time.unscaledDeltaTime;
      Debug.Log(pauseFuel.ToString("F"));
    }
  }

  public void OnMouseDown() {
    if(outOfFuel)
      return;
    useFuel = true;
    Jumpy.Time.SlowTime();
  }

  public void OnMouseUp() {
    useFuel = false;
    Jumpy.Time.ReseTime();
  }
}
