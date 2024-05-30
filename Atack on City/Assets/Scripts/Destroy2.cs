using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy2 : MonoBehaviour
{
   
    public void DestroyEnemy2()
    {
        DestroyObject(gameObject);

        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Enemy_Destroyer2");

        
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }

}
