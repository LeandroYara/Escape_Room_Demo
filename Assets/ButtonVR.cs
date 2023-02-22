using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{

    public GameObject Button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    bool IsPressed;
    // Start is called before the first frame update
    void Start()
    {
        IsPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsPressed)
        {
            Button.transform.localPosition= new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
            Button.GetComponent<Renderer>().material.color = Color.green;
            presser = other.gameObject;
            onPress.Invoke();
            IsPressed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == presser)
        {
            Button.transform.localPosition = new Vector3(transform.position.x, transform.position.y + 0.01f, transform.position.z);
            Button.GetComponent<Renderer>().material.color = Color.red;
            onRelease.Invoke();
            IsPressed   = false;
        }
    }
}
