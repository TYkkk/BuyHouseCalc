using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private GameObject mainUIObject;
    private UIManager mainUIManager;

    private float _salePrice;

    public float SalePrice
    {
        get
        {
            return _salePrice;
        }

        set
        {
            if (value < 0)
            {
                value = 0;
            }

            _salePrice = value;
        }
    }

    private float _gsRate;

    public float GsRate
    {
        get
        {
            return _gsRate;
        }

        set
        {
            if (value < 0)
            {
                value = 0;
            }

            _gsRate = value;

            PlayerPrefs.SetFloat(Const.GsRatePrefsKey, value);
        }
    }

    public float _qsRate;

    public float QsRate
    {
        get
        {
            return _qsRate;
        }

        set
        {
            if (value < 0)
            {
                value = 0;
            }

            _qsRate = value;

            PlayerPrefs.SetFloat(Const.QsRatePrefsKey, value);
        }
    }

    public float _zsRate;

    public float ZsRate
    {
        get
        {
            return _zsRate;
        }

        set
        {
            if (value < 0)
            {
                value = 0;
            }

            _zsRate = value;

            PlayerPrefs.SetFloat(Const.ZsRatePrefsKey, value);
        }
    }

    private float _zjRate;

    public float ZjRate
    {
        get
        {
            return _zjRate;
        }

        set
        {
            if (value < 0)
            {
                value = 0;
            }

            _zjRate = value;

            PlayerPrefs.SetFloat(Const.ZjRatePrefsKey, value);
        }
    }

    public float GsRateResult
    {
        get
        {
            return _salePrice * _gsRate;
        }
    }

    public float QsRateResult
    {
        get
        {
            return _salePrice * _qsRate;
        }
    }

    public float ZsRateResult
    {
        get
        {
            return _salePrice * _zsRate;
        }
    }

    public float ZjRateResult
    {
        get
        {
            return _salePrice * _zjRate;
        }
    }

    private float _otherPrict;

    public float OtherPrict
    {
        get
        {
            return _otherPrict;
        }

        set
        {
            if (value < 0)
            {
                value = 0;
            }

            _otherPrict = value;

            PlayerPrefs.SetFloat(Const.OtherPricePrefsKey, value);
        }
    }

    public float OtherAllPrice
    {
        get
        {
            return GsRateResult + QsRateResult + ZsRateResult + ZjRateResult + OtherPrict;
        }
    }

    public float AllPrice
    {
        get
        {
            return OtherAllPrice + _salePrice;
        }
    }

    private float _areaNum = 1;

    public float AreaNum
    {
        get
        {
            return _areaNum;
        }

        set
        {
            if (value <= 0)
            {
                value = 1;
            }

            _areaNum = value;
        }
    }

    public float AreaUnitPrice
    {
        get
        {
            return AllPrice / AreaNum;
        }
    }

    private void Awake()
    {
        _instance = this;

        InitPlayerPrefsData();

        InitUI();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InitPlayerPrefsData()
    {
        _gsRate = PlayerPrefs.GetFloat(Const.GsRatePrefsKey);
        _qsRate = PlayerPrefs.GetFloat(Const.QsRatePrefsKey);
        _zsRate = PlayerPrefs.GetFloat(Const.ZsRatePrefsKey);
        _zjRate = PlayerPrefs.GetFloat(Const.ZjRatePrefsKey);
        _otherPrict = PlayerPrefs.GetFloat(Const.OtherPricePrefsKey);
    }

    private void InitUI()
    {
        string mainUIPath = Const.MainUIPath;

        mainUIObject = Instantiate(Resources.Load(mainUIPath)) as GameObject;

        mainUIManager = mainUIObject.GetComponent<UIManager>();
    }
}
