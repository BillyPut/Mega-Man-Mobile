using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public bool resetGame, stopPlayer = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(TextAppear());
        }
    }

    IEnumerator TextAppear()
    {
        transform.GetChild(0).gameObject.SetActive(true);

        stopPlayer = true;

        yield return new WaitForSeconds(3f);

        resetGame = true;
    }


}
