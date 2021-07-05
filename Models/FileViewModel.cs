using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CsvWebParser.Models
{
    public class FileViewModel
    {
        public HttpPostedFileBase File { get; set; }
        public string Message { get; set; }
    }
}