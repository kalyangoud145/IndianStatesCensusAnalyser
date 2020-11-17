using IndianStatesCensusAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStatesCensusAnalyser.POCO
{
    public class CensusDTO
    {
        public int serialNumber;
        public string stateName;
        public string state;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;
        public long housingUnits;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double populationDensity;
        public double housingDensity;

        /// <summary>
        /// constructor to define the necessary attribute for the Indian State census Data.
        /// </summary>
        /// <param name="stateCodeDao">The state code DAO.</param>
        public CensusDTO(StateCodeDAO stateCodeDao)
        {
            this.serialNumber = stateCodeDao.serialNumber;
            this.stateName = stateCodeDao.stateName;
            this.tin = stateCodeDao.tin;
            this.stateCode = stateCodeDao.stateCode;
        }
        /// <summary>
        ///  constructor to define the necessary attribute for the Indian State Code Data
        /// </summary>
        /// <param name="censusDataDao">The census data DAO.</param>
        public CensusDTO(CensusDataDAO censusDataDao)
        {
            this.state = censusDataDao.state;
            this.population = censusDataDao.population;
            this.area = censusDataDao.area;
            this.density = censusDataDao.density;
        }
    }
}
