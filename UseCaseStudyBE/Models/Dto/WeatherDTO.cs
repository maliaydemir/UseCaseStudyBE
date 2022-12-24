namespace UseCaseStudyBE.Models.Dto;

public class WeatherDTO
{
    public string date { get; set; }
    public string day { get; set; }
    public string icon { get; set; }
    public string description { get; set; }
    public string status { get; set; }
    public string degree { get; set; }
    public string min { get; set; }
    public string max { get; set; }
    public string night { get; set; }
    public string humidity { get; set; }

    public DateTime? ParsedDate
    {
        get
        {
            var tmp = date.Split('.');
            return DateTime.Parse(tmp[2]+"-"+tmp[1]+"-"+tmp[0]);
        }
    }
}

public class WeatherApiResult
{
    public List<WeatherDTO> result { get; set; }
}