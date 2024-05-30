using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class WaveInfo
{
    public GameObject enemyPrefab;
    public int count = 10;
    public float rate = 2;
    public AudioClip audioClip;
    public float offset = 15;
}

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> targets;
    public GameObject enemyPrefab;
    public float spawnRate = 2;

    
    public float offset = 15;
    public TextMeshProUGUI timer;

    [Header("Audio")]
    public AudioClip beep;
    public AudioClip start;

    [Header("Waves")]
    public WaveInfo[] waves;

    private AudioSource audio;
    private bool isSpawning = true;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        StartCoroutine(Waves());
    }

    IEnumerator Waves()
    {
        foreach (var wave in waves)
        {
            
            Tower.isUpgrading = true;

            //COUNT DOWN
            timer.gameObject.SetActive(true);
            timer.color = Color.white;
            offset = wave.offset;
            while (offset >= 0)
            {
                if (offset < 11) timer.color = Color.yellow;

                if (offset < 6)
                {
                    timer.color = Color.red;
                    audio.PlayOneShot(beep);
                }

                timer.text = offset.ToString();
                offset--;
                yield return new WaitForSeconds(1);
            }
            audio.PlayOneShot(start);
            timer.gameObject.SetActive(false);

            //SPAWN
            
            Tower.isUpgrading = false;
            for (int i = 0; i < wave.count; i++)
            {
                Instantiate(wave.enemyPrefab, transform.position, Quaternion.identity).GetComponent<Enemy>().targets = targets;
                yield return new WaitForSeconds(wave.rate);
            }
        }
        isSpawning = false;
    }

    private void Update()
    {
        if (isSpawning) return;

        if (FindObjectsOfType<Enemy>().Length == 0)
        {
            // win screen
            Debug.Log("You win!");
        }
    }


    private void OnDrawGizmos()
    {
        if (targets.Count <= 1) return;

        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, targets[0].position);
        for (int i = 0; i < targets.Count - 1; i++)
        {
            Gizmos.DrawLine(targets[i].position, targets[i + 1].position);
        }
    }
}
