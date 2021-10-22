

using IndianStateCensusAnalyser.POCO;
using NUnit.Framework;
using System.Collections.Generic;
using Newtonsoft.Json;

using IndianStateCensusAnalyser.DTO;
using IndianStateCensusAnalyser;
using static IndianStateCensusAnalyser.CensusAnalyser;
using System;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\INDIA\Naveen\census\IndianStatesCensusAnalyserProblem\Indian States Census Analyser Problem\CSVFiles\IndiaStateCensusData.csv";
        static string indianStateCodeFilePath = @"C:\Users\INDIA\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.csv";
        static string InvalidCensusDataFilePath = @"C:\Users\INDIA\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndianData.csv";
        static string InvalidStateCodeDataFilePath = @"C:\Users\INDIA\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndianData.csv";
        static string InvalidCensusDataFileType = @"C:\Users\INDIA\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCensusData.txt";
        static string InvalidStateCodeDataFileType = @"C:\Users\INDIA\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\IndiaStateCode.txt";
        static string delimiterIndiancensusFilePath = @"C:\Users\INDIA\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\INDIA\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\DelimiterIndiaStateCode.csv";
        static string wrongHeaderIndianCensusFilePath=  @"C:\Users\INDIA\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCensusData.csv";
        static string wrongHeaderIndianStateCodeFilePath = @"C:\Users\INDIA\source\repos\IndianStateCensusAnalyser\CensusAnalyserTest\CSVFiles\WrongIndiaStateCode.csv";
        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalrecord;
        Dictionary<string, CensusDTO> staterecord;


        [SetUp]
        public void Setup()
        {
           censusAnalyser = new CensusAnalyser();
            totalrecord = new Dictionary<string, CensusDTO>();
            staterecord = new Dictionary<string, CensusDTO>();
        }

     //   TC1.1:- Given the States Census CSV file, Check to ensure the Number of Record matches.
 
         [Test]
        public void GivenIndianCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords() //method count Check to ensure the Number of Record matches 
        {
           totalrecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
         //  staterecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
          Assert.AreEqual(29, totalrecord.Count);
        //   Assert.AreEqual(37, staterecord.Count);
        }

     //  TC1.2:- Given the State Census CSV File if incorrect Returns a custom Exception.
        [Test]
        public void  GivenWrongIndianCensusCSVFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(InvalidCensusDataFilePath, Country.INDIA, indianStateCensusHeaders));
        //    var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(InvalidStateCodeDataFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
         //   Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);

        }
       // TC1.3:- Given the State Census CSV File when correct but type incorrect Returns a custom Exception.

       [Test]
        public void GivenWrongIndianCensusCSVFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(InvalidCensusDataFileType, Country.INDIA, indianStateCensusHeaders));
        //    var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(InvalidStateCodeDataFileType, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
       //     Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);

        }
        //TC1.4:- Given the State Census CSV File when correct but delimiter incorrect Returns a custom Exception.
 
         [Test]
        public void GivenIndianCensusCSVFile_WhenDelimiterNotProper_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndiancensusFilePath, Country.INDIA, indianStateCensusHeaders));
        //    var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER,censusException.eType);
        //    Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);

        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenHeaderNotProper_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
          //  var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
          //  Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);

        }

    }
}