using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollisionDo : MonoBehaviour
{
    [SerializeField] private UnityEvent action;
    private GameObject colisionee;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        colisionee = collision.gameObject;
        action.Invoke();
    }

    public void OnDestroy()
    {
     if(colisionee != null)
        {
            Destroy(colisionee);
        }
    } 
}
