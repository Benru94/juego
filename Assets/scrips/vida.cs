using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vida : MonoBehaviour
{

    Text vidas;
    public static int totalvidas = 3;

   private void Start()
    {
        
        vidas = GetComponent<Text>();
        
    }
   public void actualizarMarcador()
    {
        totalvidas--;
        vidas.text = "Vida: " + totalvidas;

    }
   

}
