using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float coolDown = 0;

    void Update()
    {
        var gameManager = GameManager.Instance;
        coolDown -= Time.deltaTime;

        if(coolDown <= 0f && !GameManager.Instance.isGameOver()){
            coolDown =  GameManager.Instance.obstacleInterval;

            int prefabIndex =  Random.Range(0, gameManager.obstaclePrefabs.Count);
            var prefab = gameManager.obstaclePrefabs[prefabIndex];

            Quaternion rotation = prefab.transform.rotation;
            float x = gameManager.xOffSetObstacle;
            float y = Random.Range(gameManager.yOffSetObstacle.x, gameManager.yOffSetObstacle.y);
            Vector3 position = new Vector3(x, y , 0);
            Instantiate(prefab, position, rotation);
        }
    }
}
