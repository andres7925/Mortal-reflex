using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    private Slider slider;

    private void Start(){
        slider = GetComponent<Slider>();
    }

    public void CambiarVidaMaxima(int vidaMaxima){
        slider.maxValue = 100;
    }

    public void CambiarVidaActual(int cantidadVida)
    {
        slider.value = cantidadVida;
    }

    public void InicializarBarra(int cantidadVida)
    {
        CambiarVidaMaxima(cantidadVida);
        CambiarVidaActual(cantidadVida);
        
    }


}
