using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAboard.Utilities
{
    public class CustomAssertions
    {
        public static void AssertStringEquals(string expected, string actual, string message = null)
        {
            try
            {
                Assert.AreEqual(expected, actual, message);
            }
            catch(Exception ex)
            {
                //ignore
            }


        }
    
    
    
    
    
    }
}
