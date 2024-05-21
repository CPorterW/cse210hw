class Fraction{
    private double _topNum;
    private double _bottomNum;

#region Constructors
    public Fraction (){
        _topNum = 1;
        _bottomNum = 1;
    }

    public Fraction (double topNum){
        _topNum = topNum;
        _bottomNum = 1;
    }

    public Fraction (double topNum, double bottomNum){
        _topNum = topNum;
        _bottomNum = bottomNum;
    }
#endregion

#region CRUD
    public double GetTopNum(){
        return _topNum;
    }

    public double GetBottomNum(){
        return _bottomNum;
    }

    public void SetTopNum(double topNum){
        _topNum = topNum;
    }

    public void SetBottomNum(double bottomNum){
        _bottomNum = bottomNum;
    }
#endregion

#region Methods
    public string GetFractionString(){
        return $"{_topNum}/{_bottomNum}";
    }

    public double GetDecimalValue(){
        return _topNum/_bottomNum;
    }
#endregion
}