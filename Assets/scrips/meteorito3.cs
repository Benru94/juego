using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))] // para que pueda impactar en los objectos
[RequireComponent(typeof(Rigidbody2D))] // se hace para que tenga cuerpo el ateroide
public class meteorito3 : MonoBehaviour
{
    public Transform pivot;
    public float springRange;
    bool puedeDrag = true;
    public float velMax;

    public float releaseTime = .15f;
    public GameObject siguienteMeteo;
    public GameObject metoactual;
    public vida vida = new vida();


    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; // solo se mueve por script, no le afecta la fisica de unity
        
    }


    Vector3 disparo;
    void OnMouseDrag()
    {
        if (!puedeDrag)
            return;

        var posicion = Camera.main.ScreenToWorldPoint(Input.mousePosition); // cogemos el punto donde estamos tocando la pantalla
        disparo = posicion - pivot.position; //distancia al pivote 
        disparo.z = 0;
        if (disparo.magnitude > springRange)//si arrastramos demasiado lejos
        {
            disparo = disparo.normalized * springRange;
        }
        transform.position = disparo + pivot.position;
    }

    void OnMouseUp()
    {

        if (!puedeDrag)
            return;
        puedeDrag = false; // ya habriamos soltado el asteroide, es innecesario arrastrar

    
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.velocity = -disparo.normalized * velMax * (disparo.magnitude / springRange);
        
        StartCoroutine(Release());
        StartCoroutine(Releas());

    }

    IEnumerator Release()
    {

       
        yield return new WaitForSeconds(2f);
        if (siguienteMeteo != null)
        {
            siguienteMeteo.SetActive(true);
            
        }

        yield return new WaitForSeconds(8f);
        
        metoactual.SetActive(false);
        


    }

    IEnumerator Releas()
    {
        yield return new WaitForSeconds(2f);


        if (metoactual == null && siguienteMeteo == null)
        {

            vida.totalvidas--;
            vida.actualizarMarcador();

        }
    }
   
    



}
