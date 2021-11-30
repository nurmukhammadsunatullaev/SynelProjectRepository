using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using BusinessLevel.Interfaces;
using BusinessLevel.Mappers;
using BusinessLevel.Models;
using CsvHelper;

namespace BusinessLevel.Services
{
    public class CSVReaderService : ICSVReaderService
    {
        public IEnumerable<PersonCSVModel> Read(Stream stream)
        {
            try
            {
                using (var csv = new CsvReader(new StreamReader(stream), CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<PersonCSVMapper>();
                    var records = csv.GetRecords<PersonCSVModel>().ToList();
                    return records;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
