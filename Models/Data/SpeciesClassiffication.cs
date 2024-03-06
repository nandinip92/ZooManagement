using Microsoft.EntityFrameworkCore.Query;

namespace ZooManagement.Models.Data;
public class SpeciesClassification{
    public required int ClassNumber{get;set;}
    public required string ClassType{get;set;}
    public required string AnimalNames{get;set;}

}