﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
  [SerializeField]
  Player player;
  [SerializeField]
  Transform mountains;

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
    if (player != null) {
      if (player.transform.position.x >= this.transform.position.x) {
        camera.transform.position = new Vector3(player.transform.position.x, camera.transform.position.y, camera.transform.position.z);
      }
    }
  }

  void ScaleBackGround() {
    SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();

    float cameraHeight = Camera.main.orthographicSize * 2;
    Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
    Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
    Vector3 scale = transform.localScale;
    if (cameraSize.x >= cameraSize.y) { // Landscape (or equal)
      scale *= cameraSize.x / spriteSize.x;
    } else { // Portrait
      scale *= cameraSize.y / spriteSize.y;
    }
    scale.z = 1;
    this.transform.position = Vector2.zero; // Optional
    this.transform.localScale = scale;
    // Now ssetting the mountains
    mountains.position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10));
    mountains.localScale = new Vector3(scale.x, mountains.localScale.y, 0);
  }

}
