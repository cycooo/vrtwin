using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringePump : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        Sleep();
    }

    public void WakeUp()
    {
        rb.isKinematic = false;
    }

    public void Sleep()
    { 
        rb.isKinematic = true;
    }
}
