using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFollowCamera : MonoBehaviour
{
    private Camera mainCamera;
    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Convert world position to screen position
        Vector3 screenPos = mainCamera.WorldToScreenPoint(transform.position);

        // Set the position of the TextMeshPro object to the screen position
        rectTransform.position = screenPos;
    }

}
