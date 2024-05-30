using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform bar;

    private Transform cam;

    void Start()
    {
        cam = Camera.main.transform;
    }

    
    void Update()
    {
        transform.LookAt(transform.position + cam.forward);
    }

    public void Scale(int health, int maxHealth)
    {
        bar.localScale = new Vector3((float)health / maxHealth, 1, 1);
    }
}
