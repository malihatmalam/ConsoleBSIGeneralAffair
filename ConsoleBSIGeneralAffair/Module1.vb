Imports BSIGeneralAffairBO

Module Module1

    Sub Main()
        VendorDB()
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

End Module
