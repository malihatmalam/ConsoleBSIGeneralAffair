Imports BSIGeneralAffairBO
Imports BSIGeneralAffairDAL

Module Module1

    Sub Main()
        'VendorDB()
        'VendorCreateDB()
        'VendorUpdateDB()
        VendorDeleteDB()
    End Sub

    Sub VendorDB()
        Dim vendorDAL As New BSIGeneralAffairDAL.DALVendor

        Dim vendors = vendorDAL.getAll()
        For Each vendor As Vendor In vendors
            Console.WriteLine(
                "{0}-{1}-{2}",
                vendor.VendorID,
                vendor.VendorName,
                vendor.VendorAddress,
                vendor.CreatedAt,
                vendor.UpdatedAt
                )
        Next
    End Sub

    Sub VendorCreateDB()
        Dim vendorDAL As New BSIGeneralAffairDAL.DALVendor
        Dim newVendor As New Vendor
        newVendor.VendorName = "PT Bintang Gils"
        newVendor.VendorAddress = "Jalan Paralayang"

        Try
            Dim result = vendorDAL.create(newVendor)
            If result = 1 Then
                Console.WriteLine("Insert failed")
            Else
                Console.WriteLine("Insert success")
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Sub VendorUpdateDB()
        Dim vendorDAL As New BSIGeneralAffairDAL.DALVendor
        Dim updateVendor As New Vendor
        updateVendor.VendorID = 15
        updateVendor.VendorName = "PT Bintang 11"
        updateVendor.VendorAddress = "Jln Bintang aja"

        Try
            Dim result = vendorDAL.update(updateVendor)
            If result = 1 Then
                Console.WriteLine("Update failed")
            Else
                Console.WriteLine("Update success")
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Sub VendorDeleteDB()
        Dim vendorDAL As New BSIGeneralAffairDAL.DALVendor
        Dim vendorId As Integer = 17
        Try
            Dim result = vendorDAL.delete(vendorId)
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
