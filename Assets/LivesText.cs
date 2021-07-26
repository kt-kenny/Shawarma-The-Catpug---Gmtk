using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesText : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        int lives = GameObject.FindObjectOfType<GameSession>().GetComponent<GameSession>().playerLives;
        gameObject.GetComponent<Text>().text = "     : " + lives.ToString();
    }
}
