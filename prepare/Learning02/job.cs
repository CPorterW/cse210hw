public class Job(string company, string jobTitle, int startYear, int endYear){
    public string _jobTitle = jobTitle;
    public string _company = company;
    public int _startYear = startYear;
    public int _endYear = endYear;

    public void Display(){
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }

}