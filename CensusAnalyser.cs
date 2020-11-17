using IndianStatesCensusAnalyser.POCO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndianStatesCensusAnalyser
{
    public class CensusAnalyser
    {
        // Enum for  creating instance of multiple countries.
        public enum Country
        {
            INDIA,
            US,
        }
        // Dictionary to store the data from the CSV files
        Dictionary<string, CensusDTO> dataMap;
        /// <summary>
        /// Function to load the data from Csv files and retuns data map
        /// </summary>
        /// <param name="country">The country.</param>
        /// <param name="csvFilePath">The CSV file path.</param>
        /// <param name="dataHeaders">The data headers.</param>
        /// <returns></returns>
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
    }
}
