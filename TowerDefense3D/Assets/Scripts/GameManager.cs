using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static int life = 4;
    public static int gold = 100;
    public TextMesh textLife;
    public GameObject particles;
    private bool end = false;
    public Text textGold;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {

        textGold.text = "Golds : " + gold;
        if (textLife != null){
            string text = "";
            for (int i = 0; i < life; i++)
            {
                text += "-";
            }
            textLife.text = text;
            if (life == 0 && !end)
            {
                Instantiate(particles, GameObject.Find("House").transform.position, Quaternion.identity);
                Destroy(GameObject.Find("House"));
                end = true;
            }
        }
        
	}
}
