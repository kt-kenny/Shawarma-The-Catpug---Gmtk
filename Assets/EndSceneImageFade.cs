using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneImageFade : MonoBehaviour
{
    private Image img;
    private int numFrames;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = numFrames; i>0; i--) {
            img = transform.GetChild(i).GetComponent<Image>();
            StartCoroutine(WaitAndFade(5,img));
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitAndFade(int secs,Image img) {
        yield return new WaitForSecondsRealtime(secs);
        StartCoroutine(FadeImage(img, true));
    }

    IEnumerator FadeImage(Image img, bool fadeAway) {
        // fade from opaque to transparent
        if (fadeAway) {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime) {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime) {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }


}
