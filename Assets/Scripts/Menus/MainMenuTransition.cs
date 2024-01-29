using Assets.Scripts;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenuTransition : MonoBehaviour
{
    [SerializeField]
    public InputActionReference buttonPressAction;

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
        SceneManager.LoadSceneAsync(0);
    }

}
