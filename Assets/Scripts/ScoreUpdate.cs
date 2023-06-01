using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject gameOver;

    private void Update() {
        text.text = "Score: " + GameManager.Instance.score;
        gameOver.SetActive(GameManager.Instance.isGameOver());
    }
}
