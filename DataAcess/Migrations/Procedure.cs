using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Procedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var query = @"CREATE PROCEDURE GetMebli
                        AS
                        SELECT* FROM Meblis
                        GO

                        CREATE PROCEDURE GetMebli @id int
                        AS
                        SELECT* FROM Meblis WHERE id = @id
                        GO

                        CREATE PROCEDURE AddMebli @Price int, @ProdavecID int
                        AS
                        INSERT INTO Meblis(Price, ProdavecID) VALUES(@Price, @ProdavecID)
                        GO

                        CREATE PROCEDURE EditMebli @id int, @Price int, @ProdavecID int
                        AS
                        UPDATE Meblis
                        SET Price = @Price, ProdavecID = @ProdavecID
                        WHERE id = @id
                        GO

                        CREATE PROCEDURE DeleteMebli @id int
                        AS
                        DELETE FROM Meblis
                        WHERE id = @id
                        GO

                        CREATE PROCEDURE GetOpis
                        AS
                        SELECT* FROM Opsis
                        GO

                        CREATE PROCEDURE GetOpis @Id int
                        AS
                        SELECT* FROM Opsis
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE AddOpis @Virobnik nvarchar(MAX), @Material nvarchar(MAX), @MebliID int
                        AS
                        INSERT INTO Opsis(Virobnik, Material, MebliID) VALUES(@Virobnik, @Material, @MebliID)
                        GO

                        CREATE PROCEDURE EditOpis @Id int, @Virobnik nvarchar(MAX), @Material nvarchar(MAX), @MebliID int
                        AS
                        UPDATE Opsis
                        SET Virobnik = @Virobnik, Material = @Material, MebliID = @MebliID
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE DeleteOpis @Id int
                        AS
                        DELETE FROM Opsis
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE GetPocupci
                        AS
                        SELECT* FROM Pocupcis
                        GO

                        CREATE PROCEDURE GetPocupci @Id int
                        AS
                        SELECT* FROM Pocupcis
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE AddPocupci @FullName nvarchar(MAX), @Email nvarchar(MAX)
                        AS
                        INSERT INTO Pocupcis(FullName, Email) VALUES(@FullName, @Email)
                        GO

                        CREATE PROCEDURE EditPocupci @Id int, @FullName nvarchar(MAX), @Email nvarchar(MAX)
                        AS
                        UPDATE Pocupcis
                        SET FullName = @FullName, Email = @Email
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE DeletePocupci @Id int
                        AS
                        DELETE FROM Pocupcis
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE GetZamovlennya
                        AS
                        SELECT* FROM Zamovlennyas
                        GO

                        CREATE PROCEDURE GetZamovlennya @Id int
                        AS
                        SELECT* FROM Zamovlennyas
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE AddOZamovlennya @MebliID int, @PocupciID int
                        AS
                        INSERT INTO Zamovlennyas(MebliID, PocupciID) VALUES(@MebliID, @PocupciID)
                        GO

                        CREATE PROCEDURE EditZamovlennya @Id int, @MebliID int, @PocupciID int
                        AS
                        UPDATE Zamovlennyas
                        SET MebliID = @MebliID, PocupciID = @PocupciID
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE DeleteZamovlennya @Id int
                        AS
                        DELETE FROM Zamovlennyas
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE GetProdavci
                        AS
                        SELECT* FROM Prodavcis
                        GO

                        CREATE PROCEDURE GetProdavci @Id int
                        AS
                        SELECT* FROM Prodavcis
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE AddProdavci @Email nvarchar(MAX)
                        AS
                        INSERT INTO Prodavcis(Email) VALUES(@Email)
                        GO

                        CREATE PROCEDURE EditProdavci @Id int, @Email nvarchar(MAX)
                        AS
                        UPDATE Prodavcis
                        SET Email = @Email
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE DeleteProdavci @Id int
                        AS
                        DELETE FROM Prodavcis
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE GetRobitniki
                        AS
                        SELECT* FROM Robitnikis
                        GO

                        CREATE PROCEDURE GetRobitniki @Id int
                        AS
                        SELECT* FROM Robitnikis
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE AddRobitniki @FullName nvarchar(MAX), @Staj int
                        AS
                        INSERT INTO Robitnikis(FullName, Staj) VALUES(@FullName, @Staj)
                        GO

                        CREATE PROCEDURE EditRobitniki @Id int, @FullName nvarchar(MAX), @Staj int
                        AS
                        UPDATE Robitnikis
                        SET FullName = @FullName, Staj = @Staj
                        WHERE Id = @Id
                        GO

                        CREATE PROCEDURE DeleteRobitniki @Id int
                        AS
                        DELETE FROM Robitnikis
                        WHERE Id = @Id
                        GO";

            migrationBuilder.Sql(query);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
