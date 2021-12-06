IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'Payment_Company')
  BEGIN
    CREATE DATABASE Payment_Company
    END

USE [Payment_Company]
GO
