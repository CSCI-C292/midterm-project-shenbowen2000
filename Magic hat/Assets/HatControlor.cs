using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatControlor : MonoBehaviour
{
    public GameObject effect;
    Vector3 rawPosition;
    Vector3 hatPosition;     
    float maxWidth;          
    public static int sum = 0;  
        
    void Start()
    {
        Vector3 screenPos = new Vector3(Screen.width, 0, 0);
        Vector3 moveWidth = Camera.main.ScreenToWorldPoint(screenPos);
        float hatWidth = GetComponent<Renderer>().bounds.extents.x;
        hatPosition = transform.position;
        maxWidth = moveWidth.x - hatWidth;
    }
    void Update()
    {
        rawPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hatPosition = new Vector3(rawPosition.x, hatPosition.y, 0);
        hatPosition.x = Mathf.Clamp(hatPosition.x, -maxWidth, maxWidth);
        GetComponent<Rigidbody2D>().MovePosition(hatPosition);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        sum++;
        
        Destroy(col.gameObject);
        
    }
    void OnGUI()
    {
        GUIStyle style = new GUIStyle();

        style.fontSize = 25;                    
        style.normal.textColor = Color.black;   

        GUILayout.BeginArea(new Rect(5, 5, 500, 100));
        GUILayout.Label("Score：" + sum, style, GUILayout.Width(200), GUILayout.Height(50));
        GUILayout.EndArea();
    }
}