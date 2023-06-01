using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    void FixedUpdate()
    {
        float x = GameManager.Instance.obstacleSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x, 0, 0);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("DestroyObstacle")){
            Destroy(this.gameObject);
        }
    }
}
