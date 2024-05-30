using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy1 : MonoBehaviour
{
   
    public void DestroyEnemy1()
    {
        DestroyObject(gameObject);

        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Enemy_Destroyer1");

        
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }

}
