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
    public bool playerHittable;

    public Slider slider;
    public TextMeshProUGUI scoreText;
    public MegaManScript megaMan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (megaMan.invinsibility <= 0)
        {
            playerHittable = true;
        }

        string scoreAmount = score.ToString();
        scoreText.text = scoreAmount;
        slider.value = health;
    }
}
