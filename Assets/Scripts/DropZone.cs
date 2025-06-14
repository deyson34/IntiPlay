using UnityEngine;

public class DropZone : MonoBehaviour
{
    public GameObject currentObject;
    private Transform parentOriginal;
    public bool RegisterObject(GameObject obj, Vector3 posicionOriginal)
    {
        if (currentObject != null)
        {
            Debug.LogWarning("DropZone already has an object registered.");
            return false;
        }

        currentObject = obj;

        parentOriginal = obj.transform.parent; // Guarda el padre actual
        // Saca al objeto de su padre para que se mueva libremente en el mundo
        obj.transform.SetParent(null);

        // Ahora sí, mueve el objeto con precisión
        obj.transform.position = transform.position + Vector3.up * 0.01f;
        obj.transform.rotation = Quaternion.identity;
        obj.transform.SetParent(parentOriginal); // Vuelve a su contenedor
        Debug.Log($"Object {obj.name} registered in DropZone {gameObject.name} at position {obj.transform.position}.");
        return true;
    }
    public void RemoveObject(GameObject obj)
    {
        if (currentObject == obj)
        {
            Debug.Log($"Objeto {obj.name} removido de {gameObject.name}");
            currentObject = null;
        }
    }
}

