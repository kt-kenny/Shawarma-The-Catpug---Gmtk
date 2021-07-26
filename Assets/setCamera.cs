using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class setCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CinemachineConfiner>().m_BoundingShape2D = GameObject.Find("CameraBound").GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
