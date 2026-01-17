using UnityEngine;

public class RayCastingScript : MonoBehaviour
{
    public GameManager gameManager;

    void Update()
    {
        float dirX = Input.GetAxis("Mouse X");
        float dirY = Input.GetAxis("Mouse Y");
        transform.Rotate(dirY, -dirX, 0);

        if (Input.GetMouseButtonDown(0))
        {
            ShootRay();
        }
    }

    void ShootRay()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 50f))
        {
            if (hit.collider.CompareTag("BlackObjects"))
            {
                Destroy(hit.collider.gameObject);
                gameManager.BlackObjectDestroyed();
            }
        }
    }
}
