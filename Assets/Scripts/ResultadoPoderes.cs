using UnityEngine;

public class ResultadoPoderes
{
    public int fuego = 0;
    public int agua = 0;
    public int tierra = 0;

    public int bonificacionVidaHoguera => fuego * 20;
    public float bonificacionVelocidad => agua * 25;

    public float bonificacionDaño => tierra * 25;

    public override string ToString()
    {
        return $"🔥 Fuego: {fuego} (+{bonificacionVidaHoguera} vida)\n" +
               $"💧 Agua: {agua} (+{bonificacionVelocidad}% velocidad)\n" +
               $"🌱 Tierra: {tierra} (+{bonificacionDaño}% daño)\n";
    }
}
