using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudApiWebApp.DTOs
{
    public class dtos
    {
    }

    public class GetByCode
    {
        public string id { get; set; }  //Organization TIN
        public string itemCode { get; set; }  //Object Code
    }

    public class GetByDateRange
    {
        public string id { get; set; }  //Organization TIN
        public string fromDate { get; set; }  //Start Date
        public string toDate { get; set; }  //End Date
        public string source { get; set; }  //End Date
        public string destination { get; set; }  //End Date
    }
}
