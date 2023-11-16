using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableTennis4dView.Infrastructure.Migrations
{
    public partial class Addanewsample : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Ownership = table.Column<int>(type: "int", nullable: false),
                    DominantHand = table.Column<int>(type: "int", nullable: false),
                    InvertedNameOrder = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserPlayer",
                columns: table => new
                {
                    ApplicationUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlayersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserPlayer", x => new { x.ApplicationUsersId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserPlayer_AspNetUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserPlayer_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Techniques",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerId = table.Column<long>(type: "bigint", nullable: false),
                    SourcePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Techniques", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Techniques_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "097f6233-0db5-4347-aad0-14e20625e5be", "538d76f0-c284-4b4d-8440-a0241b01490e", "Admin", "ADMIN" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "5b95d507-2c92-4f7b-badf-1ab2f2d9e9a4", "User", "USER" },
                    { "382ececc-2b01-4e85-a63f-2387f547c1f2", "1eb6198a-d17d-4550-88b7-d9a10233bc65", "Management", "MANAGEMENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "04b594c0-f5ef-45e0-be39-fcc76372986d", 0, "c8c01ac3-6223-4b61-af90-d31c6c69a117", "demo13@gmail.com", false, null, false, null, null, "DEMO13", "AQAAAAEAACcQAAAAEM78ayszhhQWfepP6nyRFjhrxYbEdGTKNVwa0GUu0E88hYN3TYL7JFYSbS713KLypg==", null, false, "10d7b919-f0d6-45ac-a50e-196feb288ad9", false, "demo13" },
                    { "0bcdf15d-064c-4e00-afbc-0a96ef149624", 0, "7b6d6f8e-7897-4dce-8b0b-261382586487", "demo35@gmail.com", false, null, false, null, null, "DEMO35", "AQAAAAEAACcQAAAAEK/qzMHc+zThalVKRe4YpK75Nt+rRRtn9hn/CNlVYO0NUJ1w37VdKF7tGCWE50VB8g==", null, false, "3af38aa5-cd8c-4cf3-9f84-b34eb0fa78fd", false, "demo35" },
                    { "0eb1f2ee-4067-49c4-bebd-78ede6d9b87f", 0, "67edff88-0ca0-4351-940c-e5c4aca9e119", "demo58@gmail.com", false, null, false, null, null, "DEMO58", "AQAAAAEAACcQAAAAEEEPutLE0VDMfKFFzn96mNdJkEj+fzRrlCfr5i518aiMkmmHuc2Dr5WQaDyplzhi0A==", null, false, "861ffb05-8479-4f4b-b1a7-2d574f9e79b7", false, "demo58" },
                    { "15799da3-9eae-499f-8f5b-50f0cffbd2db", 0, "ec553145-8d8a-4fb8-9aea-eba2adaf101f", "demo86@gmail.com", false, null, false, null, null, "DEMO86", "AQAAAAEAACcQAAAAEINhIJz5KFxHhXRgWOCcy9Vhg+G0p9MZMasByu7HSTD06ihKRrxqmmLZFag8jJv0hQ==", null, false, "431cc7e3-9ac1-406c-8ee3-6d9d7d28e7f0", false, "demo86" },
                    { "173c8b1c-2dcc-4668-9a86-09769886f211", 0, "40ea3c95-6c6a-4351-8bd2-a3b279707e95", "demo39@gmail.com", false, null, false, null, null, "DEMO39", "AQAAAAEAACcQAAAAEGx6jUzxsWNuxKPMV2yJ/c4VA6ugKoFf6zdm65Nuewy4OdcUOgKVIZ0I/TszvfDCQg==", null, false, "abc00819-25cc-4137-8621-3266187454e2", false, "demo39" },
                    { "17e09b65-8ffc-4e6b-97ab-18f5557ca315", 0, "99fb0b5a-9f56-4763-9ae5-f9399cc5f4e2", "demo30@gmail.com", false, null, false, null, null, "DEMO30", "AQAAAAEAACcQAAAAENGYH1uPb3vsBcdcpec2aCPGIlugVTl3WNesThoiDTTfyisRRORYstQNG+UDSOoiTw==", null, false, "c21d9916-c59e-4d6b-81bf-80e0ad33b0c5", false, "demo30" },
                    { "1a86db69-6a3a-42d5-9ff1-0e368d5562ad", 0, "35bde76a-2b4f-44f8-b4b6-e97db05bf93e", "demo88@gmail.com", false, null, false, null, null, "DEMO88", "AQAAAAEAACcQAAAAEE6C/LvgS4pRUwPNHQA7WgVBcT9Hl2TFVy5dEerSnoHkbxi3YpxDsKuR9KwzDAuHzA==", null, false, "04218184-8196-44e7-9996-cb1852f415c2", false, "demo88" },
                    { "1d18cc3c-6336-4af4-ace3-46b86e98ed3a", 0, "624293a4-1a84-4f43-8324-e99c11a44a9d", "demo53@gmail.com", false, null, false, null, null, "DEMO53", "AQAAAAEAACcQAAAAENf9ZpDJ+5fbikhlTeq7eZcHw/uO4ZgFRxAchv+JjYcdpx8aH/X3JKm0zbCVSAftqA==", null, false, "41f4f243-a2ac-4a5c-adfb-918f9c57d307", false, "demo53" },
                    { "249cd65e-8528-4ca8-9f8f-278150445a10", 0, "69cf495b-86d6-4914-bc27-883dcf0e21ec", "demo27@gmail.com", false, null, false, null, null, "DEMO27", "AQAAAAEAACcQAAAAEFs90HOteb/MixOEEvXWiIRKfq9vw/Vt60WiOsRGiNeMnqYbBqKrb135rtTM6z3w8Q==", null, false, "98a75ac7-01ff-453e-8e2b-f1bc1d7af160", false, "demo27" },
                    { "2b1813c6-b5c0-49ed-81dc-d4342f457954", 0, "91791f75-4905-43ee-b23f-90a4eac380b1", "demo77@gmail.com", false, null, false, null, null, "DEMO77", "AQAAAAEAACcQAAAAEBM2oi0FIeGe6gcl9UMtBQu+cwGdw6vjnbm8Y8nlFIdeNVSKCtIbyheCU3H9al7njQ==", null, false, "dfc9aaad-968f-4325-a6d0-33e729ddfec9", false, "demo77" },
                    { "3104c9f6-6dbf-4cf3-a542-462ad606d2a2", 0, "b8e347d1-d706-4dfc-abec-972e0045e165", "demo60@gmail.com", false, null, false, null, null, "DEMO60", "AQAAAAEAACcQAAAAEDwprKklcilFqm7qNiMpF+BKXJauWGrirXb/hUQBCp8cngfmYz07J1WuRr9UY3/hJg==", null, false, "d6a58b2a-fe6c-494f-be16-313979c0e463", false, "demo60" },
                    { "3171181e-1d0f-41d8-a626-a6f0d29be678", 0, "b2937708-4b16-4bff-b5fc-80c907a9c22d", "demo20@gmail.com", false, null, false, null, null, "DEMO20", "AQAAAAEAACcQAAAAEPW0eKfAANNeTrKhdGRTM8LPjoCrh9kqEYS3wvNrE5ojCiQ2/ystJMalQObxc/QJZA==", null, false, "baf695cf-1af1-4d8f-a8f1-b93c3b4f4f32", false, "demo20" },
                    { "338760fc-7971-4a63-959c-a9d16c954421", 0, "8437458b-4c9a-47b8-a759-d93e90091155", "demo50@gmail.com", false, null, false, null, null, "DEMO50", "AQAAAAEAACcQAAAAEB0ymSqZnHW7QdSlqs55tb17zBTy5c2zspKCOMDogmOF/J8FMnG6z+2WEjt7QrSqrA==", null, false, "16cbb8bc-d703-4ffe-a5fc-4fc05be438bd", false, "demo50" },
                    { "35f0c66b-fb97-4c90-964c-c5986fdbaf63", 0, "ff3d11b9-582e-42e7-933e-c5d335fc8e4b", "demo44@gmail.com", false, null, false, null, null, "DEMO44", "AQAAAAEAACcQAAAAENB1Ryw+kKFlKL5fdbkLDxpI730GVUJLy8m07tbb0QZFTmVG5MLdnjBD6KwLMoxoYw==", null, false, "540c3920-a2bd-4482-828c-815f9129d283", false, "demo44" },
                    { "39f76f4b-54c5-4407-90d7-4c98a64b2d4b", 0, "07e6a321-db74-4464-95c5-b5f8ddb16db1", "demo12@gmail.com", false, null, false, null, null, "DEMO12", "AQAAAAEAACcQAAAAEAP3fMyCYlFV7rFjq8uIL0s2ouz867gyB3ZQBKgKu1+IenGppP2QXF4IaKzyDtpO9Q==", null, false, "61edf27f-b9c7-4e5a-b9b0-ab3dd4298bbf", false, "demo12" },
                    { "3b983e1b-6908-49fb-ac17-f9111d4df502", 0, "41512f8f-f156-49d1-83aa-c4d9c336a99d", "demo40@gmail.com", false, null, false, null, null, "DEMO40", "AQAAAAEAACcQAAAAEMorHHLQfNQ+AGZXafaeMw5ZszOVWTtz0V2DafCs3pTGeMDywP5RD8loscMuST0fVw==", null, false, "241df0d3-daed-4162-82e2-f4f3eef3225d", false, "demo40" },
                    { "3c87c60e-cf18-4514-b122-ab09b1753677", 0, "b10dbcc6-5e2f-48d4-85c4-aff94c24f2be", "demo99@gmail.com", false, null, false, null, null, "DEMO99", "AQAAAAEAACcQAAAAEKJuFF87x0urwN4lb8dDmsdyp486cI3l0lrJVydAQ4PWKh000v8gjstPR/wDUL7Rxg==", null, false, "2cf8c0da-8373-4246-9c93-dba3cbfc2c61", false, "demo99" },
                    { "3e07cd99-f3a8-42ba-8710-6cf498d05b3f", 0, "1edc8362-ad42-40b3-bf02-b6784a40ead0", "demo84@gmail.com", false, null, false, null, null, "DEMO84", "AQAAAAEAACcQAAAAEHHX55wqRymOkhjCh/hTBUh0qNyYeY1WuE5OIJMry0wZVMB1j098ApXsIowXbMGGgQ==", null, false, "f40d20f9-7c43-4259-9a07-db982b557ec5", false, "demo84" },
                    { "41be9677-d873-45bb-927d-1ddbef61fb26", 0, "a24430d5-adbd-44fc-8679-2a9d3d2208fd", "demo17@gmail.com", false, null, false, null, null, "DEMO17", "AQAAAAEAACcQAAAAEJyy/BepiX0YuZyWa5KFl0AOdw5Qk3oy6/RnFv4cX5R0LGHQVtyyelcid6jP6unukA==", null, false, "ba758ab1-d662-4d26-af0b-b64a28298c54", false, "demo17" },
                    { "43d8ef57-f237-44b5-b10c-0599d36ce1ab", 0, "2920d6b5-0fe5-4268-8186-ade08d24c7d4", "demo82@gmail.com", false, null, false, null, null, "DEMO82", "AQAAAAEAACcQAAAAEGF4BH4q7XFUDXM1D07hCvpEmxE1La40w0+0y+UQXIPuxTWldcYb7RP99ZP9rqFLyg==", null, false, "7530be2b-a481-432e-98ff-66f902be2555", false, "demo82" },
                    { "4566331e-202a-4100-a1b0-823bfc86c5a1", 0, "2b06d1b4-b841-4952-a43a-8a8cfb7c6c0d", "demo91@gmail.com", false, null, false, null, null, "DEMO91", "AQAAAAEAACcQAAAAEJSiCw7jTc1g/Dn+fOR5rydgLHYFI8z/sXu2Fpne4m1YXe8l524V9Ro5sI+zk2KyAA==", null, false, "0ced1e80-472a-42cb-aeaa-6c95a8012ab9", false, "demo91" },
                    { "49bd3837-9e6f-41bd-b709-f835f06f142f", 0, "c658c90e-55b4-4c59-bf18-712df0a5879c", "demo85@gmail.com", false, null, false, null, null, "DEMO85", "AQAAAAEAACcQAAAAEITjRYQiDrIYQjXZl5bA9wgdEHHQX3LPQBcVP5FL4bZyfA522GV8QtgHCBypvDm0Pg==", null, false, "3a0617c8-4d8b-4033-8768-54e7980a7f12", false, "demo85" },
                    { "49efa8c2-1a71-478e-8b9a-bc0c5061829f", 0, "cc47d569-2cc9-443d-95ec-03ae7e238efb", "demo48@gmail.com", false, null, false, null, null, "DEMO48", "AQAAAAEAACcQAAAAEL1cw6gFTf/pvRoKPBRVZKIH3jr+YqTi0MpBqUKYxMKMxxMkna8U7+3ZHkA31vFu8g==", null, false, "e47f436f-bd3f-4ec3-bac8-8ff12b70415b", false, "demo48" },
                    { "4ad9d690-c153-42a6-be1d-d4b9ca74d2d4", 0, "4cfa484d-9dcf-4edc-b249-ada8e2510db6", "demo21@gmail.com", false, null, false, null, null, "DEMO21", "AQAAAAEAACcQAAAAEDIfuIu0I8zDR2CtOL+qN3xhtE3xEx5X0EcBIKsurFYE9Mo+GpDpJseJ/4GbAR6mZA==", null, false, "60194c8e-d07e-4da0-9a15-94bb8022f3c5", false, "demo21" },
                    { "53bd4bd1-f647-46bd-b4ee-5f5b11d9370d", 0, "40da33f5-6b7e-4432-9cca-4ce88faeafe1", "demo23@gmail.com", false, null, false, null, null, "DEMO23", "AQAAAAEAACcQAAAAELoIMsrHZu46BxDd1UFG3NNaEJrdjhdn8X2msGmEDmJTY2V33/XZv6O0fMiuXTdaPQ==", null, false, "d0cddc23-8d9f-48a7-87ce-289b6e5aa556", false, "demo23" },
                    { "53e0f2fe-cd73-4d6d-83d2-a3173dd32a34", 0, "daacff50-dc14-45b1-81a1-ac0d9868a5d5", "demo74@gmail.com", false, null, false, null, null, "DEMO74", "AQAAAAEAACcQAAAAEBSy07vjKQ37e5xgxVAwG2g6LqmNddcE/TtLJ3TMKEcfpXG3NHURZWzoCzKjJuceow==", null, false, "2b39a99c-da48-40c0-a9e2-311f582456cb", false, "demo74" },
                    { "542b4881-199a-4b98-8214-daca312a12ed", 0, "6816ef02-600a-4a2c-b693-74a4bb115a4e", "demo57@gmail.com", false, null, false, null, null, "DEMO57", "AQAAAAEAACcQAAAAED1mrRbeU3jbeHvubwbaf9fRxcgEaudM8TM5NmNqOdL5TCefEIUZcbN6jk8ubj8Syg==", null, false, "0c064005-f00d-4ba6-b874-2ca44b15bbd1", false, "demo57" },
                    { "5835cf98-55e2-4732-95f9-d62566a3b4b8", 0, "8f5bc6b8-a67d-4cfe-b4f0-413d3e532a18", "demo18@gmail.com", false, null, false, null, null, "DEMO18", "AQAAAAEAACcQAAAAELd4tRs0qQgXI9XxnP1/nK+JJ0qmlSabiDfohqyGgxigZ8i081c7rQi/Po+GyakYPQ==", null, false, "7900d345-ef38-4e95-ae95-f4cb8d25336d", false, "demo18" },
                    { "59fbfea0-4d38-41c4-972f-7e502d0e5d15", 0, "75e90138-07e1-4b54-afe7-bcd7c345a4e5", "demo87@gmail.com", false, null, false, null, null, "DEMO87", "AQAAAAEAACcQAAAAEMaFp7uF4osU0hqjxyyiygRKjZrIbWytnNIusVoDy3Xi3JvQpi354W3G/Xzelcyo/g==", null, false, "bbe2fc1f-edd6-46be-b506-6c981fa8c025", false, "demo87" },
                    { "5cfbb116-5005-4f61-8fd2-9dcb63d0bdc4", 0, "d3ca3d5d-9127-4181-b7aa-e02d792de451", "demo93@gmail.com", false, null, false, null, null, "DEMO93", "AQAAAAEAACcQAAAAEG/wgzU9TiwpS7c/WLzaRxkxzTs/t9x7UYEPM0H8enG7RftizKuJVh871IJ9ZuCFdg==", null, false, "37ffc1de-cb3a-45f3-a13b-747f74197e28", false, "demo93" },
                    { "5d4c73b7-0133-4fdc-9fdb-3c1573f8ae68", 0, "a26a8027-4953-4608-a394-3c67be8efcd8", "demo94@gmail.com", false, null, false, null, null, "DEMO94", "AQAAAAEAACcQAAAAEPMXPkERhD7CJE3lKr3QSqxHy6ck/5rgGH1Tv7EZzrUaN8ENakqlZ59wFvv/KUKMiA==", null, false, "03d004d2-0bb5-4def-b174-c356e22f92f5", false, "demo94" },
                    { "60e556b9-84c8-47d1-81dc-eb82f4078c33", 0, "eec1a877-853b-4dd8-8536-0b752205923b", "demo89@gmail.com", false, null, false, null, null, "DEMO89", "AQAAAAEAACcQAAAAEAh1996MbvB7mPJZJ8FQfxENPELn8H4ZearD/Qnew269ggqTwTqg6WaD7QFjYMCJ6w==", null, false, "e0cf69d8-f500-426b-8780-a4e01ad5ab5c", false, "demo89" },
                    { "68caf9c3-fbca-4058-913d-bff7dc6a5dfb", 0, "d47afcb1-b194-4626-b335-7bf3f5895bcd", "demo97@gmail.com", false, null, false, null, null, "DEMO97", "AQAAAAEAACcQAAAAEGuJnk2OIqNgC1Fr0XAX4AiiS2CfDMrsWvPkEgtgCAc4P9DNFvZJQaVUSLpEB/lDEw==", null, false, "c1cb285d-f476-487c-aa72-d95bd8b12373", false, "demo97" },
                    { "6b0ec92d-05e1-4fbf-929c-2018c02164c1", 0, "110bd84b-cb03-4e12-8b55-97367d71d4da", "demo2@gmail.com", false, null, false, null, null, "DEMO2", "AQAAAAEAACcQAAAAELcITQPPVQOytBnjYeqbqsN7T5m7ONdAuXJe5LY62X21SRNOiorYIemMC2VBPcKj5Q==", null, false, "4f1ad0cd-69cc-459f-b377-e96f453f99fb", false, "demo2" },
                    { "6be793bc-c29c-43aa-80f6-7fab7d392bb9", 0, "f457a6f2-67c4-48e8-9258-6b46bdfb65dc", "demo34@gmail.com", false, null, false, null, null, "DEMO34", "AQAAAAEAACcQAAAAEEE1FAvho95sAhKAHKYm4WZGu4zomY9IC3/ctaES4ryFGf1Xc9s002LoL/zwyNCF9Q==", null, false, "a637abe9-d704-4a4e-bec3-f402e8f7a27e", false, "demo34" },
                    { "723543d4-3deb-446d-a737-ee68b3d03dbb", 0, "cf34ad3e-bd6b-4ba8-b269-34956b5329e9", "demo36@gmail.com", false, null, false, null, null, "DEMO36", "AQAAAAEAACcQAAAAENJzK8bmUlpp9doRqEL6UVIlOaiHqr9APCuL7Lhp+xOr/EGs1EjHZm9Wto7qkaB9kg==", null, false, "35c6e17f-f353-4db9-b791-ffe4671b84f4", false, "demo36" },
                    { "72d48439-5aaa-4e98-8b45-e382bb34617d", 0, "7c2f9f65-80b9-404b-a754-8c69146d0153", "demo78@gmail.com", false, null, false, null, null, "DEMO78", "AQAAAAEAACcQAAAAEESlN2ERrgWUFIr6ogwb21d/7lJHxP7eO+fLwmh+SsCZSWKlOU1eb9qC27QttXYMDA==", null, false, "b8d3b132-4a32-48cf-ac7c-45c71eabcb18", false, "demo78" },
                    { "7a654e0c-4087-4c5a-aaa0-9f5e68cd9200", 0, "c3a8f61d-aa0e-4075-b834-e30e7fee0952", "demo25@gmail.com", false, null, false, null, null, "DEMO25", "AQAAAAEAACcQAAAAEDvQnLBpIeoCOdI9S50P/o5VC1Y3f6ss/qOak0u3Zr6TabB1wZ1gt+zo2hpasHgEbw==", null, false, "88720c23-65e0-4126-bf1c-24d9f65e71c3", false, "demo25" },
                    { "7ebc5810-66d9-48d5-8fa2-0b7ff85f69af", 0, "0a3d75b9-9807-4115-8157-e39e8c0bfe0f", "demo64@gmail.com", false, null, false, null, null, "DEMO64", "AQAAAAEAACcQAAAAEL4GtLju0nA+K5pzuv+b3CTAhYu5E5mXeB/oDTOqeBddO09vDiPppKi8KPvACMIyMw==", null, false, "f18f2e73-0185-4835-a45d-af1d333972ee", false, "demo64" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7f689b0e-4699-42e2-afaf-1ab55fede3b7", 0, "5a36bb25-cbe9-44a3-8ab9-c4a27b2bab97", "demo29@gmail.com", false, null, false, null, null, "DEMO29", "AQAAAAEAACcQAAAAEKGbwPDYlc6kPxEWEUNM9KpH8lLlEijw/zBRy18OVBDv0LZb+k4u8Kigv8elsEJakw==", null, false, "84b96ace-6aac-4116-8fa3-b564c7e97d5e", false, "demo29" },
                    { "801c9002-41aa-43ec-913d-788a5917c6e3", 0, "25bcbdbd-1f03-490a-9a6e-a88077d6e0ac", "demo49@gmail.com", false, null, false, null, null, "DEMO49", "AQAAAAEAACcQAAAAEL8KSzgtvmmrdjZLjtPJ1jUaY/W5phwM0bWmPZ//ogN08fm89Xsc2gntSRkLMX9jeA==", null, false, "a15ae5ec-8510-45ca-aba6-4c73e7a672e9", false, "demo49" },
                    { "81d8d81c-c4c5-42f5-b427-10d9c7b9b615", 0, "bfcd62e3-7926-4464-a8e2-b1e2ed14d129", "demo1@gmail.com", false, null, false, null, null, "DEMO1", "AQAAAAEAACcQAAAAEBv+Pa8acl5oeosFiGhkz+eKZ8KXvlcEoUFEy9Srl6vYwMtVrszSouIsKzDfpk0pSw==", null, false, "1e1b3f82-53b8-4382-a635-b7046fa9783a", false, "demo1" },
                    { "833cfacf-d13a-4152-95ea-189243a8a7fa", 0, "903b51ea-2847-4a02-86a6-6fe70713f153", "demo24@gmail.com", false, null, false, null, null, "DEMO24", "AQAAAAEAACcQAAAAEKZetisjIGfLjRvFGQim43twMaZjwWllFT1zN0ZAG+Nl2TqKWqR7AGZuhfdBnh13sA==", null, false, "d4828014-833e-48fe-b29b-041a2aca3e7a", false, "demo24" },
                    { "840c004b-abd3-4e1f-be23-81c656dc1018", 0, "d8a824b5-f329-4928-847a-1e9153dd37a7", "demo56@gmail.com", false, null, false, null, null, "DEMO56", "AQAAAAEAACcQAAAAENR3H7PRgoEFo3i9sNzzNi8PmBv54CWlLw9WjPPPYn774LOqijkMUSbbsGczeTjc8A==", null, false, "1c0de9fa-be1c-4f59-abed-81731c73ee4e", false, "demo56" },
                    { "847954b0-abfe-4c83-8ecc-31ddb4041c02", 0, "9898479c-8336-4243-80b6-a2f97a3bf371", "demo71@gmail.com", false, null, false, null, null, "DEMO71", "AQAAAAEAACcQAAAAEDkp6WCciK2CYoQaMbnYctH/9qMFaxXXaAs4V1//b22oUOwN68DnrbHsUsVYXI/wJA==", null, false, "3ece074b-ede7-4a64-88e2-d14ebc6ed827", false, "demo71" },
                    { "871f2a58-e6cf-428e-8c61-fe46e22cd296", 0, "a6acc739-ee71-48f1-803a-9b37e045ddbf", "demo15@gmail.com", false, null, false, null, null, "DEMO15", "AQAAAAEAACcQAAAAEEv+20NDPell0PGyLfZrtbjhWqAjwnvaG4T1W2VYt1aeV5L+XrFNKOAdgbMSOiU1vg==", null, false, "106475b8-3114-4552-92d6-734e79b7fb6a", false, "demo15" },
                    { "892495de-3732-4994-948b-2102a0ef3fe2", 0, "24009b08-d220-4c78-929b-2f49e3d35dc0", "demo8@gmail.com", false, null, false, null, null, "DEMO8", "AQAAAAEAACcQAAAAEOzdZTom7qzU1qbdkCyLkqrVHh8/fDqx/hNGElwmAGsGJk2xT6uufTGqy7lekYA4ow==", null, false, "8f88e48c-7b81-4b87-a755-46ce79142775", false, "demo8" },
                    { "913863f2-32aa-4faa-8094-e170094aef0f", 0, "ba7d9386-c948-4cc6-bfb5-5560ff7d6c80", "demo22@gmail.com", false, null, false, null, null, "DEMO22", "AQAAAAEAACcQAAAAEGjfRsfSWOj5Z8MH9AGLl+LIIP4kL0bdSqqDazui5nvhHJtXjt7ey2SAssiSGGslhQ==", null, false, "fbfe450a-ddb3-4c14-8796-ee354a077307", false, "demo22" },
                    { "944ce887-2c07-477e-9b84-d6ffad369846", 0, "3c49975d-7202-4216-92c0-8266376f6c57", "demo100@gmail.com", false, null, false, null, null, "DEMO100", "AQAAAAEAACcQAAAAEHjfFFhBgvoF9444un5binJjBJEAvL645bVT35qkhDcvAIUaEy9vYhFBXNfVvWz27w==", null, false, "cf64e27a-a445-44cb-9c4d-2a1461545e75", false, "demo100" },
                    { "9a9cc7fd-e0cc-49f1-9a49-356a25200749", 0, "d1673a6c-341c-4cc3-9e09-5f253498eea2", "demo46@gmail.com", false, null, false, null, null, "DEMO46", "AQAAAAEAACcQAAAAEMfeEJHa80NomD6H2WExgK2cKQOU7RdWQAPeCU+iyMT822M9Y3sVg7GRpwf35b5iwA==", null, false, "9d1a8082-bca2-4719-9f31-0b5da3a8f0ad", false, "demo46" },
                    { "9cd7d2f3-6adf-47ab-b2b8-ef8e7ce626a3", 0, "230c13b0-34c3-4826-8d3c-a9dfb214ae69", "demo10@gmail.com", false, null, false, null, null, "DEMO10", "AQAAAAEAACcQAAAAEDMmKuW1+5lZKhoX1fVgZO2xvmJySXOTA0Rzr48ukj31zGNDha8EQn5NYywFaJKTag==", null, false, "f3e1bd4d-320b-43a4-8733-101f82b8ecab", false, "demo10" },
                    { "9d724033-06e3-4ff6-a5cc-6472ef4d363b", 0, "522b89e9-7b2e-46b6-add3-0db741275228", "demo95@gmail.com", false, null, false, null, null, "DEMO95", "AQAAAAEAACcQAAAAEEJQ8P0SWlDfZAtL2IsnRoT9MtEIPSRvnpORKYiA9FpMnM3IDuZtHKEMPIfHsZx0Jg==", null, false, "adf6876b-7d00-4cdb-ba82-06d7bf91de85", false, "demo95" },
                    { "9ec37c81-c4b3-4f76-9df9-9d4f366442e9", 0, "bf220c4c-611f-4bc6-acae-d09f374ef236", "demo79@gmail.com", false, null, false, null, null, "DEMO79", "AQAAAAEAACcQAAAAEJwhGvna+3yqE+MdUwlDVw6GGxFGhA/kJcVyE4eszapRE8mnLaazhj8EkVGmCKl4Kg==", null, false, "b03b2773-5343-436f-ae08-6af7f91b4843", false, "demo79" },
                    { "9f4e0d6b-75f5-47ae-82ec-7d59e67c3e22", 0, "5c6bf4a1-2b8e-4621-b89c-0a0b723a03d2", "demo68@gmail.com", false, null, false, null, null, "DEMO68", "AQAAAAEAACcQAAAAEHJ4u4b32ns5pmm7H/jN1TZ6Il6x/srYRCwYadyfqpu89KYTorS63RtA9fgPS854Uw==", null, false, "cacd1935-32f6-4d36-a8a0-cffa2b1ba464", false, "demo68" },
                    { "9f6de330-aa7b-459c-9ee6-c811988bf8d8", 0, "f715a496-4847-4a73-8990-eefe2493eb6e", "demo61@gmail.com", false, null, false, null, null, "DEMO61", "AQAAAAEAACcQAAAAEAWxH53bAz/BKQvj+nzWUtQ03OU74AmzgDYlyTU8qX06JuWTvzypxwyGHOlcc7pfxw==", null, false, "37542f9b-4e93-42c6-898d-87e5a7aa8407", false, "demo61" },
                    { "9ffe1904-043d-4b57-9a72-692f5658e6cf", 0, "e95757cd-21bd-44ea-84d6-795637dcfdaf", "demo70@gmail.com", false, null, false, null, null, "DEMO70", "AQAAAAEAACcQAAAAEMjpC7gYl3xI2Jaiw86b9dr/9XlSQwxbJpW8vyT/47l+QLU5QCwrql1CnWIbzWXcLg==", null, false, "498b0eac-e36f-417d-8f4c-d7bce46636df", false, "demo70" },
                    { "a0abf4be-9112-45a7-b36a-cd6fa1776d69", 0, "c440b768-1ce4-4eaa-937b-a36a75de3958", "demo32@gmail.com", false, null, false, null, null, "DEMO32", "AQAAAAEAACcQAAAAEGLJYoHvsFzORi0eSDJv9cV2FMusIqg4ki2CN/7U4A4W7xEmhMkgV8ksdHfLKPQa3Q==", null, false, "0ac575f8-b371-4122-97d0-b78766205e99", false, "demo32" },
                    { "a22a5281-c891-4135-a1be-86b23f874c57", 0, "a84f0540-a3d5-4885-9453-f29064fdd848", "demo96@gmail.com", false, null, false, null, null, "DEMO96", "AQAAAAEAACcQAAAAEP83GaFP/vca77L+TAa2HvfD5pj71ptds+ZtGRIBmGc0MLSiK/p0tRdBg5dxda9vQw==", null, false, "96ed676f-6e06-45f9-92eb-30bf8970693e", false, "demo96" },
                    { "a31701a2-e58e-4318-aade-4ea8668536fe", 0, "397f71d4-dc0a-4d44-a27b-3193997dfade", "demo47@gmail.com", false, null, false, null, null, "DEMO47", "AQAAAAEAACcQAAAAEKpiUvTjXcxmo3hOtkcDWie4wiuhUBIZ5CquTXx0+qO8fuGZMai+Mz5xjVqw+bIiPw==", null, false, "115b6a76-5a79-4468-b63d-11c83d9bbe55", false, "demo47" },
                    { "a6ed6f99-fb30-41ba-a336-344c0dbddcc3", 0, "ecbb4a92-3361-46d7-8292-d11198d3bb2f", "demo80@gmail.com", false, null, false, null, null, "DEMO80", "AQAAAAEAACcQAAAAEMCWJrjmt+5aipKwRth5pETq2k6FzuIffqx8rmLWd7XUPHrP1pYgMzcXVDb6phXC6w==", null, false, "4a10d7dd-c671-4fd3-a0e5-a48108b8dbf0", false, "demo80" },
                    { "a94b13f9-3baa-431a-8c5a-659a0adb1e89", 0, "12a7048a-ebcb-4484-9ab1-67a12d941fba", "demo3@gmail.com", false, null, false, null, null, "DEMO3", "AQAAAAEAACcQAAAAELnFwDhblPsfTHv8pC/qkv9M48La5HV5hWEfvLfx7THMg/CY0ZjPHU2yTlMuLg7eyg==", null, false, "d5e86d42-620b-49db-86ac-7a85ac14a5da", false, "demo3" },
                    { "aa84f082-d704-4f3e-949d-925e07a57851", 0, "162c623a-e441-4f1a-851c-5f86077a5eaf", "demo75@gmail.com", false, null, false, null, null, "DEMO75", "AQAAAAEAACcQAAAAEBq0W45jH+QBy1tRff4dHKTobN/D7Rrbuvv8/mQdTFOytMtj5o9pRZJbwvUqKpuxVg==", null, false, "8cc6fafe-42cd-4240-a11a-272747c24310", false, "demo75" },
                    { "ace848b5-50a1-4ea0-bd3a-6c27ff62963d", 0, "d4749d5a-91c3-4487-9b0d-26227bbc75a6", "demo6@gmail.com", false, null, false, null, null, "DEMO6", "AQAAAAEAACcQAAAAEH7Xggzr0BxMWhkeNvHx/DAIhw/bisZ+u5hVE08vy29rGrdW0suvJcoEnV4sSIDGsw==", null, false, "1388c404-90ab-44b1-89d5-af45bd3cde6f", false, "demo6" },
                    { "b12995c6-1dc2-4879-b11c-d25e007732f0", 0, "1128fe10-4991-4554-942b-83a01e9f7293", "demo67@gmail.com", false, null, false, null, null, "DEMO67", "AQAAAAEAACcQAAAAEBGHrU1XeW2lpujjSghCef/t7GvzqSaMGe3TYrZ7MtSvHPMPpAPTwGPWQHtySfciVA==", null, false, "319b16cf-81bb-41f7-bd61-685e042ac053", false, "demo67" },
                    { "b2390311-5457-4f64-bc6b-0f9358efc944", 0, "f68db651-90db-42b0-98da-fad0482a003e", "demo72@gmail.com", false, null, false, null, null, "DEMO72", "AQAAAAEAACcQAAAAEAtVZdK6eyCA4N4+sZEeJhvdZ89kZM7Dqb3PkuK3CFSLxwy5BLT8U/ovkSPfb1Cy0A==", null, false, "3e9e5436-63c2-4fb4-84fd-44936d588187", false, "demo72" },
                    { "b39b05a4-dab5-4b2f-b6d5-0bd37e3303ca", 0, "75c9c565-5ce2-4c08-a0bd-efa4cbbeb416", "demo62@gmail.com", false, null, false, null, null, "DEMO62", "AQAAAAEAACcQAAAAEEmJmvAlW/1TjmsMiigsxruBU+ed7t43TEa9EnT2nfDMbOjtoR2R8/p5PdyWS8SXvQ==", null, false, "04fc2cf4-f07e-4c0a-bf74-27ba8dac9ec9", false, "demo62" },
                    { "b4edf037-8b39-4b83-84fe-1ccf3a75c756", 0, "ba9c9587-8dde-4df8-b593-30ebf8f9ed8d", "demo51@gmail.com", false, null, false, null, null, "DEMO51", "AQAAAAEAACcQAAAAELEfZ/MTSe55jvJGY3coG7m6KkdobGCfXcoG9RXlCef55lVj9Wua+Ao3wYur3sOngg==", null, false, "c6ebc0de-01bd-462f-939e-762f449d5b68", false, "demo51" },
                    { "b7e34e37-5f09-4cc5-a28c-42ce48b273ff", 0, "22df10a0-d704-49c8-bcdc-d48241635fc1", "demo66@gmail.com", false, null, false, null, null, "DEMO66", "AQAAAAEAACcQAAAAENHWoksQ+p4J5qfWsYlua9a6AHP97ThFAiaUPmfM0RM2J6UJi2ZIOt/wlRZz/z1fuw==", null, false, "1ffbf190-d264-405f-9157-56a7a914239f", false, "demo66" },
                    { "b806f51f-ac6d-443f-9b04-3d6cbe86e929", 0, "015ebb85-69fc-4f99-b4c9-8d0b31410ed5", "demo26@gmail.com", false, null, false, null, null, "DEMO26", "AQAAAAEAACcQAAAAEHArgxYBcSnFqPMvY6Zk9I5A5skpRAfXiFgeMcHxurzlMTKSdqSGXOB8c0Gt7Ux+XA==", null, false, "48ad2a0d-98fc-4b8c-9a9e-e284b032df2c", false, "demo26" },
                    { "b86de36b-045c-4cfd-bb92-bd831137e1d0", 0, "15ee2cfd-9fc7-464a-9cea-ab36c6ff5475", "demo92@gmail.com", false, null, false, null, null, "DEMO92", "AQAAAAEAACcQAAAAEKRJWjojpu+IrrcbMsuQetYX/gM2dyrd8XGnMeoAh5PErugX/f09PghqNVTKNu0mQQ==", null, false, "324ca3ac-7cf7-4343-a062-6043f1e5ec1e", false, "demo92" },
                    { "b96e0e54-d27c-4bb8-b733-411ce2559112", 0, "ca5e04a8-e3ab-4f6b-829f-84bfe3a9d578", "demo14@gmail.com", false, null, false, null, null, "DEMO14", "AQAAAAEAACcQAAAAEHMK93pEQ08ruH3xkEw1NsmODGJMN93Jdh0J+jh1qolD4pqZR3Kb8Y10343+B7Uvcg==", null, false, "ca43643e-ed03-4be5-a28b-09f15d051d66", false, "demo14" },
                    { "ba5cd66b-4e0c-4e8f-8ccb-f5a0bf938338", 0, "37a50db5-98e5-4825-8830-dac4ac41e6d2", "demo55@gmail.com", false, null, false, null, null, "DEMO55", "AQAAAAEAACcQAAAAEGCTh93+N23nFlU9/RPe0DfBDEwigRtDWuR9V7DJNg6tWbgeexmOeJLykKf/1BYCwA==", null, false, "111c78dd-68e9-4615-bc0a-2e8c744fc735", false, "demo55" },
                    { "bddbc1e1-7115-4bb6-9333-7595d0588204", 0, "4eb06a24-6dbc-461a-b064-e5c83742cfd7", "demo43@gmail.com", false, null, false, null, null, "DEMO43", "AQAAAAEAACcQAAAAEDFoasb45zITI0j3G5pqj1GoBTX9zTh1HNJwKcjMK9vWewDjMPu/AHlvksYi8Yngvg==", null, false, "54520ab9-ca50-45ac-ace1-7fa9e99e38d4", false, "demo43" },
                    { "c087333c-fbaa-406a-92a1-9ced4975a5f9", 0, "c2ea3a37-7969-4ea7-8e45-cbf84508becd", "demo69@gmail.com", false, null, false, null, null, "DEMO69", "AQAAAAEAACcQAAAAEOAZG/Xf1cmMpmZQ3efBSJ9wHL7a/byFje+Y/5B3xVhOSjzpCwE+5me+3XpZ8NTK2g==", null, false, "60b95d9a-52c9-4f55-bc1a-53942f8733e0", false, "demo69" },
                    { "c0a5afd7-b87e-41fc-a55f-4877e8886383", 0, "4087d1e8-8aa4-473f-a2ef-7f231fae530d", "demo76@gmail.com", false, null, false, null, null, "DEMO76", "AQAAAAEAACcQAAAAEH+XhddhiE189USCJS/G4Bf4GgY6O8TuKtdQyw2POqys+6jtT/a39cI/x1zZPXI66w==", null, false, "dc16603e-84e2-427f-82e0-0b8d277a4666", false, "demo76" },
                    { "c1cfbacf-50d7-47b5-a54a-6e0832bf8318", 0, "133ecddb-0fba-4401-bb9b-0a468bc67ba1", "demo98@gmail.com", false, null, false, null, null, "DEMO98", "AQAAAAEAACcQAAAAEItW0gqOT+lazQUO7pPBLR2pmbJb5AYgDmDKTbEDlz0avV3xT3OMdu+PnyO9ZAlPjQ==", null, false, "f5855ff3-0b5d-4bef-87bd-f47ebbab4f08", false, "demo98" },
                    { "c4b2c83a-5165-47f4-8335-0ba1a4abf456", 0, "85a674ad-6961-4c03-9a1e-c225eda98064", "demo41@gmail.com", false, null, false, null, null, "DEMO41", "AQAAAAEAACcQAAAAEO7t0Q6EfZrhcuHCBZ+prwPN+l8xgLm8lo1oxzEX+B031wIgH35XoPbpsMs9OtuXCg==", null, false, "7088bf24-b4f4-4548-8a76-ed486d6a1b62", false, "demo41" },
                    { "c4cdcb71-472a-4928-bc4b-c0696b52a1dc", 0, "60a57bfc-8703-4fd2-86d4-a4281f9fb974", "demo65@gmail.com", false, null, false, null, null, "DEMO65", "AQAAAAEAACcQAAAAECWWkwuuzPU0eOkouN7X9+RCZTPeyVPu+jDxdg5vtoD2RFTe7MzL8JtJZKCLzGvPgA==", null, false, "1093a962-d876-407b-afe9-aa664a151a4d", false, "demo65" },
                    { "ca71f36c-564f-4ca0-a5cb-7b5de7078c3f", 0, "684d50d3-518f-4b18-b933-96e208cfacc7", "demo37@gmail.com", false, null, false, null, null, "DEMO37", "AQAAAAEAACcQAAAAEChD+b+HJjKL4uHixczozxmVWq2mg08XM/Ns0iKXlVT9Uq8zrGFaeLMwcZO598Bohw==", null, false, "3181fe89-495f-4495-b553-27671d44fb8e", false, "demo37" },
                    { "cd94eb51-4758-41a0-9844-0b2e4267ca08", 0, "a966e075-4a73-410c-b767-3afb4a1fd62a", "demo73@gmail.com", false, null, false, null, null, "DEMO73", "AQAAAAEAACcQAAAAECbmxRY9AJdTQIzSP7HIGdXbgQsA+LT/Ga6qu5MW832RTXdR8iu+3jT7ZKYOiIFpqQ==", null, false, "655e9945-d604-4a9a-9b9e-65555a86fae3", false, "demo73" },
                    { "d3d38229-ed84-4171-a8ec-95b46dacb72b", 0, "6d5802c3-c177-4b60-8565-2fde092af938", "demo81@gmail.com", false, null, false, null, null, "DEMO81", "AQAAAAEAACcQAAAAEMhSX5ap4xXgTJ9zn08Ltd5IBONVROdvdsqTWqFyT/PtX8SKu4wZ0Uizd64UGSASxQ==", null, false, "d0104068-94d1-4e68-a80c-84b1fefebff3", false, "demo81" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "d5069aab-4015-426a-a1db-f015208e5634", 0, "14f3599a-474f-4cd7-98b6-6a94e2e2465e", "demo5@gmail.com", false, null, false, null, null, "DEMO5", "AQAAAAEAACcQAAAAEF28ySEYGboUzuAUA41aWr3YGvnEEyGed17xvYXkbGPlfgTpsQF8VLrHQD4BHuJKkA==", null, false, "0420553b-b31d-4aa5-a5ce-218281b0e758", false, "demo5" },
                    { "d86262bf-ff0d-4448-8b7b-fcf0a2e4c70a", 0, "faa6f8ae-c46f-4771-a009-90487a11ad76", "demo33@gmail.com", false, null, false, null, null, "DEMO33", "AQAAAAEAACcQAAAAED46OG+Vxn2+9d2uh/wnsKMngHLUaIs7Jv6kfbFm4QsRbOGlC6N/R4RQCQbsWUVFug==", null, false, "a1a9ffa5-d4eb-419d-9100-5fff28d3a74a", false, "demo33" },
                    { "da10dc99-0275-4c50-86ad-6b2a2ab039f5", 0, "c7e496c6-7412-40af-957a-afbbfb7bdac8", "demo9@gmail.com", false, null, false, null, null, "DEMO9", "AQAAAAEAACcQAAAAEMAvRvfa18EP+j7GuF1yFwGzrlJ3w1cEmxehGTCBdUbjI+4SQ3yVVKNEyVGIYJGrkQ==", null, false, "6ce70589-2f74-43e6-84c5-c24aa389f4ab", false, "demo9" },
                    { "dc6c3edc-ca6a-4ec6-88bf-55a4d0c386bd", 0, "93256b36-0aee-4cf5-b189-a44dc3bd70a1", "demo38@gmail.com", false, null, false, null, null, "DEMO38", "AQAAAAEAACcQAAAAEDWqjRBxyOEQrkFY57GOm2s2JvCcH2qeCcZOCbul39SLTOQrYmbXbRG4u28vjO3xqg==", null, false, "72c91e07-42a1-4edc-9830-b979d360590e", false, "demo38" },
                    { "dd8308e6-76ad-4ddb-ba66-1ce309722132", 0, "30941b70-5547-4b66-b2e5-0a6fdda23e67", "demo63@gmail.com", false, null, false, null, null, "DEMO63", "AQAAAAEAACcQAAAAEGJ4aw3h4n1fcfWwuVKXWQ1kq9zPOxe6RdGwVph/dEV6qDv3U1HRduKXxz3nhI9x7w==", null, false, "924c5fac-3808-44c8-afb9-fbea1334bacb", false, "demo63" },
                    { "de860aa1-ee68-4463-be74-fd2e2e8a2485", 0, "046d1706-fb6c-4800-8fbc-4400123684db", "demo90@gmail.com", false, null, false, null, null, "DEMO90", "AQAAAAEAACcQAAAAEFWPVS6JPUu3KnO7QygrSumFI2/jRjyh/DWA1u2hEIspcEAN4ZL3lzMoSN7E9Lxx9Q==", null, false, "db90b876-6f4c-423b-8807-9c261f295a88", false, "demo90" },
                    { "dead277a-cbdc-41d7-b29c-ce10cd2a5abc", 0, "0a748163-a488-4875-a502-fa9819a191f6", "demo28@gmail.com", false, null, false, null, null, "DEMO28", "AQAAAAEAACcQAAAAEHqiW9je/dxP8hWdlh7Tsx11iFIuVSVJ/S6OLVVne+pSspSN03GtfzJzZ8hJMcIq4g==", null, false, "59b2ba96-fcad-4377-be83-484b94d933ca", false, "demo28" },
                    { "dfe198a6-2b51-4280-a8e9-5feab2a0cf87", 0, "bd875e3c-a764-4989-8c5f-f53a0ed67e42", "demo7@gmail.com", false, null, false, null, null, "DEMO7", "AQAAAAEAACcQAAAAEFF6NdVZlyx7z6tUZSKsIYTU8AwhHD1QkbCI9Md0FyyzI5ZkM/zIve6TvgwtNZrJ2Q==", null, false, "759ceaf5-b525-478f-8ee1-dd885e0aa021", false, "demo7" },
                    { "e18a912a-2109-4172-9d22-8b17df321295", 0, "2109a5d8-d707-4e4c-8127-a3f8f9a88198", "demo42@gmail.com", false, null, false, null, null, "DEMO42", "AQAAAAEAACcQAAAAEBvKEPTECBJQKL/Eub4D/2Qz7o0PwpaoIooOU1GI5MnOrhQMx/WklGmRQebwoqKYFw==", null, false, "61dfa480-3e69-4818-98eb-36cd2a9196fc", false, "demo42" },
                    { "e275f767-ca20-4155-b64e-a808123dfc10", 0, "0b5d8f56-f1e8-495f-a8d2-455670828339", "demo31@gmail.com", false, null, false, null, null, "DEMO31", "AQAAAAEAACcQAAAAECFb/roeog8LmjBcP2N2jfecKhe12kOkx9rkqP85luyK89fZbyK1/FM7tzIhUynEwg==", null, false, "b55e1fac-ef6b-4a41-a0bd-67c0d13ba30a", false, "demo31" },
                    { "e3772e97-2700-465a-877d-aca6241b0090", 0, "6b4917cf-9685-4544-9aaf-65c06a02cb78", "demo16@gmail.com", false, null, false, null, null, "DEMO16", "AQAAAAEAACcQAAAAEHzXx7SQcBzxIDiUTT2zUVw5aXzxGjiut8Pg+VHCE3/Sdn8LC38gPsoQZxvsnSZUCA==", null, false, "b027cc38-8d02-4f47-949f-2b2c8a71a0ee", false, "demo16" },
                    { "e5136de3-fd6f-4a75-8fe8-ba08c48e506e", 0, "fabd3d64-1dbc-408a-8d3e-733b5729f181", "demo83@gmail.com", false, null, false, null, null, "DEMO83", "AQAAAAEAACcQAAAAEIFzMG1qc3UIjClVSIkXHfDGuMsTQF8KdSHI1rpbxWooZDHC3AOxWKogHS+Z7h8W8g==", null, false, "bdfc96cc-e834-4ab0-9724-3a74cd592bba", false, "demo83" },
                    { "ea13e1aa-0801-41a0-ae9d-d409ad12d3c3", 0, "02c279f3-1429-4ba1-a34f-df0709f9e9a8", "demo45@gmail.com", false, null, false, null, null, "DEMO45", "AQAAAAEAACcQAAAAENYDVxouBRoZbhJL0CBhRs8TL3QNMpdTFA7jO6z/NqUE3wtkNsHlN5wN2kFq6Sbtuw==", null, false, "31598a51-7a81-4c7f-ae7f-7830e6bd1edf", false, "demo45" },
                    { "eb31e760-ac37-4770-b06f-457a714739d0", 0, "2222c06e-82d4-4f9b-970c-14a6038e91e2", "demo54@gmail.com", false, null, false, null, null, "DEMO54", "AQAAAAEAACcQAAAAEIgF3vkqJeo6tIvt/XeaX7sdHKyekEJrQow1o/HHqWSX4Ock7ZkbPt1cWO9aroYxVQ==", null, false, "cf37145a-ead7-4002-8046-9165d51d9b1e", false, "demo54" },
                    { "ee704fb6-7a2d-4056-b9dd-9998119d8b15", 0, "91db16b6-221b-4658-9837-74b6432f759b", "demo52@gmail.com", false, null, false, null, null, "DEMO52", "AQAAAAEAACcQAAAAEIGTJVBE9F/e+DJfziYC+4d/A3WYsmVBNqat7Xq97v0w2sW6JimSwdqqHh7fcsBKBA==", null, false, "698e9927-c34d-4e62-b966-a2601a43d27e", false, "demo52" },
                    { "efb2311a-fa23-4184-9e82-8aca148493c7", 0, "46b9643a-a69c-4547-ac83-95eb6585caf1", "demo59@gmail.com", false, null, false, null, null, "DEMO59", "AQAAAAEAACcQAAAAENYrlDPYtWidkehHd12tJxrPFGX37w79rU3KKnPuFvPfwF+7pE20KSJ17FtuSlonyA==", null, false, "bbbd8b67-16c1-4950-b7d9-78d276024817", false, "demo59" },
                    { "f083542e-a46c-47fa-b1ec-7b014e09b27f", 0, "5f0aa8a6-f10f-4e78-b986-ce91f4dfaeeb", "demo19@gmail.com", false, null, false, null, null, "DEMO19", "AQAAAAEAACcQAAAAEK4Uxop+dbWeMPFuqCmU4ZnCchx5qOfwKFf5vq8q37YPXmROOf3asDv9oT6LDzEBJA==", null, false, "effd0251-de36-4499-bedf-9de9ad88756a", false, "demo19" },
                    { "f136fa2a-992b-40b5-9c44-ce72e8ddba25", 0, "bf935ea5-cc95-48ab-b1fa-d44fd7b40455", "demo4@gmail.com", false, null, false, null, null, "DEMO4", "AQAAAAEAACcQAAAAENKtIROou24ClSY1TePE2KACudw8kqBW+tB7Y/yf0BKL1VzM56jLnUuumGTmK7fkCw==", null, false, "cb02c7e9-d470-4e77-8e87-d26202209d82", false, "demo4" },
                    { "f974cd01-a43d-4b92-88cb-8e2df11d739f", 0, "e65c3342-c4e2-4e11-ab18-bc41f1ec8a3b", "demo11@gmail.com", false, null, false, null, null, "DEMO11", "AQAAAAEAACcQAAAAEIkZQUaP79SviZHdPGn1YGjVe3B+W4zZ4O9oEYcfcVTIFXNs4MNAYjnnK7jzc+Qe4g==", null, false, "91b6e033-c2f1-4e40-a405-5a0af252b067", false, "demo11" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CreatedDate", "DominantHand", "FirstName", "InvertedNameOrder", "LastName", "ModifiedDate", "NickName", "Ownership", "Sex" },
                values: new object[,]
                {
                    { 11L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Felipe", false, "Morita", new DateTime(2023, 11, 14, 23, 19, 20, 943, DateTimeKind.Local).AddTicks(9040), null, 1, 1 },
                    { 12L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Ilija", false, "Lupulesku", new DateTime(2023, 11, 14, 23, 19, 20, 943, DateTimeKind.Local).AddTicks(9070), "Lupi", 1, 1 },
                    { 13L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Biljana", false, "Golić", new DateTime(2023, 11, 14, 23, 19, 20, 943, DateTimeKind.Local).AddTicks(9080), "Biba", 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "04b594c0-f5ef-45e0-be39-fcc76372986d" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "0bcdf15d-064c-4e00-afbc-0a96ef149624" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "0eb1f2ee-4067-49c4-bebd-78ede6d9b87f" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "15799da3-9eae-499f-8f5b-50f0cffbd2db" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "173c8b1c-2dcc-4668-9a86-09769886f211" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "17e09b65-8ffc-4e6b-97ab-18f5557ca315" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "1a86db69-6a3a-42d5-9ff1-0e368d5562ad" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "1d18cc3c-6336-4af4-ace3-46b86e98ed3a" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "249cd65e-8528-4ca8-9f8f-278150445a10" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "2b1813c6-b5c0-49ed-81dc-d4342f457954" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "3104c9f6-6dbf-4cf3-a542-462ad606d2a2" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "3171181e-1d0f-41d8-a626-a6f0d29be678" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "338760fc-7971-4a63-959c-a9d16c954421" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "35f0c66b-fb97-4c90-964c-c5986fdbaf63" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "39f76f4b-54c5-4407-90d7-4c98a64b2d4b" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "3b983e1b-6908-49fb-ac17-f9111d4df502" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "3c87c60e-cf18-4514-b122-ab09b1753677" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "3e07cd99-f3a8-42ba-8710-6cf498d05b3f" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "41be9677-d873-45bb-927d-1ddbef61fb26" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "43d8ef57-f237-44b5-b10c-0599d36ce1ab" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "4566331e-202a-4100-a1b0-823bfc86c5a1" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "49bd3837-9e6f-41bd-b709-f835f06f142f" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "49efa8c2-1a71-478e-8b9a-bc0c5061829f" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "4ad9d690-c153-42a6-be1d-d4b9ca74d2d4" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "53bd4bd1-f647-46bd-b4ee-5f5b11d9370d" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "53e0f2fe-cd73-4d6d-83d2-a3173dd32a34" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "542b4881-199a-4b98-8214-daca312a12ed" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "5835cf98-55e2-4732-95f9-d62566a3b4b8" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "59fbfea0-4d38-41c4-972f-7e502d0e5d15" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "5cfbb116-5005-4f61-8fd2-9dcb63d0bdc4" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "5d4c73b7-0133-4fdc-9fdb-3c1573f8ae68" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "60e556b9-84c8-47d1-81dc-eb82f4078c33" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "68caf9c3-fbca-4058-913d-bff7dc6a5dfb" },
                    { "382ececc-2b01-4e85-a63f-2387f547c1f2", "6b0ec92d-05e1-4fbf-929c-2018c02164c1" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "6be793bc-c29c-43aa-80f6-7fab7d392bb9" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "723543d4-3deb-446d-a737-ee68b3d03dbb" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "72d48439-5aaa-4e98-8b45-e382bb34617d" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "7a654e0c-4087-4c5a-aaa0-9f5e68cd9200" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "7ebc5810-66d9-48d5-8fa2-0b7ff85f69af" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "7f689b0e-4699-42e2-afaf-1ab55fede3b7" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "801c9002-41aa-43ec-913d-788a5917c6e3" },
                    { "097f6233-0db5-4347-aad0-14e20625e5be", "81d8d81c-c4c5-42f5-b427-10d9c7b9b615" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "833cfacf-d13a-4152-95ea-189243a8a7fa" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "840c004b-abd3-4e1f-be23-81c656dc1018" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "847954b0-abfe-4c83-8ecc-31ddb4041c02" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "871f2a58-e6cf-428e-8c61-fe46e22cd296" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "892495de-3732-4994-948b-2102a0ef3fe2" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "913863f2-32aa-4faa-8094-e170094aef0f" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "944ce887-2c07-477e-9b84-d6ffad369846" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "9a9cc7fd-e0cc-49f1-9a49-356a25200749" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "9cd7d2f3-6adf-47ab-b2b8-ef8e7ce626a3" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "9d724033-06e3-4ff6-a5cc-6472ef4d363b" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "9ec37c81-c4b3-4f76-9df9-9d4f366442e9" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "9f4e0d6b-75f5-47ae-82ec-7d59e67c3e22" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "9f6de330-aa7b-459c-9ee6-c811988bf8d8" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "9ffe1904-043d-4b57-9a72-692f5658e6cf" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "a0abf4be-9112-45a7-b36a-cd6fa1776d69" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "a22a5281-c891-4135-a1be-86b23f874c57" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "a31701a2-e58e-4318-aade-4ea8668536fe" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "a6ed6f99-fb30-41ba-a336-344c0dbddcc3" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "a94b13f9-3baa-431a-8c5a-659a0adb1e89" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "aa84f082-d704-4f3e-949d-925e07a57851" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "ace848b5-50a1-4ea0-bd3a-6c27ff62963d" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "b12995c6-1dc2-4879-b11c-d25e007732f0" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "b2390311-5457-4f64-bc6b-0f9358efc944" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "b39b05a4-dab5-4b2f-b6d5-0bd37e3303ca" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "b4edf037-8b39-4b83-84fe-1ccf3a75c756" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "b7e34e37-5f09-4cc5-a28c-42ce48b273ff" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "b806f51f-ac6d-443f-9b04-3d6cbe86e929" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "b86de36b-045c-4cfd-bb92-bd831137e1d0" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "b96e0e54-d27c-4bb8-b733-411ce2559112" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "ba5cd66b-4e0c-4e8f-8ccb-f5a0bf938338" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "bddbc1e1-7115-4bb6-9333-7595d0588204" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "c087333c-fbaa-406a-92a1-9ced4975a5f9" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "c0a5afd7-b87e-41fc-a55f-4877e8886383" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "c1cfbacf-50d7-47b5-a54a-6e0832bf8318" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "c4b2c83a-5165-47f4-8335-0ba1a4abf456" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "c4cdcb71-472a-4928-bc4b-c0696b52a1dc" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "ca71f36c-564f-4ca0-a5cb-7b5de7078c3f" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "cd94eb51-4758-41a0-9844-0b2e4267ca08" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "d3d38229-ed84-4171-a8ec-95b46dacb72b" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "d5069aab-4015-426a-a1db-f015208e5634" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "d86262bf-ff0d-4448-8b7b-fcf0a2e4c70a" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "da10dc99-0275-4c50-86ad-6b2a2ab039f5" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "dc6c3edc-ca6a-4ec6-88bf-55a4d0c386bd" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "dd8308e6-76ad-4ddb-ba66-1ce309722132" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "de860aa1-ee68-4463-be74-fd2e2e8a2485" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "dead277a-cbdc-41d7-b29c-ce10cd2a5abc" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "dfe198a6-2b51-4280-a8e9-5feab2a0cf87" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "e18a912a-2109-4172-9d22-8b17df321295" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "e275f767-ca20-4155-b64e-a808123dfc10" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "e3772e97-2700-465a-877d-aca6241b0090" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "e5136de3-fd6f-4a75-8fe8-ba08c48e506e" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "ea13e1aa-0801-41a0-ae9d-d409ad12d3c3" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "eb31e760-ac37-4770-b06f-457a714739d0" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "ee704fb6-7a2d-4056-b9dd-9998119d8b15" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "efb2311a-fa23-4184-9e82-8aca148493c7" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "f083542e-a46c-47fa-b1ec-7b014e09b27f" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "f136fa2a-992b-40b5-9c44-ce72e8ddba25" },
                    { "1be3f673-24b0-4b5e-99b8-1cd1c51fb2b0", "f974cd01-a43d-4b92-88cb-8e2df11d739f" }
                });

            migrationBuilder.InsertData(
                table: "Techniques",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "PlayerId", "SourcePath", "Title" },
                values: new object[,]
                {
                    { 14L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 14, 23, 19, 20, 943, DateTimeKind.Local).AddTicks(9090), 11L, "/players/31-Biba-BH-High-Arc.zip", "BH Loop Off Push" },
                    { 15L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 14, 23, 19, 20, 943, DateTimeKind.Local).AddTicks(9090), 11L, "/players/31-Biba-BH-High-Arc.zip", "FH Loop Off Block" },
                    { 16L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 14, 23, 19, 20, 943, DateTimeKind.Local).AddTicks(9100), 12L, "/players/31-Biba-BH-High-Arc.zip", "FH Loop Off Block" },
                    { 17L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 14, 23, 19, 20, 943, DateTimeKind.Local).AddTicks(9100), 12L, "/players/31-Biba-BH-High-Arc.zip", "FH Active Block" },
                    { 18L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 14, 23, 19, 20, 943, DateTimeKind.Local).AddTicks(9100), 13L, "/players/31-Biba-BH-High-Arc.zip", "FH Counter Loop" },
                    { 19L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 14, 23, 19, 20, 943, DateTimeKind.Local).AddTicks(9100), 13L, "/players/31-Biba-BH-High-Arc.zip", "BH High Arc" },
                    { 20L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 14, 23, 19, 20, 943, DateTimeKind.Local).AddTicks(9100), 13L, "/players/31-Biba-BH-High-Arc.zip", "BH Smash High Ball" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserPlayer_PlayersId",
                table: "ApplicationUserPlayer",
                column: "PlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Techniques_PlayerId",
                table: "Techniques",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserPlayer");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Techniques");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
