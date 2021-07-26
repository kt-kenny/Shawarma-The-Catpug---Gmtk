using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mine : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Material spriteMaterial;
    private int explode = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            if (explode < 1){
                SoundManagerScript.PlaySound("explode");
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                explode += 1;
                Debug.Log("collided with player");
                GameObject explosion = Instantiate(explosionPrefab, gameObject.transform.position, gameObject.transform.rotation);
                StartCoroutine(DestroyExplosion(explosion));
                collision.GetComponent<PlayerController>().ExplodePlayer();
            }
        }
    }
    private IEnumerator DestroyExplosion(GameObject explosion) {
        yield return new WaitForSeconds(1);
        Destroy(explosion);
        Destroy(gameObject);
        
    }


}
