using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public float speed = 1f;
    // public GameObject explosionPrefab;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
    private void nTriggerEnter2D(Collider2D collision)
    {
        //Instantiate(explosionPrefab, transform.position, Quartenion.Identity);
        Destroy(gameObject);
    }
}
