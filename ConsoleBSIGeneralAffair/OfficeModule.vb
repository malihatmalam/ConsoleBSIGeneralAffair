Imports BSIGeneralAffairBO

Module OfficeModule
    Sub OfficeDB()
        Dim OfficeDAL As New BSIGeneralAffairDAL.DALOffice

        Dim Offices = OfficeDAL.getAll()
        For Each office As Office In Offices
            Console.WriteLine(
                "{0} {1} {2} {3} ",
                office.OfficeID,
                office.OfficeName,
                office.OfficeAddress,
                office.UpdateAt
                )
        Next
    End Sub

    Sub OfficeCreateDB()
        Dim OfficeDAL As New BSIGeneralAffairDAL.DALOffice
        Dim newOffice As New Office
        newOffice.OfficeName = "Nokia"
        newOffice.OfficeAddress = "Nokia"
        newOffice.OfficeFlagActive = 1

        Try
            Dim result = OfficeDAL.create(newOffice)
            If result = 1 Then
                Console.WriteLine("Insert failed")
            Else
                Console.WriteLine("Insert success")
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Sub OfficeUpdateDB()
        Dim OfficeDAL As New BSIGeneralAffairDAL.DALOffice
        Dim updateOffice As New Office
        updateOffice.OfficeID = 15
        updateOffice.OfficeName = "PT Bintang 11"
        updateOffice.OfficeAddress = "PT Bintang 11"
        updateOffice.OfficeFlagActive = 1

        Try
            Dim result = OfficeDAL.update(updateOffice)
            If result = 1 Then
                Console.WriteLine("Update failed")
            Else
                Console.WriteLine("Update success")
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Sub OfficeDeleteDB()
        Dim OfficeDAL As New BSIGeneralAffairDAL.DALOffice
        Dim OfficeID As Integer = 17
        Try
            Dim result = OfficeDAL.delete(OfficeID)
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
