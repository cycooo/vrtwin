using UnityEngine;

public class Handle : MonoBehaviour
{
    [SerializeField] Rigidbody myRigidBody;


    void Start()
    {
        myRigidBody.Sleep();
    }

    public void WakeUp()
    {
        myRigidBody.WakeUp();
    }
}
