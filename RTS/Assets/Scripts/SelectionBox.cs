using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionBox : MonoBehaviour
{
    public RectTransform selectionBox;
    public RectTransform canvasRectTransform; // Add this
    public LayerMask selectableLayer;
    private Vector2 _startPosition;
    private Rect _selectionRect;
    private Commander _commander;

    private void Awake()
    {
        _commander = GetComponent<Commander>();
    }

    void Update()
    {
        // On mouse button down, record the start position
        if (Input.GetMouseButtonDown(0))
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, Input.mousePosition, null, out _startPosition);
            selectionBox.gameObject.SetActive(true);
        }

        // While holding the mouse button, adjust the box size
        if (Input.GetMouseButton(0))
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, Input.mousePosition, null, out Vector2 localMousePosition))
            {
                UpdateSelectionBox(localMousePosition);
            }
        }

        // On mouse button up, hide the box
        if (Input.GetMouseButtonUp(0))
        {
            ReleaseSelectionBox();
        }
    }

    void UpdateSelectionBox(Vector2 currentMousePosition)
    {
        Vector2 size = currentMousePosition - _startPosition;
        selectionBox.sizeDelta = new Vector2(Mathf.Abs(size.x), Mathf.Abs(size.y));
        selectionBox.anchoredPosition = _startPosition + size / 2;
    }

    void ReleaseSelectionBox()
    {
        selectionBox.gameObject.SetActive(false);
        Vector2 min = selectionBox.anchoredPosition - (selectionBox.sizeDelta / 2);
        Vector2 max = selectionBox.anchoredPosition + (selectionBox.sizeDelta / 2);

        _selectionRect = new Rect(min, selectionBox.sizeDelta);
        SelectObjects();
    }

    void SelectObjects()
    {
        Rect screenRect = new Rect(
            canvasRectTransform.TransformPoint(_selectionRect.position),
            canvasRectTransform.TransformVector(_selectionRect.size)
        );
        foreach (var obj in FindObjectsOfType<GameObject>())
        {
            if (((1 << obj.layer) & selectableLayer) != 0)
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(obj.transform.position);
                if (screenRect.Contains(screenPos, true))
                {
                    foreach (GameObject gameobject in selectionBox)
                    {
                        _commander.addToSelection(gameobject);
                    }
                }
            }
        }
    }
}
