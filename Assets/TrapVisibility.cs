using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapVisibility : MonoBehaviour
{
    [SerializeField] private Transform player;
    private PlayerController script;

    private void Start() {
         script = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer[] renderers = transform.GetComponentsInChildren<SpriteRenderer>();
        // Debug.Log(renderers.Length);
        foreach (SpriteRenderer r in renderers) {
            if (script.isDog) { r.enabled = true; }
            else { r.enabled = false; }
        }
    }
}
