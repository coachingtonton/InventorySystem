using UnityEngine;

public class HotBarManager : MonoBehaviour
{
    public Hotbar hotbar;
    private InputCHECKERFUCK inputChecker;

    private void Awake()
    {
        hotbar = new Hotbar();
    }

    private void Start()
    {
        inputChecker = GetComponent<InputCHECKERFUCK>();
    }

    private void Update()
    {
        HandleNumberKeys();
        HandleScrollWheel();
    }

    private void HandleNumberKeys()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectSlot(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SelectSlot(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SelectSlot(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) SelectSlot(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) SelectSlot(4);
        if (Input.GetKeyDown(KeyCode.Alpha6)) SelectSlot(5);
        if (Input.GetKeyDown(KeyCode.Alpha7)) SelectSlot(6);
    }

    private void HandleScrollWheel()
    {

        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
        if (scroll > 0f) SelectSlot((hotbar.selectedIndex - 1 + 7) % 7);
        if (scroll < 0f) SelectSlot((hotbar.selectedIndex + 1) % 7);
    }

    private void SelectSlot(int index)
    {

        hotbar.selectedIndex = index;
        Debug.Log("Selected slot: " + index);
        EventManager.current.TriggerSlotSelected(index);
    }

    public void AssignItemToSlot(Item item, int index)
    {
        hotbar.AssignItem(item, index);
    }
}
