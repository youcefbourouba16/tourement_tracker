using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourament_library.Models
{
    public class PrizeModel
    {
        public PrizeModel(string placeNumber, string placeName, string prizePercentage, string prizeAmount)
        {
            this.placeName = placeName;

            int placeNumberValue;
            int.TryParse(placeNumber, out placeNumberValue);
            this.placeNumber = placeNumberValue;

            double prizePercentageValue;
            double.TryParse(prizePercentage, out prizePercentageValue);

            this.prizePercentage = prizePercentageValue;

            decimal prizeAmountValue;
            decimal.TryParse(prizeAmount, out prizeAmountValue);
            this.prizeAmount = prizeAmountValue;
        }
        public PrizeModel()
        {

        }

        public int id { get; set; }
        public int placeNumber { get; set; }
        public string placeName { get; set; }
        public double prizePercentage { get; set; }
        public decimal prizeAmount { get; set; }
    }
}
