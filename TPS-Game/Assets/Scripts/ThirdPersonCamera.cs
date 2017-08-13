using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {
    private readonly string MOUSEX = "Mouse X";
    private readonly string MOUSEY = "Mouse Y";

    //need to follow a player
    [SerializeField]
    [Tooltip("Add the gameobject that the camera will follow in a TPS style")]
    private Transform target;
    [SerializeField]
    [Tooltip("The space that the camera will have with the  gameobject")]
    private float spaceBehindObject;
    [SerializeField]
    private Transform cameraTransform;

    [SerializeField]
    private float verticalSensitivity;

    [SerializeField]
    private float horizontalSensitivity;


    private float angleX;
    private float angleY;

    /// <summary>
    ///     At each update, the camera will place itself behind the player
    ///     and rotate according the mouse movements
    /// </summary>
    private void Update()
    {
        //calculate the camera angle
        float horizontalMove = Input.GetAxis(MOUSEX);
        float verticalMove = Input.GetAxis(MOUSEY);

        angleX += horizontalMove * horizontalSensitivity;
        angleY += (-verticalMove) * verticalSensitivity;

        angleY = Mathf.Clamp(angleY, -80f, 80f);

        //execute the move
        Vector3 direction = new Vector3(0, 0, -spaceBehindObject);
        Quaternion rotation = Quaternion.Euler(angleY, angleX, 0);

        cameraTransform.position = target.position + rotation * direction;
        //the camera must look at the object after it moves
        cameraTransform.LookAt(target);        
    }
}
