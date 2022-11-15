using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Player;

public class GameManager : MonoBehaviour
{

    public int health;
    public int score;
    public Slider slider;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string scoreAmount = score.ToString();
        scoreText.text = scoreAmount;
        slider.value = health;
    }
}
