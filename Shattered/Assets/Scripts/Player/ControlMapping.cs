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
    [SerializeField] PauseMenu pauseMenu;


    [SerializeField] VoidEventChannel nextWave_EventChannel;

    [SerializeField] bool canAttack => Camera.main != null;

    //TowerPlacing
    [Header("TowerPlacing")]
    [SerializeField] GameObjectEventChannel openTowerMenu_EventChannel;
    [SerializeField] VoidEventChannel onPlaceTower_EventChannel;
    [SerializeField] VoidEventChannel onExitPlacing_EventChannel;
    [SerializeField] bool isPlacing = false;
    [SerializeField] PlacementPointer placementPosition;

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
        mainPlayerControls.BasicControls.Pause.performed += PauseMenu;
        mainPlayerControls.BasicControls.Attack.performed += OnAttack;
        mainPlayerControls.BasicControls.ChangeCamera.performed += OnChangeCamera;
        mainPlayerControls.PlacingControls.EnterPlacingMode.performed += EnterPlacementMode;

    }

    private void OnDisable()
    {
        mainPlayerControls.Disable();
        mainPlayerControls.BasicControls.Interact.performed -= (InputAction.CallbackContext ctx) => { playerInteractor.Interacted = true; };
        mainPlayerControls.BasicControls.Interact.canceled -= (InputAction.CallbackContext ctx) => { playerInteractor.Interacted = false; };
        mainPlayerControls.BasicControls.NextWave.performed -= (InputAction.CallbackContext ctx) => { nextWave_EventChannel.CallEvent(new()); };
        mainPlayerControls.BasicControls.Restart.performed -= (InputAction.CallbackContext ctx) => { SceneManager.LoadScene(1); };
        mainPlayerControls.BasicControls.Pause.performed -= PauseMenu;
        mainPlayerControls.BasicControls.Attack.performed -= OnAttack;
        mainPlayerControls.BasicControls.ChangeCamera.performed -= OnChangeCamera;
        mainPlayerControls.PlacingControls.EnterPlacingMode.performed -= EnterPlacementMode;
        PlacementDeAssigning();
    }

    void OnChangeCamera(InputAction.CallbackContext ctx)
    {
        GameManager.instance.ChangeCamera();
    }

    void OnAttack(InputAction.CallbackContext ctx)
    {
        if (!canAttack)
        {
            return;
        }
        playerAttack.Attack();
    }

    void EnterPlacementMode(InputAction.CallbackContext ctx)
    {
        if(isPlacing)
        {
            return;
        }

        placementPosition.gameObject.SetActive(true);
        isPlacing = true;
        PlacementAssigning();
        openTowerMenu_EventChannel.CallEvent(new(placementPosition.gameObject));
    }

    void PlaceTower(InputAction.CallbackContext ctx)
    {
        if(!isPlacing)
        {
            return;
        }
        if(!placementPosition.CanPlace)
        {
            return;
        }

        onPlaceTower_EventChannel.CallEvent(new());
        ExitMode();
    }

    void ExitPlacementMode(InputAction.CallbackContext ctx)
    {
        onExitPlacing_EventChannel.CallEvent(new());
        ExitMode();
    }

    void ExitMode()
    {
        if (!isPlacing)
        {
            return;
        }
        isPlacing = false;
        PlacementDeAssigning();
        placementPosition.gameObject.SetActive(false);
    }

    void PlacementAssigning()
    {
        mainPlayerControls.PlacingControls.ExitPlacingMode.performed += ExitPlacementMode;
        mainPlayerControls.PlacingControls.PlaceTower.performed += PlaceTower;

        mainPlayerControls.BasicControls.Pause.performed += Empty;
        mainPlayerControls.BasicControls.Pause.performed -= PauseMenu;
    }

    void PlacementDeAssigning()
    {
        mainPlayerControls.PlacingControls.ExitPlacingMode.performed -= ExitPlacementMode;
        mainPlayerControls.PlacingControls.PlaceTower.performed -= PlaceTower;

        mainPlayerControls.BasicControls.Pause.performed -= Empty;
        mainPlayerControls.BasicControls.Pause.performed += PauseMenu;
    }

    //Temp
    void PauseMenu(InputAction.CallbackContext ctx)
    {
        pauseMenu.Pause();
    }

    void Empty(InputAction.CallbackContext ctx)
    {
        return;
    }
}
