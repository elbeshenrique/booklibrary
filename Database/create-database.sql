IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'BookLibrary')
BEGIN
    CREATE DATABASE BookLibrary;
END