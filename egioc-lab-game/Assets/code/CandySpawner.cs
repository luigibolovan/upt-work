using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour {

    [SerializeField]
    float maxX;

    public GameObject[] candies;

    [SerializeField]
    float spawnInterval;

    public static CandySpawner instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    // Use this for initialization
    void Start () {
        startSpawning();
    }
	
	// Update is called once per frame
	void Update () {

	}

    void spawnCandy() { 
        int random = Random.Range(0, candies.Length);

        float randomX = Random.Range(-maxX, maxX); //randomize candy position

        Vector3 randomPosition = new Vector3(randomX, transform.position.y, transform.position.z); //create new random position

        Instantiate(candies[random], randomPosition, transform.rotation); //instantiate candy at random position
    }

    IEnumerator spawn() {
        yield return new WaitForSeconds(2f);

        while (true){
            spawnCandy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void startSpawning() {
        StartCoroutine("spawn");
    }

    public void stopSpawning()  {
        StopCoroutine("spawn");
    }
}
