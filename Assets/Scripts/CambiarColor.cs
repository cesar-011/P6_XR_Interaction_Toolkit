using UnityEngine;

public class CambiarColor : MonoBehaviour
{
    public void PintarDeRojo()
    {
        // Obtiene el renderizador del objeto y le cambia el color a rojo
        GetComponent<MeshRenderer>().material.color = Color.red;
    }
}