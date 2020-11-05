using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlor : MonoBehaviour
{
    public GameObject ball;    
    private float maxwidth;    
    private float time = 2;
    GameObject newball;        
    void Start()
    {
        Vector3 screenPos = new Vector3(Screen.width, 0, 0);
        Vector3 moveWidth = Camera.main.ScreenToWorldPoint(screenPos);
        float ballWidth = ball.GetComponent<Renderer>().bounds.extents.x;
        maxwidth = moveWidth.x - ballWidth;
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = Random.Range(1f, 1.5f);
            float posX = Random.Range(-maxwidth, maxwidth);
            float posY = Random.Range(5, 7);
            Vector3 spawnPosition = new Vector3(posX, posY, 0);

            newball = (GameObject)Instantiate(ball, spawnPosition, Quaternion.identity);
            Destroy(newball, 5);
        }
    }
}
