//using UnityEngine;
//using UnityEngine.InputSystem;

//public class PlayerMovement : MonoBehaviour
//{
//    public InputActionProperty moveAction; // Input Action from the controller (e.g., LeftHand Move)
//    public float moveSpeed = 1.0f;

//    private CharacterController characterController;

//    void Start()
//    {
//        characterController = GetComponent<CharacterController>();
//        if (characterController == null)
//        {
//            Debug.LogError("CharacterController component is missing on this GameObject.");
//        }
//    }

//    void Update()
//    {
//        Vector2 input = moveAction.action.ReadValue<Vector2>();
//        Vector3 moveDirection = new Vector3(input.x, 0, input.y);
//        moveDirection = transform.TransformDirection(moveDirection); // Transform to world space

//        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
//    }
//}
