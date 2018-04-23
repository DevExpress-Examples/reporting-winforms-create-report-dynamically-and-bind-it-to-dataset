using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace WindowsApplication1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            
            // Create XtraReport instance
            XtraReport rep = new XtraReport();
            
            // Set the XtraReport.DataSource
            rep.DataSource = FillDataset();
            rep.DataMember = ((DataSet)rep.DataSource).Tables[0].TableName;
            
            // Add required bands to the Xtrareport.Bands collection
            InitBands(rep);
            
            // Add requited styles to the XtraReport.StyleSheet collection
            InitStyles(rep);
            
            // Arrange required controls on bands and bind the controls to data
            if (radioButton1.Checked) {
                // Use XRTable to display data
                InitDetailsBasedonXRTable(rep);
            }
            else {
                // Use XRLabels to display data
                InitDetailsBasedOnXRLabel(rep);
            };
            
            // Create a chart, bind it to data and add to the report
            InitChart(rep);
            
            // Display the result
            rep.ShowPreviewDialog();
        }
        public DataSet FillDataset() {
            DataSet dataSet1 = new DataSet();
            dataSet1.DataSetName = "nwindDataSet1";
            DataTable dataTable1 = new DataTable();

            dataSet1.Tables.Add(dataTable1);

            dataTable1.TableName = "Category";
            dataTable1.Columns.Add("CategoryName", typeof(string));
            dataTable1.Columns.Add("count1", typeof(int));
            dataTable1.Columns.Add("count2", typeof(int));
            dataTable1.Columns.Add("count3", typeof(int));

            dataSet1.Tables["Category"].Rows.Add(new Object[] {"Beverage",10, 30,2});
            dataSet1.Tables["Category"].Rows.Add(new Object[] {"Grocerie",20, 40,4});
            dataSet1.Tables["Category"].Rows.Add(new Object[] { "Meat", 30, 50 ,1});
            dataSet1.Tables["Category"].Rows.Add(new Object[] { "Vegetable", 5, 5,8 });
            dataSet1.Tables["Category"].Rows.Add(new Object[] { "Fish", 5, 5 ,10});
            return dataSet1;

        }
        public void InitBands(XtraReport rep) {
            // Create bands
            DetailBand detail = new DetailBand();
            PageHeaderBand pageHeader = new PageHeaderBand();
            ReportFooterBand reportFooter = new ReportFooterBand();
            detail.Height = 20;
            reportFooter.Height = 380;
            pageHeader.Height = 20;

            // Place the bands onto a report
            rep.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] { detail, pageHeader, reportFooter });
        }
        public void InitStyles(XtraReport rep) {
            // Create different odd and even styles
            XRControlStyle oddStyle = new XRControlStyle();
            XRControlStyle evenStyle = new XRControlStyle();

            // Specify the odd style appearance
            oddStyle.BackColor = Color.LightBlue;
            oddStyle.StyleUsing.UseBackColor = true;
            oddStyle.StyleUsing.UseBorders = false;
            oddStyle.Name = "OddStyle";

            // Specify the even style appearance
            evenStyle.BackColor = Color.LightPink;
            evenStyle.StyleUsing.UseBackColor = true;
            evenStyle.StyleUsing.UseBorders = false;
            evenStyle.Name = "EvenStyle";
            
            // Add styles to report's style sheet
            rep.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {oddStyle, evenStyle});
        }

        public void InitDetailsBasedOnXRLabel(XtraReport rep) {
            DataSet ds = ((DataSet)rep.DataSource);
            int colCount = ds.Tables[0].Columns.Count;
            int colWidth = (rep.PageWidth - (rep.Margins.Left + rep.Margins.Right)) / colCount;
            
            // Create header captions
            for(int i = 0; i < colCount; i++) {
                XRLabel label = new XRLabel();
                label.Location = new Point(colWidth * i, 0);
                label.Size = new Size(colWidth, 20);
                label.Text = ds.Tables[0].Columns[i].Caption;
                if(i > 0)
                    label.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
                else
                    label.Borders = DevExpress.XtraPrinting.BorderSide.All;
                
                // Place the headers onto a PageHeader band
                rep.Bands[BandKind.PageHeader].Controls.Add(label);
            }
            // Create data-bound labels with different odd and even backgrounds
            for(int i = 0; i < colCount; i++) {
                XRLabel label = new XRLabel();
                label.Location = new Point(colWidth * i, 0);
                label.Size = new Size(colWidth, 20);
                label.DataBindings.Add("Text", null, ds.Tables[0].Columns[i].Caption);
                label.OddStyleName = "OddStyle";
                label.EvenStyleName = "EvenStyle";
                if(i > 0)
                    label.Borders = DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom;
                else
                    label.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom;
                
                // Place the labels onto a Detail band
                rep.Bands[BandKind.Detail].Controls.Add(label);
            }
        }
        public void InitDetailsBasedonXRTable(XtraReport rep) {
            DataSet ds = ((DataSet)rep.DataSource);
            int colCount = ds.Tables[0].Columns.Count;
            int colWidth = (rep.PageWidth - (rep.Margins.Left + rep.Margins.Right)) / colCount;

            // Create a table to represent headers
            XRTable tableHeader = new XRTable();
            tableHeader.Height = 20;
            tableHeader.Width = (rep.PageWidth - (rep.Margins.Left + rep.Margins.Right));
            XRTableRow headerRow = new XRTableRow();
            headerRow.Width = tableHeader.Width;
            tableHeader.Rows.Add(headerRow);

            tableHeader.BeginInit();

            // Create a table to display data
            XRTable tableDetail = new XRTable();
            tableDetail.Height = 20;
            tableDetail.Width = (rep.PageWidth - (rep.Margins.Left + rep.Margins.Right));
            XRTableRow detailRow = new XRTableRow();
            detailRow.Width = tableDetail.Width;
            tableDetail.Rows.Add(detailRow);
            tableDetail.EvenStyleName = "EvenStyle";
            tableDetail.OddStyleName = "OddStyle";

            tableDetail.BeginInit();

            // Create table cells, fill the header cells with text, bind the cells to data
            for(int i = 0; i < colCount; i++) {
                XRTableCell headerCell = new XRTableCell();
                headerCell.Width = colWidth;
                headerCell.Text = ds.Tables[0].Columns[i].Caption;

                XRTableCell detailCell = new XRTableCell();
                detailCell.Width = colWidth;
                detailCell.DataBindings.Add("Text", null, ds.Tables[0].Columns[i].Caption);
                if(i == 0) {
                 headerCell.Borders = DevExpress.XtraPrinting.BorderSide.Left |DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
                 detailCell.Borders = DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Bottom;
                }
                else {
                    headerCell.Borders = DevExpress.XtraPrinting.BorderSide.All;
                    detailCell.Borders = DevExpress.XtraPrinting.BorderSide.All;
                }

                // Place the cells into the corresponding tables
                headerRow.Cells.Add(headerCell);
                detailRow.Cells.Add(detailCell);
            }
            tableHeader.EndInit();
            tableDetail.EndInit();
            // Place the table onto a report's Detail band
            rep.Bands[BandKind.PageHeader].Controls.Add(tableHeader);
            rep.Bands[BandKind.Detail].Controls.Add(tableDetail);
        }
        public void InitChart(XtraReport rep) {
            DataSet ds = ((DataSet)rep.DataSource);

            // Create a chart
            XRChart xrChart1 = new DevExpress.XtraReports.UI.XRChart();
            
            xrChart1.Location = new System.Drawing.Point(0, 0);
            xrChart1.Name = "xrChart1";
            
            // Create chart series and bind them to data
            for(int i = 1; i < ds.Tables[0].Columns.Count; i++) {
                if(ds.Tables[0].Columns[i].DataType == typeof(int) || ds.Tables[0].Columns[i].DataType == typeof(double)) {
                    DevExpress.XtraCharts.Series series = new DevExpress.XtraCharts.Series(ds.Tables[0].Columns[i].Caption, DevExpress.XtraCharts.ViewType.Bar);
                    series.DataSource = ds.Tables[0];
                    series.ArgumentDataMember = ds.Tables[0].Columns[0].Caption;
                    series.PointOptionsTypeName = "PointOptions";
                    series.ValueDataMembers[0] = ds.Tables[0].Columns[i].Caption;
                    xrChart1.Series.Add(series);
                    
                }
            }
            // Customize the chart appearance
            ((DevExpress.XtraCharts.XYDiagram)xrChart1.Diagram).AxisX.Label.Angle = 20;
            ((DevExpress.XtraCharts.XYDiagram)xrChart1.Diagram).AxisX.Label.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            ((DevExpress.XtraCharts.XYDiagram)xrChart1.Diagram).AxisX.Label.Antialiasing = true;

            xrChart1.SeriesTemplate.PointOptionsTypeName = "PointOptions";
            xrChart1.Size = new System.Drawing.Size(650, 360);
            
            // Place the chart onto a report footer
            rep.Bands[BandKind.ReportFooter].Controls.Add(xrChart1);
        }

        
       
    


    }
}