using UnityEngine;
using UnityEngine.UI;

public class FogataVida : MonoBehaviour
{
    public Slider barraVida;
    private float vida = 100f;
    private float consumoPorSegundo = 2f; // La fogata pierde vida con el tiempo
    private float dañoPorEnemigos = 5f; // Daño recibido por ataques

    public ParticleSystem fuegoParticulas; // Para cambiar efectos visuales
    private Color fuegoNormal = Color.white;
    private Color fuegoDañado = new Color(1f, 0.5f, 0.5f); // Rojo-anaranjado para indicar daño

    void Start()
    {
        fuegoParticulas = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        vida -= consumoPorSegundo * Time.deltaTime;
        barraVida.value = vida;

        if (vida <= 0)
        {
            ApagarFogata();
        }
    }

    public void AgregarLeña()
    {
        vida += 20f; // Cada leña aumenta la vida de la fogata
        if (vida > 100f) vida = 100f;
        CambiarColorFuego(fuegoNormal); // Restaurar fuego normal al agregar leña
    }

    public void RecibirDaño()
    {
        vida -= dañoPorEnemigos;
        CambiarColorFuego(fuegoDañado); // Cambiar efecto visual cuando recibe daño
    }

    void ApagarFogata()
    {
        GetComponentInChildren<ParticleSystem>().Stop();
    }

    void CambiarColorFuego(Color nuevoColor)
    {
        var main = fuegoParticulas.main;
        main.startColor = nuevoColor;
    }
}
