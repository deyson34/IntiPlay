using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject powerUpManagerPrefab;

    void Awake()
    {
        if (PowerUpManager.Instance == null)
        {
            Instantiate(powerUpManagerPrefab);
        }
    }
    void Start()
    {
        ResultadoPoderes poderes = PowerUpManager.Instance.poderesSeleccionados;
        if (poderes != null)
        {
            Debug.Log("Aplicando bonificaciones:");
            Debug.Log(poderes.ToString());
        }
        // Aquí puedes aplicar los stats:
        // - fuego → vida extra
        // - agua → velocidad
        // - tierra → daño
    }
}
