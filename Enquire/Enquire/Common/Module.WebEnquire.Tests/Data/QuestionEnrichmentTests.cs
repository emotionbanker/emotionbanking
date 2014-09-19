using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using compucare.Enquire.Legacy.Umfrage2Lib.circular;
using NUnit.Framework;

namespace Compucare.Enquire.Common.Module.WebEnquire.Tests.Data
{
    [TestFixture]
    public class QuestionEnrichmentTests
    {
        [Test]
        public void QuestionnaireInfoTest()
        {
            QuestionnaireInfo info = new QuestionnaireInfo();

            info.Code = GetCode();

            info.ComputeAlii();
        }


        private String GetCode()
        {
            return @"1;#;

#Wir beginnen mit Fragen zu dem Image der Bank;

#Wenn ich an diese Bank denke, verbinde ich damit folgende Eigenschaften. Die Bank ist ...;634!4;2187!4;2188!4;2189!4;2194!4;74!4;639!4;640/1!4;1647!4;638!4;77!4;75!4;2192!4;2193!4;@;

1496;#;1649;#;1537;#;2738;#;3037!4;@;

#Denken Sie bitte an den Service und die Leistungen Ihrer Bank.;#;#Diese Bank bietet mir:;643;644;2537;646;1348;1352;1353;1354;1502;1166;1356;1357;1358;1359;1360;1361;1362;@;

#<font size=4>Abwicklung Ihres Bankgeschäftes</font>; #Wie häufig nutzen Sie die folgenden Möglichkeiten zur Abwicklung des Bankgeschäftes?;63!4;64!4;#; #<font size=4>Informationsverhalten der Bank</font>;2543;110/1;135;136;@;

#<font size=4>Produktnutzung</font>;2355;#;2356;@;

wenn(2355.5) (#<font size=4>Finanzierung/Kredite</font>,
#Wie sehr treffen folgende Aussagen über Finanzierung/Kredite auf Ihre Bank zu?,2849,2850,2851,2857,2858,2852,2853,2854,2855,2856,2859,2860,2861,2862,2863,2864,#,2865);#;

#<font size=4>Beratung</font>;#Kommen wir nun zur Beratung in dieser Bank.;1501;@;

wenn(1501.1|1501.2|1501.3) (709,1129,#,#Bitte beurteilen Sie die Qualität der Betreuung durch Ihren Kundenberater. Wie sehr treffen die folgenden Kriterien auf Ihren Berater zu?,1584,2425,2423,648,1131,649,43,41,48,1497,2430,2866,142,1499,1500,1512,1513/1,1514,1644,@,144!2,#,#Falls es im letzten Jahr zu einem Wechsel des Kundenberaters gekommen ist:,145,#,146);#;2357!5;@;

wenn (1501.4|1501.5) (2280);#;

#Hätten Sie gerne (mehr) Beratung zu folgenden Bereichen?;1571/3;1567/3;2206/1;2207/1;1719/2;1720/2;2205;1721/1;2560;2559;2208;@;

#<font size=4>Zufriedenheit</font>;#Natürlich erlebt man die Bank einmal besser, einmal schlechter. Aus diesen Erlebnissen formt sich ein Gesamteindruck der Bank. Bitte denken Sie an alle Erfahrungen, die Sie im Laufe der Zeit mit dieser Bank gemacht haben.;#;#Alles in allem, wie zufrieden sind Sie in Ihrer Bank mit ...;11;1504;2221;2431;2984;1505;1507;3038;651;1287/1;35;2201;54/1;70;138;653;147;@;

107/1;@;

wenn(107/1.1|107/1.2|107/1.3|107/1.4)(655,#,108/1,#,656);#;#;

#<font size=4>Verbundenheit</font>;#Wir kommen nun zu Ihrer Beziehung mit der Bank.;281/2;#;L2986/1;#;2561;#;1110;@;

#Bitte geben Sie an, wie sehr die Aussagen auf Sie zutreffen.;238;1645;101;1517;658;242;1659;1660;1516;1565;2182;2202/2;2796;2797/1;@;

wenn (658.4|658.5) (2539);#;

#Wir kommen nun zu den letzten Fragen. Stellen Sie sich das Angebot einer Bank vor, deren Leistung und Service Ihren Erwartungen in vollem Umfang entsprechen, also ein Institut, bei dem Sie gerne Kunde sind ...;#;#Was sollte die Bank Ihrer Träume bieten? Was wäre für Sie attraktiv?;659;660;2538;662;1369;1370;1371;1503;1412;1304;1373;1374;1375;1376;1377;1378;1379;@;

#<font size=4>Statistische Angaben</font>;#Wir bitten Sie nun, einige Angaben zu Ihrem Unternehmen zu machen, die selbstverständlich vollkommen anonym und nur statistisch ausgewertet werden;2985/1;#;2794;#;L2868;#;L2415;#;2581/2;#;2222/2;@;";

            /*
            return @"2694;#;

#Wir beginnen mit Fragen zu Ihrer Entscheidung für die Raiffeisenbank Stockerau und dem Image der Bank.;#Ich habe mich für die Raiffeisenbank Stockerau entschieden wegen ...;88!4;89!4;90!4;91!4;92!4;93!4;94!4;95!4;97!4;1734!4;1735!4;734!4;2426!4;2540!4;2541!4;2542!4;@;

#Wenn ich an die Raiffeisenbank Stockerau denke, verbinde ich damit folgende Eigenschaften. Die Bank ist ...;634!4;2187!4;2188!4;2189!4;2194!4;74!4;639!4;640/1!4;1647!4;638!4;77!4;75!4;2192!4;2193!4;@;

1496;#;1649;#;1537;@;

#Denken Sie bitte an den Service und die Leistungen Ihrer Bank.;#;#Die Raiffeisenbank Stockerau bietet
mir:;643;644;645;646;1348;1352;1353;1354;1502;1166;1356;1357;1358;1359;1360;1361;1362;@;

#<font size=4>Informationsquellen</font>;#Wie häufig beziehen Sie relevante Informationen für Ihre Finanzentscheidungen über folgende Quellen?;
111!4;112!4;114!4;115!4;116!4;117!4;119!4;120!4;121!4;122!4;1494!4;2422!4;@;

2535;#;2343!5;@;

#<font size=4>Informationsverhalten der Raiffeisenbank Stockerau</font>;
2543;110/1;135;#;136;@;

#<font size=4>Abwicklung Ihres Bankgeschäftes</font>;
#Wie häufig nutzen Sie die folgenden Möglichkeiten zur Abwicklung des Bankgeschäftes?;63!4;64!4;65!4;66!4;@;

#<font size=4>Produktnutzung</font>;2353;#;2354;@;

#Kommen wir nun zur Beratung in der Raiffeisenbank Stockerau.;1501;@;

wenn(1501.1|1501.2|1501.3) (709,1129,@,#Bitte beurteilen Sie die Qualität der Betreuung durch Ihren Berater. Wie sehr treffen die folgenden Kriterien auf Ihren Berater zu?,2425,2423,648,1131,2698,2699,649,43,41,48,1497,142,1499,1500,1512,1513/1,1514,1642,@,144,#,#Wenn es im letzten Jahr zu einem Wechsel des Kundenberaters gekommen ist:,145,146);#;2357;@;

wenn (1501.4|1501.5) (2280,#,2281,#,2282);#;1534!4;1533;1535;1536;@;

#<font size=4>Zufriedenheit</font>;#Natürlich erlebt man die Bank einmal besser, einmal schlechter. Aus diesen Erlebnissen formt sich ein Gesamteindruck der Bank. Bitte denken Sie an alle Erfahrungen, die Sie im Laufe der Zeit mit der Raiffeisenbank Stockerau gemacht haben.;#;#Alles in allem, wie zufrieden sind Sie in Ihrer Bank mit ...;11;1504;2221;2431;1505;1507;651;35;54/1;70;138;653;147;@;

wenn (147.4|147.5) (2536);#;2544/5;2697;#;1669/1;#;#;#Bei der Inanspruchnahme von Bankleistungen gibt es ab und zu Situationen, mit denen man nicht ganz zufrieden ist und die ein Gefühl von Ärger verursachen können. Danach fragen wir.;107;@;

wenn (107.1|107.2|107.3|107.4) (655,#,108,#,656);#;

#<font size=4>Verbundenheit</font>;#Wir kommen nun zu Ihrer Beziehung mit der Raiffeisenbank Stockerau. Bitte geben Sie an, wie sehr die Aussagen auf Sie zutreffen.;100;1643;101;242;1517;658;1659;1660;1516;1565;2182;2202;@;

wenn (658.4|658.5) (2539);#;

1110;104;1367;@;

#Stellen Sie sich das Angebot einer Bank vor, deren Leistung und Service Ihren Erwartungen in vollem Umfang entsprechen, also ein Institut, bei dem Sie gerne Kunde sind ...;#;#Was sollte die Bank Ihrer Träume bieten? Was wäre für Sie attraktiv?;659;660;661;662;1369;1370;1371;1412;1503;1304;1373;1374;1375;1376;1377;1378;1379;@;

#Wir kommen nun schon zu den letzten Fragen. Bitte geben Sie an, wie sehr die Aussagen auf Sie zutreffen.;673;674;#;#;

#<font size=4>Statistische Angaben</font>;213;@;

wenn(213.1) (1715,#,679,#,2690,#,2691);#;#Wir bitten Sie nun, einige Angaben zu Ihrer Person zu machen, die selbstverständlich vollkommen anonym und nur statistisch ausgewertet werden.;204;#;205;#;208;#;206;#;2561;#;2279;#;2108;@;

#Vielen Dank für Ihre Unterstützung bei der Weiterentwicklung der Raiffeisenbank Stockerau!
<br>Als Dankeschön verlosen wir unter allen Teilnehmern 6 Gutscheine für ein Day Spa 'Dinner & Wellnes' der Therme Laa für je 2 Personen.
<br><br/>Wir garantieren Ihnen absolute Anonymität.
<br>Die Angabe Ihrer Daten steht in keinem Zusammenhang mit dem Fragebogen und wird lediglich zur Verlosung des Gutscheins verwendet.
<br><br/><br/>Wenn Sie an der Verlosung teilnehmen wollen, tragen Sie bitte Ihren Namen und Ihre Anschrift ein:;2583;2584;2585;2586;";
             * */
        }
    }
}
