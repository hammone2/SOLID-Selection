using UnityEngine;

public class InteractSelectionResponse : MonoBehaviour, ISelectionResponse
{
    private Transform _selection;
    [SerializeField] private GameObject popup;

    public void OnSelect(Transform selection)
    {
        _selection = selection;
        var outline = selection.GetComponent<Outline>();
        if (outline) outline.OutlineWidth = 2;

        popup.SetActive(true);
    }

    public void OnDeselect(Transform selection)
    {
        var outline = selection.GetComponent<Outline>();
        if (outline) outline.OutlineWidth = 0;
        _selection = null;

        popup.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_selection == null)
                return;

            popup.SetActive(false);
            _selection.gameObject.SetActive(false);
        }
    }
}
