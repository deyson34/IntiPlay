using System.Collections.Generic;

public static class PagoHelper
{
    public static ResultadoPoderes CalcularResultado(List<ObjetoPago> objetoSeleccionados)
    {
        ResultadoPoderes resultado = new ResultadoPoderes();
        foreach (var obj in objetoSeleccionados)
        {
            switch (obj.tipoElemento)
            {
                case Elemento.Fuego:
                    resultado.fuego++;
                    break;
                case Elemento.Agua:
                    resultado.agua++;
                    break;
                case Elemento.Tierra:
                    resultado.tierra++;
                    break;
            }
        }
        return resultado;
    }    
}
