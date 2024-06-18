using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.EnhancedTouch;
using TMPro;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;
    public TextMeshProUGUI logText;

    Condition Hp { get { return uiCondition.Hp; } }
    Condition Mp { get { return uiCondition.Mp; } }

    // when collision is true
    public float getLarger = 10;
    public float getHeavier = 20;
    public bool isCollision = false;

    private void Start()
    {
        logText.text = "�α� �ۼ���...";
    }

    void Update()
    {
        //Debug.Log(isCollision);

        Hp.Subtract(Hp.passiveValue * Time.deltaTime);

        if (Hp.curValue <= 0.0f)
        {
            GameManager.Instance.GameOver();
        }

        if(isCollision == true)
        {
            Hp.Add(getLarger);
            Mp.Add(getHeavier);
            logText.text = "ũ�Ⱑ 10 �����߽��ϴ�! \n���԰� 20 �����߽��ϴ�!";
            isCollision = false;
        }
    }
}