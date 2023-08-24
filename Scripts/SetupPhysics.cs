using UnityEngine;

public class SetupPhysics : MonoBehaviour
{
    public bool useBoxCollider = true;  // if set to false, will use sphere collider as default
    public bool isKinematic = true;

    void Start()
    {
        // Get all child GameObjects of the current GameObject
        int childCount = transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            SetupGameObjectPhysics(child);
        }
    }

    void SetupGameObjectPhysics(GameObject go)
    {
        Debug.Log(go.name);

        // Check if the object already has a collider
        if (go.GetComponent<Collider>() == null)
        {
            if (useBoxCollider)
            {
                go.AddComponent<BoxCollider>();
            }
            else
            {
                go.AddComponent<SphereCollider>();
            }
        }

        // Check if the object already has a rigidbody
        if (go.GetComponent<Rigidbody>() == null)
        {
            Rigidbody rb = go.AddComponent<Rigidbody>();
            rb.isKinematic = isKinematic;
        }

        // Also process the children of this GameObject
        int childCount = go.transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            SetupGameObjectPhysics(go.transform.GetChild(i).gameObject);
        }
    }
}
