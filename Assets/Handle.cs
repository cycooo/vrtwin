using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : MonoBehaviour
{
    [SerializeField] Rigidbody myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody.Sleep();
        print("???");
    }

    public void WakeUp()
    {
        myRigidBody.WakeUp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
