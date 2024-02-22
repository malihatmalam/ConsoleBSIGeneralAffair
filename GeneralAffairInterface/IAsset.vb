Imports BSIGeneralAffairBO

Public Interface IAsset
    Inherits IBaseCRUD(Of Asset)

    Function getByNumberAsset() As List(Of Asset)
    Function handsoverAsset() As List(Of Asset)
    Function handsoverHistoryAsset() As List(Of Asset)

End Interface
