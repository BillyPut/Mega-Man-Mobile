using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    public float yPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
        if (player.transform.position.x > 102f || player.transform.position.y > 12f)
        {
            yPos = player.transform.position.y + 1f;
        }
        else
        {
            yPos = 0f;
        }

        transform.position = new Vector3(player.transform.position.x, yPos, transform.position.z);
    }
}
