using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TextPopup : MonoBehaviour
{
    private TextMeshPro textMesh;

    void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    public static TextPopup CreateDamagePopup(Vector3 pos, float damageAmount)
    {
        Transform popupTextInstance = Instantiate(GameInstance.Instance.popupText, pos, Quaternion.identity);
        TextPopup textPopup = popupTextInstance.GetComponent<TextPopup>();
        textPopup.SetupDamage(pos, damageAmount);

        return textPopup;
    }


    public static TextPopup CreateHealPopup(Vector3 pos, float healAmount)
    {
        Transform popupTextInstance = Instantiate(GameInstance.Instance.popupText, pos + GetRandPos(1f), Quaternion.identity);
        TextPopup textPopup = popupTextInstance.GetComponent<TextPopup>();
        textPopup.SetupHeal(pos, healAmount);

        return textPopup;
    }

    public void SetupDamage(Vector3 pos, float damageAmount)
    {
        textMesh.SetText(damageAmount.ToString("F1"));

        textMesh.color = Color.yellow;

        transform.DOJump(pos + new Vector3(Random.Range(-2, 2), 0, 0), 1, 1, 1.5f);

        transform.DOScale(Vector3.zero, 2.5f);

        textMesh.DOFade(0, 1.5f).OnComplete(() => Destroy(gameObject)); 
    }


    public void SetupHeal(Vector3 pos, float healAmount)
    {
        textMesh.SetText(healAmount.ToString("F1"));

        transform.DOMove(pos + Vector3.up * 2, 2f).SetEase(Ease.InOutSine);

        transform.DOScale(Vector3.zero, 1.5f);

        textMesh.DOFade(0, 1.5f).OnComplete(() => Destroy(gameObject));
    }

    public static Vector3 GetRandPos(float coef)
    {
        return new Vector3(Random.Range(-coef, coef), Random.Range(-coef, coef), 0);
    }
    
}
