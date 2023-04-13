using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Blank : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI chatBox;

    public void MakeBlanked()
    {
        chatBox.text = "...";
    }
}
