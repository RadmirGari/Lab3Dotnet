using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CommunityApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
public class City
{
    public int CityId { get; set; }

    [Required]
    public string CityName { get; set; }

    public int Population { get; set; }

    [Required]
    [ForeignKey("Province")]
    public string ProvinceCode { get; set; }


    [ValidateNever]
    public Province Province { get; set; }
}
