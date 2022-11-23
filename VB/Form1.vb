Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraCharts

Namespace WindowsFormsApp1
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			' Create a report instance.
			Dim report = New XtraReport()

			' Set up the report's data source.
			report.DataSource = CreateDataSet()
			report.DataMember = (TryCast(report.DataSource, DataSet)).Tables(0).TableName

			' Create bands.
			CreateBands(report)

			' Apply styles.
			ApplyStyles(report)

			' Add controls to the bands and bind the controls to data.
			If xrTableRadioButton.Checked Then
				' Use the XRTable control to display data.
				InitializeBandsUsingXRTable(report)
			Else
				' Use the XRLabel control to display data.
				InitializeBandsUsingXRLabel(report)
			End If

			' Create a chart, bind it to data, and add the chart to the report.
			InitializeChart(report)

			' Show the report's Preview.
			report.ShowPreviewDialog()
		End Sub

		Public Function CreateDataSet() As DataSet
			Dim dataSet = New DataSet() With {.DataSetName = "Categories"}

			Dim dataTable = New DataTable() With {.TableName = "Category"}

			dataSet.Tables.Add(dataTable)

			dataTable.Columns.Add("Category Name", GetType(String))
			dataTable.Columns.Add("Amount 1", GetType(Integer))
			dataTable.Columns.Add("Amount 2", GetType(Integer))
			dataTable.Columns.Add("Amount 3", GetType(Integer))

			dataSet.Tables("Category").Rows.Add(New Object() { "Beverage", 10, 30, 2 })
			dataSet.Tables("Category").Rows.Add(New Object() { "Groceries", 20, 40, 4 })
			dataSet.Tables("Category").Rows.Add(New Object() { "Meat", 30, 50, 1 })
			dataSet.Tables("Category").Rows.Add(New Object() { "Vegetable", 5, 5, 8 })
			dataSet.Tables("Category").Rows.Add(New Object() { "Fish", 5, 5, 10 })

			Return dataSet
		End Function

		Public Sub CreateBands(ByVal report As XtraReport)
			Dim detail = New DetailBand() With {.HeightF = 20}
			Dim pageHeader = New PageHeaderBand() With {.HeightF = 20}
			Dim reportFooter = New ReportFooterBand() With {.HeightF = 380}
			report.Bands.AddRange(New Band() { detail, pageHeader, reportFooter })
		End Sub

		Public Sub ApplyStyles(ByVal report As XtraReport)
			' Create odd and even styles and set up their appearance.
			Dim oddStyle = New XRControlStyle()
			Dim evenStyle = New XRControlStyle()

			oddStyle.BackColor = Color.LightBlue
			oddStyle.StyleUsing.UseBackColor = True
			oddStyle.StyleUsing.UseBorders = False
			oddStyle.Name = "OddStyle"

			evenStyle.BackColor = Color.LightPink
			evenStyle.StyleUsing.UseBackColor = True
			evenStyle.StyleUsing.UseBorders = False
			evenStyle.Name = "EvenStyle"

			' Add the styles to the report's StyleSheet collection.
			report.StyleSheet.AddRange(New XRControlStyle() { oddStyle, evenStyle })
		End Sub

		Public Sub InitializeBandsUsingXRLabel(ByVal report As XtraReport)
			Dim ds = TryCast(report.DataSource, DataSet)
			Dim colCount As Integer = ds.Tables(0).Columns.Count
			Dim colWidth As Single = (report.PageWidth - (report.Margins.Left + report.Margins.Right)) / colCount

			' Create header captions.
			For i As Integer = 0 To colCount - 1
				Dim label = New XRLabel()

				label.LocationF = New PointF(colWidth * i, 0)
				label.SizeF = New SizeF(colWidth, 20)
				label.Text = ds.Tables(0).Columns(i).Caption

				If i > 0 Then
					label.Borders = BorderSide.Right Or BorderSide.Top Or BorderSide.Bottom
				Else
					label.Borders = BorderSide.All
				End If

				' Add a label with the caption to the report's PageHeader band.
				report.Bands(BandKind.PageHeader).Controls.Add(label)
			Next i

			' Create data-bound labels with different odd and even backgrounds.
			For i As Integer = 0 To colCount - 1
				Dim label = New XRLabel()

				label.LocationF = New PointF(colWidth * i, 0)
				label.SizeF = New SizeF(colWidth, 20)
				label.ExpressionBindings.Add(New ExpressionBinding("Text", "[" & ds.Tables(0).Columns(i).Caption & "]"))
				label.OddStyleName = "OddStyle"
				label.EvenStyleName = "EvenStyle"

				If i > 0 Then
					label.Borders = BorderSide.Right Or BorderSide.Bottom
				Else
					label.Borders = BorderSide.Left Or BorderSide.Right Or BorderSide.Bottom
				End If

				' Add the label to the report's Detail band.
				report.Bands(BandKind.Detail).Controls.Add(label)
			Next i
		End Sub

		Public Sub InitializeBandsUsingXRTable(ByVal report As XtraReport)
			Dim ds = (TryCast(report.DataSource, DataSet))
			Dim colCount As Integer = ds.Tables(0).Columns.Count
			Dim colWidth As Single = (report.PageWidth - (report.Margins.Left + report.Margins.Right)) / colCount

			' Create a table header.
			Dim tableHeader = New XRTable()
			tableHeader.Height = 20
			tableHeader.WidthF = (report.PageWidth - (report.Margins.Left + report.Margins.Right))

			Dim headerRow = New XRTableRow()
			headerRow.WidthF = tableHeader.WidthF
			tableHeader.Rows.Add(headerRow)

			tableHeader.BeginInit()

			' Create a table body.
			Dim tableBody = New XRTable()
			tableBody.Height = 20
			tableBody.WidthF = (report.PageWidth - (report.Margins.Left + report.Margins.Right))

			Dim bodyRow = New XRTableRow()
			bodyRow.WidthF = tableBody.WidthF
			tableBody.Rows.Add(bodyRow)
			tableBody.EvenStyleName = "EvenStyle"
			tableBody.OddStyleName = "OddStyle"

			tableBody.BeginInit()

			' Initialize table header and body cells.
			For i As Integer = 0 To colCount - 1
				Dim headerCell = New XRTableCell()
				headerCell.WidthF = colWidth
				headerCell.Text = ds.Tables(0).Columns(i).Caption

				Dim bodyCell = New XRTableCell()
				bodyCell.WidthF = colWidth
				bodyCell.DataBindings.Add("Text", Nothing, ds.Tables(0).Columns(i).Caption)

				If i = 0 Then
					headerCell.Borders = BorderSide.Left Or BorderSide.Top Or BorderSide.Bottom
					bodyCell.Borders = BorderSide.Left Or BorderSide.Top Or BorderSide.Bottom
				Else
					headerCell.Borders = BorderSide.All
					bodyCell.Borders = BorderSide.All
				End If

				headerRow.Cells.Add(headerCell)
				bodyRow.Cells.Add(bodyCell)
			Next i

			tableHeader.EndInit()
			tableBody.EndInit()

			' Add the table header and body to the corresponding report bands.
			report.Bands(BandKind.PageHeader).Controls.Add(tableHeader)
			report.Bands(BandKind.Detail).Controls.Add(tableBody)
		End Sub

		Public Sub InitializeChart(ByVal report As XtraReport)
			Dim ds = TryCast(report.DataSource, DataSet)

			' Create a chart.
			Dim chart = New XRChart()

			chart.Location = New Point(0, 0)
			chart.Name = "xrChart1"

			' Create chart series and bind them to data.
			For i As Integer = 1 To (ds.Tables(0).Columns.Count) - 1
				If ds.Tables(0).Columns(i).DataType Is GetType(Integer) OrElse ds.Tables(0).Columns(i).DataType Is GetType(Double) Then
					Dim series = New Series(ds.Tables(0).Columns(i).Caption, ViewType.Bar)

					series.DataSource = ds.Tables(0)
					series.ArgumentDataMember = ds.Tables(0).Columns(0).Caption
					series.ValueDataMembers(0) = ds.Tables(0).Columns(i).Caption

					chart.Series.Add(series)
				End If
			Next i

			' Customize the chart appearance.
			TryCast(chart.Diagram, XYDiagram).AxisX.Label.Angle = 20
			TryCast(chart.Diagram, XYDiagram).AxisX.Label.Font = New Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, (CByte(204)))

			chart.Size = New Size(650, 360)

			' Add the chart to the report's footer.
			report.Bands(BandKind.ReportFooter).Controls.Add(chart)
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

		End Sub
	End Class
End Namespace
