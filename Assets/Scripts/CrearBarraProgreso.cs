using UnityEngine;
using UnityEngine.UI;

public class CrearBarraProgreso : MonoBehaviour
{
    public Slider barraProgreso;

    void Start()
    {
        // Crear Canvas
        GameObject canvasGO = new GameObject("Canvas", typeof(Canvas));
        Canvas canvas = canvasGO.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        // Crear Slider
        GameObject sliderGO = new GameObject("BarraProgreso", typeof(Slider));
        sliderGO.transform.SetParent(canvasGO.transform);

        RectTransform rt = sliderGO.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(400, 25);
        rt.anchorMin = new Vector2(0.5f, 1f); // centro en X, top en Y
        rt.anchorMax = new Vector2(0.5f, 1f);
        rt.pivot = new Vector2(0.5f, 1f);
        rt.anchoredPosition = new Vector2(0, -20); // 20px desde el borde superior

        barraProgreso = sliderGO.GetComponent<Slider>();
        barraProgreso.minValue = 0;
        barraProgreso.maxValue = 100;
        barraProgreso.value = 0;
        barraProgreso.direction = Slider.Direction.LeftToRight;

        // Crear Background
        GameObject bg = new GameObject("Background", typeof(Image));
        bg.transform.SetParent(sliderGO.transform, false);
        Image bgImage = bg.GetComponent<Image>();
        bgImage.color = new Color(0.2f, 0.2f, 0.2f, 1f); // gris oscuro
        RectTransform bgRT = bg.GetComponent<RectTransform>();
        bgRT.anchorMin = new Vector2(0, 0);
        bgRT.anchorMax = new Vector2(1, 1);
        bgRT.offsetMin = Vector2.zero;
        bgRT.offsetMax = Vector2.zero;
        barraProgreso.targetGraphic = bgImage;

        // Crear Fill
        GameObject fillGO = new GameObject("Fill", typeof(Image));
        fillGO.transform.SetParent(sliderGO.transform, false);
        Image fillImage = fillGO.GetComponent<Image>();
        fillImage.color = new Color(0.3f, 0.8f, 0.3f, 1f); // verde suave
        RectTransform fillRT = fillGO.GetComponent<RectTransform>();
        fillRT.anchorMin = new Vector2(0, 0);
        fillRT.anchorMax = new Vector2(1, 1);
        fillRT.offsetMin = new Vector2(2, 2);
        fillRT.offsetMax = new Vector2(-2, -2);

        barraProgreso.fillRect = fillRT;

        // Añadir Outline (opcional)
        Outline outline = bg.AddComponent<Outline>();
        outline.effectColor = Color.black;
        outline.effectDistance = new Vector2(1.5f, -1.5f);
    }

    public void AumentarProgreso(float cantidad)
    {
        barraProgreso.value = Mathf.Clamp(barraProgreso.value + cantidad, 0, 100);
    }
}
