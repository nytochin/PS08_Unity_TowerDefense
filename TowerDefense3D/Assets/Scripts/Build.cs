using UnityEngine;
using System.Collections;

public class Build : MonoBehaviour {

    public Texture2D tex;
    public Texture2D texOver;
    public Texture2D texError;
    public GameObject tower;
    public int cost = 20;
    private bool hasTower = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnMouseOver()
    {
        if (!hasTower && GameManager.gold >= cost)
            GetComponent<Renderer>().material.mainTexture = texOver;
        else
            GetComponent<Renderer>().material.mainTexture = texError;
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.mainTexture = tex;
    }

    private void OnMouseUp()
    {
        if (!hasTower && GameManager.gold >= cost)
        {
            Vector3 pos = transform.position;
            pos.y = -0.6f;
            Instantiate(tower, pos, Quaternion.identity);
            hasTower = true;
            GameManager.gold -= cost;
        }
    }
}
