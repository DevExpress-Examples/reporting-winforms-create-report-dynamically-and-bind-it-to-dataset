using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using DevExpress.XtraCharts;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            // Create a report instance.
            var report = new XtraReport();

            // Set up the report's data source.
            report.DataSource = CreateDataSet();
            report.DataMember = (report.DataSource as DataSet).Tables[0].TableName;

            // Create bands.
            CreateBands(report);

            // Apply styles.
            ApplyStyles(report);

            // Add controls to the bands and bind the controls to data.
            if (xrTableRadioButton.Checked) {
                // Use the XRTable control to display data.
                InitializeBandsUsingXRTable(report);
            } else {
                // Use the XRLabel control to display data.
                InitializeBandsUsingXRLabel(report);
            };

            // Create a chart, bind it to data, and add the chart to the report.
            InitializeChart(report);

            // Show the report's Preview.
            report.ShowPreviewDialog();
        }

        public DataSet CreateDataSet() {
            var dataSet = new DataSet() {
                DataSetName = "Categories"
            };

            var dataTable = new DataTable() {
                TableName = "Category"
            };

            dataSet.Tables.Add(dataTable);

            dataTable.Columns.Add("Category Name", typeof(string));
            dataTable.Columns.Add("Amount 1", typeof(int));
            dataTable.Columns.Add("Amount 2", typeof(int));
            dataTable.Columns.Add("Amount 3", typeof(int));

            dataSet.Tables["Category"].Rows.Add(new Object[] { "Beverage", 10, 30, 2 });
            dataSet.Tables["Category"].Rows.Add(new Object[] { "Groceries", 20, 40, 4 });
            dataSet.Tables["Category"].Rows.Add(new Object[] { "Meat", 30, 50, 1 });
            dataSet.Tables["Category"].Rows.Add(new Object[] { "Vegetable", 5, 5, 8 });
            dataSet.Tables["Category"].Rows.Add(new Object[] { "Fish", 5, 5, 10 });

            return dataSet;
        }

        public void CreateBands(XtraReport report) {
            var detail = new DetailBand() { HeightF = 20 };
            var pageHeader = new PageHeaderBand() { HeightF = 20 };
            var reportFooter = new ReportFooterBand() { HeightF = 380 };
            report.Bands.AddRange(new Band[] { detail, pageHeader, reportFooter });
        }

        public void ApplyStyles(XtraReport report) {
            // Create odd and even styles and set up their appearance.
            var oddStyle = new XRControlStyle();
            var evenStyle = new XRControlStyle();

            oddStyle.BackColor = Color.LightBlue;
            oddStyle.StyleUsing.UseBackColor = true;
            oddStyle.StyleUsing.UseBorders = false;
            oddStyle.Name = "OddStyle";

            evenStyle.BackColor = Color.LightPink;
            evenStyle.StyleUsing.UseBackColor = true;
            evenStyle.StyleUsing.UseBorders = false;
            evenStyle.Name = "EvenStyle";

            // Add the styles to the report's StyleSheet collection.
            report.StyleSheet.AddRange(new XRControlStyle[] { oddStyle, evenStyle });
        }

        public void InitializeBandsUsingXRLabel(XtraReport report) {
            var ds = report.DataSource as DataSet;
            int colCount = ds.Tables[0].Columns.Count;
            int colWidth = (report.PageWidth - ((int)report.Margins.Left + (int)report.Margins.Right)) / colCount;

            // Create header captions.
            for (int i = 0; i < colCount; i++) {
                var label = new XRLabel();

                label.Location = new Point(colWidth * i, 0);
                label.Size = new Size(colWidth, 20);
                label.Text = ds.Tables[0].Columns[i].Caption;

                if (i > 0)
                    label.Borders = BorderSide.Right | BorderSide.Top | BorderSide.Bottom;
                else
                    label.Borders = BorderSide.All;

                // Add a label with the caption to the report's PageHeader band.
                report.Bands[BandKind.PageHeader].Controls.Add(label);
            }

            // Create data-bound labels with different odd and even backgrounds.
            for (int i = 0; i < colCount; i++) {
                var label = new XRLabel();

                label.Location = new Point(colWidth * i, 0);
                label.Size = new Size(colWidth, 20);
                label.ExpressionBindings.Add(new ExpressionBinding("Text", "[" + ds.Tables[0].Columns[i].Caption + "]"));
                label.OddStyleName = "OddStyle";
                label.EvenStyleName = "EvenStyle";

                if (i > 0)
                    label.Borders = BorderSide.Right | BorderSide.Bottom;
                else
                    label.Borders = BorderSide.Left | BorderSide.Right | BorderSide.Bottom;

                // Add the label to the report's Detail band.
                report.Bands[BandKind.Detail].Controls.Add(label);
            }
        }

        public void InitializeBandsUsingXRTable(XtraReport report) {
            var ds = (report.DataSource as DataSet);
            int colCount = ds.Tables[0].Columns.Count;
            int colWidth = (report.PageWidth - ((int)report.Margins.Left + (int)report.Margins.Right)) / colCount;

            // Create a table header.
            var tableHeader = new XRTable();
            tableHeader.Height = 20;
            tableHeader.Width = (report.PageWidth - ((int)report.Margins.Left + (int)report.Margins.Right));

            var headerRow = new XRTableRow();
            headerRow.Width = tableHeader.Width;
            tableHeader.Rows.Add(headerRow);

            tableHeader.BeginInit();

            // Create a table body.
            var tableBody = new XRTable();
            tableBody.Height = 20;
            tableBody.Width = (report.PageWidth - ((int)report.Margins.Left + (int)report.Margins.Right));

            var bodyRow = new XRTableRow();
            bodyRow.Width = tableBody.Width;
            tableBody.Rows.Add(bodyRow);
            tableBody.EvenStyleName = "EvenStyle";
            tableBody.OddStyleName = "OddStyle";

            tableBody.BeginInit();

            // Initialize table header and body cells.
            for (int i = 0; i < colCount; i++) {
                var headerCell = new XRTableCell();
                headerCell.Width = colWidth;
                headerCell.Text = ds.Tables[0].Columns[i].Caption;

                var bodyCell = new XRTableCell();
                bodyCell.Width = colWidth;
                bodyCell.DataBindings.Add("Text", null, ds.Tables[0].Columns[i].Caption);

                if (i == 0) {
                    headerCell.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
                    bodyCell.Borders = BorderSide.Left | BorderSide.Top | BorderSide.Bottom;
                } else {
                    headerCell.Borders = BorderSide.All;
                    bodyCell.Borders = BorderSide.All;
                }

                headerRow.Cells.Add(headerCell);
                bodyRow.Cells.Add(bodyCell);
            }

            tableHeader.EndInit();
            tableBody.EndInit();

            // Add the table header and body to the corresponding report bands.
            report.Bands[BandKind.PageHeader].Controls.Add(tableHeader);
            report.Bands[BandKind.Detail].Controls.Add(tableBody);
        }

        public void InitializeChart(XtraReport report) {
            var ds = report.DataSource as DataSet;

            // Create a chart.
            var chart = new XRChart();

            chart.Location = new Point(0, 0);
            chart.Name = "xrChart1";

            // Create chart series and bind them to data.
            for (int i = 1; i < ds.Tables[0].Columns.Count; i++) {
                if (ds.Tables[0].Columns[i].DataType == typeof(int) || ds.Tables[0].Columns[i].DataType == typeof(double)) {
                    var series = new Series(ds.Tables[0].Columns[i].Caption, ViewType.Bar);

                    series.DataSource = ds.Tables[0];
                    series.ArgumentDataMember = ds.Tables[0].Columns[0].Caption;
                    series.ValueDataMembers[0] = ds.Tables[0].Columns[i].Caption;

                    chart.Series.Add(series);
                }
            }

            // Customize the chart appearance.
            (chart.Diagram as XYDiagram).AxisX.Label.Angle = 20;
            (chart.Diagram as XYDiagram).AxisX.Label.Font = new Font(
                "Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));

            chart.Size = new Size(650, 360);

            // Add the chart to the report's footer.
            report.Bands[BandKind.ReportFooter].Controls.Add(chart);
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}
