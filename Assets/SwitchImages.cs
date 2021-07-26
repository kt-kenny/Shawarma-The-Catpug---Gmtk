using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchImages : MonoBehaviour
{
    [SerializeField] PlayerController player;
    private int i;
    // Update is called once per frame
    private void Start() {
        i = 0;
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && !player.isDog && !PauseMenu.GameIsPaused) { //remeber to set rendering layer and order

            //Debug.Log("Destroy image");
            Transform child = transform.GetChild(0);
            Destroy(child.gameObject);
        }
        if(transform.GetChildCount() == 0) { SceneManager.LoadScene(1); }
    }
}
