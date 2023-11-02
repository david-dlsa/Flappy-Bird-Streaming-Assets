using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        // Incrementa a posição horizontal dos canos
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
