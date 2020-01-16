using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    float maxX;
    float minX;
    int dir = 0;
    // Update is called once per frame

    private void Start()
    {
        if (speed > 0) {
            maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + 200, 0, 0)).x;
            minX = Camera.main.ScreenToWorldPoint(new Vector3(-200, 0, 0)).x;
            dir = 0;
        }
        else
        {
            maxX = Camera.main.ScreenToWorldPoint(new Vector3(-200, 0, 0)).x;
            minX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + 200, 0, 0)).x;
            dir = 1;
        }
    }
    void Update()
    {
        transform.SetPositionAndRotation(new Vector3(transform.position.x + speed, transform.position.y, -1), Quaternion.identity);

        if (dir == 0)
        {
            if (transform.position.x > maxX) transform.SetPositionAndRotation(new Vector3(minX, transform.position.y, -1), Quaternion.identity);
        }

        else if (transform.position.x < maxX) transform.SetPositionAndRotation(new Vector3(minX, transform.position.y, -1), Quaternion.identity);

    }
}
