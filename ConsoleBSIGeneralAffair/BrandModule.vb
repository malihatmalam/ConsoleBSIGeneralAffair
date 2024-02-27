Imports BSIGeneralAffairBO

Module BrandModule

    Sub BrandDB()
        Dim BrandDAL As New BSIGeneralAffairDAL.DALBrand

        Dim brands = BrandDAL.getAll()
        For Each brand As Brand In brands
            Console.WriteLine(
                "{0}-{1}-{2}",
                brand.BrandID,
                brand.BrandName,
                brand.UpdatedAt
                )
        Next
    End Sub

    Sub BrandCreateDB()
        Dim brandDAL As New BSIGeneralAffairDAL.DALBrand
        Dim newBrand As New Brand
        newBrand.BrandName = "Nokia"

        Try
            Dim result = brandDAL.create(newBrand)
            If result = 1 Then
                Console.WriteLine("Insert failed")
            Else
                Console.WriteLine("Insert success")
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Sub BrandUpdateDB()
        Dim brandDAL As New BSIGeneralAffairDAL.DALBrand
        Dim updateBrand As New Brand
        updateBrand.BrandID = 15
        updateBrand.BrandName = "PT Bintang 11"

        Try
            Dim result = brandDAL.update(updateBrand)
            If result = 1 Then
                Console.WriteLine("Update failed")
            Else
                Console.WriteLine("Update success")
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Sub BrandDeleteDB()
        Dim brandDAL As New BSIGeneralAffairDAL.DALBrand
        Dim brandID As Integer = 17
        Try
            Dim result = brandDAL.delete(brandID)
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
