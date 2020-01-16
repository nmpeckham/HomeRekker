using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHazard : Hazard
{
    public Transform self;
    public float countdown = 2.5f;
    public float bombRadius = 5.0f;
    public float bombForce = 500.0f;

    public override void StartHazard()
    {
        StartCoroutine("StartBomb");
    }

    IEnumerator StartBomb()
    {
        yield return new WaitForSeconds(countdown);
        Collider2D[] hits = new Collider2D[100];
        ContactFilter2D contact = new ContactFilter2D();
        Physics2D.OverlapCircle(self.position, bombRadius, contact, hits);
        foreach (Collider2D thing in hits)
        {
            if (thing == null || thing == self.gameObject.GetComponent<Collider2D>())
                continue;
            //Debug.Log("!" + thing.name);
            Rigidbody2D rb = thing.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = rb.position - (Vector2)self.position;
                float distance = direction.magnitude;
                rb.AddForce(Mathf.Lerp(0, bombForce, 1 - distance) * direction, ForceMode2D.Impulse);
            }
        }
        Destroy(self.gameObject);
    }
}
