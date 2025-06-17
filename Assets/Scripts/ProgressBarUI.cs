using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    private GameObject progressBarBackground;
    private GameObject progressBarFill;
    private Text percentText;

    private float targetProgress = 1f; // Empieza llena
    private float currentProgress = 1f;

    [Header("3D Settings")]
    [SerializeField] private Transform targetObject;
    [SerializeField] private Vector3 offset = new Vector3(0, 2f, 0);

    private Canvas canvas;
    private RectTransform canvasRect;

    void Start()
    {
        CreateUI();
        UpdateProgressBar(); // Asegura que inicie en 100%
    }

    void Update()
    {
        if (Mathf.Abs(currentProgress - targetProgress) > 0.001f)
        {
            currentProgress = Mathf.Lerp(currentProgress, targetProgress, Time.deltaTime * 5f);
            UpdateProgressBar();
        }

        if (canvas.renderMode == RenderMode.WorldSpace && targetObject != null)
        {
            canvas.transform.position = targetObject.position + offset;
            canvas.transform.LookAt(Camera.main.transform);
            canvas.transform.Rotate(0, 180f, 0);
        }

        // Bajar progreso con tecla C
        if (Input.GetKeyDown(KeyCode.C))
        {
            targetProgress -= 0.2f;
            targetProgress = Mathf.Clamp01(targetProgress); // Asegura que no sea menor que 0
        }
    }

    void CreateUI()
    {
        GameObject canvasGO = new GameObject("Canvas", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
        canvas = canvasGO.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvasGO.GetComponent<CanvasScaler>().dynamicPixelsPerUnit = 10;
        canvasRect = canvasGO.GetComponent<RectTransform>();
        canvasRect.sizeDelta = new Vector2(1.5f, 0.5f);
        canvasGO.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);

        CanvasGroup cg = canvasGO.AddComponent<CanvasGroup>();
        cg.interactable = false;
        cg.blocksRaycasts = false;

        if (FindFirstObjectByType<UnityEngine.EventSystems.EventSystem>() == null)
        {
            GameObject eventSystem = new GameObject("EventSystem", typeof(UnityEngine.EventSystems.EventSystem));
            eventSystem.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
        }

        progressBarBackground = new GameObject("ProgressBarBackground", typeof(Image));
        progressBarBackground.transform.SetParent(canvasGO.transform);
        Image bgImage = progressBarBackground.GetComponent<Image>();
        bgImage.color = new Color(0.2f, 0.15f, 0.1f);

        RectTransform bgRect = progressBarBackground.GetComponent<RectTransform>();
        bgRect.anchorMin = new Vector2(0.5f, 0.5f);
        bgRect.anchorMax = new Vector2(0.5f, 0.5f);
        bgRect.pivot = new Vector2(0.5f, 0.5f);
        bgRect.sizeDelta = new Vector2(1.5f, 0.15f);
        bgRect.anchoredPosition = Vector2.zero;

        progressBarFill = new GameObject("ProgressBarFill", typeof(Image));
        progressBarFill.transform.SetParent(progressBarBackground.transform);
        Image fillImage = progressBarFill.GetComponent<Image>();
        fillImage.color = new Color(0.8f, 0.6f, 0.1f);

        RectTransform fillRect = progressBarFill.GetComponent<RectTransform>();
        fillRect.anchorMin = new Vector2(0, 0);
        fillRect.anchorMax = new Vector2(0, 1);
        fillRect.pivot = new Vector2(0, 0.5f);
        fillRect.sizeDelta = new Vector2(0, 0);
        fillRect.anchoredPosition = Vector2.zero;

        GameObject textGO = new GameObject("ProgressText", typeof(Text));
        textGO.transform.SetParent(progressBarBackground.transform);
        percentText = textGO.GetComponent<Text>();
        percentText.alignment = TextAnchor.MiddleCenter;
        percentText.color = Color.white;
        percentText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        percentText.text = "100%";

        RectTransform textRect = percentText.GetComponent<RectTransform>();
        textRect.sizeDelta = bgRect.sizeDelta;
        textRect.anchoredPosition = Vector2.zero;
    }

    void UpdateProgressBar()
    {
        float totalWidth = 1.5f;
        progressBarFill.GetComponent<RectTransform>().sizeDelta = new Vector2(totalWidth * currentProgress, 0);
        percentText.text = Mathf.RoundToInt(currentProgress * 100f) + "%";
    }
}
