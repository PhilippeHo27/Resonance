/*
 * InputExamples Class
 *
 * This MonoBehaviour class provides examples of how to handle input events using the InputManager. It includes examples of
 * how to use event handlers for the Started, Performed and Canceled events. It also demonstrates how to use methods with
 * different return types and parameters as event handlers.
 * 
 */

using UnityEngine.InputSystem;
using UnityEngine;

public class InputExamples : MonoBehaviour
{
    private int _parameter = 0;
    
    private void Start()
    {
        //To enable map:
        InputManager.Instance.GameControls.AnotherMap.Enable();
        InputManager.Instance.GameControls.Camera.Enable();

        
        //Example for Started Performed and Canceled
        InputManager.Instance.InputActionHandlers["1"].Started += _ => { Debug.Log("Started"); };
        InputManager.Instance.InputActionHandlers["1"].Performed += _ => { Debug.Log("Performed"); };
        InputManager.Instance.InputActionHandlers["1"].Canceled += _ => { Debug.Log("Canceled"); };
    
        //Example with a void method
        InputManager.Instance.InputActionHandlers["2"].Canceled += _ => ExampleOne();
        
        //Example with string method
        InputManager.Instance.InputActionHandlers["T"].Performed += _ =>
        {
            string result = ExampleTwo();
            Debug.Log(result);
        };

        //Example method with a parameter
        InputManager.Instance.InputActionHandlers["F12"].Performed += _ => ExampleThree(_parameter);
        
        //Example for composite movements
        InputManager.Instance.InputActionHandlers["Movements"].Performed += HandleMovement;

    }

    private void OnDisable()
    {
        if (InputManager.Exists)
        {
            InputManager.Instance.GameControls.AnotherMap.Disable();
            InputManager.Instance.GameControls.Camera.Disable();
        }
    }

    private void ExampleOne()
    {
        Debug.Log("Test with void method and no parameter");
    }
    
    private string ExampleTwo()
    {
        return "Test with string method and no parameter";
    }

    private void ExampleThree(int param)
    {
        Debug.Log($"Test with parameter a: {param}");
    }
    
    private void HandleMovement(InputAction.CallbackContext context)
    {
        Vector2 movement = context.ReadValue<Vector2>();
        Debug.Log($"Movement: {movement}");
        Debug.Log($"Context: {context.action}");

        switch (movement)
        {
            case var _ when movement.x < 0:
                Debug.Log($"A key was pressed with value: {movement}");
                break;
            case var _ when movement.x > 0:
                Debug.Log($"D key was pressed with value: {movement}");
                break;
            case var _ when movement.y > 0:
                Debug.Log($"W key was pressed with value: {movement}");
                break;
            case var _ when movement.y < 0:
                Debug.Log($"S key was pressed with value: {movement}");
                break;
        }
    }

}