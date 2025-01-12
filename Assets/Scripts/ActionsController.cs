using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActionsController : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject role;
    private PlayerInput playerInput;
    private InputAction deltaAction,pressAction,positionAction;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        deltaAction = playerInput.actions["Delta"];
        pressAction = playerInput.actions["Press"];
        positionAction = playerInput.actions["Position"];
    }
    private void OnEnable()
    {

        deltaAction.performed += OnDelta;
        pressAction.performed += OnPress;
    }
    private void OnDisable()
    {
        deltaAction.performed -= OnDelta;
        pressAction.performed -= OnPress;
    }
    void OnDelta(InputAction.CallbackContext ctx)
    {
        Debug.Log(deltaAction.ReadValue<Vector2>());
        //HELPER.OutPutAspectRatio();
        if ((deltaAction.ReadValue<Vector2>().x > 0 && this.transform.position.x < 0) || (deltaAction.ReadValue<Vector2>().x < 0 && this.transform.position.x > 0))
        {
            this.transform.position = new Vector3(-this.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
        //GameManager.Instance.monster.GetComponent<>
        GameManager.Instance.changesprite();
    }
    void OnPress(InputAction.CallbackContext ctx)
    {
        /* Debug.Log(ctx.ReadValue<float>());
         float newspeed = GameManager.Instance.role.GetComponent<Animator>().speed;
         Debug.Log(newspeed);
         newspeed = newspeed + 0.2f;
         GameManager.Instance.role.GetComponent<Animator>().speed=newspeed;*/
        Debug.Log("OnPress");
        //HELPER.OutPutAspectRatio();
        //HELPER.OutPutWorldPosition(GameManager.Instance.cube1,GameManager.Instance.cube2,GameManager.Instance.cube3, GameManager.Instance.cube4);
        //HELPER.OutPutWorldToScreen(GameManager.Instance.cube4, Camera.main);
    }
    void OnPosition(InputAction.CallbackContext ctx)
    {
       /* Debug.Log(ctx.ReadValue<Vector2>());*/
    }
    public void TestEvents()
    {
        GameObject effect = Resources.Load<GameObject>("swordeffect");
        Instantiate(effect,GameManager.Instance.role.transform);
        Debug.Log("events!");
    }

}
