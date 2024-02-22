Public Class Asset
    Public Property AssetID As Integer?
    Public Property BrandID As Short?
    Public Property AssetCategoryID As Short?
    Public Property AssetFactoryNumber As String
    Public Property AssetNumber As String
    Public Property AsssetName As String
    Public Property AssetCost As Decimal?
    Public Property AssetProcurementDate As DateTime?
    Public Property AssetFlagActive As Boolean?
    Public Property AssetCondition As String
    Public Property CreatedAt As DateTime?
    Public Property UpdatedAt As DateTime?
    Public Property Category As AssetCategory
    Public Property UserAsset As List(Of AssetUser)
    Public Property Brand As Brand


End Class