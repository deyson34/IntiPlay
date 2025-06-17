using UnityEngine;

public class RecogerLeña : MonoBehaviour
{
    private GameObject leñaRecogida;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Presionar "E" para recoger
        {
            RecogerObjeto();
        }
        else if (Input.GetKeyDown(KeyCode.Q) && leñaRecogida != null) // Presionar "Q" para agregar
        {
            AgregarALaFogata();
        }
    }

    void RecogerObjeto()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            if (hit.collider.CompareTag("Leña"))
            {
                leñaRecogida = hit.collider.gameObject;
                leñaRecogida.SetActive(false); // Ocultar la leña al recogerla
            }
        }
    }

    void AgregarALaFogata()
    {
        if (leñaRecogida != null)
        {
            FogataVida fogata = FindObjectOfType<FogataVida>(); // Buscar la fogata en la escena
            if (fogata != null)
            {
                fogata.AgregarLeña();
                leñaRecogida = null; // La leña ha sido usada
            }
        }
    }
}
