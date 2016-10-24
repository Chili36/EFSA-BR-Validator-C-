using EfsaBusinessRuleValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ValidateEfsaXml
{
    class Program
    {
        static void Main(string[] args)
        {

            //Boilerplate for file
            var xmlfil = @"C:\Dev\EFSA_Xml\rapport (2)_wf2.xml"; //<---- Ange sökväg till xml-file här.
            var xml = XDocument.Load(xmlfil);

            var samples = XDocument.Load(@xmlfil).Descendants("result"); //Använder Workflow 2
            var tests = new List<Outcome>();

            var validator = new Validator();

            

            var br01a = validator.BR01A(samples.First());
            Console.WriteLine("BRO1A {0}", br01a.passed ? "PASSED": "FAILED");
            var br02a_01 = validator.BR02A_01(samples.First());
            Console.WriteLine("BR02A_01 {0}", br02a_01.passed ? "PASSED" : "FAILED");
            var br02a_02 = validator.BR02A_02(samples.First());
            Console.WriteLine("BR02A_02 {0}", br02a_02.passed ? "PASSED" : "FAILED");
            var br02a_03 = validator.BR02A_03(samples.First());
            Console.WriteLine("BR02A_03 {0}", br02a_03.passed ? "PASSED" : "FAILED");
            var br02a_04 = validator.BR02A_04(samples.First());
            Console.WriteLine("BR02A_04 {0}", br02a_04.passed ? "PASSED" : "FAILED");
            var br02a_05 = validator.BR02A_05(samples.First());
            Console.WriteLine("BR02A_05 {0}", br02a_05.passed ? "PASSED" : "FAILED");
            var br02a_06 = validator.BR02A_06(samples.First());
            Console.WriteLine("BR02A_06 {0}", br02a_06.passed ? "PASSED" : "FAILED");
            var br02a_07 = validator.BR02A_07(samples.First());
            Console.WriteLine("BR02A_07 {0}", br02a_07.passed ? "PASSED" : "FAILED");
            var br03a_01 = validator.BR03A_01(samples.First());
            Console.WriteLine("BR03A_01 {0}", br03a_01.passed ? "PASSED" : "FAILED");
            var br03a_02 = validator.BR03A_02(samples.First());
            Console.WriteLine("BR03A_02 {0}", br03a_02.passed ? "PASSED" : "FAILED");
            var br03a_03 = validator.BR03A_03(samples.First());
            Console.WriteLine("BR03A_03 {0}", br03a_03.passed ? "PASSED" : "FAILED");
            var br03a_04 = validator.BR03A_04(samples.First());
            Console.WriteLine("BR03A_04 {0}", br03a_04.passed ? "PASSED" : "FAILED");
            var br03a_05 = validator.BR03A_05(samples.First());
            Console.WriteLine("BR03A_05 {0}", br03a_05.passed ? "PASSED" : "FAILED");
            var br03a_06 = validator.BR03A_06(samples.First());
            Console.WriteLine("BR03A_06 {0}", br03a_06.passed ? "PASSED" : "FAILED");
            var br03a_07 = validator.BR03A_07(samples.First());
            Console.WriteLine("BR03A_07 {0}", br03a_07.passed ? "PASSED" : "FAILED");
            var br03a_08 = validator.BR03A_08(samples.First());
            Console.WriteLine("BR03A_08 {0}", br03a_08.passed ? "PASSED" : "FAILED");
            var br03a_09 = validator.BR03A_09(samples.First());
            Console.WriteLine("BR03A_09 {0}", br03a_09.passed ? "PASSED" : "FAILED");
            var br03a_10 = validator.BR03A_10(samples.First());
            Console.WriteLine("BR03A_10 {0}", br03a_10.passed ? "PASSED" : "FAILED");
            var br03a_11 = validator.BR03A_11(samples.First());
            Console.WriteLine("BR03A_11 {0}", br03a_11.passed ? "PASSED" : "FAILED");
            var br03a_12 = validator.BR03A_12(samples.First());
            Console.WriteLine("BR03A_12 {0}", br03a_12.passed ? "PASSED" : "FAILED");
            var br08a_05 = validator.BR08A_05(samples.First());
            Console.WriteLine("BR08A_05 {0}", br08a_05.passed ? "PASSED" : "FAILED");
            var br09a_09 = validator.BR09A_09(samples.First());
            Console.WriteLine("BR09A_09 {0}", br09a_09.passed ? "PASSED" : "FAILED");
            var br12a_01 = validator.BR12A_01(samples.First());
            Console.WriteLine("BR12A_01 {0}", br12a_01.passed ? "PASSED" : "FAILED");
            var pest01 = validator.PEST01(samples.First());
            /*
            Console.WriteLine("PEST01 {0}", pest01.passed ? "PASSED" : "FAILED");
            var pest02 = validator.PEST02(samples.First());
            Console.WriteLine("PEST02 {0}", pest02.passed ? "PASSED" : "FAILED");
            var pest03 = validator.PEST03(samples.First());
            Console.WriteLine("PEST03 {0}", pest03.passed ? "PASSED" : "FAILED");
            var pest04 = validator.PEST04(samples.First());
            Console.WriteLine("PEST04 {0}", pest04.passed ? "PASSED" : "FAILED");
            var pest05 = validator.PEST05(samples.First());
            Console.WriteLine("PEST05 {0}", pest05.passed ? "PASSED" : "FAILED");
            var pest06 = validator.PEST06(samples.First());
            Console.WriteLine("PEST06 {0}", pest06.passed ? "PASSED" : "FAILED");
            var pest07 = validator.PEST07(samples.First());
            Console.WriteLine("PEST07 {0}", pest07.passed ? "PASSED" : "FAILED");
            var pest08 = validator.PEST08(samples.First());
            Console.WriteLine("PEST08 {0}", pest08.passed ? "PASSED" : "FAILED");
            var pest09 = validator.PEST09(samples.First());
            Console.WriteLine("PEST09 {0}", pest09.passed ? "PASSED" : "FAILED");
            var pest10 = validator.PEST10(samples.First());
            Console.WriteLine("PEST10 {0}", pest10.passed ? "PASSED" : "FAILED");
            var pest11 = validator.PEST11(samples.First());
            Console.WriteLine("PEST11 {0}", pest11.passed ? "PASSED" : "FAILED");
            var pest12 = validator.PEST12(samples.First());
            Console.WriteLine("PEST12 {0}", pest12.passed ? "PASSED" : "FAILED");
            var pest13 = validator.PEST13(samples.First());
            Console.WriteLine("PEST13 {0}", pest13.passed ? "PASSED" : "FAILED");
            var pest14 = validator.PEST14(samples.First());
            Console.WriteLine("PEST14 {0}", pest14.passed ? "PASSED" : "FAILED");
            var pest15 = validator.PEST15(samples.First());
            Console.WriteLine("PEST15 {0}", pest15.passed ? "PASSED" : "FAILED");
            var pest16 = validator.PEST16(samples.First());
            Console.WriteLine("PEST16 {0}", pest16.passed ? "PASSED" : "FAILED");
            var pest17 = validator.PEST17(samples.First());
            Console.WriteLine("PEST17 {0}", pest17.passed ? "PASSED" : "FAILED");
            var pest18 = validator.PEST18(samples.First());
            Console.WriteLine("PEST18 {0}", pest18.passed ? "PASSED" : "FAILED");
            var pest19 = validator.PEST19(samples.First());
            Console.WriteLine("PEST19 {0}", pest19.passed ? "PASSED" : "FAILED");
            var pest20 = validator.PEST20(samples.First());
            Console.WriteLine("PEST20 {0}", pest20.passed ? "PASSED" : "FAILED");
            var pest21 = validator.PEST21(samples.First());
            Console.WriteLine("PEST21 {0}", pest21.passed ? "PASSED" : "FAILED");
            var pest22 = validator.PEST22(samples.First());
            Console.WriteLine("PEST22 {0}", pest22.passed ? "PASSED" : "FAILED");
            var pest23 = validator.PEST23(samples.First());
            Console.WriteLine("PEST23 {0}", pest23.passed ? "PASSED" : "FAILED");
            var pest24 = validator.PEST24(samples.First());
            Console.WriteLine("PEST24 {0}", pest24.passed ? "PASSED" : "FAILED");
            var pest25 = validator.PEST25(samples.First());
            Console.WriteLine("PEST25 {0}", pest25.passed ? "PASSED" : "FAILED");
            var chem01 = validator.CHEM01(samples.First());
            Console.WriteLine("CHEM01 {0}", chem01.passed ? "PASSED" : "FAILED");
            var chem02 = validator.CHEM02(samples.First());
            Console.WriteLine("CHEM02 {0}", chem02.passed ? "PASSED" : "FAILED");
            var chem03 = validator.CHEM03(samples.First());
            Console.WriteLine("CHEM03 {0}", chem03.passed ? "PASSED" : "FAILED");
            var chem04 = validator.CHEM04(samples.First());
            Console.WriteLine("CHEM04 {0}", chem04.passed ? "PASSED" : "FAILED");
            var chem05 = validator.CHEM05(samples.First());
            Console.WriteLine("CHEM05 {0}", chem05.passed ? "PASSED" : "FAILED");
            var chem06 = validator.CHEM06(samples.First());
            Console.WriteLine("CHEM06 {0}", chem06.passed ? "PASSED" : "FAILED");
            var chem07 = validator.CHEM07(samples.First());
            Console.WriteLine("CHEM07 {0}", chem07.passed ? "PASSED" : "FAILED");
            var chem08 = validator.CHEM08(samples.First());
            Console.WriteLine("CHEM08 {0}", chem08.passed ? "PASSED" : "FAILED");
            */

            Console.ReadLine();

        }
    }
}
