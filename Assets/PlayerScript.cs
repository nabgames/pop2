using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    Rigidbody2D rb;
    public int popped;
    public int limit;
    public Transform Existence;
    public string levelName;
    public bool isFirstLevel;
    public int totalPop;
    public int fake;
    public int count;
    public string level;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        if (isFirstLevel){
            fake = 300;
        }
        else{
            fake = PlayerPrefs.GetInt("fake");
        }
        if (isFirstLevel){
            popped = 0;
        }
        else{
            popped = PlayerPrefs.GetInt("popped");
        }
        for (int x = -limit; x <= limit; x++)
        {
            for (int y = -limit; y <= limit; y++)
            {
                Instantiate(Existence, new Vector3(x, y, 0.0f), Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        count = fake / 30;
        fake--;
        PlayerPrefs.SetInt("fake", fake);
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        transform.position = transform.position + move * .1f;
        print(count);
        if (count<=0){
            Application.LoadLevel(level);
        }
	}
	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.CompareTag("ExistenceTrigger")){
            other.gameObject.SetActive(false);
            popped++;
            totalPop++;
            if (totalPop ==  (limit*2+1)*(limit*2+1)){
                PlayerPrefs.SetInt("popped", popped);
                Application.LoadLevel(levelName);
            }
        }
	}
}
