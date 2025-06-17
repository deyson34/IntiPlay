using UnityEngine;

public class TomarObjeto : MonoBehaviour
{
    public Transform puntoDeSujecion; // Lugar donde se sujeta el objeto
    private GameObject objetoTomado;
    private float distanciaRaycast = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objetoTomado == null)
                IntentarTomarObjeto();
            else
                SoltarObjeto();
        }

        if (objetoTomado != null)
        {
            objetoTomado.transform.position = puntoDeSujecion.position;
        }
    }

    void IntentarTomarObjeto()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); // hacia donde mira la cámara

        if (Physics.Raycast(ray, out hit, distanciaRaycast))
        {
            if (hit.transform.CompareTag("Interactivo"))
            {
                objetoTomado = hit.transform.gameObject;
                Rigidbody rb = objetoTomado.GetComponent<Rigidbody>();
                if (rb != null) rb.isKinematic = true;

                objetoTomado.transform.SetParent(puntoDeSujecion);
                objetoTomado.transform.position = puntoDeSujecion.position;
            }
        }
    }

    void SoltarObjeto()
    {
        if (objetoTomado != null)
        {
            Rigidbody rb = objetoTomado.GetComponent<Rigidbody>();
            if (rb != null) rb.isKinematic = false;

            objetoTomado.transform.SetParent(null);
            objetoTomado = null;
        }
    }
}
