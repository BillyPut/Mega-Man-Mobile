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
    public bool dead;

    public Slider slider;
    public TextMeshProUGUI scoreText;
    public MegaManScript megaMan;
    public EndGame resetTime;
    public Rigidbody2D deathParticle;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (megaMan.invinsibility <= 0)
        {
            playerHittable = true;
        }
        else
        {
            playerHittable = false;
        }

        if (resetTime.stopPlayer == true)
        {
            megaMan.gameObject.SetActive(false);
        }

        if (health <= 0 || megaMan.fellOff == true || resetTime.resetGame == true)
        {
            if (dead == false)
            {
                StartCoroutine(DeathCoroutine());
                //SceneManager.LoadScene("SampleScene");
            }

        }

        if (health > 28)
        {
            health = 28;
        }

        string scoreAmount = score.ToString();
        scoreText.text = scoreAmount;
        slider.value = health;
    }

    IEnumerator DeathCoroutine()
    {
        dead = true;
        megaMan.gameObject.SetActive(false);

        for (int i = 0; i < 4; i++)
        {
            Rigidbody2D deathProj = Instantiate(deathParticle, new Vector3(megaMan.transform.position.x, megaMan.transform.position.y, 0), Quaternion.identity);
            if (i == 0)
            {
                deathProj.velocity = new Vector2(3f, 0f);
            }
            if (i == 1)
            {
                deathProj.velocity = new Vector2(0f, 3f);
            }
            if (i == 2)
            {
                deathProj.velocity = new Vector2(-3f, 0f);
            }
            if (i == 3)
            {
                deathProj.velocity = new Vector2(0f, -3f);
            }
        }

        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene("SampleScene");
       

    }



}
