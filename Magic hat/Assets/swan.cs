using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swan : MonoBehaviour
{
    private Vector3 startPosition;
    public float speed;
    void Start()
    {
        Vector3 screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float swanExtentsX = transform.GetComponent<Renderer>().bounds.extents.x;
        startPosition = new Vector3(screenSize.x + transform.position.y, transform.position.z);
        transform.position = startPosition;
    }

    void Update()
    {
        if (transform.position.x < -startPosition.x)
        {
            transform.position = startPosition;
        }
        transform.Translate(Vector3.right * -1 * speed * Time.deltaTime);
    }
}
