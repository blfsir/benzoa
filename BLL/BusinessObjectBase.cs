using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;

using System.Reflection;

namespace BLL
{
    public class BusinessObjectBase
    {
        protected static ResourceManager ResourceManager = new ResourceManager(typeof(BusinessObjectBase).Namespace + ".BOText", Assembly.GetExecutingAssembly());
         
    }
}
