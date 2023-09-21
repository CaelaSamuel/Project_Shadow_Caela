using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float distance = 2f;
    [SerializeField] private LayerMask mask;

    private Player_UI playerUI;

    private Input_Manager inputManager;

    private void Start()
    {
        mainCamera = GetComponent<PlayerCamera>().GetCamera;
        playerUI = GetComponent<Player_UI>();
        inputManager = GetComponent<Input_Manager>();
    }

    private void Update()
    {
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction  * distance, UnityEngine.Color.magenta);

        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            Interactable interactable = hitInfo.collider.GetComponent<Interactable>();

            if(interactable != null)
            {
                //interactable.BaseInteraction();
                playerUI.UpdatePromptMessage(interactable.promptMessage);

                if (inputManager.onFootActions.Interact.triggered)
                {
                    interactable.BaseInteraction();
                }
            }
            
        }
        else
        {
            playerUI.UpdatePromptMessage("");
        }
    }
}
