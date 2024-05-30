using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<Transform> targets;
    public float speed = 3;
    public int minDamage = 10;
    public int maxDamage = 20;

    private int current = 0;

    void Update()
    {
        if (targets.Count == 0) return;

        if (Vector3.Distance(transform.position, targets[current].position) < 0.3f)
        {
            current++;
            if (current >= targets.Count)
            {
                //TODO: attack base
                //TODO: spawn vfx
                var damage = Random.Range(minDamage, maxDamage);
                GameObject.FindGameObjectWithTag("Base").GetComponent<Health>().DealDamage(damage);
                Destroy(gameObject);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targets[current].position, speed * Time.deltaTime);
            if (transform.position == null)
            {
                Destroy(gameObject);

            }
        }    

    }
}
