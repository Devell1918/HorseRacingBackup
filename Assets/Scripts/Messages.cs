using TMPro;
using UnityEngine;

public class Messages : MonoBehaviour
{
    private TextMeshProUGUI TMP;

    private void Awake()
    {
        TMP = GetComponent<TextMeshProUGUI>();
    }
    public void SetMessage(string message)
    {
        TMP.text = message;
    }
}
