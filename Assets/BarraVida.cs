using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        // Asegúrate de que el componente Slider está asignado
        slider = GetComponent<Slider>();
        if (slider == null)
        {
            Debug.LogError("El componente Slider no está asignado en el GameObject.");
        }
    }

    public void CambiarVidaMaxima(int vidaMaxima)
    {
        if (slider == null) return; // Verifica que slider no sea nulo antes de acceder a él

        slider.maxValue = vidaMaxima; // Asigna el valor máximo correcto
        slider.value = vidaMaxima; // Asigna el valor inicial igual al máximo si es necesario
    }

    public void CambiarVidaActual(int cantidadVida)
    {
        if (slider == null) return; // Verifica que slider no sea nulo antes de acceder a él

        slider.value = cantidadVida;
    }

    public void InicializarBarra(int cantidadVida)
    {
        CambiarVidaMaxima(cantidadVida);
        CambiarVidaActual(cantidadVida);
    }
}
