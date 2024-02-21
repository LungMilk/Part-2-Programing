using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class GoalkeerperController : MonoBehaviour
{
    public Rigidbody2D goalKeeperRB;
    public Transform goalControllerTransform;


    Vector2 PlayerPosition;
    public Vector2 direction;
    public float magnitude;
    private void FixedUpdate()
    {
        PlayerPosition = Controller.CurrentSelection.transform.position;
        direction = ((Vector2)goalKeeperRB.transform.position - (Vector2)PlayerPosition).normalized;
        magnitude = ((Vector2)goalKeeperRB.transform.position - (Vector2)PlayerPosition).magnitude;

        goalKeeperRB.MovePosition((Vector2)goalControllerTransform.position + -direction * magnitude / 2);
    }
    
}
