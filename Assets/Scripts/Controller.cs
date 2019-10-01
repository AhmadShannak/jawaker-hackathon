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

  void Awake() {
    ScaleBackGround();
  }

  void Start() {
    camera = this.transform.parent;
  }

  void Update() {
    if (player.transform.position.x >= this.transform.position.x) {
      camera.transform.position = new Vector3(player.transform.position.x, camera.transform.position.y, camera.transform.position.z);
    }
    Fuel();
  }

  void ScaleBackGround() {
    SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();

    float cameraHeight = Camera.main.orthographicSize * 2;
    Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
    Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
    Vector2 scale = transform.localScale;
    if (cameraSize.x >= cameraSize.y) { // Landscape (or equal)
      scale *= cameraSize.x / spriteSize.x;
    } else { // Portrait
      scale *= cameraSize.y / spriteSize.y;
    }
    this.transform.position = Vector2.zero; // Optional
    this.transform.localScale = scale;
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
