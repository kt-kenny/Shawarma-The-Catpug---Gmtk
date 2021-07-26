using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFloorSensor : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Ground") {
            GetComponentInParent<EnemyAi>().TurnAround();
        }
    }
}
