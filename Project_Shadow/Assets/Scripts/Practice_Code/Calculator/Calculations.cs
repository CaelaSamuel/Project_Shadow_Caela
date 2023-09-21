using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Calculations : MonoBehaviour
{
    #region References
    public TMP_Text txtAnswer;
    public Button addition;
    public Button subtraction;
    public Button multiplication;
    public Button division;
    public TMP_InputField sumValue1;
    public TMP_InputField sumValue2;
    #endregion

    #region Variables
    private int sum1, sum2, result;
    #endregion

    public void Calculation(string sumType)
    {
        sum1 = Int32.Parse(sumValue1.text);
        sum2 = Int32.Parse(sumValue2.text);

        switch (sumType)
        {
            case "Addition":
                Addition();
                txtAnswer.text = result.ToString();
                break; 
            case "Subtraction":
                Subtraction();
                txtAnswer.text = result.ToString();
                break; 
            case "Multiplication":
                Multiplication();
                txtAnswer.text = result.ToString();
                break;
            case "Division":
                Division();
                txtAnswer.text = result.ToString();
                break;
            default:
                break;
        }

        
    }

    private void Addition()
    {
        result = sum1 + sum2;
    }
    
    private void Subtraction()
    {
        result = sum1 - sum2;
    }
    
    private void Multiplication()
    {
        result = sum1 * sum2;
    }
    
    private void Division()
    {
        if (sum1 <= 0)
            return;
        if (sum2 <= 0)
            return;
        else
            result = sum1 / sum2;
    }
}
