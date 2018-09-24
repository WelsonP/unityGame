using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}


public class Control_1 : MonoBehaviour
{
    public GameObject sonicWave; // Name of the bullet's prefab
    public GameObject BulletPosition;
    
    public float fireRate = 0.25f;
    public float nextFire = 0.0f;


    public Rigidbody2D rb;
    public float speed;
    public Boundary boundary;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update() { 
        if (Input.GetKeyDown ("space") && Time.time>nextFire) {
			nextFire = Time.time + fireRate;
			GameObject bullet01 = (GameObject)Instantiate (sonicWave);
			bullet01.transform.position = BulletPosition.transform.position;
            AudioSource sound = GetComponent<AudioSource>();
            sound.Play();
        }
	}
			


	void FixedUpdate ()
	{
		float moveVertical = Input.GetAxis ("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rb.velocity = movement * speed;

		rb.position = new Vector2 (
			Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp (rb.position.y, boundary.yMin, boundary.yMax));
	}
}