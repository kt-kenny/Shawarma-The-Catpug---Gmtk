using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InvisibleTiles : MonoBehaviour {
    [SerializeField] private Transform player;
    private PlayerController script;

    private void Start() {
        script = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update() {
        TilemapRenderer r = transform.GetComponentInChildren<TilemapRenderer>();
        if (script.isDog) { r.enabled = true; }
        else { r.enabled = false; }
        
    }
}

