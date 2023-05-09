


Open XML:
	https://learn.microsoft.com/en-us/office/open-xml/how-to-create-a-spreadsheet-document-by-providing-a-file-name


ReportByLineMenManager: Responsible for generating Line Men Report.
	Steps
		Invokes Excel Manager to create DataTable from Excel file
		Parses Data Table and converts to DTO.
		Create group by Line Men Name of the List of DTO
		Invokes OpenXmlFacade class to generate excel file.
			"ReportByLineMenManager" has deligate to fill data
