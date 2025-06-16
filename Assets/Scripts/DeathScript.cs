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
        Debug.Log("Algo entró al trigger: " + other.gameObject.name);

        if (other.CompareTag("Projectile"))
        {
            Debug.Log("Enemy Hit!!!");
            Destroy(transform.root.gameObject);  // Destruye al enemigo completo
        }
    }

    // O si estás usando colisiones normales, usa este método en lugar del de arriba:
    /*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Algo colisionó con: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Enemy Hit!!!");
            Destroy(transform.root.gameObject);  // Destruye al enemigo completo
        }
    }
    */
}
