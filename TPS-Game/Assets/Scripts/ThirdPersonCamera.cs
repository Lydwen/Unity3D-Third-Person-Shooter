using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {
    //need to follow a player
    [SerializeField]
    [Tooltip("Add the gameobject that the camera will follow in a TPS style")]
    private Transform objectToFollowTransform;
    [SerializeField]
    [Tooltip("The space that the camera will have with the  gameobject")]
    private float spaceBehindObject;
    [SerializeField]
    private Transform cameraTransform;

    /// <summary>
    ///     At each update, the camera will place itself behind the player
    /// </summary>
    private void Update()
    {
        Vector3 objectToFollowPosition = objectToFollowTransform.position;
        Vector3 objectToFollowDirection = objectToFollowTransform.forward;
        Quaternion objectToFollowRotation = objectToFollowTransform.rotation;

        //Put the camera behind the player
        cameraTransform.position = objectToFollowPosition - (objectToFollowDirection * spaceBehindObject);
        //The camera film the player
        cameraTransform.rotation = objectToFollowRotation;
    }
}
