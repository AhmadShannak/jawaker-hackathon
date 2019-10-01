using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jumpy {
  public class Time : MonoBehaviour {
    public static float timeScale = 1;

    public static void SlowTime() {
      Jumpy.Time.timeScale = 0.55f;
      UnityEngine.Time.timeScale = 0.05f ;
      UnityEngine.Time.fixedDeltaTime = UnityEngine.Time.timeScale * 0.02f;
    }

    public static void ReseTime() {
      Jumpy.Time.timeScale = 1 + Score.speed;
      UnityEngine.Time.timeScale = 1 + Score.speed * 2f;
    }
  }
}