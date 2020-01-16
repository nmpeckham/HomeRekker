using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunHazard : Hazard
{
    public Transform self;
    public float frequency = 0.25f;
    public float time = 5.0f;
    public int rayCount = 7;
    public float raySeparation = 0.5f;

    private bool sunny = false;
    private float nextRay = 0.0f;

    public override void StartHazard()
    {
        StartCoroutine("StartSun");
    }

    IEnumerator StartSun()
    {
        sunny = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(time);
        sunny = false;
        finished = true;
    }

    void Update()
    {
        if (sunny && Time.time > nextRay)
        {
            float raySource = self.position.x - raySeparation * ((rayCount - 1) / 2);
            for (int i = 0; i < rayCount; i++)
            {
                RaycastHit2D[] hit = new RaycastHit2D[1];
                ContactFilter2D contact = new ContactFilter2D();
                Vector2 source = new Vector2(raySource, self.position.y);
                if (Physics2D.Raycast(source, Vector2.down, contact, hit, 40.0f) > 0)
                {
                    if (hit[0].collider.CompareTag("Person"))
                    {
                        Figure figure = hit[0].collider.GetComponent<Figure>();
                        figure.heat += 1;
                        if (figure.heat >= 10)
                            figure._touched = true;
                    }
                }
                raySource += raySeparation;
            }
            nextRay = Time.time + frequency;
        }
    }
}
