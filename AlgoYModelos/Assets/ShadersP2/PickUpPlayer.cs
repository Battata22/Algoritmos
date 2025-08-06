using UnityEngine;

public class PickUpPlayer : MonoBehaviour
{

    [SerializeField] float rayDistance;
    [SerializeField] LayerMask layerMask;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance, layerMask) && hit.collider.TryGetComponent<PickUp>(out PickUp pickeable))
            {
                pickeable.PickUp();
                //Debug.Log("Hit: " + hit.collider.gameObject.name);
            }

            if (Physics.Raycast(ray, out hit, rayDistance, 11) && hit.collider.name == "HoldersT")
            {
                PPFinales.instance.PrenderPPGuiso();
            }
        }
    }
}
