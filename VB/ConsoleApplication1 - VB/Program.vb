Imports System
Imports System.Diagnostics
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.Xpo.DB

Namespace ConsoleApplication1
	Friend Class Program
		Shared Sub Main(ByVal args() As String)
			Dim q As Quote = TryCast(Session.DefaultSession.FindObject(Of Quote)(New OperandProperty("Oid") = 1), Quote)
			If q Is Nothing Then
				q = New Quote()
				For i As Integer = 0 To 4
					Dim qi As New QuoteItem()
					qi.Sequence = i
					q.QuoteItems.Add(qi)
					qi.Save()
				Next i
				q.Save()
			End If
			Dim maxValue As Integer = Convert.ToInt32(Session.DefaultSession.Evaluate(Of QuoteItem)(CriteriaOperator.Parse("Max(Sequence)"), New OperandProperty("Quote.Oid") = q.Oid))
			Debug.Assert(maxValue = 4, "Error")

			Dim items As New XPCollection(Of QuoteItem)(New OperandProperty("Quote.Oid") = q.Oid, New SortProperty("Sequence", SortingDirection.Descending))
			items.TopReturnedObjects = 1
			If items.Count <> 0 Then
				Dim maxQuoteItemObject As QuoteItem = TryCast(items(0), QuoteItem)
				Debug.Assert(maxQuoteItemObject.Sequence = 4, "Error")
			End If
		End Sub
	End Class
End Namespace
