using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AreaNameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private StringValue roomNameValue;
    [SerializeField] private float duration;

    public void ActivateText()
    {
        StartCoroutine(NameCo());
    }

    public IEnumerator NameCo()
    {
        SetText(roomNameValue.value);
        nameText.enabled = true;
        yield return new WaitForSeconds(duration);
        nameText.enabled = false;
    }

    public void SetStringValue(StringValue newText)
    {
        roomNameValue = newText;
    }

    void SetText(string newText)
    {
        nameText.text = newText;
    }

}