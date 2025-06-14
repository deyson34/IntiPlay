using UnityEngine;
using System.Collections.Generic;
public class PagoManager : MonoBehaviour
{
    public void EnviarObjetosSeleccionados(List<ObjetoPago> objetos)
    {
        ResultadoPoderes poderes = PagoHelper.CalcularResultado(objetos);
        Debug.Log("Resultado del ritual: \n" + poderes.ToString());
    }
}
