using System;
using System.ComponentModel.DataAnnotations;

public class OpenWeatherCurrent
{
    public int Id { get; set; }
    public int feels_like { get; set; }
    public int clouds { get; set; }
    public int humidity { get; set; }
    public long dt { get; set; }
    public long timezone_offset { get; set; }
    public int pressure { get; set; }
    public int temp { get; set; }
    public int uvi { get; set; }
    public int visibility { get; set; }
    public int wind_deg { get; set; }
    public int wind_speed { get; set; }
    public DateTime? insertDate { get; set; }
    public DateTime? lastUpdateDate { get; set; }
    public string? city {get; set;}
    public string? country {get; set;}

}