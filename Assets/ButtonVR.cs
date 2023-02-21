using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{

    public GameObject Button;
    public UnityEvent onPress;
    GameObject press;
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
            press = other.gameObject;
            onPress.Invoke();
            Button.GetComponent<Renderer>().material.color = Color.green;
            IsPressed = true;
        }
    }
}
