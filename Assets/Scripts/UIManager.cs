using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public InputField InputDec;
    public InputField InputDecUnitW;

    public InputField InputArea;

    public InputField InputGsRate;
    public InputField InputQsRate;
    public InputField InputZsRate;
    public InputField InputZjRate;
    public InputField InputOtherPrice;

    public Text GsResultText;
    public Text QsResultText;
    public Text ZsResultText;
    public Text ZjResultText;
    public Text OtherAllResultText;
    public Text AllResultText;
    public Text AreaUnitPrice;

    private void Awake()
    {
        InputDec.onEndEdit.AddListener(InputDecOnEndEditEventHandler);
        InputDecUnitW.onEndEdit.AddListener(InputDecUnitWOnEndEditEventHandler);

        SetInputRateTextData(GameManager.Instance.GsRate, InputGsRate);
        SetInputRateTextData(GameManager.Instance.QsRate, InputQsRate);
        SetInputRateTextData(GameManager.Instance.ZsRate, InputZsRate);
        SetInputRateTextData(GameManager.Instance.ZjRate, InputZjRate);
        SetInputRateTextData(GameManager.Instance.OtherPrict, InputOtherPrice, false);

        InputArea.onEndEdit.AddListener(InputAreaOnEndEditEventHandler);

        InputGsRate.onEndEdit.AddListener(InputGsRateOnEndEditEventHandler);
        InputQsRate.onEndEdit.AddListener(InputQsRateOnEndEditEventHandler);
        InputZsRate.onEndEdit.AddListener(InputZsRateOnEndEditEventHandler);
        InputZjRate.onEndEdit.AddListener(InputZjRateOnEndEditEventHandler);
        InputOtherPrice.onEndEdit.AddListener(InputOtherPriceOnEndEditEventHandler);

        UpdateAllRateResult();
    }

    private void SetInputRateTextData(float value, InputField target, bool usePercentage = true)
    {
        if (value == 0)
        {
            target.text = "";
        }
        else
        {
            if (usePercentage)
            {
                target.text = (value * Const.PercentageValue).ToString();
            }
            else
            {
                target.text = value.ToString();
            }
        }
    }

    private void InputAreaOnEndEditEventHandler(string content)
    {
        GameManager.Instance.AreaNum = ConvertInputContentToFloat(content);

        UpdateAreaUnitPriceResult();
    }

    private void InputOtherPriceOnEndEditEventHandler(string content)
    {
        GameManager.Instance.OtherPrict = ConvertInputContentToFloat(content);

        UpdateOtherAllResult();
    }

    private void InputGsRateOnEndEditEventHandler(string content)
    {
        GameManager.Instance.GsRate = ConvertInputContentToFloat(content) / Const.PercentageValue;

        UpdateGsRateResult();

        UpdateOtherAllResult();
    }

    private void InputQsRateOnEndEditEventHandler(string content)
    {
        GameManager.Instance.QsRate = ConvertInputContentToFloat(content) / Const.PercentageValue;

        UpdateQsRateResult();

        UpdateOtherAllResult();
    }

    private void InputZsRateOnEndEditEventHandler(string content)
    {
        GameManager.Instance.ZsRate = ConvertInputContentToFloat(content) / Const.PercentageValue;

        UpdateZsRateResult();

        UpdateOtherAllResult();
    }

    private void InputZjRateOnEndEditEventHandler(string content)
    {
        GameManager.Instance.ZjRate = ConvertInputContentToFloat(content) / Const.PercentageValue;

        UpdateZjRateResult();

        UpdateOtherAllResult();
    }

    private void InputDecOnEndEditEventHandler(string content)
    {
        UpdateInputContent(ConvertInputContentToFloat(content));
    }

    private void InputDecUnitWOnEndEditEventHandler(string content)
    {
        UpdateInputContent(ConvertInputContentToFloat(content) * Const.UnitNum);
    }

    private float ConvertInputContentToFloat(string content)
    {
        float.TryParse(content, out float result);

        return result;
    }

    private void UpdateInputContent(float value)
    {
        GameManager.Instance.SalePrice = value;

        InputDec.text = GameManager.Instance.SalePrice.ToString();

        InputDecUnitW.text = (GameManager.Instance.SalePrice / Const.UnitNum).ToString();

        UpdateAllRateResult();
    }

    private void UpdateAllRateResult()
    {
        UpdateGsRateResult();
        UpdateQsRateResult();
        UpdateZsRateResult();
        UpdateZjRateResult();

        UpdateOtherAllResult();
    }

    private void UpdateGsRateResult()
    {
        GsResultText.text = GameManager.Instance.GsRateResult.ToString();
    }

    private void UpdateQsRateResult()
    {
        QsResultText.text = GameManager.Instance.QsRateResult.ToString();
    }

    private void UpdateZsRateResult()
    {
        ZsResultText.text = GameManager.Instance.ZsRateResult.ToString();
    }

    private void UpdateZjRateResult()
    {
        ZjResultText.text = GameManager.Instance.ZjRateResult.ToString();
    }

    private void UpdateOtherAllResult()
    {
        OtherAllResultText.text = GameManager.Instance.OtherAllPrice.ToString();

        UpdateAllResult();
    }

    private void UpdateAllResult()
    {
        AllResultText.text = GameManager.Instance.AllPrice.ToString();

        UpdateAreaUnitPriceResult();
    }

    private void UpdateAreaUnitPriceResult()
    {
        AreaUnitPrice.text = GameManager.Instance.AreaUnitPrice.ToString();
    }
}
