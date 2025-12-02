using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;

public class RobotTest : MonoBehaviour
{

    [SerializeField] Button buttonSwingR;
    [SerializeField] Button buttonSwingL;

    [SerializeField] Button buttonBoomR;
    [SerializeField] Button buttonBoomL;

    [SerializeField] Button buttonArmR;
    [SerializeField] Button buttonArmL;

    [SerializeField] Button buttonHandR;
    [SerializeField] Button buttonHandL;

    [SerializeField] private float rotationSwingSpeed = 100f;
    [SerializeField] GameObject boneSwing;

    [SerializeField] private float rotationBoomSpeed = 100f;
    [SerializeField] GameObject boneBoom;

    [SerializeField] private float rotationArmSpeed = 100f;
    [SerializeField] GameObject boneArm;

    [SerializeField] private float rotationHandSpeed = 100f;
    [SerializeField] GameObject boneHand;

    [SerializeField] Toggle toggleLookDown;

    private bool isSwingButtonRPressed = false;
    private bool isSwingButtonLPressed = false;

    private bool isBoomButtonRPressed = false;
    private bool isBoomButtonLPressed = false;

    private bool isArmButtonRPressed = false;
    private bool isArmButtonLPressed = false;

    private bool isHandButtonRPressed = false;
    private bool isHandButtonLPressed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetupButtonEvents(buttonSwingR, (isPressed) => isSwingButtonRPressed = isPressed);
        SetupButtonEvents(buttonSwingL, (isPressed) => isSwingButtonLPressed = isPressed);

        SetupButtonEvents(buttonBoomR, (isPressed) => isBoomButtonRPressed = isPressed);
        SetupButtonEvents(buttonBoomL, (isPressed) => isBoomButtonLPressed = isPressed);

        SetupButtonEvents(buttonArmR, (isPressed) => isArmButtonRPressed = isPressed);
        SetupButtonEvents(buttonArmL, (isPressed) => isArmButtonLPressed = isPressed);

        SetupButtonEvents(buttonHandR, (isPressed) => isHandButtonRPressed = isPressed);
        SetupButtonEvents(buttonHandL, (isPressed) => isHandButtonLPressed = isPressed);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSwingButtonRPressed)
        {
            boneSwing.transform.Rotate(0f, rotationSwingSpeed * Time.deltaTime, 0f);
        }
        else if (isSwingButtonLPressed)
        {
            boneSwing.transform.Rotate(0f, -rotationSwingSpeed * Time.deltaTime, 0f);
        }

        if (isBoomButtonRPressed)
        {
            boneBoom.transform.Rotate(0f, rotationBoomSpeed * Time.deltaTime, 0f);
        }
        else if (isBoomButtonLPressed)
        {
            boneBoom.transform.Rotate(0f, -rotationBoomSpeed * Time.deltaTime, 0f);
        }

        if (isArmButtonRPressed)
        {
            boneArm.transform.Rotate(0f, -rotationArmSpeed * Time.deltaTime, 0f);
        }
        else if (isArmButtonLPressed)
        {
            boneArm.transform.Rotate(0f, rotationArmSpeed * Time.deltaTime, 0f);
        }

        if (isHandButtonRPressed)
        {
            boneHand.transform.Rotate(0f, rotationHandSpeed * Time.deltaTime, 0f);
        }
        else if (isHandButtonLPressed)
        {
            boneHand.transform.Rotate(0f, -rotationHandSpeed * Time.deltaTime, 0f);
        }

        if (toggleLookDown.isOn)
        {
            makeHandLookDown();            
        }
    }

    void makeHandLookDown()
    {

        Transform parentTransform = boneHand.transform.parent;
        // Get the parent's world-space right axis
        Vector3 parentRight = parentTransform.right;

        // Define the desired forward direction in world space (pointing straight up)
        Vector3 worldUpward = Vector3.up;

        // Calculate the target world rotation. This rotation orients the boneHand so that its
        // forward vector points upwards (worldUpward), and its up vector aligns with its
        // parent's right vector.
        Quaternion targetWorldRotation = Quaternion.LookRotation(worldUpward, parentRight);

        // Convert the world rotation to local rotation relative to the parent
        boneHand.transform.localRotation = Quaternion.Inverse(parentTransform.rotation) * targetWorldRotation;
    }

    private void SetupButtonEvents(Button button, System.Action<bool> setPressedState)
    {
        EventTrigger trigger = button.gameObject.GetComponent<EventTrigger>() ?? button.gameObject.AddComponent<EventTrigger>();

        var pointerDown = new EventTrigger.Entry { eventID = EventTriggerType.PointerDown };
        pointerDown.callback.AddListener((e) => setPressedState(true));
        trigger.triggers.Add(pointerDown);

        var pointerUp = new EventTrigger.Entry { eventID = EventTriggerType.PointerUp };
        pointerUp.callback.AddListener((e) => setPressedState(false));
        trigger.triggers.Add(pointerUp);
    }

    public void onButtonSwingPressed()
    {
        Debug.Log("Swing Clicked");
    }

}
