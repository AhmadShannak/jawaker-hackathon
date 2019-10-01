using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score; 
    public static float levelFactor = 4f;
    public static int level = 0;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        score = 1;
    }

    // Update is called once per frame
    void Update()
    {
        updateScore();
    }

    void updateScore() {
        int position = (int) player.transform.position.x;
        position = position < score ? 0 : position;
        score = position;
        Debug.Log(score);
    }
}
