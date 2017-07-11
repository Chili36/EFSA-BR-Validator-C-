using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EfsaBusinessRuleValidator
{
    public class VmprBusinessRules
    {
        ///The value in the data element 'Programme Legal Reference' (progLegalRef) should be equal to 'Council Directive (EC) No 23/1996 (amended)' (N247A);
        ///The value in the data element 'Programme Legal Reference' (progLegalRef) should be equal to 'Council Directive (EC) No 23/1996 (amended)' (N247A);
        public Outcome VMPR001(XElement sample)
        {
            // <checkedDataElements>;
            var progLegalRef = sample.Element("progLegalRef").Value;

            var outcome = new Outcome();
            outcome.name = "VMPR001";
            outcome.lastupdate = "2017-01-09";
            outcome.description = "The value in the data element 'Programme Legal Reference' (progLegalRef) should be equal to 'Council Directive (EC) No 23/1996 (amended)' (N247A);";
            outcome.error = "WARNING: progLegalRef is different from Council Directive (EC) No 23/1996;";
            outcome.type = "warning";
            outcome.passed = true;

            //Logik
            if (progLegalRef != "N247A")
            {
                outcome.passed = false;
            }

            return outcome;
        }

        ///The value in the data element 'Sampling Strategy' (sampStrategy) must be different from 'Census' (ST50A) and 'Not specified' (STXXA);
        public Outcome VMPR002(XElement sample)
        {
            // <checkedDataElements>;
            var sampStrategy = (string)sample.Element("sampStrategy");

            var outcome = new Outcome();
            outcome.name = "VMPR002";
            outcome.lastupdate = "2017-01-10";
            outcome.description = "The value in the data element 'Sampling Strategy' (sampStrategy) must be different from 'Census' (ST50A) and 'Not specified' (STXXA);";
            outcome.error = "sampStrategy is not specified, or equal to census, though these values should not be reported;";
            outcome.type = "error";
            outcome.passed = true;

            //Logik (ignore null: no);
            var sampStrategys = new List<string>();
            sampStrategys.Add("ST50A");
            sampStrategys.Add("STXXA");
            if (!sampStrategys.Contains(sampStrategy))
            {
                outcome.passed = false;
            }

            return outcome;
        }
        ///The value in the data element 'Sampling Strategy' (sampStrategy) should be different from 'Objective sampling' (ST10A), and 'Convenient sampling' (ST40A);
        public Outcome VMPR003(XElement sample)
        {
            // <checkedDataElements>;
            var sampStrategy = (string)sample.Element("sampStrategy");

            var outcome = new Outcome();
            outcome.name = "VMPR003";
            outcome.lastupdate = "2017-01-10";
            outcome.description = "The value in the data element 'Sampling Strategy' (sampStrategy) should be different from 'Objective sampling' (ST10A), and 'Convenient sampling' (ST40A);";
            outcome.error = "WARNING: sampStrategy is objective or conveniente sampling, though these values should not be reported;";
            outcome.type = "warning";
            outcome.passed = true;

            //Logik (ignore null: yes);
            if (!String.IsNullOrEmpty(sampStrategy))
            {
                var sampStrategys = new List<string>();
                sampStrategys.Add("ST10A");
                sampStrategys.Add("ST40A");
                if (!sampStrategys.Contains(sampStrategy))
                {
                    outcome.passed = false;
                }
            }
            return outcome;
        }

        ///If the value in 'Link To Original Sample’ (sampInfo.origSampId) is reported, i.e. a follow-up sample, then the value in 'Sampling Strategy’ (sampStrategy) must be 'suspect sampling' (ST30A);
        public Outcome VMPR004(XElement sample)
        {
            // <checkedDataElements>;
            var sampStrategy = (string)sample.Element("sampStrategy");
            var sampInforigSampId = (string)sample.Element("sampInfo.origSampId");

            var outcome = new Outcome();
            outcome.name = "VMPR004";
            outcome.lastupdate = "2016-05-10";
            outcome.description = "If the value in 'Link To Original Sample’ (sampInfo.origSampId) is reported, i.e. a follow-up sample, then the value in 'Sampling Strategy’ (sampStrategy) must be 'suspect sampling' (ST30A);";
            outcome.error = "sampStrategy is not suspect sampling, though sampInfo.origSampId is reported;";
            outcome.type = "error";
            outcome.passed = true;


            if (!String.IsNullOrEmpty(sampInforigSampId))
            {
                var sampStrategys = new List<string>();
                sampStrategys.Add("ST30A");
                if (!sampStrategys.Contains(sampStrategy))
                {
                    outcome.passed = false;
                }

            }
            return outcome;
        }
        ///The value in the data element 'Programme type' (progType) should be equal to 'Official (National and EU) programme' (K018A);
        public Outcome VMPR005(XElement sample)
        {
            // <checkedDataElements>;
            var progType = (string)sample.Element("progType");

            var outcome = new Outcome();
            outcome.name = "VMPR005";
            outcome.lastupdate = "2017-01-10";
            outcome.description = "The value in the data element 'Programme type' (progType) should be equal to 'Official (National and EU) programme' (K018A);";
            outcome.error = "WARNING: progType is not Official (National and EU) programme;";
            outcome.type = "warning";
            outcome.passed = true;

            //Logik (ignore null: yes);
            if (!String.IsNullOrEmpty(progType))
            {
                var progTypes = new List<string>();
                progTypes.Add("K018A");
                if (!progTypes.Contains(progType))
                {
                    outcome.passed = false;
                }

            }
            return outcome;
        }
        ///The value in the data element 'Sampling method' (sampMethod) should be equal to 'According to Dir. 2002/63/EC' (N009A), or 'According to 97/747/EC' (N010A), or 'According to Reg 1883/2006' (N015A), or 'According to 98/179/EC' (N021A), or 'Individual' (N030A), or 'According to Commission Regulation (EU) No 589/201' (N039A);
        public Outcome VMPR006(XElement sample)
        {
            // <checkedDataElements>;
            var sampMethod = (string)sample.Element("sampMethod");

            var outcome = new Outcome();
            outcome.name = "VMPR006";
            outcome.lastupdate = "2017-01-20";
            outcome.description = "The value in the data element 'Sampling method' (sampMethod) should be equal to 'According to Dir. 2002/63/EC' (N009A), or 'According to 97/747/EC' (N010A), or 'According to Reg 1883/2006' (N015A), or 'According to 98/179/EC' (N021A), or 'Individual' (N030A), or 'According to Commission Regulation (EU) No 589/201' (N039A);";
            outcome.error = "WARNING: sampMethod is not in the recommend list of codes;";
            outcome.type = "warning";
            outcome.passed = true;

            //Logik (ignore null: yes);
            if (!String.IsNullOrEmpty(sampMethod))
            {
                var sampMethods = new List<string>();
                sampMethods.Add("N009A");
                sampMethods.Add("N010A");
                sampMethods.Add("N015A");
                sampMethods.Add("N030A");
                sampMethods.Add("N021A");
                sampMethods.Add("N039A");
                if (!sampMethods.Contains(sampMethod))
                {
                    outcome.passed = false;
                }

            }
            return outcome;
        }
        ///The value in the data element 'Sampler' (sampler) should be equal to 'Official sampling' (CX02A);
        public Outcome VMPR007(XElement sample)
        {
            // <checkedDataElements>;
            var sampler = (string)sample.Element("sampler");

            var outcome = new Outcome();
            outcome.name = "VMPR007";
            outcome.lastupdate = "2017-01-09";
            outcome.description = "The value in the data element 'Sampler' (sampler) should be equal to 'Official sampling' (CX02A);";
            outcome.error = "WARNING: sampler is different from Official sampling;";
            outcome.type = "warning";
            outcome.passed = true;

            //Logik (ignore null: yes);
            if (!String.IsNullOrEmpty(sampler))
            {
                var samplers = new List<string>();
                samplers.Add("CX02A");
                if (!samplers.Contains(sampler))
                {
                    outcome.passed = false;
                }

            }
            return outcome;
        }
        ///Only recommended combinations of 'Sampling point' (sampPoint) and 'Sampling unit type' (sampUnitType) should be reported;
        public Outcome VMPR008(XElement sample)
        {
            // <checkedDataElements>;
            var sampPoint = (string)sample.Element("sampPoint");
            var sampUnitType = (string)sample.Element("sampUnitType");

            var outcome = new Outcome();
            outcome.name = "VMPR008";
            outcome.lastupdate = "2017-01-10";
            outcome.description = "Only recommended combinations of 'Sampling point' (sampPoint) and 'Sampling unit type' (sampUnitType) should be reported;";
            outcome.error = "WARNING: the combinations of sampPoint and sampUnitType are not among the recommended when reporting VMPR results;";
            outcome.type = "warning";
            outcome.passed = true;

            //Logik (ignore null: yes);
            if (!String.IsNullOrEmpty(sampPoint))
            {
                var sampPoints = new List<string>();

                if (sampPoint == "E10A")
                {
                    var sampUnitTypes = new List<string>();
                    sampUnitTypes.Add("G198A");
                    sampUnitTypes.Add("G199A");
                    sampUnitTypes.Add("G202A");
                    if (!sampUnitTypes.Contains(sampUnitType))
                    {
                        outcome.passed = false;
                    }
                }
                if (sampPoint == "E112A")
                {
                    var sampUnitTypes = new List<string>();
                    sampUnitTypes.Add("G204A");
                    sampUnitTypes.Add("G203A");
                    outcome.passed = sampUnitTypes.Contains(sampUnitType);
                }
                if (sampPoint == "E152A")
                {
                    var sampUnitTypes = new List<string>();
                    sampUnitTypes.Add("G198A");
                    sampUnitTypes.Add("G199A");
                    sampUnitTypes.Add("G202A");
                    outcome.passed = sampUnitTypes.Contains(sampUnitType);
                }

                sampPoints = new List<string>();
                sampPoints.Add("E180A");
                sampPoints.Add("E170A");
                if (!sampPoints.Contains(sampPoint))
                {
                    outcome.passed = sampUnitType == "G199A";
                }
                sampPoints = new List<string>();
                sampPoints.Add("E300A");
                sampPoints.Add("E301A");
                sampPoints.Add("E510A");
                sampPoints.Add("E520A");
                if (!sampPoints.Contains(sampPoint))
                {
                    var sampUnitTypes = new List<string>();
                    sampUnitTypes.Add("G204A");
                    sampUnitTypes.Add("G203A");
                    outcome.passed = sampUnitTypes.Contains(sampUnitType);
                }
                if (sampPoint == "E311A")
                {
                    var sampUnitTypes = new List<string>();
                    sampUnitTypes.Add("G200A");
                    sampUnitTypes.Add("G199A");
                    outcome.passed = sampUnitTypes.Contains(sampUnitType);
                }
                if (sampPoint == "E010A")
                {
                    var sampUnitTypes = new List<string>();
                    sampUnitTypes.Add("G199A");
                    sampUnitTypes.Add("G202A");
                    sampUnitTypes.Add("G203A");
                    outcome.passed = sampUnitTypes.Contains(sampUnitType);
                }
            }
            return outcome;
        }
        ///A value in the data element 'Text description of the matrix of the sample taken' (sampMatText) should be reported;
        public Outcome VMPR009(XElement sample)
        {
            // <checkedDataElements>;
            var sampMatText = (string)sample.Element("sampMatText");

            var outcome = new Outcome();
            outcome.name = "VMPR009";
            outcome.lastupdate = "2016-05-10";
            outcome.description = "A value in the data element 'Text description of the matrix of the sample taken' (sampMatText) should be reported;";
            outcome.error = "WARNING: sampMatText is missing, though recommended;";
            outcome.type = "warning";
            outcome.passed = true;

            //Logik (ignore null: no);

            outcome.passed = !String.IsNullOrEmpty(sampMatText);
            return outcome;
        }
        ///The value in the data element 'Type of parameter' (paramType) should be equal to 'Full legal marker residue definition analysed' (P005A), or 'Sum based on a subset' (P004A), or 'Part of a sum' (P002A);
        public Outcome VMPR010(XElement sample)
        {
            // <checkedDataElements>;
            var paramType = (string)sample.Element("paramType");

            var outcome = new Outcome();
            outcome.name = "VMPR010";
            outcome.lastupdate = "2017-03-16";
            outcome.description = "The value in the data element 'Type of parameter' (paramType) should be equal to 'Full legal marker residue definition analysed' (P005A), or 'Sum based on a subset' (P004A), or 'Part of a sum' (P002A);";
            outcome.error = "WARNING: paramType is not in the recommended list of codes;";
            outcome.type = "warning";
            outcome.passed = true;

            //Logik (ignore null: yes);
            if (!String.IsNullOrEmpty(paramType))
            {
                var paramTypes = new List<string>();
                paramTypes.Add("P005A");
                paramTypes.Add("P004A");
                paramTypes.Add("P002A");
                outcome.passed = paramTypes.Contains(paramType);
            }
            return outcome;
        }
        ///Only recommended values of 'Parameter code' (paramCode) should be combined with 'Type of parameter' (paramType) equal to 'Part of a sum' (P002A);
        public Outcome VMPR011(XElement sample)
        {
            // <checkedDataElements>;
            var paramCode = (string)sample.Element("paramCode");
            var paramType = (string)sample.Element("paramType");

            var outcome = new Outcome();
            outcome.name = "VMPR011";
            outcome.lastupdate = "2017-03-16";
            outcome.description = "Only recommended values of 'Parameter code' (paramCode) should be combined with 'Type of parameter' (paramType) equal to 'Part of a sum' (P002A);";
            outcome.error = "WARNING: paramType is not part of a sum, though paramCode is a code for which the type should be part of sum;";
            outcome.type = "warning";
            outcome.passed = true;

            //Logik (ignore null: yes);
           
            if (!String.IsNullOrEmpty(paramCode))
            {
                var paramCodes = new List<string>();
                paramCodes.Add("RF-0108-003-PPP");
                paramCodes.Add("RF-0108-002-PPP");
                paramCodes.Add("RF-00000646-VET");
                paramCodes.Add("RF-00000648-VET");
                paramCodes.Add("RF-00000638-VET");
                paramCodes.Add("RF-00000601-VET");
                paramCodes.Add("RF-00000602-VET");
                paramCodes.Add("RF-00000603-VET");
                paramCodes.Add("RF-00000604-VET");
                paramCodes.Add("RF-00000605-VET");
                paramCodes.Add("RF-00000606-VET");
                paramCodes.Add("RF-00000607-VET");
                paramCodes.Add("RF-00000608-VET");
                paramCodes.Add("RF-00000610-VET");
                paramCodes.Add("RF-00000624-VET");
                paramCodes.Add("RF-00000612-VET");
                paramCodes.Add("RF-00000600-VET");
                paramCodes.Add("RF-00000615-VET");
                paramCodes.Add("RF-00000617-VET");
                paramCodes.Add("RF-00000649-VET");
                paramCodes.Add("RF-00000621-VET");
                paramCodes.Add("RF-00000622-VET");
                paramCodes.Add("RF-0900-001-PPP");
                paramCodes.Add("RF-00000679-VET");
                paramCodes.Add("RF-00000779-VET");
                paramCodes.Add("RF-00000781-VET");
                paramCodes.Add("RF-00000647-VET");
                paramCodes.Add("RF-00000614-VET");
                paramCodes.Add("RF-00000611-VET");
                paramCodes.Add("RF-00000682-VET");
                paramCodes.Add("RF-00000681-VET");
                paramCodes.Add("RF-00000045-VET");
                paramCodes.Add("RF-00000041-VET");
                paramCodes.Add("RF-00000040-VET");
                paramCodes.Add("RF-00000629-VET");
                paramCodes.Add("RF-00002895-PAR");
                paramCodes.Add("RF-00000178-VET");
                paramCodes.Add("RF-00000166-VET");
                paramCodes.Add("RF-00000575-VET");
                paramCodes.Add("RF-00000579-VET");
                paramCodes.Add("RF-00000551-VET");
                paramCodes.Add("RF-00000695-VET");
                paramCodes.Add("RF-00000594-VET");
                paramCodes.Add("RF-00000590-VET");
                paramCodes.Add("RF-00000007-VET");
                paramCodes.Add("RF-00002865-PAR");
                paramCodes.Add("RF-00002908-PAR");
                paramCodes.Add("RF-00002909-PAR");
                paramCodes.Add("RF-00002910-PAR");
                paramCodes.Add("RF-00002911-PAR");
                paramCodes.Add("RF-00002919-PAR");
                paramCodes.Add("RF-00001727-PAR");
                paramCodes.Add("RF-00004638-PAR");
                paramCodes.Add("RF-00004639-PAR");
                paramCodes.Add("RF-00002915-PAR");
                paramCodes.Add("RF-00000049-VET");
                paramCodes.Add("RF-00000543-VET");
                paramCodes.Add("RF-00000586-VET");
                paramCodes.Add("RF-00000642-VET");
                paramCodes.Add("RF-00000532-VET");
                paramCodes.Add("RF-00000670-VET");
                paramCodes.Add("RF-00000588-VET");
                paramCodes.Add("RF-00000043-VET");
                paramCodes.Add("RF-00000037-VET");
                paramCodes.Add("RF-00000038-VET");
                paramCodes.Add("RF-00002917-PAR");
                paramCodes.Add("RF-0416-001-PPP");
                paramCodes.Add("RF-0926-001-PPP");
                paramCodes.Add("RF-00002955-PAR");
                paramCodes.Add("RF-00000571-VET");
                paramCodes.Add("RF-00002888-PAR");
                paramCodes.Add("RF-00002889-PAR");
               
                if (paramCodes.Contains(paramCode))
                {
                    outcome.passed = paramType == "P002A";
                }

            }
            return outcome;
        }
        ///The value in the data element 'Analytical Method Type' (anMethType) must be equal to 'Screening' (AT06A), or 'Confirmation' (AT08A);
        public Outcome VMPR012(XElement sample)
        {
            // <checkedDataElements>;
            var anMethType = (string)sample.Element("anMethType");

            var outcome = new Outcome();
            outcome.name = "VMPR012";
            outcome.lastupdate = "2016-05-10";
            outcome.description = "The value in the data element 'Analytical Method Type' (anMethType) must be equal to 'Screening' (AT06A), or 'Confirmation' (AT08A);";
            outcome.error = "anMethType is not screening or confirmation;";
            outcome.type = "error";
            outcome.passed = true;

            //Logik (ignore null: yes);
            if (!String.IsNullOrEmpty(anMethType))
            {
                var anMethTypes = new List<string>();
                anMethTypes.Add("AT06A");
                anMethTypes.Add("AT08A");
                outcome.passed = anMethTypes.Contains(anMethType);
            }
            return outcome;
        }
        ///If the value in the data element 'Evaluation of the result' (evalCode) is 'Detected' (J041A) or 'Above maximum permissible quantities' (J003A), then the value in the data element 'Analytical Method Type' (anMethType) must be equal to 'Confirmation' (AT08A);
        public Outcome VMPR013(XElement sample)
        {
            // <checkedDataElements>;
            var anMethType = (string)sample.Element("anMethType");
            var evalCode = (string)sample.Element("evalCode");

            var outcome = new Outcome();
            outcome.name = "VMPR013";
            outcome.lastupdate = "2016-05-10";
            outcome.description = "If the value in the data element 'Evaluation of the result' (evalCode) is 'Detected' (J041A) or 'Above maximum permissible quantities' (J003A), then the value in the data element 'Analytical Method Type' (anMethType) must be equal to 'Confirmation' (AT08A);";
            outcome.error = "anMethType is not confirmation, though evalCode is detected or above maximum permissible quantities;";
            outcome.type = "error";
            outcome.passed = true;

            //Logik (ignore null: yes);
           
            if (!String.IsNullOrEmpty(anMethType))
            {
                var evalCodes = new List<string>();
                evalCodes.Add("J041A");
                evalCodes.Add("J003A");
                ///TESTING

                if (evalCodes.Contains(evalCode))
                {
                    var anMethTypes = new List<string>();
                    anMethTypes.Add("AT08A");
                    outcome.passed = anMethTypes.Contains(anMethType);
                }
            }
            return outcome;
        }
        ///The value in the data element 'Accreditation procedure for the analytical method' (accredProc) should be equal to 'Accredited according to ISO/IEC17025' (V001A), or 'Accredited and validated according to Com.Dec. 2002/657/EC' (V007A), or 'Validated according to Commission Decision 2002/657/EC, but not accredited under ISO/IEC17025' (V005A);
        public Outcome VMPR014(XElement sample)
        {
            // <checkedDataElements>;
            var accredProc = (string)sample.Element("accredProc");

            var outcome = new Outcome();
            outcome.name = "VMPR014";
            outcome.lastupdate = "2017-03-16";
            outcome.description = "The value in the data element 'Accreditation procedure for the analytical method' (accredProc) should be equal to 'Accredited according to ISO/IEC17025' (V001A), or 'Accredited and validated according to Com.Dec. 2002/657/EC' (V007A), or 'Validated according to Commission Decision 2002/657/EC, but not accredited under ISO/IEC17025' (V005A);";
            outcome.error = "WARNING: accredProc is not one of the recommended procedure;";
            outcome.type = "warning";
            outcome.passed = true;

            //Logik (ignore null: yes);
            if (!String.IsNullOrEmpty(accredProc))
            {
                var accredProcs = new List<string>();
                accredProcs.Add("V001A");
                accredProcs.Add("V007A");
                accredProcs.Add("V005A");
                outcome.passed = accredProcs.Contains(accredProc);
            }
            return outcome;
        }
        ///If a value is reported in 'Result LOD' (resLOD), or 'Result LOQ' (resLOQ), or 'Result value' (resVal), or 'CC alpha' (CCalpha), or 'CC beta' (CCbeta), then the value in the data element 'Result unit' (resUnit) should be equal to 'Microgram/kilogram' (G050A) or 'Microgram/litre' (G051A) to ensure that values are comparable;
        public Outcome VMPR015(XElement sample)
        {
            // <checkedDataElements>;
            var resLOD = (string)sample.Element("resLOD");
            var resLOQ = (string)sample.Element("resLOQ");
            var resVal = (string)sample.Element("resVal");
            var CCalpha = (string)sample.Element("CCalpha");
            var CCbeta = (string)sample.Element("CCbeta");
            var resUnit = (string)sample.Element("resUnit");

            var outcome = new Outcome();
            outcome.name = "VMPR015";
            outcome.lastupdate = "2017-03-16";
            outcome.description = "If a value is reported in 'Result LOD' (resLOD), or 'Result LOQ' (resLOQ), or 'Result value' (resVal), or 'CC alpha' (CCalpha), or 'CC beta' (CCbeta), then the value in the data element 'Result unit' (resUnit) should be equal to 'Microgram/kilogram' (G050A) or 'Microgram/litre' (G051A) to ensure that values are comparable;";
            outcome.error = "WARNING: resUnit is not microgram/kilogram or microgram/litre, though a numerical value is reported;";
            outcome.type = "warning";
            outcome.passed = true;

            if (string.IsNullOrEmpty(resLOD) && string.IsNullOrEmpty(resLOQ) && string.IsNullOrEmpty(resVal) && string.IsNullOrEmpty(CCbeta) && string.IsNullOrEmpty(CCalpha))
            {
                return outcome;
            }
                var resUnits = new List<string>();
                resUnits.Add("G050A");
                resUnits.Add("G051A");
                outcome.passed = resUnits.Contains(resUnit);
            return outcome;
        }
        ///If the value in 'Parameter code' (paramCode) belongs to the group B3c (chemical elements used in vmpr), then a value in the data element 'Result LOQ' (resLOQ) should be reported;
        public Outcome VMPR016(XElement sample)
        {
            // <checkedDataElements>;
            var resLOQ = (string)sample.Element("resLOQ");
            var paramCode = (string)sample.Element("paramCode");
            string[] grupp = { "RF-00000001-RAD", "RF-00000002-CHE", "RF-00000006-CHE", "RF-00000013-CHE", "RF-00000020-CHE", "RF-00000025-CHE", "RF-00000029-CHE", "RF-00000048-CHE", "RF-00000052-CHE", "RF-00000059-CHE", "RF-00000066-CHE", "RF-00000071-CHE", "RF-00000080-CHE", "RF-00000103-CHE", "RF-00000110-CHE", "RF-00000123-CHE", "RF-00000125-CHE", "RF-00000127-CHE", "RF-00000142-CHE", "RF-00000144-CHE", "RF-00000146-CHE", "RF-00000149-CHE", "RF-00000151-CHE", "RF-00000160-CHE", "RF-00000163-CHE", "RF-00000166-CHE", "RF-00000169-CHE", "RF-00000171-CHE", "RF-00000173-CHE", "RF-00000175-CHE", "RF-00000178-CHE", "RF-00000181-CHE", "RF-00000183-CHE", "RF-00000188-CHE", "RF-00000190-CHE", "RF-00000192-CHE", "RF-00000194-CHE", "RF-00000196-CHE", "RF-00000198-CHE", "RF-00000200-CHE", "RF-00000202-CHE", "RF-00000204-CHE", "RF-00001449-PAR" };

            var outcome = new Outcome();
            outcome.name = "VMPR016";
            outcome.lastupdate = "2017-03-16";
            outcome.description = "If the value in 'Parameter code' (paramCode) belongs to the group B3c (chemical elements used in vmpr), then a value in the data element 'Result LOQ' (resLOQ) should be reported;";
            outcome.error = "WARNING: resLOQ is missing, though paramCode belongs to the group B3c (chemical elements used in vmpr);";
            outcome.type = "warning";
            outcome.passed = true;


            if (grupp.Contains(paramCode))
            {
                outcome.passed = !string.IsNullOrEmpty(resLOQ);

            }
            
            return outcome;
        }
        ///A value in at least one of the following data elements must be reported: 'Result LOQ' (resLOQ) or 'CC beta' (CCbeta) or 'CC alpha' (CCalpha);
        public Outcome VMPR017(XElement sample)
        {
            // <checkedDataElements>;
            var resLOQ = (string)sample.Element("resLOQ");
            var CCbeta = (string)sample.Element("CCbeta");
            var CCalpha = (string)sample.Element("CCalpha");

            var outcome = new Outcome();
            outcome.name = "VMPR017";
            outcome.lastupdate = "2017-03-16";
            outcome.description = "A value in at least one of the following data elements must be reported: 'Result LOQ' (resLOQ) or 'CC beta' (CCbeta) or 'CC alpha' (CCalpha);";
            outcome.error = "WARNING: None of the following data elements is reported, though at least one is mandatory: resLOQ, or CCbeta, or CCalpha;";
            outcome.type = "warning";
            outcome.passed = !(string.IsNullOrEmpty(resLOQ) && string.IsNullOrEmpty(CCalpha) &&string.IsNullOrEmpty(CCbeta));
            return outcome;
        }
        ///If the value in the data element 'Accreditation procedure for the analytical method' (accredProc) is 'Accredited and validated according to Com. Dec. 2002/657/EC' (V007A) and the value in the data element 'Analytical method type' (anMethType) is 'Confirmation' (AT08A) and the value in 'Typer of parameter' (paramType) is not equal to 'Part of a sum' (P002A), and the value in 'Parameter code' (paramCode) doesn't belong to group B3c (chemical elements used in vmpr), then a value in the data element 'CC alpha' (CCalpha) must be reported;
        public Outcome VMPR018(XElement sample)
        {
            // <checkedDataElements>;
            var paramCode = (string)sample.Element("paramCode");
            var accredProc = (string)sample.Element("accredProc");
            var anMethType = (string)sample.Element("anMethType");
            var paramType = (string)sample.Element("paramType");
            var CCalpha = (string)sample.Element("CCalpha");

            string[] b3c = { "RF-00000001-RAD", "RF-00000002-CHE", "RF-00000006-CHE", "RF-00000013-CHE", "RF-00000020-CHE", "RF-00000025-CHE", "RF-00000029-CHE", "RF-00000048-CHE", "RF-00000052-CHE", "RF-00000059-CHE", "RF-00000066-CHE", "RF-00000071-CHE", "RF-00000080-CHE", "RF-00000103-CHE", "RF-00000110-CHE", "RF-00000123-CHE", "RF-00000125-CHE", "RF-00000127-CHE", "RF-00000142-CHE", "RF-00000144-CHE", "RF-00000146-CHE", "RF-00000149-CHE", "RF-00000151-CHE", "RF-00000160-CHE", "RF-00000163-CHE", "RF-00000166-CHE", "RF-00000169-CHE", "RF-00000171-CHE", "RF-00000173-CHE", "RF-00000175-CHE", "RF-00000178-CHE", "RF-00000181-CHE", "RF-00000183-CHE", "RF-00000188-CHE", "RF-00000190-CHE", "RF-00000192-CHE", "RF-00000194-CHE", "RF-00000196-CHE", "RF-00000198-CHE", "RF-00000200-CHE", "RF-00000202-CHE", "RF-00000204-CHE", "RF-00001449-PAR" };
            var outcome = new Outcome();
            outcome.name = "VMPR018";
            outcome.lastupdate = "2017-03-16";
            outcome.description = "If the value in the data element 'Accreditation procedure for the analytical method' (accredProc) is 'Accredited and validated according to Com. Dec. 2002/657/EC' (V007A) and the value in the data element 'Analytical method type' (anMethType) is 'Confirmation' (AT08A) and the value in 'Typer of parameter' (paramType) is not equal to 'Part of a sum' (P002A), and the value in 'Parameter code' (paramCode) doesn't belong to group B3c (chemical elements used in vmpr), then a value in the data element 'CC alpha' (CCalpha) must be reported;";
            outcome.error = "CCalpha is missing, though mandatory if accredProc is accredited and validated according to Com. Dec. 2002/657/EC and anMethType is confirmation and paramType is not part of a sum and paramCode is not in group B3c (chemical elements used in vmpr);";
            outcome.type = "error";
            outcome.passed = true;
            if (accredProc == "V007A" && anMethType == "AT08A" && paramType != "P002A" && b3c.Contains(paramCode) == false)
            {
                outcome.passed = string.IsNullOrEmpty(CCalpha);
            }
            return outcome;
        }
        ///If the value in the data element 'Accreditation procedure for the analytical method' (accredProc) is 'Accredited and validated according to Com. Dec. 2002/657/EC' (V007A) and the value in the data element 'Analytical method type' (anMethType) is 'Screening' (AT06A), and the value in 'Parameter code' (paramCode) doesn't belong to group B3c (chemical elements used in vmpr), then a value in the data element 'CC beta' (CCbeta) must be reported
        public Outcome VMPR019(XElement sample)
        {
            // <checkedDataElements>;
            var paramCode = (string)sample.Element("paramCode");
            var accredProc = (string)sample.Element("accredProc");
            var anMethType = (string)sample.Element("anMethType");
            var CCbeta = (string)sample.Element("CCbeta");
            string[] b3c = { "RF-00000001-RAD", "RF-00000002-CHE", "RF-00000006-CHE", "RF-00000013-CHE", "RF-00000020-CHE", "RF-00000025-CHE", "RF-00000029-CHE", "RF-00000048-CHE", "RF-00000052-CHE", "RF-00000059-CHE", "RF-00000066-CHE", "RF-00000071-CHE", "RF-00000080-CHE", "RF-00000103-CHE", "RF-00000110-CHE", "RF-00000123-CHE", "RF-00000125-CHE", "RF-00000127-CHE", "RF-00000142-CHE", "RF-00000144-CHE", "RF-00000146-CHE", "RF-00000149-CHE", "RF-00000151-CHE", "RF-00000160-CHE", "RF-00000163-CHE", "RF-00000166-CHE", "RF-00000169-CHE", "RF-00000171-CHE", "RF-00000173-CHE", "RF-00000175-CHE", "RF-00000178-CHE", "RF-00000181-CHE", "RF-00000183-CHE", "RF-00000188-CHE", "RF-00000190-CHE", "RF-00000192-CHE", "RF-00000194-CHE", "RF-00000196-CHE", "RF-00000198-CHE", "RF-00000200-CHE", "RF-00000202-CHE", "RF-00000204-CHE", "RF-00001449-PAR" };

            var outcome = new Outcome();
            outcome.name = "VMPR019";
            outcome.lastupdate = "2016-05-10";
            outcome.description = "If the value in the data element 'Accreditation procedure for the analytical method' (accredProc) is 'Accredited and validated according to Com. Dec. 2002/657/EC' (V007A) and the value in the data element 'Analytical method type' (anMethType) is 'Screening' (AT06A), and the value in 'Parameter code' (paramCode) doesn't belong to group B3c (chemical elements used in vmpr), then a value in the data element 'CC beta' (CCbeta) must be reported";
            outcome.error = "CCbeta is missing, though mandatory if accredProc is accredited and validated according to Com. Dec. 2002/657/EC and anMethType is screening and paramCode is not in group B3c (chemical elements used in vmpr);";
            outcome.type = "error";
            outcome.passed = true;

            if (accredProc == "V007A" && anMethType == "AT06A"  && b3c.Contains(paramCode) == false)
            {
                outcome.passed = string.IsNullOrEmpty(CCbeta);
            }
          
            return outcome;
        }

        ///If the value in the data element 'Accreditation procedure for the analytical method' (accredProc) is 'Accredited and validated according to Com. Dec. 2002/657/EC' (V007A), then the value in the data element 'CC beta' (CCbeta) should be reported;
        public Outcome VMPR020(XElement sample)
        {
            // <checkedDataElements>;
            var accredProc = (string)sample.Element("accredProc");
            var CCbeta = (string)sample.Element("CCbeta");

            var outcome = new Outcome();
            outcome.name = "VMPR020";
            outcome.lastupdate = "2016-05-10";
            outcome.description = "If the value in the data element 'Accreditation procedure for the analytical method' (accredProc) is 'Accredited and validated according to Com. Dec. 2002/657/EC' (V007A), then the value in the data element 'CC beta' (CCbeta) should be reported;";
            outcome.error = "WARNING: CCbeta is missing, though recommended if accredProc is accredited and validated according to Com. Dec. 2002/657/E;";
            outcome.type = "warning";
            outcome.passed = true;

            //Logik (ignore null: no);
            if (accredProc == "V007A")
            {
                outcome.passed = !String.IsNullOrEmpty(CCbeta);
            }
             return outcome;
        }
        ///The value in the data element 'Result qualitative value' (resQualValue) must be equal to 'negative/absent' (NEG), because neither positive screening results nor qualitative confirmation results should be reported;
        public Outcome VMPR021(XElement sample)
        {
            // <checkedDataElements>;
            var resQualValue = (string)sample.Element("resQualValue");

            var outcome = new Outcome();
            outcome.name = "VMPR021";
            outcome.lastupdate = "2016-05-10";
            outcome.description = "The value in the data element 'Result qualitative value' (resQualValue) must be equal to 'negative/absent' (NEG), because neither positive screening results nor qualitative confirmation results should be reported;";
            outcome.error = "resQualValue is different from negative/absent;";
            outcome.type = "error";
            outcome.passed = true;

            //Logik (ignore null: yes);
            if (!String.IsNullOrEmpty(resQualValue))
            {
                var resQualValues = new List<string>();
                resQualValues.Add("NEG");
                outcome.passed = resQualValues.Contains(resQualValue);

            }
            return outcome;
        }
        ///If the value in the data element 'Analytical method type' (anMethType) is 'Screening' (AT06A), then the value in 'Type of results' (resType) should be equal to 'Qualitative value (binary)' (BIN) and the value in 'Result value' (resVal) should not be reported;
        public Outcome VMPR022(XElement sample)
        {
            // <checkedDataElements>;
            var anMethType = (string)sample.Element("anMethType");
            var resType = (string)sample.Element("resType");
            var resVal = (string)sample.Element("resVal");

            var outcome = new Outcome();
            outcome.name = "VMPR022";
            outcome.lastupdate = "2017-03-16";
            outcome.description = "If the value in the data element 'Analytical method type' (anMethType) is 'Screening' (AT06A), then the value in 'Type of results' (resType) should be equal to 'Qualitative value (binary)' (BIN) and the value in 'Result value' (resVal) should not be reported;";
            outcome.error = "WARNING: resType is different from binary or resVal is reported, though anMethType is screening;";
            outcome.type = "warning";
            outcome.passed = true;

            //Logik (ignore null: no);
            if (anMethType == "AT06A")
            {
                var resTypes = new List<string>();
                resTypes.Add("BIN");
                outcome.passed = resTypes.Contains(resType) && string.IsNullOrEmpty(resVal);
            }
            
            return outcome;
        }
        ///If the value in the data element 'Analytical method type' (anMethType) is  'Confirmation' (AT08A), then the value in 'Type of results' (resType) should be equal to 'non detected value (below LOD)' (LOD), or 'non quantified value (below LOQ)' (LOQ), or 'numerical value' (VAL), or 'value below CCalpha (below CC alpha)' (CCA), and the value in 'Result qualitative value' (resQualValue) should not be reported;
        public Outcome VMPR023(XElement sample)
        {
            // <checkedDataElements>;
            var anMethType = (string)sample.Element("anMethType");
            var resType = (string)sample.Element("resType");
            var resQualValue = (string)sample.Element("resQualValue");

            var outcome = new Outcome();
            outcome.name = "VMPR023";
            outcome.lastupdate = "2017-03-16";
            outcome.description = "If the value in the data element 'Analytical method type' (anMethType) is  'Confirmation' (AT08A), then the value in 'Type of results' (resType) should be equal to 'non detected value (below LOD)' (LOD), or 'non quantified value (below LOQ)' (LOQ), or 'numerical value' (VAL), or 'value below CCalpha (below CC alpha)' (CCA), and the value in 'Result qualitative value' (resQualValue) should not be reported;";
            outcome.error = "WARNING: resType is different from LOD, LOQ, VAL, CCA or resQualValue is reported, though anMethType is confirmation;";
            outcome.type = "warning";
            outcome.passed = true;

            //Logik (ignore null: no);
            if (anMethType == "AT08A")
            {
                var resTypes = new List<string>();
                resTypes.Add("LOD");
                resTypes.Add("LOQ");
                resTypes.Add("VAL");
                resTypes.Add("CCA");
                outcome.passed = resTypes.Contains(resType) && String.IsNullOrEmpty(resQualValue);
            }
            
            return outcome;
        }
        ///The value in the data element 'Type of result' (resType), must be equal to 'non detected value (below LOD)' (LOD), or 'non quantified value (below LOQ)' (LOQ), or 'numerical value' (VAL), or 'value below CCalpha (below CC alpha)' (CCA), or 'value below CCbeta (below CC beta)' (CCB), or 'qualitative value (Binary)' (BIN), or 'Value above the upper limit of the working range' (AWR);
        public Outcome VMPR024(XElement sample)
        {
            // <checkedDataElements>;
            var resType = (string)sample.Element("resType");

            var outcome = new Outcome();
            outcome.name = "VMPR024";
            outcome.lastupdate = "2017-03-16";
            outcome.description = "The value in the data element 'Type of result' (resType), must be equal to 'non detected value (below LOD)' (LOD), or 'non quantified value (below LOQ)' (LOQ), or 'numerical value' (VAL), or 'value below CCalpha (below CC alpha)' (CCA), or 'value below CCbeta (below CC beta)' (CCB), or 'qualitative value (Binary)' (BIN), or 'Value above the upper limit of the working range' (AWR);";
            outcome.error = "resType is different from LOD, LOQ, VAL, CCA, CCB, BIN, and AWR;";
            outcome.type = "error";
            outcome.passed = true;

            //Logik (ignore null: yes);
            if (!String.IsNullOrEmpty(resType))
            {
                var resTypes = new List<string>();
                resTypes.Add("LOD");
                resTypes.Add("LOQ");
                resTypes.Add("VAL");
                resTypes.Add("CCA");
                resTypes.Add("CCB");
                resTypes.Add("BIN");
                resTypes.Add("AWR");
                outcome.passed = resTypes.Contains(resType);

            }
            return outcome;
        }
        ///If a value in the data element 'Result value' (resVal) is reported and 'CC alpha' (CCalpha) is not reported, then a value in at least one of the following data elements should be reported: 'Result value uncertainty' (resValUncert) or 'Result value uncertainty Standard deviation' (resValUncertSD), i.e. precision must be determined for quantitative results;
        public Outcome VMPR025(XElement sample)
        {
            // <checkedDataElements>;
            var resVal = (string)sample.Element("resVal");
            var CCalpha = (string)sample.Element("CCalpha");
            var resValUncert = (string)sample.Element("resValUncert");
            var resValUncertSD = (string)sample.Element("resValUncertSD");

            var outcome = new Outcome();
            outcome.name = "VMPR025";
            outcome.lastupdate = "2017-03-16";
            outcome.description = "If a value in the data element 'Result value' (resVal) is reported and 'CC alpha' (CCalpha) is not reported, then a value in at least one of the following data elements should be reported: 'Result value uncertainty' (resValUncert) or 'Result value uncertainty Standard deviation' (resValUncertSD), i.e. precision must be determined for quantitative results;";
            outcome.error = "WARNING: resValUncert and resValUncertSD are missing, though at least one is recommended when resVal is reported and CCalpha is missing;";
            outcome.type = "warning";
            outcome.passed = true;

            //Logik (ignore null: no);
            if (string.IsNullOrEmpty(CCalpha) && !string.IsNullOrEmpty(resVal))
            {
                var resVals = new List<string>();
                ///TESTING
                outcome.passed = !string.IsNullOrEmpty(resValUncert) || !string.IsNullOrEmpty(resValUncertSD);
            }
            return outcome;
        }
        ///The value in the data element 'Type of limit for the result evaluation' (evalLimitType) should be equal to 'Maximum Residue Level (MRL)' (W002A), or 'Minimum Required Performance Limit (MRPL)' (W005A), or 'Reference point of action (RPA)' (W006A), or 'Presence' (W012A), or 'Maximum Limit' (W001A);
        public Outcome VMPR026(XElement sample)
        {
            // <checkedDataElements>;
            var evalLimitType = (string)sample.Element("evalLimitType");

            var outcome = new Outcome();
            outcome.name = "VMPR026";
            outcome.lastupdate = "2017-03-16";
            outcome.description = "The value in the data element 'Type of limit for the result evaluation' (evalLimitType) should be equal to 'Maximum Residue Level (MRL)' (W002A), or 'Minimum Required Performance Limit (MRPL)' (W005A), or 'Reference point of action (RPA)' (W006A), or 'Presence' (W012A), or 'Maximum Limit' (W001A);";
            outcome.error = "WARNING: evalLimitType is not in the list of recommended codes;";
            outcome.type = "warning";
            outcome.passed = true;

            //Logik (ignore null: yes);
            if (!String.IsNullOrEmpty(evalLimitType))
            {
                var evalLimitTypes = new List<string>();
                evalLimitTypes.Add("W002A");
                evalLimitTypes.Add("W005A");
                evalLimitTypes.Add("W006A");
                evalLimitTypes.Add("W012A");
                evalLimitTypes.Add("W001A");
                outcome.passed = evalLimitTypes.Contains(evalLimitType);

            }
            return outcome;
        }
        ///If a value in the data element 'Result value' (resVal) is reported and the value in the data element 'Type of limit for the result evaluation' (evalLimitType) is different from 'Presence' (W012A), then a a value in the data element 'Limit for the result evaluation' (evalLowLimit) should be reported;
        public Outcome VMPR027(XElement sample)
        {
            // <checkedDataElements>;
            var resVal = (string)sample.Element("resVal");
            var evalLimitType = (string)sample.Element("evalLimitType");
            var evalLowLimit = (string)sample.Element("evalLowLimit");

            var outcome = new Outcome();
            outcome.name = "VMPR027";
            outcome.lastupdate = "2016-05-10";
            outcome.description = "If a value in the data element 'Result value' (resVal) is reported and the value in the data element 'Type of limit for the result evaluation' (evalLimitType) is different from 'Presence' (W012A), then a a value in the data element 'Limit for the result evaluation' (evalLowLimit) should be reported;";
            outcome.error = "WARNING: evalLowLimit is missing, though recommended when resVal is reported and evalLimitType is different from presence;";
            outcome.type = "warning";
            outcome.passed = true;

            //Logik (ignore null: no);
            if (!string.IsNullOrEmpty(resVal) && evalLimitType == "W012A")
            {
                outcome.passed = !String.IsNullOrEmpty(evalLowLimit);
            }
            return outcome;
        }
        ///If the value in the data element 'Evaluation of the result' (evalCode) is different from 'Not detected' (J040A) and 'Result not evaluated' (J029A), then a value in the data element 'Type of limit for the result evaluation' (evalLimitType) should be reported;
        public Outcome VMPR028(XElement sample)
        {
            // <checkedDataElements>;
            var evalCode = (string)sample.Element("evalCode");
            var evalLimitType = (string)sample.Element("evalLimitType");

            var outcome = new Outcome();
            outcome.name = "VMPR028";
            outcome.lastupdate = "2016-05-10";
            outcome.description = "If the value in the data element 'Evaluation of the result' (evalCode) is different from 'Not detected' (J040A) and 'Result not evaluated' (J029A), then a value in the data element 'Type of limit for the result evaluation' (evalLimitType) should be reported;";
            outcome.error = "WARNING: evalLimitType is missing, though recommended when evalCode is neither 'not detected' nor 'result not evaluated';";
            outcome.type = "warning";
            outcome.passed = true;

          
                var evalCodes = new List<string>();
                evalCodes.Add("J040A");
                evalCodes.Add("J029A");
                ///TESTING
                if (evalCodes.Contains(evalCode))
                {
                    outcome.passed = !String.IsNullOrEmpty(evalLimitType);
                }
            return outcome;
        }
        ///The value in the data element 'Evaluation of the result' (evalCode) must be equal to 'Detected' (J041A), or 'Not detected' (J040A), or 'Above maximum permissible quantities' (J003A), or 'Less than or equal to maximum permissible quantities' (J002A), or 'Compliant due to measurement uncertainty' (J031A), or 'Result not evaluated' (J029A);
        public Outcome VMPR029(XElement sample)
        {
            // <checkedDataElements>;
            var evalCode = (string)sample.Element("evalCode");

            var outcome = new Outcome();
            outcome.name = "VMPR029";
            outcome.lastupdate = "2016-05-10";
            outcome.description = "The value in the data element 'Evaluation of the result' (evalCode) must be equal to 'Detected' (J041A), or 'Not detected' (J040A), or 'Above maximum permissible quantities' (J003A), or 'Less than or equal to maximum permissible quantities' (J002A), or 'Compliant due to measurement uncertainty' (J031A), or 'Result not evaluated' (J029A);";
            outcome.error = "evalCode is not in the allowed list of codes;";
            outcome.type = "error";
            outcome.passed = true;

            //Logik (ignore null: yes);
            if (!String.IsNullOrEmpty(evalCode))
            {
                var evalCodes = new List<string>();
                evalCodes.Add("J041A");
                evalCodes.Add("J040A");
                evalCodes.Add("J003A");
                evalCodes.Add("J002A");
                evalCodes.Add("J031A");
                evalCodes.Add("J029A");
                outcome.passed = evalCodes.Contains(evalCode);

            }
            return outcome;
        }
        ///If the value in the data element 'Type of limit for the result evaluation' (evalLimitType) is equal to 'Maximum Residue Level (MRL)' (W002A), then the value in 'Evaluation of the result' (evalCode) should be equal to 'Less than or equal to maximum permissible quantities' (J002A), or 'Greater than maximum permissible quantities' (J003A), or 'Compliant due to measurement uncertainty' (J031A), or 'result not evaluated' (J029A);
        public Outcome VMPR030(XElement sample)
        {
            // <checkedDataElements>;
            var evalLimitType = (string)sample.Element("evalLimitType");
            var evalCode = (string)sample.Element("evalCode");

            var outcome = new Outcome();
            outcome.name = "VMPR030";
            outcome.lastupdate = "2017-03-17";
            outcome.description = "If the value in the data element 'Type of limit for the result evaluation' (evalLimitType) is equal to 'Maximum Residue Level (MRL)' (W002A), then the value in 'Evaluation of the result' (evalCode) should be equal to 'Less than or equal to maximum permissible quantities' (J002A), or 'Greater than maximum permissible quantities' (J003A), or 'Compliant due to measurement uncertainty' (J031A), or 'result not evaluated' (J029A);";
            outcome.error = "WARNING: evalCode is not in the recommended list of codes when evalLimitType is MRL;";
            outcome.type = "warning";
            outcome.passed = true;

            //Logik (ignore null: yes);
            if (evalLimitType == "W002A")
            {
                var evalCodes = new List<string>();
                evalCodes.Add("J002A");
                evalCodes.Add("J003A");
                evalCodes.Add("J031A");
                evalCodes.Add("J029A");
                outcome.passed = evalCodes.Contains(evalCode);

            }
           
            return outcome;
        }
        ///If the value in the data element 'Type of limit for the result evaluation' (evalLimitType) is equal to 'Presence' (W012A), then the value in 'Evaluation of the result' (evalCode) should be equal to 'Not detected' (J040A), or 'Detected' (J041A);
        public Outcome VMPR031(XElement sample)
        {
            // <checkedDataElements>;
            var evalLimitType = (string)sample.Element("evalLimitType");
            var evalCode = (string)sample.Element("evalCode");

            var outcome = new Outcome();
            outcome.name = "VMPR031";
            outcome.lastupdate = "2017-03-17";
            outcome.description = "If the value in the data element 'Type of limit for the result evaluation' (evalLimitType) is equal to 'Presence' (W012A), then the value in 'Evaluation of the result' (evalCode) should be equal to 'Not detected' (J040A), or 'Detected' (J041A);";
            outcome.error = "WARNING: evalCode is not in the recommended list of codes when evalLimitType is presence;";
            outcome.type = "warning";
            outcome.passed = true;

            //Logik (ignore null: yes);
            if (evalLimitType == "W012A")
            {
                var evalCodes = new List<string>();
                evalCodes.Add("J040A");
                evalCodes.Add("J041A");
                outcome.passed = evalCodes.Contains(evalCode);
            }
            
            return outcome;
        }
        ///A value in 'Sample taken assessment' (evalInfo.sampTkAsses) must be reported;
        public Outcome VMPR032(XElement sample)
        {
            // <checkedDataElements>;
            var evalInfosampTkAsses = (string)sample.Element("evalInfo.sampTkAsses");

            var outcome = new Outcome();
            outcome.name = "VMPR032";
            outcome.lastupdate = "2017-03-16";
            outcome.description = "A value in 'Sample taken assessment' (evalInfo.sampTkAsses) must be reported;";
            outcome.error = "evalInfo.sampTkAsses and evalInfo.sampEventAsses are missing, though at least one is mandatory;";
            outcome.type = "error";
            outcome.passed = true;

            //Logik (ignore null: no);
            if (1 == 1)
            {

                outcome.passed = !String.IsNullOrEmpty(evalInfosampTkAsses);

            }
            return outcome;
        }
        ///If the value in the data elements 'Sample taken assessment' (evalInfo.sampTkAsses) or 'Sampling event assessment' (evalInfo.sampEventAsses) is equal to 'Non-compliant' (J038A), then a value in the data element 'Action taken' (actTakenCode) must be reported;
        public Outcome VMPR034(XElement sample)
        {
            // <checkedDataElements>;
            var evalInfosampTkAsses = (string)sample.Element("evalInfo.sampTkAsses");
            var evalInfosampEventAsses = (string)sample.Element("evalInfo.sampEventAsses");
            var actTakenCode = (string)sample.Element("actTakenCode");

            var outcome = new Outcome();
            outcome.name = "VMPR034";
            outcome.lastupdate = "2016-05-10";
            outcome.description = "If the value in the data elements 'Sample taken assessment' (evalInfo.sampTkAsses) or 'Sampling event assessment' (evalInfo.sampEventAsses) is equal to 'Non-compliant' (J038A), then a value in the data element 'Action taken' (actTakenCode) must be reported;";
            outcome.error = "actTakenCode is missing, though mandatory when evalInfo.sampTkAsses or evalInfo.sampEventAsses are non-compliant;";
            outcome.type = "error";
            outcome.passed = true;

            //Logik (ignore null: no);
            if (evalInfosampTkAsses == "J038A" || evalInfosampEventAsses == "J038A")
            {
               
                outcome.passed = !String.IsNullOrEmpty(actTakenCode);

            }
            return outcome;
        }
        ///The value in the data element 'Sample taken assessment' (evalInfo.sampTkAsses) and the value in the data element 'Sampling event assessment' (evalInfo.sampEventAsses) must be equal to 'Compliant' (J037A), or 'Non-compliant' (J038A);
        public Outcome VMPR035(XElement sample)
        {
            // <checkedDataElements>;
            var evalInfosampTkAsses = (string)sample.Element("evalInfo.sampTkAsses");
            var evalInfosampEventAsses = (string)sample.Element("evalInfo.sampEventAsses");

            var outcome = new Outcome();
            outcome.name = "VMPR035";
            outcome.lastupdate = "2016-05-10";
            outcome.description = "The value in the data element 'Sample taken assessment' (evalInfo.sampTkAsses) and the value in the data element 'Sampling event assessment' (evalInfo.sampEventAsses) must be equal to 'Compliant' (J037A), or 'Non-compliant' (J038A);";
            outcome.error = "Neither evalInfo.sampTkAsses nor evalInfo.sampEventAsses are compliant or non-compliant;";
            outcome.type = "error";
            outcome.passed = true;

            //Logik (ignore null: yes);
            if (!String.IsNullOrEmpty(evalInfosampTkAsses) || !String.IsNullOrEmpty(evalInfosampEventAsses))
            {
                var evalInfosampTkAssess = new List<string>();
                evalInfosampTkAssess.Add("J037A");
                evalInfosampTkAssess.Add("J038A");
                outcome.passed = evalInfosampTkAssess.Contains(evalInfosampTkAsses);

                var evalInfosampEventAssess = new List<string>();
                evalInfosampEventAssess.Add("J037A");
                evalInfosampEventAssess.Add("J038A");
                outcome.passed = evalInfosampEventAssess.Contains(evalInfosampEventAsses);

            }
            return outcome;
        }
        ///If the value in the data elemente 'Action Taken' (actTakenCode) is equal to 'Follow-up investigation' (I), then a value in the data element 'Conclusion of follow-up investigation' (evalInfo.conclusion) must be reported;
        public Outcome VMPR036(XElement sample)
        {
            // <checkedDataElements>;
            var actTakenCode = (string)sample.Element("actTakenCode");
            var evalInfoconclusion = (string)sample.Element("evalInfo.conclusion");

            var outcome = new Outcome();
            outcome.name = "VMPR036";
            outcome.lastupdate = "2016-05-10";
            outcome.description = "If the value in the data elemente 'Action Taken' (actTakenCode) is equal to 'Follow-up investigation' (I), then a value in the data element 'Conclusion of follow-up investigation' (evalInfo.conclusion) must be reported;";
            outcome.error = "evalInfo.conclusion is missing, though actTakenCode is follow-up investigation;";
            outcome.type = "error";
            outcome.passed = true;

            //Logik (ignore null: no);
            if (actTakenCode == "I")
            {
                outcome.passed = !String.IsNullOrEmpty(evalInfoconclusion);
            }
            
            return outcome;
        }
        ///The value in the data element 'Sampling point' (sampPoint) should be different from 'Unspecified', 'Others' and 'Unknown';
        public Outcome VMPR037(XElement sample)
        {
            // <checkedDataElements>;
            var sampPoint = (string)sample.Element("sampPoint");

            var outcome = new Outcome();
            outcome.name = "VMPR037";
            outcome.lastupdate = "2016-05-10";
            outcome.description = "The value in the data element 'Sampling point' (sampPoint) should be different from 'Unspecified', 'Others' and 'Unknown';";
            outcome.error = "WARNING: sampPoint is reported as unspecified, or others, or unknown, though these values should not be reported;";
            outcome.type = "warning";
            outcome.passed = true;

            //Logik (ignore null: yes);
            if (!String.IsNullOrEmpty(sampPoint))
            {
                var sampPoints = new List<string>();
                sampPoints.Add("E098A");
                sampPoints.Add("E099A");
                sampPoints.Add("E980A");
                outcome.passed = sampPoints.Contains(sampPoint);

            }
            return outcome;
        }
        ///The value in 'Coded description of the matrix of the sample taken' (sampMatCode) should be equal to the value in 'Coded description of the analysed matrix' (anMatCode);
        public Outcome VMPR038(XElement sample)
        {
            // <checkedDataElements>;
            var sampMatCode = (string)sample.Element("sampMatCode");
            var anMatCode = (string)sample.Element("anMatCode");

            var outcome = new Outcome();
            outcome.name = "VMPR038";
            outcome.lastupdate = "2017-04-20";
            outcome.description = "The value in 'Coded description of the matrix of the sample taken' (sampMatCode) should be equal to the value in 'Coded description of the analysed matrix' (anMatCode);";
            outcome.error = "anMatCode is different from sampMatCode, though the matrix sampled should be equal to the analysed matrix;";
            outcome.type = "error";
            outcome.passed = true;

            //Logik (ignore null: yes);
            outcome.passed = sampMatCode == anMatCode;

            return outcome;
        }
    }
   


}
