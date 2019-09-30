using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jumpy {
  public class Time : MonoBehaviour {
    public static float timeScale = 1;
    public static void SlowTime() {
      UnityEngine.Time.timeScale = 0.05f;
      UnityEngine.Time.fixedDeltaTime = UnityEngine.Time.timeScale * 0.02f;
    }
    public static void ReseTime() {
      UnityEngine.Time.timeScale = 1;
      // UnityEngine.Time.fixedDeltaTime = UnityEngine.Time.timeScale;
    }
  }
}