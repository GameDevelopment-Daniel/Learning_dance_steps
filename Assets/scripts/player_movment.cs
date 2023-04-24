using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class player_movment : MonoBehaviour
{

    
    [SerializeField]
    InputAction limb = new InputAction(type: InputActionType.Button);

    [SerializeField] int upLimit;
    [SerializeField] int downLimit;


    bool limbMove;
    bool limbUp;

    [SerializeField] int speed;


    void Start()
    {
        limbMove= false;
        limbUp= false;
    }
    public void OnEnable()
    {
        limb.Enable();
    }

    public void OnDisable()
    {
        limb.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (limb.IsPressed()) { limbMove = true; }

        if (limbMove && !limbUp)
        {
            if (transform.eulerAngles.z >= upLimit)
            {
                Debug.Log(transform.eulerAngles.z);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y ,
                                                    transform.eulerAngles.z - Time.deltaTime * speed);

            }
            else
            { 
                limbMove= false;
                limbUp= true;
            }
        }
        if (limbMove && limbUp)
        {
            if (transform.eulerAngles.z <= downLimit)
            {
                Debug.Log(transform.eulerAngles.z);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y,
                                                    transform.eulerAngles.z + Time.deltaTime * speed);
            }
            else
            {
                limbMove = false;
                limbUp = false;
            }
        }

    }
}
