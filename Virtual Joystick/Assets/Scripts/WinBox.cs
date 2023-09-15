using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinBox : MonoBehaviour
{
    Buttons buttons;

    // Start is called before the first frame update
    void Start()
    {
        buttons = FindObjectOfType<Buttons>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Player>())
            buttons.Victory();
    }
}
