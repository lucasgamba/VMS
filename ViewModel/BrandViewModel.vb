'BrandViewModel class added by the syncfusion
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace VMS.vb.net

    Public Class BrandViewModel

        Public ReadOnly Property CanadaData As ObservableCollection(Of BrandModel)

        Public ReadOnly Property FranceData As ObservableCollection(Of BrandModel)

        Public Property PlantDetails As ObservableCollection(Of BrandModel)

        Public Sub New()

            CanadaData = New ObservableCollection(Of BrandModel)()
            CanadaData.Add(New BrandModel() With {
                .Year = "2000",
                .Value = 26.8
            })
            CanadaData.Add(New BrandModel() With {
                .Year = "2001",
                .Value = 29
            })
            CanadaData.Add(New BrandModel() With {
                .Year = "2002",
                .Value = 27.5
            })
            CanadaData.Add(New BrandModel() With {
                .Year = "2003",
                .Value = 28.4
            })
            CanadaData.Add(New BrandModel() With {
                .Year = "2004",
                .Value = 26.5
            })
            CanadaData.Add(New BrandModel() With {
                .Year = "2005",
                .Value = 25.1
            })


            FranceData = New ObservableCollection(Of BrandModel)()
            FranceData.Add(New BrandModel() With {
                .Year = "2000",
                .Value = 9.3
            })
            FranceData.Add(New BrandModel() With {
                .Year = "2001",
                .Value = 8.3
            })
            FranceData.Add(New BrandModel() With {
                .Year = "2002",
                .Value = 9.2
            })
            FranceData.Add(New BrandModel() With {
                .Year = "2003",
                .Value = 9.9
            })
            FranceData.Add(New BrandModel() With {
                .Year = "2004",
                .Value = 9.6
            })
            FranceData.Add(New BrandModel() With {
                .Year = "2005",
                .Value = 10.8
            })

            PlantDetails = New ObservableCollection(Of BrandModel)() From {
    New BrandModel() With {
        .Direction = "North",
        .Tree = 80
    },
    New BrandModel() With {
        .Direction = "NorthWest",
        .Tree = 87
    },
    New BrandModel() With {
        .Direction = "West",
        .Tree = 78
    },
    New BrandModel() With {
        .Direction = "SouthWest",
        .Tree = 85
    },
    New BrandModel() With {
        .Direction = "South",
        .Tree = 81
    },
    New BrandModel() With {
        .Direction = "SouthEast",
        .Tree = 88
    },
    New BrandModel() With {
        .Direction = "East",
        .Tree = 80
    },
    New BrandModel() With {
        .Direction = "NorthEast",
        .Tree = 85
    }
}

        End Sub

    End Class

End Namespace
