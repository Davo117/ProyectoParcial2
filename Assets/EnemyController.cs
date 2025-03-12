using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int puntos;
    public GameObject explosionPrefab;
    public float speed;


    //  //
    [SerializeField] private GameObject enemyBulletPrefab;
    [SerializeField] private Transform shootOrigin;

    public AudioSource enemyShoot;
    public float livingTime = 0.6f;
    public SpriteRenderer myRenderer;
    public Collider2D myCollider;
    [SerializeField] private AudioSource enemyDeath;
    void Start()
    {
        InvokeRepeating("DoShoot", 1f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime * -1, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerBullet") 
        {
            PointCount.Instance.AddPoints(puntos);
            Destroy(gameObject, livingTime);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            enemyDeath.Play(); 
            if(myRenderer != null & myCollider != null){ 
                myRenderer.enabled = false;
                myCollider.enabled = false;
            }
        }
    }

    private void DoShoot()
    {
        if(enemyBulletPrefab != null)
        {
            Instantiate(enemyBulletPrefab, shootOrigin.position, Quaternion.identity); 
        }
    }
}
