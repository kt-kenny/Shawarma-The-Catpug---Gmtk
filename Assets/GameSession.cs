using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSession : MonoBehaviour {
    public int playerLives = 5;
    private void Awake() {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {

    }

    public void ProcessPlayerDeath() {
        if (playerLives > 0) {
            TakeLife();
        }
        else {
            ResetGameSession();
        }
    }

    public void ResetGameSession() {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    private void TakeLife() {
        playerLives -= 1;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}