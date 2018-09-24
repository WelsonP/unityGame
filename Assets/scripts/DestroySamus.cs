using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySamus : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            GameObject.FindWithTag("Finish").GetComponent<AudioSource>().mute = true;
            AudioSource source = GetComponent<AudioSource>();
            source.Play();

            Destroy(this.gameObject.GetComponent<CircleCollider2D>());
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
