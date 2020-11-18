using IndianStatesCensusAnalyser;
using IndianStatesCensusAnalyser.POCO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStatesCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserUnitTest
{
    public class AnalyserNUnitTest
    {
        /// <summary>
        /// Csv file paths
        /// </summary>
        static readonly string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static readonly string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static readonly string indianStateCensusFilePath = @"C:\Users\Ravula\source\repos\CensusAnalyserUnitTest\CSVFiles\IndiaStateCensusData.csv";
        static readonly string indianStateCodeFilePath = @"C:\Users\Ravula\source\repos\CensusAnalyserUnitTest\CSVFiles\IndiaStateCode.csv";
        static readonly string wrongHeaderIndianStateCensusFilePath = @"C:\Users\Ravula\source\repos\CensusAnalyserUnitTest\CSVFiles\WrongIndiaStateCensusData.csv";
        static readonly string wrongHeaderIndianStateCodeFilePath = @"C:\Users\Ravula\source\repos\CensusAnalyserUnitTest\CSVFiles\WrongIndiaStateCode.csv";
        static readonly string wrongDelimiterIndianStateCensusFilePath = @"C:\Users\Ravula\source\repos\CensusAnalyserUnitTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static readonly string wrongDelimiterIndianStateCodeFilePath = @"C:\Users\Ravula\source\repos\CensusAnalyserUnitTest\CSVFiles\DelimiterIndiaStateCode.csv";
        static readonly string wrongIndianStateCensusFilePath = @"C:\Users\Ravula\source\repos\CensusAnalyserUnitTest\CSVFiles\IndiaData.csv";
        static readonly string wrongIndianStateCodeFilePath = @"C:\Users\Ravula\source\repos\CensusAnalyserUnitTest\CSVFiles\IndiaSteCode.csv";
        static readonly string wrongIndianStateCensusFileType = @"C:\Users\Ravula\source\repos\CensusAnalyserUnitTest\CSVFiles\IndiaStateCensusData.txt";
        static readonly string wrongIndianStateCodeFileType = @"C:\Users\Ravula\source\repos\CensusAnalyserUnitTest\CSVFiles\IndiaStateCode.txt";
        IndianStatesCensusAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        /// <summary>
        /// setup method will excecute every time 
        /// </summary>
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStatesCensusAnalyser.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }
        ///TC 1.1
        /// <summary>
        /// Given proper census data file should return data count
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        ///TC 1.2
        /// <summary>
        /// Given wrong census data file path should return file not found exception
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
        ///TC 1.3
        /// <summary>
        /// Given wrong census data file type should return custom exception invalid file type
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        ///TC 1.4
        /// <summary>
        /// Given  census data file  wrong delimiter should return custom exception incorrect delimiter exception
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongDelimiterIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        ///TC 1.5
        /// <summary>
        /// Given  census data file incorrect headers should return custom exception incorrect delimiter exception
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianStateCensusFilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
        ///TC 2.1
        /// <summary>
        /// Given proper state code data file should return data count
        /// </summary>
        [Test]
        public void GivenIndianStateCodeDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }
        ///TC 2.2
        /// <summary>
        /// Given wrong state code data file path should return file not found exception
        /// </summary>
        [Test]
        public void GivenWrongIndianStateCodeDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
        ///TC 2.3
        /// <summary>
        /// Given wrong state code data file type should return custom exception invalid file type
        /// </summary>
        [Test]
        public void GivenWrongIndianStateCodeFileType_WhenReaded_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }
        ///TC 2.4
        /// <summary>
        /// Given  state code data file  wrong delimiter should return custom exception incorrect delimiter exception
        /// </summary>
        [Test]
        public void GivenIndianStateCodeDataFile_WhenNotProper_ShouldReturnException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongDelimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual("File Contains Wrong Delimiter", stateException.eType);
        }
        ///TC 2.5
        /// <summary>
        /// Given  state code data file incorrect headers should return custom exception incorrect delimiter exception
        /// </summary>
        [Test]
        public void givenIndianStateCodeDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianStateCodeFilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}