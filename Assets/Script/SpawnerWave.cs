using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnerWave : MonoBehaviour
{
    [System.Serializable]
    public class WAVE
    {
        public GameObject[] enemies;
        public int count;
        public float enemybetwenspown;
    }
    public WAVE[] wave;
    public Transform[] spawnpoint;
    public float timebetwenspows;
    public GameObject healtBar;
    private WAVE curentweave;
    private int curentweavesIndex;
    private Transform player;
    public GameObject Boss;
    public Transform bossSpawnerPonint;
    bool ok = false;
    bool finishingWeave = true;
    int i= 0;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    private void Update()
    {
        if (player != null)
        {
            if (curentweavesIndex < wave.Length)
            {
                if (finishingWeave == true)
                {
                    finishingWeave = !finishingWeave;
                    StartCoroutine(StartNextWave(curentweavesIndex));
                    curentweavesIndex++;
                }

            }
            else
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && curentweavesIndex >= wave.Length)
            {
                if (!ok)
                {
                    Instantiate(Boss, bossSpawnerPonint.position, bossSpawnerPonint.rotation);
                    healtBar.SetActive(true);
                    ok = !ok;
                }
            }
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && i == curentweave.count)
            {
                finishingWeave = !finishingWeave;
                i = 0;
            }

        }
    }

    IEnumerator StartNextWave(int index)
    {
        yield return new  WaitForSeconds(timebetwenspows);
        StartCoroutine(SpawnWeave(index));
    }

    IEnumerator SpawnWeave(int index)
    {
        curentweave = wave[index];
        for (i=0;i<curentweave.count;i++)
        {
            if(player==null)
            {
                yield break;
            }
            GameObject randomEnemy = curentweave.enemies[Random.Range(0, curentweave.enemies.Length)];
            Transform random = spawnpoint[Random.Range(0, spawnpoint.Length)];
            Instantiate(randomEnemy, random.position, random.rotation);

            yield return new WaitForSeconds(curentweave.enemybetwenspown);
         
        }

    }


}
