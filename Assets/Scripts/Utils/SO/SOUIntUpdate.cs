using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIntUpdate : MonoBehaviour
{

    public SOInt soInt;
    public TMP_Text uiTextValue;


    void Start()
    {
        uiTextValue.text = soInt.value.ToString();
    }

    
    void Update()
    {
        uiTextValue.text = soInt.value.ToString();
    }
}
