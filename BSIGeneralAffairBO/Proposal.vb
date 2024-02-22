Public Class Proposal
    Public Property ProposalToken As String
    Public Property DepartementID As Byte?
    Public Property UserID As Integer?
    Public Property VendorID As Short?
    Public Property ProposalObjective As String
    Public Property ProposalDescription As String
    Public Property ProposalRequireDate As DateTime?
    Public Property ProposalBudget As Decimal?
    Public Property ProposalNote As String
    Public Property ProposalType As String
    Public Property ProposalStatus As String
    Public Property ProposalApproveLevel As Byte?
    Public Property ProposalNegotiationNote As String
    Public Property CreatedAt As DateTime?
    Public Property UpdatedAt As DateTime?

    Public Property Department As Departement
    Public Property User As User
    Public Property Vendor As Vendor
    Public Property File As List(Of ProposalFile)
    Public Property ServiceHistory As List(Of ProposalService)

End Class