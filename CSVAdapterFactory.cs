using IndianStatesCensusAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStatesCensusAnalyser
{
    /// <summary>
    /// method Load Csv Data return the mapped dictionary loaded from the Csv File
    /// else throw the exception
    /// </summary>
    /// <param name="country"></param>
    /// <param name="csvFilePath"></param>
    /// <param name="dataHeaders"></param>
    public class CSVAdapterFactory
    {
        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string dataHeaders)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
                default:
                    throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }
}
