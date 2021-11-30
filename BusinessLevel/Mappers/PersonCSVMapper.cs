using System.Globalization;
using BusinessLevel.Models;
using CsvHelper.Configuration;

namespace BusinessLevel.Mappers
{
    public sealed class PersonCSVMapper: ClassMap<PersonCSVModel>
    {
        public PersonCSVMapper()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(x => x.Payroll_Number).Name("Personnel_Records.Payroll_Number");
            Map(x => x.Forenames).Name("Personnel_Records.Forenames");
            Map(x => x.Surname).Name("Personnel_Records.Surname");
            Map(x => x.Date_of_Birth).Name("Personnel_Records.Date_of_Birth");
            Map(x => x.Telephone).Name("Personnel_Records.Telephone");
            Map(x => x.Mobile).Name("Personnel_Records.Mobile");
            Map(x => x.Address).Name("Personnel_Records.Address");
            Map(x => x.Address_2).Name("Personnel_Records.Address_2");
            Map(x => x.Postcode).Name("Personnel_Records.Postcode");
            Map(x => x.Date_of_Birth).Name("Personnel_Records.Date_of_Birth");
            Map(x => x.EMail_Home).Name("Personnel_Records.EMail_Home");
            Map(x => x.Start_Date).Name("Personnel_Records.Start_Date");
        }
    }
}
