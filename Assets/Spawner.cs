using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public GameObject spawnObject;
    public float spawnTime = 1;
    private float spawnTimeCounter;

	// Use this for initialization
	void Start () {
        spawnTimeCounter = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
        spawnTimeCounter += Time.deltaTime;

        if (spawnTimeCounter > spawnTime)
        {
            GameObject obj = Instantiate(spawnObject);
            obj.transform.position = new Vector3(5 * Random.Range(-1.0f, 1.0f), 3 * Random.Range(-1, 1), 5);
            spawnTimeCounter = 0;
        }
       
	
	}
}
