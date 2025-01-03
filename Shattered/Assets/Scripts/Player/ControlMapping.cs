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
    [SerializeField] VoidEventChannel onDisableDescriptionMenu;
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
        mainPlayerControls.BasicControls.Interact.performed += InteractPeformed;
        mainPlayerControls.BasicControls.Interact.canceled += InteractCanceled;
        mainPlayerControls.BasicControls.NextWave.performed += (InputAction.CallbackContext ctx) => { nextWave_EventChannel.CallEvent(new());};
        mainPlayerControls.BasicControls.Pause.performed += PauseMenu;
        mainPlayerControls.BasicControls.Attack.performed += OnAttack;
        mainPlayerControls.BasicControls.ChangeCamera.performed += OnChangeCamera;
        mainPlayerControls.PlacingControls.EnterPlacingMode.performed += OnOpenPlacementMode;

    }

    private void OnDisable()
    {
        mainPlayerControls.Disable();
        mainPlayerControls.BasicControls.Interact.performed -= InteractPeformed;
        mainPlayerControls.BasicControls.Interact.canceled -= InteractCanceled;
        mainPlayerControls.BasicControls.NextWave.performed -= (InputAction.CallbackContext ctx) => { nextWave_EventChannel.CallEvent(new()); };
        mainPlayerControls.BasicControls.Pause.performed -= PauseMenu;
        mainPlayerControls.BasicControls.Attack.performed -= OnAttack;
        mainPlayerControls.BasicControls.ChangeCamera.performed -= OnChangeCamera;
        mainPlayerControls.PlacingControls.EnterPlacingMode.performed -= OnOpenPlacementMode;
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

    void OnOpenPlacementMode(InputAction.CallbackContext ctx)
    {
        if (isPlacing)
        {
            return;
        }

        openTowerMenu_EventChannel.CallEvent(new(placementPosition.gameObject));
    }

    public void EnterPlacementMode(VoidEvent ctx)
    {
        placementPosition.gameObject.SetActive(true);
        isPlacing = true;
        PlacementAssigning();
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
        onDisableDescriptionMenu.CallEvent(new());
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

    void InteractPeformed(InputAction.CallbackContext ctx)
    {
        playerInteractor.Interacted = true;
    }

    void InteractCanceled(InputAction.CallbackContext ctx)
    {
        playerInteractor.Interacted = false;
    }

    void Empty(InputAction.CallbackContext ctx)
    {
        return;
    }
}
