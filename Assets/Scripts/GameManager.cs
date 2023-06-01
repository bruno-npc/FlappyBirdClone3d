using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    public List<GameObject> obstaclePrefabs;

    public float obstacleSpeed = 10;

    public float obstacleInterval = 1;

    public float xOffSetObstacle = 0;
    public Vector2 yOffSetObstacle = new Vector2(0, 0);

    public int score = 0;
    private bool gameOver = false;

    private void Awake() {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } 
        else {
            Instance = this;
        }
    }

    public bool isGameOver (){
        return gameOver;
    }

    public void endGame (){
        gameOver = true;
        StartCoroutine(reloadScene(2));
    }   

    private IEnumerator reloadScene(float delay){
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("SampleScene");
    }
}
