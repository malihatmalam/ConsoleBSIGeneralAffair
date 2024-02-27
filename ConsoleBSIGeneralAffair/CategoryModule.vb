Imports BSIGeneralAffairBO

Module CategoryModule
    Sub CategoryDB()
        Dim CategoryDAL As New BSIGeneralAffairDAL.DALCategory

        Dim Categories = CategoryDAL.getAll()
        For Each category As AssetCategory In Categories
            Console.WriteLine(
                "{0} {1} {2} ",
                category.AssetCategoryID,
                category.AssetCategoryName,
                category.UpdatedAt
                )
        Next
    End Sub

    Sub CategoryCreateDB()
        Dim CategoryDAL As New BSIGeneralAffairDAL.DALCategory
        Dim newCategory As New AssetCategory
        newCategory.AssetCategoryName = "Nokia"

        Try
            Dim result = CategoryDAL.create(newCategory)
            If result = 1 Then
                Console.WriteLine("Insert failed")
            Else
                Console.WriteLine("Insert success")
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Sub CategoryUpdateDB()
        Dim CategoryDAL As New BSIGeneralAffairDAL.DALCategory
        Dim updateCategory As New AssetCategory
        updateCategory.AssetCategoryID = 15
        updateCategory.AssetCategoryName = "PT Bintang 11"

        Try
            Dim result = CategoryDAL.update(updateCategory)
            If result = 1 Then
                Console.WriteLine("Update failed")
            Else
                Console.WriteLine("Update success")
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Sub CategoryDeleteDB()
        Dim CategoryDAL As New BSIGeneralAffairDAL.DALCategory
        Dim categoryID As Integer = 17
        Try
            Dim result = CategoryDAL.delete(categoryID)
            If result = 1 Then
                Console.WriteLine("Delete failed")
            Else
                Console.WriteLine("Delete success")
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub
End Module
