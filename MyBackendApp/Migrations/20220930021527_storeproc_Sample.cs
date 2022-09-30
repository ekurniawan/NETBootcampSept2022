﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBackendApp.Migrations
{
    public partial class storeproc_Sample : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.SamuraisWhoSaidAWord
               @text VARCHAR(20)
               AS
               SELECT      Samurais.Id, Samurais.Name
               FROM        Samurais INNER JOIN
                           Quotes ON Samurais.Id = Quotes.SamuraiId
               WHERE      (Quotes.Text LIKE '%'+@text+'%')");

            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.DeleteQuotesForSamurai
             @samuraiId int
             AS
             DELETE FROM Quotes
             WHERE Quotes.SamuraiId=@samuraiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop procedure SamuraisWhoSaidAWord");
            migrationBuilder.Sql(@"drop procedure DeleteQuotesForSamurai");
        }
    }
}
