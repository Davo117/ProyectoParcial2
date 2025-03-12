using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Transform shootOrigin;
    public GameObject playerBullet;
    public float xMin, yMin, xMax, yMax;
    public GameObject playerExplosion;


    public AudioSource playerExplosionAudio;
    public AudioSource playerHit;
    public AudioSource playerShoot;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerShoot.Play();
            Instantiate(playerBullet, shootOrigin.transform.position, Quaternion.identity);
        }
        float x = Mathf.Clamp(transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector3(x, y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "EnemyBullet" ||  collision.tag == "Enemy")
        {
            //life = life - 1;
            playerHit.Play();
            //if (life == 0)
            //{
                playerExplosionAudio.Play();
                Instantiate(playerExplosion, transform.position, transform.rotation);
                Destroy(gameObject);
            //}
        }
    }
}
