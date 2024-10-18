using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerMovement))]
public class ControlMapping : MonoBehaviour
{
    MainPlayerControls mainPlayerControls;
    PlayerMovement playerMovement;
    PlayerAttack playerAttack;
    [SerializeField] CameraMovement cameraMovement;
    [SerializeField] PlayerInteractor playerInteractor;
    [SerializeField] VoidEventChannel nextWave_EventChannel;
    [SerializeField] PauseMenu pauseMenu;

    private void Awake()
    {
        mainPlayerControls = new MainPlayerControls();
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        playerMovement.WASDInput = mainPlayerControls.BasicControls.WASD.ReadValue<Vector2>();
        cameraMovement.M_Position = mainPlayerControls.MouseControls.MousePosition.ReadValue<Vector2>();
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        mainPlayerControls.Enable();
        mainPlayerControls.BasicControls.Interact.performed += (InputAction.CallbackContext ctx) => { playerInteractor.Interacted = true; };
        mainPlayerControls.BasicControls.Interact.canceled += (InputAction.CallbackContext ctx) => { playerInteractor.Interacted = false; };
        mainPlayerControls.BasicControls.NextWave.performed += (InputAction.CallbackContext ctx) => { nextWave_EventChannel.CallEvent(new());};
        mainPlayerControls.BasicControls.Restart.performed += (InputAction.CallbackContext ctx) => { SceneManager.LoadScene(1); };
        mainPlayerControls.BasicControls.Pause.performed += (InputAction.CallbackContext ctx) => { pauseMenu.Pause(); };
        mainPlayerControls.BasicControls.Attack.performed += (InputAction.CallbackContext ctx) => { playerAttack.Attack(playerAttack.CameraDirection); };

    }

    private void OnDisable()
    {
        mainPlayerControls.Disable();
        mainPlayerControls.BasicControls.Interact.performed -= (InputAction.CallbackContext ctx) => { playerInteractor.Interacted = true; };
        mainPlayerControls.BasicControls.Interact.canceled -= (InputAction.CallbackContext ctx) => { playerInteractor.Interacted = false; };
        mainPlayerControls.BasicControls.NextWave.performed -= (InputAction.CallbackContext ctx) => { nextWave_EventChannel.CallEvent(new()); };
        mainPlayerControls.BasicControls.Restart.performed -= (InputAction.CallbackContext ctx) => { SceneManager.LoadScene(1); };
        mainPlayerControls.BasicControls.Pause.performed += (InputAction.CallbackContext ctx) => { pauseMenu.Pause(); };
        mainPlayerControls.BasicControls.Attack.performed -= (InputAction.CallbackContext ctx) => { playerAttack.Attack(playerAttack.CameraDirection); };
    }
}
