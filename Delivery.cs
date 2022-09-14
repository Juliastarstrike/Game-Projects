using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float DestroyDelay = 0.5f;
    bool hasPackage;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage= true;
            Destroy(other.gameObject, DestroyDelay);
        }
        if (other.CompareTag("Costomer") && hasPackage)
        {
            Debug.Log("Deliverd package");
            hasPackage= false;
        }
    }
}
