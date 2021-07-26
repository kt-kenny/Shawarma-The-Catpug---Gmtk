using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popup : MonoBehaviour
{
    [SerializeField] GameObject instructionSprite;
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            Destroy(GameObject.Find("intro"));
            Instantiate(instructionSprite, transform);
        }
    }

}
