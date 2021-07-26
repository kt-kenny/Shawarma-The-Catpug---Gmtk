using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelExit : MonoBehaviour
{
    private float LevelExitSlowMoFactor = 0.1f;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player"){
            Debug.Log("Collided with player");
            StartCoroutine(NextScene());
        }
    }

    IEnumerator NextScene() {
        Time.timeScale = LevelExitSlowMoFactor;
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1f;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
