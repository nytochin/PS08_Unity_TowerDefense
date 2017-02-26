using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private NavMeshAgent agent;
    public GameObject particles;
    public AudioClip sound;
    public int life = 1;
    AudioSource audSource;

    // Use this for initialization
    void Start () {
        audSource = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        NavMeshPath path = new NavMeshPath();
        if (agent.CalculatePath(GameObject.Find("Home").transform.position, path))
        {
            agent.destination = GameObject.Find("Home").transform.position;
        }

	}
	
	// Update is called once per frame
	void Update () {
	    if (life == 0)
        {
            Destroy();
            GameManager.gold += 25;

        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Home")
        {
            GameManager.life--;
            Destroy();
        }
        if (other.gameObject.tag == "Bullet")
        {
            life--;
        }
    }

    void Destroy()
    {
        audSource.PlayOneShot(sound);
        GameObject ptc = (GameObject)Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(ptc, 3.0f);
    }
}
