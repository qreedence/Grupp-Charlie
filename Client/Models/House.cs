using Microsoft.AspNetCore.Components;

namespace Client.Models
{
    public class House
    {
       
        public int HouseId { get; set; }
        public Category Category { get; set; }
        public string Adress { get; set; }
        public County County { get; set; }
        public int Price { get; set; }
        public int LivingArea { get; set; }
        public int AuxiliaryArea { get; set; }
        public int PlotArea { get; set; }
        public string Description { get; set; }
        public int NumberOfRooms { get; set; }
        public int MonthlyFee { get; set; }
        public int OperatingCostPerYear { get; set; }
        public int YearOfConstruction { get; set; }
        public List<Image> Gallery {  get; set; }
        public Realtor Realtor { get; set; }
        public Municipality Municipality { get; set; }
        //public Agency Agency { get; set; } 


    }
}
