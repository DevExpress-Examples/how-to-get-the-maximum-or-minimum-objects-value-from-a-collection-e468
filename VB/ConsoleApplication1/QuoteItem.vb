Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo

Namespace ConsoleApplication1

	Public Class QuoteItem
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
		Private _sequence As Integer
		Public Property Sequence() As Integer
			Get
				Return _sequence
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("Sequence", _sequence, value)
			End Set
		End Property
		Private _quote As Quote
		<Association("Quote-QuoteItems")> _
		Public Property Quote() As Quote
			Get
				Return _quote
			End Get
			Set(ByVal value As Quote)
				SetPropertyValue("Quote", _quote, value)
			End Set
		End Property
	End Class
End Namespace