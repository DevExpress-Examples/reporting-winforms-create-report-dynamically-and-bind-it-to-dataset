<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128600432/19.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4657)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Reporting_how-to-dynamically-generate-a-report-and-bind-it-to-a-dataset-in-a-winforms-e4657/Report_at_Runtime/Form1.cs) (VB: [Form1.vb](./VB/Reporting_how-to-dynamically-generate-a-report-and-bind-it-to-a-dataset-in-a-winforms-e4657/Report_at_Runtime/Form1.vb))
* [Program.cs](./CS/Reporting_how-to-dynamically-generate-a-report-and-bind-it-to-a-dataset-in-a-winforms-e4657/Report_at_Runtime/Program.cs) (VB: [Program.vb](./VB/Reporting_how-to-dynamically-generate-a-report-and-bind-it-to-a-dataset-in-a-winforms-e4657/Report_at_Runtime/Program.vb))
<!-- default file list end -->
# How to dynamically generate a report and bind it to a DataSet in a WinForms application


<p>If you wish to generate a report based on <a href="https://documentation.devexpress.com/WindowsForms/DevExpress.XtraGrid.GridControl.class">GridControl</a>, it is easy to do this by using <a href="https://documentation.devexpress.com/XtraReports/DevExpress.XtraReports.ReportGeneration.ReportGenerator.class">ReportGenerator</a> as described in the <a href="https://documentation.devexpress.com/WindowsForms/114962/Controls-and-Libraries/Data-Grid/Export-and-Printing/Advanced-Grid-Printing-and-Exporting">Advanced Grid Printing and Exporting</a> help article. This component can be used at design time as well as at runtime. <br><br>If you are interested in creating a report from scratch, use the approach described below.<br><br>1. Create a report instance and <a href="https://documentation.devexpress.com/#XtraReports/CustomDocument15034">bind it to data</a>.</p>
<p>2. Add required <a href="https://documentation.devexpress.com/#XtraReports/CustomDocument2590">bands</a> to the report.</p>
<p>3. Add required <a href="https://documentation.devexpress.com/#XtraReports/CustomDocument2605">controls</a> to the created bands and provide data to them.</p>
<p>After the report layout is complete, you can generate the report document and display it in a <a href="https://documentation.devexpress.com/#XtraReports/CustomDocument10707">Print Preview</a>.</p>
<p> </p>
<p><strong>See also</strong>

* <a href="https://www.devexpress.com/Support/Center/p/E4421">How to dynamically generate a master-detail report in a WinForms application</a>
* <a href="https://www.devexpress.com/Support/Center/p/E652">How to dynamically generate a report and bind it to a collection of objects in a WinForms application</a>
* <a href="https://www.devexpress.com/Support/Center/p/AK15900">How to create a report dynamically</a></p>

<br/>


