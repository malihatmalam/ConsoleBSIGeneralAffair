Imports BSIGeneralAffairBO

Public Interface IProposal
    Function getWaitingAppoval() As List(Of Proposal)

    Function create(proposal As Proposal) As Integer

    Function createService(proposal As Proposal) As Integer

    Function cmsApproval(proposal As Proposal) As Integer

    Function getHistoryProcurement() As List(Of Proposal)

    Function getHistoryService() As List(Of Proposal)

    Function getByProposalToken() As List(Of Proposal)

    Function update(proposal As Proposal) As Integer

    Function uploadFile(file As ProposalFile) As Integer

    Function cancel(proposal As Proposal) As Integer

    Function mobileApproval(proposal As Proposal) As Integer

    Function getHistoryApprovalProposal() As List(Of Proposal)

End Interface
