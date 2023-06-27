using UnityEngine;

public class SyringePump : MonoBehaviour
{
    public bool open = false;

    public GameObject meshContainer;

    private Rigidbody rb;
    private Animator meshAnimator;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        meshAnimator = meshContainer.GetComponent<Animator>();

        Sleep();
    }


    public void Open()
    {
        meshAnimator.Play("Open");
        open = true;
    }


    public void Close()
    {
        meshAnimator.Play("Close");
        open = false;
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
