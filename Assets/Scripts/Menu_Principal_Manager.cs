using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Principal_Manager : MonoBehaviour
{
    [Header("Camaras")]
    public Camera mainCamera;
    public Camera menuCamera;
    public Camera creditCamera;
    public Camera preJuegoCamera;

    [Header("Terrenos")]
    public GameObject terrenoUI;
    public GameObject terrenoGameplay;

    [Header("UIs")]
    public GameObject uiMenu;
    public GameObject uiCreditos;
    public GameObject uiPreJuego;
    public GameObject uiGameplay;

    [Header("Contenedores de escenario")]
    public GameObject escenario;
    public GameObject mainMenu;
    public GameObject credits;
    public GameObject preJuego;

    [Header("Historia y Traducción")]
    public GameObject historiaEN;
    public GameObject historiaES;
    public Button translateButton;
    [SerializeField] private TextMeshProUGUI translateButtonText;
    private bool mostrandoIngles = true;
    public bool jugando => PowerUpManager.Instance != null && PowerUpManager.Instance.estaJugando;
    void Start()
    {
        if (jugando)
        {
            // Activar la cámara principal y desactivar las demás
            mainCamera.enabled = true;
            creditCamera.enabled = false;
            preJuegoCamera.enabled = false;
            menuCamera.enabled = false;

            // Desactivar todos los UIs excepto el de gameplay
            uiMenu.SetActive(false);
            uiCreditos.SetActive(false);
            uiPreJuego.SetActive(false);
            uiGameplay.SetActive(true);

            // Desactivar todos los contenedores de escenario excepto el de gameplay
            mainMenu.SetActive(false);
            credits.SetActive(false);
            preJuego.SetActive(false);

            terrenoUI.SetActive(false);
            terrenoGameplay.SetActive(true);

            foreach (var listener in FindObjectsByType<AudioListener>(FindObjectsSortMode.None))
            {
                listener.enabled = false;
            }
            mainCamera.GetComponent<AudioListener>().enabled = true;
        }
        else
        {
            // Desactivar todas las cámaras excepto la del menú
            mainCamera.enabled = false;
            creditCamera.enabled = false;
            preJuegoCamera.enabled = false;
            menuCamera.enabled = true;

            // Desactivar todos los UIs excepto el del menú principal
            uiMenu.SetActive(true);
            uiCreditos.SetActive(false);
            uiPreJuego.SetActive(false);
            uiGameplay.SetActive(false);

            // Desactivar todos los contenedores de escenario excepto el del menú principal
            mainMenu.SetActive(true);
            credits.SetActive(false);
            preJuego.SetActive(false);

            terrenoUI.SetActive(true);
            terrenoGameplay.SetActive(false);

            foreach (var listener in FindObjectsByType<AudioListener>(FindObjectsSortMode.None))
            {
                listener.enabled = false;
            }
            menuCamera.GetComponent<AudioListener>().enabled = true;

            MostrarMenu();  
            // Asignar comportamiento al botón traducir
            translateButton.onClick.AddListener(TranslateStory);
        }
             
    }

    public void MostrarMenu()
    {
        uiMenu.SetActive(true);
        uiCreditos.SetActive(false);
        uiPreJuego.SetActive(false);
        uiGameplay.SetActive(false);

        mainMenu.SetActive(true);
        credits.SetActive(false);
        preJuego.SetActive(false);

        terrenoUI.SetActive(true);
        terrenoGameplay.SetActive(false);

        menuCamera.enabled = true;
        creditCamera.enabled = false;
        preJuegoCamera.enabled = false;
        mainCamera.enabled = false;
    }

    public void MostrarCreditos()
    {
        uiMenu.SetActive(false);
        uiCreditos.SetActive(true);
        uiPreJuego.SetActive(false);
        uiGameplay.SetActive(false);

        mainMenu.SetActive(false);
        credits.SetActive(true);
        preJuego.SetActive(false);

        terrenoUI.SetActive(true);
        terrenoGameplay.SetActive(false);

        menuCamera.enabled = false;
        creditCamera.enabled = true;
        preJuegoCamera.enabled = false;
        mainCamera.enabled = false;
    }

    public void EmpezarPreJuego()
    {
        uiMenu.SetActive(false);
        uiCreditos.SetActive(false);
        uiPreJuego.SetActive(true);
        uiGameplay.SetActive(false);

        mainMenu.SetActive(false);
        credits.SetActive(false);
        preJuego.SetActive(true);

        terrenoUI.SetActive(true);
        terrenoGameplay.SetActive(false);

        menuCamera.enabled = false;
        creditCamera.enabled = false;
        preJuegoCamera.enabled = true;
        mainCamera.enabled = false;

        // Mostrar texto en inglés por defecto
        MostrarHistoriaIngles();
    }

    public void TranslateStory()
    {
        if (mostrandoIngles)
            MostrarHistoriaEspanol();
        else
            MostrarHistoriaIngles();
    }

    public void MostrarHistoriaIngles()
    {
        mostrandoIngles = true;
        historiaEN.SetActive(true);
        historiaES.SetActive(false);
        translateButtonText.text = "Spanish Version";
    }

    public void MostrarHistoriaEspanol()
    {
        mostrandoIngles = false;
        historiaEN.SetActive(false);
        historiaES.SetActive(true);
        translateButtonText.text = "English Version";
    }

    public void PagoEscena()
    {
        // Cargar la escena de PersonalizarPago
        SceneManager.LoadScene("PagoTierraPowerUps");
    }
    public void EmpezarJuego()
    {
        // Esto se llamaría después de la escena de PersonalizarPago
        uiMenu.SetActive(false);
        uiCreditos.SetActive(false);
        uiPreJuego.SetActive(false);
        uiGameplay.SetActive(true);

        mainMenu.SetActive(false);
        credits.SetActive(false);
        preJuego.SetActive(false);

        terrenoUI.SetActive(false);
        terrenoGameplay.SetActive(true);

        menuCamera.enabled = false;
        creditCamera.enabled = false;
        preJuegoCamera.enabled = false;
        mainCamera.enabled = true;
    }

    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
