using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecyclingStation.BusinestLayer.Data
{
    using RecyclingStation.WasteDisposal.Interfaces;

   public class ProcesingData:IProcessingData
    {
        private  double energyBalance;
        private  double capitalBalance;

        public ProcesingData(double energyBalance, double capitalBalance)
        {
            this.EnergyBalance = energyBalance;
            this.CapitalBalance = capitalBalance;
        }

        public double EnergyBalance
        {
            get { return this.energyBalance; }
            set { this.energyBalance = value; }
        }

        public double CapitalBalance
        {
            get { return this.capitalBalance; }
            set { this.capitalBalance = value; }
        }
    }
}
