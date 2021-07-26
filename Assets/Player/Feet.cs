using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour {

    private PlayerController script;

    // Start is called before the first frame update
    void Start() {
        //Debug.Log("FEET CODE STARTED");
        script = gameObject.GetComponentInParent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        print("collision");
        if (collision.tag == "Ground") {
            script.isGrounded = true;
            //Debug.Log("Grounded");

        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Ground") {
            script.isGrounded = false;
            //Debug.Log("Not grounded");
        }
    }


}

