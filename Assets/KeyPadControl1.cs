using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadControl1 : MonoBehaviour
{
    public int correctCombination = 379;
    public bool accessGranted = false;
    public GameObject puerta;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (accessGranted == true)
        {
            puerta.SetActive(false);
            accessGranted = false;
        }
    }

    public bool CheckIfCorrect(int combination)
    {
        if (correctCombination == combination) 
        {
            accessGranted = true;
            return true;
        }
        return false;
    }
}
