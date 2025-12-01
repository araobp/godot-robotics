using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RobotTest : MonoBehaviour
{

    [SerializeField] Button buttonSwingR;
    [SerializeField] Button buttonSwingL;

    [SerializeField] Button buttonBoomR;
    [SerializeField] Button buttonBoomL;

    [SerializeField] Button buttonArmR;
    [SerializeField] Button buttonArmL;

    [SerializeField] private float rotationSwingSpeed = 100f;
    [SerializeField] GameObject boneSwing;

    [SerializeField] private float rotationBoomSpeed = 100f;
    [SerializeField] GameObject boneBoom;

    [SerializeField] private float rotationArmSpeed = 100f;
    [SerializeField] GameObject boneArm;

    private bool isSwingButtonRPressed = false;
    private bool isSwingButtonLPressed = false;

    private bool isBoomButtonRPressed = false;
    private bool isBoomButtonLPressed = false;

    private bool isArmButtonRPressed = false;
    private bool isArmButtonLPressed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetupButtonEvents(buttonSwingR, (isPressed) => isSwingButtonRPressed = isPressed);
        SetupButtonEvents(buttonSwingL, (isPressed) => isSwingButtonLPressed = isPressed);

        SetupButtonEvents(buttonBoomR, (isPressed) => isBoomButtonRPressed = isPressed);
        SetupButtonEvents(buttonBoomL, (isPressed) => isBoomButtonLPressed = isPressed);

        SetupButtonEvents(buttonArmR, (isPressed) => isArmButtonRPressed = isPressed);
        SetupButtonEvents(buttonArmL, (isPressed) => isArmButtonLPressed = isPressed);
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
