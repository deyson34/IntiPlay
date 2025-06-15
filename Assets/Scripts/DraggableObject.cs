using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private bool isDragging = false;
    private float zCoord;
    private Vector3 originalPosition;
    private DropZone zonaActual = null;

    public bool colocadoEnZona = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPosition = transform.position;
    }

    private void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        transform.position += Vector3.up * 0.005f; // Levitar al iniciar el arrastre

        if (colocadoEnZona && zonaActual != null)
        {
            zonaActual.RemoveObject(gameObject);
            zonaActual = null;
            colocadoEnZona = false;
        }
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if(!isDragging || colocadoEnZona) return;

        Vector3 mouseWorld = GetMouseWorldPosition();
        transform.position = new Vector3(mouseWorld.x, originalPosition.y + 0.005f, mouseWorld.z);
        
    }

    private void OnMouseUp()
    {
        isDragging = false;
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // Registrar objeto en la DropZone
            DropZone zona = hit.collider.GetComponent<DropZone>();
            if (zona != null)
            {
                colocadoEnZona = zona.RegisterObject(gameObject, originalPosition);
                zonaActual = zona;
                return;
            }
        }
        //No se soltó en una DropZone
        transform.position = originalPosition;
        colocadoEnZona = false;
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = zCoord; // Set the z coordinate to the distance from the camera
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }
}
