using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnTime;
    public float yPosMin, yPosMax;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnPipes());
    }

   IEnumerator SpawnPipes()
    {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(pipe, transform.position + Vector3.up * Random.Range(yPosMin,yPosMax), Quaternion.identity);
            StartCoroutine(SpawnPipes());
 
    }
    // Update is called once per fram
}
