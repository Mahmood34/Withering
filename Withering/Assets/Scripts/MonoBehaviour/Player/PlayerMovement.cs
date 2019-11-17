using System.Collections;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator animator;
    public NavMeshAgent agent;
    public float velocity = 5;
    public float turnSpeed = 10;
    public Interactable focus;
    Vector2 input;
    float angle;
    Quaternion targetRotation;
    public SceneChange sceneChanger;
    
    // Start is called before the first frame update
    void Start()
    {
        // agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * 5, Color.green);


        if (Physics.Raycast(ray, out hit, 5) && Input.GetKeyDown(KeyCode.F))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                SetFocus(interactable);
                sceneChanger.TestScene();
            }
        }
        else
        {
            RemoveFocus();
        }

        GetInput();
        if (Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1) return;
        CalculateDirection();
        Rotate();
        Move();

    }

    public void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
                focus.onDeFocused();

            focus = newFocus;
        }

        newFocus.OnFocused();

    }

    public void RemoveFocus()
    {
        if (focus != null)
            focus.onDeFocused();

        focus = null;

    }

    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    void CalculateDirection()
    {
        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle;
    }

    void Rotate()
    {
        targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    void Move()
    {
        transform.position += transform.forward * velocity * Time.deltaTime;
    }
}
