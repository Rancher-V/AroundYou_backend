using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AroudYou.Migrations
{
    public partial class alterItemIdType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Items_ItemId",
                table: "Favorites");
            migrationBuilder.DropIndex(
                name: "IX_Favorites_ItemId",
                table: "Favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemCategories",
                table: "ItemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemCategories_Items_ItemId",
                table: "ItemCategories");
            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropColumn(
               name: "ItemId",
               table: "ItemCategories");
            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Favorites");
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Items");
           

            migrationBuilder.AddColumn<string>(
                    name: "Id",
                    table: "Items",
                    nullable: false
                );
            migrationBuilder.AddColumn<string>(
                    name: "ItemId",
                    table: "ItemCategories",
                    nullable: false
                );
            migrationBuilder.AddColumn<string>(
                    name: "ItemId",
                    table: "Favorites",
                    nullable: true
                );
            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemCategories",
                table: "ItemCategories",
                columns: new[] { "ItemId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCategories_Items_ItemId",
                table: "ItemCategories",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ItemId",
                table: "Favorites",
                column: "ItemId");


            //migrationBuilder.AlterColumn<string>(
            //    name: "Id",
            //    table: "Items",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //migrationBuilder.AlterColumn<string>(
            //    name: "ItemId",
            //    table: "ItemCategories",
            //    nullable: false,
            //    oldClrType: typeof(int));

            //migrationBuilder.AlterColumn<string>(
            //    name: "ItemId",
            //    table: "Favorites",
            //    nullable: true,
            //    oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Items_ItemId",
                table: "Favorites",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Items_ItemId",
                table: "Favorites");
            migrationBuilder.DropIndex(
                name: "IX_Favorites_ItemId",
                table: "Favorites");
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemCategories",
                table: "ItemCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemCategories_Items_ItemId",
                table: "ItemCategories");
            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropColumn(
               name: "ItemId",
               table: "ItemCategories");
            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Favorites");
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Items");


            migrationBuilder.AddColumn<int>(
                    name: "Id",
                    table: "Items",
                    nullable: false
                );
            migrationBuilder.AddColumn<int>(
                    name: "ItemId",
                    table: "ItemCategories",
                    nullable: false
                );
            migrationBuilder.AddColumn<int>(
                    name: "ItemId",
                    table: "Favorites",
                    nullable: true
                );

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemCategories",
                table: "ItemCategories",
                columns: new[] { "ItemId", "CategoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCategories_Items_ItemId",
                table: "ItemCategories",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ItemId",
                table: "Favorites",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Items_ItemId",
                table: "Favorites",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);



            //migrationBuilder.DropForeignKey(
            //    name: "FK_Favorites_Items_ItemId",
            //    table: "Favorites");

            //migrationBuilder.DropColumn(
            //    name: "Id",
            //    table: "Items");
            //migrationBuilder.DropColumn(
            //    name: "ItemId",
            //    table: "ItemCategories");
            //migrationBuilder.DropColumn(
            //    name: "ItemId",
            //    table: "Favorites");

            //migrationBuilder.AddColumn<int>(
            //        name: "Id",
            //        table: "Items",
            //        nullable: false
            //    );
            //migrationBuilder.AddColumn<int>(
            //        name: "ItemId",
            //        table: "ItemCategories",
            //        nullable: false
            //    );
            //migrationBuilder.AddColumn<int>(
            //        name: "ItemId",
            //        table: "Favorites",
            //        nullable: true
            //    );



            ////migrationBuilder.AlterColumn<int>(
            ////    name: "Id",
            ////    table: "Items",
            ////    nullable: false,
            ////    oldClrType: typeof(string))
            ////    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            ////migrationBuilder.AlterColumn<int>(
            ////    name: "ItemId",
            ////    table: "ItemCategories",
            ////    nullable: false,
            ////    oldClrType: typeof(string));

            ////migrationBuilder.AlterColumn<int>(
            ////    name: "ItemId",
            ////    table: "Favorites",
            ////    nullable: false,
            ////    oldClrType: typeof(string),
            ////    oldNullable: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Favorites_Items_ItemId",
            //    table: "Favorites",
            //    column: "ItemId",
            //    principalTable: "Items",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
