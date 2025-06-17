using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEditor;
public class UIManagerPago : MonoBehaviour
{
    public Button botonEmpezar;
    public TextMeshProUGUI mensaje;
    public DropZone[] zonasDrop;
    public PagoManager pagoManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        botonEmpezar.interactable = false;
        botonEmpezar.onClick.AddListener(EmpezarJuego);
    }

    // Update is called once per frame
    void Update()
    {
        int zonasOcupadas = 0;
        foreach (var zona in zonasDrop)
        {
            if (zona.currentObject != null)
            {
                zonasOcupadas++;
            }
        }
        //Habilitamos si las 3 zonas estan ocupadas
        botonEmpezar.interactable = zonasOcupadas == 3;
    }

    void EmpezarJuego()
    {
        List<ObjetoPago> objetosSeleccionados = new List<ObjetoPago>();
        foreach (var zona in zonasDrop)
        {
            var obj = zona.currentObject.GetComponent<ObjetoPago>();
            if (obj != null)
            {
                objetosSeleccionados.Add(obj);
            }
        }

        ResultadoPoderes poderes = PagoHelper.CalcularResultado(objetosSeleccionados);
        PowerUpManager.Instance.poderesSeleccionados = poderes;
        PowerUpManager.Instance.estaJugando = true;
        // Ir a la escena principal (combate o gameplay)
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenary");
    }
}
