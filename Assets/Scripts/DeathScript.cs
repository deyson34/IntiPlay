using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeathScript : MonoBehaviour
{
    public GameObject projectile;

    private void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Algo entr� al trigger: " + other.gameObject.name);

        if (other.CompareTag("Projectile"))
        {
            Debug.Log("Enemy Hit!!!");
            Destroy(transform.root.gameObject);  // Destruye al enemigo completo
        }
    }

    // O si est�s usando colisiones normales, usa este m�todo en lugar del de arriba:
    /*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Algo colision� con: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Enemy Hit!!!");
            Destroy(transform.root.gameObject);  // Destruye al enemigo completo
        }
    }
    */
}
