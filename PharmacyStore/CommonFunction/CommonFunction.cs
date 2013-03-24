using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PharmacyStore
{
    public static class CommonFunction
    {
        public static void CopyProperties(this Object source, Object destination)
        {
            // Iterate the Properties of the destination instance and  
            // populate them from their source counterparts  
            PropertyInfo[] destinationProperties = destination.GetType().GetProperties();
            foreach (PropertyInfo destinationPi in destinationProperties)
            {
                int check = (from p in source.GetType().GetProperties() where p.Name==destinationPi.Name select p).Count();
                if (check > 0)
                {
                    PropertyInfo sourcePi = source.GetType().GetProperty(destinationPi.Name);
                    destinationPi.SetValue(destination, sourcePi.GetValue(source, null), null);
                }
            }
        }
    }
}