using System;
using System.ComponentModel.DataAnnotations;

public class OpenWeatherObject
{
    public int Id { get; set; }
    public OpenWeatherCurrent current {get; set;}
    public DateTime? insertDate { get; set; }
    public DateTime? lastUpdateDate { get; set; }
    public string? city {get; set;}
    public string? country {get; set;}

}