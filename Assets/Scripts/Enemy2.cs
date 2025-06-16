using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy2 : MonoBehaviour
{
    public float movementSpeed = 20;
    private Rigidbody eRB;
    private GameObject torre;

    void Start()
    {
        eRB = GetComponent<Rigidbody>();
        torre = GameObject.FindWithTag("Campfire");
    }
    private void FixedUpdate()
    {
        transform.LookAt(torre.transform.position);
        eRB.AddForce((torre.transform.position - transform.position).normalized * movementSpeed);
    }
}
