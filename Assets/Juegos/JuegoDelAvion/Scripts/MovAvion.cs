using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovAvion : MonoBehaviour
{
    private float velocidad = 5f;
    private Vector3 posicionObjetivo;

    // Start is called before the first frame update
    void Start()
    {
        posicionObjetivo = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            posicionObjetivo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posicionObjetivo.z = this.transform.position.z;
            posicionObjetivo.x = this.transform.position.x;
        }
        this.transform.position =
            Vector3.MoveTowards(current: this.transform.position, target: posicionObjetivo, maxDistanceDelta: velocidad * Time.deltaTime);
    }
}
