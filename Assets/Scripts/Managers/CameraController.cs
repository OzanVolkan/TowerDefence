using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float panSpeed = 30f;
    float panBorderThickness = 10f;
    float zLimit = 50f;
    float xLimit = 50f;

    float scrollSpeed = 5f;
    float minY = 10f;
    float maxY = 80f;
    void Update()
    {
        if (GameManager.Instance.IsGameOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            //transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);

            Vector3 translation = Vector3.forward * panSpeed * Time.deltaTime;
            float clampedZ = Mathf.Clamp(transform.position.z + translation.z, -zLimit, zLimit);
            translation.z = clampedZ - transform.position.z;
            transform.Translate(translation, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            //transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);

            Vector3 translation = Vector3.back * panSpeed * Time.deltaTime;
            float clampedZ = Mathf.Clamp(transform.position.z + translation.z, -zLimit, zLimit);
            translation.z = clampedZ - transform.position.z;
            transform.Translate(translation, Space.World);


        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            //transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);

            Vector3 translation = Vector3.right * panSpeed * Time.deltaTime;
            float clampedX = Mathf.Clamp(transform.position.x + translation.x, xLimit / 2f, xLimit);
            translation.x = clampedX - transform.position.x;
            transform.Translate(translation, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            //transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);

            Vector3 translation = Vector3.left * panSpeed * Time.deltaTime;
            float clampedX = Mathf.Clamp(transform.position.x + translation.x, xLimit / 2f, xLimit);
            translation.x = clampedX - transform.position.x;
            transform.Translate(translation, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
