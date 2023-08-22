using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransneftEnergy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrentTransformers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TransformationRatio = table.Column<double>(type: "float", nullable: false),
                    VerificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentTransformers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityMeters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    VerificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityMeters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoltageTransformers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    TransformationRatio = table.Column<double>(type: "float", nullable: false),
                    VerificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoltageTransformers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChildOrganizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentOrganizationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildOrganizations_Organizations_ParentOrganizationId",
                        column: x => x.ParentOrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsumptionObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChildOrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumptionObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumptionObjects_ChildOrganizations_ChildOrganizationId",
                        column: x => x.ChildOrganizationId,
                        principalTable: "ChildOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityMeasuringPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ConsumptionObjectId = table.Column<int>(type: "int", nullable: false),
                    ElectricityMeterId = table.Column<int>(type: "int", nullable: false),
                    CurrentTransformerId = table.Column<int>(type: "int", nullable: false),
                    VoltageTransformerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityMeasuringPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricityMeasuringPoints_ConsumptionObjects_ConsumptionObjectId",
                        column: x => x.ConsumptionObjectId,
                        principalTable: "ConsumptionObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectricityMeasuringPoints_CurrentTransformers_CurrentTransformerId",
                        column: x => x.CurrentTransformerId,
                        principalTable: "CurrentTransformers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectricityMeasuringPoints_ElectricityMeters_ElectricityMeterId",
                        column: x => x.ElectricityMeterId,
                        principalTable: "ElectricityMeters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectricityMeasuringPoints_VoltageTransformers_VoltageTransformerId",
                        column: x => x.VoltageTransformerId,
                        principalTable: "VoltageTransformers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectricitySupplyPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    MaxPower = table.Column<double>(type: "float", nullable: false),
                    ConsumptionObjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricitySupplyPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricitySupplyPoints_ConsumptionObjects_ConsumptionObjectId",
                        column: x => x.ConsumptionObjectId,
                        principalTable: "ConsumptionObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SettlementMeters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElectricitySupplyPointId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettlementMeters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettlementMeters_ElectricitySupplyPoints_ElectricitySupplyPointId",
                        column: x => x.ElectricitySupplyPointId,
                        principalTable: "ElectricitySupplyPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityMeasuringPointsSettlementMeters",
                columns: table => new
                {
                    ElectricityMeasuringPointId = table.Column<int>(type: "int", nullable: false),
                    SettlementMeterId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityMeasuringPointsSettlementMeters", x => new { x.ElectricityMeasuringPointId, x.SettlementMeterId, x.StartTime, x.EndTime });
                    table.ForeignKey(
                        name: "FK_ElectricityMeasuringPointsSettlementMeters_ElectricityMeasuringPoints_ElectricityMeasuringPointId",
                        column: x => x.ElectricityMeasuringPointId,
                        principalTable: "ElectricityMeasuringPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectricityMeasuringPointsSettlementMeters_SettlementMeters_SettlementMeterId",
                        column: x => x.SettlementMeterId,
                        principalTable: "SettlementMeters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildOrganizations_ParentOrganizationId",
                table: "ChildOrganizations",
                column: "ParentOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumptionObjects_ChildOrganizationId",
                table: "ConsumptionObjects",
                column: "ChildOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityMeasuringPoints_ConsumptionObjectId",
                table: "ElectricityMeasuringPoints",
                column: "ConsumptionObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityMeasuringPoints_CurrentTransformerId",
                table: "ElectricityMeasuringPoints",
                column: "CurrentTransformerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityMeasuringPoints_ElectricityMeterId",
                table: "ElectricityMeasuringPoints",
                column: "ElectricityMeterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityMeasuringPoints_VoltageTransformerId",
                table: "ElectricityMeasuringPoints",
                column: "VoltageTransformerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityMeasuringPointsSettlementMeters_SettlementMeterId",
                table: "ElectricityMeasuringPointsSettlementMeters",
                column: "SettlementMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricitySupplyPoints_ConsumptionObjectId",
                table: "ElectricitySupplyPoints",
                column: "ConsumptionObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SettlementMeters_ElectricitySupplyPointId",
                table: "SettlementMeters",
                column: "ElectricitySupplyPointId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricityMeasuringPointsSettlementMeters");

            migrationBuilder.DropTable(
                name: "ElectricityMeasuringPoints");

            migrationBuilder.DropTable(
                name: "SettlementMeters");

            migrationBuilder.DropTable(
                name: "CurrentTransformers");

            migrationBuilder.DropTable(
                name: "ElectricityMeters");

            migrationBuilder.DropTable(
                name: "VoltageTransformers");

            migrationBuilder.DropTable(
                name: "ElectricitySupplyPoints");

            migrationBuilder.DropTable(
                name: "ConsumptionObjects");

            migrationBuilder.DropTable(
                name: "ChildOrganizations");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
