using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyDetector : MonoBehaviour
{
    private TextMeshPro display;
    private KeyPadControl1 keyPadControl1;
    // Start is called before the first frame update
    void Start()
    {
        display = GameObject.FindGameObjectWithTag("Display").GetComponentInChildren<TextMeshPro>();
        display.text = "";

        keyPadControl1 = GameObject.FindGameObjectWithTag("Keypad").GetComponent<KeyPadControl1>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KeypadButton"))
        {
            var key = other.GetComponentInChildren<TextMeshPro>();
            if (key != null)
            {
                var KeyFeedBack = other.gameObject.GetComponent<KeyFeedback>();
                if (key.text == "B")
                {
                    if (display.text.Length > 0)
                    {
                        display.text = display.text.Substring(0, display.text.Length - 1);
                    }
                }
                else if (key.text == "C")
                {
                    var accessGranted = false;
                    if (display.text.Length > 0)
                    {
                        accessGranted = keyPadControl1.CheckIfCorrect(Convert.ToInt32(display.text));
                    }

                    if (accessGranted == true)
                    {
                        display.text = "Bien!"; ;
                    }
                    else
                    {
                        display.text = "Error";
                    }
                }
                else
                {
                    bool onlyNumbers = int.TryParse(display.text, out int value);
                    if (onlyNumbers == false)
                    {
                        display.text = "";
                    }
                    if (display.text.Length < 3)
                    {
                        display.text += key.text;
                    }
                }
                KeyFeedBack.keyHit = true;
            }
        }
    }
}
