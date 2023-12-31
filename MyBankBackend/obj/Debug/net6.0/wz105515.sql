CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Customers" (
    "Id" uuid NOT NULL,
    "FirstName" text NOT NULL,
    "LastName" text NOT NULL,
    "Email" text NOT NULL,
    "BirthDate" date NOT NULL,
    CONSTRAINT "PK_Customers" PRIMARY KEY ("Id")
);

CREATE TABLE "Accounts" (
    "Id" uuid NOT NULL,
    "Balance" numeric NOT NULL,
    "Number" text NOT NULL,
    "Password" text NOT NULL,
    "CustomerId" uuid NOT NULL,
    CONSTRAINT "PK_Accounts" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Accounts_Customers_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES "Customers" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Accounts_CustomerId" ON "Accounts" ("CustomerId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231231035211_initial', '6.0.0');

COMMIT;

START TRANSACTION;

DROP INDEX "IX_Accounts_CustomerId";

CREATE UNIQUE INDEX "IX_Accounts_CustomerId" ON "Accounts" ("CustomerId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20231231040857_CustomerAndAccount', '6.0.0');

COMMIT;

