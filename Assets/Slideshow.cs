using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slideshow : MonoBehaviour
{
    private float elapsed = 0f;
    private Image img;
    private Transform child;
    // Start is called before the first frame update
    void Start()
    {
        img = transform.GetChild(2).GetComponent<Image>();
        //img.color = new Color(1, 1, 1, 0);
    }
    
    // Update is called once per frame
    void Update()
    {
        int child_index = transform.GetChildCount()-1;
        Debug.Log(child_index);

        child = transform.GetChild(child_index);
        img = child.GetComponent<Image>();
        //Destroy(child.gameObject);
        
        elapsed += Time.deltaTime;
        if (elapsed >= 5f) {
            elapsed = elapsed % 5f;
            if (img != null) { StartCoroutine(FadeImage());} 
        }
    }

    IEnumerator FadeImage() {
        for (float i = 1; i >= 0; i -= Time.deltaTime) {
            // set color with i as alpha
            img.color = new Color(1, 1, 1, i);
            yield return null;
        }
        
        Destroy(child.gameObject);
    }


}
