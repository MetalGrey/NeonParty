using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelText : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float textSpeed;
    public string TextFortextComponent;
    void Start()
    {
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in TextFortextComponent)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        textComponent.CrossFadeAlpha(0.0f, 1f, false);
    }
}
