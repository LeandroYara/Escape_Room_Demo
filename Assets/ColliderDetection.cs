using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetection : MonoBehaviour
{
    public GameObject FakeWall;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sphere")
        {
            Debug.Log("Se activo el mecanismo");
            FakeWall.SetActive(false);
        }
    }
}
