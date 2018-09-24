using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyOnContact : MonoBehaviour {

    public Text countText;
    public AudioClip clip;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            //score += 10;
            // SetCountText();
            AudioSource source = GetComponent<AudioSource>();
            source.Play();

            //Vector2 move = Camera.main.ViewportToWorldPoint(new Vector2(0.2f, 0.2f));
            //this.transform.position = move;

            Destroy(this.gameObject.GetComponent<BoxCollider2D>());
            Destroy(this.gameObject.GetComponent<SpriteRenderer>());

        }
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    ///void SetCountText()
//{
        // countText.text = "Score: " + score.ToString();
//}
}
