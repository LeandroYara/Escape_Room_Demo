using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{

    public GameObject Button;
    public GameObject Fake_Wall;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            Button.GetComponent<Renderer>().material.color = Color.green;
            Fake_Wall.gameObject.SetActive(false);
            presser = other.gameObject;
            onPress.Invoke();
            isPressed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other == presser)
        {
            Button.GetComponent<Renderer>().material.color = Color.red;
            onRelease.Invoke();
            isPressed = false;
        }
    }
}
