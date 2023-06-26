using UnityEngine;

public class RackPosition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("SyringePump"))
        {
            other.gameObject.transform.position = transform.position;
            other.gameObject.transform.rotation = transform.rotation;

            other.gameObject.GetComponent<SyringePump>().Sleep();
        }
    }
}
