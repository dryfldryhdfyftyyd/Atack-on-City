using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy3 : MonoBehaviour
{
   
    public void DestroyEnemy3()
    {
        DestroyObject(gameObject);

        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("Enemy_Destroyer3");

        
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }

}
