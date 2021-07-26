using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchText : MonoBehaviour
{
    [SerializeField] private PlayerController player;
  
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "     : " + player.maxSwitch.ToString();
    }
}
