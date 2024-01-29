using Assets.Scripts;

using UnityEngine;
using UnityEngine.InputSystem;


public class StoreMenuController : MonoBehaviour
{
    [SerializeField]
    public InputActionReference buttonPressAction;
    public GameObject menu;

    private void OnEnable()
    {
        buttonPressAction.action.performed += MenuToggle;
        buttonPressAction.action.Enable();
    }

    private void OnDisable()
    {
        buttonPressAction.action.performed -= MenuToggle;
        buttonPressAction.action.Disable();
    }


    private void MenuToggle(InputAction.CallbackContext context)
    {
        if (menu.activeInHierarchy)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
        }
    }
}
