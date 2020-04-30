Imports DevExpress.Xpo

Namespace ConsoleApplication1

	Public Class Quote
		Inherits XPObject

		Public Sub New()
			MyBase.New()
			' This constructor is used when an object is loaded from a persistent storage.
			' Do not place any code here.
		End Sub
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
			' This constructor is used when an object is loaded from a persistent storage.
			' Do not place any code here.
		End Sub
		Public Overrides Sub AfterConstruction()
			MyBase.AfterConstruction()
			' Place here your initialization code.
		End Sub
		Private _name As String
		Public Property Name() As String
			Get
				Return _name
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Name", _name, value)
			End Set
		End Property
		<Association("Quote-QuoteItems"), Aggregated>
		Public ReadOnly Property QuoteItems() As XPCollection(Of QuoteItem)
			Get
				Return GetCollection(Of QuoteItem)("QuoteItems")
			End Get
		End Property
	End Class
End Namespace