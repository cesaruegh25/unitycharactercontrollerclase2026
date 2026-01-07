using System;
using System.Xml.Linq;
using UnityEngine;

public class CubePingPong : MonoBehaviour
{

        [Header("puntos entre los que se moverá")]
        [SerializeField] private Transform pointA;
        [SerializeField] private Transform pointB;
        [SerializeField] private float velocidad = 2f;
        private GameObject jugador;
        private Transform currentyTarget;
        private bool activo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(pointA == null || pointB == null)
        {
            Debug.LogError("puntos nulos");
            Destroy(this.gameObject);
            return;
        }

        transform.position = pointA.position;
        currentyTarget = pointB;
    }

    // Update is called once per frame
    void Update()
    {

        if (activo)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentyTarget.position, velocidad * Time.deltaTime);
            if(Vector3.Distance(transform.position, currentyTarget.position) < 0.01)
            {
                currentyTarget = (currentyTarget == pointA)? pointB: pointA ;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            jugador = other.gameObject;
            activo = true;
            jugador.transform.parent = transform;
        }
    
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
           activo = false;
           jugador.transform.parent = null;
        }

        
    }
}
