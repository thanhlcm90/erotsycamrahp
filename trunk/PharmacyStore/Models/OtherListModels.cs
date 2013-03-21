using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PharmacyStore.Models
{
    public static class OtherList
    {
        public static Dictionary<int, string> Gender = new Dictionary<int, string>()
            {
                { 1, "Male"},
                { 2, "Female"}
            };
    }
}