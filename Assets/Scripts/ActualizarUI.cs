using UnityEngine;
using TMPro; // Necesario para modificar TextMeshPro

public class ActualizarUI : MonoBehaviour
{
    public TextMeshProUGUI textoPantalla;

    public void CambiarTexto()
    {
        textoPantalla.text = "¡Objeto agarrado con éxito!";
    }
}