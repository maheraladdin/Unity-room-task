using UnityEngine;

public class ToolRotation : MonoBehaviour
{
    private Vector3 initialRotation;
    private Quaternion targetRotation;
    private bool isRotating = false;

    void Start()
    {
        initialRotation = transform.eulerAngles;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ???? ??????? ??? ?????
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    isRotating = true;
                    targetRotation = Quaternion.Euler(0, 0, 180); // ????? ????? ??????? ????????
                }
            }
        }

        if (isRotating) // ??? ???????
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 50); // ????? ???????
        }

        if (transform.rotation == targetRotation) // ??? ???????? ?? ???????? ?? ??? ?????? ??????
        {
            isRotating = false;
            targetRotation = Quaternion.Euler(initialRotation);
        }
    }
}
