using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using SynelProject.Mappers;
using SynelProject.Models.EntityModels;
using SynelProject.Models.ViewModels;

namespace SynelProject.Services
{
    public class CSVReaderService
    {
        public List<PersonCSVModel> ReadCSVFile(Stream stream)
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
