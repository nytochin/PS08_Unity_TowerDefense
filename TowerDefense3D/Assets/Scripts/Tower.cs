using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

    private GameObject enemy;
    public GameObject proj;
    public GameObject gun;
    public float power = 100.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (enemy != null)
        {
            transform.LookAt(enemy.transform.position);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        print("name : " + other.gameObject.name);
        if (other.gameObject.tag == "Enemy")
        {
            enemy = other.gameObject;
            transform.LookAt(enemy.transform.position);
            Fire();
        }
    }

    void Fire()
    {
        GameObject bullet = (GameObject) Instantiate(proj, gun.transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * power);
        Destroy(bullet, 3.0f);
    }
}
