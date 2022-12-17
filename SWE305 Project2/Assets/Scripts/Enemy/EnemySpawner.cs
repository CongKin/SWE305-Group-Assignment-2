using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private GameObject swarmerPrefab;
    [SerializeField]private GameObject bigSwarmerPrefab;

    [SerializeField]private float  swarmerInterval = 3.5f;
    [SerializeField]private float  bigSwarmerInterval = 10f;

    [SerializeField]private float swarmerWave = 5.0f;
    [SerializeField]private float bigSwarmerWave = 5.0f;

    [SerializeField]private float swarmerXmin = -8.0f;
    [SerializeField]private float swarmerXmax = 8.0f;
    [SerializeField]private float swarmerYmin = 2.0f;
    [SerializeField]private float swarmerYmax = 2.0f;

    [SerializeField]private float bigSwarmerXmin = -8.0f;
    [SerializeField]private float bigSwarmerXmax = 8.0f;
    [SerializeField]private float bigSwarmerYmin = 2.0f;
    [SerializeField]private float bigSwarmerYmax = 2.0f;

    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerWave, swarmerPrefab));
        StartCoroutine(spawnEnemy(bigSwarmerInterval, bigSwarmerWave, bigSwarmerPrefab));
    }

    private IEnumerator spawnEnemy(float interval, float wave, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        if(enemy == swarmerPrefab)
        {
            GameObject newEnemy = 
            Instantiate(enemy, new Vector3
                (Random.Range(swarmerXmin,swarmerXmax), Random.Range(swarmerYmin,swarmerYmax), 0), Quaternion.identity);
        }
        else if (enemy == bigSwarmerPrefab)
        {
            GameObject newEnemy = 
            Instantiate(enemy, new Vector3
                (Random.Range(bigSwarmerXmin,bigSwarmerXmax), Random.Range(bigSwarmerYmin,bigSwarmerYmax), 0), Quaternion.identity);
        }
        

        wave--;
        if (wave > 0)
        {
            StartCoroutine(spawnEnemy(interval,wave,enemy));
        }
    }

}
