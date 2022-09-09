# Readme

## How to run test

- Run Test

  ```sh
  dotnet test
  ```

## Test Options and Reports

1. Generate Unit Test Report

   ```sh
   dotnet test --logger "html;logfilename=testResults.html"
   ```

2. Generate Coverage Report

   ```sh
   dotnet test --collect:"XPlat Code Coverage"
   ```

   2.1. Generate `html` report from `xml` report

   - Install `dotnet-reportgenerator-globaltool`

     ```sh
     dotnet tool install -g dotnet-reportgenerator-globaltool
     ```

     > หลังจาก install dotnet-reportgenerator-globaltool ให้ set path ไปที่ reportgenerator

   - Generate `html` report

     ```sh
     reportgenerator -reports:"Path/To/Credit.Tests/TestResults/<hash value>/coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
     ```

3. Generate JUnit Report

   - เข้าไปที่ Test Project

     ```sh
     cd Credit.Tests
     ```

   - Install `JunitXml.TestLogger`

     ```sh
     dotnet add package JunitXml.TestLogger --version 3.0.114
     ```

   - Run JUnit Report(ไม่ระบุ path)

     ```sh
     dotnet test --logger:junit
     ```

   - Run JUnit Report(ระบุ path)

     ```sh
     dotnet test --logger:"junit;LogFilePath=test-result.xml"
     ```
