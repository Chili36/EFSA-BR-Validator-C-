﻿using EfsaBusinessRuleValidator;
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

            
            //var xmlfil = @"C:\Users\dafo\Downloads\Pesticidrapport_2016-01-01_2016-01-31.xml";
            var xmlfil = @"C:\Dev\REST_latest.xml";


            if (args.Length > 0)
            {
                xmlfil = args[0];
            }

            Console.WriteLine($"Använder {xmlfil}");

            if (!System.IO.File.Exists(xmlfil))
            {
                Console.WriteLine("Sökvägen till en testfil måste anges.");
                Console.ReadLine();
            }


            ValidateVMPR(XDocument.Load(@xmlfil));
            //ValideDatePest(xmlfil);
            Console.WriteLine("DONE!");
            Console.ReadLine();

        }

        private static void ValideDatePest(string xmlfil)
        {
            var xml = XDocument.Load(xmlfil);
            var samples = XDocument.Load(@xmlfil).Descendants("result"); //Använder Workflow 2
            var tests = new List<BusinessRuleError>();
            var validator = new Validator();

            foreach (var el in samples)
            {
                tests.AddRange(Validate(el));
            }

          


            var errors = tests.Where(x => x.outcome.passed == false);
            Console.WriteLine($"Det fanns {errors.Count()} valideringsfel");

            foreach (var error in errors.GroupBy(p => p.outcome.error))
            {
                Console.WriteLine(errors.Where(x => x.outcome.error == error.Key).First().outcome.name);
                Console.WriteLine(error.Key);

                var samplesWithErrors = errors.Where(x => x.outcome.error == error.Key);
                var noOfSamples = samplesWithErrors.Select(x => x.El.Element("labSampCode").Value).Distinct().Count();

                //Skapa xmlfil med alla fel. 

                var xmlDoc = new XDocument(new XElement("errors", samplesWithErrors.Select(x => x.El)));

                var filnamn = $"C:\\dev\\errors\\{errors.Where(x => x.outcome.error == error.Key).First().outcome.name}_q4.xml";

                xmlDoc.Save(filnamn);


                Console.WriteLine($"There are {noOfSamples} samples with this error");


                XElement e = errors.Where(x => x.outcome.error == error.Key).First().El;
                Outcome o = errors.Where(x => x.outcome.error == error.Key).First().outcome;

                Console.WriteLine($"Restype = {(string)e.Element("resType")}");
                Console.WriteLine($"labSampCode = {(string)e.Element("labSampCode")}");
                Console.WriteLine($"resultCode = {(string)e.Element("resultCode")}");
                foreach (var v in o.values)
                {
                    Console.WriteLine($"Value: {v.Item1}: {v.Item2}");

                }



                //    El.Element("labSampCode").Value;



                // Console.WriteLine(e);
                Console.WriteLine("----------------------");

            }
        }

        static void ValidateVMPR(XDocument xml)
        {
            var results = xml.Descendants("result");

            var tests = new List<BusinessRuleError>();
            var validator = new Validator();

            foreach (var el in results)
            {
                tests.AddRange(ValidateVMPR(el));
            }

            var errors = tests.Where(x => x.outcome.passed == false);
            foreach (var error in errors.Where(q=> q.outcome.type == "error").GroupBy(p => p.outcome.error))
            {
                Console.WriteLine(errors.Where(x => x.outcome.error == error.Key).First().outcome.name);
                Console.WriteLine(error.Key);

                var samplesWithErrors = errors.Where(x => x.outcome.error == error.Key);
                var noOfSamples = samplesWithErrors.Select(x => x.El.Element("sampId").Value).Distinct().Count();

                //Skapa xmlfil med alla fel. 

                var xmlDoc = new XDocument(new XElement("errors", samplesWithErrors.Select(x => x.El)));

                var filnamn = $"C:\\dev\\errors\\{errors.Where(x => x.outcome.error == error.Key).First().outcome.name}_q4.xml";

                xmlDoc.Save(filnamn);


                Console.WriteLine($"There are {noOfSamples} samples with this error");


                XElement e = errors.Where(x => x.outcome.error == error.Key).First().El;
                Outcome o = errors.Where(x => x.outcome.error == error.Key).First().outcome;

                Console.WriteLine($"sampId = {(string)e.Element("sampId")}");
                Console.WriteLine($"resId = {(string)e.Element("resId")}");
                foreach (var v in o.values)
                {
                    Console.WriteLine($"Value: {v.Item1}: {v.Item2}");

                }



                //    El.Element("labSampCode").Value;



                // Console.WriteLine(e);
                Console.WriteLine("----------------------");

            }

        }
       
        private static List<BusinessRuleError> ValidateVMPR(XElement el)
        {
            var validator = new VmprBusinessRules();
            var utfall = new List<BusinessRuleError>();

            var vmpr001 = validator.VMPR001(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr001 });
            var vmpr002 = validator.VMPR002(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr002 });
            var vmpr003 = validator.VMPR003(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr003 });
            var vmpr004 = validator.VMPR004(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr004 });
            var vmpr005 = validator.VMPR005(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr005 });
            var vmpr006 = validator.VMPR006(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr006 });
            var vmpr007 = validator.VMPR007(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr007 });
            var vmpr008 = validator.VMPR008(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr008 });
            var vmpr009 = validator.VMPR009(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr009 });
            var vmpr010 = validator.VMPR010(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr010 });
            var vmpr011 = validator.VMPR011(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr011 });
            var vmpr012 = validator.VMPR012(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr012 });
            var vmpr013 = validator.VMPR013(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr013 });
            var vmpr014 = validator.VMPR014(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr014 });
            var vmpr015 = validator.VMPR015(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr015 });
            var vmpr016 = validator.VMPR016(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr016 });
            var vmpr017 = validator.VMPR017(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr017 });
            var vmpr018 = validator.VMPR018(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr018 });
            var vmpr019 = validator.VMPR019(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr019 });
            var vmpr020 = validator.VMPR020(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr020 });
            var vmpr021 = validator.VMPR021(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr021 });
            var vmpr022 = validator.VMPR022(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr022 });
            var vmpr023 = validator.VMPR023(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr023 });
            var vmpr024 = validator.VMPR024(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr024 });
            var vmpr025 = validator.VMPR025(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr025 });
            var vmpr026 = validator.VMPR026(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr026 });
            var vmpr027 = validator.VMPR027(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr027 });
            var vmpr028 = validator.VMPR028(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr028 });
            var vmpr029 = validator.VMPR029(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr029 });
            var vmpr030 = validator.VMPR030(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr030 });
            var vmpr031 = validator.VMPR031(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr031 });
            var vmpr032 = validator.VMPR032(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr032 });
            var vmpr034 = validator.VMPR034(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr034 });
            var vmpr035 = validator.VMPR035(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr035 });
            var vmpr036 = validator.VMPR036(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr036 });
            var vmpr037 = validator.VMPR037(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr037 });
            var vmpr038 = validator.VMPR038(el);
            utfall.Add(new BusinessRuleError { El = el, outcome = vmpr038 });
            return utfall;

        }

        private static List<BusinessRuleError> Validate(XElement el)
        {
            var validator = new Validator();

            var utfall = new List<BusinessRuleError>();

            var br01a = validator.BR01A(el);
            if (!br01a.passed)
            {
                utfall.Add(new BusinessRuleError { El = el,outcome = br01a });
            }

            var br02a_01 = validator.BR02A_01(el);
            if (!validator.BR02A_01(el).passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = validator.BR02A_01(el) });
            }

            var br02a_02 = validator.BR02A_02(el);
            if (!br02a_02.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br02a_02 });
            }

        
            var br02a_03 = validator.BR02A_03(el);
            if (!br02a_03.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br02a_03 });
            }

            var br02a_04 = validator.BR02A_04(el);
            if (!br02a_04.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br02a_04 });
            }
            
            var br02a_05 = validator.BR02A_05(el);
            if (!br02a_05.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br02a_05 });
            }

            var br02a_06 = validator.BR02A_06(el);
            if (!br02a_06.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br02a_06 });
            }

            var br02a_07 = validator.BR02A_07(el);
            if (!br02a_07.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br02a_07 });
            }


            var br03a_01 = validator.BR03A_01(el);
            if (!br03a_01.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br03a_01 });
            }

            var br03a_02 = validator.BR03A_02(el);
            if (!br03a_02.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br03a_02 });
            }

            
            var br03a_03 = validator.BR03A_03(el);
            if (!br03a_03.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br03a_03 });
            }


            var br03a_04 = validator.BR03A_04(el);
            if (!br03a_04.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br03a_04 });
            }


            var br03a_05 = validator.BR03A_05(el);
            if (!br03a_05.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br03a_05 });
            }


            var br03a_06 = validator.BR03A_06(el);
            if (!br03a_06.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br03a_06 });
            }


            var br03a_07 = validator.BR03A_07(el);
            if (!br03a_07.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br03a_07 });
            }


            var br03a_08 = validator.BR03A_08(el);
            if (!br03a_08.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br03a_08 });
            }

            var br03a_09 = validator.BR03A_09(el);
            if (!br03a_09.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br03a_09 });
            }

            var br03a_10 = validator.BR03A_10(el);
            if (!br03a_10.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br03a_10 });
            }


            var br03a_11 = validator.BR03A_11(el);
            if (!br03a_11.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br03a_11 });
            }

            var br03a_12 = validator.BR03A_12(el);
            if (!br03a_12.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br03a_12 });
            }

             var br03a_13 = validator.BR03A_13(el);
            if (!br03a_13.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br03a_13 });
            }


            var br03a_14 = validator.BR03A_14(el);
            if (!br03a_14.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br03a_14 });
            }


            var br03a_15 = validator.BR03A_15(el);
            if (!br03a_15.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br03a_15 });
            }
            
            var br03a_16 = validator.BR03A_16(el);
            if (!br03a_16.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br03a_16 });
            }


            var br03a_17 = validator.BR03A_17(el);
            if (!br03a_17.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br03a_17 });
            }

            
            var br04a = validator.BR04A(el);
            if (!br04a.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br04a });
            }

            var br07a = validator.BR07A_01(el);
            if (!br07a.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br07a });
            }


            var br07a_02 = validator.BR07A_02(el);
            if (!br07a_02.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br07a_02 });
            }


            var br07a_03 = validator.BR07A_03(el);
            if (!br07a_03.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br07a_03 });
            }
            var br08a_05 = validator.BR08A_05(el);
            if (!br08a_05.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br08a_05 });
            }

            var br09a_09 = validator.BR09A_09(el);
            if (!br09a_09.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br09a_09 });
            }


            var br12a_01 = validator.BR12A_01(el);
            if (!br12a_01.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = br12a_01 });
            }

            var pest01 = validator.PEST01(el);
            if (!pest01.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest01 });
            }
            var pest02 = validator.PEST02(el);
            if (!pest02.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest02 });
            }
            var pest03 = validator.PEST03(el);
            if (!pest03.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest03 });
            }
            var pest04 = validator.PEST04(el);
            if (!pest04.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest04 });
            }
            var pest05 = validator.PEST05(el);
            if (!pest05.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest05 });
            }
            var pest06 = validator.PEST06(el);
            if (!pest06.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest06 });
            }
            var pest07 = validator.PEST07(el);
            if (!pest07.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest07 });
            }
            var pest08 = validator.PEST08(el);
            if (!pest08.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest08 });
            }
            var pest09 = validator.PEST09(el);
            if (!pest09.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest09 });
            }
            var pest10 = validator.PEST10(el);
            if (!pest10.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest10 });
            }
            var pest11 = validator.PEST11(el);
            if (!pest11.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest11 });
            }
            var pest12 = validator.PEST12(el);
            if (!pest12.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest12 });
            }
            var pest13 = validator.PEST13(el);
            if (!pest13.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest13 });
            }
            var pest14 = validator.PEST14(el);
            if (!pest14.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest14 });
            }
            var pest15 = validator.PEST15(el);
            if (!pest15.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest15 });
            }
            var pest16 = validator.PEST16(el);
            if (!pest16.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest16 });
            }
            var pest17 = validator.PEST17(el);
            if (!pest17.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest17 });
            }
            var pest18 = validator.PEST18(el);
            if (!pest18.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest18 });
            }
            var pest19 = validator.PEST19(el);
            if (!pest19.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest19 });
            }
            var pest20 = validator.PEST20(el);
            if (!pest20.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest20 });
            }
            var pest21 = validator.PEST21(el);
            if (!pest21.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest21 });
            }
            var pest22 = validator.PEST22(el);
            if (!pest22.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest22 });
            }
            var pest23 = validator.PEST23(el);
            if (!pest23.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest23 });
            }
            var pest24 = validator.PEST24(el);
            if (!pest24.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest24 });
            }
            var pest25 = validator.PEST25(el);
            if (!pest25.passed)
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest25 });
            }

            var pest26 = validator.PEST26(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest26 });
            }

            var pest669_1 = validator.PEST669_1(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest669_1 });
            }

            var pest669_CN = validator.PEST669_CN(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest669_CN });
            }

            var pest669_DO = validator.PEST669_DO(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest669_DO });
            }

            var pest669_DO_a = validator.PEST669_DO_a(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest669_DO_a });
            }

            var pest669_EG = validator.PEST669_EG(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest669_EG });
            }

            var pest669_EG_a = validator.PEST669_EG_a(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest669_EG_a });
            }
            var pest669_KE = validator.PEST669_KE(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest669_KE });
            }

            var pest669_KH = validator.PEST669_KH(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest669_KH });
            }

            var pest669_KH_a = validator.PEST669_KH_a(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest669_KH_a });
            }


            var pest669_TH = validator.PEST669_TH(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest669_TH });
            }
            var pest669_TH_a = validator.PEST669_TH_a(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest669_TH_a });
            }

            var pest669_TR = validator.PEST669_TR(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest669_TR });
            }

            var pest669_TR_a = validator.PEST669_TR_a(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest669_TR_a });
            }

            var pest669_VN = validator.PEST669_VN(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest669_VN });
            }

            var pest669_VN_a = validator.PEST669_VN_a(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest669_VN_a });
            }

            var pest669_VN_b = validator.PEST669_VN_b(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest669_VN_b });
            }

            var pest669_VN_c = validator.PEST669_VN_c(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest669_VN_c });
            }

            var pest_sampInfo005 = validator.PEST_sampInfo005(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest_sampInfo005 });
            }

            var pest_sampInfo009 = validator.PEST_sampInfo009(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest_sampInfo009 });
            }

            var pest_sampInfo018 = validator.PEST_sampInfo018(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest_sampInfo018 });
            }

            var pest_sampInfo019 = validator.PEST_sampInfo019(el);
            {
                utfall.Add(new BusinessRuleError { El = el, outcome = pest_sampInfo019 });
            }

            return utfall;
        }
    }
}
