using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CustomizableSlime
{
    internal class Checks
    {
        public static void AssetsCheck()
        {
            if (!Directory.Exists("CustomizableSlime"))
            {
                Directory.CreateDirectory("CustomizableSlime/Images/");
                File.Create("CustomizableSlime/Images/slime_icon.png");
                File.Create("CustomizableSlime/Images/plort_icon.png");
                throw new IOException("\nCustomizableSlime Folder does not exist! Don't worry, it has been created for you during this error message.");
            }
        }
    }
}
