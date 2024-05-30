using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public static bool isUpgrading = true;

    public GameObject upgrade;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public Transform canvas;


    private List<Transform> targets = new();
    private Transform cam;


    private void Start()
    {
        InvokeRepeating(nameof(Shoot), 0f, fireRate);
        cam = Camera.main.transform;
        canvas.gameObject.GetComponent<Canvas>().worldCamera = Camera.main;
    }

    private void Update()
    {
        canvas.gameObject.SetActive(isUpgrading);

        if(!isUpgrading) return;

        canvas.transform.LookAt(transform.position + cam.forward);
    }

    public void Upgrade()
    {
        if (upgrade == null)
            return;

        Instantiate(upgrade, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void Shoot()
    {
        ClearEmpty();

        if(targets.Count == 0)
        {
            return;
        }

        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation).GetComponent<Bullet>();
        //TODO: target closest enemy
        bullet.target = targets[0];
    }

    void ClearEmpty()
    {
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] == null)
                targets.RemoveAt(i);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            targets.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            targets.Remove(other.transform);
        }
    }
}
