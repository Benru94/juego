using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text contador;
    public static int puntuacion = 0;

    private void Start()
    {
        contador = GetComponent<Text>();
    }

    private void Update()
    {
        contador.text = "Score: " + puntuacion;
    }

}
