using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EfsaBusinessRuleValidator
{
    class VmprBusinessRules
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
            if (paramCode"RF-0108-003-PPP")
{
            }
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
               
                outcome.passed = paramCodes.Contains(paramCode);
                var paramTypes = new List<string>();
                paramTypes.Add("P002A");
                outcome.passed = paramTypes.Contains(paramType);

            }
            return outcome;
        }
    }
}
