using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;
    private float timeSpawn;
    public float startTimeSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;

    // Update is called once per frame
    private void Update()
    {
        if (timeSpawn <= 0)
        {
            int random = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstaclePatterns[random], transform.position, Quaternion.identity);
            /*GameObject obj = ObjectPool.current.GetPooledObject();
            if (obj == null) return;
            obj.transform.position = obstaclePatterns[random].transform.position;
            obj.transform.rotation = obstaclePatterns[random].transform.rotation;
            obj.SetActive(true);*/
            timeSpawn = startTimeSpawn;
            if (startTimeSpawn > minTime)
            {
                startTimeSpawn -= decreaseTime;
            }
        }
        else
        {
            timeSpawn -= Time.deltaTime;
        }
    }
}
