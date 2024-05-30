using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreToThrowing : MonoBehaviour
{
    public int damagedealing;

    private Rigidbody rb;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        // check if you hit an enemy
        if (collision.gameObject.GetComponent<BasicEnemy>() != null)
        {
            BasicEnemy enemy = collision.gameObject.GetComponent<BasicEnemy>();

            enemy.TakeDamage(damagedealing);

            
            Destroy(gameObject);
        }

        
        rb.isKinematic = true;

        
        
    }
}
