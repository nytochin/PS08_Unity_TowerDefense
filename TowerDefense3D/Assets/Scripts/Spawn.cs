using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject mob;
    public float interval = 1000.0f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnMob", 0.0f, interval);
    }
	
	// Update is called once per frame
	void Update () {
	}

    void SpawnMob()
    {
        Instantiate(mob, transform.position, Quaternion.identity);
    }
}
