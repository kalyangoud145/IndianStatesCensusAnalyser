using IndianStatesCensusAnalyser;
using IndianStatesCensusAnalyser.POCO;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStatesCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserUnitTest
{
    public class NUnitTest
    {
        /// <summary>
        /// Csv file paths
        /// </summary>
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\Ravula\source\repos\CensusAnalyserUnitTest\CSVFiles\IndiaStateCensusData.csv";
        static string indianStateCodeFilePath = @"C:\Users\Ravula\source\repos\CensusAnalyserUnitTest\CSVFiles\IndiaStateCode.csv";
        static string wrongHeaderIndianStateCensusFilePath = @"C:\Users\Ravula\source\repos\CensusAnalyserUnitTest\CSVFiles\WrongIndiaStateCensusData.csv";
        static string wrongHeaderIndianStateCodeFilePath = @"C:\Users\Ravula\source\repos\CensusAnalyserUnitTest\CSVFiles\WrongIndiaStateCode.csv";
        static string wrongDelimiterIndianStateCensusFilePath = @"C:\Users\Ravula\source\repos\CensusAnalyserUnitTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongDelimiterIndianStateCodeFilePath = @"C:\Users\Ravula\source\repos\CensusAnalyserUnitTest\CSVFiles\DelimiterIndiaStateCode.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\Ravula\source\repos\CensusAnalyserUnitTest\CSVFiles\IndiaData.csv";
        static string wrongIndianStateCodeFilePath = @"C:\Users\Ravula\source\repos\CensusAnalyserUnitTest\CSVFiles\IndiaSteCode.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\Ravula\source\repos\CensusAnalyserUnitTest\CSVFiles\IndiaStateCensusData.txt";
        static string wrongIndianStateCodeFileType = @"C:\Users\Ravula\source\repos\CensusAnalyserUnitTest\CSVFiles\IndiaStateCode.txt";
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
            //Act
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            //Assert
            Assert.AreEqual(29, totalRecord.Count);    
        }
        ///TC 1.2
        /// <summary>
        /// Given wrong census data file path should return file not found exception
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            //Act
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders));
            //Assert
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
        ///TC 1.3
        /// <summary>
        /// Given wrong census data file type should return custom exception invalid file type
        /// </summary>
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            //Act
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders));
            //Assert
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        ///TC 1.4
        /// <summary>
        /// Given  census data file  wrong delimiter should return custom exception incorrect delimiter exception
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenNotProper_ShouldReturnException()
        {
            //Act
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongDelimiterIndianStateCensusFilePath, indianStateCensusHeaders));
            //Assert
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        ///TC 1.5
        /// <summary>
        /// Given  census data file incorrect headers should return custom exception incorrect delimiter exception
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            //Act
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianStateCensusFilePath, indianStateCensusHeaders));
            //Assert
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
        ///TC 2.1
        /// <summary>
        /// Given proper state code data file should return data count
        /// </summary>
        [Test]
        public void GivenIndianStateCodeDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            //Act
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            //Assert
            Assert.AreEqual(37, stateRecord.Count);
        }
        ///TC 2.2
        /// <summary>
        /// Given wrong state code data file path should return file not found exception
        /// </summary>
        [Test]
        public void GivenWrongIndianStateCodeDataFile_WhenReaded_ShouldReturnCustomException()
        {
            //Act
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFilePath, indianStateCodeHeaders));
            //Assert
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }
        ///TC 2.3
        /// <summary>
        /// Given wrong state code data file type should return custom exception invalid file type
        /// </summary>
        [Test]
        public void GivenWrongIndianStateCodeFileType_WhenReaded_ShouldReturnCustomException()
        {
            //Act
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders));
            //Assert
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }
        ///TC 2.4
        /// <summary>
        /// Given  state code data file  wrong delimiter should return custom exception incorrect delimiter exception
        /// </summary>
        [Test]
        public void GivenIndianStateCodeDataFile_WhenNotProper_ShouldReturnException()
        {
            //Act
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongDelimiterIndianStateCodeFilePath, indianStateCodeHeaders));
            //Assert
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }
        ///TC 2.5
        /// <summary>
        /// Given  state code data file incorrect headers should return custom exception incorrect delimiter exception
        /// </summary>
        [Test]
        public void givenIndianStateCodeDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            //Act
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianStateCodeFilePath, indianStateCodeHeaders));
            ////Assert
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}