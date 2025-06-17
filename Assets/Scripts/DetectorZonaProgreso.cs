using UnityEngine;

public class DetectorZonaProgreso : MonoBehaviour
{
    private CrearBarraProgreso barra;
    public float cantidadAumentar = 20f; // Aumenta de 20 en 20

    private void Start()
    {
        barra = FindObjectOfType<CrearBarraProgreso>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador toc� la fogata");

            if (barra != null)
            {
                barra.AumentarProgreso(cantidadAumentar); // Aqu� aumentar� 20 puntos
            }
        }
    }
}
