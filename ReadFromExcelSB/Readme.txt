


Open XML:
	https://learn.microsoft.com/en-us/office/open-xml/how-to-create-a-spreadsheet-document-by-providing-a-file-name
	https://www.c-sharpcorner.com/article/creating-excel-file-using-openxml/


C# Tutorial
	https://www.youtube.com/watch?v=SXmVym6L8dw&list=PLAC325451207E3105

GitHub Tutorial:
	https://www.youtube.com/watch?v=iv8rSLsi1xo

Visual Studio Tutorial:
	https://www.youtube.com/watch?v=REG-p_eFNIw

NuGet Package:
	https://www.youtube.com/watch?v=WW3bO1lNDmo


ReportByLineMenManager: Responsible for generating Line Men Report.
	Steps
		Invokes Excel Manager to create DataTable from Excel file
		Parses Data Table and converts to DTO.
		Create group by Line Men Name of the List of DTO
		Invokes OpenXmlFacade class to generate excel file.
			"ReportByLineMenManager" has deligate to fill data
