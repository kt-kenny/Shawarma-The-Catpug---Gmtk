using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip explosion;
    public static AudioClip jump;
    private static AudioSource audsrc;
    private static AudioClip dead;

    // Start is called before the first frame update
    void Start()
    {
        audsrc = gameObject.GetComponent<AudioSource>();
        explosion = Resources.Load<AudioClip>("CATPUG_propulsion_bomb");
        jump = Resources.Load<AudioClip>("CATPUG_jump_test");
        dead = Resources.Load<AudioClip>("CATPUG_DED");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip) {
        switch (clip) {
            case "explode":
                audsrc.PlayOneShot(explosion);
                break;
            case "jump":
                audsrc.PlayOneShot(jump);
                break;
            case "dead":
                audsrc.PlayOneShot(dead);
                break;
        }
    }

}
