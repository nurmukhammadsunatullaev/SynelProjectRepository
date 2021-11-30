using System;
using System.Collections.Generic;
using System.IO;
using BusinessLevel.Models;

namespace BusinessLevel.Interfaces
{
    public interface ICSVReaderService
    {
        public IEnumerable<PersonCSVModel> Read(Stream stream);
    }
}
